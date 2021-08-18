
namespace data_structs
{
    class DuploNo
    {
        private DuploNo previous, next;
        private object element;

        public DuploNo(object element)
        {
            previous = next = null;
            this.element = element;
        }

        public DuploNo getPrevious() { return this.previous; }
        public void setPrevious(DuploNo node) { previous = node; }

        public object getElemente() { return this.element; }
        public void setElement(object element) { this.element = element; }

        public DuploNo getNext() { return next; }
        public void setNext(DuploNo node) { next = node; }
    }
}
