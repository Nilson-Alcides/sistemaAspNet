using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
   public class Produto
    {
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")]
        public int idProduto { get; set; }

        [Display(Name = "Nome ", Description = "Nome.")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string nomeProd { get; set; }

        [Display(Name = "Marca ", Description = "Marca")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string marcaProd { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int quantidade { get; set; }
        
        [Display(Name = "Valor")]       
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public decimal preco { get; set; }

        public Categoria categoria { get; set; }
    }
}
