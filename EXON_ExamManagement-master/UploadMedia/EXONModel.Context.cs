﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EXON_SYSTEM2Entities : DbContext
    {
        public EXON_SYSTEM2Entities()
            : base("name=EXON_SYSTEM2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ANSWER> ANSWERS { get; set; }
        public virtual DbSet<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual DbSet<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual DbSet<BAGOFTEST> BAGOFTESTS { get; set; }
        public virtual DbSet<CONTEST_FEES> CONTEST_FEES { get; set; }
        public virtual DbSet<CONTEST_TYPES> CONTEST_TYPES { get; set; }
        public virtual DbSet<CONTESTANT_TYPES> CONTESTANT_TYPES { get; set; }
        public virtual DbSet<CONTESTANT> CONTESTANTS { get; set; }
        public virtual DbSet<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }
        public virtual DbSet<CONTESTANTS_SUBJECTS> CONTESTANTS_SUBJECTS { get; set; }
        public virtual DbSet<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }
        public virtual DbSet<CONTEST> CONTESTS { get; set; }
        public virtual DbSet<DEMO_FINGERPRINTS> DEMO_FINGERPRINTS { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_POSITIONS> EXAMINATIONCOUNCIL_POSITIONS { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        public virtual DbSet<FINGERPRINT> FINGERPRINTS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<MODULE> MODULES { get; set; }
        public virtual DbSet<ORIGINAL_TEST_DETAILS> ORIGINAL_TEST_DETAILS { get; set; }
        public virtual DbSet<ORIGINAL_TESTS> ORIGINAL_TESTS { get; set; }
        public virtual DbSet<POSITION> POSITIONS { get; set; }
        public virtual DbSet<QUESTION_TYPES> QUESTION_TYPES { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<RECEIPT> RECEIPTS { get; set; }
        public virtual DbSet<REGISTER> REGISTERS { get; set; }
        public virtual DbSet<REGISTERS_SUBJECTS> REGISTERS_SUBJECTS { get; set; }
        public virtual DbSet<REMINDER> REMINDERS { get; set; }
        public virtual DbSet<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }
        public virtual DbSet<ROOMTEST> ROOMTESTS { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULES { get; set; }
        public virtual DbSet<SHIFT> SHIFTS { get; set; }
        public virtual DbSet<STAFF> STAFFS { get; set; }
        public virtual DbSet<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
        public virtual DbSet<STRUCTURE_DETAILS> STRUCTURE_DETAILS { get; set; }
        public virtual DbSet<STRUCTURE> STRUCTURES { get; set; }
        public virtual DbSet<SUBJECT> SUBJECTS { get; set; }
        public virtual DbSet<SUBQUESTION> SUBQUESTIONS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TEST_DETAILS> TEST_DETAILS { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
        public virtual DbSet<TOPIC> TOPICS { get; set; }
        public virtual DbSet<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }
        public virtual DbSet<VIOLATION> VIOLATIONS { get; set; }
        public virtual DbSet<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
    }
}