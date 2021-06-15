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
    public class ProdutoDAO
    {
        string retorno;
        string CodProduto = " ";
        

        private Banco db = new Banco();
        //INSERIR PRODUTOS
        public void Insert(Produto produto)
        {
            Random numAleatorio = new Random();

            CodProduto =  numAleatorio.Next(100, 1000000).ToString();            
            string idProduto = "P";
            idProduto = idProduto + CodProduto;
            

            try
            {
                string strInsert = string.Format("INSERT INTO PRODUTO(idProduto,  nomeProd, marcaProd, quantidade, preco)" +
                   " values('{0}','{1}','{2}','{3}', '{4}'); SELECT LAST_INSERT_ID();",
                      idProduto, produto.nomeProd, produto.marcaProd, produto.quantidade, Convert.ToDecimal(produto.preco));
                retorno = db.RetornaDado(strInsert);
                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro Produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro Produto" + ex.Message);
            }
        }
        //ATUALIZAR PRODUTO
        public void Update(Produto produto)
        {
            try
            {
                string strInsert = "UPDATE Produto SET ";
                strInsert += string.Format("nomeProd = '{0}',", produto.nomeProd);
              //  strInsert += string.Format("cpfCliente = '{0}',", produto.cpfCliente.Replace(".", string.Empty).Replace("-", string.Empty));
                strInsert += string.Format("marcaProd = '{0}',", produto.marcaProd);
                strInsert += string.Format("quantidade = '{0}',", produto.quantidade);
                strInsert += string.Format("dataNascCliente = '{0}' ", produto.preco);                
                strInsert += string.Format(" where idProduto = {0} ;", produto.idProduto);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar Produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar Produto" + ex.Message);
            }

        }
        //SELECT PRODUTOS
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "select * From produto ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar produto" + ex.Message);
            }
        }
        //SELECIONAR PRODUTOD POR ID
        public MySqlDataReader SelectId(string idProduto)
        {
            try
            {
                string strString = string.Format("select * From Produto where idProduto = '{0}'; ", idProduto);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar Produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar Produto" + ex.Message);
            }
        }
    }
}
