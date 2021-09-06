using Microsoft.Reporting.WinForms;
using CL.Persistance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ReportRoomDiagrams
{
    
    public partial class FrmAllSpQues : Form
    {
        private CONTEST kithi = new CONTEST();
     

        private string sj;
        private int dvs;
        public FrmAllSpQues( int divisionShiftID)
        {
            
            InitializeComponent();         
          MTAQuizEntities db = new MTAQuizEntities();         
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
        private void FrmAllSpQues_Load(object sender, EventArgs e)
        {
            MTAQuizEntities db = new MTAQuizEntities();
            var shift = (
                         from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == dvs).ToList()
                         from cts in db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == dvs.DivisionShiftID).ToList()
                         from sch in db.SCHEDULES.Where(x => x.ScheduleID == cts.ScheduleID).ToList()
                         from sh in db.SHIFTS.Where(x => x.ShiftID == dvs.ShiftID)
                         from sj in db.SUBJECTS.Where(x => x.SubjectID == sch.SubjectID).ToList()
                         select new
                         {
                             sh = sh.ShiftName,
                             sj = sj.SubjectName,
                             ct = sh.CONTEST.ContestName
                         }
                        ).FirstOrDefault();
            int i = 1;
            var list = (
                        from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == dvs).ToList()
                        from cts in db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == dvs.DivisionShiftID).ToList()
                        from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == cts.ContestantShiftID).ToList()
                        from ct in db.CONTESTANTS.Where(x => x.ContestantID == cts.ContestantID).ToList()
                        from asw in db.ANSWERSHEETS.Where(x => x.ContestantTestID == ctt.ContestantTestID).ToList()
                        from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetID == asw.AnswerSheetID).ToList()
                        from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID).ToList()
                        from qt in db.QUESTIONS.Where(x => x.QuestionID == sqt.QuestionID && x.Type == 5).ToList()
                        select new
                        {
                            Order = i++,
                            Name = ct.FullName,
                            ContestantCode = ct.ContestantCode,
                            DOB = ConvertUnixToDateTime(Convert.ToInt32(ct.DOB)).ToString(@" dd \/ MM \/ yyyy"),
                            SubQues = Converts(sqt.SubQuestionContent)
                        }
                ).ToList();
           
            SpeakingQuesBindingSource.DataSource = list.GroupBy(x => x.ContestantCode)
                                                        .Select(g => g.First())
                                                        .ToList();
           
            ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",shift.ct.ToLower()),
                    new ReportParameter("CreateDate",DateTime.Now.ToString(@"\n\g\à\y\ dd \t\h\á\n\g\ MM \n\ă\m\ yyyy")),
                    new ReportParameter("Subject",shift.sj.ToString().ToUpper()),
                    new ReportParameter("ShiftName",shift.sh.ToString()),
                        };
            try
            {
                this.reportViewer1.LocalReport.SetParameters(listPara);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
