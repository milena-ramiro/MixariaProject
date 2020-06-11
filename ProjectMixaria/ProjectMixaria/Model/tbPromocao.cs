using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbPromocao
    {

        public int Estab { get; set; }
        public string Produto { get; set; }
        public System.DateTime Inicio { get; set; }
        public System.DateTime Fim { get; set; }
        public decimal Preco { get; set; }
        public decimal Promocao { get; set; }
        public Nullable<byte> Prioridade { get; set; }

        public virtual tbEstab tbEstab { get; set; }
        public virtual tbProdutos tbProduto { get; set; }

    }
}
