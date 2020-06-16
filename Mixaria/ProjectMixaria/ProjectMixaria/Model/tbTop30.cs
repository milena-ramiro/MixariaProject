using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbTop30
    {
        public int estab { get; set; }
        public string produto { get; set; }
        public System.DateTime inicio { get; set; }
        public System.DateTime fim { get; set; }
        public Nullable<decimal> preco { get; set; }
        public Nullable<decimal> promocao { get; set; }
        public Nullable<byte> item_top { get; set; }

        public virtual tbEstab tbEstab { get; set; }
        public virtual tbProdutos tbProduto { get; set; }

    }
}
