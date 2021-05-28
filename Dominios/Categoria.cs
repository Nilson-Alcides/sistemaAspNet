using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
   public class Categoria
    {       

        public int idCategoria { get; set; }
        public string nomeCategoria { get; set; }
        public Produto produto { get; set; }
        
    }
}
