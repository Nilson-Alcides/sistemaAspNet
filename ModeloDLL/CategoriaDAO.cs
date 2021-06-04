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

    }
}
