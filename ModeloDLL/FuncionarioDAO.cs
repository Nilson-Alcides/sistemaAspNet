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
                    " senhaFunc, nivelAcesso,logradouro, numero,complemento, bairro, CEP, cidade, estado, UF," +
                    " numTel1, numTel2, numTel3) " +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}',{10},'{11}'," +
                    " '{12}','{13}','{14}','{15}','{16}'); SELECT LAST_INSERT_ID();",
                       funcionario.nomeFunc, funcionario.cpfFunc.Replace(".", string.Empty).Replace("-", string.Empty), funcionario.emailFunc, funcionario.cargo,
                       funcionario.senhaFunc, funcionario.nivelAcesso, funcionario.logradouro, funcionario.numero,
                      funcionario.complemento, funcionario.bairro, funcionario.CEP, funcionario.cidade,
                      funcionario.estado, funcionario.UF, funcionario.numTel1, funcionario.numTel2, funcionario.numTel3);
                retorno = db.RetornaDado(strInsert);


                //string strInsertTel = string.Format("INSERT INTO TELEFONE(idFunc, numTel1, numTel2, numTel3) " +
                //   " values({0},'{1}',{2},{3});",
                //       retorno, funcionario.telefone.numTel1, funcionario.telefone.numTel2, funcionario.telefone.numTel3);
                //db.ExecutaComando(strInsertTel);

                //string strInsertEnd = string.Format("INSERT INTO ENDERECO(idFunc, logradouro, numero," +
                //    "complemento, bairro, CEP, cidade, estado, UF) " +
                //    " values({0},'{1}',{2},'{3}','{4}',{5},'{6}','{7}','{8}');",
                //      retorno, funcionario.endereco.logradouro, funcionario.endereco.numero,
                //      funcionario.endereco.complemento, funcionario.endereco.bairro, funcionario.endereco.CEP, funcionario.endereco.cidade,
                //      funcionario.endereco.estado, funcionario.endereco.UF);
                //db.ExecutaComando(strInsertEnd);

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
        public Funcionario TestarUsuario(Funcionario user)
        {
            string strInsert = "SELECT * FROM funcionario";
            strInsert += string.Format(" WHERE ");
            strInsert += string.Format("emailFunc = '{0}' ", user.emailFunc);
            strInsert += string.Format(" AND ");
            strInsert += string.Format("senhaFunc = '{0}'; ", user.senhaFunc);


            MySqlDataReader teste;

            teste = db.RetornaComando(strInsert);

            if (teste.HasRows)
            {
                while (teste.Read())
                {
                    Funcionario dto = new Funcionario();
                    {
                        dto.emailFunc = Convert.ToString(teste["emailFunc"]);
                        dto.senhaFunc = Convert.ToString(teste["senhaFunc"]);
                    }
                }
            }

            else
            {
                user.emailFunc = null;
                user.senhaFunc = null;
            }
            return user;

        }

        //Seleciona funcionario pro ID
        public MySqlDataReader SelectId(int id)
        {
            try
            {
                string strString = string.Format("select * From funcionario where idFunc = {0}; ", id);
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
        //ATUALIZAR FUNCIONARIO
        public void Update(Funcionario  funcionario)
        {         
            try
            {
                string strInsert = "UPDATE FUNCIONARIO SET ";
                strInsert += string.Format("nomeFunc = '{0}',", funcionario.nomeFunc);
                strInsert += string.Format("cpfFunc = '{0}',", funcionario.cpfFunc.Replace(".", string.Empty).Replace("-", string.Empty));
                strInsert += string.Format("emailFunc = '{0}',", funcionario.emailFunc);
                strInsert += string.Format("cargo = '{0}',", funcionario.cargo);                
                strInsert += string.Format("senhaFunc = '{0}', ", funcionario.senhaFunc);
                strInsert += string.Format("nivelAcesso = '{0}', ", funcionario.nivelAcesso);

                strInsert += string.Format("logradouro = '{0}', ", funcionario.logradouro);
                strInsert += string.Format("numero = '{0}', ", funcionario.numero);
                strInsert += string.Format("complemento = '{0}', ", funcionario.complemento);
                strInsert += string.Format("bairro = '{0}', ", funcionario.bairro);
                strInsert += string.Format("CEP = '{0}', ", funcionario.CEP);
                strInsert += string.Format("cidade = '{0}', ", funcionario.cidade);
                strInsert += string.Format("estado = '{0}', ", funcionario.estado);
                strInsert += string.Format("UF = '{0}', ", funcionario.UF);

                strInsert += string.Format("numTel1 = '{0}', ", funcionario.numTel1);
                strInsert += string.Format("numTel2 = '{0}',", funcionario.numTel2);
                strInsert += string.Format("numTel3 = '{0}' ", funcionario.numTel3);

                strInsert += string.Format(" where idFunc = {0} ;", funcionario.idFunc);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar funcionario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar funcionario" + ex.Message);
            }

        }
        // EXCLUIR
        public void Delete(Funcionario funcionario)
        {
            try
            {
                string strInsertTel = "DELETE from telefone ";
                strInsertTel += string.Format(" WHERE idFunc = '{0}' ", funcionario.idFunc);
                db.ExecutaComando(strInsertTel);

                string strInsertEnd = "DELETE from endereco ";
                strInsertEnd += string.Format(" WHERE idFunc = '{0}' ", funcionario.idFunc);
                db.ExecutaComando(strInsertEnd);

                string strInsert = "DELETE from funcionario ";
                strInsert += string.Format(" WHERE idFunc = '{0}' ", funcionario.idFunc);
                db.ExecutaComando(strInsert);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar EXCLUIR" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em EXCLUIR cliente" + ex.Message);
            }
        }

       

    }
}
