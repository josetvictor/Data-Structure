using data_structs.Node;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Arvore
{
    class TreeRN : SearchBinaryTree
    {
        private NoRubroNegra root;
        private int lenght;

        public TreeRN(NoRubroNegra no) : base(no)
        {
            root = no;
            lenght = 1;
        }

        public int blackHeight(NoRubroNegra node)
        {
            int height = 0;
            if(node != null)
            {
                if(node.Cor() == "N")
                {
                    height = 1 + Math.Max(blackHeight(node.Left()), blackHeight(node.Right()));
                } else
                {
                    height = Math.Max(blackHeight(node.Left()), blackHeight(node.Right()));
                }
            }
            return height;
        }

        public bool isRN(NoRubroNegra tree)
        {

            if(blackHeight(tree.Left()) != blackHeight(tree.Right()))
            {
                return false;
            }

            if (isRoot(tree) && tree.Cor() != "N")
            {
                return false;
            }

            ArrayList nodes = new ArrayList();
            nodes = tree.nodeElements(nodes, tree);

            foreach(NoRubroNegra node in nodes)
            {
                if(node.Left() != null && node.Right() != null)
                {
                    if (node.Cor() == "R" && (node.Left().Cor() != "N" || node.Right().Cor() != "N"))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool isExternal(NoRubroNegra node) => node.Left() == null && node.Right() == null;

        public bool isRoot(NoRubroNegra node) => node == root;

        public void recolorir(NoRubroNegra node)
        {
            if (node == root && node.Parent() == null)
                return;
            if (node != null && node.Cor() == "R")
                node.setCor("N");
            else if(node != null && node.Cor() == "N")
                node.setCor("R");
        }

        public int height(NoRubroNegra node)
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

        public int depth(NoRubroNegra node)
        {
            if (node == null || node == root)
                return 0;
            else
                return (1 + depth(node.Parent()));
        }

        public NoRubroNegra search(NoRubroNegra tree, int value)
        {
            if (tree.Element() == value)
                return tree;
            if (value < tree.Element())
                return search(tree.Left(), value);

            return search(tree.Right(), value);
        }

        public void insert(NoRubroNegra node, int value)
        {
            //if (node.Parent() != null && node.Parent().Cor() == "R")
            //    node.setCor("N");
            // Percorre a arvore e insere o nó como na BST
            if (node != null)
            {
                if (value > node.Element())
                {
                    if (node.Right() == null)
                    {
                        var newNodeRN = new NoRubroNegra(node, value);
                        node.setRight(newNodeRN);
                        lenght++;
                        balanceTree(node.Right());
                        if (newNodeRN.Parent() != null && newNodeRN.Parent().Cor() == "R")
                            newNodeRN.setCor("N");
                    }
                    else
                        insert(node.Right(), value);
                }
                else
                {
                    if (node.Left() == null)
                    {
                        var newNodeRN = new NoRubroNegra(node, value);
                        node.setLeft(newNodeRN);
                        lenght++;
                        balanceTree(node.Left());
                        if (newNodeRN.Parent() != null && newNodeRN.Parent().Cor() == "R")
                            newNodeRN.setCor("N");
                    }
                    else insert(node.Left(), value);
                }
            }
        }

        public void balanceTree(NoRubroNegra node)
        {
            // caso 1
            if (node.Cor() == "R" && node.Parent().Cor() == "N")
                return;
            // Caso 2
            if (node.Parent().Cor() == "R" && (node.Parent().Parent().Left() != null && node.Parent().Parent().Left().Cor() == "R"))
            {
                recolorir(node.Parent());
                recolorir(node.Parent().Parent());
                recolorir(node.Parent().Parent().Left());

                balanceTree(node.Parent());
                return;
            } else if (node.Parent().Cor() == "R" && (node.Parent().Parent().Right() != null && node.Parent().Parent().Right().Cor() == "R"))
            {
                recolorir(node.Parent());
                recolorir(node.Parent().Parent());
                recolorir(node.Parent().Parent().Left());

                balanceTree(node.Parent());
                return;
            }
            //caso 3
            if (node.Parent().Cor() == "R" && (node.Parent().Parent().Left() == null || node.Parent().Parent().Left().Cor() == "N"))
            {
                rotationSR(node.Parent().Parent());
            }
            else if (node.Cor() == "R" && (node.Parent().Right() == null || node.Parent().Right().Cor() == "N"))
            {
                rotationSL(node);
            }
        }

        public NoRubroNegra rotationSL(NoRubroNegra node)
        {
            var vovz = node.Parent();
            var aux = node;
            node = node.Right();
            node.setParent(aux.Parent());
            aux.setParent(node);
            node.setLeft(aux);
            aux.setRight(node.Left());
            node.setParent(vovz);

            if (vovz.Left() == aux)
                vovz.setLeft(node);
            else
                vovz.setRight(node);

            node.setCor("N");
            node.Left().setCor("R");
            node.Right().setCor("R");

            return node;
        }

        public NoRubroNegra rotationSR(NoRubroNegra node)
        {
            var vovz = node.Parent();
            var aux = node;
            node = node.Left();
            node.setParent(aux.Parent());
            aux.setParent(node);
            node.setRight(aux);
            aux.setLeft(node.Right());
            node.setParent(vovz);

            if (vovz.Left() == aux)
                vovz.setLeft(node);
            else
                vovz.setRight(node);

            node.setCor("N");
            node.Left().setCor("R");
            node.Right().setCor("R");

            return node;
        }

        public void showTreeRN(NoRubroNegra tree)
        {
            int rows = height(tree);
            int columns = lenght;

            NoRubroNegra[,] matrizTree = new NoRubroNegra[rows + 1, columns];
            ArrayList nodes = new ArrayList();

            nodes = tree.nodeElements(nodes, tree);

            nodes.ToArray();
            for (int i = 0; i < columns; i++)
            {
                NoRubroNegra no = null;
                if (i < nodes.ToArray().Length)
                    no = (NoRubroNegra)nodes[i]; ;
                matrizTree[depth(no), i] = no;
            }

            for (int i = 0; i < rows+1; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    NoRubroNegra node = matrizTree[i, j];

                    if (node == null)
                        Console.Write("     ");
                    else
                        Console.Write(node.Element() + "[" + node.Cor() +"]");

                    Console.Write("      ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
    }
}
