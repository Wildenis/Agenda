using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda.Formularios
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnFrmAgenda_Click(object sender, EventArgs e)
        {
            Application.Run(new CadastroDeCliente.frmAgenda());
        }

        private void btnFrmProdutos_Click(object sender, EventArgs e)
        {
            Application.Run(new Agenda.Formularios.frmProdutos());
        }
    }
}
