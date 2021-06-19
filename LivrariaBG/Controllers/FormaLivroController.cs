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
    public class FormatoLivroController : Controller
    {
        //Seleciona Todos formato 
        public ActionResult ConsultarTodosformatos()
        {
            var metodoAutor = new FormatoLivroDAO();
            return View(SelecionaFormato(metodoAutor.Select()));
        }
        // Cadastrar formatoLivro GET
        public ActionResult Cadastrar()
        {

            return View();
        }
        // Cadastrar formatoLivro POST
        [HttpPost]
        public ActionResult Cadastrar(FormatoLivro formatoLivro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoformato = new FormatoLivroDAO();
                    metodoformato.Insert(formatoLivro);
                    MessageBox.Show("formatoLivro cadastrada com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return RedirectToAction("ConsultarTodosformatos");
                }
                return View(formatoLivro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao Cadastrar Formato" + ex.Message);
            }

        }
        //Seleciona Detalhes Formato por ID       
        public ActionResult ConsultarFormatoId(int id)
        {
            var metodoFormatoId = new FormatoLivroDAO();
            return View(SelecionaFormato(metodoFormatoId.SelectId(id)).FirstOrDefault());

        }

        // Seleciona o Formato para atualizar
        public ActionResult AtualizarFormato(int id)
        {
            try
            {
                FormatoLivro formatoLivro = new FormatoLivro();
                formatoLivro.idFormato = id;
                var metodoFormato = new FormatoLivroDAO();
                return View(SelecionaFormato(metodoFormato.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar Formato" + ex.Message);
            }

        }
        // Atualizar Formato
        [HttpPost]
        public ActionResult AtualizarFormato(FormatoLivro formatoLivro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoFormato = new FormatoLivroDAO();
                    metodoFormato.Update(formatoLivro);
                    return RedirectToAction("ConsultarTodosformatos");
                }
                return View(formatoLivro);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao atualuzar Formato" + ex.Message);
            }

        }
        //Deletar Autor
        public ActionResult Delete(int id)
        {
            FormatoLivro FormatoLivro = new FormatoLivro { idFormato = id };

            var metodoFormato = new FormatoLivroDAO();
            return View(SelecionaFormato(metodoFormato.SelectId(id)).FirstOrDefault());

        }
        //Confirmar Deletar Autor
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmaDelete(int id)
        {

            DialogResult Resposta = MessageBox.Show("Tem certeza que deseja  excluir este Formato ", "Excluir Formato ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resposta == DialogResult.Yes)
            {
                FormatoLivro FormatoLivro = new FormatoLivro();
                FormatoLivro.idFormato = id;
                var metodoFormato = new FormatoLivroDAO();
                metodoFormato.Delete(FormatoLivro);
            }
            return RedirectToAction("ConsultarTodosformatos");
        }


        private List<FormatoLivro> SelecionaFormato(MySqlDataReader retorno)
        {
            var autors = new List<FormatoLivro>();

            while (retorno.Read())
            {
                var TempFormato = new FormatoLivro()
                {
                    idFormato = int.Parse(retorno["idFormato"].ToString()),
                    descricao_for = retorno["descricao_for"].ToString(),
                };
                autors.Add(TempFormato);
            }
            retorno.Close();
            return autors;
        }
    }
}
