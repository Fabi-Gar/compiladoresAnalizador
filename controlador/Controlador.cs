using compiladoresAnalizador.modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace compiladoresAnalizador.controlador
{
    internal class Controlador
    {
        AnalizadorLexico AnalizadorLexico;
        VistaPrincipal VistaAnalizador;

        public Controlador(AnalizadorLexico analizadorLexico, VistaPrincipal vistaAnalizador)
        {
            AnalizadorLexico = analizadorLexico;
            VistaAnalizador = vistaAnalizador;

            vistaAnalizador.btnAnalizar.Click += clickBoton;
            vistaAnalizador.FormClosing += vistaCerrada;

            vistaAnalizador.Show();
        }

        private void vistaCerrada(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void clickBoton(object sender, EventArgs e)
        {
            if (sender == VistaAnalizador.btnAnalizar)
            {
                // Limpiar resultados previos
                VistaAnalizador.lstTokens.Items.Clear();
                VistaAnalizador.txtErrores.Clear();

                // Obtener el código ingresado
                string codigo = VistaAnalizador.txtCodigo.Text;

                try
                {
                    // Realizar el análisis léxico
                    List<Token> tokens = AnalizadorLexico.Analizar(codigo);

                    // Mostrar los tokens en la lista
                    foreach (var token in tokens)
                    {
                        VistaAnalizador.lstTokens.Items.Add(token.ToString());
                    }

                    // Realizar el análisis sintáctico
                    var parser = new AnalizadorSintactico(tokens);
                    parser.Parse();
                    VistaAnalizador.txtErrores.Text = "La entrada es sintácticamente correcta.";
                }
                catch (Exception ex)
                {
                    VistaAnalizador.txtErrores.Text = $"Error: {ex.Message}";
                }
            }
        }
    }
}
