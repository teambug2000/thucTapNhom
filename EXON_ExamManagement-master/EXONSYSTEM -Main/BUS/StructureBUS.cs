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
    public class StructureBUS
    {
        private static StructureBUS instance;
        public static StructureBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StructureBUS();
                }
                return instance;
            }
        }
        private StructureBUS() { }

        public STRUCTURE GetStructure(int scheduleID, SqlConnection sql)
        {
            return StructureDAO.Instance.GetStructure(scheduleID, sql);
        }
    }
}
