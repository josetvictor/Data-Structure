using data_structs.Node;
using System;
using System.Collections;

namespace data_structs{
    public class SimpleTree {

        #region Atributos
        NoTree raiz;
        int tamanho;
        #endregion

        public SimpleTree(object value) {
            raiz = new NoTree(null, value);
            tamanho = 1;
        }

        #region Metodos genericos
        public int size() {
            return tamanho;
        }

        public int height(NoTree value) {
            //método exercício
            if (isExternal(value))
                return 0;
            else
            {
                int altura = 0;
                while (children(value).MoveNext())
                {
                    altura = Math.Max(altura, height(raiz));
                }
                return altura+1;
            }
        }

        public bool isEmpty() {
            return false;
        }

        public void preOrder(NoTree node, ArrayList lista, bool isElement)
        {
            if (isElement)
                lista.Add(node.element());
            else lista.Add(node);

            IEnumerator nodos = children(node);
            while (nodos.MoveNext())
            {
                preOrder((NoTree)(nodos.Current), lista, isElement);
            }
        }
        
        public IEnumerator elements() {
            //método exercício
            IEnumerator filhos = children(raiz);
            ArrayList lista = new ArrayList();
            lista.Add(raiz.element());

            while (filhos.MoveNext())
            {
                preOrder((NoTree)(filhos.Current), lista, true);
            }
            return lista.GetEnumerator();
        }
        
        public IEnumerator Nos() {
            //método exercício
            IEnumerator filhos = children(raiz);
            ArrayList lista = new ArrayList();
            lista.Add(raiz);

            while (filhos.MoveNext())
            {
                preOrder((NoTree)(filhos.Current), lista, false);
            }
            return lista.GetEnumerator();
        }
        #endregion

        #region Metodos de acesso
        public NoTree root() {
            return raiz;
        }
        
        public NoTree parent(NoTree node) {
            return node.parent();
        }
        
        public IEnumerator children(NoTree node) {
            return node.children();
        }
        #endregion

        #region Metodos de consulta
        public bool isInternal(NoTree node) {
            return (node.childrenNumber() > 0);
        }
        
        public bool isExternal(NoTree node) {
            return (node.childrenNumber() == 0);
        }
        
        public bool isRoot(NoTree node) {
            return (node == this.raiz);
        }

        public int depth(NoTree node) {
            if ((node == this.raiz)) {
                return 0;
            }
            else {
                return (1 + this.depth(node.parent()));
            }
        }
        #endregion

        #region Metodo de atualização
        public object replace(NoTree node, object objeto) {
            //método exercício
            node.setElement(objeto);
            return objeto;
        }
        #endregion

        #region Metodos adicionais
        // São metodos definidos pela estrutura que estende o TAD árvore

        public void addChild(NoTree node, object objeto) {
            NoTree novo = new NoTree(node, objeto);
            node.addChild(novo);
            this.tamanho++;
        }
        
        public object remove(NoTree node) {
            NoTree pai = node.parent();
            if (((pai != null) || this.isExternal(node))) {
                pai.removeChild(node);
            }
            else {
                throw new SystemException();
            }
            
            object objeto= node.element();
            tamanho--;
            return objeto;
        }

        public void swapElements(NoTree nodeLeft, NoTree nodeRight) {
            //método exercício
            var aux = nodeLeft.element();
            nodeLeft.setElement(nodeRight.element());
            nodeRight.setElement(aux);
        }
        #endregion
    }
}
