using data_structs.Arvore;
using data_structs.Node;
using System;

namespace data_structs
{
    class Program
    {
        static void Main(string[] args)
        {
            NoRubroNegra root = new NoRubroNegra(20);
            TreeRN rn = new TreeRN(root);

            rn.insert(root, 10);
            rn.insert(root, 30);
            rn.insert(root, 33);
            rn.insert(root, 32);
            rn.insert(root, 34);
            rn.insert(root, 35);

            rn.showTreeRN(root);

            Console.ReadKey();
            //NoBinary root = new NoBinary(null, 50);
            //TreeAVL searchTree = new TreeAVL(root);

            //searchTree.insertAVL(root, 20);
            //searchTree.insertAVL(root, 100);
            //searchTree.insertAVL(root, 80);

            //searchTree.showTree(root);

            //Console.ReadKey();

            //Console.WriteLine("");

            //var removeNode = searchTree.search(root, 20);
            //searchTree.remove(removeNode);

            //searchTree.showTree(root);

            //while (true)
            //{
            //    Console.WriteLine("Escolha uma ação");
            //    Console.WriteLine("Digite 1 para inserir / Digite 2 para remover");
            //    int choice = int.Parse(Console.ReadLine());
            //    if (choice == 1)
            //    {
            //        Console.WriteLine("Insira um novo valor na arvore!");
            //        int value = int.Parse(Console.ReadLine());
            //        searchTree.insert(root, value);

            //        Console.Clear();
            //    } else if(choice == 2)
            //    {
            //        Console.WriteLine("Insira o elemento que você quer remover da arvore!");
            //        int value = int.Parse(Console.ReadLine());
            //        //searchTree.remove(searchTree.search(root, value), value);

            //        Console.Clear();
            //    }

            //    searchTree.showTree(searchTree.getRoot());

            //    Console.ReadKey();

            //    Console.Clear();
            //}
        }
    }
}
