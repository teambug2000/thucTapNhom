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
    
    public partial class ANSWERSHEET_DETAILS
    {
        public int AnswerSheetDetailID { get; set; }
        public Nullable<int> ChoosenAnswer { get; set; }
        public string AnswerContent { get; set; }
        public Nullable<int> LastTime { get; set; }
        public int Status { get; set; }
        public int AnswerSheetID { get; set; }
        public int SubQuestionID { get; set; }
        public Nullable<double> Score { get; set; }
        public string Comment { get; set; }
    
        public virtual SUBQUESTION SUBQUESTION { get; set; }
        public virtual ANSWERSHEET ANSWERSHEET { get; set; }
    }
}
