using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Editora
    {
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")]
        public int idEditora { get; set; }

        [Display(Name = "Editora", Description = "Editora")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string nomeEditora { get; set; }
       
    }
}
