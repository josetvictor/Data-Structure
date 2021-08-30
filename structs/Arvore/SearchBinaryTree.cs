using data_structs.Node;
using System;
using System.Collections;
using System.Collections.Generic;

namespace data_structs.Arvore
{
    class SearchBinaryTree
    {
        private NoBinary root;
        private int lenght = 0;
        private NoRubroNegra no;

        public SearchBinaryTree(NoBinary root)
        {
            this.root = root;
            lenght++;
        }

        public SearchBinaryTree(NoRubroNegra no)
        {
            this.no = no;
        }
        #region Metodos genericos
        public int size() => lenght;
        public int height(NoBinary node)
        {
            if (node == null || (node.Left() == null && node.Right() == null))
                return 0;
            else
            {
                if (height(node.Left()) > height(node.Right()))
                    return 1 + height(node.Left());
                else 
                    return 1 + height(node.Right());
            }
        }

        public bool isEmpty() => lenght == 0;
        #endregion

        #region Metodos de acesso
        public NoBinary getRoot() => root;
        public NoBinary parent(NoBinary node) => node.Parent();
        public NoBinary leftChild(NoBinary node) => node.Left();
        public NoBinary rightChild(NoBinary node) => node.Right();

        public bool hasLeft(NoBinary node) => node.Left() != null;
        public bool hasRight(NoBinary node) => node.Left() != null;
        #endregion

        #region Metodo de atualização
        public int replace(NoBinary node, int value)
        {
            node.setElement(value);
            return node.Element();
        }
        #endregion

        #region Metodos adicionais
        public NoBinary search(NoBinary tree, int value)
        {
            if (tree.Element() == value)
                return tree;
            if (value < tree.Element())
                return search(tree.Left(), value);

            return search(tree.Right(), value);
        }
        
        public void insert(NoBinary subTree, int value)
        {
            if(subTree != null)
            {
                if (value > subTree.Element())
                {
                    if (subTree.Right() == null)
                    {
                        subTree.setRight(new NoBinary(subTree, value));
                        lenght++;
                    }
                    else
                        insert(subTree.Right(), value);
                }
                else
                {
                    if (subTree.Left() == null)
                    {
                        subTree.setLeft(new NoBinary(subTree, value));
                        lenght++;
                    }
                    else insert(subTree.Left(), value);
                }
            }
        }

        public void remove(NoBinary node)
        {
            // Se não tiver filhos
            if (isExternal(node))
            {
                NoBinary dad = node.Parent();
                if (dad.Left() == node) dad.setLeft(null);
                else dad.setRight(null);
                cleaNode(node);
            }
            // se tiver um filho
            else if (isInternal(node))
            {
                NoBinary dad = node.Parent();
                if (dad.Left() == null)
                    dad.setRight(node.Right());
                else
                    dad.setLeft(node.Left());

                cleaNode(node);
            }
            // se tiver dois filhos
            else if (node.Left() != null && node.Right() != null)
            {
                NoBinary aux = minNode(node.Right());
                node.setElement(aux.Element());
                remove(aux);
            }
        }

        public NoBinary minNode(NoBinary node)
        {
            NoBinary current = node;

            while(current != null && current.Left() != null)
            {
                current = current.Left();
            }

            return current;
        }

        public void cleaNode(NoBinary node)
        {
            node.setParent(null);
            node.setLeft(null);
            node.setRight(null);
        }
        #endregion

        #region Metodos de consulta
        public bool isInternal(NoBinary node) => node.Left() == null || node.Right() == null;

        public bool isExternal(NoBinary node) => node.Left() == null && node.Right() == null;
        public bool isRoot(NoBinary node) => node == root;

        public int depth(NoBinary node)
        {
            if (node == null || node == root)
                return 0;
            else
                return (1 + depth(node.Parent()));
        }

        public void showTree(NoBinary tree)
        {
            int rows = height(tree);
            int columns = lenght;

            NoBinary[,] matrizTree = new NoBinary[rows + 1, columns];
            ArrayList nodes = new ArrayList();

            nodes = tree.nodeElements(nodes, tree);

            nodes.ToArray();
            for(int i = 0; i < columns; i++)
            {
                NoBinary no = null;
                if (i < nodes.ToArray().Length)
                    no = (NoBinary)nodes[i]; ;
                matrizTree[depth(no), i] = no;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    NoBinary node = matrizTree[i, j];

                    if (node == null)
                        Console.Write(" ");
                    else
                        Console.Write(node.Element() + "h[" + node.BalanceFactor() + "]");

                    Console.Write("   ");
                }
                Console.WriteLine("");
            }
        }
        #endregion
    }
}