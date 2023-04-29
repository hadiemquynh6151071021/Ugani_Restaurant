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
    
    public partial class LOAIMON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIMON()
        {
            this.MONANs = new HashSet<MONAN>();
        }

        [Required(ErrorMessage = "Vui lòng chọn tên loại món!")]
        [DisplayName("Tên loại món"), RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Tên món là một chỗi lý tự!")]
        public int MALOAIMON { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn tên loại món!")]
        [DisplayName("Tên loại món")]
        public string TENLOAIMON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MONAN> MONANs { get; set; }
    }
}
