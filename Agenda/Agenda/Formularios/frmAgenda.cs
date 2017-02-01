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
            using (SqlConnection con = new SqlConnection("Server=AME0510093W10-1\\SQLEXPRESS;Database=db_Agenda;Trusted_Connection=Yes;"))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_DadosAgenda (NOME, CEP, ENDERECO, NUMEROCASA, BAIRRO, CIDADE, ESTADO, CELULAR) VALUES (@NOME, @CEP, @ENDERECO, @NUMEROCASA, @BAIRRO, @CIDADE, @ESTADO, @CELULAR)", con))
                {
                    cmd.Parameters.AddWithValue("NOME", txtNome.Text);
                    cmd.Parameters.AddWithValue("CEP", mskCEP.Text);
                    cmd.Parameters.AddWithValue("ENDERECO", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("NUMEROCASA", txtNumeroCasa.Text);
                    cmd.Parameters.AddWithValue("BAIRRO", txtBairro.Text);
                    cmd.Parameters.AddWithValue("CIDADE", txtCidade.Text);
                    cmd.Parameters.AddWithValue("ESTADO", cboEstado.Text);
                    cmd.Parameters.AddWithValue("CELULAR", mskCelular.Text);
                    try
                    {
                        con.Open();
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                            lblMensagem.Visible = true;
                            lblMensagem.Text = "Conta cadastrada com sucesso!";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensagem.Text = "Erro ao cadastrar conta.\n" + ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
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
    }   
}
