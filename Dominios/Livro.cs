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

        [Display(Name = "Editora ", Description = "Editora.")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string editora { get; set; }

        [Key]
        [Display(Name = "categoria ID ", Description = "categoria.")]
        public int idEditora { get; set; }

        [Display(Name = "Autor ", Description = "Autor.")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string autor { get; set; }

        [Key]
        [Display(Name = "categoria ID ", Description = "categoria.")]
        public int idCategoria { get; set; }
       
        [Display(Name = "Categoria ", Description = "Categoria.")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string categoria { get; set; }

        [Display(Name = "Formato ", Description = "Formato")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string formato { get; set; }

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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe a data de Lançamento")]
        public DateTime dataLanc { get; set; }
    }
}
