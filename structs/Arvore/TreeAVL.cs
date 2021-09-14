using data_structs.Node;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Arvore
{
    class TreeAVL : SearchBinaryTree
    {
        NoBinary root;
        int lenght;

        public TreeAVL(NoBinary no) : base(no)
        {
            root = no;
            lenght = 1;
        }

        public NoBinary rotationSL(NoBinary node)
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

            balanceFactor(aux);

            return node;
        }

        public NoBinary rotationSR(NoBinary node)
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

            balanceFactor(aux);

            return node;
        }

        public NoBinary doubleRotationRL(NoBinary node)
        {
            node.setRight(rotationSL(node.Right()));
            return rotationSR(node);
        }

        public NoBinary doubleRotationLR(NoBinary node)
        {
            node.setLeft(rotationSR(node.Left()));
            return rotationSL(node);
        }

        public void balanceFactor(NoBinary node)
        {
            node.setBalanceFactor(height(node.Left()) - height(node.Right()));
        }

        public void insertAVL(NoBinary node, int value)
        {
            // Percorre a arvore e insere o nó como na BST
            if (node != null)
            {
                if (value > node.Element())
                {
                    if (node.Right() == null)
                    {
                        node.setRight(new NoBinary(node, value));
                        lenght++;
                    }
                    else
                        insert(node.Right(), value);
                }
                else
                {
                    if (node.Left() == null)
                    {
                        node.setLeft(new NoBinary(node, value));
                        lenght++;
                    }
                    else insert(node.Left(), value);
                }
            }
            // balanceia a árvore se for necessário
            passinhoDoVolante(node);
        }

        public bool compAVL(TreeAVL A, TreeAVL B)
        {
            List<NoBinary> arvoreA = new List<NoBinary>();
            List<NoBinary> arvoreB = new List<NoBinary>();

            arvoreA = A.root.nodeElements(arvoreA, A.root);
            arvoreB = B.root.nodeElements(arvoreB, B.root);
            
            arvoreA.ToArray();
            arvoreB.ToArray();

            if (arvoreA.Count != arvoreB.Count)
            {
                return false;
            } else
            {
                for (int i = 0; i < arvoreA.Count; i++)
                {

                    if (arvoreA[i].Element() != arvoreB[i].Element())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void removeAVL(int value)
        {
            // Busca o nó que vai ser deletado
            var deleted = search(root, value);
            // Deleta o nó encontrado
            remove(deleted);
            // Balancia a arvore se for necessário
            passinhoDoVolante(root);
        }

        public void passinhoDoVolante(NoBinary node) {
            balanceFactor(node);
            if (node.BalanceFactor() == 2)
            {
                var Left = node.Left();
                if (Left.BalanceFactor() == 0 || Left.BalanceFactor() == 1)
                {
                    rotationSR(node);
                }
                if (Left.BalanceFactor() == -1)
                {
                    doubleRotationLR(Left);
                }
            }
            if (node.BalanceFactor() == -2)
            {
                var Right = node.Right();
                if (Right.BalanceFactor() == 0 || Right.BalanceFactor() == -1)
                {
                    rotationSL(node);
                }
                if (Right.BalanceFactor() == 1)
                {
                    doubleRotationRL(node.Right());
                }
            }

            if(node == root || node.Parent() == null)
            {
                root = node;
            }
            else
            {
                passinhoDoVolante(node.Parent());
            } 
        }
    }
}
