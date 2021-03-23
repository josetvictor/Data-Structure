using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class EPilhaVazia : Exception
    {
        public EPilhaVazia(string text) : base(text) { }
    }
}
