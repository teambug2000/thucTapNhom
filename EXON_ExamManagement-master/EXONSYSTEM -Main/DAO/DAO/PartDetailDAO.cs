using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class PartDetailDAO
    {
        private static PartDetailDAO instance;
        public static PartDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartDetailDAO();
                }
                return instance;
            }
        }

        private PartDetailDAO() { }
        public List<PARTS_DETAILS> GetAllPartDetailByPartID(int partID, List<PARTS_DETAILS> rListPartDetail, SqlConnection sql)
        {
            try
            {

                using (var command = new SqlCommand("select * from PARTS_DETAILS where PartID = @id", sql))
                {
                    command.Parameters.Add("@id", partID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PARTS_DETAILS PARTS_DETAILS = new PARTS_DETAILS();
                            PARTS_DETAILS.PartDetailID = Convert.ToInt32(reader["PartDetailID"].ToString());
                            PARTS_DETAILS.PartID = Convert.ToInt32(reader["PartID"].ToString());
                            PARTS_DETAILS.TopicID = Convert.ToInt32(reader["TopicID"].ToString());
                            PARTS_DETAILS.OrderOfTopic = Convert.ToInt32(reader["OrderOfTopic"].ToString());
                            PARTS_DETAILS.Status = Convert.ToInt32(reader["Status"].ToString());
                            rListPartDetail.Add(PARTS_DETAILS);
                        }
                    }
                }

                return rListPartDetail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
