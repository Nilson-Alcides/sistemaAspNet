using System;
using System.Collections.Generic;
using System.Text;

namespace Dominios
{
    public class Usuario
    {
        public int IdUsu { get; set; }
        public string NomeUsu { get; set; }
        public string Cargo { get; set; }
        public string Senha { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
