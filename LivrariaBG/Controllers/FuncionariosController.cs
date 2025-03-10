﻿using Dominios;
using ModeloDLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows.Forms;

namespace LivrariaBG.Controllers
{
    public class FuncionariosController : Controller
    {
        // GET: Funcionarios
        public ActionResult Funcionarios()
        {
            var metodoFuncionario = new FuncionarioDAO();
            return View(SelecionaFuncionario(metodoFuncionario.Select()));
        }

        private List<Funcionario> SelecionaFuncionario(MySqlDataReader retorno)
        {
            var funcionarios = new List<Funcionario>();

            while (retorno.Read())
            {
                var TempFincionario = new Funcionario()
                {
                    idFunc = int.Parse(retorno["idFunc"].ToString()),
                    nomeFunc = retorno["nomeFunc"].ToString(),
                    cpfFunc = retorno["cpfFunc"].ToString(),
                    emailFunc = retorno["emailFunc"].ToString(),
                    cargo = retorno["cargo"].ToString(),
                    senhaFunc = retorno["senhaFunc"].ToString(),
                    nivelAcesso = retorno["nivelAcesso"].ToString(),

                    logradouro = retorno["logradouro"].ToString(),
                    numero = int.Parse(retorno["numero"].ToString()),
                    complemento = retorno["complemento"].ToString(),
                    CEP = retorno["CEP"].ToString(),
                    bairro = retorno["bairro"].ToString(),
                    cidade = retorno["cidade"].ToString(),
                    estado = retorno["estado"].ToString(),
                    UF = retorno["UF"].ToString(),

                    numTel1 = retorno["numTel1"].ToString(),
                    numTel2 = retorno["numTel2"].ToString(),
                    numTel3 = retorno["numTel3"].ToString(),
                };
                funcionarios.Add(TempFincionario);
            }
            retorno.Close();
            return funcionarios;
        }
        //selecionar funcionario por ID
        public ActionResult FuncionariosPorId(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            return View(SelecionaFuncionario(metodoFuncionario.SelectId(id)).FirstOrDefault());
        }
        //Cadastrar funcionario
        public ActionResult Cadastrar()
        {

            return View();
        }
        [HttpPost]
        //validar funcionario
        public ActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodoFuncionario = new FuncionarioDAO();
                metodoFuncionario.Insert(funcionario);
                MessageBox.Show("Cliente cadastrado com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return RedirectToAction("Funcionarios");
            }
            return View(funcionario);

        }
        // Selecuina o funcionario para atualizar
        public ActionResult AtualizarFuncionario(int id) 
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.idFunc = id;
                var metodoFuncionario = new FuncionarioDAO();
                return View(SelecionaFuncionario(metodoFuncionario.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar cliente" + ex.Message);
            }

        }
        // Atualizar cliente
        [HttpPost]
        public ActionResult AtualizarFuncionario(Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoFuncionario = new FuncionarioDAO();
                    metodoFuncionario.Update(funcionario);
                    return RedirectToAction("Funcionarios");
                }
                return View(funcionario);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao atualuzar cliente" + ex.Message);
            }

        }
        //Deletar cliente
        public ActionResult Delete(int id)
        {
            Funcionario cliente = new Funcionario { idFunc = id };

            var metodoFuncionario = new FuncionarioDAO();
            return View(SelecionaFuncionario(metodoFuncionario.SelectId(id)).FirstOrDefault());

        }
        //Deletar cliente
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmaDelete(int id)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.idFunc = id;
            var metodoFuncionario = new FuncionarioDAO();
            metodoFuncionario.Delete(funcionario);

            return RedirectToAction("Funcionarios");
        }
    }
}