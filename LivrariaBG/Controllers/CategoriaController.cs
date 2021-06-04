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
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }
        //Seleciona Todos categorias 
        public ActionResult ConsultarTodasCategorias()
        {
            var metodoCategoria = new CategoriaDAO();
            return View(SelecionaCategoria(metodoCategoria.Select()));
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes
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
                    return RedirectToAction("ConsultarTodosClientes");
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar cliente" + ex.Message);
            }

        }

        // Selecuina o cliente para atualizar
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
        // Atualizar cliente
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
        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //Seleciona Cliente por ID       
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
