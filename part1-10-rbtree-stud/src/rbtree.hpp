////////////////////////////////////////////////////////////////////////////////
/// \file
/// \brief     Реализация классов красно-черного дерева
/// \author    Sergey Shershakov
/// \version   0.1.0
/// \date      01.05.2017
///            This is a part of the course "Algorithms and Data Structures" 
///            provided by  the School of Software Engineering of the Faculty 
///            of Computer Science at the Higher School of Economics.
///
/// "Реализация" (шаблонов) методов, описанных в файле rbtree.h
///
////////////////////////////////////////////////////////////////////////////////

#include <stdexcept>        // std::invalid_argument


namespace xi {


//==============================================================================
// class RBTree::node
//==============================================================================

    template<typename Element, typename Compar>
    RBTree<Element, Compar>::Node::~Node() {
        if (_left)
            delete _left;
        if (_right)
            delete _right;
    }


    template<typename Element, typename Compar>
    typename RBTree<Element, Compar>::Node *RBTree<Element, Compar>::Node::setLeft(Node *lf) {
        // предупреждаем повторное присвоение
        if (_left == lf)
            return nullptr;

        // если новый левый — действительный элемент
        if (lf) {
            // если у него был родитель
            if (lf->_parent) {
                // ищем у родителя, кем был этот элемент, и вместо него ставим бублик
                if (lf->_parent->_left == lf)
                    lf->_parent->_left = nullptr;
                else                                    // доп. не проверяем, что он был правым, иначе нарушение целостности
                    lf->_parent->_right = nullptr;
            }

            // задаем нового родителя
            lf->_parent = this;
        }

        // если у текущего уже был один левый — отменяем его родительскую связь и вернем его
        Node *prevLeft = _left;
        _left = lf;

        if (prevLeft)
            prevLeft->_parent = nullptr;

        return prevLeft;
    }


    template<typename Element, typename Compar>
    typename RBTree<Element, Compar>::Node *RBTree<Element, Compar>::Node::setRight(Node *rg) {
        // предупреждаем повторное присвоение
        if (_right == rg)
            return nullptr;

        // если новый правый — действительный элемент
        if (rg) {
            // если у него был родитель
            if (rg->_parent) {
                // ищем у родителя, кем был этот элемент, и вместо него ставим бублик
                if (rg->_parent->_left == rg)
                    rg->_parent->_left = nullptr;
                else                                    // доп. не проверяем, что он был правым, иначе нарушение целостности
                    rg->_parent->_right = nullptr;
            }

            // задаем нового родителя
            rg->_parent = this;
        }

        // если у текущего уже был один левый — отменяем его родительскую связь и вернем его
        Node *prevRight = _right;
        _right = rg;

        if (prevRight)
            prevRight->_parent = nullptr;

        return prevRight;
    }


//==============================================================================
// class RBTree
//==============================================================================

    template<typename Element, typename Compar>
    RBTree<Element, Compar>::RBTree() {
        _root = nullptr;
        _dumper = nullptr;
    }

    template<typename Element, typename Compar>
    RBTree<Element, Compar>::~RBTree() {
        // грохаем пока что всех через корень
        if (_root)
            delete _root;
    }


    template<typename Element, typename Compar>
    void RBTree<Element, Compar>::deleteNode(Node *nd) {
        // если переданный узел не существует, просто ничего не делаем, т.к. в вызывающем проверок нет
        if (nd == nullptr)
            return;

        // потомков убьет в деструкторе
        delete nd;
    }


    template<typename Element, typename Compar>
    void RBTree<Element, Compar>::insert(const Element &key) {
        // этот метод можно оставить студентам целиком
        Node *newNode = insertNewBstEl(key);

        // отладочное событие
        if (_dumper)
            _dumper->rbTreeEvent(IRBTreeDumper<Element, Compar>::DE_AFTER_BST_INS, this, newNode);

        rebalance(newNode);

        // отладочное событие
        if (_dumper)
            _dumper->rbTreeEvent(IRBTreeDumper<Element, Compar>::DE_AFTER_INSERT, this, newNode);

    }


    template<typename Element, typename Compar>
    typename RBTree<Element, Compar>::Node *RBTree<Element, Compar>::nfind(const Element &key) {
        Node *current = _root;
        while (current != nullptr)
            if (key == current->_key)
                return current;
            else
                current = key < current->_key ? current->_left : current->_right;
        return nullptr;
    }

    template<typename Element, typename Compar>
    typename RBTree<Element, Compar>::Node *
    RBTree<Element, Compar>::insertNewBstEl(const Element &key) {
        Node *current, *parent, *x;

        current = _root;
        parent = nullptr;
        while (current != nullptr) {
            if (key == current->_key)
                return current;
            parent = current;
            current = key < current->_key ? current->_left : current->_right;
        }

        x = new Node();
        x->_key = key;
        x->_parent = parent;
        x->_left = nullptr;
        x->_right = nullptr;
        x->setRed();

        if (parent) {
            if (key < parent->_key)
                parent->_left = x;
            else
                parent->_right = x;
        } else {
            _root = x;
        }

        return x;
    }


    template<typename Element, typename Compar>
    typename RBTree<Element, Compar>::Node *
    RBTree<Element, Compar>::rebalanceDUG(Node *nd) {
        if (nd->_parent->_parent) {
            if (nd->_parent == nd->_parent->_parent->getLeft()) {
                Node *y = nd->_parent->_parent->_right;
                if (y && y->isRed()) {
                    nd->_parent->setBlack();
                    y->setBlack();
                    nd->_parent->_parent->setRed();

                    if (_dumper)
                        _dumper->rbTreeEvent(IRBTreeDumper<Element, Compar>::DE_AFTER_RECOLOR1, this, nd);

                    nd = nd->_parent->_parent;
                } else {
                    if (nd == nd->_parent->getRight()) {
                        nd = nd->_parent;
                        rotLeft(nd);
                    }
                    nd->_parent->setBlack();
                    nd->_parent->_parent->setRed();
                    rotRight(nd->_parent->_parent);
                }
            } else {
                Node *y = nd->_parent->_parent->_left;
                if (y && y->isRed()) {
                    nd->_parent->setBlack();
                    y->setBlack();
                    nd->_parent->_parent->setRed();

                    if (_dumper)
                        _dumper->rbTreeEvent(IRBTreeDumper<Element, Compar>::DE_AFTER_RECOLOR3D, this, nd);
                    nd = nd->_parent->_parent;
                } else {
                    if (nd == nd->_parent->getLeft()) {
                        nd = nd->_parent;
                        rotRight(nd);
                    }
                    nd->_parent->setBlack();
                    nd->_parent->_parent->setRed();
                    rotLeft(nd->_parent->_parent);
                }
            }
            return nd;
        }

        return nullptr;
    }


    template<typename Element, typename Compar>
    void RBTree<Element, Compar>::rebalance(Node *nd) {
        while (nd != _root && nd->_parent->isRed())
            nd = rebalanceDUG(nd);
        _root->setBlack();
    }


    template<typename Element, typename Compar>
    void RBTree<Element, Compar>::rotLeft(typename RBTree<Element, Compar>::Node *nd) {

        // правый потомок, который станет после левого поворота "выше"
        Node *y = nd->_right;

        if (!y)
            throw std::invalid_argument("Can't rotate left since the right child is nil");


        y->_parent = nd->_parent;
        if (y->_parent == nullptr)
            _root = y;
        if (nd->_parent != nullptr) {
            if (nd->_parent->getLeft() == nd)
                nd->_parent->_left = y;
            else
                nd->_parent->_right = y;
        }

        nd->_right = y->_left;
        if (y->getLeft() != nullptr)
            y->_left->_parent = nd;

        nd->_parent = y;

        y->_left = nd;


        // отладочное событие
        if (_dumper)
            _dumper->rbTreeEvent(IRBTreeDumper<Element, Compar>::DE_AFTER_LROT, this, nd);
    }


    template<typename Element, typename Compar>
    void RBTree<Element, Compar>::rotRight(typename RBTree<Element, Compar>::Node *nd) {
        Node *y = nd->_left;

        if (!y)
            throw std::invalid_argument("Can't rotate right since the left child is nil");

        y->_parent = nd->_parent;
        if (y->_parent == nullptr)
            _root = y;
        if (nd->_parent != nullptr) {
            if (nd->_parent->getLeft() == nd)
                nd->_parent->_left = y;
            else
                nd->_parent->_right = y;
        }

        nd->_left = y->_right;
        if (y->getRight() != nullptr)
            y->_right->_parent = nd;

        nd->_parent = y;
        y->_right = nd;

        // отладочное событие
        if (_dumper)
            _dumper->rbTreeEvent(IRBTreeDumper<Element, Compar>::DE_AFTER_RROT, this, nd);
    }

    #ifdef RBTREE_WITH_DELETION

    template<typename Element, typename Compar>
    void RBTree<Element, Compar>::remove(const Element &key) {
        Node *x, *y;
        Node *nd = nfind(key);

        if (!nd)
            throw std::invalid_argument("");

        if (nd->getLeft() == nullptr || nd->getRight() == nullptr)
            y = nd;
        else {
            y = nd->_right;
            while (y->getLeft() != nullptr)
                y = y->_left;
        }

        if (y->getLeft() != nullptr)
            x = y->_left;
        else
            x = y->_right;

        if (x) {
            x->_parent = y->_parent;
            if (y->_parent)
                if (y == y->_parent->getLeft())
                    y->_parent->_left = x;
                else
                    y->_parent->_right = x;
            else
                _root = x;

            if (y != nd) nd->_key = y->_key;

            //if (y->isBlack())
                delrebalance(x);

        }
    }

    template<typename Element, typename Compar>
    typename RBTree<Element, Compar>::Node *
    RBTree<Element, Compar>::delrebalance(Node *nd) {
        while (nd != _root && nd->isBlack()) {
            if (nd == nd->_parent->getLeft()) {
                Node *w = nd->_parent->_right;
                if (w->isRed()) {
                    w->setBlack();
                    nd->_parent->setRed();
                    rotLeft(nd->_parent);
                    w = nd->_parent->_right;
                }
                if (w->_left->isBlack() && w->_right->isBlack()) {
                    w->setRed();
                    nd = nd->_parent;
                } else {
                    if (w->_right->isBlack()) {
                        w->_left->setBlack();
                        w->setRed();
                        rotRight(w);
                        w = nd->_parent->_right;
                    }
                    w->_color = nd->_parent->_color;
                    nd->_parent->setBlack();
                    w->_right->setBlack();
                    rotLeft(nd->_parent);
                    nd = _root;
                }
            } else {
                Node *w = nd->_parent->_left;
                if (w->isRed()) {
                    w->setBlack();
                    nd->_parent->setRed();
                    rotRight(nd->_parent);
                    w = nd->_parent->_left;
                }
                if (w->_right->isBlack() && w->_left->isBlack()) {
                    w->setRed();
                    nd = nd->_parent;
                } else {
                    if (w->_left->isBlack()) {
                        w->_right->setBlack();
                        w->setRed();
                        rotLeft(w);
                        w = nd->_parent->_left;
                    }
                    w->_color = nd->_parent->_color;
                    nd->_parent->setBlack();
                    w->_left->setBlack();
                    rotRight(nd->_parent);
                    nd = _root;
                }
            }
        }
        nd->setBlack();
    }
    #endif // RBTREE_WITH_DELETION

} // namespace xi

