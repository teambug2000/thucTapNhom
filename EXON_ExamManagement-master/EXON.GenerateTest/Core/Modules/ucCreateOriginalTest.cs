using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
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
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucCreateOriginalTest : BaseModule
    {
        #region Service

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
        private PartService _PartService;
        private PartDetailService _PartDetailService;



        #endregion Service

        private int CurrentContestID
        {
            get
            {
                return StaticResource.ContestID;
            }
        }

        private int CurrentSubjectId
        {
            get
            {
                return StaticResource.SubjectID;
            }
        }

        private int CurrentScheduleID
        {
            get
            {
                try
                {
                    SCHEDULE schedule = _ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectId);
                    if (schedule != null) return schedule.ScheduleID;
                    else return -1;
                }
                catch { return -1; }
            }
        }

        private int NumberOfContestant
        {
            get
            {
                int ScheduleID = _ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectId).ScheduleID;
                return _ContestantShiftService.GetAllBySchedule(ScheduleID).Count();
            }
        }

        public int AutoNumOfTest
        {
            get
            {
                try
                {
                    return GetNumOfTest();
                }
                catch (Exception ex)
                {
                    Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                    return -1;
                }
            }
        }

        public ucCreateOriginalTest()
        {
            InitializeComponent();
            InitializeService();
        }

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
            _PartService = new PartService();
            _PartDetailService = new PartDetailService();
        }

        public override string ModuleName
        {
            get
            {
                return Properties.Resources.CreateOriginalTest;
            }
        }

        // Code tạo đề thi gốc của A Hùng K50
        protected internal override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResource.CreateOriginalTest:
                    CreateOriginalTest();
                    break;

                case TagResource.AcceptTest:
                    AcceptTest();
                    break;

                case TagResource.DeleteOriginalTest:
                    DeleteOriginalTest();
                    break;
                case TagResource.ExportTestToDoc:
                    ExportTestToDoc();
                    break;
            }
        }

        private void ExportTestToDoc()
        {
            List<ORIGINAL_TESTS> test = _OriginalTestService
                .GetByNewContest2Subject(CurrentContestID, CurrentSubjectId)
                .ToList();
#if !DEBUG
            if (test.Count == 0)
            {
                MessageBox.Show("Chưa Có Đề Thi Gốc!. Vui Lòng Tạo Đề...",
                    Properties.Resources.Notification,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

#endif

            SplashScreenManager.ShowSplashScreen();
#if DEBUG
            test = new List<ORIGINAL_TESTS>
            {
                new ORIGINAL_TESTS
                {
                    OriginalTestID=1,
                }
            };
#endif

            CustomeRichTextbox richTextbox = new CustomeRichTextbox();
            CustomeRichTextbox temp = new CustomeRichTextbox();
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(pathDesktop, DateTime.Now.ToShortDateString().Replace('/', '_'));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            int indexTest = 1;
            foreach (ORIGINAL_TESTS ot in test)
            {
                int index = 1;
                richTextbox.Clear();
                temp.Clear();

                temp.Text = "Đề Gốc " + indexTest + "\n\n";
             //   temp.HighLightText();
                temp.SelectAll();
                temp.Copy();

                richTextbox.Select(richTextbox.Text.Length, 0);
                richTextbox.Paste();

                IEnumerable<ORIGINAL_TEST_DETAILS> listOriginalTest = _OriginalTestDetailService.GetAll(ot.OriginalTestID);

#if DEBUG
                listOriginalTest = new List<ORIGINAL_TEST_DETAILS>
                {
                    new ORIGINAL_TEST_DETAILS
                    {
                        OriginalTestDetailID=1
                    }
                };
#endif

                List<QUESTION> originalQuestion = new List<QUESTION>();
                foreach (ORIGINAL_TEST_DETAILS otd in listOriginalTest)
                {
                    originalQuestion.Add(_QuestionService.GetById(otd.QuestionID));
                }

#if DEBUG
                originalQuestion = _QuestionService.GetAll().ToList();
#endif
                foreach (QUESTION q in originalQuestion)
                {
                    QUESTION_TYPES type = _QuestionTypeService.GetById(q.QuestionTypeID);
                    if (type.IsQuiz)
                    {
                        if (type.IsParagraph)
                        {
                            temp.Clear();
                            temp.Rtf = q.QuestionContent;
                            temp.SelectAll();
                            temp.Copy();

                            richTextbox.Select(richTextbox.Text.Length, 0);
                            richTextbox.Paste();
                        }

                        IEnumerable<SUBQUESTION> listSubQuestion = _SubQuestionService.GetAll(q.QuestionID);
                        foreach (SUBQUESTION sq in listSubQuestion)
                        {
                            temp.Clear();
                            if (type.IsQuestionContent)
                            {
                                temp.Clear();
                                temp.Text = "\n\t Câu Hỏi " + index++.ToString() + " : ";
                                temp.SelectAll();
                                temp.Copy();

                                richTextbox.Select(richTextbox.Text.Length, 0);
                                richTextbox.Paste();

                                temp.Clear();
                                temp.Rtf = sq.SubQuestionContent;
                   //             temp.BoldText();
                                temp.SelectAll();
                                temp.Copy();

                                richTextbox.Select(richTextbox.Text.Length, 0);
                                richTextbox.Paste();
                            }
                            IEnumerable<ANSWER> listAnswer = _AnswerService.GetAll(sq.SubQuestionID);
                            char indexAnswer = 'A';
                            foreach (ANSWER a in listAnswer)
                            {
                                temp.Clear();
                                temp.Text = "\t Đáp Án " + (indexAnswer++).ToString() + ": ";
                                temp.SelectAll();
                                temp.Copy();

                                richTextbox.Select(richTextbox.Text.Length, 0);
                                richTextbox.Paste();

                                temp.Clear();
                                temp.Rtf = a.AnswerContent;
                               // if (a.IsCorrect) temp.HighLightText();
                                temp.SelectAll();
                                temp.Copy();


                                richTextbox.Select(richTextbox.Text.Length, 0);
                                richTextbox.Paste();
                            }
                        }
                    }
                }
                //frmDisplayTest form = new frmDisplayTest(richTextbox);
                //form.ShowDialog();

                richTextbox.SaveFile(Path.Combine(path, string.Format("Đề Số {0}.rtf", indexTest++)));
            }
            SplashScreenManager.CloseForm();
            MessageBox.Show("Xuất ra file thành công!\nLưu tại thư mục: " + path,
                Properties.Resources.Notification,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(path);
        }

        private void DeleteOriginalTest()
        {
            TabPage currentTab = tabControl1.SelectedTab;
            if (currentTab != null)
            {
                try
                {
                    int originalTestId = int.Parse(currentTab.Name);

                    if (DialogResult.Yes == MessageBox.Show(Properties.Resources.YesNoMessage,
                        Properties.Resources.WarningDialog,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning))
                    {
                        _OriginalTestDetailService.DeleteAllByOriginalTest(originalTestId);
                        _OriginalTestDetailService.Save();
                        _OriginalTestService.Delete(originalTestId);
                        _OriginalTestService.Save();

                        Log.Instance.WriteLog(LogType.FATAL, string.Format("Đã xóa đề thi gốc bởi {0}", CurrentStaffId));
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                }
            }
        }

        public override void InitModule()
        {
            DisplayTest();
        }

        private void AcceptTest()
        {
            TabPage currentTab = tabControl1.SelectedTab;
            if (currentTab != null)
            {
                try
                {
                    int originalTestId = int.Parse(currentTab.Name);
                    ORIGINAL_TESTS test = _OriginalTestService.GetById(originalTestId);

                    if (test.Status == (int)OriginalTestStatus.Accepted)
                    {
                        MetroMessageBox.Show(this, "Đề Này Đã Phê Duyệt Rồi!", Properties.Resources.WarningDialog,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    if (DialogResult.OK == MessageBox.Show(Properties.Resources.YesNoMessage,
                                Properties.Resources.WarningDialog,
                                MessageBoxButtons.OK))
                    {
                        if (test != null)
                        {
                            test.AcceptDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                            test.Status = (int)OriginalTestStatus.Accepted;
                            _OriginalTestService.Update(test);
                            _OriginalTestService.Save();

                            DisplayAccepted(true);
                            Log.Instance.WriteLog(LogType.INFO, string.Format("Phê Duyệt Đề Số {0} thành công", test.OriginalTestID));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "Không Thể Phê Duyệt!", Properties.Resources.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                }
            }
        }

        private void CreateOriginalTest()
        {
            int NumOfTest = 0;
            if (XMLSettings.AutoNumberOfTest)
            {
                NumOfTest = GetNumOfTest();
            }
            else
            {
                NumOfTest = XMLSettings.NumberOfOriginalTest;
            }
            if (NumOfTest > 0)
            {
                STRUCTURE structTest = _StructureService
                        .GetByScheduleId(CurrentScheduleID);
                if (structTest == null)
                {
                    MessageBox.Show("Chưa Có Cấu Trúc Đề. Vui lòng nhập cấu trúc đề!",
                        Properties.Resources.Notification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                List<PART> listPart = _PartService.GetByScheduleId(CurrentScheduleID).ToList();
                List<List<QUESTION>> listOriginalTest = new List<List<QUESTION>>();
                for (int i = 0; i < NumOfTest; i++)
                    listOriginalTest.Add(new List<QUESTION>());

                List<TOPIC> listTopic = _TopicService
                    .GetAll(CurrentSubjectId)
                    .ToList();
                List<QUESTION_TYPES> listQuestionType = _QuestionTypeService
                    .GetAll()
                    .ToList();

                bool IsEnable = true;
                string messageLog = string.Empty;

                STRUCTURE structure = _StructureService.GetByScheduleId(CurrentScheduleID);
                if (structure == null)
                {
                    SplashScreenManager.CloseForm();
                    MetroMessageBox.Show(this, "Chưa có cấu trúc đề thi. Vui lòng tạo cấu trúc đề trước.!!!",
                        Properties.Resources.WarningDialog,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (listPart.Count != 0) //Cau truc co PART
                {
                    for (int part = 0; part < listPart.Count; part++)
                    {
                        List<List<QUESTION>> listPartQuestion = new List<List<QUESTION>>();
                        for (int i = 0; i < NumOfTest; i++)
                            listPartQuestion.Add(new List<QUESTION>());
                        listTopic = new List<TOPIC>();
                        List<PARTS_DETAILS> listPartDetail = _PartDetailService.GetAllByPartID(listPart[part].PartID).ToList();
                        for (int partDT = 0; partDT < listPartDetail.Count; partDT++)
                        {
                            listTopic.Add(listPartDetail[partDT].TOPIC);
                        }

                        for (int i = 0; i < listTopic.Count; i++)
                        {
                            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
                                .GetAll(structure.StructureID, listTopic[i].TopicID)
                                .ToList();

                            for (int j = 0; j < listStructureDetail.Count; j++)
                            {
                                if (listStructureDetail[j].NumberQuestions == 0) continue;
                                List<QUESTION> listQuestion4Topic = _QuestionService
                                    .GetByTopicLevel(listTopic[i].TopicID, listStructureDetail[j].Level)
                                    .ToList();

                                if (listQuestion4Topic == null || listQuestion4Topic.Count == 0)
                                {
                                    MetroMessageBox.Show(this, $"Không có câu hỏi được phê duyệt thuộc chủ đề {listTopic[i].TopicName}",
                                        Properties.Resources.WarningDialog,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return;
                                }

                                int SumQuestion = 0;
                                List<QuestionOfType> listQuestionOfType = new List<QuestionOfType>();
                                foreach (QUESTION_TYPES qt in _QuestionTypeService.GetAll())
                                {
                                    QuestionOfType questionOfType = new QuestionOfType();
                                    questionOfType.NumOfSubQestion = qt.NumberSubQuestion;
                                    questionOfType.QuestionTypeID = qt.QuestionTypeID;

                                    foreach (QUESTION q in listQuestion4Topic)
                                    {
                                        if (q.QuestionTypeID == qt.QuestionTypeID)
                                        {
                                            questionOfType.NumOfQuestion++;
                                            SumQuestion += qt.NumberSubQuestion;
                                        }
                                    }
                                    if (questionOfType.NumOfQuestion != 0)
                                        listQuestionOfType.Add(questionOfType);
                                }

                                if (SumQuestion < listStructureDetail[j].NumberQuestions * NumOfTest)
                                {
                                    messageLog += string.Format(@"Cần Bổ Sung Ít Nhất {0} Câu Hỏi Level {1}
                                    Chủ Đề {2} Môn {3} Vào Ngân Hàng Câu Hỏi\n",
                                            listStructureDetail[j].NumberQuestions * NumOfTest - listQuestion4Topic.Count,
                                            listStructureDetail[j].Level,
                                            listTopic[i].TopicName,
                                            _SubjectService.GetById(listTopic[i].SubjectID).SubjectName)
                                            .Replace("\n", Environment.NewLine);
                                    IsEnable = false;
                                    if (!IsEnable) continue;
                                }

                                try
                                {
                                    //Giai phuong trinh nghiem nguyen
                                    //xac dinh moi loai lay bao nhieu cau
                                    listQuestionOfType = RandomQuestionOfType(listQuestionOfType);
                                    listQuestionOfType = GetListNumberQuestionGet(listQuestionOfType, listStructureDetail[j].NumberQuestions, NumOfTest);
                                    if (listQuestionOfType == null)
                                        return;

                                    QUESTION_TYPES qtt = new QUESTION_TYPES();
                                    foreach (QuestionOfType qt in listQuestionOfType)
                                    {
                                        if (qt.NumOfQestionGet == 0) continue;

                                        List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QuestionTypeID == qt.QuestionTypeID).ToList();
                                        if (listFilterQuestion.Count < qt.NumOfQestionGet * NumOfTest)
                                        {
                                            messageLog += string.Format(@"Cần Bổ Sung Ít Nhất {0} Câu Hỏi Level {1}
                                    Chủ Đề {2} Môn {3} \nLoại {4} \nVào Ngân Hàng Câu Hỏi\n",
                                                    qt.NumOfQestionGet * NumOfTest - listFilterQuestion.Count,
                                                    listStructureDetail[j].Level,
                                                    listTopic[i].TopicName,
                                                    _SubjectService.GetById(listTopic[i].SubjectID).SubjectName,
                                                    _QuestionTypeService.GetById(qt.QuestionTypeID).Description)
                                                    .Replace("\n", Environment.NewLine);
                                            IsEnable = false;
                                        }
                                        if (!IsEnable) continue;

                                        qtt = _QuestionTypeService.GetById(qt.QuestionTypeID);
                                        if (qt.NumOfQestionGet == 1)
                                        {
                                            while (listFilterQuestion.Count < qt.NumOfQestionGet * NumOfTest)
                                                listFilterQuestion.AddRange(listFilterQuestion);
                                        }
                                        List<QUESTION> listQuestionRandom =
                                            _QuestionService.GetRandomList(listFilterQuestion,
                                            qt.NumOfQestionGet * NumOfTest);

                                        for (int t = 0; t < NumOfTest; t++)
                                        {
                                            listOriginalTest[t]
                                                .AddRange(listQuestionRandom
                                                .GetRange(t * qt.NumOfQestionGet, qt.NumOfQestionGet));
                                        }
                                    }
                                }
                                //catch
                                //{
                                //    MetroMessageBox.Show(this,
                                //        Properties.Resources.NotEnoughQuestionMessage,
                                //        Properties.Resources.WarningDialog,
                                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    MetroMessageBox.Show(this, messageLog, Properties.Resources.WarningDialog,
                                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    return;
                                //}
                                catch (DbEntityValidationException dbEx)
                                {
                                    string ex = "";
                                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                                    {
                                        foreach (var validationError in validationErrors.ValidationErrors)
                                        {
                                            ex = ex + "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage + "\n";

                                        }
                                    }
                                    MessageBox.Show(ex);
                                    //return 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < listTopic.Count; i++)
                    {
                        List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
                            .GetAll(structure.StructureID, listTopic[i].TopicID)
                            .ToList();

                        for (int j = 0; j < listStructureDetail.Count; j++)
                        {
                            if (listStructureDetail[j].NumberQuestions == 0) continue;
                            List<QUESTION> listQuestion4Topic = _QuestionService
                                .GetByTopicLevel(listTopic[i].TopicID, listStructureDetail[j].Level)
                                .ToList();

                            if (listQuestion4Topic == null || listQuestion4Topic.Count == 0)
                            {
                                MetroMessageBox.Show(this, $"Không có câu hỏi được phê duyệt thuộc chủ đề {listTopic[i].TopicName}",
                                    Properties.Resources.WarningDialog,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            int SumQuestion = 0;
                            List<QuestionOfType> listQuestionOfType = new List<QuestionOfType>();
                            foreach (QUESTION_TYPES qt in _QuestionTypeService.GetAll())
                            {
                                QuestionOfType questionOfType = new QuestionOfType();
                                questionOfType.NumOfSubQestion = qt.NumberSubQuestion;
                                questionOfType.QuestionTypeID = qt.QuestionTypeID;

                                foreach (QUESTION q in listQuestion4Topic)
                                {
                                    if (q.QuestionTypeID == qt.QuestionTypeID)
                                    {
                                        questionOfType.NumOfQuestion++;
                                        SumQuestion += qt.NumberSubQuestion;
                                    }
                                }
                                if (questionOfType.NumOfQuestion != 0)
                                    listQuestionOfType.Add(questionOfType);
                            }

                            if (SumQuestion < listStructureDetail[j].NumberQuestions * NumOfTest)
                            {
                                messageLog += string.Format(@"Cần Bổ Sung Ít Nhất {0} Câu Hỏi Level {1}
                                    Chủ Đề {2} Môn {3} Vào Ngân Hàng Câu Hỏi\n",
                                        listStructureDetail[j].NumberQuestions * NumOfTest - listQuestion4Topic.Count,
                                        listStructureDetail[j].Level,
                                        listTopic[i].TopicName,
                                        _SubjectService.GetById(listTopic[i].SubjectID).SubjectName)
                                        .Replace("\n", Environment.NewLine);
                                IsEnable = false;
                                if (!IsEnable) continue;
                            }

                            try
                            {
                                //Giai phuong trinh nghiem nguyen
                                //xac dinh moi loai lay bao nhieu cau
                                listQuestionOfType = RandomQuestionOfType(listQuestionOfType);
                                listQuestionOfType = GetListNumberQuestionGet(listQuestionOfType, listStructureDetail[j].NumberQuestions, NumOfTest);
                                if (listQuestionOfType == null)
                                    return;

                                QUESTION_TYPES qtt = new QUESTION_TYPES();
                                foreach (QuestionOfType qt in listQuestionOfType)
                                {
                                    if (qt.NumOfQestionGet == 0) continue;

                                    List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QuestionTypeID == qt.QuestionTypeID).ToList();
                                    if (listFilterQuestion.Count < qt.NumOfQestionGet * NumOfTest)
                                    {
                                        messageLog += string.Format(@"Cần Bổ Sung Ít Nhất {0} Câu Hỏi Level {1}
                                    Chủ Đề {2} Môn {3} \nLoại {4} \nVào Ngân Hàng Câu Hỏi\n",
                                                qt.NumOfQestionGet * NumOfTest - listFilterQuestion.Count,
                                                listStructureDetail[j].Level,
                                                listTopic[i].TopicName,
                                                _SubjectService.GetById(listTopic[i].SubjectID).SubjectName,
                                                _QuestionTypeService.GetById(qt.QuestionTypeID).Description)
                                                .Replace("\n", Environment.NewLine);
                                        IsEnable = false;
                                    }
                                    if (!IsEnable) continue;

                                    qtt = _QuestionTypeService.GetById(qt.QuestionTypeID);
                                    if (qt.NumOfQestionGet == 1)
                                    {
                                        while (listFilterQuestion.Count < qt.NumOfQestionGet * NumOfTest)
                                            listFilterQuestion.AddRange(listFilterQuestion);
                                    }
                                    List<QUESTION> listQuestionRandom =
                                        _QuestionService.GetRandomList(listFilterQuestion,
                                        qt.NumOfQestionGet * NumOfTest);

                                    for (int t = 0; t < NumOfTest; t++)
                                    {
                                        listOriginalTest[t]
                                            .AddRange(listQuestionRandom
                                            .GetRange(t * qt.NumOfQestionGet, qt.NumOfQestionGet));
                                    }
                                }
                            }
                            //catch
                            //{
                            //    MetroMessageBox.Show(this,
                            //        Properties.Resources.NotEnoughQuestionMessage,
                            //        Properties.Resources.WarningDialog,
                            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    MetroMessageBox.Show(this, messageLog, Properties.Resources.WarningDialog,
                            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    return;
                            //}
                            catch (DbEntityValidationException dbEx)
                            {
                                string ex = "";
                                foreach (var validationErrors in dbEx.EntityValidationErrors)
                                {
                                    foreach (var validationError in validationErrors.ValidationErrors)
                                    {
                                        ex = ex + "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage + "\n";

                                    }
                                }
                                MessageBox.Show(ex);
                                //return 0;
                            }
                        }
                    }
                }
                if (!IsEnable)
                {
                    MetroMessageBox.Show(this, messageLog, Properties.Resources.WarningDialog,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Instance.WriteLog(LogType.WARN, "Sinh đề thi không thành công do thiếu câu hỏi");
                    return;
                }

                #region Save to DataBase

                try
                {
                    foreach (List<QUESTION> originalQuestion in listOriginalTest)
                    {
                        int totalSubQues = 0;// lay ra tong so luong cau hoi
                        foreach (var ques in listOriginalTest[0])
                        {
                            totalSubQues += ques.SUBQUESTIONS.Count;
                        }
                        ORIGINAL_TESTS originalTest = new ORIGINAL_TESTS()
                        {
                            CreateDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                            SubjectID = CurrentSubjectId,
                            ContestID = CurrentContestID,
                            Status = (int)OriginalTestStatus.New
                        };
                        _OriginalTestService.Add(originalTest);
                        _OriginalTestService.Save();

                        for (int i = 0; i < originalQuestion.Count; i++)
                        {
                            ORIGINAL_TEST_DETAILS detail = new ORIGINAL_TEST_DETAILS()
                            {
                                NumberIndex = i,
                                OriginalTestID = originalTest.OriginalTestID,
                                QuestionID = originalQuestion[i].QuestionID,
                                Status = 1
                            };
                            _OriginalTestDetailService.Add(detail);
                        }
                        _OriginalTestDetailService.Save();
                    }
                    MessageBox.Show(Properties.Resources.OriginalTestCreateSuccess, Properties.Resources.Success);
                }
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, Properties.Resources.Error);
                //    return;
                //}

                catch (DbEntityValidationException dbEx)
                {
                    string ex = "";
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ex = ex + "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage + "\n";

                        }
                    }
                    MessageBox.Show(ex);
                    //return 0;
                }

                #endregion Save to DataBase

                #region update status contest

                CONTEST contest = _ContestService.GetById(CurrentContestID);
                contest.Status = (int)ContestStatus.GenerateOriginalDone;
                _ContestService.Update(contest);
                _ContestService.Save();

                #endregion update status contest

                DisplayTest();
            }
        }

        private bool CheckTime()
        {
#if DEBUG
            return true;
#endif
            CONTEST currentContest = _ContestService.GetById(CurrentContestID);
            DateTime begin = DateTimeHelpers.ConvertUnixToDateTime(currentContest.CreatedQuestionStartDate);
            DateTime end = DateTimeHelpers.ConvertUnixToDateTime(currentContest.CreatedQuestionEndDate);
            if (begin <= SystemTimeService.Now && end >= SystemTimeService.Now)
            {
                return true;
            }
            else
            {
                MetroMessageBox.Show(this, Properties.Resources.NotDuringTestMessage,
                    Properties.Resources.WarningDialog,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
        }
        //Random 1 lọai câu hỏi và đổi nó lên đầu 
        private List<QuestionOfType> RandomQuestionOfType(List<QuestionOfType> listQuestionOfType)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            if (listQuestionOfType.Count == 0) return new List<QuestionOfType>();
            int randomIndex = r.Next(0, listQuestionOfType.Count);
            var temp = listQuestionOfType[randomIndex];
            listQuestionOfType[randomIndex] = listQuestionOfType[0];
            listQuestionOfType[0] = temp;

            return listQuestionOfType;
        }

        private List<QuestionOfType> GetListNumberQuestionGet(List<QuestionOfType> listQuestionOfType, int sumQuestionNeed, int NumOfTest)
        {
            if (listQuestionOfType.Count == 1)//Nếu chỉ có 1 loại câu hỏi
            {
                if (sumQuestionNeed % listQuestionOfType[0].NumOfSubQestion != 0)// nếu k chia hết (k thỏa mãn)
                {
                    MetroMessageBox.Show(this,
                                "Cấu trúc đề không phù hợp với ngân hàng câu hỏi",
                                Properties.Resources.WarningDialog,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                listQuestionOfType[0].NumOfQestionGet = sumQuestionNeed / listQuestionOfType[0].NumOfSubQestion;
                return listQuestionOfType;
            }
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int RealSumQuestionNeed = sumQuestionNeed;
            foreach (QuestionOfType q in listQuestionOfType)//giải phương trình nghiệm nguyên 
            {
                if (q.NumOfSubQestion != 1 && RealSumQuestionNeed != 0 && RealSumQuestionNeed >= q.NumOfSubQestion)
                {
                    int max = (int)(q.NumOfQuestion / NumOfTest);
                    do
                    {
                        if (max == 0) break;
                        q.NumOfQestionGet = r.Next(1, max);
                    } while (RealSumQuestionNeed < q.NumOfQestionGet * q.NumOfSubQestion);
                    RealSumQuestionNeed -= q.NumOfQestionGet * q.NumOfSubQestion;
                }
                else
                {
                    //if (q.NumOfSubQestion == 1)
                    //{
                        q.NumOfQestionGet = RealSumQuestionNeed;
                        RealSumQuestionNeed = 0;
                    //}
                }
            }
            return listQuestionOfType;
        }

        private int GetNumOfTest()
        {
            if (CurrentSubjectId > 0 && CurrentScheduleID > 0)
            {
                int minNumQuestion = int.MaxValue;
                int minOriginalTest = 1;

                List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectId).ToList();
                List<QUESTION> listOriginalTest = new List<QUESTION>();
                List<QUESTION_TYPES> listQuestionType = _QuestionTypeService.GetAll().ToList();

                STRUCTURE structure = _StructureService.GetByScheduleId(CurrentScheduleID);
                if (structure == null)
                {
                    MessageBox.Show(Properties.Resources.NotStructureMessage, Properties.Resources.WarningDialog);
                    return 0;
                }

                for (int i = 0; i < listTopic.Count; i++)
                {
                    List<STRUCTURE_DETAILS> listStructureDetail =
                    _StructureDetailService.GetAll(_StructureService
                    .GetByScheduleId(CurrentScheduleID).StructureID, listTopic[i].TopicID)
                    .ToList();

                    for (int j = 0; j < listStructureDetail.Count; j++)
                    {
                        if (listStructureDetail[j].NumberQuestions > 1 && minNumQuestion > listStructureDetail[j].NumberQuestions)
                            minNumQuestion = listStructureDetail[j].NumberQuestions;
                    }
                    if (minNumQuestion == int.MaxValue) minNumQuestion = 1;
                }
                if (listTopic.Count != 0 && minNumQuestion != int.MaxValue)
                {
                    if (minNumQuestion != 1)
                    {
                        while (true)
                        {
                            bool isOK = DataHelper.GetPermutations<int>
                                (Enumerable.Range(1, minOriginalTest * minNumQuestion), minNumQuestion).Count() > NumberOfContestant;
                            if (isOK) break;
                            else minOriginalTest++;
                        }
                    }
                    else
                    {
                        int getByContestant = (int)Math.Ceiling((decimal)(0.1 * NumberOfContestant));
                        minOriginalTest = getByContestant < 3 ? getByContestant : 3;
                    }

                    return minOriginalTest;
                }
                else return 0;
            }
            else return 0;
        }

        private string CheckStatusOrginalTest(OriginalTestStatus status)
        {
            switch (status)
            {
                case OriginalTestStatus.New:
                    return Properties.Resources.New;

                case OriginalTestStatus.Accepted:
                    return Properties.Resources.Accepted;

                default:
                    return Properties.Resources.New;
            }
        }

        protected void UnloadTabpage(TabPage page)
        {
            while (page.Controls.Count > 0) page.Controls[0].Dispose();
        }

        private void DisplayTest()
        {
            foreach (TabPage t in tabControl1.TabPages)
            {
                UnloadTabpage(t);
            }
            tabControl1.TabPages.Clear();

            List<ORIGINAL_TESTS> test = _OriginalTestService
                .GetByNewContest2Subject(CurrentContestID, CurrentSubjectId)
                .ToList();

            var data = (from t in test
                        select new
                        {
                            OriginalTestID = t.OriginalTestID,
                            CreateDate = DateTimeHelpers.ConvertUnixToDateTime(t.CreateDate),
                            AcceptDate = DateTimeHelpers.ConvertUnixToDateTime(t.AcceptDate ?? 0),
                            Status = CheckStatusOrginalTest((OriginalTestStatus)t.Status)
                        }).ToList();

            #region Display Test

            SplashScreenManager.ShowSplashScreen();
            int i = 0;

            foreach (var d in data)
            {
                IEnumerable<ORIGINAL_TEST_DETAILS> listOriginalTest = _OriginalTestDetailService.GetAll(d.OriginalTestID);
                List<QUESTION> originalQuestion = (from otd in listOriginalTest
                                                   from q in _QuestionService.GetAll()
                                                   where otd.QuestionID == q.QuestionID
                                                   select q).ToList();
                //Tab page index
                i++;

                Panel pnTest = new Panel();
                pnTest.AutoScroll = true;
                pnTest.Dock = DockStyle.Fill;

                TabPage tpTest = new TabPage();
                tpTest.Name = d.OriginalTestID.ToString();
                tpTest.Text = "Đề gốc số " + i;
                tpTest.UseVisualStyleBackColor = true;
                tpTest.Padding = new System.Windows.Forms.Padding(3);
                tpTest.Controls.Add(pnTest);

                tabControl1.TabPages.Add(tpTest);

                int index = 1;
                List<Control> listUc = new List<Control>();
                foreach (QUESTION q in originalQuestion)
                {
                    ucDisplayQuestion display = new ucDisplayQuestion(q.QuestionID, ref index);
                    display.Accepted(d.Status == Properties.Resources.Accepted);
                    listUc.Add(display);
                }
                listUc.Reverse();
                pnTest.Controls.AddRange(listUc.ToArray());

                #endregion Display Test
            }
            SplashScreenManager.CloseForm();
        }

        public override void Refresh()
        {
            base.Refresh();
            DisplayTest();
        }

        private void DisplayAccepted(bool t)
        {
            TabPage currentTab = tabControl1.SelectedTab;
            if (currentTab != null)
            {
                foreach (Control c in currentTab.Controls[0].Controls)
                {
                    if (c.GetType() == typeof(ucDisplayQuestion))
                    {
                        (c as ucDisplayQuestion).Accepted(t);
                    }
                }
            }
        }
    }
}