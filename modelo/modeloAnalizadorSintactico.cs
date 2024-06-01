using System;
using System.Collections.Generic;

namespace compiladoresAnalizador.modelo
{
    internal class AnalizadorSintactico
    {
        private List<Token> tokens;
        private int currentIndex;

        public AnalizadorSintactico(List<Token> tokens)
        {
            this.tokens = tokens;
            this.currentIndex = 0;
        }

        private Token CurrentToken => tokens[currentIndex];

        private void Avanzar()
        {
            currentIndex++;
        }

        //muestra de los errores

        private void Esperar(string tipoEsperado)
        {
            if (CurrentToken.Type != tipoEsperado)
            {
                throw new Exception($"Se esperaba {tipoEsperado} pero se encontró {CurrentToken.Type} en la posición {currentIndex}");
            }
            Avanzar();
        }

        //obtiene el tipo de dato que se esta utilizando
        public void Parse()
        {
            while (currentIndex < tokens.Count)
            {
                if (CurrentToken.Type == "Palabra Reservada")
                {
                    switch (CurrentToken.Value)
                    {
                        case "entero":
                        case "decimal":
                        case "caracter":
                        case "vBool":
                            AnalizarDeclaracionVariable();
                            break;
                        case "si":
                            AnalizarEstructuraCondicional();
                            break;
                        case "mientras":
                            AnalizarEstructuraIterativa();
                            break;
                        case "público":
                            AnalizarDeclaracionFuncion();
                            break;
                        default:
                            throw new Exception($"Palabra reservada inesperada en la posición {currentIndex}: {CurrentToken.Value}");
                    }
                }
                else if (CurrentToken.Type == "Identificador")
                {
                    Avanzar(); // Procesar identificador
                }
                else
                {
                    throw new Exception($"Estructura inesperada en la posición {currentIndex}: {CurrentToken.Value}");
                }
            }
        }
        

        //Estructura de la declaracion
        private void AnalizarDeclaracionVariable()
        {
            Esperar("Palabra Reservada"); // Tipo de dato
            Esperar("Identificador"); // Nombre de la variable
            while (CurrentToken.Type == "Delimitador" && CurrentToken.Value == ",")
            {
                Avanzar(); 
                Esperar("Identificador");
            }
            if (CurrentToken.Type != "Delimitador" || CurrentToken.Value != ";")
            {
                throw new Exception($"Se esperaba un punto y coma ';' al final de la declaración en la posición {currentIndex}");
            }
            Avanzar(); 
        }

        //estructura condicional si sino
        private void AnalizarEstructuraCondicional()
        {
            Esperar("Palabra Reservada"); //SI
            Esperar("Paréntesis de Apertura");
         
            while (CurrentToken.Type != "Paréntesis de Cierre")
            {
                Avanzar();
            }
            Esperar("Paréntesis de Cierre");
            Esperar("Llave de Apertura");
            
            //analiza el bloque de codigo dentro de la estructura
            while (CurrentToken.Type != "Llave de Cierre")
            {
                AnalizarInstruccion();
            }
            Esperar("Llave de Cierre");

            // Analizar el bloque "sino"
            if (currentIndex < tokens.Count && CurrentToken.Type == "Palabra Reservada" && CurrentToken.Value == "sino")
            {
                Avanzar(); 
                Esperar("Llave de Apertura");
                while (CurrentToken.Type != "Llave de Cierre")
                {
                    AnalizarInstruccion(); 
                }
                Esperar("Llave de Cierre");
            }
        }


        //Estructura Mientras
        private void AnalizarEstructuraIterativa()
        {
            Esperar("Palabra Reservada"); //Se espera la palabra reservada Mientras
            Esperar("Paréntesis de Apertura");
            
            while (CurrentToken.Type != "Paréntesis de Cierre")
            {
                Avanzar();
            }
            Esperar("Paréntesis de Cierre");
            Esperar("Llave de Apertura");
            
            while (CurrentToken.Type != "Llave de Cierre")
            {
                AnalizarInstruccion(); // Analiza el codigo dentro del bloque
            }
            Esperar("Llave de Cierre");
        }

        private void AnalizarDeclaracionFuncion()
        {
            Esperar("Palabra Reservada"); //tipo publico,etc
            Esperar("Palabra Reservada"); // el tipo de dato que vamos a utilizar
            Esperar("Identificador");
            Esperar("Paréntesis de Apertura");

          
            if (CurrentToken.Type != "Paréntesis de Cierre")
            {
                do
                {
                    Esperar("Palabra Reservada"); 
                    Esperar("Identificador"); 
                    if (CurrentToken.Type == "Delimitador" && CurrentToken.Value == ",")
                    {
                        Avanzar(); 
                    }
                    else if (CurrentToken.Type != "Paréntesis de Cierre")
                    {
                        throw new Exception($"Estructura no completada {currentIndex}");
                    }
                } while (CurrentToken.Type == "Delimitador" && CurrentToken.Value == ",");
            }

            Esperar("Paréntesis de Cierre");
            Esperar("Llave de Apertura");

           
            while (CurrentToken.Type != "Llave de Cierre")
            {
                AnalizarInstruccion(); 
            }

            Esperar("Llave de Cierre");
        }

        private void AnalizarInstruccion()
        {
            if (CurrentToken.Type == "Palabra Reservada")
            {
                switch (CurrentToken.Value)
                {
                    case "entero":
                    case "decimal":
                    case "caracter":
                    case "vBool":
                        AnalizarDeclaracionVariable();
                        break;
                    case "si":
                        AnalizarEstructuraCondicional();
                        break;
                    case "mientras":
                        AnalizarEstructuraIterativa();
                        break;
                    case "regresar":
                        AnalizarRetorno();
                        break;
                    default:
                        throw new Exception($"Palabra reservada inesperada en la posición {currentIndex}: {CurrentToken.Value}");
                }
            }
            else if (CurrentToken.Type == "Identificador")
            {
                Avanzar(); 
                if (CurrentToken.Type == "Operador Asignación")
                {
                    Avanzar();
                   
                    while (CurrentToken.Type != "Delimitador" || CurrentToken.Value != ";")
                    {
                        Avanzar();
                    }
                    Esperar("Delimitador"); 
                }
                else
                {
                    throw new Exception($"Error de sintaxis en la posición {currentIndex}: se esperaba un operador de asignación o una llamada a función");
                }
            }
            else
            {
                throw new Exception($"Instrucción inesperada en la posición {currentIndex}: {CurrentToken.Value}");
            }
        }

        //Funcion retorno
        private void AnalizarRetorno()
        {
            Esperar("Palabra Reservada");
          
            while (CurrentToken.Type != "Delimitador" || CurrentToken.Value != ";")
            {
                Avanzar();
            }
            Esperar("Delimitador"); 
        }
    }
}
