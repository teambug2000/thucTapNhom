using DAO;
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
    public class QuestionTypeBUS
    {
        private static QuestionTypeBUS instance;
        public static QuestionTypeBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestionTypeBUS();
                }
                return instance;
            }
        }
        private QuestionTypeBUS() { }

        public List<QUESTION_TYPES> GetAllQuesType(List<QUESTION_TYPES> rListQuesType, SqlConnection sql)
        {
            return QuestionTypeDAO.Instance.GetAllQuestionType(rListQuesType, sql);
        }
    }
}
