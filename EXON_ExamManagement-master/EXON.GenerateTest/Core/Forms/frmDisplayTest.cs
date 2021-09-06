using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
using EXON.GenerateTest.Core.Controls;
using EXON.GenerateTest.Core.Forms;
using EXON.GenerateTest.Core.Helper;
using EXON.GenerateTest.Core.Models;
using EXON.GenerateTest.Core.Tags;
using EXON.GenerateTest.Settings;
using EXON.Model.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest.Core.Forms
{
    public partial class frmDisplayTest : BaseForm
    {
        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;
        private ContestantShiftService _ContestantShiftService;
        private SubjectService _SubjectService;
        private StructureDetailService _StructureDetailService;
        private StructureService _StructureService;
        private TopicService _TopicService;
        private QuestionService _QuestionService;
        private OriginalTestService _OriginalTestService;
        private OriginalTestDetailService _OriginalTestDetailService;
        private BagOfTestService _BagOfTestService;
        private DivisionShiftService _DivisionShiftService;
        private TestService _TestService;
        private TestDetailService _TestDetailService;
        private SubQuestionService _SubQuestionService;
        private AnswerService _AnswerService;
        private QuestionTypeService _QuestionTypeService;
        private void InitializeService()
        {
            _ContestService = new ContestService();
            _ShiftService = new ShiftService();
            _ScheduleService = new ScheduleService();
            _ContestantShiftService = new ContestantShiftService();
            _SubjectService = new SubjectService();
            _StructureDetailService = new StructureDetailService();
            _StructureService = new StructureService();
            _TopicService = new TopicService();
            _QuestionService = new QuestionService();
            _OriginalTestService = new OriginalTestService();
            _OriginalTestDetailService = new OriginalTestDetailService();
            _BagOfTestService = new BagOfTestService();
            _DivisionShiftService = new DivisionShiftService();
            _TestService = new TestService();
            _TestDetailService = new TestDetailService();
            _SubQuestionService = new SubQuestionService();
            _AnswerService = new AnswerService();
            _QuestionTypeService = new QuestionTypeService();
        }
        public frmDisplayTest(int TestID)
        {
            InitializeComponent();
            InitializeService();
            DisplayTest(TestID);
        }
        protected void UnloadTabpage(TabPage page)
        {
            while (page.Controls.Count > 0) page.Controls[0].Dispose();
        }
        private void DisplayTest(int TestID)
        {
            foreach (TabPage t in tabControl1.TabPages)
            {
                UnloadTabpage(t);
            }
        
             tabControl1.TabPages.Clear();
            #region Display Test
            var test = _TestService.GetById(TestID);
            if (test != null )
            {
                SplashScreenManager.ShowSplashScreen();


                List<TEST_DETAILS> listTestDetails = _TestDetailService.GetAll(TestID).ToList();
                List<QUESTION> testQuestion = (from otd in listTestDetails
                                               from q in _QuestionService.GetAll()
                                               where otd.QuestionID == q.QuestionID
                                               select q).ToList();
                //Tab page index

                Panel pnTest = new Panel();
                pnTest.AutoScroll = true;
                pnTest.Dock = DockStyle.Fill;

                TabPage tpTest = new TabPage();
                tpTest.Name = test.TestID.ToString();
                tpTest.Text = "Mã đề " + test.TestID.ToString();
                tpTest.UseVisualStyleBackColor = true;
                tpTest.Padding = new System.Windows.Forms.Padding(3);
                tpTest.Controls.Add(pnTest);

                tabControl1.TabPages.Add(tpTest);

                int index = 1;
                List<Control> listUc = new List<Control>();
                foreach (QUESTION q in testQuestion)
                {
                    ucDisplayQuestion display = new ucDisplayQuestion(q.QuestionID, ref index);
                    display.Accepted(false);
                    listUc.Add(display);
                }
                listUc.Reverse();
                pnTest.Controls.AddRange(listUc.ToArray());

                #endregion Display Test

                SplashScreenManager.CloseForm(); 
            }
        }

    }
}