//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WASSPRO_TDC_WEBSERVICE
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOTRINH_THU
    {
        public decimal id { get; set; }
        public Nullable<decimal> nv_id { get; set; }
        public string malt { get; set; }
        public Nullable<decimal> user_create { get; set; }
        public Nullable<System.DateTime> date_create { get; set; }
        public Nullable<decimal> user_update { get; set; }
        public Nullable<System.DateTime> date_updaet { get; set; }
    
        public virtual LOTRINH LOTRINH { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
