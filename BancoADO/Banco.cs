using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace BancoADO
{
    public class Banco : IDisposable
    {
        private readonly MySqlConnection conexao;
        public Banco()
        {
            try
            {
                conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
                conexao.Open();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco de acesso" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação" + ex.Message);
            }

        }

        public void ExecutaComando(string strQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();

        }
        public MySqlDataReader RetornaComando(string strQuery)
        {
            var vComando = new MySqlCommand(strQuery, conexao);
            return vComando.ExecuteReader();
        }
        public string RetornaDado(string StrQuery)
        {
            var vComando = new MySqlCommand(StrQuery, conexao);
            return vComando.ExecuteScalar().ToString();
        }
        //public string RetornaDado(string StrQuery)
        //{
        //    string result;
        //    var vComando = new MySqlCommand(StrQuery, conexao);
        //    result = (string)vComando.ExecuteScalar();
        //    if (result == null)
        //    {
        //        result = "";
        //    }
        //    return result;
        //}

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}
