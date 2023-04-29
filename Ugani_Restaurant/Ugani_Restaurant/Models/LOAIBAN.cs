﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class LOAIBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIBAN()
        {
            this.BANANs = new HashSet<BANAN>();
        }

        public int MALOAIBAN { get; set; }
        [DisplayName("Loại bàn"), RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Loại bàn là một chuỗi ký tự!")]
        public string TENLOAIBAN { get; set; }
        public string MOTA { get; set; }
        public Nullable<decimal> DONGIA { get; set; }
        public string DVT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANAN> BANANs { get; set; }
    }
}
