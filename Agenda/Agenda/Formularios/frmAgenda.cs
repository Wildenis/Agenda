using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace CadastroDeCliente
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            PesquisarCEP(mskCEP.Text);
        }

        private void frmAgenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Trocar o ENTER pelo TAB.
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstSalvar_Click(object sender, EventArgs e)
        {
            //validação do conteúdo do campo NOME
            if (txtNome.Text == "")
            {
                errErro.SetError(lblNome, "Campo obrigatório.");
                return;
            }
            else
            {
                errErro.SetError(lblNome, "");
            }
            //string ConexaoDATABASE = Properties.Settings.Default.conexaoDB;
            string ConexaoDATABASE = Agenda.Properties.Settings.Default.conexaoDB;
            //Negocio.clAcessoDB();
        }

        private void PesquisarCEP(string CEP)
        {
            //Pesquisa de CEP
            DataSet ds = new DataSet();

            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);
            ds.ReadXml(xml);
            if (ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep completo" || ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep único")
            {
                txtEndereco.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString() + " " + ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                cboEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                txtNumeroCasa.Focus();
            }
            else
            {
                MessageBox.Show("CEP não Encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {

        }
    }   
}
