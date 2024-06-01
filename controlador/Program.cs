using System;
using System.Windows.Forms;
using compiladoresAnalizador.controlador;
using compiladoresAnalizador.modelo;

namespace compiladoresAnalizador
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var analizadorLexico = new AnalizadorLexico();
            var vistaPrincipal = new VistaPrincipal();
            var controlador = new Controlador(analizadorLexico, vistaPrincipal);

            Application.Run(vistaPrincipal);
        }
    }
}
