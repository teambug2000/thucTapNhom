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
    
    public partial class EXAMINATIONCOUNCIL_STAFFS
    {
        public int ExaminationCouncil_StaffID { get; set; }
        public Nullable<int> StaffID { get; set; }
        public Nullable<int> ExaminationCouncil_PositionID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public Nullable<int> ContestID { get; set; }
    
        public virtual CONTEST CONTEST { get; set; }
        public virtual EXAMINATIONCOUNCIL_POSITIONS EXAMINATIONCOUNCIL_POSITIONS { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}
