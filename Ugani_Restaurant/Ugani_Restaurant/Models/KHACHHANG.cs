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
    using System.Linq;

    public partial class KHACHHANG
    {
        UGANI_1Entities db = new UGANI_1Entities();
        public int ID { get; set; }
        public string ID_USER { get; set; }
        public string TENKHACHHANG { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public string getFullname_Cus(string mail)
        {
            string temp1 = db.AspNetUsers.Where(m => m.Email == mail).FirstOrDefault().Id;
            string temp2 = db.KHACHHANGs.Where(m => m.ID_USER == temp1).FirstOrDefault().TENKHACHHANG;
            return temp2;
        }
    }
}
