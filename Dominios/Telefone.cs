using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Telefone
    {
        public int idTelefone { get; set; }
        public Cliente cliente { get; set; }
        public Funcionario funcionario { get; set; }
        public string TipoTelefone { get; set; }
        public int dddTelefone { get; set; }
        public int numeroTelefone { get; set; }

    }
}
