using Microsoft.Reporting.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel;
using EXON.SubModel.Models;

namespace ReportRoomDiagrams
{
    public partial class FormPrintAnswer : Form
    {
        private CONTEST kithi = new CONTEST();
        private int id;
       
        private int dvs;
        private float index;
        public string Converts(string s)
        {
           
                System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
                // Convert the RTF to plain text.
                rtBox.Rtf = s;
             
            string plainText = rtBox.Text;


            return plainText;
                
        }

        public string CheckAnswer( string s)
        {
            string a = "";
            if (s == "")
            {
                a = "Thí sinh bỏ qua câu hỏi này";
                return a;
            }
            
            return s;
        }
       
        public FormPrintAnswer(int _ContestantShiftID)
        {
          MTAQuizDbContext  db = new MTAQuizDbContext();
            InitializeComponent();
           
            id = _ContestantShiftID;
            try
            {
                var index1 = (
                             from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == id).ToList()
                             from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                             from tn in db.TESTNUMBERs.Where(x => x.ContestantShiftID == cts.ContestantShiftID).ToList()
                             select tn.TestNumberIndex).ToList();
                index =(float)Convert.ToInt32(index1.FirstOrDefault())/1000;//số phách
            }
            catch(Exception ex)
            {

            }

        }
        string getans(List<ListAnwser> listans,int subid)
        {

            foreach (var it in listans)
            {
                if (subid == it.subid)
                {
                    return it.anwser;
                }
            }
            return "";
        }
        private void FormPrintAnswer_Load(object sender, EventArgs e)
        {
            try
            {
                MTAQuizDbContext  db = new MTAQuizDbContext();
           
            List<ListAnwser> listans = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id)                                   
                                        from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.ANSWERSHEET.ContestantTestID==ctt.ContestantTestID).ToList()
                                        from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID && x.QUESTION.Type==4).ToList()
                                      
                                        select new ListAnwser
                                        {
                                            anwser = aswdt.AnswerContent,
                                            subid = sqt.SubQuestionID,
                                        }
                         ).ToList();
                if (listans.Count != 0)
                {
                    var list = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                        from tdt in db.TEST_DETAILS.Where(x=>x.TestID==ctt.TestID).ToList()
                        from qt in db.QUESTIONS.Where(x => x.QuestionID == tdt.QuestionID && x.Type == 4).ToList()
                        from sqt in db.SUBQUESTIONS.Where(x => x.QuestionID == qt.QuestionID).ToList()
                        select new
                        {
                            question = sqt.SubQuestionContent,
                            testid = ctt.TestID,
                            answer=getans(listans, sqt.SubQuestionID),
                          
                        }
                        ).ToList();
         
           
                var shift = (
                             from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == id)
                             from sch in db.SCHEDULES.Where(x => x.ScheduleID == cts.ScheduleID).ToList()
                             from sj in db.SUBJECTS.Where(x => x.SubjectID == sch.SubjectID).ToList()                            
                             from sh in db.SHIFTS.Where(x => x.ShiftID == cts.DIVISION_SHIFTS.ShiftID)
                             select new
                             {
                                 shname = sh.ShiftName,
                                 contestid = sh.ContestID,
                                 subjectname = sj.SubjectName,
                                 divisionshiftID = cts.DivisionShiftID
                             }
                       ).FirstOrDefault();
                //var teacher = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                //               from asw in db.ANSWERSHEETS.Where(x => x.ContestantTestID == ctt.ContestantTestID).ToList()
                //               from aswr in db.ANSWERSHEET_WRITING.Where(x => x.AnswerSheetID == asw.AnswerSheetID).ToList()
                //               from wrt in db.WRITING_TEACHER.Where(x => x.AnswerSheetWritingID == aswr.AnswerSheetWritingID).ToList()
                //               select new
                //               {
                //                   idTeacher = wrt.ID
                //               }
                //            ).ToList();
             
                    kithi = db.CONTESTS.Where(x => x.ContestID == shift.contestid).FirstOrDefault();
                    ReportParameter[] listPara;
                    float testnumberindex = index + shift.divisionshiftID;
                    if (list.Count>1)
                    {
                        ReportParameter p = new ReportParameter("ShowTextbox", "false");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
                        listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToLower()),
                    new ReportParameter("CreateDate",DateTime.Now.ToString(@"\n\g\à\y\ dd \t\h\á\n\g\ MM \n\ă\m\ yyyy")),
                    new ReportParameter("Subject",shift.subjectname.ToString().ToUpper()),
                    new ReportParameter("ShiftName",shift.shname.ToString()),
                    new ReportParameter("ContestanShiftID",testnumberindex.ToString()),
                    new ReportParameter("Ques1",Converts(list[0].question.ToString())),
                    new ReportParameter("Answer1",CheckAnswer(list[0].answer.ToString())),
                    new ReportParameter("Ques2",Converts(list[1].question.ToString())),
                    new ReportParameter("Answer2",CheckAnswer(list[1].answer.ToString())),
                    new ReportParameter("Ques3",Converts(list[2].question.ToString())),
                    new ReportParameter("Answer3",CheckAnswer(list[2].answer.ToString())),
                    new ReportParameter("Ques4", Converts(list[3].question.ToString())),
                    new ReportParameter("Answer4",CheckAnswer(list[3].answer.ToString())),
                    new ReportParameter("Ques5", Converts(list[4].question.ToString())),
                    new ReportParameter("Answer5",CheckAnswer(list[4].answer.ToString())),
                    new ReportParameter("SubQuestionContant",Converts(list[5].question.ToString())),
                    new ReportParameter("AnswerContent",CheckAnswer(list[5].answer.ToString())),
                     };
                    }
                   else
                    {
                       
                        ReportParameter p = new ReportParameter("ShowTextbox", "true");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
                        listPara = new ReportParameter[]{

                    new ReportParameter("ContestName",kithi.ContestName.ToLower()),
                    new ReportParameter("CreateDate",DateTime.Now.ToString(@"\n\g\à\y\ dd \t\h\á\n\g\ MM \n\ă\m\ yyyy")),
                    new ReportParameter("Subject",shift.subjectname.ToString().ToUpper()),
                    new ReportParameter("ShiftName",shift.shname.ToString()),
                    new ReportParameter("ContestanShiftID",testnumberindex.ToString()),
                      new ReportParameter("Ques1", " "),
                    new ReportParameter("Answer1"," "),
                    new ReportParameter("Ques2"," "),
                    new ReportParameter("Answer2"," "),
                    new ReportParameter("Ques3"," "),
                    new ReportParameter("Answer3"," "),
                    new ReportParameter("Ques4", " "),
                    new ReportParameter("Answer4"," "),
                    new ReportParameter("Ques5", " "),
                    new ReportParameter("Answer5"," "),
                    new ReportParameter("SubQuestionContant",Converts(list[0].question.ToString())),
                    new ReportParameter("AnswerContent",CheckAnswer(list[0].answer.ToString())),
                        };
                    }
                    this.reportViewer1.LocalReport.SetParameters(listPara);
                    this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Thí sinh chưa hoàn thành bài thi");
                this.Dispose();
            }

            }
            catch (Exception ex)
            {
            }
        }
    }
    class ListAnwser
    {
        public string anwser { get; set; }
        public int subid { get; set;}
    }
}
