using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class StructureDetailDAO
    {
        private static StructureDetailDAO instance;
        public static StructureDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StructureDetailDAO();
                }
                return instance;
            }
        }

        private StructureDetailDAO() { }
        public List<STRUCTURE_DETAILS> GetAllPartDetailByStrucIDAndTopicID(int structureID, int topicID , List<STRUCTURE_DETAILS> rListPartDetail, SqlConnection sql)
        {
            try
            {

                using (var command = new SqlCommand("select * from STRUCTURE_DETAILS where StructureID = @structureid and TopicID = @topicid ", sql))
                {
                    command.Parameters.Add("@structureid", structureID);
                    command.Parameters.Add("@topicid", topicID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            STRUCTURE_DETAILS STRUCTURE_DETAILS = new STRUCTURE_DETAILS();
                            STRUCTURE_DETAILS.StructureDetailID = Convert.ToInt32(reader["StructureDetailID"].ToString());
                            STRUCTURE_DETAILS.NumberQuestions = Convert.ToInt32(reader["NumberQuestions"].ToString());
                            STRUCTURE_DETAILS.TopicID = Convert.ToInt32(reader["TopicID"].ToString());
                            STRUCTURE_DETAILS.StructureID = Convert.ToInt32(reader["StructureID"].ToString());
                            STRUCTURE_DETAILS.Status = Convert.ToInt32(reader["Status"].ToString());
                            STRUCTURE_DETAILS.Level = Convert.ToInt32(reader["Level"].ToString());
                            STRUCTURE_DETAILS.Score = Convert.ToInt32(reader["Score"].ToString());
                            rListPartDetail.Add(STRUCTURE_DETAILS);
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
