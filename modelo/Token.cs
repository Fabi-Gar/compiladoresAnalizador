using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiladoresAnalizador.modelo
{
    internal class Token
    {
        public string Value { get; }
        public string Type { get; }

        public Token(string value, string type)
        {
            Value = value;
            Type = type;
        }

        public override string ToString()
        {
            return $"Token: {Value}, Tipo: {Type}";
        }
    }
}



