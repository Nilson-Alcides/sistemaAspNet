using Dominios;
using ModeloDLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LivrariaBG.Controllers
{
    public class LoginController : Controller
    {
        FuncionarioDAO AC = new FuncionarioDAO();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult VerificarFuncionario(Funcionario u)
        {
            // enviar os dados dos formualario para ser checados no banco de dados 
            AC.TestarUsuario(u);

            //quando o banco devolver , se as  informações forem diferentes de nulas ou seja
            // se foram encontradas no banco de dados serão ciadas as sesões 

            if (u.emailFunc != null && u.senhaFunc != null)
            {
                //classe de segurança que valida quando vai para o banco e volta para a tela 
                FormsAuthentication.SetAuthCookie(u.emailFunc, false);
                Session["usuarioLogado"] = u.emailFunc.ToString();
                Session["SenhaLogado"] = u.senhaFunc.ToString();

                // direciona para a pagina index
                return RedirectToAction("Index", "Home");

            }

            else
            {      // se o login estiver errado volta para pagina login         
                return RedirectToAction("Login", "Login");

            }

        }
        //private Funcionario SelecionaFuncionarioUser(MySqlDataReader retorno)
        //{
        //    var funcionarios = new Funcionario();

        //    while (retorno.Read())
        //    {
        //        var TempFincionario = new Funcionario()
        //        {
        //            idFunc = int.Parse(retorno["idFunc"].ToString()),
        //            nomeFunc = retorno["nomeFunc"].ToString(),
        //            cpfFunc = retorno["cpfFunc"].ToString(),
        //            emailFunc = retorno["emailFunc"].ToString(),
        //            cargo = retorno["cargo"].ToString(),
        //            senhaFunc = retorno["senhaFunc"].ToString(),
        //            nivelAcesso = retorno["nivelAcesso"].ToString()
        //        };
                
        //    }
        //    retorno.Close();
        //    return funcionarios;

            
        //}

    }
}