using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Cliente
    {

        [Display(Name = "Nome ", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string nome_cli { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string cpf_cli { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{2}\)\d{4}-\d{4}$",
            ErrorMessage = "O numero do telefone não é valido use (99)9999-9999")]
        public string telefone_cli { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = " O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string email_cli { get; set; }
       
        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O Endereço é obrigatorio")]
        public string endereco_cli { get; set; }

        [Display(Name = "Complemento")]
        [Required(ErrorMessage = "O Complemento é obrigatorio")]
        public string complemento_cli { get; set; }
        
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O Bairro é obrigatorio")]
        public string bairro_cli { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O Cidade é obrigatorio")]
        public string cidade_cli { get; set; }
       
        [Display(Name = "UF")]
        [Required(ErrorMessage = "O UF é obrigatorio")]
        public string uf_id_est { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O CEP é obrigatorio")]
        public string cep_cli { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "O login é obrigatorio")]
        public string login_id_cli { get; set; }

        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "a senha é obrigatorio")]
        public string senha_cli { get; set; }


    }
}
