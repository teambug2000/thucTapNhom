using DAO.DataProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;
using System.Data.SqlClient;

namespace DAO.DAO
{
    public class TestDAO
    {
        private static TestDAO instance;

        public static TestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestDAO();
                }
                return instance;
            }
        }

        private TestDAO()
        {
        }

        public void GetListQuestionByContestantInformation(ContestantInformation CI, out List<List<Questions>> rLLstQuest, out bool IsContinute, out int numberQuestionsOfTest, out ErrorController EC)
        {
            IsContinute = false;
            numberQuestionsOfTest = 0;
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                //try
                //{
                int count = 0;
                List<TEST_DETAILS> lstTD = DB.TEST_DETAILS.Where(x => x.TestID == CI.TestID).ToList();
                lstTD.OrderBy(x => x.NumberIndex);
                //Debug.WriteLine("lstTD.Count {0}", lstTD.Count);
                List<Questions> lstQuestions;
                List<List<Questions>> lstLQuestion = new List<List<Questions>>();
                Hashtable hstbAnswersheetDetail = null;

                if (CI.Status == Common.STATUS_DOING_BUT_INTERRUPT || CI.Status == Common.STATUS_LOGGED_DO_NOT_FINISH || CI.Status == Common.STATUS_DOING)
                {
                    hstbAnswersheetDetail = new Hashtable();
                    AnswersheetDetailDAO.Instance.GetHastableAnswersheetDetailByAnswerSheetID(CI, out hstbAnswersheetDetail, out EC);
                    IsContinute = true;
                }

                if (lstTD.Count > 0)
                {
                    List<SubQuestion> lstSubQuestiton = new List<SubQuestion>();
                    foreach (TEST_DETAILS td in lstTD)
                    {
                        lstQuestions = new List<Questions>();
                        lstSubQuestiton = GetListSubQuestionByQuestionID(td.QuestionID, td.TestID);
                        //int TypeQ = td.QUESTION.Type ?? default(int);
                        //if (TypeQ != 5)
                        //{
                        foreach (var sq in lstSubQuestiton.Select((value, index) => new { data = value, index = index }))
                        {
                            SUBQUESTION SQ = DB.SUBQUESTIONS.SingleOrDefault(x => x.SubQuestionID == sq.data.SubQuestionID);
                            Questions q = new Questions();
                            q.NO = td.NumberIndex + sq.index + 1;
                            // Todo
                            q.FormatQuestion = SQ.QUESTION.QuestionFormat;
                            q.TestDetailID = td.TestDetailID;
                            q.QuestionID = SQ.QuestionID;
                            q.SubQuestionID = SQ.SubQuestionID;
                            q.TestID = td.TestID;
                            q.TitleOfQuestion = SQ.SubQuestionContent;
                            q.AnswerChecked = 2000;
                            q.IsSingleChoice = SQ.QUESTION.IsSingleChoice;
                            q.IsQuestionContent = SQ.QUESTION.IsQuestionContent;

                            q.ListAnswer = GetListAnswerByListAnswerID(sq.data.ListAnswerID);

                            if (hstbAnswersheetDetail != null && (CI.Status == Common.STATUS_DOING_BUT_INTERRUPT || CI.Status == Common.STATUS_LOGGED_DO_NOT_FINISH || CI.Status == Common.STATUS_DOING))
                            {
                                q.AnswerChecked = 2000 + sq.data.ListAnswerID.IndexOf(Convert.ToInt32(hstbAnswersheetDetail[q.SubQuestionID])) + 1;
                            }

                            q.Type = SQ.QUESTION.Type ?? default(int);
                            count++;
                            lstQuestions.Add(q);

                            if (SQ.QUESTION.Audio != null)
                            {
                                lstQuestions.Insert(0, new Questions(SQ.QUESTION.Audio, SQ.QUESTION.QuestionFormat, q.Type));
                                lstQuestions.Insert(1, new Questions(SQ.QUESTION.QuestionContent, SQ.QUESTION.QuestionFormat));
                            }
                            if (lstQuestions.Count == SQ.QUESTION.NumberSubQuestion && SQ.QUESTION.NumberSubQuestion > 1)
                            {
                                lstQuestions.Insert(0, new Questions(SQ.QUESTION.QuestionContent, SQ.QUESTION.QuestionFormat));
                            }
                            Thread.Sleep(100);
                        }
                        lstLQuestion.Add(lstQuestions);
                        // }
                    }
                    numberQuestionsOfTest = count;
                    //Debug.WriteLine("lstLQuestion: " + lstLQuestion.Count);

                    rLLstQuest = lstLQuestion;
                    EC = new ErrorController(Common.STATUS_OK, "Get list questions successfully by TestID=" + CI.TestID);
                }
                else
                {
                    rLLstQuest = null;
                    EC = new ErrorController(Common.STATUS_ERROR, "Can not get TEST_DETAIL by TestID=" + CI.TestID);
                }
                //}
                //catch(Exception ex)
                //{
                //	rLLstQuest = null;
                //	EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
                //}
            }
        }

        private List<int> HandleGetNumberIdexAnswerInQuestion(string data)
        {
            List<int> lstIndex = new List<int>();

            string[] arrDataSplit = data.Split(',');
            foreach (string s in arrDataSplit)
            {
                lstIndex.Add(Convert.ToInt32(s));
            }
            return lstIndex;
        }

        private List<SubQuestion> GetListSubQuestionByQuestionID(int questionID, int testID)
        {
            List<SubQuestion> lstSubQuestiton = new List<SubQuestion>();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                TEST_DETAILS TD = DB.TEST_DETAILS.SingleOrDefault(x => x.QuestionID == questionID && x.TestID == testID);
                lstSubQuestiton = new JavaScriptSerializer().Deserialize<List<SubQuestion>>(TD.RandomAnswer);
            }
            return lstSubQuestiton;
        }

        private List<Answer> GetListAnswerByListAnswerID(List<int> lstAnswerID)
        {
            List<Answer> lstAnswer = new List<Answer>();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                foreach (int index in lstAnswerID)
                {
                    ANSWER A = DB.ANSWERS.Where(x => x.AnswerID == index).SingleOrDefault();
                    if (A != null)
                    {
                        lstAnswer.Add(new Answer(A.AnswerID, A.AnswerContent));
                    }
                }
            }
            return lstAnswer;
        }

        public double SumScore(ContestantInformation CI)
        {
            double result = 0;
            List<TEST_DETAILS> lstTD = new List<TEST_DETAILS>();

            List<SUBQUESTION> lstSub = new List<SUBQUESTION>();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                lstTD = DB.TEST_DETAILS.Where(x => x.TestID == CI.TestID).ToList();

                if (lstTD.Count > 0)
                {
                    foreach (TEST_DETAILS td in lstTD)
                    {
                        lstSub = DB.SUBQUESTIONS.Where(x => x.QuestionID == td.QuestionID).ToList();
                        foreach (SUBQUESTION sub in lstSub)
                        {
                            if (sub.QUESTION.Type == 4)
                            {
                                //TODO
                            }
                            else
                                result += sub.Score ?? default(double);
                        }
                    }
                }
            }
            return result;
        }

        public void UpMedia(byte[] buffer)
        {
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                QUESTION Q = new QUESTION();
                Q = DB.QUESTIONS.Where(x => x.QuestionID == 505).SingleOrDefault();
                Q.Audio = buffer;
                Q.Type = 1;
                DB.Entry(Q).State = EntityState.Modified;
                DB.SaveChanges();
            }
        }

        public double CheckAnswers(AnswersheetDetail ad)
        {
            double result = 0;
            int type;
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                ANSWERSHEET_DETAILS ans = new ANSWERSHEET_DETAILS();
                if (ad.AnswerContent != null)
                {
                    ans = DB.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetDetailID == ad.AnswerSheetDetailID).SingleOrDefault();

                    if (ans != null)
                    {
                        result = ans.Score ?? default(double);
                    }
                }
                else
                {
                    List<ANSWER> lstA = DB.ANSWERS.Where(x => x.SubQuestionID == ad.SubQuestionID).ToList();
                    if (lstA.Count > 0)
                    {
                        ANSWER A = lstA.SingleOrDefault(y => y.AnswerID == ad.ChoosenAnswer);
                        if (A != null)
                        {
                            if (A.IsCorrect)
                            {
                                result = A.SUBQUESTION.Score ?? default(double);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public EXON.Model.Models.TEST GetTestByDivisionShiftID(int DivisonShiftID, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.TEST _bagOFTest = new EXON.Model.Models.TEST();
                using (var command = new SqlCommand("select * from BAGOFTESTS where DivisonShiftID = @id", sql))
                {
                    command.Parameters.Add("@id", DivisonShiftID);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EXON.Model.Models.TEST bagOFTest = new EXON.Model.Models.TEST();
                            bagOFTest.BagOfTestID = Convert.ToInt32(reader["BagOfTestID"].ToString());
                           // bagOFTest.NumberOfTest = Convert.ToInt32(reader["NumberOfTest"].ToString());
                            bagOFTest.Status = Convert.ToInt32(reader["DivisionShiftID"].ToString());
                            //bagOFTest.DivisionShiftID = Convert.ToInt32(reader["ScheduleID"].ToString());
                            _bagOFTest = bagOFTest;
                        }
                    }
                }

                return _bagOFTest;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EXON.Model.Models.TEST InsertTestByBagOfTest(EXON.Model.Models.TEST test, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.TEST _test = new EXON.Model.Models.TEST();
                using (var command = new SqlCommand("INSERT INTO TESTS (TestDate, BagOfTestID, SubjectID, Status) output INSERTED.TestID VALUES (@testDate, @bagOfTestID, @subjectID, @status)", sql))
                {
                    command.Parameters.Add("@testDate", test.TestDate);
                    command.Parameters.Add("@bagOfTestID", test.BagOfTestID);
                    command.Parameters.Add("@subjectID", test.SubjectID);
                    command.Parameters.Add("@status", test.Status);
                    test.TestID = (int)command.ExecuteScalar();
                    _test = test;
                }
                return _test;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EXON.Model.Models.TEST UpdateTest(int DivisonShiftID, EXON.Model.Models.TEST test, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.TEST _test = new EXON.Model.Models.TEST();
                using (var command = new SqlCommand("UPDATE BAGOFTESTS SET NumberOfTest = @numberOfTest, Status = @status  WHERE DivisionShift = @divisionShift", sql))
                {
                    //command.Parameters.Add("@numberOfTest", bagOfTest.NumberOfTest);
                    command.Parameters.Add("@status", test.Status);
                   // command.Parameters.Add("@divisionShift", bagOfTest.DivisionShiftID);
                    command.ExecuteNonQuery();
                    _test = test;
                }
                return _test;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}