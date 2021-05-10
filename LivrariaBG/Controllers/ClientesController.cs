using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LivrariaBG.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return View();
        }
    }
}