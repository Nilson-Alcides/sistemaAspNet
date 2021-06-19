using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class FormatoLivro
    {
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")]
        public int idFormato { get; set; }

        [Display(Name = "Formato", Description = "Formato")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string descricao_for { get; set; }
    }
}
