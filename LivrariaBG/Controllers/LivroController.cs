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
            var ObjCategoria = new CategoriaDAO();
            var ListaCategoria = ObjCategoria.Select();
            SelectList lista = new SelectList(ListaCategoria, "idCategoria", "nomeCategoria");
            ViewBag.Lista = lista;

            var ObjEditora = new EditoraDAO();
            var ListaEditora = ObjEditora.Select();
            SelectList listaEditora = new SelectList(ListaEditora, "idEditora", "nomeEditora");
            ViewBag.Lista = listaEditora;

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
                MessageBox.Show("Livro cadastrado com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return RedirectToAction("ConsultarTodosLivros");
            }
            return View(livro);
        }
        //Seleciona Todos Livros 
        public ActionResult ConsultarTodosLivros()
        {
            var metodoLivro = new LivroDAO();
            return View(SelecionaLivro(metodoLivro.Select()));
        }
        //Seleciona livros por ID
        public ActionResult ConsultarLivrosId(string id)
        {
            var metodoLivroId = new LivroDAO();
            return View(SelecionaLivro(metodoLivroId.SelectId(id)).FirstOrDefault());

        }
        // Selecionar o Livro para atualizar
        public ActionResult AtualizarLivro(string id)
        {
            try
            {
                Livro livro = new Livro();
                livro.idLivro = id;
                var metodoLivro = new LivroDAO();
                return View(SelecionaLivro(metodoLivro.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar Livro" + ex.Message);
            }

        }
        // Atualizar Livro
        [HttpPost]
        public ActionResult AtualizarLivro(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoLivro = new LivroDAO();
                    metodoLivro.Update(livro);
                    return RedirectToAction("ConsultarTodosLivros");
                }
                return View(livro);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao atualuzar Livro" + ex.Message);
            }

        }

        //Lista de livros
        private List<Livro> SelecionaLivro(MySqlDataReader retorno)
        {

            var livros = new List<Livro>();

            while (retorno.Read())
            {
                var TempLivro = new Livro()
                {
                    idLivro = retorno["idLivro"].ToString(),//0
                    isbn = retorno["isbn"].ToString(),//1
                    autor = retorno["autor"].ToString(),//2
                    editora = retorno["editora"].ToString(),//3
                    formato = retorno["formato"].ToString(),//4
                    categoria = retorno["categoria"].ToString(),//5
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
        //Deletar Livro
        public ActionResult Delete(string id)
        {
            Livro produto = new Livro { idLivro = id };

            var metodoLivro = new LivroDAO();
            return View(SelecionaLivro(metodoLivro.SelectId(id)).FirstOrDefault());

        }
        //Deletar Livro
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmaDelete(string id)
        {

            DialogResult Resposta = MessageBox.Show("Tem certeza que deseja  excluir este Livro ", "Excluir Livro ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resposta == DialogResult.Yes)
            {
                Livro livro = new Livro();
                livro.idLivro = id;
                var metodoLivro = new LivroDAO();
                metodoLivro.Delete(livro);
            }
            return RedirectToAction("ConsultarTodosLivros");
        }
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

