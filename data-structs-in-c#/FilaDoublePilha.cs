namespace data_structs
{
    class FilaDoublePilha
    {
        private int arrayLength;
        private StackArray stackOne, stackTwo;

        public FilaDoublePilha(int length)
        {
            stackOne = new StackArray(length);
            stackTwo = new StackArray(length);
            arrayLength = length;
        }
        public void enqueue(object element)
        { 
            stackOne.push(element);
        }
        public object denqueue()
        {
            if (stackOne.isEmpty()) throw new EFilaVazia("Fila vazia");

            while(stackOne.size() > 1)
            {
                stackTwo.push(stackOne.pop());
            }

            object denqueued = stackOne.pop();

            StackArray aux = stackOne;
            stackOne = stackTwo;
            stackTwo = aux;

            return denqueued;
        }
    }
}
