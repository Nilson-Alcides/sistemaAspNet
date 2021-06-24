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
    public class LivroDAO
    {
        string retorno;
        string CodLivro = " ";
        

        private Banco db = new Banco();
        //INSERIR LIVRO
        public void Insert(Livro livro)
        {
            Random numAleatorio = new Random();
            

            CodLivro = numAleatorio.Next(100, 1000000).ToString();
            string idLivro = "L";
            idLivro = idLivro + CodLivro;
            
            try
            {
                string strInsert = string.Format("INSERT INTO LIVRO(idLivro,  isbn, titulo, descricao, capaLivro, paginas," +
                    " estoque, valorUnit, dataLanc,autor, editora,formato,categoria, idCategoria)" +
                   " values('{0}','{1}','{2}','{3}', '{4}',{5},{6},'{7}','{8}','{9}','{10}','{11}','{12}',{13}); SELECT LAST_INSERT_ID();",
                      idLivro, livro.isbn, livro.titulo, livro.descricao, livro.capaLivro, livro.paginas,
                      livro.estoque, Convert.ToDecimal(livro.valorUnit).ToString().Replace(",", "."), 
                      String.Format("{0:u}", livro.dataLanc), livro.autor, livro.editora, livro.formato,livro.categoria, livro.idCategoria);
                retorno = db.RetornaDado(strInsert);


            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro livro" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro livro" + ex.Message);
            }
        }
        public MySqlDataReader Select()
        {
            try
            {
                string strString = "select * From livro ";
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar livro" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar livro" + ex.Message);
            }
        }
        //SELECIONAR LIVRO POR ID
        public MySqlDataReader SelectId(string idLivro)
        {
            try
            {
                string strString = string.Format("select * From Livro where idLivro = '{0}'; ", idLivro);
                return db.RetornaComando(strString);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em selecionar Livro" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em selecionar Livro" + ex.Message);
            }
        }
        //ATUALIZAR LIVRO
        public void Update(Livro livro)
        {
            try
            {
                string strInsert = "UPDATE Livro SET ";
                strInsert += string.Format("titulo = '{0}',", livro.titulo);
                //  strInsert += string.Format("cpfCliente = '{0}',", produto.cpfCliente.Replace(".", string.Empty).Replace("-", string.Empty));
                strInsert += string.Format("isbn = '{0}',", livro.isbn);
                strInsert += string.Format("capaLivro = '{0}',", livro.capaLivro);
                strInsert += string.Format("descricao = '{0}',", livro.descricao);
                strInsert += string.Format("autor = '{0}',", livro.autor);
                strInsert += string.Format("editora = '{0}',", livro.editora);
                strInsert += string.Format("formato = '{0}',", livro.formato);
                strInsert += string.Format("categoria = '{0}',", livro.categoria);
                strInsert += string.Format("estoque = {0},", livro.estoque);
                strInsert += string.Format("paginas = {0},", livro.paginas);
                strInsert += string.Format("dataLanc = '{0:u}',",livro.dataLanc);                
                strInsert += string.Format("valorUnit = '{0}' ", Convert.ToDecimal(livro.valorUnit).ToString().Replace(",", "."));
                strInsert += string.Format(" where idLivro = '{0}' ;", livro.idLivro);
                db.ExecutaComando(strInsert);
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em atualizar livro" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em atualizar Produto" + ex.Message);
            }

        }
        public void Delete(Livro livro)
        {
            try
            {
                string strInsert = "DELETE from Livro ";
                strInsert += string.Format(" WHERE idLivro = '{0}' ", livro.idLivro);
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
