//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class ANSWERSHEET_WRITING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANSWERSHEET_WRITING()
        {
            this.WRITING_TEACHER = new HashSet<WRITING_TEACHER>();
        }
    
        public int AnswerSheetWritingID { get; set; }
        public Nullable<int> AnswerSheetID { get; set; }
        public Nullable<double> WritingScore { get; set; }
        public Nullable<double> WritingScore2 { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ANSWERSHEET ANSWERSHEET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WRITING_TEACHER> WRITING_TEACHER { get; set; }
    }
}
