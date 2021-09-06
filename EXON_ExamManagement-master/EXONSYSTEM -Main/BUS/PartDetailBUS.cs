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
    public class PartDetailBUS
    {
        private static PartDetailBUS instance;
        public static PartDetailBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartDetailBUS();
                }
                return instance;
            }
        }
        private PartDetailBUS() { }

        public List<PARTS_DETAILS> GetAllPartDetailByPartID(int partID, List<PARTS_DETAILS> rListPartDetail, SqlConnection sql)
        {
            return PartDetailDAO.Instance.GetAllPartDetailByPartID(partID, rListPartDetail, sql);
        }
    }
}
