//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UploadMedia
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIOLATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VIOLATION()
        {
            this.VIOLATIONS_CONTESTANTS = new HashSet<VIOLATIONS_CONTESTANTS>();
        }
    
        public int ViolationID { get; set; }
        public string ViolationName { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
    }
}
