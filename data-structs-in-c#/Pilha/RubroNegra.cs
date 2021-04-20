using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class RubroNegra
    {
		private int tRed, tBlack, arrayLength;
		private Object[] array;
		public RubroNegra(int length)
		{
			array = new object[length];
			arrayLength = length;
			tRed = -1;
			tBlack = arrayLength;
		}
		public int size_red()
		{
			return tRed + 1;
		}
		public int size_black()
		{
			return arrayLength - tBlack;
		}
		public Object pop_red()
		{
			if (isEmpty_red()) throw new EPilhaVazia("A pilha vermelha está vazia");
			tRed = tRed - 1;
			return array[tRed + 1];
		}
		public Object pop_black()
		{
			if (isEmpty_black()) throw new EPilhaVazia("A pilha preta está vazia");
			tBlack = tBlack + 1;
			return array[tBlack - 1];
		}
		public void push_red(Object objeto)
		{
			int newLinha;
			Object[] novoArray;
			if (tRed + 1 == tBlack)
			{
				newLinha = arrayLength * 2;
				novoArray = new object[newLinha];

				for (int i = 0; i < tRed; i++)
				{
					novoArray[i] = array[i];
				}
				for (int ii = 1; ii <= arrayLength - tBlack; ii++)
				{
					novoArray[newLinha - ii] = array[arrayLength - ii];
				}
				arrayLength = newLinha;
				array = novoArray;
			}
			array[++tRed] = objeto;
			Console.WriteLine("Foi adicionado um elemento na pilha vermelha");
		}
		public void push_black(object objeto)
		{
			int newLinha;
			Object[] novoArray;
			if (tBlack - 1 == tRed)
			{
				newLinha = arrayLength * 2;
				novoArray = new Object[newLinha];
				for (int ii = 1; ii <= arrayLength - tBlack; ii++)
				{
					novoArray[newLinha - ii] = array[arrayLength - ii];
				}
				for (int i = 0; i < tRed; i++)
				{
					novoArray[i] = array[i];
				}
				tBlack = newLinha - (arrayLength - tBlack);
				arrayLength = newLinha;
				array = novoArray;
			}
			array[--tBlack] = objeto;
			Console.WriteLine("Foi adicionado um elemento na pilha preta");
		}
		public Object top_red()
		{
			if (isEmpty_red()) throw new EPilhaVazia("A pilha vermelha está vazia");
			return array[tRed];
		}
		public Object top_black()
		{
			if (isEmpty_black()) throw new EPilhaVazia("A pilha preta está vazia");
			return array[tBlack];
		}
		public Boolean isEmpty_red()
		{
			return tRed == -1;
		}
		public Boolean isEmpty_black()
		{
			return tBlack == arrayLength;
		}
	}
}
