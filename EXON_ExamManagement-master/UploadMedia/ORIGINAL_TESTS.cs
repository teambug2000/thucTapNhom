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
    
    public partial class ORIGINAL_TESTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORIGINAL_TESTS()
        {
            this.ORIGINAL_TEST_DETAILS = new HashSet<ORIGINAL_TEST_DETAILS>();
        }
    
        public int OriginalTestID { get; set; }
        public int CreateDate { get; set; }
        public Nullable<int> AcceptDate { get; set; }
        public int Status { get; set; }
        public int ContestID { get; set; }
        public int SubjectID { get; set; }
    
        public virtual CONTEST CONTEST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORIGINAL_TEST_DETAILS> ORIGINAL_TEST_DETAILS { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
    }
}
