using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Livro
    {
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")]
        public string idLivro { get; set; }

        public int IdEditora { get; set; }
        public int IdAutor { get; set; }
        public Categoria categoria { get; set; }
        public int IdCategoria { get; set; }
        public int IdFormato { get; set; }

        [Display(Name = "ISBN ", Description = "ISBN.")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string isbn { get; set; }

        [Display(Name = "Titulo ", Description = "Titulo")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string titulo { get; set; }

        [Display(Name = "Descrição ", Description = "Descrição")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string descricao { get; set; }

        [Display(Name = "Capa ", Description = "Capa")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string capaLivro { get; set; }


        [Display(Name = "Paginas", Description = "Paginas")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int paginas { get; set; }

        [Display(Name = "Quantidade", Description = "Quantidade")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int estoque { get; set; }

        [Display(Name = "Valor", Description = "Valor")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public decimal valorUnit { get; set; }

        [Display(Name = "Lançamento", Description = "Lançamento")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateTime dataLanc { get; set; }
    }
}
