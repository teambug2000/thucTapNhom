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
    
    public partial class QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION()
        {
            this.ORIGINAL_TEST_DETAILS = new HashSet<ORIGINAL_TEST_DETAILS>();
            this.SUBQUESTIONS = new HashSet<SUBQUESTION>();
            this.TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }
    
        public int QuestionID { get; set; }
        public string QuestionContent { get; set; }
        public int QuestionFormat { get; set; }
        public int Level { get; set; }
        public int CreatedDate { get; set; }
        public Nullable<int> AcceptedDate { get; set; }
        public int Status { get; set; }
        public int QuestionTypeID { get; set; }
        public int TopicID { get; set; }
        public int CreatedStaffID { get; set; }
        public Nullable<int> AcceptedStaffID { get; set; }
        public byte[] Audio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORIGINAL_TEST_DETAILS> ORIGINAL_TEST_DETAILS { get; set; }
        public virtual QUESTION_TYPES QUESTION_TYPES { get; set; }
        public virtual STAFF STAFF { get; set; }
        public virtual STAFF STAFF1 { get; set; }
        public virtual TOPIC TOPIC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBQUESTION> SUBQUESTIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAILS> TEST_DETAILS { get; set; }
    }
}
