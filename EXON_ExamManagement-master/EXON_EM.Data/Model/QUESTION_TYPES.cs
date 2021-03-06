namespace EXON_EM.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QUESTION_TYPES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION_TYPES()
        {
            QUESTIONS = new HashSet<QUESTION>();
        }

        [Key]
        public int QuestionTypeID { get; set; }

        [Required]
        [StringLength(250)]
        public string QuestionTypeName { get; set; }

        public string Description { get; set; }

        public bool IsSingleChoice { get; set; }

        public bool IsParagraph { get; set; }

        public bool IsQuestionContent { get; set; }

        public int NumberSubQuestion { get; set; }

        public int NumberAnswer { get; set; }

        public int Status { get; set; }

        public bool IsQuiz { get; set; }

        public int? Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }
    }
}
