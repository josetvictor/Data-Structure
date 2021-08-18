using data_structs.Node;
using System;

namespace data_structs.Arvore
{
    class SearchBinaryTree
    {
        NoBinary root;
        int lenght;
        public SearchBinaryTree(NoBinary root)
        {
            this.root = root;
            lenght = 1;
        }
        #region Metodos genericos
        public int size() => lenght;
        public int height(NoBinary node)
        {
            if (isExternal(node))
                return 0;
            else
            {
                int altura = 0;
                while (node.getChildLeft() != null || node.getChildRight() != null)
                {
                    altura = Math.Max(altura, height(root));
                }
                return altura + 1;
            }
        }
        public bool isEmpty() => lenght == 0;
        #endregion

        #region Metodos de acesso
        public NoBinary getRoot() => root;
        public NoBinary parent(NoBinary node) => node.getParent();
        public NoBinary leftChild(NoBinary node) => node.getChildLeft();
        public NoBinary rightChild(NoBinary node) => node.getChildRight();
        public bool hasLeft(NoBinary node) => node.getChildLeft() != null;

        public bool hasRight(NoBinary node) => node.getChildLeft() != null;
        #endregion

        #region Metodo de atualização
        public int replace(NoBinary node, int objeto)
        {
            node.setElement(objeto);
            return node.getElement();
        }
        #endregion

        #region Metodos adicionais
        public NoBinary search(NoBinary tree, int value)
        {
            if (tree.getElement() == value)
                return tree;
            if (value < tree.getElement())
                return search(tree.getChildLeft(), value);

            return search(tree.getChildRight(), value);
        }

        
        public void insert(NoBinary subTree, int value)
        {
            if(subTree != null)
            {
                if (value > subTree.getElement())
                {
                    if (subTree.getChildRight() == null)
                        subTree.setChildRight(new NoBinary(subTree, value));
                    else insert(subTree.getChildRight(), value);
                }
                else
                {
                    if (subTree.getChildLeft() == null)
                        subTree.setChildLeft(new NoBinary(subTree, value));
                    else insert(subTree.getChildLeft(), value);
                }
            }
        }

        public void remove(NoBinary node, int value)
        {
            //NoBinary deletedNode = search(root, value);
            // Se não tiver filhos
            if (isExternal(node))
            {
                NoBinary dad = node.getParent();
                if (dad.getChildLeft() == node) dad.setChildLeft(null);
                else dad.setChildRight(null);
                cleaNode(node);
            }
            // se tiver um filho
            else if (node.getChildLeft() == null || node.getChildRight() == null)
            {
                NoBinary dad = node.getParent();

                if (dad.getChildLeft() == null)
                    dad.setChildRight(node.getChildRight());
                else
                    dad.setChildLeft(node.getChildLeft());

                cleaNode(node);

            }
            // se tiver dois filhos
            else if (node.getChildLeft() != null && node.getChildRight() != null)
            {
                NoBinary aux = node.getChildRight().minNode();
                node.setElement(aux.getElement());
                remove(node.getChildRight(), node.getElement());
            }
        }

        public void cleaNode(NoBinary node)
        {
            node.setParent(null);
            node.setChildLeft(null);
            node.setChildRight(null);
        }
        #endregion

        #region Metodos de consulta
        public bool isInternal(NoBinary node) => node.getChildLeft() == null ||
        node.getChildRight() == null;

        public bool isExternal(NoBinary node) => node.getChildLeft() == null &&
        node.getChildRight() == null;
        public bool isRoot(NoBinary node) => node == root;
        public int depth(NoBinary node)
        {
            if (node == root)
            {
                return 0;
            }
            else
            {
                return (1 + depth(node.getParent()));
            }
        }

        public void showTree(NoBinary tree)
        {
            if(tree != null)
            {
                showTree(tree.getChildLeft());

                if(tree == root)
                {
                    Console.WriteLine(tree.getElement() + " ");
                } else
                {
                    Console.WriteLine("---" + tree.getElement() + " ");
                }


                showTree(tree.getChildRight());
            }
            
        }
        #endregion
    }
}