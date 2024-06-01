using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace compiladoresAnalizador.modelo
{
    internal class AnalizadorLexico
    {
        private List<KeyValuePair<string, string>> patterns;

        public AnalizadorLexico()
        {
            patterns = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(@"\b(entero|decimal|caracter|vBool|vacio|constante|clase|publico|privado|protegido|estatico|si|sino|mientras|por|regresar|público)\b", "Palabra Reservada"),
                new KeyValuePair<string, string>(@"^[a-zA-Z_][a-zA-Z0-9_]*", "Identificador"),
                new KeyValuePair<string, string>(@"^[0-9]+\.[0-9]+", "Decimal"),
                new KeyValuePair<string, string>(@"^[0-9]+", "Entero"),
                new KeyValuePair<string, string>(@"^(verdadero|falso)", "Lógico"),
                new KeyValuePair<string, string>(@"^[-+\*/]", "Operador Aritmético"),
                new KeyValuePair<string, string>(@";", "Delimitador"),
                new KeyValuePair<string, string>(@"^(==|!=|<=|>=|<|>)", "Operador Relacional"),
                new KeyValuePair<string, string>(@"^=", "Operador Asignación"),
                new KeyValuePair<string, string>(@"^""([^""\\]|\\.)*""", "Cadena de Texto"),
                new KeyValuePair<string, string>(@"\(", "Paréntesis de Apertura"),
                new KeyValuePair<string, string>(@"\)", "Paréntesis de Cierre"),
                new KeyValuePair<string, string>(@"\{", "Llave de Apertura"),
                new KeyValuePair<string, string>(@"\}", "Llave de Cierre"),
                new KeyValuePair<string, string>(@"\s+", "Espacio"),
                new KeyValuePair<string, string>(@"\n+", "Salto de línea"),
                new KeyValuePair<string, string>(@",", "Delimitador")
            };
        }

        public List<Token> Analizar(string input)
        {
            List<Token> tokens = new List<Token>();
            int position = 0;

            while (position < input.Length)
            {
                bool matchFound = false;

                foreach (KeyValuePair<string, string> pattern in patterns)
                {
                    Match match = Regex.Match(input.Substring(position), pattern.Key);

                    if (match.Success && match.Index == 0)
                    {
                        //Eliminacion de espacios y saltos de linea
                        if (pattern.Value != "Espacio" && pattern.Value != "Salto de línea")
                        {
                            tokens.Add(new Token(match.Value, pattern.Value));
                        }
                        position += match.Length;
                        matchFound = true;
                        break;
                    }
                }

              

                if (!matchFound)
                {
                    throw new Exception($"Error léxico: carácter inesperado en la posición {position}: {input[position]}");
                }
            }

            return tokens;
        }
    }
}
