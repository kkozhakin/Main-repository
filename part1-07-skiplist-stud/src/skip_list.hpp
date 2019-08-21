////////////////////////////////////////////////////////////////////////////////
// Module Name:  skip_list.h/hpp
// Authors:      Leonid Dworzanski, Sergey Shershakov
// Version:      2.0.0
// Date:         28.10.2018
//
// This is a part of the course "Algorithms and Data Structures"
// provided by  the School of Software Engineering of the Faculty
// of Computer Science at the Higher School of Economics.
////////////////////////////////////////////////////////////////////////////////

// !!! DO NOT include skip_list.h here, 'cause it leads to circular refs. !!!

#include <cstdlib>

//==============================================================================
// class NodeSkipList
//==============================================================================

template <class Value, class Key, int numLevels>
void NodeSkipList<Value, Key, numLevels>::clear(void)
{
    for (int i = 0; i < numLevels; ++i)
        Base::nextJump[i] = 0;

    Base::levelHighest = -1;
}

//------------------------------------------------------------------------------

template <class Value, class Key, int numLevels>
NodeSkipList<Value, Key, numLevels>::NodeSkipList(void)
{
    clear();
}

//------------------------------------------------------------------------------

template <class Value, class Key, int numLevels>
NodeSkipList<Value, Key, numLevels>::NodeSkipList(const Key& tkey)
{
    clear();

    Base::Base::key = tkey;
}

//------------------------------------------------------------------------------

template <class Value, class Key, int numLevels>
NodeSkipList<Value, Key, numLevels>::NodeSkipList(const Key& tkey, const Value& val)
{
    clear();

    Base::Base::key = tkey;
    Base::Base::value = val;
}


//==============================================================================
// class SkipList
//==============================================================================

template <class Value, class Key, int numLevels>
SkipList<Value, Key, numLevels>::SkipList(double probability)
{
    _probability = probability;

    // Lets use m_pPreHead as a final sentinel element
    for (int i = 0; i < numLevels; ++i)
        Base::_preHead->nextJump[i] = Base::_preHead;

    Base::_preHead->levelHighest = numLevels - 1;
}

template <class Value, class Key, int numLevels>
void SkipList<Value, Key, numLevels>::removeNext(SkipList::Node* nodeBefore) {
    if (!nodeBefore || nodeBefore->next == this->_preHead)
        throw std::invalid_argument("");

    Node *update[numLevels];
    Node *currNode = this->_preHead;
    for (int i = nodeBefore->next->levelHighest; i >= -1; --i) {
        if (i == -1)
            while (currNode->next != this->_preHead && currNode != nodeBefore)
                currNode = currNode->next;
        else
            while (currNode->nextJump[i] != this->_preHead && currNode != nodeBefore)
                currNode = currNode->nextJump[i];
        update[i] = currNode;
    }

    currNode = nodeBefore->next;

    for (int lv = 0; lv <= currNode->levelHighest; lv++)
    {
        if (update[lv]->nextJump[lv] != currNode)
            break;
        update[lv]->nextJump[lv] = currNode->nextJump[lv];
    }
    nodeBefore->next = currNode->next;
    delete currNode;
}

template <class Value, class Key, int numLevels>
void SkipList<Value, Key, numLevels>::insert(const Value &val, const Key &key) {
    Node *update[numLevels];
    Node *currNode = this->_preHead;
        for (int i = currNode->levelHighest; i >= -1; --i)
        {
            if (i == -1)
                while (currNode->next != this->_preHead && currNode->next->key <= key)
                    currNode = currNode->next;
            else
                while (currNode->nextJump[i] != this->_preHead && currNode->nextJump[i]->key <= key)
                    currNode = currNode->nextJump[i];
            update[i] = currNode;
        }
    Node *node = new Node();
    node->key = key;
    node->value = val;
    node->next = currNode->next;
    currNode->next = node;
    node->levelHighest = randomLevel();
    for (int i = node->levelHighest + 1; i <= numLevels; i++)
        update[i] = nullptr;
    for (int lv = 0; lv <= node->levelHighest; lv++)
    {
        node->nextJump[lv] = update[lv]->nextJump[lv];
        update[lv]->nextJump[lv] = node;
    }
}

template <class Value, class Key, int numLevels>
typename SkipList<Value, Key, numLevels>::Node* SkipList<Value, Key, numLevels>::findLastLessThan(const Key &key) const
{
    Node* currNode = this->_preHead;
    for (int i = currNode->levelHighest; i >= -1 ; --i)
    {
        if (i == -1)
            while (currNode->next != this->_preHead && currNode->next->key < key)
                currNode = currNode->next;
        else
            while (currNode->nextJump[i] != this->_preHead && currNode->nextJump[i]->key < key)
                    currNode = currNode->nextJump[i];
    }
    if (currNode->next->key == key)
        return currNode;
    else
        return this->_preHead;
}

template <class Value, class Key, int numLevels>
typename SkipList<Value, Key, numLevels>::Node* SkipList<Value, Key, numLevels>::findFirst(const Key &key) const
{
    Node* currNode = this->_preHead;
        for (int i = currNode->levelHighest; i >= -1; --i)
        {
            if (i == -1)
                while (currNode->next != this->_preHead && currNode->next->key < key)
                    currNode = currNode->next;
            else
                while (currNode->nextJump[i] != this->_preHead && currNode->nextJump[i]->key < key)
                        currNode = currNode->nextJump[i];
        }
        currNode = currNode->next;
    if (currNode->key == key)
        return currNode;
    else
        return nullptr;
}

template<class Value, class Key, int numLevels>
SkipList<Value, Key, numLevels>::~SkipList()
{

}
