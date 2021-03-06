namespace CreateDB.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOPICS")]
    public partial class TOPIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOPIC()
        {
            PARTS_DETAILS = new HashSet<PARTS_DETAILS>();
            PARTS_SUBJECT_DETAILS = new HashSet<PARTS_SUBJECT_DETAILS>();
            QUESTIONS = new HashSet<QUESTION>();
            STRUCTURE_DETAILS = new HashSet<STRUCTURE_DETAILS>();
            STRUCTURE_SUBJECT_DETAILS = new HashSet<STRUCTURE_SUBJECT_DETAILS>();
            TOPICS_STAFFS = new HashSet<TOPICS_STAFFS>();
        }

        public int TopicID { get; set; }

        public string TopicName { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int SubjectID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTS_DETAILS> PARTS_DETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTS_SUBJECT_DETAILS> PARTS_SUBJECT_DETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE_DETAILS> STRUCTURE_DETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE_SUBJECT_DETAILS> STRUCTURE_SUBJECT_DETAILS { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }
    }
}
