using Dominios;
using ModeloDLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace LivrariaBG.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        // Cadastro Livro
        public ActionResult Cadastrar()
        {

            return View();
        }
        // Cadastro Livro
        [HttpPost]
        public ActionResult Cadastrar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var metodoLivro = new LivroDAO();
                metodoLivro.Insert(livro);
                MessageBox.Show("Cliente cadastrado com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return RedirectToAction("ConsultarTodosProdutos");
            }
            return View(livro);
        }
        //Seleciona Todos Produtos 
        public ActionResult ConsultarTodosLivros()
        {
            var metodoLivro = new LivroDAO();
            return View(SelecionaLivro(metodoLivro.Select()));
        }

        private List<Livro> SelecionaLivro(MySqlDataReader retorno)
        {

            var livros = new List<Livro>();

            while (retorno.Read())
            {
                var TempLivro = new Livro()
                {
                    idLivro = retorno["idLivro"].ToString(),//0
                    isbn = retorno["isbn"].ToString(),//1
                    IdAutor = int.Parse(retorno["IdAutor"].ToString()),//2
                    IdEditora = int.Parse(retorno["IdEditora"].ToString()),//3
                    IdFormato = int.Parse(retorno["IdFormato"].ToString()),//4
                    IdCategoria = int.Parse(retorno["IdCategoria"].ToString()),//5
                    titulo = retorno["titulo"].ToString(),//6                    
                    descricao = retorno["descricao"].ToString(),//7
                    capaLivro = retorno["capaLivro"].ToString(),//8
                    paginas = int.Parse(retorno["paginas"].ToString()),//9
                    estoque = int.Parse(retorno["estoque"].ToString()),//10
                    dataLanc = DateTime.Parse(retorno["dataLanc"].ToString()),//11                  
                    valorUnit = decimal.Parse(retorno["valorUnit"].ToString()),//12

                };
                livros.Add(TempLivro);
            }
            retorno.Close();
            return livros;
        }
        //SELECIONAR CATEGORIA LISTA
        private List<Categoria> SelecionaCategoria(MySqlDataReader retorno)
        {
            var categorias = new List<Categoria>();

            while (retorno.Read())
            {
                var TempCategoria = new Categoria()
                {
                    idCategoria = int.Parse(retorno["idCategoria"].ToString()),
                    nomeCategoria = retorno["nomeCategoria"].ToString(),
                    tipoCategoria = retorno["tipoProduto"].ToString(),
                };
                categorias.Add(TempCategoria);
            }
            retorno.Close();
            return categorias;
        }
    }
}

