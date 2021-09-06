namespace CreateDB.QuizStorage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TESTNUMBER")]
    public partial class TESTNUMBER
    {
        [Key]
        public int IDTestNumber { get; set; }

        public int? ContestantShiftID { get; set; }

        [StringLength(10)]
        public string TestNumberIndex { get; set; }

        public virtual CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS { get; set; }
    }
}
