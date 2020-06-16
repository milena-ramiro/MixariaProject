using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbEstab
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public byte[] Logo { get; set; }
        public string LogoTipo { get; set; }
        public string Rua { get; set; }
        public string Nro { get; set; }
        public string Bairro { get; set; }
        public Nullable<short> TipoEst { get; set; }
        public Nullable<short> Municipio { get; set; }

        public virtual tbMunicipio tbMunicipio { get; set; }
        public virtual tbTipoEst tbTipoEst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPromocao> tbPromocaos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbUsuario> tbUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbTop30> tbTop30 { get; set; }

    }
}
