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
    
    public partial class TOPICS_STAFFS
    {
        public int TopicStaffID { get; set; }
        public int BeginDate { get; set; }
        public int EndDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int TopicID { get; set; }
        public int TaskmasterStaffID { get; set; }
        public int AssignedStaffID { get; set; }
    
        public virtual STAFF STAFF { get; set; }
        public virtual STAFF STAFF1 { get; set; }
        public virtual TOPIC TOPIC { get; set; }
    }
}
