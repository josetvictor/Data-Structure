namespace data_structs
{
    class No
    {
        private object element;
        private No next;

        public No(object element)
        {
            this.element = element;
        }

        public object getElement() { return this.element; }
        public void setElement(object element) { this.element = element; }

        public No getNext() { return this.next; }
        public void setNext(No node) { this.next = node; }
    }
}
