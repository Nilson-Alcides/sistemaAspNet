using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Funcionario
    {
        // Id do funcionario
        [Display(Name = "Código ", Description = "Codigo.")]
        public int idFunc { get; set; }
        
        // Nome do funcionario
        [Display(Name = "Nome", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
           "Números e caracteres especiais não são permitidos no nome.")]
        public string nomeFunc { get; set; }
        
        // CPF do funcionario
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string cpfFunc { get; set; }
        
        // email do funcionario
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = " O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string emailFunc { get; set; }

        //Cargo do funcionario
        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O cargo é obrigatorio")]
        public string cargo { get; set; }

        //Senha ou Password do funcionario
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O senha é obrigatorio")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string senhaFunc { get; set; }
        
        //Nivel de acesso
        [Display(Name = "Privilégio")]
        [Required(ErrorMessage = "O nivel de acesso é obrigatorio")]
        public string nivelAcesso { get; set; }      

    }
}
