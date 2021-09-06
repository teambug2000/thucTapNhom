using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.Common
{
    public class InfoContestant
    {
        public int STT { get; set; }
        public string ContestantCode { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string IdCardNumber { get; set; }
        public string CurrentAddress { get; set; }
        public string LocationCode { get; set; }
        public string Roomtest { get; set; }
        public DateTime ExamDate { get; set; }
        public string Shift { set; get; }
        public string ExamTime { get; set; }
        public String KhoiThi { get; set; }
    }

    public class KhoiThi
    {
        public KhoiThi()
        {
            ListMonThi = new List<string>();
        }

        public string Ten { get; set; }
        public List<String> ListMonThi { get; set; }
    }

    public class DiaDiem
    {
        public string TenDiaDiem { get; set; }
        public string MaDiaDiem { get; set; }
    }
}