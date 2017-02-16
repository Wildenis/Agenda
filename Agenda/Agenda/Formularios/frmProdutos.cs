using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Agenda.Formularios
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {

        }

        private void tstSalvar_Click(object sender, EventArgs e)
        {
            decimal preco;
            //pergunta para o usuário se ele confirma a inclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clProdutos clProdutos = new clProdutos();

            //carrega as propriedades
            clProdutos.proDescricao = txtDescricao.Text;
            clProdutos.proMarca = txtMarca.Text;
            //clProdutos.proDataCadastro = dtpDataCadastro.Text;

            //tratamento de campo numérico
            if (decimal.TryParse(txtPreco.Text, out preco))
            {
                clProdutos.proPreco = Convert.ToString(preco);
            } else
            {
                clProdutos.proPreco = "0";
            }

            //tratamento do campo data
            clProdutos.proDataCadastro = string.Format("{0:yyyy-MM-dd}", dtpDataCadastro.Value);

            //variável com a string de conexão com o banco de dados
            clProdutos.banco = Agenda.Properties.Settings.Default.conexaoDB;

            //chama o método gravar
            clProdutos.Gravar();

            MessageBox.Show(clProdutos.strQueryResult.ToString());

            //mensagem de confirmação de inclusão
            MessageBox.Show("Cliente incluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
