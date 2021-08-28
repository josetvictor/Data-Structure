using data_structs.Arvore;
using data_structs.Node;
using System;

namespace data_structs
{
    class Program
    {
        static void Main(string[] args)
        {
            NoBinary root = new NoBinary(null, 10);
            TreeRN rn = new TreeRN(root);

            rn.insertRN(root, 5);
            rn.insertRN(root, 2);
            rn.insertRN(root, 8);
            rn.insertRN(root, 15);
            rn.insertRN(root, 22);
            rn.insertRN(root, 25);

            rn.showTree(root);

            Console.ReadKey();

            Console.WriteLine("");

            var removeNode = searchTree.search(root, 5);
            searchTree.remove(removeNode);

            searchTree.showTree(root);

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
