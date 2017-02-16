using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clAcessoDB
    {
        //variável para receber a string de conexao
        public string vConexao = "";

        //método responsável por abrir a conexão com o banco de dados
        public SqlConnection AbreBanco()
        {
            //Abre a conexão com a banco de dados
            SqlConnection conn = new SqlConnection(vConexao);
            conn.Open();
            return conn;
        }

        //método responsável por fechar a conexão com o banco de dados
        public void FechaBanco(SqlConnection conn)
        {
            //fecha a conexão com o banco de dados
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        //método responsavel por executar comandos (INSERT, UPDATE, DELETE) no banco de dados.
        public void ExecutarComando(string strQuery)
        {
            //cria o objeto de conexao
            SqlConnection conn = new SqlConnection();
            try
            {
                //abre a conexao com o banco de dados
                conn = AbreBanco();

                //cria o objeto de comando
                SqlCommand cmdComando = new SqlCommand();
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = conn;

                //Passa os valores de query SQL, tipo do comando, conexao e executa o comando
                cmdComando.ExecuteNonQuery();
            }
            //tratamento de execessoes
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                //em caso de erro ou não, o finally é executado para fechar a conexao com o banco de dados
                FechaBanco(conn);
            }
        }

        //DataSet é utilizado para retornar um volume grande de registro utilizado principalmente para o componente datagridview
        public DataSet RetornaDataSet(string strQuery)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                //Abre a conexao com o banco de dados
                conn = AbreBanco();
                //Cria o objeto de comando
                SqlCommand cmdComando = new SqlCommand();
                //passa os valores da query SQL, tipo do comando, conexao e executa o comando
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = conn;
                //declara um dataadapter
                SqlDataAdapter daAdaptador = new SqlDataAdapter();
                //declara um dataset
                DataSet dsDataSet = new DataSet();
                //passa o comando a ser executado pelo dataadapter
                daAdaptador.SelectCommand = cmdComando;
                //O dataadapter faz a conexao com o banco de dados, carrega o dataset e fecha a conexao
                daAdaptador.Fill(dsDataSet);
                //retorna o dataset carregado
                return dsDataSet;
                //tratamento de excessoes
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                //em caso de erro ou não, o finally
                //é executado para fechar a conexão com o banco de dados
                FechaBanco(conn);
            }
        }
    }
}
