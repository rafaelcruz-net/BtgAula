using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ClienteViewModel
    {

        public Int32 Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required]
        public String CPF { get; set; }

        [Required]
        public String Agencia { get; set; }

        [Required]
        public String Conta { get; set; }

        [Required]
        public String Estado { get; set; }
    }
}