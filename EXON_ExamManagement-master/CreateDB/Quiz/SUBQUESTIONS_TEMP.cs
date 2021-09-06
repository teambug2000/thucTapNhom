namespace CreateDB.Quiz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUBQUESTIONS_TEMP
    {
        [Key]
        public int SubQuestionTempID { get; set; }

        public int SubQuestionID { get; set; }

        public string SubQuestionContent { get; set; }

        public double? Score { get; set; }

        public int QuestionID { get; set; }

        public int? QuestionTempID { get; set; }

        public int DivisionShiftID { get; set; }
    }
}
