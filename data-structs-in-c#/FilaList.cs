using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class FilaList
    {
        private No first;
        private No last;
        private int length = 0;

        public FilaList() { }

        public int size() { return length; }

        public bool isEmpty() { return length == 0; }

        public object peek()
        {
            if (isEmpty()) throw new EFilaVazia("A fila está vazia!");
            return this.first.getElement();
        }

        public void enqueue(object element)
        {
            if(size() == 0)
            {
                first = last = new No(element);
                length++;
            }
            else
            {
                last.setNext(new No(element));
                last = last.getNext();
                length++;
            }
        }
        public object denqueue()
        {
            if (isEmpty()) throw new EFilaVazia("A fila está vazia!");
            object newFirst = first.getElement();
            first = first.getNext();
            return newFirst;
        }
    }
}
