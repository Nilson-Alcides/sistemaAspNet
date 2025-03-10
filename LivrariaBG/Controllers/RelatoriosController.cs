﻿using Dominios;
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
                    idCliente =int.Parse( retorno["idCliente"].ToString()),
                    nomeCliente = retorno["nomeCliente"].ToString(),
                    cpfCliente = retorno["cpfCliente"].ToString(),
                    emailCliente = retorno["emailCliente"].ToString(),
                    sexoCliente = retorno["sexoCliente"].ToString(),
                    dataNascCliente =DateTime.Parse( retorno["dataNascCliente"].ToString()),
                    statusCliente = retorno["statusCliente"].ToString(),
                    
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