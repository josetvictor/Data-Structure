using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs
{
    class EFilaVazia : Exception
    {
        public EFilaVazia(string text) : base(text) { }
    }
}
