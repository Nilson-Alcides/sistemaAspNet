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
                return RedirectToAction("ConsultarTodosProdutos");
            }
            return View(produto);
        }
        //Seleciona Todos Produtos 
        public ActionResult ConsultarTodosProdutos()
        {
            var metodoProduto = new ProdutoDAO();
            return View(SelecionaProduto(metodoProduto.Select()));
        }

        //Seleciona Produto por ID
        public ActionResult ConsultarProdutoId(string id)
        {
            var metodoProdutoId = new ProdutoDAO();
            return View(SelecionaProduto(metodoProdutoId.SelectId(id)).FirstOrDefault());

        }
        private List<Produto> SelecionaProduto(MySqlDataReader retorno)
        {
            
            var produtos = new List<Produto>();

            while (retorno.Read())
            {
                var TempProduto = new Produto()
                {
                    idProduto = retorno["idProduto"].ToString(),                    
                    nomeProd = retorno["nomeProd"].ToString(),
                    marcaProd = retorno["marcaProd"].ToString(),
                    quantidade = int.Parse(retorno["quantidade"].ToString()),
                    preco = decimal.Parse(retorno["preco"].ToString()),                   
                   
                };
                produtos.Add(TempProduto);
            }
            retorno.Close();
            return produtos;
        }
        // Selecionar o Produto para atualizar
        public ActionResult AtualizarProduto(string id)
        {
            try
            {
                Produto produto = new Produto();
                produto.idProduto = id;
                var metodoProduto = new ProdutoDAO();
                return View(SelecionaProduto(metodoProduto.SelectId(id)).FirstOrDefault());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao listar Produto" + ex.Message);
            }

        }
        // Atualizar Produto
        [HttpPost]
        public ActionResult AtualizarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoProduto = new ProdutoDAO();
                    metodoProduto.Update(produto);
                    return RedirectToAction("ConsultarTodosProdutoss");
                }
                return View(produto);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(404, "Erro ao atualuzar Produto" + ex.Message);
            }

        }
    }
}