using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class EDequeVazio : Exception
    {
        public EDequeVazio(string text) : base(text) { }
    }
}
