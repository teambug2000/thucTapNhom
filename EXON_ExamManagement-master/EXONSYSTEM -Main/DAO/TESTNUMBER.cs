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
    
    public partial class TESTNUMBER
    {
        public int IDTestNumber { get; set; }
        public Nullable<int> ContestantShiftID { get; set; }
        public string TestNumberIndex { get; set; }
    
        public virtual CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS { get; set; }
    }
}