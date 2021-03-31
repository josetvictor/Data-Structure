using System;
using System.Collections;
using System.Diagnostics;

namespace data_structs
{
    class Program
    {
        static void Main(string[] args)
        {
            // instanciando a arvore e adicionando filhos
            SimpleTree simples = new SimpleTree(1);
            simples.addChild(simples.root(), 2);
            simples.addChild(simples.root(), 3);
            simples.addChild(simples.root(), 4);
            simples.addChild(simples.root(), 5);
            simples.addChild(simples.root(), 8);

            Console.WriteLine("Tamanho da arvore \n");

            Console.WriteLine(simples.size());

            Console.ReadKey();
            Console.Clear();

            IEnumerator Filhos = simples.Nos();

            Console.WriteLine("Lista de nodos da arvore \n");

            NoTree nodo = null;

            while (Filhos.MoveNext())
            {
                NoTree filho = (NoTree)Filhos.Current;
                if((int)filho.element() == 5)
                {
                    nodo = filho;
                }
                Console.WriteLine(Filhos.Current);
            }

            Console.ReadKey();
            Console.Clear();

            Filhos = simples.elements();
            Console.WriteLine("Lista de elementos da arvore \n");
            while (Filhos.MoveNext())
            {
                Console.WriteLine(Filhos.Current);
            }

            Console.ReadKey();
            Console.Clear();

            // buscando filhos e aplicando metodo de swap e replace

            Console.WriteLine("metodo replace \n");
            Console.WriteLine("root before replace " + simples.root().element());
            simples.replace(simples.root(), 10);
            Console.WriteLine("root after replace "+simples.root().element());


            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Arvore antes do swap \n");

            Filhos = simples.elements();

            while (Filhos.MoveNext())
            {
                Console.WriteLine(Filhos.Current);
            }

            simples.swapElements(simples.root(), nodo);

            Console.WriteLine("Arvore depois do swap \n");

            Filhos = simples.elements();

            while (Filhos.MoveNext())
            {
                Console.WriteLine(Filhos.Current);
            }

            Console.WriteLine("Veja que a posição 10 foi trocada pela posição 5");

            Console.ReadKey();
            Console.Clear();

            

        }
    }
}
