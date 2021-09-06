using ContestManagementVer2.CSDL_Exonsytem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2.DAO
{
    public class ContestantOfLocation
    {
        public int LocationID { get; set; }
        public List<CONTESTANT> listThiSinh { get; set; }
    }
}
