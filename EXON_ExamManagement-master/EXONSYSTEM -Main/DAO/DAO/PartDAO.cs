using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class PartDAO
    {
        private static PartDAO instance;
        public static PartDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartDAO();
                }
                return instance;
            }
        }

        private PartDAO() { }
        public List<PART> GetAllPart(int scheduleID,  List<PART> rListPart, SqlConnection sql)
        {
            try
            {
                
                using (var command = new SqlCommand("select * from PARTS where ScheduleID = @id", sql))
                {
                    command.Parameters.Add("@id", scheduleID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PART part = new PART();
                            part.PartID = Convert.ToInt32(reader["PartID"].ToString());
                            part.CreatedDate = Convert.ToInt32(reader["CreatedDate"].ToString());
                            part.Status = Convert.ToInt32(reader["Status"].ToString());
                            part.ScheduleID = Convert.ToInt32(reader["ScheduleID"].ToString());
                            part.CreateStaffID = Convert.ToInt32(reader["CreateStaffID"].ToString());
                            part.Name = reader["Name"].ToString();
                            part.OrderOfQuestion= Convert.ToInt32(reader["OrderOfQuestion"].ToString());
                            part.OrderInTest = Convert.ToInt32(reader["OrderInTest"].ToString());
                            part.Shuffle = Convert.ToInt32(reader["Shuffle"].ToString());
                            rListPart.Add(part);
                        }
                    }
                }

                return rListPart;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
