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
    public class AutorController : Controller
    {
        //Seleciona Todos Autor 
        public ActionResult ConsultarTodosAutores()
        {
            var metodoAutor = new AutorDAO();
            return View(SelecionaEditora(metodoAutor.Select()));
        }
        // Cadastrar autor GET
        public ActionResult Cadastrar()
        {

            return View();
        }
        // Cadastrar autor POST
        [HttpPost]
        public ActionResult Cadastrar(Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoAutor = new AutorDAO();
                    metodoAutor.Insert(autor);
                    MessageBox.Show("Autor cadastrada com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return RedirectToAction("ConsultarTodosAutores");
                }
                return View(autor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao Cadastrar autor" + ex.Message);
            }

        }
        //Seleciona Detalhes autor por ID       
        public ActionResult ConsultarAutorId(int id)
        {
            var metodoEditoraId = new AutorDAO();
            return View(SelecionaEditora(metodoEditoraId.SelectId(id)).FirstOrDefault());

        }

        // Seleciona o autor para atualizar
        public ActionResult AtualizarAutor(int id)
        {
            try
            {
                Autor autor = new Autor();
                autor.idAutor = id;
                var metodoAutor = new AutorDAO();
                return View(SelecionaEditora(metodoAutor.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar autor" + ex.Message);
            }

        }


        //Selecionar e converter lista 
        private List<Autor> SelecionaEditora(MySqlDataReader retorno)
        {
            var autors = new List<Autor>();

            while (retorno.Read())
            {
                var TempAutor = new Autor()
                {
                    idAutor = int.Parse(retorno["idAutor"].ToString()),
                    nomeAutor = retorno["nomeAutor"].ToString(),
                };
                autors.Add(TempAutor);
            }
            retorno.Close();
            return autors;
        }
    }
}
