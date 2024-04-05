using compiladoresAnalizador.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiladoresAnalizador.controlador
{
    internal class Controlador
    {
        modeloAnalizadorLexico AnalizadorLexico;
        VistaPrincipal VistaAnalizador;

        public Controlador(modeloAnalizadorLexico analizadorLexico, VistaPrincipal vistaAnalizador)
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
            if (sender ==VistaAnalizador.btnAnalizar)
            {
                // Crear una instancia de AnalizadorLexico
                modeloAnalizadorLexico.AnalizadorLexico analizador = new modeloAnalizadorLexico.AnalizadorLexico();

                // Obtener el código fuente ingresado por el usuario desde la vista principal
                string codigoFuente = VistaAnalizador.txtCodigo.Text;

                // Realizar el análisis léxico utilizando el analizador léxico
                string resultadoAnalisis = analizador.Analizar(codigoFuente);

                // Mostrar el resultado del análisis léxico en el TextBox de respuesta de la vista principal
                VistaAnalizador.txtRespuesta.Text = resultadoAnalisis;
            }


        }
    }
}
