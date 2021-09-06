using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
using EXON.GenerateTest.Core.Forms;
using EXON.GenerateTest.Core.Models;
using EXON.GenerateTest.Core.Reports;
using EXON.GenerateTest.Core.Tags;
using EXON.Model.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucCreateStructure : BaseModule
    {
        private ContestService _ContestService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private TopicService _TopicService;
        private StructureService _StructureService;
        private StructureDetailService _StructureDetailService;
        private PartDetailService _PartDetailService;
        private PartService _PartService;

        private int TotalNumOfQuestion;
        private double TotalScore;

        private int PreviousSelectIndex = 0;

        private int CurrentScheduleID
        {
            get
            {
                try
                {
                    if (StaticResource.ContestID <= 0) return -1;
                    return _ScheduleService.GetByContestAndSubject(StaticResource.ContestID, CurrentSubjectID).ScheduleID;
                }
                catch
                {
                    return -1;
                }
            }
        }

        private int CurrentSubjectID { get { return StaticResource.SubjectID; } }

        private int CurrentTopicID
        {
            get
            {
                try
                {
                    if (gcStructTest.CurrentCell.RowIndex < 0 || gcStructTest.SelectedRows.Count == 0) return -1;
                    DataGridViewRow data = gcStructTest.SelectedRows[0];
                    return int.Parse(data.Cells["TopicID"].Value.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }

        public ucCreateStructure()
        {
            InitializeComponent();

            _ContestService = new ContestService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            _TopicService = new TopicService();
            _StructureService = new StructureService();
            _StructureDetailService = new StructureDetailService();
            _PartDetailService = new PartDetailService();
            _PartService = new PartService();
        }

        public override void InitModule()
        {
            base.InitModule();
            Initdata4GcStructTest(true);
            InitControl4Panel();
        }

        private void InitControl4Panel()
        {
            SplashScreenManager.ShowSplashScreen();

            pnMain.Controls.Clear();
            List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectID).ToList();
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                for (int i = listTopic.Count - 1; i >= 0; i--)
                {
                    ucDisplayStructure detail = new ucDisplayStructure(structure, listTopic[i]);
                    detail.UpdateUserControl += UpdateGridView;
                    pnMain.Controls.Add(detail);
                }
                CanculateTotal();
            }

            SplashScreenManager.CloseForm();
        }

        public override void Refresh()
        {
            base.Refresh();
            UpdateGridView();
            InitControl4Panel();
            PreviousSelectIndex = 0;
        }

        private void UpdateGridView()
        {
            _StructureDetailService = new StructureDetailService();
            Initdata4GcStructTest();
            CanculateTotal();
        }

        private void CanculateTotal()
        {
            TotalNumOfQuestion = 0;
            TotalScore = 0;

            foreach (Control c in pnMain.Controls)
            {
                if (c.GetType() == typeof(ucDisplayStructure))
                {
                    TotalNumOfQuestion += (c as ucDisplayStructure).TotalNumQuestion;
                    TotalScore += (c as ucDisplayStructure).TotalScore;
                }
            }

            lbTotalQuestion.Text = string.Format("Tổng số câu hỏi: {0}", TotalNumOfQuestion);
            lbTotalScore.Text = string.Format("Tổng số điểm: {0}", TotalScore);
        }

        private void Initdata4GcStructTest(bool isFirstShow = false)
        {
            List<TOPIC> listTopic = _TopicService.GetAll(CurrentSubjectID).ToList();
            lbTotalTopic.Text = string.Format("Số Chủ Đề {0}", listTopic.Count);
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure == null)
                {
                    structure = new STRUCTURE()
                    {
                        CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                        ScheduleID = schedule.ScheduleID,
                        CreatedStaffID = CurrentStaffId,
                        Status = 1
                    };
                    _StructureService.Add(structure);
                    _StructureService.Save();

                    foreach (TOPIC t in listTopic)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            STRUCTURE_DETAILS sd = new STRUCTURE_DETAILS()
                            {
                                Level = i,
                                NumberQuestions = 0,
                                Score = 1,
                                StructureID = structure.StructureID,
                                TopicID = t.TopicID,
                                Status = 1
                            };
                            _StructureDetailService.Add(sd);
                        }
                        _StructureDetailService.Save();
                    }
                }

                List<StructureDetailViewModel> listStructureDetailViewModel = new List<StructureDetailViewModel>();
                for (int i = 0; i < listTopic.Count; i++)
                {
                    List<STRUCTURE_DETAILS> listStructureDetail =
                        _StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID).ToList();

                    if (listStructureDetail.Count == 0)
                    {
                        for (int j = 1; j <= 4; j++)
                        {
                            STRUCTURE_DETAILS sd = new STRUCTURE_DETAILS()
                            {
                                Level = j,
                                NumberQuestions = 0,
                                Score = 1,
                                StructureID = structure.StructureID,
                                TopicID = listTopic[i].TopicID,
                                Status = 1
                            };
                            _StructureDetailService.Add(sd);
                        }
                        _StructureDetailService.Save();

                        listStructureDetail =
                        _StructureDetailService.GetAll(structure.StructureID, listTopic[i].TopicID).ToList();
                    }

                    //PART
                    var PartSubject = _PartService.GetByTopicId(listTopic[i].TopicID);
                    if (PartSubject != null)
                    {
                        var PartSubjectDT = _PartDetailService.GetByTopicId(listTopic[i].TopicID);

                        StructureDetailViewModel model = new StructureDetailViewModel
                        {
                            TopicID = listTopic[i].TopicID,
                            TopicName = listTopic[i].TopicName,
                            Level1 = listStructureDetail[0].NumberQuestions,
                            Level2 = listStructureDetail[1].NumberQuestions,
                            Level3 = listStructureDetail[2].NumberQuestions,
                            Level4 = listStructureDetail[3].NumberQuestions,
                            ParSubjectID = PartSubject.PartID,
                            PartOrderInTest = PartSubject.OrderInTest.Value,
                            OrderOfTopic = PartSubjectDT.OrderOfTopic.Value,
                        };
                        listStructureDetailViewModel.Add(model);
                    }
                    else
                    {
                        StructureDetailViewModel model = new StructureDetailViewModel
                        {
                            TopicID = listTopic[i].TopicID,
                            TopicName = listTopic[i].TopicName,
                            Level1 = listStructureDetail[0].NumberQuestions,
                            Level2 = listStructureDetail[1].NumberQuestions,
                            Level3 = listStructureDetail[2].NumberQuestions,
                            Level4 = listStructureDetail[3].NumberQuestions,
                            ParSubjectID = 0,
                            PartOrderInTest = 0,
                            OrderOfTopic = 0
                        };
                        listStructureDetailViewModel.Add(model);
                    }
                }


                gcStructTest.SelectionChanged -= gcStructTest_SelectionChanged;
                gcStructTest.DataSource = listStructureDetailViewModel;
                gcStructTest.SelectionChanged += gcStructTest_SelectionChanged;
                if (!isFirstShow && PreviousSelectIndex < gcStructTest.Rows.Count)
                {
                    gcStructTest.ClearSelection();

                    int index = ((gcStructTest.Rows.Count - 1) > PreviousSelectIndex) ? PreviousSelectIndex + 1 : (gcStructTest.Rows.Count - 1);

                    gcStructTest.Rows[index].Selected = true;
                    //SelectRowAndStructure();
                }
            }
        }

        public override string ModuleName
        {
            get
            {
                return Properties.Resources.StructureTestName;
            }
        }

        protected internal override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResource.CreateStruct:
                    MetroMessageBox.Show(this, "Vui lòng nhập cấu trúc theo form bên phải",
                        Properties.Resources.Notification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;

                case TagResource.UpdateStruct:
                    MetroMessageBox.Show(this, "Vui lòng sửa cấu trúc bằng cách nhấn Sửa ở form bên phải",
                        Properties.Resources.Notification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;

                case TagResource.ExportStructToDoc:
                    CreateReportStruct();
                    break;

                case TagResource.CreatePart:
                    CreateReportPart();
                    InitControl4Panel();
                    break;
            }
        }
        private void CreateReportPart()
        {
            frmPart frm = new frmPart(CurrentScheduleID, CurrentStaffId);
            frm.ShowDialog();
        }
        private void CreateReportStruct()
        {
            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    FrmStructTestReport temp = new FrmStructTestReport(structure.StructureID);
                    temp.ShowDialog();
                }
            }
            else
                MetroMessageBox.Show(this, "Chưa Có Cấu Trúc Đề",
                      Properties.Resources.Notification,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
        }

        private void gcStructTest_SelectionChanged(object sender, System.EventArgs e)
        {
            SelectRowAndStructure();
        }

        private void SelectRowAndStructure()
        {
            if (gcStructTest.SelectedRows.Count > 0 && gcStructTest.SelectedRows[0].Index >= 0)
            {
                PreviousSelectIndex = gcStructTest.SelectedRows[0].Index;
            }

            SCHEDULE schedule = _ScheduleService.GetById(CurrentScheduleID);
            if (schedule != null)
            {
                STRUCTURE structure = _StructureService.GetByScheduleId(schedule.ScheduleID);
                if (structure != null)
                {
                    pnMain.SetAutoScrollMargin(90, 120);
                    foreach (ucDisplayStructure sd in pnMain.Controls)
                    {
                        if (sd.CheckCorrectStructureDetail(structure.StructureID, CurrentTopicID))
                        {
                            sd.Show();
                            sd.ChangeColor(true);
                            pnMain.ScrollControlIntoView(sd);
                        }
                        else
                        {
                            sd.Hide();
                            sd.ChangeColor(false);
                        }
                    }
                }
            }
        }
    }
}