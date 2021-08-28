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

        public int depthRN(NoRubroNegra node)
        {
            if (node == null || node == root)
                return 0;
            else
                return (1 + depthRN(node.Parent()));
        }

        public int heightRN(NoRubroNegra node)
        {
            if (node == null || (node.Left() == null && node.Right() == null))
                return 0;
            else
            {
                if (heightRN(node.Left()) > heightRN(node.Right()))
                    return 1 + heightRN(node.Left());
                else 
                    return 1 + heightRN(node.Right());
            }
        }

        public void showTreeRN(NoRubroNegra tree)
        {
            int rows = heightRN(tree) + 1;
            int columns = lenght;

            NoRubroNegra[,] matrizTree = new NoRubroNegra[rows, columns];
            ArrayList nodes = new ArrayList();

            nodes = tree.nodeElements(nodes, tree);

            nodes.ToArray();
            for(int i = 0; i < columns; i++)
            {
                NoRubroNegra no = null;
                if (i < nodes.ToArray().Length)
                    no = (NoRubroNegra)nodes[i]; ;
                matrizTree[depthRN(no), i] = no;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    NoRubroNegra node = matrizTree[i, j];

                    if (node == null)
                        Console.Write(" ");
                    else
                        Console.Write(node.Element() + "[" + node.Cor() + "]");

                    Console.Write("   ");
                }
                Console.WriteLine("");
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

            node.setCor('R');
            node.Left().setCor('N');
            node.Right().setCor('N');
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

            node.setCor('R');
            node.Left().setCor('N');
            node.Right().setCor('N');
            return node;
        }

        public void recolorir(NoRubroNegra node){
            if(node.Parent() == null && node.Cor() == "N")
                return;
            else if(node != null && node.Cor() == "R")
                node.setCor("N");
            else if(node != null && node.Cor() == "N")
                node.setCor("R");
        }

        public void insertRN(NoRubroNegra node, int value)
        {
            // Percorre a arvore e insere o nó como na BST
            if (node != null)
            {
                if (value > node.Element())
                {
                    if (node.Right() == null)
                    {
                        node.setRight(new NoRubroNegra(node, value));
                        lenght++;
                        if(node.Parent().Cor() == "R")
                            recolorir(node);
                    }
                    else
                        insert(node.Right(), value);
                }
                else
                {
                    if (node.Left() == null)
                    {
                        node.setLeft(new NoRubroNegra(node, value));
                        lenght++;
                        if(node.Parent().Cor() == "R")
                            recolorir(node);
                    }
                    else insert(node.Left(), value);
                }
                balanceRubroNegra(NoRubroNegra node);
            }
        }

        public void balanceRubroNegra(NoRubroNegra node)
        {
            // caso 1
            if(node.Cor() == "R" && node.Parent().Cor() == "N")
                return;
            // caso 2
            if(node.Cor() == "R" && node.Parent().Cor() == "R"){
                // Verifica quem é o tio e salva em uma variavel
                var uncle;
                if(node.Parent() == node.Parent().Parent().Left())
                    uncle = node.Parent().Parent().Right();
                else
                    uncle = node.Parent().Parent().Left();

                if(uncle != null && uncle == "R"){
                    recolorir(node.Parent());
                    recolorir(node.Parent().Parent());
                    recolorir(node.Parent().Parent().Left());
                } else if(uncle != null && uncle == "R"){
                    recolorir(node.Parent());
                    recolorir(node.Parent().Parent());
                    recolorir(node.Parent().Parent().Right());
                }
                balanceRubroNegra(node.Parent().Parent());
                // caso 3
                if(uncle == null || uncle.Cor() == "N"){
                    // caso a
                    if(uncle == node.Parent().Parent().Right()){
                        node = rotationSR(node);
                        balanceRubroNegra(node);
                    } else if(uncle == node.Parent().Parent().Left()){
                        node = rotationSL(node);
                        balanceRubroNegra(node);
                    }
                }
            }
        }
    }
}
