//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intermoda.LbDatPro
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaquiladoCaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaquiladoCaja()
        {
            this.MaquiladoCajaDetalle = new HashSet<MaquiladoCajaDetalle>();
        }
    
        public int Id { get; set; }
        public short CompaniaId { get; set; }
        public short OrdenAno { get; set; }
        public short OrdenNumero { get; set; }
        public int Numero { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaquiladoCajaDetalle> MaquiladoCajaDetalle { get; set; }
    }
}
