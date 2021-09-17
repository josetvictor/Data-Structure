using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Grafos
{
    public class Vertice
    {
        private object node;

        public Vertice()
        {

        }

        public object getVertice() => node;

        public void setVertice(object newV) => node = newV;
    }
}
