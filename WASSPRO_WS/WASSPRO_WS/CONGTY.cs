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
    
    public partial class CONGTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONGTY()
        {
            this.CHINHANHs = new HashSet<CHINHANH>();
            this.CHINHANHs1 = new HashSet<CHINHANH>();
            this.CHINHANHs2 = new HashSet<CHINHANH>();
        }
    
        public string maCTY { get; set; }
        public string tenCTY { get; set; }
        public string DC_CTY { get; set; }
        public string SDT_CTY { get; set; }
        public string MST_CTY { get; set; }
        public string soFAX_CTY { get; set; }
        public string link_portal { get; set; }
        public string pass_default { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHINHANH> CHINHANHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHINHANH> CHINHANHs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHINHANH> CHINHANHs2 { get; set; }
    }
}
