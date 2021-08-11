using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Arvore
{
    class SearchBinaryTree
    {
        NoBinaryTree raiz;
        int lenght;
        public SearchBinaryTree(NoBinaryTree raiz)
        {
            this.raiz = raiz;
            lenght = 1;
        }
        #region Metodos genericos
        public int size() => lenght;
        public int height(NoBinaryTree node)
        {
            if (isExternal(node))
                return 0;
            else
            {
                int altura = 0;
                while (node.getSonLeft() != null || node.getSonRight() != null)
                {
                    altura = Math.Max(altura, height(raiz));
                }
                return altura + 1;
            }
        }
        public bool isEmpty() => lenght == 0;
        #endregion
        #region Metodos de acesso
        public NoBinaryTree root() => raiz;
        public NoBinaryTree parent(NoBinaryTree node) => node.getParent();
        public NoBinaryTree leftChild(NoBinaryTree node) => node.getSonLeft();
        public NoBinaryTree rightChild(NoBinaryTree node) => node.getSonRight();
        public bool hasLeft(NoBinaryTree node) => node.getSonLeft() != null;

        public bool hasRight(NoBinaryTree node) => node.getSonLeft() != null;
        #endregion
        #region Metodo de atualização
        public object replace(NoBinaryTree node, object objeto)
        {
            node.setElement(objeto);
            return node.element();
        }
        #endregion
        #region Metodos adicionais
        public NoBinaryTree search(object value)
        {
            if (raiz == null) return null;
            NoBinaryTree node = raiz;
            while ((long)node.element() != (long)value)
            {
                if ((long)value < (long)node.element()) node = node.getSonLeft();
                else node = node.getSonRight();
                if (node == null) return null;
            }
            return node;
        }
        public void insert(object objeto)
        {
            NoBinaryTree new_ = new NoBinaryTree();
            new_.setElement(objeto);
            new_.setSonLeft(null);
            new_.setSonRight(null);
            if (raiz == null)
                raiz = new_;
            else
            {
                NoBinaryTree node = raiz;
                NoBinaryTree nodeBefore;
                while (true)
                {
                    nodeBefore = node;
                    new_.setParent(nodeBefore);

                    if ((long)objeto < (long)node.element())
                    {
                        node = node.getSonLeft();
                        if (node == null)
                        {
                            nodeBefore.setSonLeft(new_);
                            lenght++;
                            return;
                        }
                    }
                    else
                    {
                        node = node.getSonRight();
                        if (node == null)
                        {
                            nodeBefore.setSonRight(new_);
                            lenght++;
                            return;
                        }
                    }
                }
            }
        }
        public bool remove(object value)
        {
            bool flag = false;
            if (raiz == null) return flag;
            NoBinaryTree deletedNode = search(value);
            // Se não tiver filhos
            if (isExternal(deletedNode))
            {
                NoBinaryTree dad = deletedNode.getParent();
                if (dad.getSonLeft() == deletedNode) dad.setSonLeft(null);
                else dad.setSonRight(null);
                cleaNode(deletedNode);
                flag = true;
            }
            // se tiver um filho
            else if (deletedNode.getSonLeft() == null || deletedNode.getSonRight() == null)
            {
                NoBinaryTree dad = deletedNode.getParent();
                if (dad.getSonLeft() == deletedNode)
                {
                    if (deletedNode.getSonLeft() != null) dad.setSonLeft(deletedNode.getSonLeft());
                    else dad.setSonLeft(deletedNode.getSonRight());

                    cleaNode(deletedNode);
                    flag = true;
                }
                else
                {
                    if (deletedNode.getSonRight() != null)
                        dad.setSonRight(deletedNode.getSonLeft());

                    else dad.setSonRight(deletedNode.getSonRight());
                    cleaNode(deletedNode);
                    flag = true;
                }
            }
            // se tiver dois filhos
            else if (deletedNode.getSonLeft() != null && deletedNode.getSonRight() != null)
            {
                NoBinaryTree pai = deletedNode.getParent();
                NoBinaryTree irmao = deletedNode.getSonLeft();
                NoBinaryTree maiorFilho = deletedNode.getSonRight();
                NoBinaryTree filhofilho = maiorFilho.getSonLeft();
                if (pai.getSonLeft() == deletedNode)
                {
                    pai.setSonLeft(filhofilho);
                    filhofilho.setSonLeft(irmao);
                    filhofilho.setSonRight(maiorFilho);
                    cleaNode(deletedNode);
                    maiorFilho.setParent(filhofilho);
                    maiorFilho.setSonLeft(null);
                    flag = true;
                }
            }
            return flag;
        }
        public void cleaNode(NoBinaryTree node)
        {
            node.setParent(null);
            node.setSonLeft(null);
            node.setSonRight(null);
        }
        #endregion
        #region Metodos de consulta
        public bool isInternal(NoBinaryTree node) => node.getSonLeft() == null ||
        node.getSonRight() == null;

        public bool isExternal(NoBinaryTree node) => node.getSonLeft() == null &&
        node.getSonRight() == null;
        public bool isRoot(NoBinaryTree node) => node == raiz;
        public int depth(NoBinaryTree node)
        {
            if (node == raiz)
            {
                return 0;
            }
            else
            {
                return (1 + depth(node.getParent()));
            }
        }
        #endregion
    }
}
