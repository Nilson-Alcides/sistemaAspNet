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
    public class ClienteDAO
    {
        private Banco db = new Banco();
        //INSERIR CLINETE
        public void Insert(Cliente cliente)
        {
            string retorno;
            try
            {
                string strInsert = string.Format("INSERT INTO CLIENTE(nomeCliente, cpfCliente, emailCliente, sexoCliente," +
                    "dataNascCliente, statusCliente) " +
                   " values('{0}','{1}','{2}','{3}','{4}','{5}'); SELECT LAST_INSERT_ID();",
                       cliente.nomeCliente, cliente.cpfCliente.Replace(".", string.Empty).Replace("-", string.Empty), cliente.emailCliente, cliente.sexoCliente,
                       String.Format("{0:u}", cliente.dataNascCliente), cliente.statusCliente);

                retorno =  db.RetornaDado(strInsert);

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
        //ATUALIZAR CLIENTE
        public void Update(Cliente cliente)
        {
            try
            {
                string strInsert = "UPDATE CLIENTE SET ";
                strInsert += string.Format("nomeCliente = '{0}',", cliente.nomeCliente);
                strInsert += string.Format("cpfCliente = '{0}',", cliente.cpfCliente);
                strInsert += string.Format("emailCliente = '{0}',", cliente.emailCliente);
                strInsert += string.Format("sexoCliente = '{0}',", cliente.sexoCliente);
                strInsert += string.Format("dataNascCliente = '{0}' ", cliente.dataNascCliente);
                strInsert += string.Format(" where idCliente = {0} ;", cliente.idCliente);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar cliente" + ex.Message);
            }

        }
        //SELECIONAR TODOS CLIENTE
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "select * From cliente ";
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
        //SELECIONAR CLIENTE POR ID
        public MySqlDataReader SelectId(int idCliente)
        {
            try
            {
                string strString = string.Format("select * From cliente where idCliente = {0}; ", idCliente);
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
        // EXCLUIR
        public void Delete(Cliente cliente)
        {
            try
            {
                string strInsert = "DELETE from cliente ";
                strInsert += string.Format(" WHERE idCliente = '{0}' ", cliente.idCliente);
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
