using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class StructureDAO
    {
        private static StructureDAO instance;
        public static StructureDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StructureDAO();
                }
                return instance;
            }
        }

        private StructureDAO() { }
        public STRUCTURE GetStructure(int scheduleID, SqlConnection sql)
        {
            try
            {
                STRUCTURE _structure = new STRUCTURE();
                using (var command = new SqlCommand("select * from STRUCTURES where ScheduleID = @id", sql))
                {
                    command.Parameters.Add("@id", scheduleID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            STRUCTURE structure = new STRUCTURE();
                            structure.StructureID = Convert.ToInt32(reader["STRUCTUREID"].ToString());
                            structure.CreatedDate = Convert.ToInt32(reader["CreatedDate"].ToString());
                            structure.Status = Convert.ToInt32(reader["Status"].ToString());
                            structure.ScheduleID = Convert.ToInt32(reader["ScheduleID"].ToString());
                            structure.CreatedStaffID = Convert.ToInt32(reader["CreatedStaffID"].ToString());
                            _structure = structure;
                        }
                    }
                }

                return _structure;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
