using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clClientes
    {
        //propriedades
        public string banco { get; set; }
        public int cliCodigo { get; set; }
        public string cliNome { get; set; }
        public string cliEndereco { get; set; }
        public string cliNumero { get; set; }
        public string cliBairro { get; set; }
        public string cliCidade { get; set; }
        public string cliEstado { get; set; }
        public string cliCEP { get; set; }
        public string cliCelular { get; set; }

        public void Gravar()
        {
            //variavel utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append(" INSERT INTO tbClientes");

            strQuery.Append(" ( ");

            strQuery.Append(" cliNome ");
            strQuery.Append(", cliEndereco ");
            strQuery.Append(", cliNumero ");
            strQuery.Append(", cliBairro ");
            strQuery.Append(", cliCidade ");
            strQuery.Append(", cliEstado ");
            strQuery.Append(", cliCEP ");
            strQuery.Append(", cliCelular ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");
            strQuery.Append(" '" + cliNome + "'");
            strQuery.Append(", '" + cliEndereco + "'");
            strQuery.Append(", '" + cliNumero + "'");
            strQuery.Append(", '" + cliBairro + "'");
            strQuery.Append(", N'" + cliCidade + "'");
            strQuery.Append(", '" + cliEstado + "'");
            strQuery.Append(", '" + cliCEP + "'");
            strQuery.Append(", '" + cliCelular + "'");

            strQuery.Append(" ); ");

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutarComando(strQuery.ToString());


        }

        public void Alterar()
        {
            StringBuilder strQuery = new StringBuilder();
            //montagem do update
            strQuery.Append(" UPDATE tbClientes");

            strQuery.Append(" SET ");

            strQuery.Append(" cliNome = '" + cliNome + "'");
            strQuery.Append(", cliEndereco = '" + cliEndereco + "'");
            strQuery.Append(", cliNumero = '" + cliNumero + "'");
            strQuery.Append(", cliBairro = '" + cliBairro + "'");
            strQuery.Append(", cliCidade = '" + cliCidade + "'");
            strQuery.Append(", cliEstado = '" + cliEstado + "'");
            strQuery.Append(", cliCEP = '" + cliCEP + "' ");
            strQuery.Append(", cliCelular = '" + cliCelular + "' ");

            strQuery.Append(" WHERE");

            strQuery.Append(" cliCodigo = " + cliCodigo);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutarComando(strQuery.ToString());
        }

        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbClientes ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" cliCodigo = " + cliCodigo);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutarComando(strQuery.ToString());
        }
    }
}
