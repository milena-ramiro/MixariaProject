using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbMunicipio
    {
        public short Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEstab> tbEstabs { get; set; }
    }
}
