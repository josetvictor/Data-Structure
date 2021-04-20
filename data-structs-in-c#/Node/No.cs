using System;
using System.Collections;

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

    public class NoTree {
        
        private object value;
        
        private NoTree dad;
        
        private ArrayList childrens = new ArrayList();
        
        public NoTree(NoTree dad, object value) {
            this.dad = dad;
            this.value = value;
        }
        
        public object element() {
            return value;
        }
        
        public NoTree parent() {
            return dad;
        }
        
        public void setElement(object value) {
            this.value = value;
        }
        
        public void addChild(NoTree value) {
          
          childrens.Add(value);
        }
        
        public void removeChild(NoTree element) {
            childrens.Remove(element);
        }
        
        public int childrenNumber() {
            return childrens.Count;
        }
        
        public IEnumerator children() {
            return childrens.GetEnumerator();
        }
    }
}
