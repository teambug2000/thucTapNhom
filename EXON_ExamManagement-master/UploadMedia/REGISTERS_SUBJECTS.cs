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
    
    public partial class REGISTERS_SUBJECTS
    {
        public int RegisterSubjectID { get; set; }
        public int Status { get; set; }
        public int RegisterID { get; set; }
        public int SubjectID { get; set; }
    
        public virtual REGISTER REGISTER { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
    }
}