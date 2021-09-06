using DAO.DataProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
	public class AnswersheetDetailDAO
	{
		private static AnswersheetDetailDAO instance;
		public static AnswersheetDetailDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AnswersheetDetailDAO();
				}
				return instance;
			}
		}
		private AnswersheetDetailDAO() { }
		public void PushAnswerSheetDetail(AnswersheetDetail ansSheetDetail, out ErrorController EC)
		{
            int Type;
            using (EXON_SYSTEM_TESTEntities db = new EXON_SYSTEM_TESTEntities())
            {
                using (DbContextTransaction dbtr = db.Database.BeginTransaction())
                {

                    try
                    {

                        ANSWERSHEET_DETAILS AD = db.ANSWERSHEET_DETAILS.SingleOrDefault(x => x.AnswerSheetID == ansSheetDetail.AnswerSheetID && x.SubQuestionID ==ansSheetDetail.SubQuestionID);
                        if (AD != null)
                            {
                            ANSWER ans = new ANSWER();
                            if (ansSheetDetail.AnswerContent != null)
                            {
                                ans = db.ANSWERS.Where(x => x.SubQuestionID == ansSheetDetail.SubQuestionID).SingleOrDefault();
                                if (ans != null)
                                {
                                    Type = ans.SUBQUESTION.QUESTION.Type ?? default(int);
                                    if (Type ==2|| Type== 3)
                                    {
                                        List<string> lstAnswerContent = new List<string>();
                                        lstAnswerContent = TachDapAn(ans.AnswerContent);
                                        string strTraLoi = ChuanHoa(ansSheetDetail.AnswerContent);
                                       
                                        foreach(string ansc in lstAnswerContent)
                                        {
                                            string strDapAn = ChuanHoa(ansc);
                                            if (CheckAnswerContent(strDapAn, strTraLoi))
                                            {
                                                AD.Score = ans.SUBQUESTION.Score;
                                                break;
                                            }
                                        }
                                        
                                     
                                    }
                                    else
                                    {
                                        AD.Score = 0;
                                    }
                                }
                            }
                            AD.ChoosenAnswer = ansSheetDetail.ChoosenAnswer;
                            AD.LastTime = ansSheetDetail.LastTime;
                            AD.SubQuestionID = ansSheetDetail.SubQuestionID;
                           AD.AnswerContent = ansSheetDetail.AnswerContent;
                            AD.Status = Common.STATUS_CHANGED;
                            db.Entry(AD).State = EntityState.Modified;
                            db.SaveChanges();
                            dbtr.Commit();
                            EC = new ErrorController(Common.STATUS_OK, "Change status to STATUS_CHANGED: 4002");

                        }
                        else
                        {
                            ANSWERSHEET_DETAILS dbAnsSheetDetail = new ANSWERSHEET_DETAILS();
                            ANSWER ans = new ANSWER();
                            if (ansSheetDetail.AnswerContent != null )
                            {
                                ans = db.ANSWERS.Where(x => x.SubQuestionID == ansSheetDetail.SubQuestionID).SingleOrDefault();
                                if (ans != null)
                                {
                                    Type = ans.SUBQUESTION.QUESTION.Type ?? default(int);
                                    if (ans.AnswerContent == ansSheetDetail.AnswerContent && (Type == 2 || Type == 3))
                                    {
                                        dbAnsSheetDetail.Score = ans.SUBQUESTION.Score;
                                    }
                                    else
                                    {
                                        dbAnsSheetDetail.Score = 0;
                                    }
                                }
                            }
                         
                            dbAnsSheetDetail.AnswerSheetID = ansSheetDetail.AnswerSheetID;
                            dbAnsSheetDetail.ChoosenAnswer = ansSheetDetail.ChoosenAnswer;
                            if (ansSheetDetail.AnswerContent != null)
                            {
                                dbAnsSheetDetail.AnswerContent = ansSheetDetail.AnswerContent;
                            }
                            dbAnsSheetDetail.LastTime = ansSheetDetail.LastTime;
                            dbAnsSheetDetail.SubQuestionID = ansSheetDetail.SubQuestionID;
                            dbAnsSheetDetail.Status = Common.STATUS_INITIALIZE;
                            db.ANSWERSHEET_DETAILS.Add(dbAnsSheetDetail);
                            db.SaveChanges();
                            dbtr.Commit();
                            EC = new ErrorController(Common.STATUS_OK, "Add new ANSWERSHEET_DETAIL with  STATUS_INITIALIZE: 4001");
                        }
                    }
                    catch (Exception ex)
                    {
                        dbtr.Rollback();
                        EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
                    }
                }
            }
		}

        private List<string> TachDapAn(string answerContent)
        {
            List<string> lstAnswerContent = new List<string>();
            string[] arrLstString;
            if (answerContent.Contains("/") )
            {
                 arrLstString = answerContent.Split('/');
                lstAnswerContent = arrLstString.ToList();
            }
            else if( answerContent.Contains("\\"))
            {
                arrLstString = answerContent.Split('\\');
                lstAnswerContent = arrLstString.ToList();
            }
            else
            {
                lstAnswerContent.Add(answerContent);
            }
            return lstAnswerContent;
        }

        private string ChuanHoa(string answerContent)
        {
            string s = answerContent.Trim();
            while (s.IndexOf("  ") >= 0)
            {
                s = s.Replace("  ", " ");
            }
            StringBuilder kq = new StringBuilder(s.Length);
            foreach (char c in s)
            {
                if (Char.IsLower(c))
                {
                    kq.Append(char.ToUpper(c));
                }
                else kq.Append(c);

            }
            return kq.ToString();
        }

        private bool CheckAnswerContent(string strDapAn,  string strTraLoi)
        {
            //TODO
            if(strDapAn==strTraLoi)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetHastableAnswersheetDetailByAnswerSheetID(ContestantInformation CI, out Hashtable hstbAnswersheetDetailOut, out ErrorController EC)
		{
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				try
				{
					ANSWERSHEET ANS = DB.ANSWERSHEETS.SingleOrDefault(x => x.ContestantTestID == CI.ContestantTestID);
					if (ANS != null)
					{
						Hashtable hstbAnswersheetDetail = new Hashtable();
						List<AnswersheetDetail> lstAnswersheetDetail = new List<AnswersheetDetail>();
						List<ANSWERSHEET_DETAILS> lstDBAnswersheetDetail = DB.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetID == CI.AnswerSheetID).ToList();
						foreach (ANSWERSHEET_DETAILS AD in lstDBAnswersheetDetail)
						{
                            
							hstbAnswersheetDetail.Add(AD.SubQuestionID, AD.ChoosenAnswer);
						}
						hstbAnswersheetDetailOut = hstbAnswersheetDetail;
						EC = new ErrorController(Common.STATUS_OK, "Get list answer successfully");
					}
					else
					{
						EC = new ErrorController(Common.STATUS_ERROR, "Can not get ANSWERSHEET");
						hstbAnswersheetDetailOut = null;
					}
				}
				catch(Exception ex)
				{
					hstbAnswersheetDetailOut = null;
					EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
				}
			}
		}
		public void GetListAnswerSheetDetail(ContestantInformation CI, out List<AnswersheetDetail> rListASD)
		{
			AnswersheetDetail AHD;
			List<AnswersheetDetail> lstAD = new List<AnswersheetDetail>();
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				List<ANSWERSHEET_DETAILS> lstAHD = DB.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetID == CI.AnswerSheetID).ToList();
				foreach (ANSWERSHEET_DETAILS ahd in lstAHD)
				{
					AHD = new AnswersheetDetail();
					AHD.ChoosenAnswer = ahd.ChoosenAnswer ?? default(int);
					AHD.SubQuestionID = ahd.SubQuestionID;
					AHD.AnswerSheetID = ahd.AnswerSheetID;
                    AHD.AnswerContent = ahd.AnswerContent;
                    AHD.AnswerSheetDetailID = ahd.AnswerSheetDetailID;
                  
					lstAD.Add(AHD);
				}
				rListASD = lstAD;
			}
		}
	}
}
