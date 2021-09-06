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
    
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            this.ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            this.CONTESTS = new HashSet<CONTEST>();
            this.CONTESTS1 = new HashSet<CONTEST>();
            this.DIVISION_SHIFTS = new HashSet<DIVISION_SHIFTS>();
            this.EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            this.QUESTIONS = new HashSet<QUESTION>();
            this.QUESTIONS1 = new HashSet<QUESTION>();
            this.RECEIPTS = new HashSet<RECEIPT>();
            this.REMINDERS = new HashSet<REMINDER>();
            this.REMINDERS1 = new HashSet<REMINDER>();
            this.STRUCTURES = new HashSet<STRUCTURE>();
            this.TOPICS_STAFFS = new HashSet<TOPICS_STAFFS>();
            this.TOPICS_STAFFS1 = new HashSet<TOPICS_STAFFS>();
            this.STAFFS_POSITIONS = new HashSet<STAFFS_POSITIONS>();
        }
    
        public int StaffID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int DOB { get; set; }
        public int Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string AcademicRank { get; set; }
        public string Degree { get; set; }
        public string CurrentAddress { get; set; }
        public string MailAddress { get; set; }
        public int Status { get; set; }
        public int DepartmentID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTEST> CONTESTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTEST> CONTESTS1 { get; set; }
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEIPT> RECEIPTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE> STRUCTURES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOPICS_STAFFS> TOPICS_STAFFS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
    }
}
