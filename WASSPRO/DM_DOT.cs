//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLCongNo
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_DOT
    {
        public DM_DOT()
        {
            this.HOADONs = new HashSet<HOADON>();
            this.NHANVIEN_HOADON = new HashSet<NHANVIEN_HOADON>();
        }
    
        public decimal DOT_ID { get; set; }
        public string TENDOT { get; set; }
        public string DIENGIAI { get; set; }
        public Nullable<decimal> USER_CREATE { get; set; }
        public Nullable<System.DateTime> DATE_CREATE { get; set; }
    
        public virtual ICollection<HOADON> HOADONs { get; set; }
        public virtual ICollection<NHANVIEN_HOADON> NHANVIEN_HOADON { get; set; }
    }
}
