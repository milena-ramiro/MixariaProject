using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EconomizeMais.Models
{
    public class FabricantesViewModel
    {
        public short Codigo { get; set; }

        [Required(ErrorMessage = "O nome do fabricante é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Fabricante")]
        public String Nome { get; set; }

        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }

        [Display(Name = "LogoTipo")]
        public string LogoTipo { get; set; }
    }
}