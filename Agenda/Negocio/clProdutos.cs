﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clProdutos
    {
        public string strQueryResult;

        //propriedades
        public string banco { get; set; }
        public int proCodigo { get; set; }
        public string proDescricao { get; set; }
        public string proMarca { get; set; }
        public string proPreco { get; set; }
        public string proDataCadastro { get; set; }

        public void Gravar()
        {
            //variavel utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append(" INSERT INTO tbProdutos");

            strQuery.Append(" ( ");

            strQuery.Append(" proDescricao ");
            strQuery.Append(", proMarca ");
            strQuery.Append(", proPreco ");
            strQuery.Append(", proDataCadastro ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");
            strQuery.Append(" '" + proDescricao + "'");
            strQuery.Append(", '" + proMarca + "'");
            strQuery.Append(", '" + proPreco.Replace(",", ".") + "'");
            //strQuery.Append(", '" + proPreco + "'");
            strQuery.Append(", '" + proDataCadastro + "'");

            strQuery.Append(" ); ");

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutarComando(strQuery.ToString());
            strQueryResult = strQuery.ToString();
        }
    }
}
