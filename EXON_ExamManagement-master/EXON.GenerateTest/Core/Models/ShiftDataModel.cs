using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.GenerateTest.Core.Models
{
    public class ShiftDataModel
    {
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public string ShiftDate { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int SubjectID { get; set; }
        public int ScheduleID { get; set; }
        public int NumberContestant { get; set; }
    }
}
