using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class Deque
    {
        private DuploNo first;
        private DuploNo last;
        private int length = 0;

        public Deque() { }

        public object header() { return this.first.getElemente(); /* Cabeça */ }
        public object tail() { return this.last.getElemente(); /* Rabo */ }
        public int lengthM() { return this.length; /* Tamanho */  }
        public bool isEmpty() { return this.length == 0; /* Teste de Solidão */ }

        public void insertHeader(DuploNo node)
        {
            if (isEmpty())
            {
                this.first = node;
                this.last = node;
                this.length++;
            }else
            {
                this.first.setPrevious(node);
                node.setNext(first);
                this.first = node;
                this.length++;
            }
        }

        public object removeHeader()
        {
            if (isEmpty()) throw new EDequeVazio("Deque vazio!");
            object currentFirst = first;
            first = first.getPrevious();
            length--;
            return currentFirst;
        }

        public void insertTail(DuploNo node)
        {
            if (isEmpty())
            {
                first = node;
                last = node;
                length++;
            }
            else
            {
                last.setNext(node);
                node.setPrevious(last);
                last = node;
                length++;
            }
        }

        public object removeTail()
        {
            if (isEmpty()) throw new EDequeVazio("Deque vazio!");
            object currentLast = last;
            last = last.getNext();
            length--;
            return currentLast;
        }
    }
}
