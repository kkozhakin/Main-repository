///////////////////////////////////////////////////////////////////////////////
/// \file
/// \brief Contains pseudo-implementation part of bidirectional list structure 
/// template declared in the file's h-counterpart
///
/// © Sergey Shershakov 2015–2017.
///
/// This code is for educational purposes of the course "Algorithms and Data 
/// Structures" provided by the School of Software Engineering of the Faculty 
/// of Computer Science at the Higher School of Economics.
///
/// When altering code, a copyright line must be preserved.
///////////////////////////////////////////////////////////////////////////////

#include <stdexcept>



//==============================================================================
// class BidiList<T>::Node
//==============================================================================

/** \brief Inserts a given new (free) node \a insNode after node \a node
    *  \param node a node after which \a insNode is inserted
    *  \param insNode inserted node
    *  \return inserted node
    *
    *  if \a node is nullptr, inserts \a insNode at the very end
    *  If \a insNode is nullptr, an expection is raised.
    *  If \a insNode has a previous or next sibling, an exception is thrown
    *  */
template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::Node::insertAfterInternal(Node* insNode)
{
   // here we use "this" keyword for enhancing the fact we deal with curent node!
   Node* afterNode = this->_next;      // an element, which was after node

   if (!insNode)
       throw std::invalid_argument("");

    if (!afterNode)
    {
        insNode->_next = nullptr;
        insNode->_prev = this;
        this->_next = insNode;
        return insNode;

    }else
        {
        insNode->_next = afterNode;
        insNode->_prev = this;
        this->_next = insNode;
        afterNode->_prev = insNode;
    }



   return insNode;
}

//==============================================================================
// class BidiList<T>
//==============================================================================



template <typename T>
BidiLinkedList<T>::~BidiLinkedList()
{
   clear();
}


template <typename T>
void BidiLinkedList<T>::clear()
{
   while(_head)
   {
       _tail = _head->_next;
       delete _head;
       _head = _tail;
   }
}

template <typename T>
size_t BidiLinkedList<T>::getSize()
{
   if (_size == NO_SIZE)
       calculateSize();

   return _size;
}


template <typename T>
void BidiLinkedList<T>::calculateSize()
{
   Node* del = _head;
   if (!del)
       _size = 0;
   else
   {
       _size = 1;
       while (del->_next != nullptr) {
           del = del->_next;
           ++_size;
       }
   }
}


template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::getLastNode() const { return _tail; }


template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::appendEl(const T& val)
{
   Node* newNode = new Node(val);

   // !...
   // Здесь вырезана часть кода. Ее необходимо реализовать
   // !...

   // inserts after last node, size if going to e invalidated there
   return insertNodeAfter(getLastNode(), newNode);
}


// возможно, этот метод даже не надо изменять
template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::insertNodeAfter(Node* node, Node* insNode)
{
   if (!insNode)
       throw std::invalid_argument("`insNode` is nullptr");

   // check if a node is alone
   if (insNode->_next || insNode->_prev)
       throw std::invalid_argument("`insNode` has siblings. It seems it isn't free");


   if (!node)
       node = getLastNode();

   // if last node is nullptr itself, it means that no elements in the list at all
   if (!node)
   {
       _head = insNode;
       _tail = insNode;
   }
   else
   {
       node->insertAfterInternal(insNode);
       // If there is no one on the right from the inserted, update _tail.
       if (!insNode->_next)
           _tail = insNode;
   }


   invalidateSize();

   return insNode;
}



// Следующий фрагмент кода перестанет быть "блеклым" и станет "ярким", как только вы определите
// макрос IWANNAGET10POINTS, взяв тем самым на себя повышенные обязательства
#ifdef IWANNAGET10POINTS


template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::insertNodeBefore(Node* node, Node* insNode)
{
    if (!insNode)
        throw std::invalid_argument("`nodes` is nullptr");

    if (insNode->_next || insNode->_prev)
        throw std::invalid_argument("`nodes` has siblings. It seems it isn't free");


    if (!node)
        node = getHeadNode();

    if (!node)
    {
        _head = insNode;
        _tail = insNode;
    }
    else
    {
        insNode->_prev = node->_prev;
        insNode->_next = node;
        if (node->_prev)
            node->_prev->_next = insNode;
        node->_prev = insNode;
    }
    if (!insNode->_prev)
        _head = insNode;

    invalidateSize();

    return insNode;
}


template <typename T>
void BidiLinkedList<T>::insertNodesBefore(Node* node, Node* beg, Node* end)
{
    if (!beg || !end)
        throw std::invalid_argument("`nodes` is nullptr");

    if (end->_next || beg->_prev)
        throw std::invalid_argument("`nodes` has siblings. It seems it isn't free");


    if (!node)
        node = getHeadNode();

    if (!node)
    {
        _head = beg;
        _tail = end;
    }
    else
    {
        beg->_prev = node->_prev;
        end->_next = node;
        if (node->_prev)
            node->_prev->_next = beg;
        node->_prev = end;
    }
    if (!beg->_prev)
        _head = beg;

    invalidateSize();
}

#endif // IWANNAGET10POINTS


template <typename T>
void BidiLinkedList<T>::cutNodes(Node* beg, Node* end)
{
   if (!beg || !end)
       throw std::invalid_argument("Either `beg` or `end` is nullptr");

    if (end->_next)
        end->_next->_prev = beg->_prev;
    else
        _tail = beg->_prev;
    if (beg->_prev)
        beg->_prev->_next = end->_next;
    else
        _head = end->_next;
   beg->_prev = nullptr;
   end->_next = nullptr;

   invalidateSize();

}


template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::cutNode(Node* node)
{
   if (!node)
       throw std::invalid_argument("Either `node' is nullptr");

   if (node->_next)
       node->_next->_prev = node->_prev;
   else
       _tail = node->_prev;
   if (node->_prev)
       node->_prev->_next = node->_next;
   else
       _head = node->_next;
   node->_next = nullptr;
   node->_prev = nullptr;

   invalidateSize();

   return node;
}


template <typename T>
typename BidiLinkedList<T>::Node*
   BidiLinkedList<T>::findFirst(Node* startFrom, const T& val)
{
   if (!startFrom)
       return nullptr;

   Node* del = startFrom;
   while (del != nullptr)
   {
       if (del->_val == val)
           return del;
       del = del->_next;
   }

   return nullptr;     // not found
}

template <typename T>
typename BidiLinkedList<T>::Node**
   BidiLinkedList<T>::findAll(Node* startFrom, const T& val, int& size) {
   if (!startFrom)
       return nullptr;

   // try not to use any standard containers. create an array only when found a first occurence
   Node **res = nullptr;
   size = 0;


    Node* del = startFrom;
    while (del != nullptr)
    {
        if (del->_val == val)
            ++size;
        del = del->_next;
    }

   // recreates array if created
   if (size > 0)
   {
       res = new Node*[size + 1];
       del = startFrom;
       size = 0;
       while (del != nullptr)
       {
           if (del->_val == val)
           {
               res[size] = del;
               ++size;
           }
           del = del->_next;
       }
       res[size] = new Node();
       res[size]->_next = res[size];
       res[size]->_prev = res[size];
   }

   return res;
}

template<typename T>
void
BidiLinkedList<T>::insertNodesAfter(BidiLinkedList::Node *node, BidiLinkedList::Node *beg, BidiLinkedList::Node *end)
{
   if (!beg || !end)
       throw std::invalid_argument("`nodes` is nullptr");

   if (end->_next || beg->_prev)
       throw std::invalid_argument("`nodes` has siblings. It seems it isn't free");


   if (!node)
       node = getLastNode();

   if (!node)
   {
       _head = beg;
       _tail = end;
   }
   else
   {
       beg->_prev = node;
       end->_next = node->_next;
       if (node->_next)
            node->_next->_prev = end;
       node->_next = beg;
   }
   if (!end->_next)
       _tail = end;

    invalidateSize();
   }


// Следующий фрагмент кода перестанет быть "блеклым" и станет "ярким", как только вы определите
// макрос IWANNAGET10POINTS, взяв тем самым на себя повышенные обязательства
#ifdef IWANNAGET10POINTS

template <typename T>
typename BidiLinkedList<T>::Node**
BidiLinkedList<T>::cutAll(Node* startFrom, const T& val, int& size)
{
   Node** res = findAll(startFrom, val, size);
   if (res)
   {
       int i = 0;
       while(res[i]->_next != res[i])
       {
           cutNode(res[i]);
           ++i;
       }
       cutNode(res[i]);
       return res;
   }
   return nullptr;
}

#endif // IWANNAGET10POINTS
