using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
   public class Categoria
    {
        [Display(Name = "Código ", Description = "Codigo.")]
        public int idCategoria { get; set; }

        [Display(Name = "Categoria", Description = "Categoria")]
        [Required(ErrorMessage = "O Categoria é obrigatório.")]
        public string nomeCategoria { get; set; }

        [Display(Name = "Tipo ", Description = "Tipo Produto")]
        [Required(ErrorMessage = "O Tipo Produto é obrigatório.")]
        public string tipoCategoria { get; set; }



    }
}
