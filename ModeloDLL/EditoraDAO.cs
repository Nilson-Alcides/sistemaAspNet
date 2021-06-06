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
    public class EditoraDAO
    {
        private Banco db = new Banco();
        string retorno;

        //INSERIR EDITORA
        public void Insert(Editora editira)
        {

            try
            {
                string strInsert = string.Format("INSERT INTO EDITORA(nomeEditora) " +
                   " values('{0}' ); SELECT LAST_INSERT_ID();",
                       editira.nomeEditora);
                retorno = db.RetornaDado(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro Editora" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro Editora" + ex.Message);
            }

        }
        //SELECIONAR TODAS EDITORAS
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "SELECT * FROM EDITORA ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar editora" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar editora" + ex.Message);
            }
        }
        //SELECIONAR EDITORA POR ID
        public MySqlDataReader SelectId(int idEditora)
        {
            try
            {
                string strString = string.Format("select * From editora where idEditora = {0}; ", idEditora);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar editora" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar editora" + ex.Message);
            }
        }
        //UPDATE EDITORA
        public void Update(Editora editora)
        {
            try
            {
                string strInsert = "UPDATE EDITORA SET ";
                strInsert += string.Format("nomeEditora = '{0}'", editora.nomeEditora);                
                strInsert += string.Format(" where idEditora = {0} ;", editora.idEditora);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar editora" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar editora" + ex.Message);
            }

        }
        //DELETAR EDITORA
        public void Delete(Editora editora)
        {
            try
            {
                string strInsert = "DELETE from editora ";
                strInsert += string.Format(" WHERE idEditora = '{0}' ", editora.idEditora);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar EXCLUIR" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em EXCLUIR editora" + ex.Message);
            }
        }
    }
}
