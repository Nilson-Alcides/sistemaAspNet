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

            CodProduto =  numAleatorio.Next(3,9).ToString();            
            string idProduto = "P";
            idProduto = idProduto + CodProduto;
            int idCategoria = 9;

            try
            {
                string strInsert = string.Format("INSERT INTO PRODUTO(idProduto, idCategoria, nomeProd, marcaProd, quantidade, preco)" +
                   " values('{0}',{1},'{2}','{3}','{4}', '{5}'); SELECT LAST_INSERT_ID();",
                      idProduto, idCategoria, produto.nomeProd, produto.marcaProd, produto.quantidade, Convert.ToDecimal(produto.preco));
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
        //SELECT PRODUTOS
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "select * From produtos ";
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
    }
}
