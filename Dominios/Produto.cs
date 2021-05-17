using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
   public class Produto
    {
        public Categoria categoria { get; set; }
        public int idProduto { get; set; }
        public string nomeProd { get; set; }
        public string marcaProd { get; set; }
        public int quantidade { get; set; }
        public decimal preco { get; set; }
    }
}
