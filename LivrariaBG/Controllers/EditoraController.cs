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
    public class EditoraController : Controller
    {
        //Seleciona Todos editora 
        public ActionResult ConsultarTodasEditoras()
        {
            var metodoEditora = new EditoraDAO();
            return View(SelecionaEditora(metodoEditora.Select()));
        }
        // GET: categoria
        public ActionResult Cadastrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Editora editora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoEditora = new EditoraDAO();
                    metodoEditora.Insert(editora);
                    MessageBox.Show("Categoria cadastrada com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return RedirectToAction("ConsultarTodasEditoras");
                }
                return View(editora);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar editora" + ex.Message);
            }

        }

        // Seleciona o editora para atualizar
        public ActionResult AtualizarEditora(int id)
        {
            try
            {
                Editora editora = new Editora();
                editora.idEditora = id;
                var metodoEditora = new EditoraDAO();
                return View(SelecionaEditora(metodoEditora.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar editora" + ex.Message);
            }

        }
        // Atualizar Editora
        [HttpPost]
        public ActionResult AtualizarEditora(Editora editora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoEditora = new EditoraDAO();
                    metodoEditora.Update(editora);
                    return RedirectToAction("ConsultarTodasEditoras");
                }
                return View(editora);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao atualuzar categoria" + ex.Message);
            }

        }

        //Deletar editora
        public ActionResult Delete(int id)
        {
            Editora editora = new Editora { idEditora = id };

            var metodEditora = new EditoraDAO();
            return View(SelecionaEditora(metodEditora.SelectId(id)).FirstOrDefault());

        }
        //Deletar Editora
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmaDelete(int id)
        {

            DialogResult Resposta = MessageBox.Show("Tem certeza que deseja  excluir este Editora ", "Excluir Editora ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resposta == DialogResult.Yes)
            {
                Editora editora = new Editora();
                editora.idEditora = id;
                var metodoEditora = new EditoraDAO();
                metodoEditora.Delete(editora);
            }
            return RedirectToAction("ConsultarTodasEditoras");
        }

        //Seleciona Detalhes editora por ID       
        public ActionResult ConsultarEditoraId(int id)
        {
            var metodoEditoraId = new EditoraDAO();
            return View(SelecionaEditora(metodoEditoraId.SelectId(id)).FirstOrDefault());

        }

        private List<Editora> SelecionaEditora(MySqlDataReader retorno)
        {
            var editora = new List<Editora>();

            while (retorno.Read())
            {
                var TempEditora = new Editora()
                {
                    idEditora = int.Parse(retorno["idEditora"].ToString()),
                    nomeEditora = retorno["nomeEditora"].ToString(),                    
                };
                editora.Add(TempEditora);
            }
            retorno.Close();
            return editora;
        }
    }
}
