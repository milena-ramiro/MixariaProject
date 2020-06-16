using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbProdutos
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public short FabricanteId { get; set; }
        public Nullable<int> Estoque { get; set; }
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
        public string ImagemTipo { get; set; }

        public virtual tbFabricante tbFabricante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPromocao> tbPromocaos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbTop30> tbTop30 { get; set; }

    }
}
