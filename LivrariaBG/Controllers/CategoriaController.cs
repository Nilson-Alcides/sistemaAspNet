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
    public class CategoriaController : Controller
    {
       
        //Seleciona Todos categorias 
        public ActionResult ConsultarTodasCategorias()
        {
            var metodoCategoria = new CategoriaDAO();
            return View(SelecionaCategoria(metodoCategoria.Select())); 
        }
       
        // GET: categoria
        public ActionResult Cadastrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoCategoria = new CategoriaDAO();
                    metodoCategoria.Insert(categoria);
                    MessageBox.Show("Categoria cadastrada com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return RedirectToAction("ConsultarTodasCategorias");
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar cliente" + ex.Message);
            }

        }

        // Seleciona o categoria para atualizar
        public ActionResult AtualizarCategoria(int id)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.idCategoria = id;
                var metodoCategoria = new CategoriaDAO();
                return View(SelecionaCategoria(metodoCategoria.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar Categoria" + ex.Message);
            }

        }
        // Atualizar categoria
        [HttpPost]
        public ActionResult AtualizarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoCategoria = new CategoriaDAO();
                    metodoCategoria.Update(categoria);
                    return RedirectToAction("ConsultarTodasCategorias");
                }
                return View(categoria);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao atualuzar categoria" + ex.Message);
            }

        }
        //Deletar categoria
        public ActionResult Delete(int id)
        {
            Categoria categoria = new Categoria { idCategoria = id };

            var metodCategoria = new CategoriaDAO();
            return View(SelecionaCategoria(metodCategoria.SelectId(id)).FirstOrDefault());

        }
        //Deletar Categoria
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmaDelete(int id)
        {

            DialogResult Resposta = MessageBox.Show("Tem certeza que deseja  excluir este Clinete ", "Excluir Categoria ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resposta == DialogResult.Yes)
            {
                Categoria categoria = new Categoria();
                categoria.idCategoria = id;
                var metodocategoria = new CategoriaDAO();
                metodocategoria.Delete(categoria);
            }
            return RedirectToAction("ConsultarTodasCategorias");
        }

        //Seleciona Detalhes categoria por ID       
        public ActionResult ConsultarCategoriaId(int id)
        {
            var metodoCategoriaId = new CategoriaDAO();
            return View(SelecionaCategoria(metodoCategoriaId.SelectId(id)).FirstOrDefault());

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
