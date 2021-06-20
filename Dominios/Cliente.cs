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
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")] 
        public int idCliente { get; set; }

        [Display(Name = "Nome ", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //    "Números e caracteres especiais não são permitidos no nome.")]
        public string nomeCliente { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string cpfCliente { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = " O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string emailCliente { get; set; }

        public Endereco endereco { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(\d{2}\)\d{4}-\d{4}$",
        //    ErrorMessage = "O numero do telefone não é valido use (99)9999-9999")]

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O sexo é obrigatorio")]
        public string sexoCliente { get; set; }

        [Display(Name = "Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime dataNascCliente { get; set; }
        public Telefone telefone { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status é obrigatorio")]
        public string statusCliente { get; set; }

        //Endereço do Cliente
        [Display(Name = "Logradouro ", Description = "rua/avenida/praça")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string logradouro { get; set; }

        [Display(Name = "Número ", Description = "Número")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor coloque numero valido")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public int numero { get; set; }

        [Display(Name = "Complemento ", Description = "casa/apto/viela")]
        //[Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string complemento { get; set; }

        [Display(Name = "Bairro ", Description = "Bairro")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string bairro { get; set; }

        [Display(Name = "CEP ", Description = "CEP")]
       // [Range(0, int.MaxValue, ErrorMessage = "Por favor coloque numero valido")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string CEP { get; set; }

        [Display(Name = "Cidade ", Description = "Cidade")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string cidade { get; set; }

        [Display(Name = "Estado ", Description = "Estado")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //          "Números e caracteres especiais não são permitidos no nome.")]
        public string estado { get; set; }

        [Display(Name = "UF ", Description = "UF")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
                  "Números e caracteres especiais não são permitidos no nome.")]
        public string UF { get; set; }
        
        //TELEFONE
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O numero é obrigatorio")]
        public string numTel1 { get; set; }


        [Display(Name = "Residencial")]
        public string numTel2 { get; set; }


        [Display(Name = "Comercial")]
        public string numTel3 { get; set; }

    }
}
