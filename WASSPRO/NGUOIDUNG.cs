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
    
    public partial class NGUOIDUNG
    {
        public NGUOIDUNG()
        {
            this.NGUOIDUNG_QUYEN = new HashSet<NGUOIDUNG_QUYEN>();
        }
    
        public decimal nguoidung_id { get; set; }
        public Nullable<decimal> nv_id { get; set; }
        public string manv { get; set; }
        public string ma_nd { get; set; }
        public string pass { get; set; }
        public string macaddress { get; set; }
        public string modelname { get; set; }
        public Nullable<bool> isLock { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual ICollection<NGUOIDUNG_QUYEN> NGUOIDUNG_QUYEN { get; set; }
    }
}
