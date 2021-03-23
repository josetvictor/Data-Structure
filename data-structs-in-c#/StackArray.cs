using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class StackArray
    {
        private int tStack = -1, arrayLength, increment = 0;
        private object[] array;
        public StackArray(int length, int increment)
        {
            array = new object[length];
            arrayLength = length;
            this.increment = increment;
        }
        public StackArray(int length)
        {
            array = new object[length];
            arrayLength = length;
        }
        public int size()
        {
            return tStack + 1;
        }
        public object pop()
        {
            if (isEmpty()) throw new EPilhaVazia("A pilha está vazia");
            tStack = - 1;
            return array[tStack + 1];
        }
        public void push(object element)
        {
            object[] Atemp;
            if (size() == arrayLength)
            {
                if (increment > 0)
                {
                    arrayLength += increment;
                }else
                {
                    arrayLength *= 2;
                }

                Atemp = new object[arrayLength];

                for (int i = 0; i < tStack; i++)
                {
                    Atemp[i] = array[i];
                }
                array = Atemp;
            }
            array[++tStack] = element;
        }
        public object top()
        {
            if (isEmpty()) throw new EPilhaVazia("A pilha está vazia");
            return array[tStack];
        }
        public void empty()
        {
            tStack = 0;
            object[] arrayEmpty = new object[array.Length];

            array = arrayEmpty;
        }
        public bool isEmpty()
        {
            return tStack == -1;
        }
    }
}
