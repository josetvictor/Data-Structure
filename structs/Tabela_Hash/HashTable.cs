using System;

namespace data_structs.Tabela_Hash
{
    class TabelaHash
    {
        ItemPair[] hash;

        public TabelaHash(int length)
        {
            hash = new ItemPair[length];
        }

        public int size() => hash.Length;

        private int h(int k) => k % size();

        private int d(int k) => 7 - k % 7;

        public string keys()
        {
            string keys = "| ";
            for(int i = 0; i < size(); i++)
            {
                if (hash[i] != null)
                    keys = keys + hash[i].getKey() + " | ";
            }

            return keys;
        }

        public void elements()
        {
            for (int i = 0; i < size(); i++)
            {
                if (hash[i] != null)
                    Console.WriteLine(hash[i].getElement());
            }

        }

        public string findElement(int key)
        {
            int indice = key % size();
            int cont = 0;

            while(true)
            {
                ItemPair el = hash[indice];
                if (cont == size())
                    return "NO_SUCH_KEY";
                else if (el.getKey() == key)
                    return el.getElement();
                else
                {
                    indice = (indice + 1) % size();
                    cont++;
                }
            }
        }

        public string removeElement(int key)
        {

            for (int i = 0; i < size(); i++)
            {
                if (hash[i] != null && hash[i].getKey() == key)
                {
                    string o = hash[i].getElement();
                    hash[i].setElement("AVAILABLE");
                    return o;
                }
            }
            throw new Exception("NO_SUCH_KEY");
        }

        public void insertElement(int key, string v)
        {
            int N = size();
            int j = 0;
            int indice = (h(key) + j*d(key)) % N;

            ItemPair newItem = new ItemPair(key, v);

            while (true)
            {
                if (alfa())
                {
                    reHash(hash);
                }
                else
                {
                    ItemPair el = hash[indice];
                    if (el == null)
                    {
                        hash[indice] = newItem;
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                            if(hash[indice] == null)
                            {
                                hash[indice] = newItem;
                                break;
                            }
                            else
                            {
                                j++;
                                indice = (h(key) + j * d(key)) % N;
                            }
                        }
                        break;
                    }
                }
            }

        }

        private int contElements()
        {
            int n = 0;
            for (int i = 0; i < size(); i++)
            {
                if (hash[i] == null)
                    continue;
                else n++;
            }

            return n;
        }

        private bool alfa()
        {
            decimal n = contElements();
            decimal N = size();

            decimal alfa = n / N;

            if (alfa > (decimal)0.5) return true;
            else return false;
        }

        private void reHash(ItemPair[] hash)
        {
            ItemPair[] newHash = new ItemPair[size()*2];

            for (int i = 0; i< size();i++)
            {
                if (hash[i] != null)
                    newHash[i] = hash[i];
            }

            this.hash = newHash;
            
        }
    }

    class ItemPair
    {
        int key;
        string element;

        public ItemPair(int key, string element)
        {
            this.key = key;
            this.element = element;
        }

        public int getKey() => key;

        public string getElement() => element;
        public string setElement(string el) => element = el;
    }
}
