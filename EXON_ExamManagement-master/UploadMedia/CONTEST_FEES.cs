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
    
    public partial class CONTEST_FEES
    {
        public int ContestFee { get; set; }
        public Nullable<double> Cost { get; set; }
        public string Unit { get; set; }
        public Nullable<int> Year { get; set; }
        public int Status { get; set; }
        public Nullable<int> FreeType { get; set; }
        public Nullable<int> ContestID { get; set; }
    
        public virtual CONTEST CONTEST { get; set; }
    }
}
