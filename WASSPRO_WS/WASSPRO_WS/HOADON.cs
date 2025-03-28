//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WASSPRO_WS
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            this.CHITIET_HD = new HashSet<CHITIET_HD>();
            this.CHUNGTU_HOADON = new HashSet<CHUNGTU_HOADON>();
        }
    
        public decimal ID_HD { get; set; }
        public string kyghi { get; set; }
        public System.DateTime ngaylap { get; set; }
        public Nullable<System.DateTime> ngaythanhtoan { get; set; }
        public bool trangthai { get; set; }
        public decimal ID_KH { get; set; }
        public string maNV { get; set; }
        public string MADT { get; set; }
        public Nullable<int> soNK { get; set; }
        public string ma_giaBVMT { get; set; }
        public Nullable<decimal> giabvmt { get; set; }
        public Nullable<decimal> tien_V_BVMT { get; set; }
        public Nullable<decimal> tienBVMT { get; set; }
        public Nullable<decimal> giaNthai { get; set; }
        public Nullable<decimal> tien_V_NThai { get; set; }
        public Nullable<decimal> tien_NThai { get; set; }
        public Nullable<decimal> tienthueDH { get; set; }
        public Nullable<decimal> tienvthueDH { get; set; }
        public decimal tongtien0VAT { get; set; }
        public Nullable<decimal> VAT { get; set; }
        public Nullable<decimal> tienvat { get; set; }
        public decimal tongtien { get; set; }
        public Nullable<decimal> sotienthanhtoan { get; set; }
        public Nullable<decimal> sotienno { get; set; }
        public string ghichu { get; set; }
        public long ma_HTTT { get; set; }
        public string MaLT { get; set; }
        public Nullable<int> M3Khoan { get; set; }
        public Nullable<bool> IsLuuBo { get; set; }
        public Nullable<bool> IsInHD { get; set; }
        public string MAU_HD { get; set; }
        public string SO_HD { get; set; }
        public string KY_HIEU_HD { get; set; }
        public string keys { get; set; }
        public Nullable<decimal> m3tieuthu { get; set; }
        public Nullable<System.DateTime> ArisingDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIET_HD> CHITIET_HD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUNGTU_HOADON> CHUNGTU_HOADON { get; set; }
        public virtual GiaBVMT GiaBVMT1 { get; set; }
        public virtual HOADON HOADON1 { get; set; }
        public virtual HOADON HOADON2 { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
