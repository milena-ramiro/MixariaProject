using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EconomizeMais.Models
{
    public class ProdutosViewModel
    {
        public Int32 ProdutoId { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Descrição do Produto")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto", AllowEmptyStrings = false)]
        [Display(Name = "Preço")]
        public Decimal Preco { get; set; }

        [Display(Name = "Estoque")]
        public int Estoque { get; set; }

        [Display(Name = "Fabricante")]
        public short FabricanteId { get; set; }

        //[Required]
        //[DataType(DataType.Upload)]
        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }

        [Display(Name = "ImagemTipo")]
        public string ImagemTipo { get; set; }
    }
}