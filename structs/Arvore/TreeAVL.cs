using data_structs.Node;
using System;
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
            NoBinary aux = node.Left();
            node.setLeft(aux.Right());
            aux.setRight(node);
            return aux;
        }

        public NoBinary rotationSR(NoBinary node)
        {
            NoBinary aux = node.Right();
            node.setRight(aux.Left());
            aux.setLeft(node);
            return aux;
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

        public int balanceFactor(NoBinary node)
        {
            return height(node.Left()) - height(node.Right());
        }

        public void insertAVL(NoBinary node, int value)
        {
            // Percorre a arvore e insere o nó como na BST
            insert(node, value);
            // balanceia a árvore se for necessário
            if (balanceFactor(node) == 2)
            {
                if (value < node.Left().Element())
                {
                    rotationSL(node);
                }
                else
                {
                    doubleRotationLR(node);
                }
            }
            if (balanceFactor(node) == -2)
            {
                if (value > node.Right().Element())
                {
                    rotationSR(node);
                }
                else
                {
                    doubleRotationRL(node);
                }
            }
        }

        public NoBinary removeAVL(NoBinary node, int value)
        {
            // Busca o nó que vai ser deletado
            var deleted = search(node, value);
            // Deleta o nó encontrado
            remove(deleted);
            // Balancia a arvore se for necessário
            if (balanceFactor(node) == 2)
            {
                int balanceFactorLeft = balanceFactor(node.Left());
                if (balanceFactorLeft == 0 || balanceFactorLeft == 1)
                {
                    return rotationSL(node);
                }
                if (balanceFactorLeft == -1)
                {
                    return doubleRotationLR(node.Left());
                }
            }
            if (balanceFactor(node) == -2)
            {
                int balanceFactorRight = balanceFactor(node.Right());
                if (balanceFactorRight == 0 || balanceFactorRight == -1)
                {
                    return rotationSR(node);
                }
                if (balanceFactorRight == 1)
                {
                    return doubleRotationRL(node.Right());
                }
            }

            return node;
        }

    }
}
