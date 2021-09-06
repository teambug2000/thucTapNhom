using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class TopicDAO
    {
        private static TopicDAO instance;
        public static TopicDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TopicDAO();
                }
                return instance;
            }
        }

        private TopicDAO() { }
        public List<TOPIC> GetAllTopic(int subjectID, List<TOPIC> rListTopic, SqlConnection sql)
        {
            try
            {

                using (var command = new SqlCommand("select * from TOPICS where SubjectID = @id", sql))
                {
                    command.Parameters.Add("@id", subjectID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TOPIC TOPIC = new TOPIC();
                            TOPIC.TopicID = Convert.ToInt32(reader["TopicID"].ToString());
                            TOPIC.TopicName = reader["TopicName"].ToString();
                            TOPIC.Description = reader["Description"].ToString();
                            TOPIC.Status = Convert.ToInt32(reader["Status"].ToString());
                            TOPIC.SubjectID = Convert.ToInt32(reader["SubjectID"].ToString());
                            rListTopic.Add(TOPIC);
                        }
                    }
                }

                return rListTopic;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
