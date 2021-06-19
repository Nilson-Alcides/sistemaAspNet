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
    public class FormatoLivroDAO
    {
        private Banco db = new Banco();
        string retorno;

        //INSERIR FORMATO
        public void Insert(FormatoLivro FormatoLivro)
        {
            try
            {
                string strInsert = string.Format("INSERT INTO formatolivro(descricao_for) " +
                   " values('{0}' ); SELECT LAST_INSERT_ID();",
                       FormatoLivro.descricao_for);
                retorno = db.RetornaDado(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro formato" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro formato" + ex.Message);
            }

        }
        //SELECIONAR TODAS FORMATO
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "SELECT * FROM formatolivro ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar formato" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar formato" + ex.Message);
            }
        }
        //SELECIONAR FORMATO POR ID
        public MySqlDataReader SelectId(int idFormato)
        {
            try
            {
                string strString = string.Format("select * From formatolivro where idFormato = {0}; ", idFormato);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar Formato" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar Formato" + ex.Message);
            }
        }
        //UPDATE FORMATO
        public void Update(FormatoLivro formatoLivro)
        {
            try
            {
                string strInsert = "UPDATE formatoLivro SET ";
                strInsert += string.Format("descricao_for = '{0}'", formatoLivro.descricao_for);
                strInsert += string.Format(" where idFormato = {0} ;", formatoLivro.idFormato);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar Formato" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar Formato" + ex.Message);
            }

        }
        //DELETAR AUTOR
        public void Delete(FormatoLivro formatoLivro)
        {
            try
            {
                string strInsert = "DELETE from formatoLivro ";
                strInsert += string.Format(" WHERE idFormato = '{0}' ", formatoLivro.idFormato);
                db.ExecutaComando(strInsert);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar EXCLUIR" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em EXCLUIR Formato" + ex.Message);
            }
        }
    }
}
