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
    public class AutorDAO
    {
        private Banco db = new Banco();
        string retorno;

        //INSERIR AUTOR
        public void Insert(Autor autor)
        {

            try
            {
                string strInsert = string.Format("INSERT INTO AUTOR(nomeAutor) " +
                   " values('{0}' ); SELECT LAST_INSERT_ID();",
                       autor.nomeAutor);
                retorno = db.RetornaDado(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro autor" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro autor" + ex.Message);
            }

        }
        //SELECIONAR TODAS AUTOR
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "SELECT * FROM AUTOR ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar autor" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar autor" + ex.Message);
            }
        }
        //SELECIONAR AUTOR POR ID
        public MySqlDataReader SelectId(int idAutor)
        {
            try
            {
                string strString = string.Format("select * From autor where idAutor = {0}; ", idAutor);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar autor" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar autor" + ex.Message);
            }
        }
        //UPDATE EDITORA
        public void Update(Autor autor)
        {
            try
            {
                string strInsert = "UPDATE AUTOR SET ";
                strInsert += string.Format("nomeAutor = '{0}'", autor.nomeAutor);
                strInsert += string.Format(" where idAutor = {0} ;", autor.idAutor);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar autor" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar autor" + ex.Message);
            }

        }
        //DELETAR AUTOR
        public void Delete(Autor autor)
        {
            try
            {
                string strInsert = "DELETE from autor ";
                strInsert += string.Format(" WHERE idAutor = '{0}' ", autor.idAutor);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar EXCLUIR" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em EXCLUIR autor" + ex.Message);
            }
        }
    }
}
