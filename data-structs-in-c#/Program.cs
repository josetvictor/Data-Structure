using System;
using System.Diagnostics;

namespace data_structs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("Menu of data structs");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Escolha Uma opção abaxo:");
                Console.Write("(1)Rubro Negra | (2)Fila Array | (3)Fila Lista | (4)Pilha Array | (5)Pilha Lista | (6)Deque \n");
                int op = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op)
                {
                    case 1:
                        RubroNegra minhaPia = new RubroNegra(5);
                        minhaPia.push_black(5);
                        minhaPia.push_black(7);
                        minhaPia.push_red(23);
                        minhaPia.push_red(2);
                        minhaPia.push_red(4);
                        Console.WriteLine("Size of stack black " + minhaPia.size_black());

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        FilaArray minhaFia = new FilaArray(2);
                        minhaFia.enqueue(5);
                        minhaFia.enqueue(6);
                        minhaFia.enqueue(10);
                        Console.WriteLine("Teste de solidão " + minhaFia.isEmpty());
                        Console.WriteLine("Tamanho " + minhaFia.size());
                        Console.WriteLine("Peek " + minhaFia.top());

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        FilaList minhaFiaL = new FilaList();
                        minhaFiaL.enqueue(5);
                        minhaFiaL.enqueue(6);
                        minhaFiaL.enqueue(8);
                        Console.WriteLine("Teste de solidão " + minhaFiaL.isEmpty());
                        Console.WriteLine("Tamanho " + minhaFiaL.size());
                        Console.WriteLine("Peek " + minhaFiaL.peek());

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Stopwatch tempoDuracao = new Stopwatch();

                        Console.WriteLine("Escreva o valor de elementos para a pilha");
                        int elementos = int.Parse(Console.ReadLine());

                        StackArray Pilha1 = new StackArray(0, 10);
                        StackArray Pilha2 = new StackArray(0, 100);
                        StackArray Pilha3 = new StackArray(0, 1000);
                        StackArray Pilha4 = new StackArray(1);

                        tempoDuracao.Start();
                        for (int i = 0; i <= elementos; i++)
                        {
                            Pilha4.push(i);
                            Console.WriteLine("elemento na pilha " + i);
                        }
                        tempoDuracao.Stop();

                        Console.WriteLine("tempo de duração " + tempoDuracao.ElapsedMilliseconds.ToString());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        StackList minhaPiaL = new StackList();
                        minhaPiaL.push(5);
                        minhaPiaL.push(6);
                        minhaPiaL.push(8);
                        Console.WriteLine("Teste de Solidão: " + minhaPiaL.isEmpty());
                        Console.WriteLine("Tamanho: " + minhaPiaL.size());
                        Console.WriteLine("Top: " + minhaPiaL.top());

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Deque meuBeq = new Deque();
                        meuBeq.insertHeader(new DuploNo(5));
                        meuBeq.insertHeader(new DuploNo(6));
                        meuBeq.insertHeader(new DuploNo(8));
                        meuBeq.insertTail(new DuploNo(10));
                        meuBeq.insertTail(new DuploNo(23));
                        Console.WriteLine("Teste de solidão " + meuBeq.isEmpty());
                        Console.WriteLine("Tamanho " + meuBeq.lengthM());
                        Console.WriteLine("Cabeça " + meuBeq.header());
                        Console.WriteLine("Rabo " + meuBeq.tail());

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
