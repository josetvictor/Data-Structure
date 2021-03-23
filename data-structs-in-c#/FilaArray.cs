using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class FilaArray
    {
        int lenght, start, end, cont;
        object[] array;
        public FilaArray(int lenght)
        {
            array = new object[lenght];
            this.lenght = lenght;
            start = end = -1;
        }

        public object top() {
            if (isEmpty()) throw new EFilaVazia("Fila vazia!");    
            return array[start]; 
        }
        public int size() { return cont; }
        public bool isEmpty() { return cont == 0; }
        public void enqueue(object element)
        {
            if (size() == lenght)
            {
                object[] newArray = new object[lenght*2];
                int startOldArray = start;
                for (int j = 0, limit = size(); j < limit; j++)
                {
                    newArray[j] = array[startOldArray];
                    startOldArray = (startOldArray + start + 1) % lenght;
                }
            }
            if (size() == 0) start++;
            end = (end + 1) % lenght;
            array[end] = element;
            cont++;
        }
        public object denqueue()
        {
            if (isEmpty()) throw new EFilaVazia("Fila vazia");
            object denqueueElement = array[start];
            start = (start + 1) % lenght;
            cont--;
            return denqueueElement;
        }
    }
}
