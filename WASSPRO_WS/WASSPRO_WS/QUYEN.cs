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
    
    public partial class QUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUYEN()
        {
            this.NGUOIDUNG_QUYEN = new HashSet<NGUOIDUNG_QUYEN>();
            this.QUYEN_MENU = new HashSet<QUYEN_MENU>();
        }
    
        public decimal quyen_id { get; set; }
        public string tenquyen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGUOIDUNG_QUYEN> NGUOIDUNG_QUYEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUYEN_MENU> QUYEN_MENU { get; set; }
    }
}
