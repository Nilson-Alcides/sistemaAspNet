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
    public class ProdutosController : Controller
    {
        // GET: Produto
        // Cadastro Produto
        public ActionResult Cadastrar()
        {

            return View();
        }
        // Cadastro Produto
        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var metodoProduto = new ProdutoDAO();
                metodoProduto.Insert(produto);
                MessageBox.Show("Cliente cadastrado com successo", "cadastrado com successo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return RedirectToAction("ConsultarTodosClientes");
            }
            return View(produto);
        }
        //Seleciona Todos Produtos 
        public ActionResult ConsultarTodosProdutos()
        {
            var metodoProduto = new ProdutoDAO();
            return View(SelecionaCliente(metodoProduto.Select()));
        }

        //Seleciona Produto por ID       
        //public ActionResult ConsultarClientesId(int id)
        //{
        //    var metodoClienteId = new ClienteDAO();
        //    return View(SelecionaCliente(metodoClienteId.SelectId(id)).FirstOrDefault());

        //}
        private List<Produto> SelecionaCliente(MySqlDataReader retorno)
        {
            Categoria categoria = new Categoria();
            var produtos = new List<Produto>();

            while (retorno.Read())
            {
                var TempProduto = new Produto()
                {
                    idProduto = int.Parse(retorno["idProduto"].ToString()),
                    nomeProd = retorno["nomeProd"].ToString(),
                    marcaProd = retorno["marcaProd"].ToString(),
                    quantidade = int.Parse(retorno["quantidade"].ToString()),
                    preco = decimal.Parse(retorno["sexoCliente"].ToString()),                    
                    //categoria.idCategoria = int.Parse(retorno["idCategoria"].ToString())
                };
                produtos.Add(TempProduto);
            }
            retorno.Close();
            return produtos;
        }
    }
}