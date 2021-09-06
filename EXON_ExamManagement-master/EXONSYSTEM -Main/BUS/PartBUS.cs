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
    public class PartBUS
    {
        private static PartBUS instance;
        public static PartBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartBUS();
                }
                return instance;
            }
        }
        private PartBUS() { }

        public List<PART> GetAllPart(int scheduleID, List<PART> rListPart, SqlConnection sql)
        {
            return PartDAO.Instance.GetAllPart(scheduleID, rListPart, sql);
        }
    }
}
