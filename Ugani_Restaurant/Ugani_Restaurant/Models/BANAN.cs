//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ugani_Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BANAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANAN()
        {
            this.CHITIETDATBANs = new HashSet<CHITIETDATBAN>();
        }
    
        public string MABAN { get; set; }
        public int MALOAIBAN { get; set; }
        public Nullable<byte> SOGHE { get; set; }
    
        public virtual LOAIBAN LOAIBAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATBAN> CHITIETDATBANs { get; set; }
    }
}
