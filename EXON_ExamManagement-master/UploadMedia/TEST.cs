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
    
    public partial class TEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEST()
        {
            this.CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            this.TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }
    
        public int TestID { get; set; }
        public int TestDate { get; set; }
        public int Status { get; set; }
        public int BagOfTestID { get; set; }
        public int SubjectID { get; set; }
    
        public virtual BAGOFTEST BAGOFTEST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAILS> TEST_DETAILS { get; set; }
    }
}
