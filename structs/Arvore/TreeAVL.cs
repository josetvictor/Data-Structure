using data_structs.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Arvore
{
    static class BalanceFactor
    {
        public const int UNBALANCED_RIGHT = 1;
        public const int SLIGHTY_UNBALANCED_RIGHT = 2;
        public const int BALANCED = 3;
        public const int SLIGHTY_UNBALANCED_LEFT = 4;
        public const int UNBALANCED_LEFT = 5;
    }

    class TreeAVL : SearchBinaryTree
    {
        NoBinary root;
        int lenght, balanceFactor;

        public TreeAVL(NoBinary no) : base(no)
        {
            root = no;
            lenght = 1;
        }

        public int getNodeHeight(NoBinary node)
        {
            if (node == null) return -1;

            return Math.Max(getNodeHeight(node.getChildLeft()), getNodeHeight(node.getChildRight()));
        }

        public int getBalanceFactor(NoBinary node)
        {
            int balanceFactorDiference = getNodeHeight(node.getChildLeft()) - getNodeHeight(node.getChildRight());

            switch (balanceFactorDiference)
            {
                case -2:
                    node.fb = -2;
                    return BalanceFactor.UNBALANCED_RIGHT;
                case -1:
                    node.fb = -1;
                    return BalanceFactor.SLIGHTY_UNBALANCED_RIGHT;
                case 1:
                    node.fb = 1;
                    return BalanceFactor.SLIGHTY_UNBALANCED_LEFT;
                case 2:
                    node.fb = 2;
                    return BalanceFactor.UNBALANCED_LEFT;
                default:
                    node.fb = 0;
                    return BalanceFactor.BALANCED;
            }
        }


        public NoBinary rotationSL(NoBinary node)
        {
            NoBinary aux = node.getChildLeft();
            node.setChildLeft(aux.getChildRight());
            aux.setChildRight(node);
            return aux;
        }

        public NoBinary rotationSR(NoBinary node)
        {
            NoBinary aux = node.getChildRight();
            node.setChildRight(aux.getChildLeft());
            aux.setChildLeft(node);
            return aux;
        }

        public NoBinary doubleRotationRL(NoBinary node)
        {
            node.setChildRight(rotationSL(node.getChildRight()));
            return rotationSR(node);
        }

        public NoBinary doubleRotationLR(NoBinary node)
        {
            node.setChildLeft(rotationSR(node.getChildLeft()));
            return rotationSL(node);
        }

        public void insertAVL(NoBinary node, int value)
        {
            // insere o nó como na BST
            insert(node, value);
            // balanceia a árvore se for necessário
            int balanceFactor = getBalanceFactor(node);
            if (balanceFactor == BalanceFactor.UNBALANCED_LEFT)
            {
                if (value < node.getChildLeft().getElement())
                {
                    rotationSL(node);
                }
                else
                {
                    doubleRotationLR(node);
                }
            }
            if (balanceFactor == BalanceFactor.UNBALANCED_RIGHT)
            {
                if (value > node.getChildRight().getElement())
                {
                    rotationSR(node);
                }
                else
                {
                    doubleRotationRL(node);
                }
            }
        }

        public NoBinary remove(NoBinary node, int value)
        {
            node = removeNode(node, value);
            if (node == null)
                return node;

            int balanceFactor = getBalanceFactor(node);
            if (balanceFactor == BalanceFactor.UNBALANCED_LEFT)
            {
                int balanceFactorLeft = getBalanceFactor(node.getChildLeft());
                if (balanceFactorLeft == BalanceFactor.BALANCED || balanceFactorLeft == BalanceFactor.SLIGHTY_UNBALANCED_LEFT)
                {
                    return rotationSL(node);
                }
                if (balanceFactorLeft == BalanceFactor.SLIGHTY_UNBALANCED_RIGHT)
                {
                    return doubleRotationLR(node.getChildLeft());
                }
            }
            if (balanceFactor == BalanceFactor.UNBALANCED_RIGHT)
            {
                int balanceFactorRight = getBalanceFactor(node.getChildRight());
                if (balanceFactorRight == BalanceFactor.BALANCED || balanceFactorRight == BalanceFactor.SLIGHTY_UNBALANCED_RIGHT)
                {
                    return rotationSR(node);
                }
                if (balanceFactorRight == BalanceFactor.SLIGHTY_UNBALANCED_LEFT)
                {
                    return doubleRotationRL(node.getChildRight());
                }
            }

            return node;
        }

    }
}
