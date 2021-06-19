using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Autor
    {
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")]
        public int idAutor { get; set; }

        [Display(Name = "Autor", Description = "Autor")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string nomeAutor { get; set; }
    }


}
