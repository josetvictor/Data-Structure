namespace data_structs
{
    class PilhaDoubleFila
    {
        FilaArray filaOne, filaTwo;
        public PilhaDoubleFila(int length)
        {
            filaOne = new FilaArray(length);
            filaTwo = new FilaArray(length);
        }

        public void push(object element)
        {
            filaOne.enqueue(element);
        }

        public object pop()
        {
            if (filaOne.isEmpty()) { throw new EPilhaVazia("Pilha está vazia!"); }

            while(filaOne.size() > 1)
            {
                filaTwo.enqueue(filaOne.denqueue());
            }

            object popped = filaOne.denqueue();

            FilaArray aux = filaOne;
            filaOne = filaTwo;
            filaTwo = aux;

            return popped;
        }
    }
}
