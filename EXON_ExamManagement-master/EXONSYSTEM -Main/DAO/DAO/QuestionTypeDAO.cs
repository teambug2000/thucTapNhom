using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{

    public class QuestionTypeDAO
    {
        private static QuestionTypeDAO instance;
        public static QuestionTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestionTypeDAO();
                }
                return instance;
            }
        }

        private QuestionTypeDAO() { }
        public List<QUESTION_TYPES> GetAllQuestionType(List<QUESTION_TYPES> rListQuesType, SqlConnection sql)
        {
            try
            {

                using (var command = new SqlCommand("select * from QUESTION_TYPESS", sql))
                {
                    //command.Parameters.Add("@id", subjectID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            QUESTION_TYPES QUESTION_TYPES = new QUESTION_TYPES();
                            QUESTION_TYPES.QuestionTypeID = Convert.ToInt32(reader["QUESTION_TYPESID"].ToString());
                            QUESTION_TYPES.QuestionTypeName = reader["QuestionTypeName"].ToString();
                            QUESTION_TYPES.Description = reader["Description"].ToString();
                            QUESTION_TYPES.IsSingleChoice = Convert.ToBoolean(reader["IsSingleChoice"].ToString());
                            QUESTION_TYPES.IsParagraph = Convert.ToBoolean(reader["IsParagraph"].ToString());
                            QUESTION_TYPES.IsQuestionContent = Convert.ToBoolean(reader["IsQuestionContent"].ToString());
                            QUESTION_TYPES.IsQuiz = Convert.ToBoolean(reader["IsQuiz"].ToString());
                            QUESTION_TYPES.NumberSubQuestion = Convert.ToInt32(reader["NumberSubQuestion"].ToString());
                            QUESTION_TYPES.NumberAnswer = Convert.ToInt32(reader["NumberAnswer"].ToString());
                            QUESTION_TYPES.Status = Convert.ToInt32(reader["Status"].ToString());
                            QUESTION_TYPES.Type = Convert.ToInt32(reader["Type"].ToString());
                            rListQuesType.Add(QUESTION_TYPES);
                        }
                    }
                }

                return rListQuesType;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
