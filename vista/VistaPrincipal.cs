using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiladoresAnalizador
{
    public partial class VistaPrincipal : Form
    {
        public VistaPrincipal()
        {
            InitializeComponent();

            Controls.Add(txtCodigo);
            Controls.Add(btnAnalizar);
            Controls.Add(lstTokens);
            Controls.Add(txtErrores);
        }
    }
}
