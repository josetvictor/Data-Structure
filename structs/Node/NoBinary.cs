using System.Collections.Generic;
using System.Collections;
using System;

namespace data_structs.Node
{
    public class NoBinary
    {
        private int element;
        public int fb;
        private NoBinary dad;
        private NoBinary left;
        private NoBinary right;

        public NoBinary(int element)
        {
            this.dad = null;
            this.element = element;
            left = null;
            right = null;
        }

        public NoBinary(NoBinary dad, int element)
        {
            this.dad = dad;
            this.element = element;
            left = null;
            right = null;
        }

        public int getElement() => element;

        public void setElement(int element) => this.element = element;

        public NoBinary getParent() => dad;

        public void setParent(NoBinary node) => dad = node;

        public NoBinary getChildLeft() => left;

        public void setChildLeft(NoBinary node) => left = node;

        public void removeChildLeft() => left = null;

        public NoBinary getChildRight() => right;

        public void setChildRight(NoBinary node) => right = node;

        public void removeChildRight() => right = null;

        public int childrenNumber()
        {
            int children = 0;
            if (left != null) children++;
            if (right != null) children++;

            return children;
        }

        public IEnumerable children()
        {
            List<NoBinary> list = new List<NoBinary>();

            if (left != null) list.Add(left);
            if (right!= null) list.Add(right);

            yield return list.ToArray().GetEnumerator();
        }

        public NoBinary minNode()
        {
            NoBinary current = this;
            while (current != null && current.getChildLeft() != null)
            {
                current = current.getChildLeft();
            }

            return current;
        }
    }
}
