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
    
    public partial class DM_QUAN
    {
        public DM_QUAN()
        {
            this.DM_PHUONG = new HashSet<DM_PHUONG>();
            this.KHACHHANG_TDC = new HashSet<KHACHHANG_TDC>();
        }
    
        public string maQuan { get; set; }
        public string tenQuan { get; set; }
        public string maTinh { get; set; }
    
        public virtual ICollection<DM_PHUONG> DM_PHUONG { get; set; }
        public virtual DM_TINH DM_TINH { get; set; }
        public virtual ICollection<KHACHHANG_TDC> KHACHHANG_TDC { get; set; }
    }
}
