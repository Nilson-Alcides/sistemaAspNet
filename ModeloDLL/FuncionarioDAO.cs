using BancoADO;
using Dominios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDLL
{
    public class FuncionarioDAO
    {
        private Banco db = new Banco();
        string retorno;
        //INSERIR FUNCIONARIO
        public void Insert(Funcionario funcionario)
        {
            
            try
            {
                string strInsert = string.Format("INSERT INTO FUNCIONARIO(nomeFunc, cpfFunc, emailFunc, cargo," +
                    "senhaFunc, nivelAcesso) " +
                   " values('{0}','{1}','{2}','{3}','{4}','{5}'); SELECT LAST_INSERT_ID();",
                       funcionario.nomeFunc, funcionario.cpfFunc.Replace(".", string.Empty).Replace("-", string.Empty), funcionario.emailFunc, funcionario.cargo,
                       funcionario.senhaFunc, funcionario.nivelAcesso);
                retorno = db.RetornaDado(strInsert);

               
                string strInsertTel = string.Format("INSERT INTO TELEFONE(idFunc, TipoTelefone, dddTel, numTelefone) " +
                   " values({0},'{1}',{2},{3});",
                       retorno, funcionario.telefone.TipoTelefone, funcionario.telefone.dddTelefone, funcionario.telefone.numeroTelefone);

                db.ExecutaComando(strInsertTel);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }
            
        }
       
        //Seleciona todos funcionario
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "select * From funcionario ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar funcionario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar funcionario" + ex.Message);
            }

        }
        //Seleciona funcionario pro ID
        public MySqlDataReader SelectId(int id)
        {
            try
            {
                string strString = string.Format("select * From cliente where codigo_id_fun = {0}; ", id);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar cliente" + ex.Message);
            }
        }

    }
}
