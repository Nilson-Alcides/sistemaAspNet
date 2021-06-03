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
        string retorno;

        private Banco db = new Banco();
        //INSERIR CLINETE
        public void Insert(Cliente cliente)
        {
            
            try
            {
                string strInsert = string.Format("INSERT INTO CLIENTE(nomeCliente, cpfCliente, emailCliente, sexoCliente," +
                    "dataNascCliente, statusCliente) " +
                   " values('{0}','{1}','{2}','{3}','{4}','{5}'); SELECT LAST_INSERT_ID();",
                       cliente.nomeCliente, cliente.cpfCliente.Replace(".", string.Empty).Replace("-", string.Empty), cliente.emailCliente, cliente.sexoCliente,
                       String.Format("{0:u}", cliente.dataNascCliente), cliente.statusCliente);
                retorno =  db.RetornaDado(strInsert);

                string strInsertTel = string.Format("INSERT INTO TELEFONE(idCliente, numTel1, numTel2, numTel3) " +
                   " values({0},'{1}',{2},{3});",
                       retorno, cliente.telefone.numTel1, cliente.telefone.numTel2, cliente.telefone.numTel3);
                db.ExecutaComando(strInsertTel);

                string strInsertEnd = string.Format("INSERT INTO ENDERECO(idCliente, logradouro, numero," +
                    "complemento, bairro, CEP, cidade, estado, UF) " +                    
                    " values({0},'{1}',{2},'{3}','{4}',{5},'{6}','{7}','{8}');",
                      retorno, cliente.endereco.logradouro, cliente.endereco.numero,
                      cliente.endereco.complemento, cliente.endereco.bairro, cliente.endereco.CEP, cliente.endereco.cidade,
                      cliente.endereco.estado, cliente.endereco.UF);
                db.ExecutaComando(strInsertEnd);

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
                strInsert += string.Format("cpfCliente = '{0}',", cliente.cpfCliente.Replace(".", string.Empty).Replace("-", string.Empty));
                strInsert += string.Format("emailCliente = '{0}',", cliente.emailCliente);
                strInsert += string.Format("sexoCliente = '{0}',", cliente.sexoCliente);
                strInsert += string.Format("dataNascCliente = '{0:u}', ", cliente.dataNascCliente);
                strInsert += string.Format("statusCliente = '{0}' ", cliente.statusCliente);
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
        //SELECIONAR TODOS CLIENTE
        public MySqlDataReader SelectView()
        {
            try
            {
                string strString = "select * From vwCliente ";
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
                string strInsertTel = "DELETE from telefone ";
                strInsertTel += string.Format(" WHERE idCliente = '{0}' ", cliente.idCliente);
                db.ExecutaComando(strInsertTel);

                string strInsertEnd = "DELETE from endereco ";
                strInsertEnd += string.Format(" WHERE idCliente = '{0}' ", cliente.idCliente);
                db.ExecutaComando(strInsertEnd);

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
