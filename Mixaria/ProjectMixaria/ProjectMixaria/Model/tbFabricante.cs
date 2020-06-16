using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbFabricante
    {
        public short Codigo { get; set; }
        public string Nome { get; set; }
        public byte[] Logo { get; set; }
        public string LogoTipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProdutos> tbProdutos { get; set; }

    }
}
