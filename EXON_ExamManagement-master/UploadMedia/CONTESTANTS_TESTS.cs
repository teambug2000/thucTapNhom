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
    
    public partial class CONTESTANTS_TESTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANTS_TESTS()
        {
            this.ANSWERSHEETS = new HashSet<ANSWERSHEET>();
        }
    
        public int ContestantTestID { get; set; }
        public int Status { get; set; }
        public int ContestantShiftID { get; set; }
        public int TestID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS { get; set; }
        public virtual TEST TEST { get; set; }
    }
}
