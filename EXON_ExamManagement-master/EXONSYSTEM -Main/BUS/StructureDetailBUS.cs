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
    public class StructureDetailBUS
    {
        private static StructureDetailBUS instance;
        public static StructureDetailBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StructureDetailBUS();
                }
                return instance;
            }
        }
        private StructureDetailBUS() { }

        public List<STRUCTURE_DETAILS> GetAllPartDetailByStrucIDAndTopicID(int structureID, int topicID , List<STRUCTURE_DETAILS> rListPartDetail, SqlConnection sql)
        {
            return StructureDetailDAO.Instance.GetAllPartDetailByStrucIDAndTopicID(structureID, topicID, rListPartDetail, sql);
        }
    }
}
