using Dominios;
using ModeloDLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LivrariaBG.Controllers
{
    public class RelatoriosController : Controller
    {
        // GET: Relatorios
        public ActionResult Vendas()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            var metodoCliente = new ClienteDAO();
            return View(SelecionaCliente(metodoCliente.Select()));
        }
        private List<Cliente> SelecionaCliente(MySqlDataReader retorno)
        {
            var clientes = new List<Cliente>();

            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {
                    nome_cli = retorno["nome_cli"].ToString(),
                    cpf_cli = retorno["cpf_cli"].ToString(),
                    telefone_cli = retorno["telefone_cli"].ToString(),
                    email_cli = retorno["email_cli"].ToString(),
                    endereco_cli = retorno["endereco_cli"].ToString(),
                    complemento_cli = retorno["complemento_cli"].ToString(),
                    bairro_cli = retorno["bairro_cli"].ToString(),
                    cidade_cli = retorno["cidade_cli"].ToString(),
                    uf_id_est = retorno["uf_id_est"].ToString(),
                    cep_cli = retorno["cep_cli"].ToString()
                };
                clientes.Add(TempCliente);
            }
            retorno.Close();
            return clientes;
        }

        public ActionResult ProdutoEstoque()
        {
            return View();
        }
    }
}