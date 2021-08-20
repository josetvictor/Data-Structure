using data_structs.Node;
using System;
using System.Collections.Generic;

namespace data_structs.Arvore
{
    class SearchBinaryTree
    {
        NoBinary root;
        int lenght = 0;
        public SearchBinaryTree(NoBinary root)
        {
            this.root = root;
            lenght = lenght + 1;
        }
        #region Metodos genericos
        public int size() => lenght;
        public int height(NoBinary node)
        {
            if (node == null || (node.getChildLeft() == null && node.getChildRight() == null))
                return 0;
            else
            {
                if (height(node.getChildLeft()) > height(node.getChildRight()))
                    return 1 + height(node.getChildLeft());
                else 
                    return 1 + height(node.getChildRight());
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
                    {
                        subTree.setChildRight(new NoBinary(subTree, value));
                        lenght++;
                    }
                    else
                        insert(subTree.getChildRight(), value);
                }
                else
                {
                    if (subTree.getChildLeft() == null)
                    {
                        subTree.setChildLeft(new NoBinary(subTree, value));
                        lenght++;
                    }
                    else insert(subTree.getChildLeft(), value);
                }
            }
        }

        //public void remove(NoBinary node, int value)
        //{
        //    //NoBinary deletedNode = search(root, value);
        //    // Se não tiver filhos
        //    if (isExternal(node))
        //    {
        //        NoBinary dad = node.getParent();
        //        if (dad.getChildLeft() == node) dad.setChildLeft(null);
        //        else dad.setChildRight(null);
        //        cleaNode(node);
        //    }
        //    // se tiver um filho
        //    else if (node.getChildLeft() == null || node.getChildRight() == null)
        //    {
        //        NoBinary dad = node.getParent();

        //        if (dad.getChildLeft() == null)
        //            dad.setChildRight(node.getChildRight());
        //        else
        //            dad.setChildLeft(node.getChildLeft());

        //        cleaNode(node);

        //    }
        //    // se tiver dois filhos
        //    else if (node.getChildLeft() != null && node.getChildRight() != null)
        //    {
        //        NoBinary aux = node.getChildRight().minNode();
        //        node.setElement(aux.getElement());
        //        remove(node.getChildRight(), node.getElement());
        //    }
        //}

        public NoBinary removeNode(NoBinary node, int value)
        {
            if (node == null) return null;

            if(value < node.getElement())
            {
                node.setChildLeft(removeNode(node.getChildLeft(), value));
                return node;
            } else if (value > node.getElement())
            {
                node.setChildRight(removeNode(node.getChildRight(), value));
                return node;
            } else
            {
                // caso 1
                if(node.getChildLeft() == null && node.getChildRight() == null)
                {
                    node = null;
                    return node;
                }
                // caso 2
                if(node.getChildLeft() == null)
                {
                    node = node.getChildRight();
                    return node;
                } else if(node.getChildRight() == null)
                {
                    node = node.getChildLeft();
                    return node;
                }
                //caso 3
                NoBinary aux = node.getChildRight().minNode();
                node.setElement(aux.getElement());
                node.setChildRight(removeNode(node.getChildRight(), value));
                return node;
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
            if (node == null || node == root)
            {
                return 0;
            }
            else
            {
                return (1 + depth(node.getParent()));
            }
        }

        public void treeInOrder(NoBinary tree, List<NoBinary> values)
        {
            if(tree != null)
            {
                treeInOrder(tree.getChildLeft(), values);
                values.Add(tree);
                Console.Write(" "+tree.getElement()+" " + "h " + tree.fb);
                treeInOrder(tree.getChildRight(), values);
            }
        }

        public void showTree(NoBinary node)
        {
            int line = height(node);
            int column = lenght;
            NoBinary[,] treeSchema = new NoBinary[line + 1, column];
            List<NoBinary> trees = new List<NoBinary>();

            treeInOrder(root, trees);
            Console.WriteLine("");

            for (int i = 0; i < column; i++)
            {
                NoBinary valor = trees[i];
                treeSchema[height(valor), i] = valor;
            }

            for (int i = 0; i < line; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < column; j++)
                {
                    if(treeSchema[i,j] == null)
                    {
                        Console.Write("       ");
                    } else if( treeSchema[i,j].getElement() > (trees.Count / 2))
                    {
                        Console.Write(treeSchema[i,j].getElement() + "h " + treeSchema[i,j].fb);
                    } else
                    {
                        Console.Write("       " + treeSchema[i,j].getElement() + "h " + treeSchema[i, j].fb);
                    }
                }
                Console.WriteLine("");
            }

        }
        #endregion
    }
}