using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EconomizeMais.Models
{
    public class EstabViewModel
    {
        public Int32 Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Rua é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "Numero")]
        public string Nro { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatorio", AllowEmptyStrings = false)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Tipo de estabelecimento é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Tipo de estabelecimento")]
        public short TipoEst { get; set; }

        [Required(ErrorMessage = "Municipio é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Municipio")]
        public short MunicipioId { get; set; }

        //[Required]
        //[DataType(DataType.Upload)]
        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }

        [Display(Name = "LogoTipo")]
        public string LogoTipo { get; set; }
    }
}