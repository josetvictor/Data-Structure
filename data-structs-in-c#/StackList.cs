using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class StackList
    {
        private No tStack;
        private int length = 0;

        public StackList() { }

        public int size() { return length; }

        public bool isEmpty() { return length == 0; }

        public object top()
        {
            if (isEmpty()) throw new EPilhaVazia("A pilha está vazia");
            return tStack.getElement();
        }

        public void push(object element)
        {
            No newTop = new No(element);
            newTop.setNext(tStack);
            tStack = newTop;
            length++;
        }

        public object pop()
        {
            if (isEmpty()) throw new EPilhaVazia("A pilha está vazia");
            object currentTop = tStack.getElement();
            tStack = this.tStack.getNext();
            return currentTop;
        }
    }
}
