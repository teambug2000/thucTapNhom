using DAO.DAO;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DivisionShiftBUS
    {
        private static DivisionShiftBUS instance;
        public static DivisionShiftBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DivisionShiftBUS();
                }
                return instance;
            }
        }
        private DivisionShiftBUS() { }

        public List<DIVISION_SHIFTS> GetAllDivisionShiftByShiftID(int currentShiftId, List<DIVISION_SHIFTS> listRoomShift, SqlConnection sql)
        {
            return DivisionShiftDAO.Instance.GetAllDivisionShiftByShiftID(currentShiftId, listRoomShift, sql);
        }
    }
}
