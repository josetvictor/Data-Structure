using data_structs.Tabela_Hash;
using System;

namespace data_structs
{
    class Program
    {
        static void Main(string[] args)
        {
            TabelaHash tabela = new TabelaHash(13);

            Console.WriteLine("Tamanho inicial da tabela: " + tabela.size());

            tabela.insertElement(18, "João");
            tabela.insertElement(41, "Maria");
            tabela.insertElement(22, "Lucas");
            tabela.insertElement(44, "Johnny");
            tabela.insertElement(59, "Dani");
            tabela.insertElement(32, "Lina");
            tabela.insertElement(31, "Coleguinha 1");
            tabela.insertElement(72, "Coleguinha 2");

            Console.WriteLine("Lista de keys da tabela: ");
            Console.WriteLine(tabela.keys());

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Lista de elementos na tabela:");
            tabela.elements();
            Console.WriteLine("----------------------------------------------");

            // Removendo 2 coleguinhas
            tabela.removeElement(31);
            tabela.removeElement(72);

            Console.WriteLine("Lista de elementos na depois da remoção:");
            tabela.elements();
            Console.WriteLine("----------------------------------------------");


            Console.WriteLine("Tamanho depois de atengir sua capacidade de 50% da tabela: " + tabela.size());

        }
    }
}
