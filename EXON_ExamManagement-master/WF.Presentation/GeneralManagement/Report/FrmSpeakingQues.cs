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
using CL.Persistance.Model;
namespace ReportRoomDiagrams
{
    public partial class FrmSpeakingQues : Form
    {
        private CONTEST kithi = new CONTEST();
        private string sj;
        private int id;
        private int dvs;
        public FrmSpeakingQues(int ContestantTestID, CONTEST _kt, int subjectID, int divisionShiftID)
        {
            MTAQuizEntities db = new   MTAQuizEntities();
            InitializeComponent();
            kithi = _kt;
            sj = db.SUBJECTS.Where(x => x.SubjectID == subjectID).FirstOrDefault().SubjectName.ToString();
            id = ContestantTestID;
            dvs = divisionShiftID;
        }
        public DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
        public string Converts(string s)
        {

            System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
            // Convert the RTF to plain text.
            rtBox.Rtf = s;

            string plainText = rtBox.Text;


            return plainText;

        }
        public string CheckQuestion(string s)
        {
            string a = "";
            if (s == "")
            {
                a = "";
                return a;
            }

            return s;
        }
        private void FrmSpeakingQues_Load(object sender, EventArgs e)
        {

            MTAQuizEntities db = new MTAQuizEntities();
            var list = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantTestID == id).ToList()
                        from asw in db.ANSWERSHEETS.Where(x => x.ContestantTestID == ctt.ContestantTestID).ToList()
                        from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetID == asw.AnswerSheetID).ToList()
                        from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID).ToList()
                        from qt in db.QUESTIONS.Where(x => x.QuestionID == sqt.QuestionID && x.Type == 5).ToList()
                        from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == ctt.ContestantShiftID).ToList()
                        from sch in db.SCHEDULES.Where(x => x.ScheduleID == cts.ScheduleID).ToList()
                        from sj in db.SUBJECTS.Where(x => x.SubjectID == sch.SubjectID && x.SubjectName == sj).ToList()
                        from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == cts.DivisionShiftID && x.DivisionShiftID == dvs).ToList()
                        from aswsp in db.ANSWERSHEET_SPEAKING.Where(x => x.AnswerSheetID == asw.AnswerSheetID).ToList()
                        select new
                        {
                            bigQuestion = qt.QuestionContent,
                            subQuestion = sqt.SubQuestionContent,
                        }
                        ).ToList();
            var shift = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantTestID == id).ToList()
                         from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == ctt.ContestantShiftID).ToList()
                         from sch in db.SCHEDULES.Where(x => x.ScheduleID == cts.ScheduleID).ToList()
                         from sj in db.SUBJECTS.Where(x => x.SubjectID == sch.SubjectID && x.SubjectName == sj).ToList()
                         from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == cts.DivisionShiftID && x.DivisionShiftID == dvs).ToList()
                         from sh in db.SHIFTS.Where(x => x.ShiftID == dvs.ShiftID)
                         select new
                         {
                             sh = sh.ShiftName
                         }
                         ).FirstOrDefault();

            var profile = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantTestID == id).ToList()
                           from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == ctt.ContestantShiftID).ToList()
                           from ct in db.CONTESTANTS.Where(x => x.ContestantID == cts.ContestantID).ToList()
                           select new
                           {
                               name = ct.FullName,
                               dob = ct.DOB,
                               code = ct.ContestantCode
                           }
                           ).ToList();

            ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToLower()),
                    new ReportParameter("CreateDate",DateTime.Now.ToString(@"\n\g\à\y\ dd \t\h\á\n\g\ MM \n\ă\m\ yyyy")),
                    new ReportParameter("Subject",sj.ToString().ToUpper()),
                    new ReportParameter("ShiftName",shift.sh.ToString()),
                    new ReportParameter("DOB",ConvertUnixToDateTime(Convert.ToInt32(profile[0].dob)).ToString(@" dd \/ MM \/ yyyy")),
                    new ReportParameter("FullName",profile[0].name),
                    new ReportParameter("Code",profile[0].code),
                    new ReportParameter("Question",CheckQuestion(Converts( list[0].bigQuestion.ToString()))),
                    new ReportParameter("SubQuestion",CheckQuestion(Converts( list[0].subQuestion.ToString()))),
                };
            this.reportViewer1.LocalReport.SetParameters(listPara);
            this.reportViewer1.RefreshReport();
        }
    }
}
