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
    public class CategoriaDAO
    {
        private Banco db = new Banco();
        string retorno;
        
        //INSERIR CATEGORIA
        public void Insert(Categoria categoria)
        {

            try
            {
                string strInsert = string.Format("INSERT INTO CATEGORIA(nomeCategoria, tipoProduto) " +
                   " values('{0}','{1}' ); SELECT LAST_INSERT_ID();",
                       categoria.nomeCategoria, categoria.tipoCategoria ); 
                retorno = db.RetornaDado(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro Categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro Categoria" + ex.Message);
            }

        }
        //SELECIONAR TODAS CATEGORIAS
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "SELECT * FROM CATEGORIA ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar categoria" + ex.Message);
            }
        }
        //SELECIONAR CATEGORIA POR ID
        public MySqlDataReader SelectId(int idCategoria)
        {
            try
            {
                string strString = string.Format("select * From categoria where idCategoria = {0}; ", idCategoria);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar categoria" + ex.Message);
            }
        }
        //UPDATE CATEGORIA
        public void Update(Categoria categoria)
        {
            try
            {
                string strInsert = "UPDATE CATEGORIA SET ";
                strInsert += string.Format("nomeCategoria = '{0}',", categoria.nomeCategoria);
                strInsert += string.Format("tipoProduto = '{0}'", categoria.tipoCategoria);              
                strInsert += string.Format(" where idCategoria = {0} ;", categoria.idCategoria);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar categoria" + ex.Message);
            }

        }
        public void Delete(Categoria categoria)
        {
            try
            {               
                string strInsert = "DELETE from Categoria ";
                strInsert += string.Format(" WHERE idCategoria = '{0}' ", categoria.idCategoria);
                db.ExecutaComando(strInsert);
               
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar EXCLUIR" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em EXCLUIR Categoria" + ex.Message);
            }
        }
        public List<Categoria> SelectCategoria()
        {

            string strQuery = string.Format("SELECT * FROM Categoria");
            MySqlDataReader myReader = db.RetornaComando(strQuery);
            var ListCategoria = new List<Categoria>();
            while (myReader.Read())
            {
                var tempCategoria = new Categoria();
                tempCategoria.idCategoria = int.Parse(myReader["idCategoria"].ToString());
                tempCategoria.nomeCategoria = myReader["nomeCategoria"].ToString();
                ListCategoria.Add(tempCategoria);
            }
            myReader.Close();
            return ListCategoria;
        }
    }
}
