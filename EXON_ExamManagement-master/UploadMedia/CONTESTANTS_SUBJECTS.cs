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
    
    public partial class CONTESTANTS_SUBJECTS
    {
        public int ContestantSubjectID { get; set; }
        public int Status { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<int> ContestantID { get; set; }
    
        public virtual CONTESTANT CONTESTANT { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
    }
}