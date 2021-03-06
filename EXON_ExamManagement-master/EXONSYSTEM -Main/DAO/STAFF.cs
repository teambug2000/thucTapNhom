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
    
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            this.ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            this.DIVISIONSHIFT_SUPERVISOR = new HashSet<DIVISIONSHIFT_SUPERVISOR>();
            this.EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            this.SPEAKING_TEACHER = new HashSet<SPEAKING_TEACHER>();
            this.STAFFS_POSITIONS = new HashSet<STAFFS_POSITIONS>();
            this.WRITING_TEACHER = new HashSet<WRITING_TEACHER>();
        }
    
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public Nullable<int> DOB { get; set; }
        public Nullable<int> Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string AcademicRank { get; set; }
        public string Degree { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIVISIONSHIFT_SUPERVISOR> DIVISIONSHIFT_SUPERVISOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPEAKING_TEACHER> SPEAKING_TEACHER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WRITING_TEACHER> WRITING_TEACHER { get; set; }
    }
}
