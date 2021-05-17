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

        //INSERIR CLINETE
        public void Insert(Funcionario funcionario)
        {
            try
            {
                string strInsert = string.Format("INSERT INTO FUNCIONARIo(nomeFunc, cpfFunc, emailFunc, cargo," +
                    "senhaFunc, nivelAcesso) " +
                   " values('{0}','{1}','{2}','{3}','{4}','{5}');",
                       funcionario.nomeFunc, funcionario.cpfFunc, funcionario.emailFunc, funcionario.cargo,
                       funcionario.senhaFunc, funcionario.nivelAcesso);
                db.ExecutaComando(strInsert);

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
