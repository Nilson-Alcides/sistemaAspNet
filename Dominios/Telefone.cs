using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Telefone
    {
        [Display(Name = "Codigo")]       
        public int idTelefone { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O tipo é obrigatorio")]        
        public string TipoTelefone { get; set; }

        [Display(Name = "DDD")]
        [Required(ErrorMessage = "O ddd é obrigatorio")]
        public int dddTelefone { get; set; }
        
        [Display(Name = "Numero")]
        [Required(ErrorMessage = "O numero é obrigatorio")]
        public int numeroTelefone { get; set; }

    }
}
