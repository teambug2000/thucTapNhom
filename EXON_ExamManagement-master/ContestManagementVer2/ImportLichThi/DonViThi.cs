using ContestManagementVer2.CSDL_Exonsytem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2.ImportLichThi
{
    public class DonViThi
    {
        /// <summary>
        /// Danh sách các môn thi tại địa điểm và phòng thi đó
        /// </summary>
        public LOCATION diadiem { get; set; }
        public ROOMTEST phongthi { get; set; }
        public DateTime ngaythi { get; set; }
        public int Kip { get; set; } // 0: sáng, 1: chiều
        public List<SCHEDULE> dsMonThi { get; set; }
    }
}
