using DAO.DAO;
using DAO.DataProvider;
using EXON.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TestBUS
    {
        private static TestBUS instance;
        public static TestBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestBUS();
                }
                return instance;
            }
        }
        private TestBUS() { }
        public void GetListLQuestionByContestantInformation(ContestantInformation CI, out List<List<Questions>> rLstQuest, out bool IsContinute, out int numberQuestionsOfTest, out ErrorController EC)
        {
            TestDAO.Instance.GetListQuestionByContestantInformation(CI, out rLstQuest, out IsContinute, out numberQuestionsOfTest, out EC);
        }
        public double CheckAnswers(AnswersheetDetail ad)
        {
            return TestDAO.Instance.CheckAnswers(ad);
        }
        public double SumScore(ContestantInformation CI)
        {
            return TestDAO.Instance.SumScore(CI);
        }
        public TEST GetBagOfTestByDivisionShiftID(TEST test, SqlConnection sql)
        {
            return TestDAO.Instance.InsertTestByBagOfTest(test, sql);
        }
        public TEST InsertTestByBagOfTest(TEST test, SqlConnection sql)
        {
            return TestDAO.Instance.InsertTestByBagOfTest(test, sql);
        }
        public TEST UpdateBagOfTest(int DivisonShiftID, TEST bagOfTest, SqlConnection sql)
        {
            return TestDAO.Instance.UpdateTest(DivisonShiftID, bagOfTest, sql);
        }
    }
}
