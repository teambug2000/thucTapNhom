using BUS;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucCreateTest : BaseModule
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
        private QuestionTypeService _QuestionTypeService;
        private TestService _TestServiceMain;
        private TestDetailService _TestDetailService;
        private PartService _PartService;
        private PartDetailService _PartDetailService;
        private AnswerService _AnswerService;
        #endregion Service

        private int CurrentContestID
        {
            get
            {
                return StaticResource.ContestID;
            }
        }

        private int CurrentTestID
        {
            get
            {
                try
                {
                    if (gcOriginalTest.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcOriginalTest.Rows[gcOriginalTest.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["cTestID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentSubjectId
        {
            get
            {
                return StaticResource.SubjectID;
            }
        }

        private int CurrentNumContestant
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["NumContestant"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentScheduleId
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["ScheduleID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentShiftId
        {
            get
            {
                try
                {
                    if (gcShift.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcShift.Rows[gcShift.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["ShiftID"].Value.ToString());
                }
                catch { return -1; }
            }
        }
        private List<ShiftDataModel> ListShiftData = new List<ShiftDataModel>();
        private int CurrentNumberTestOfShift = 0;
        public ucCreateTest()
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
            _QuestionTypeService = new QuestionTypeService();
            _TestServiceMain = new TestService();
            _TestDetailService = new TestDetailService();
            _PartDetailService = new PartDetailService();
            _PartService = new PartService();
            _AnswerService = new AnswerService();
        }

        public override void InitModule()
        {
            base.InitModule();
            InitDataShift();
        }

        private void InitDataShift()
        {
            if (CurrentContestID > 0)
            {
                List<SHIFT> listShift = _ShiftService.GetAll(CurrentContestID).ToList();
                List<DIVISION_SHIFTS> listDivisionShift = new List<DIVISION_SHIFTS>();
                try
                {
                    for (int i = 0; i < listShift.Count; i++)
                        listDivisionShift.AddRange(_DivisionShiftService.GetByShift(listShift[i].ShiftID));
                }
                catch (Exception ex)
                {
                    Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                    MetroMessageBox.Show(this, Properties.Resources.NotScheduleMessage,
                        Properties.Resources.WarningDialog,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                List<CONTESTANTS_SHIFTS> listContantShift = new List<CONTESTANTS_SHIFTS>();
                for (int i = 0; i < listDivisionShift.Count; i++)
                    listContantShift.AddRange(_ContestantShiftService.GetAllByShift(listDivisionShift[i].DivisionShiftID));

                SCHEDULE schedule = _ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectId);
                SUBJECT sb = _SubjectService.GetById(CurrentSubjectId);
                var listShiftJoin = (from s in listShift
                                     from cs in listContantShift
                                     from ds in listDivisionShift
                                     where s.ShiftID == ds.ShiftID
                                     where ds.DivisionShiftID == cs.ShiftID
                                     where cs.ScheduleID == schedule.ScheduleID
                                     select new
                                     {
                                         ShiftID = s.ShiftID,
                                         ShiftName = s.ShiftName,
                                         ShiftDate = DateTimeHelpers.ConvertUnixToDateTime(s.ShiftDate).ToShortDateString(),
                                         SubjectName = sb.SubjectName + " (" + schedule.TimeOfTest / 60 + ")",
                                         SubjectCode = sb.SubjectCode,
                                         SubjectID = CurrentSubjectId,
                                         ScheduleID = schedule.ScheduleID,
                                         NumContestant = GetNumContestant(sb.SubjectID, CurrentContestID, s.ShiftID)
                                     }).Distinct().ToList();

                ListShiftData = new List<ShiftDataModel>();
                foreach (var shift in listShiftJoin)
                {

                    ShiftDataModel shiftData = new ShiftDataModel();
                    shiftData.NumberContestant = shift.NumContestant;
                    shiftData.ScheduleID = shift.ScheduleID;
                    shiftData.ShiftDate = shift.ShiftDate;
                    shiftData.ShiftID = shift.ShiftID;
                    shiftData.ShiftName = shift.ShiftName;
                    shiftData.SubjectCode = shift.SubjectCode;
                    shiftData.SubjectID = shift.SubjectID;
                    shiftData.SubjectName = shift.SubjectName;
                    ListShiftData.Add(shiftData);
                }
                gcShift.DataSource = listShiftJoin;
            }
        }

        private int GetNumContestant(int subjectID, int currentContestID, int shiftId)
        {
            int ScheduleID = _ScheduleService.GetByContestAndSubject(currentContestID, subjectID).ScheduleID;
            var data = from ds in _DivisionShiftService.GetByShift(shiftId)
                       from cs in _ContestantShiftService.GetAllBySchedule(ScheduleID)
                       where ds.DivisionShiftID == cs.ShiftID
                       select cs.ContestantID;
            return data.Count();
        }

        private void gcShift_SelectionChanged(object sender, EventArgs e)
        {
            InitDataTest();
        }

        private void InitDataTest()
        {
            var data = (from ds in _DivisionShiftService.GetByShift(CurrentShiftId)
                        from bot in _BagOfTestService.GetAll()
                        from t in _TestServiceMain.GetAllBySubject(CurrentSubjectId)
                        where bot.BagOfTestID == t.BagOfTestID
                        where ds.DivisionShiftID == bot.DivisionShiftID
                        select new
                        {
                            TestName = "Đề Thi" + t.TestID,
                            TestID = t.TestID,
                            TestDate = DateTimeHelpers.ConvertUnixToDateTime(t.TestDate).ToShortDateString()
                        }).ToList();
            CurrentNumberTestOfShift = data.Count;
            gcOriginalTest.DataSource = data;
        }

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
            if (listQuestionOfType.Count == 1)
            {
                // trường hợp chỉ có một loại câu hỏi mà số câu cần lấy không thể chia hết
                if (sumQuestionNeed % listQuestionOfType[0].NumOfSubQestion != 0)
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
            foreach (QuestionOfType q in listQuestionOfType)
            {
                if (q.NumOfSubQestion != 1 && RealSumQuestionNeed != 0 && RealSumQuestionNeed >= q.NumOfSubQestion)//
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
                    q.NumOfQestionGet = RealSumQuestionNeed;
                    RealSumQuestionNeed = 0;
                }
            }
            return listQuestionOfType;
        }

        public string ConvertToJsonRandomAnswer(int QuestionID, int OrderSubQues, List<int> listCorrectAns)
        {
            AnswerService _AnswerService = new AnswerService();
            SubQuestionService _SubQuestionService = new SubQuestionService();

            List<SUBQUESTION> listSubQuestion = _SubQuestionService.GetAll(QuestionID).ToList();
            List<SubQuestionViewModel> listSubQuestion4Json = new List<SubQuestionViewModel>();

            for (int i = 0; i < listSubQuestion.Count; i++)
            {
                List<ANSWER> listAnswer = _AnswerService.GetAll(listSubQuestion[i].SubQuestionID).ToList();
                List<ANSWER> listRandom = new List<ANSWER>();
                if (listAnswer.Count != 4)
                {
                    listRandom = _AnswerService.GetRandomList(listAnswer, listAnswer.Count);
                }
                else
                {
                    int orderAns = listCorrectAns[OrderSubQues + i];
                    ANSWER temp = listAnswer[0];
                    listAnswer[0] = listAnswer[orderAns];
                    listAnswer[orderAns] = temp;
                    listRandom = listAnswer;
                }

                List<int> listAnswerID = new List<int>();
                foreach (ANSWER a in listRandom)
                    listAnswerID.Add(a.AnswerID);

                listSubQuestion4Json.Add(new SubQuestionViewModel()
                {
                    SubQuestionID = listSubQuestion[i].SubQuestionID,
                    ListAnswerID = listAnswerID
                });
            }
            return JsonConvert.SerializeObject(listSubQuestion4Json);
        }

        // Code tạo đề thi từ ngân hàng đề của A Hùng K50
        protected internal override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResource.CreateTest:
                    // CreateAllTest();
                    CreateSingleTest();
                    break;
                case TagResource.CreateAllTest:
                    CreateAllTest();
                    break;
                case TagResource.DeleteTest:
                    DeleteTest(CurrentTestID);
                    break;
                case TagResource.DeleteAllTest:
                    DeleteAllTest(CurrentShiftId);
                    break;
            }
        }
        private void DeleteTest(int TestID)
        {
            _TestServiceMain.Delete(TestID);
            _TestServiceMain.Save();
            InitDataTest();
        }
        private void DeleteAllTest(int CurrentShiftId)
        {
            SHIFT shift = _ShiftService.GetById(CurrentShiftId);
            var listTest = shift.DIVISION_SHIFTS.FirstOrDefault().BAGOFTESTS.FirstOrDefault().TESTS;
            foreach (var item in listTest)
            {
                _TestServiceMain.Delete(item.TestID);
                _TestServiceMain.Save();
            }
            InitDataTest();
        }

        private List<TestModel> CheckNumberOfTest()
        {
            List<TestModel> listTestModel = new List<TestModel>();
            for (int i = 0; i < ListShiftData.Count; i++)
            {
                SHIFT shift = _ShiftService.GetById(ListShiftData[i].ShiftID);
                var bagOfTest = shift.DIVISION_SHIFTS.FirstOrDefault().BAGOFTESTS.FirstOrDefault();
                List<TEST> listTest = new List<TEST>();
                if (bagOfTest != null)
                {
                    listTest = bagOfTest.TESTS.ToList();
                }
                TestModel testModel = new TestModel();
                if (listTest == null || listTest.Count == 0)
                {
                    testModel.NumberOfTest = 0;
                    testModel.NumberOfTestNeed = (int)Math.Round((double)ListShiftData[i].NumberContestant * 1.5);
                }
                else
                {
                    testModel.NumberOfTest = listTest.Count;
                    testModel.NumberOfTestNeed = (int)Math.Round((double)ListShiftData[i].NumberContestant * 1.5);
                    if (testModel.NumberOfTest >= testModel.NumberOfTestNeed)
                    {
                        testModel.NumberOfTest = testModel.NumberOfTestNeed;
                    }
                }
                listTestModel.Add(testModel);
            }
            return listTestModel;
        }
        private void CreateAllTest()
        {
            var listTestModel = CheckNumberOfTest();
            for (int i = 0; i < ListShiftData.Count; i++)
            {
                int numberContestant = (int)Math.Round((double)(listTestModel[i].NumberOfTestNeed - listTestModel[i].NumberOfTest) / 1.5);
                if (numberContestant > 0)
                {
                    CreateTest(numberContestant, ListShiftData[i].ScheduleID, ListShiftData[i].ShiftID);
                }
            }
            //for (int i = 0; i < ListShiftData.Count; i++)
            //{
            //    CreateTest(ListShiftData[i].NumberContestant, ListShiftData[i].ScheduleID, ListShiftData[i].ShiftID);
            //}
        }
        private void CreateSingleTest()
        {
            if (gcOriginalTest.Rows.Count > 0)
            {
                if (MessageBox.Show("Đã Có Đề Thi. Bạn Có Muốn Tạo Tiếp",
                    Properties.Resources.WarningDialog,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No)
                { return; }
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CreateTest(CurrentNumContestant, CurrentScheduleId, CurrentShiftId);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds.ToString();
            MessageBox.Show("time:  " + elapsedMs, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CreateTest(int currentNumContestant, int currentScheduleId, int currentShiftId)
        {

            if (CurrentContestID >= 0 && CurrentSubjectId > 0)
            {
                try
                {
                    #region Make Test for Shift

                    //if (gcOriginalTest.Rows.Count > 0)
                    //{
                    //    if (MessageBox.Show("Đã Có Đề Thi. Bạn Có Muốn Tạo Tiếp",
                    //        Properties.Resources.WarningDialog,
                    //        MessageBoxButtons.YesNo,
                    //        MessageBoxIcon.Warning) == DialogResult.No)
                    //    { return; }
                    //}

                    SplashScreenManager.ShowSplashScreen();
                    // PART
                    List<PART> listPart = _PartService.GetByScheduleId(currentScheduleId).ToList();
                    List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectId).ToList();
                    List<QUESTION_TYPES> listQuestionType = _QuestionTypeService.GetAll().ToList();
                    List<QUESTION> listQuestionTest = new List<QUESTION>();//list để chứa tất cả các câu hỏi
                    if (XMLSettings.GenerateFromOrignalTest)//  Tao tu de thi goc
                    {
                        SplashScreenManager.CloseForm();
                        IEnumerable<ORIGINAL_TESTS> listOriginalTest = _OriginalTestService
                        .GetByContest2Subject(CurrentContestID, CurrentSubjectId);

                        if (listOriginalTest.Count() == 0)
                        {
                            MetroMessageBox.Show(this, Properties.Resources.NotOriginalTestMessage.Replace("\n", Environment.NewLine),
                                Properties.Resources.WarningDialog,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        for (int i = 0; i < listOriginalTest.Count(); i++)
                        {
                            IEnumerable<ORIGINAL_TEST_DETAILS> listTestDetail = _OriginalTestDetailService.GetAll(listOriginalTest.ToList()[i].OriginalTestID);
                            for (int j = 0; j < listTestDetail.Count(); j++)
                            {
                                listQuestionTest.Add(_QuestionService.GetById(listTestDetail.ToList()[j].QuestionID));
                            }
                            CreateTestByOriTest(listQuestionTest, currentNumContestant, currentScheduleId, currentShiftId);
                            return;
                        }
                    }
                    else if (XMLSettings.GenerateFromBank)// Tao tu ngan hang cau hoi
                    {
                        foreach (TOPIC t in listTopic)
                        {
                            listQuestionTest.AddRange(_QuestionService.GetByTopic(t.TopicID));
                        }
                    }

                    if (currentNumContestant < 0)
                    {
                        SplashScreenManager.CloseForm();
                        MetroMessageBox.Show(this, "Chưa Có Ca Thi. Xếp Lịch Trước!",
                            Properties.Resources.WarningDialog,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    int numberOfTest = (int)Math.Round((double)currentNumContestant * 1.5);

                    List<List<QUESTION>> listTestQuestion = new List<List<QUESTION>>();//nơi chứa các các test
                    for (int i = 0; i < numberOfTest; i++)
                        listTestQuestion.Add(new List<QUESTION>());

                    STRUCTURE structure = _StructureService.GetByScheduleId(currentScheduleId);
                    if (structure == null || CheckTopicNullInStructure(structure))//Them CheckTopicNullInPart
                    {
                        SplashScreenManager.CloseForm();
                        MetroMessageBox.Show(this, "Cấu trúc đề chưa hợp lệ do có chủ đề chưa có câu hỏi. Vui lòng kiểm tra lại!",
                            Properties.Resources.WarningDialog,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    SplashScreenManager.CloseForm();

                    SplashScreen.ShowSplashScreen(numberOfTest);
                    SplashScreen.SetStatus("Tiến hành kiếm tra và sinh đề...");
                    Log.Instance.WriteLog(LogType.INFO, "Tiến hành kiếm tra và sinh đề...");

                    if (listPart.Count != 0) //Cau truc co PART
                    {

                        for (int part = 0; part < listPart.Count; part++)
                        {
                            List<List<QUESTION>> listPartQuestion = new List<List<QUESTION>>();
                            for (int i = 0; i < numberOfTest; i++)
                                listPartQuestion.Add(new List<QUESTION>());
                            listTopic = new List<TOPIC>();
                            List<PARTS_DETAILS> listPartDetail = _PartDetailService.GetAllByPartID(listPart[part].PartID).ToList();
                            for (int partDT = 0; partDT < listPartDetail.Count; partDT++)
                            {
                                listTopic.Add(listPartDetail[partDT].TOPIC);
                            }
                            for (int i = 0; i < listTopic.Count; i++)
                            {
                                List<STRUCTURE_DETAILS> listStructureDetail =
                                _StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID)
                                .ToList();

                                SplashScreen.SetStatus($"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");
                                Log.Instance.WriteLog(LogType.INFO, $"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");

                                for (int j = 0; j < listStructureDetail.Count; j++)
                                {
                                    if (listStructureDetail[j].NumberQuestions == 0) continue;
                                    List<QUESTION> listQuestion4Topic = listQuestionTest
                                        .Where(x => x.TopicID == listTopic[i].TopicID && x.Level == listStructureDetail[j].Level)
                                        .ToList();

                                    if (listQuestion4Topic == null || listQuestion4Topic.Count == 0)
                                    {
                                        SplashScreen.CloseForm();
                                        MetroMessageBox.Show(this, $"Không có câu hỏi được phê duyệt thuộc chủ đề {listTopic[i].TopicName}",
                                            Properties.Resources.WarningDialog,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                        return;
                                    }

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
                                            }
                                        }
                                        if (questionOfType.NumOfQuestion != 0)
                                            listQuestionOfType.Add(questionOfType);
                                    }
                                    listQuestionOfType = RandomQuestionOfType(listQuestionOfType); // Random các câu hỏi thuộc chủ đề cần
                                    listQuestionOfType = GetListNumberQuestionGet(listQuestionOfType, listStructureDetail[j].NumberQuestions, numberOfTest); // tìm một nghiệm nguyên thỏa mãn

                                    SplashScreen.SetStatus($"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");
                                    Log.Instance.WriteLog(LogType.INFO, $"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");

                                    QUESTION_TYPES qtt = new QUESTION_TYPES();
                                    foreach (QuestionOfType qt in listQuestionOfType)
                                    {
                                        if (qt.NumOfQestionGet == 0) continue;
                                        qtt = _QuestionTypeService.GetById(qt.QuestionTypeID);
                                        List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QuestionTypeID == qt.QuestionTypeID).ToList();
                                        //List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QUESTION_TYPES.QuestionTypeName == qtt.QuestionTypeName).ToList();

                                        //List<QUESTION> listQuestionRandom =
                                        //        _QuestionService.GetRandomList(listFilterQuestion,
                                        //        qt.NumOfQestionGet);
                                        //foreach (QUESTION q in listQuestionRandom)
                                        //    q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000); // điểm có thể lẻ nên nhân 1000 cho về chẵn để lưu được dạng int

                                        for (int k = 0; k < numberOfTest; k++)
                                        {
                                            List<QUESTION> listQuestionRandom =
                                                _QuestionService.GetRandomList(listFilterQuestion,
                                                qt.NumOfQestionGet);
                                            foreach (QUESTION q in listQuestionRandom)
                                            {
                                                q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000); // điểm có thể lẻ nên nhân 1000 cho về chẵn để lưu được dạng int

                                            }
                                            listPartQuestion[k].AddRange(listQuestionRandom);
                                            //listTestQuestion[k].AddRange(listQuestionRandom);
                                        }
                                    }

                                    SplashScreen.SetStatus($"Thêm câu hỏi vào hàng đợi xong...");
                                }
                            }
                            //Neu dao cau hoi
                            if (XMLSettings.RandomQuestion)
                            {
                                if (listPart[part].Shuffle.Value == (int)EXON.Common.IsShuffle.Yes)
                                {
                                    Random r = new Random();
                                    foreach (var item in listPartQuestion)
                                    {
                                        List<QUESTION> listRandomPartQuestion = new List<QUESTION>();
                                        int randomIndex = 0;
                                        while (item.Count > 0)
                                        {
                                            randomIndex = r.Next(0, item.Count); //Choose a random object in the list
                                            listRandomPartQuestion.Add(item[randomIndex]); //add it to the new, random list
                                            item.RemoveAt(randomIndex); //remove to avoid duplicates
                                        }
                                        item.AddRange(listRandomPartQuestion);
                                    }
                                }
                            }
                            for (int k = 0; k < numberOfTest; k++)
                            {
                                listTestQuestion[k].AddRange(listPartQuestion[k]);
                            }
                        }
                    }
                    else // Neu khong co PART
                    {
                        listTopic = _TopicService.GetAll(CurrentSubjectId).ToList();
                        for (int i = 0; i < listTopic.Count; i++)
                        {
                            List<STRUCTURE_DETAILS> listStructureDetail =
                            _StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID)
                            .ToList();

                            SplashScreen.SetStatus($"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");
                            Log.Instance.WriteLog(LogType.INFO, $"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");

                            for (int j = 0; j < listStructureDetail.Count; j++)
                            {
                                if (listStructureDetail[j].NumberQuestions == 0) continue;
                                List<QUESTION> listQuestion4Topic = listQuestionTest
                                    .Where(x => x.TopicID == listTopic[i].TopicID && x.Level == listStructureDetail[j].Level)
                                    .ToList();

                                if (listQuestion4Topic == null || listQuestion4Topic.Count == 0)
                                {
                                    SplashScreen.CloseForm();
                                    MetroMessageBox.Show(this, $"Không có câu hỏi được phê duyệt thuộc chủ đề {listTopic[i].TopicName}",
                                        Properties.Resources.WarningDialog,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return;
                                }

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
                                        }
                                    }
                                    if (questionOfType.NumOfQuestion != 0)
                                        listQuestionOfType.Add(questionOfType);
                                }
                                listQuestionOfType = RandomQuestionOfType(listQuestionOfType); // thống kê số câu hỏi theo từng loại theo từng chủ đề
                                listQuestionOfType = GetListNumberQuestionGet(listQuestionOfType, listStructureDetail[j].NumberQuestions, numberOfTest); // tìm một nghiệm nguyên thỏa mãn

                                SplashScreen.SetStatus($"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");
                                Log.Instance.WriteLog(LogType.INFO, $"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");

                                QUESTION_TYPES qtt = new QUESTION_TYPES();
                                foreach (QuestionOfType qt in listQuestionOfType)
                                {
                                    if (qt.NumOfQestionGet == 0) continue;
                                    qtt = _QuestionTypeService.GetById(qt.QuestionTypeID);
                                    List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QuestionTypeID == qt.QuestionTypeID).ToList();
                                    //List<QUESTION> listFilterQuestion = listQuestion4Topic.Where(x => x.QUESTION_TYPES.QuestionTypeName == qtt.QuestionTypeName).ToList();

                                    //List<QUESTION> listQuestionRandom =
                                    //        _QuestionService.GetRandomList(listFilterQuestion,
                                    //        qt.NumOfQestionGet);
                                    //foreach (QUESTION q in listQuestionRandom)
                                    //    q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000); // điểm có thể lẻ nên nhân 1000 cho về chẵn để lưu được dạng int

                                    for (int k = 0; k < numberOfTest; k++)
                                    {
                                        List<QUESTION> listQuestionRandom =
                                            _QuestionService.GetRandomList(listFilterQuestion,
                                            qt.NumOfQestionGet);
                                        foreach (QUESTION q in listQuestionRandom)
                                        {
                                            q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000); // điểm có thể lẻ nên nhân 1000 cho về chẵn để lưu được dạng int

                                        }

                                        listTestQuestion[k].AddRange(listQuestionRandom);
                                    }
                                }

                                SplashScreen.SetStatus($"Thêm câu hỏi vào hàng đợi xong...");
                            }
                        }
                        //Neu dao cau hoi
                        if (XMLSettings.RandomQuestion)
                        {


                            Random r = new Random();
                            foreach (var item in listTestQuestion)
                            {
                                int randomIndex = 0;
                                List<QUESTION> listRandomPartQuestion = new List<QUESTION>();
                                while (item.Count > 0)
                                {
                                    randomIndex = r.Next(0, item.Count); //Choose a random object in the list
                                    listRandomPartQuestion.Add(item[randomIndex]); //add it to the new, random list
                                    item.RemoveAt(randomIndex); //remove to avoid duplicates
                                }
                                item.AddRange(listRandomPartQuestion);
                            }

                        }
                    }

                    #endregion Make Test for Shift

                    #region Make Test for Division Shift From Test Above

                    SplashScreen.SetStatus($"Tiến hành tạo đề thi...");
                    Log.Instance.WriteLog(LogType.INFO, $"Tiến hành tạo đề thi...");

                    var listContestant = (from ds in _DivisionShiftService.GetByShift(currentShiftId)
                                          from cs in _ContestantShiftService
                                          .GetAllBySchedule(_ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectId).ScheduleID)
                                          where ds.DivisionShiftID == cs.ShiftID
                                          select new
                                          {
                                              DivisionShiftID = ds.DivisionShiftID,
                                              ContestantID = cs.ContestantID,
                                              RoomTestID = ds.RoomTestID,
                                              Status = ds.Status
                                          }).ToList();

                    List<DIVISION_SHIFTS> listRoomShift = _DivisionShiftService.GetByShift(currentShiftId).ToList();
                    SplashScreen.SetStatus($"Tổng cộng có {listRoomShift.Count} phòng thi...");
                    Log.Instance.WriteLog(LogType.INFO, $"Tổng cộng có {listRoomShift.Count} phòng thi...");

                    int currentDivisionShiftId = listContestant.First().DivisionShiftID;
                    for (int r = 0; r < listRoomShift.Count; r++)
                    {
                        //int notByDividionShift = (int)Math.Round((double)listContestant
                        //    .Where(x => x.RoomTestID == listRoomShift[r].RoomTestID)
                        //    .Count() * 1.5);
                        int notByDividionShift = (int)Math.Round((double)currentNumContestant * 1.5);

                        BAGOFTEST bagOfTest = _BagOfTestService.GetAllByDivisionShift(listRoomShift[r].DivisionShiftID).FirstOrDefault();
                        if (bagOfTest == null)
                        {
                            bagOfTest = new BAGOFTEST()
                            {
                                DivisionShiftID = listRoomShift[r].DivisionShiftID,
                                NumberOfTest = notByDividionShift,
                                Status = 1
                            };
                            _BagOfTestService.Add(bagOfTest);
                        }
                        else
                        {
                            bagOfTest.NumberOfTest += numberOfTest;
                            _BagOfTestService.Update(bagOfTest);
                        }
                        _BagOfTestService.Save();

                        SplashScreen.SetStatus($"Tạo túi đề cho phòng thi {listRoomShift[r].ROOMTEST.RoomTestName}...");
                        Log.Instance.WriteLog(LogType.INFO, $"Tạo túi đề cho phòng thi {listRoomShift[r].ROOMTEST.RoomTestName}...");

                        var data = DataHelper.GetRandomByNumber(listTestQuestion, notByDividionShift);
                        int totalSubQues = 0;// lay ra tong so luong cau hoi
                        foreach (var ques in data[0])
                        {
                            totalSubQues += ques.SUBQUESTIONS.Count;
                        }
                        foreach (var item in data)
                        {
                            TestService _TestService = new TestService();
                            TestDetailService _TestDetailService = new TestDetailService();

                            TEST test = new TEST()
                            {
                                BagOfTestID = bagOfTest.BagOfTestID,
                                TestDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                                SubjectID = CurrentSubjectId
                            };
                            _TestService.Add(test);
                            _TestService.Save();

                            //List<QUESTION> listRandomQuestion = (XMLSettings.RandomQuestion) ? _QuestionService.GetRandomList(item, item.Count) : item;
                            List<QUESTION> listRandomQuestion = item;
                            List<int> listCorrectAns = SwapAnswer(listRandomQuestion, totalSubQues);
                            int OrderSubQues = 0;
                            for (int j = 0; j < listRandomQuestion.Count; j++)
                            {
                                TEST_DETAILS testDetail = new TEST_DETAILS();
                                testDetail.NumberIndex = j;
                                testDetail.TestID = test.TestID;
                                testDetail.Score = (double)listRandomQuestion[j].QuestionFormat / 1000;//lưu tạm vào QuestionFormat, trước nhận 1000 thì bây giờ phải chia 1000
                                testDetail.QuestionID = listRandomQuestion[j].QuestionID;
                                testDetail.RandomAnswer = ConvertToJsonRandomAnswer(listRandomQuestion[j].QuestionID, OrderSubQues, listCorrectAns);
                                _TestDetailService.Add(testDetail);
                                OrderSubQues = OrderSubQues + listRandomQuestion[j].SUBQUESTIONS.Count;

                            }
                            _TestDetailService.Save();

                            Log.Instance.WriteLog(LogType.INFO, $"Tạo thành công đề thi {test.TestID} với {listRandomQuestion.Count} câu hỏi");
                            SplashScreen.SetIncrement();
                        };
                        SplashScreen.SetStatus($"Thêm {data.Count} đề thi cho túi đề...");
                        Log.Instance.WriteLog(LogType.INFO, $"Thêm {data.Count} đề thi cho túi đề...");
                    }

                    #endregion Make Test for Division Shift From Test Above

                    #region update status contest

                    CONTEST contest = new CONTEST();
                    ContestBUS.Instance.GetContestByContestID(CurrentContestID, frmMain.sql);
                    //_ContestService.GetById(CurrentContestID);
                    contest.Status = (int)ContestStatus.GenereateTestDone;
                    ContestBUS.Instance.UpdateContest(contest, frmMain.sql);
                    //_ContestService.Update(contest);
                    //_ContestService.Save();

                    SplashScreen.SetStatus($"Sinh đề xong. Cập nhật trạng thái kì thi...");
                    Log.Instance.WriteLog(LogType.INFO, $"Sinh đề xong. Cập nhật trạng thái kì thi...");

                    #endregion update status contest
                }
                catch (Exception ex)
                {
                    SplashScreen.CloseForm();
                    MessageBox.Show(ex.Message);
                    Log.Instance.WriteErrorLog(LogType.ERROR, "Error when create test: " + ex.Message);
                    return;
                }
                SplashScreen.CloseForm();
                NotificationBox.Show("Sinh đề thi thành công", NotificationBox.AlertType.success);
                InitDataTest();
            }

        }
        private void CreateTestByOriTest(List<QUESTION> listQuestionTest, int currentNumContestant, int currentScheduleId, int currentShiftId)
        {
            #region Make Test for Shift
            SplashScreenManager.ShowSplashScreen();
            //List<PART> listPart = _PartService.GetByScheduleId(currentScheduleId).ToList();
            List<PART> listPart = new List<PART>();
            listPart = PartBUS.Instance.GetAllPart(currentScheduleId, listPart, frmMain.sql);
            List<TOPIC> listTopic = new List<TOPIC>();
            listTopic = TopicBUS.Instance.GetAllTopic(CurrentSubjectId, listTopic, frmMain.sql);
            //_TopicService.GetAll(CurrentSubjectId).ToList();
            List<QUESTION_TYPES> listQuestionType = new List<QUESTION_TYPES>();
            listQuestionType = QuestionTypeBUS.Instance.GetAllQuesType(listQuestionType, frmMain.sql);
            //_QuestionTypeService.GetAll().ToList();
            STRUCTURE structure = new STRUCTURE();
            structure = StructureBUS.Instance.GetStructure(currentScheduleId, frmMain.sql);
            //_StructureService.GetByScheduleId(currentScheduleId);
            int numberOfTest = (int)Math.Round((double)currentNumContestant * 1.5);
            // int numberOfTest = 1;

            List<List<QUESTION>> listTestQuestion = new List<List<QUESTION>>();//nơi chứa các các test
            for (int i = 0; i < numberOfTest; i++)
                listTestQuestion.Add(new List<QUESTION>());

            SplashScreen.ShowSplashScreen(numberOfTest);
            SplashScreen.SetStatus("Tiến hành kiếm tra và sinh đề...");
            Log.Instance.WriteLog(LogType.INFO, "Tiến hành kiếm tra và sinh đề...");
            if (listPart.Count != 0) //Cau truc co PART
            {
               // SplashScreenManager.CloseForm();
                for (int part = 0; part < listPart.Count; part++)
                {
                    List<List<QUESTION>> listPartQuestion = new List<List<QUESTION>>();
                    for (int i = 0; i < numberOfTest; i++)
                        listPartQuestion.Add(new List<QUESTION>());
                    listTopic = new List<TOPIC>();
                    List<PARTS_DETAILS> listPartDetail = new List<PARTS_DETAILS>();
                    listPartDetail = PartDetailBUS.Instance.GetAllPartDetailByPartID(listPart[part].PartID, listPartDetail, frmMain.sql);
                    //_PartDetailService.GetAllByPartID(listPart[part].PartID).ToList();
                    for (int partDT = 0; partDT < listPartDetail.Count; partDT++)
                    {
                        listTopic.Add(listPartDetail[partDT].TOPIC);
                    }
                    for (int i = 0; i < listTopic.Count; i++)
                    {
                        List<STRUCTURE_DETAILS> listStructureDetail = new List<STRUCTURE_DETAILS>();
                        listStructureDetail = StructureDetailBUS.Instance.GetAllPartDetailByStrucIDAndTopicID(structure.StructureID, listTopic[i].TopicID, listStructureDetail, frmMain.sql);

                        //_StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID)
                        //.ToList();

                        SplashScreen.SetStatus($"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");
                        Log.Instance.WriteLog(LogType.INFO, $"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");

                        for (int j = 0; j < listStructureDetail.Count; j++)
                        {
                            if (listStructureDetail[j].NumberQuestions == 0) continue;
                            List<QUESTION> listQuestion4Topic = listQuestionTest
                                .Where(x => x.TopicID == listTopic[i].TopicID && x.Level == listStructureDetail[j].Level)
                                .ToList();

                            SplashScreen.SetStatus($"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");
                            Log.Instance.WriteLog(LogType.INFO, $"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");
                            for (int k = 0; k < numberOfTest; k++)
                            {
                                List<QUESTION> listQuestionRandom =
                                    _QuestionService.GetRandomList(listQuestion4Topic,
                                    listQuestion4Topic.Count);
                                foreach (QUESTION q in listQuestionRandom)
                                {
                                    q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000); // điểm có thể lẻ nên nhân 1000 cho về chẵn để lưu được dạng int

                                }
                                listPartQuestion[k].AddRange(listQuestionRandom);
                                //listTestQuestion[k].AddRange(listQuestionRandom);
                            }


                            SplashScreen.SetStatus($"Thêm câu hỏi vào hàng đợi xong...");
                        }
                    }
                    //Neu dao cau hoi
                    if (XMLSettings.RandomQuestion)
                    {
                        if (listPart[part].Shuffle.Value == (int)EXON.Common.IsShuffle.Yes)
                        {
                            Random r = new Random();
                            foreach (var item in listPartQuestion)
                            {
                                List<QUESTION> listRandomPartQuestion = new List<QUESTION>();
                                int randomIndex = 0;
                                while (item.Count > 0)
                                {
                                    randomIndex = r.Next(0, item.Count); //Choose a random object in the list
                                    listRandomPartQuestion.Add(item[randomIndex]); //add it to the new, random list
                                    item.RemoveAt(randomIndex); //remove to avoid duplicates
                                }
                                item.AddRange(listRandomPartQuestion);
                            }
                        }
                    }
                    for (int k = 0; k < numberOfTest; k++)
                    {
                        listTestQuestion[k].AddRange(listPartQuestion[k]);
                    }
                }
            }
            else // Neu khong co PART
            {
                //SplashScreenManager.CloseForm();
                listTopic = _TopicService.GetAll(CurrentSubjectId).ToList();
                for (int i = 0; i < listTopic.Count; i++)
                {
                    List<STRUCTURE_DETAILS> listStructureDetail = new List<STRUCTURE_DETAILS>();
                    listStructureDetail = StructureDetailBUS.Instance.GetAllPartDetailByStrucIDAndTopicID(
                        structure.StructureID, listTopic[i].TopicID, listStructureDetail, frmMain.sql);
                    //List<STRUCTURE_DETAILS> listStructureDetail =
                    //_StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID)
                    //.ToList();

                    SplashScreen.SetStatus($"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");
                    Log.Instance.WriteLog(LogType.INFO, $"Kiểm tra chủ đề {listTopic[i].TopicName} xong...");

                    for (int j = 0; j < listStructureDetail.Count; j++)
                    {
                        if (listStructureDetail[j].NumberQuestions == 0) continue;
                        List<QUESTION> listQuestion4Topic = listQuestionTest
                            .Where(x => x.TopicID == listTopic[i].TopicID && x.Level == listStructureDetail[j].Level)
                            .ToList();

                        SplashScreen.SetStatus($"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");
                        Log.Instance.WriteLog(LogType.INFO, $"Tính toán số lượng câu hỏi của chủ đề {listTopic[i].TopicName} xong...");
                        for (int k = 0; k < numberOfTest; k++)
                        {
                            List<QUESTION> listQuestionRandom =
                                _QuestionService.GetRandomList(listQuestion4Topic,
                               listQuestion4Topic.Count);
                            foreach (QUESTION q in listQuestionRandom)
                            {
                                q.QuestionFormat = (int)(listStructureDetail[j].Score * 1000); // điểm có thể lẻ nên nhân 1000 cho về chẵn để lưu được dạng int

                            }

                            listTestQuestion[k].AddRange(listQuestionRandom);
                        }
                        SplashScreen.SetStatus($"Thêm câu hỏi vào hàng đợi xong...");
                    }
                }
                //Neu dao cau hoi
                if (XMLSettings.RandomQuestion)
                {


                    Random r = new Random();
                    foreach (var item in listTestQuestion)
                    {
                        int randomIndex = 0;
                        List<QUESTION> listRandomPartQuestion = new List<QUESTION>();
                        while (item.Count > 0)
                        {
                            randomIndex = r.Next(0, item.Count); //Choose a random object in the list
                            listRandomPartQuestion.Add(item[randomIndex]); //add it to the new, random list
                            item.RemoveAt(randomIndex); //remove to avoid duplicates
                        }
                        item.AddRange(listRandomPartQuestion);
                    }

                }
            }
            #endregion Make Test for Shift

            #region Make Test for Division Shift From Test Above

            SplashScreen.SetStatus($"Tiến hành tạo đề thi...");
            Log.Instance.WriteLog(LogType.INFO, $"Tiến hành tạo đề thi...");

            var listContestant = (from ds in _DivisionShiftService.GetByShift(currentShiftId)
                                  from cs in _ContestantShiftService
                                  .GetAllBySchedule(_ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectId).ScheduleID)
                                  where ds.DivisionShiftID == cs.ShiftID
                                  select new
                                  {
                                      DivisionShiftID = ds.DivisionShiftID,
                                      ContestantID = cs.ContestantID,
                                      RoomTestID = ds.RoomTestID,
                                      Status = ds.Status
                                  }).ToList();

            List<DIVISION_SHIFTS> listRoomShift = new List<DIVISION_SHIFTS>();
            listRoomShift = DivisionShiftBUS.Instance.GetAllDivisionShiftByShiftID(currentShiftId, listRoomShift, frmMain.sql);
            //_DivisionShiftService.GetByShift(currentShiftId).ToList();
            SplashScreen.SetStatus($"Tổng cộng có {listRoomShift.Count} phòng thi...");
            Log.Instance.WriteLog(LogType.INFO, $"Tổng cộng có {listRoomShift.Count} phòng thi...");

            int currentDivisionShiftId = listContestant.First().DivisionShiftID;
            for (int r = 0; r < listRoomShift.Count; r++)
            {
                //int notByDividionShift = (int)Math.Round((double)listContestant
                //    .Where(x => x.RoomTestID == listRoomShift[r].RoomTestID)
                //    .Count() * 1.5);
                int notByDividionShift = (int)Math.Round((double)currentNumContestant * 1.5);
                //int notByDividionShift = 1;

                BAGOFTEST bagOfTest = BagOfTestBUS.Instance.GetBagOfTestByDivisionShiftID(listRoomShift[r].DivisionShiftID, frmMain.sql);
                //_BagOfTestService.GetAllByDivisionShift(listRoomShift[r].DivisionShiftID).FirstOrDefault();
                if (bagOfTest.BagOfTestID == 0)
                {
                    bagOfTest = new BAGOFTEST()
                    {
                        DivisionShiftID = listRoomShift[r].DivisionShiftID,
                        NumberOfTest = notByDividionShift,
                        Status = 1
                    };
                    bagOfTest = BagOfTestBUS.Instance.InsertBagOfTest(bagOfTest, frmMain.sql);
                    //_BagOfTestService.Add(bagOfTest);
                }
                else
                {
                    bagOfTest.NumberOfTest += numberOfTest;
                    bagOfTest = BagOfTestBUS.Instance.UpdateBagOfTest(listRoomShift[r].DivisionShiftID, bagOfTest, frmMain.sql);
                    // _BagOfTestService.Update(bagOfTest);
                }
                //_BagOfTestService.Save();
                //{ listRoomShift[r].ROOMTEST.RoomTestName}
                //{ listRoomShift[r].ROOMTEST.RoomTestName}
                SplashScreen.SetStatus($"Tạo túi đề cho phòng thi ...");
                Log.Instance.WriteLog(LogType.INFO, $"Tạo túi đề cho phòng thi ...");

                var data = DataHelper.GetRandomByNumber(listTestQuestion, notByDividionShift);
                int totalSubQues = 0;// lay ra tong so luong cau hoi
                foreach (var ques in data[0])
                {
                    totalSubQues += ques.SUBQUESTIONS.Count;
                }
                foreach (var item in data)
                {
                    TestService _TestService = new TestService();
                    TestDetailService _TestDetailService = new TestDetailService();

                    TEST test = new TEST()
                    {
                        BagOfTestID = bagOfTest.BagOfTestID,
                        TestDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                        SubjectID = CurrentSubjectId,
                        Status = 0
                    };
                    test = TestBUS.Instance.InsertTestByBagOfTest(test, frmMain.sql);
                    //_TestService.Add(test);
                    //_TestService.Save();

                    //List<QUESTION> listRandomQuestion = (XMLSettings.RandomQuestion) ? _QuestionService.GetRandomList(item, item.Count) : item;
                    List<QUESTION> listRandomQuestion = item;
                    List<int> listCorrectAns = SwapAnswer(listRandomQuestion, totalSubQues);
                    int OrderSubQues = 0;
                    for (int j = 0; j < listRandomQuestion.Count; j++)
                    {
                        TEST_DETAILS testDetail = new TEST_DETAILS();
                        testDetail.NumberIndex = j;
                        testDetail.TestID = test.TestID;
                        testDetail.Score = (double)listRandomQuestion[j].QuestionFormat / 1000;//lưu tạm vào QuestionFormat, trước nhận 1000 thì bây giờ phải chia 1000
                        testDetail.QuestionID = listRandomQuestion[j].QuestionID;
                        testDetail.RandomAnswer = ConvertToJsonRandomAnswer(listRandomQuestion[j].QuestionID, OrderSubQues, listCorrectAns);
                        //_TestDetailService.Add(testDetail);
                        testDetail = TestDetailBUS.Instance.InsertTestDetail(testDetail, frmMain.sql);
                        OrderSubQues = OrderSubQues + listRandomQuestion[j].SUBQUESTIONS.Count;

                    }
                    // _TestDetailService.Save();

                    Log.Instance.WriteLog(LogType.INFO, $"Tạo thành công đề thi {test.TestID} với {listRandomQuestion.Count} câu hỏi");
                    SplashScreen.SetIncrement();
                };
                SplashScreen.SetStatus($"Thêm {data.Count} đề thi cho túi đề...");
                Log.Instance.WriteLog(LogType.INFO, $"Thêm {data.Count} đề thi cho túi đề...");
            }

            #endregion Make Test for Division Shift From Test Above

            #region update status contest

            CONTEST contest = ContestBUS.Instance.GetContestByContestID(CurrentContestID, frmMain.sql);
            //_ContestService.GetById(CurrentContestID);
            contest.Status = (int)ContestStatus.GenereateTestDone;
            ContestBUS.Instance.UpdateContest(contest, frmMain.sql);
            //_ContestService.Update(contest);
            //_ContestService.Save();

            SplashScreen.SetStatus($"Sinh đề xong. Cập nhật trạng thái kì thi...");
            Log.Instance.WriteLog(LogType.INFO, $"Sinh đề xong. Cập nhật trạng thái kì thi...");
            SplashScreen.CloseForm();
            #endregion update status contest
        }
        private List<int> SwapAnswer(List<QUESTION> listQues, int totalSubQues)
        {
            List<int> listAns = new List<int>() { 0, 0, 0, 0 };
            List<int> listMaxAns = new List<int>() { 0, 0, 0, 0 };
            List<int> listCorrectAns = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 4; i++)//Tinh toan so luong Ans 
            {
                listMaxAns[i] = totalSubQues / 4;
                if (i <= totalSubQues % 4)
                {
                    listMaxAns[i]++;
                }

            }
            foreach (var ques in listQues)//Doi vi tri cac Ans
            {
                var listSubQues = ques.SUBQUESTIONS.ToList();
                foreach (var sub in listSubQues)
                {
                    List<ANSWER> lAns = sub.ANSWERS.ToList();
                    if (lAns.Count == 4)
                    {
                        int i = rand.Next(0, 4);
                        if (listAns[i] < listMaxAns[i])
                        {
                            listCorrectAns.Add(i);
                            listAns[i]++;
                        }
                        else
                        {
                            int min = listAns.Min();
                            int j = listAns.FindIndex(x => x == min);
                            if (listAns[j] < listMaxAns[j])
                            {
                                listCorrectAns.Add(j);
                                listAns[j]++;
                            }
                        }
                    }
                }
            }
            return listCorrectAns;
        }

        private bool CheckTopicNullInStructure(STRUCTURE structure)
        {
            List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectId).ToList();
            foreach (TOPIC t in listTopic)
            {
                IEnumerable<STRUCTURE_DETAILS> listDetail = _StructureDetailService.GetAll(structure.StructureID, t.TopicID);

                int totalQuestion = 0;
                foreach (STRUCTURE_DETAILS sd in listDetail) totalQuestion += sd.NumberQuestions;
                if (totalQuestion == 0)
                {
                    Log.Instance.WriteLog(LogType.WARN, $"Chủ đề {t.TopicName} chưa có câu hỏi");
                    return true;
                }
            }
            return false;
        }

        private bool CheckTime()
        {
#if DEBUG
            return true;
#else
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
#endif
        }

        public override void Refresh()
        {
            base.Refresh();
            InitDataShift();
            InitDataTest();
        }

        public override string ModuleName
        {
            get
            {
                return Properties.Resources.CreateTest;
            }
        }

        private void gcOriginalTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gcOriginalTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                int testID = int.Parse(senderGrid.Rows[e.RowIndex].Cells["cTestID"].Value.ToString());
                int totalQuestion = 0;
                double totalScore = 0d;

                IEnumerable<TEST_DETAILS> listTest = _TestDetailService.GetAll(testID);
                foreach (TEST_DETAILS td in listTest)
                {
                    QUESTION q = _QuestionService.GetById(td.QuestionID);
                    totalQuestion += _QuestionTypeService.GetById(q.QuestionTypeID).NumberSubQuestion;
                    totalScore += td.Score * _QuestionTypeService.GetById(q.QuestionTypeID).NumberSubQuestion;
                }
                lbTotalQuestion.Text = $"Số câu hỏi: {totalQuestion.ToString()}";
                lbTotalScore.Text = $"Tổng điểm: {totalScore.ToString()}";
                lbDateCreate.Text = $"Ngày tạo: {DateTimeHelpers.ConvertUnixToDateTime(_TestServiceMain.GetById(testID).TestDate).ToString("dd/MM/yyyy")}";
            }
        }

        private void bbiShowTest_Click(object sender, EventArgs e)
        {
            frmDisplayTest frmDisplayTest = new frmDisplayTest(CurrentTestID);
            frmDisplayTest.ShowDialog();
        }
    }
}