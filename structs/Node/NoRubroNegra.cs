using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Node
{
    class NoRubroNegra
    {
        private int element;
        private string cor;
        private int alturaNegra;
        private NoRubroNegra dad;
        private NoRubroNegra left;
        private NoRubroNegra right;

        public NoRubroNegra(int element)
        {
            dad = null;
            this.element = element;
            cor = "N";
            left = null;
            right = null;
        }

        public NoRubroNegra(NoRubroNegra dad, int element)
        {
            this.dad = dad;
            this.element = element;
            cor = "R";
            left = null;
            right = null;
        }

        public string Cor() => cor;

        public void setCor(string cor) => this.cor = cor;

        public int AlturaNegra() => alturaNegra;

        public void setAlturaNegra(int alturaNegra) => this.alturaNegra = alturaNegra;

        public int Element() => element;

        public void setElement(int element) => this.element = element;

        public NoRubroNegra Parent() => dad;

        public void setParent(NoRubroNegra node) => dad = node;

        public NoRubroNegra Left() => left;

        public void setLeft(NoRubroNegra node) => left = node;

        public void removeLeft() => left = null;

        public NoRubroNegra Right() => right;

        public void setRight(NoRubroNegra node) => right = node;

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
            List<NoRubroNegra> list = new List<NoRubroNegra>();

            if (left != null) list.Add(left);
            if (right != null) list.Add(right);

            yield return list.ToArray().GetEnumerator();
        }

        public ArrayList nodeElements(ArrayList nodes, NoRubroNegra no)
        {
            NoRubroNegra leftSon = no.left;
            NoRubroNegra rightSon = no.right;

            if (no != null)
            {
                if (leftSon != null)
                    nodeElements(nodes, leftSon);

                nodes.Add(no);

                if (rightSon != null)
                    nodeElements(nodes, rightSon);
            }

            return nodes;
        }
    }
}
