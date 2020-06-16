//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EconomizeMais
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbEstab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEstab()
        {
            this.tbPromocao = new HashSet<tbPromocao>();
            this.tbUsuario = new HashSet<tbUsuario>();
            this.tbTop30 = new HashSet<tbTop30>();
        }
    
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
        public virtual ICollection<tbPromocao> tbPromocao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbUsuario> tbUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbTop30> tbTop30 { get; set; }
    }
}