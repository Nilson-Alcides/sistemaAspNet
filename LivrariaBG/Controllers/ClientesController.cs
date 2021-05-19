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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Cadastrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodoCliente = new ClienteDAO();
                metodoCliente.Insert(cliente);
                MessageBox.Show("Cliente cadastrado com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return RedirectToAction("ConsultarTodosClientes");
            }
            return View(cliente);

        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodoCliente = new ClienteDAO();
                metodoCliente.Insert(cliente);
                RedirectToAction("ConsultarTodosClientes");
            }
            return View(cliente);

        }
        //Seleciona Todos Cliente 
        public ActionResult ConsultarTodosClientes()
        {
            var metodoCliente = new ClienteDAO();
            return View(SelecionaCliente(metodoCliente.Select()));
        }

        //Seleciona Cliente por ID
       
        public ActionResult ConsultarClientesId(int id)
        {
            var metodoClienteId = new ClienteDAO();
            return View(SelecionaCliente(metodoClienteId.SelectId(id)).FirstOrDefault());

        }
        private List<Cliente> SelecionaCliente(MySqlDataReader retorno)
        {
            var clientes = new List<Cliente>();

            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {
                    idCliente = int.Parse(retorno["idCliente"].ToString()),
                    nomeCliente = retorno["nomeCliente"].ToString(),
                    cpfCliente = retorno["cpfCliente"].ToString(),
                    emailCliente = retorno["emailCliente"].ToString(),
                    sexoCliente = retorno["sexoCliente"].ToString(),
                    dataNascCliente = DateTime.Parse(retorno["dataNascCliente"].ToString()),
                    statusCliente = retorno["statusCliente"].ToString(),

                };
                clientes.Add(TempCliente);
            }
            retorno.Close();
            return clientes;
        }

        public ActionResult Consultar()
        {
            var metodoUsuario = new UsuarioDAO();
            return View(SelecionaUsiario(metodoUsuario.Select()));
        }

        //Deletar cliente
        public ActionResult Delete(int id)
        {
            Cliente cliente = new Cliente { idCliente = id };
            
            var metodoCliente = new ClienteDAO();
            return View(SelecionaCliente(metodoCliente.SelectId(id)).FirstOrDefault());

        }




        //Deletar cliente
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmaDelete(int id)
        {
            Cliente cliente = new Cliente();
            cliente.idCliente = id;
            var metodoUsuario = new ClienteDAO();
            metodoUsuario.Delete(cliente);

            return RedirectToAction("ConsultarTodosClientes");
        }


        private List<Usuario> SelecionaUsiario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();

            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    Senha = retorno["SenhaUsu"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        


    }
 }