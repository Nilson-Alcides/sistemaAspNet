using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Telefone
    {
        [Display(Name = "Codigo")]       
        public int idTelefone { get; set; }

       // [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$",
        // ErrorMessage = "O numero do Celular não é valido use (99)99999-9999")]
        [Display(Name = "Celular")]
        //[Required(ErrorMessage = "O numero é obrigatorio")]
        public int numTel1 { get; set; }

       
        [Display(Name = "Residencial")]       
        public int numTel2 { get; set; }

        
        [Display(Name = "Comercial")]
        public int numTel3 { get; set; }

    }
}
