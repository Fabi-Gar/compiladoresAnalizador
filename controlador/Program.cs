using compiladoresAnalizador.controlador;
using compiladoresAnalizador.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiladoresAnalizador
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VistaPrincipal vistAnalizador = new VistaPrincipal();
            modeloAnalizadorLexico modeloLexico= new modeloAnalizadorLexico();

            Controlador programaControl = new Controlador(modeloLexico,vistAnalizador);

            
            Application.Run();
        }
    }
}
