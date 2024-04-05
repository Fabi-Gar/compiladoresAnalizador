using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace compiladoresAnalizador.modelo
{
    internal class modeloAnalizadorLexico
    {
        internal class AnalizadorLexico
        {
            private Dictionary<string, string> patterns;

            // Creacion del diccionario con las reglas
            public AnalizadorLexico()
            {
                // Se ingresan los patrones y se determina que es como token
                patterns = new Dictionary<string, string>();
                patterns.Add("[a-z][a-z0-9]*", "Identificador");                        // Patrón para identificadores
                patterns.Add("[0-9]+", "Entero");                                       // Patrón para números enteros
                patterns.Add("verdadero|falso", "Lógico");                              // Patrón para valores lógicos
                patterns.Add("[0-9]+\\.[0-9]+", "Decimal");                             // Patrón para números decimales
                patterns.Add("[+\\-*/]", "Operador Aritmético");                        // Patrón para operadores aritméticos
                patterns.Add(";", "Delimitador");                                       // Patrón para el delimitador ;
                patterns.Add("\\b(entero|decimal|carácter|vacio|vBool|si|sino|mientras|por|regresar|cadena)\\b", "Palabra Reservada Básica"); // Patrón para palabras reservadas básicas
                patterns.Add("\\b(cIngreso|cSalida|\\n|usando|clase|público|privado|protegido|constante|estático)\\b", "Palabra Reservada Adicional"); // Patrón para palabras reservadas adicionales
                patterns.Add("[A-Z][a-z0-9]*", "Constante");                            // Patrón para constantes
                patterns.Add("(==|!=|<|>|<=|>=)", "Operador Relacional");               // Patrón para operadores relacionales
                patterns.Add("\".*?\"", "Cadena de Texto");                             // Patrón para cadenas de texto
                patterns.Add("[\\s\t\n]+", "Espacios, saltos de línea y tabuladores");  // Patrón para espacios, saltos de línea y tabuladores
            }

            
            public string Analizar(string input)
            {
                //El resultado sera concatenado 
                StringBuilder result = new StringBuilder();
              
                // Realiza un recorrido por cada patron y tipo lexico del diccionario
                foreach (KeyValuePair<string, string> pattern in patterns)
                {

                 
                    // Encuentra las coincidencias de los patrones con el texto que se ingreso
                    MatchCollection matches = Regex.Matches(input, pattern.Key);

                    // Si encuentra una coincidencia lo hace dentro de cada una de ellas recorriendolo
                    foreach (Match match in matches)
                    {
                        //Agrega al token "Lo que encontro" y su tipo de lexico al resultado
                        // Agrega el token (coincidencia) y su tipo léxico correspondiente al resultado
                        result.AppendLine($"Token: {match.Value}, Tipo: {pattern.Value}");
                    }
                }
                
                return result.ToString();
            }
        }
    }
}
