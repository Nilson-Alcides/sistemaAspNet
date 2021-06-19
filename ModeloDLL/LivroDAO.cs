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
                    " estoque, valorUnit, dataLanc )" +
                   " values('{0}','{1}','{2}','{3}', '{4}',{5},{6},'{7}','{8}'); SELECT LAST_INSERT_ID();",
                      idLivro, livro.isbn, livro.titulo, livro.descricao, livro.capaLivro, livro.paginas,
                      livro.estoque, Convert.ToDecimal(livro.valorUnit).ToString().Replace(",", "."), 
                      String.Format("{0:u}", livro.dataLanc));
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
    }
}
