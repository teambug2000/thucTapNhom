namespace CreateDB.QuizMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPEAKING_TEACHER
    {
        [StringLength(10)]
        public string ID { get; set; }

        public int AnswerSheetSpeakingID { get; set; }

        public int? TeacherID { get; set; }

        public int? Status { get; set; }

        public virtual ANSWERSHEET_SPEAKING ANSWERSHEET_SPEAKING { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}
