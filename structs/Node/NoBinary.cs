using System.Collections.Generic;
using System.Collections;
using System;

namespace data_structs.Node
{
    public class NoBinary
    {
        int element;
        private int balanceFactor;
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

        public int BalanceFactor() => balanceFactor;
        public int setBalanceFactor(int fb) => balanceFactor = fb;

        public int Element() => element;

        public void setElement(int element) => this.element = element;

        public NoBinary Parent() => dad;

        public void setParent(NoBinary node) => dad = node;

        public NoBinary Left() => left;

        public void setLeft(NoBinary node) => left = node;

        public void removeLeft() => left = null;

        public NoBinary Right() => right;

        public void setRight(NoBinary node) => right = node;

        public void removeRight() => right = null;

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

        public List<NoBinary> nodeElements(List<NoBinary> nodes, NoBinary no)
        {
            NoBinary leftSon = no.left;
            NoBinary rightSon = no.right;

            if(no != null)
            {
                if(leftSon != null)
                    nodeElements(nodes, leftSon);

                nodes.Add(no);

                if(rightSon != null)
                    nodeElements(nodes, rightSon);
            }

            return nodes;
        }
    }
}
