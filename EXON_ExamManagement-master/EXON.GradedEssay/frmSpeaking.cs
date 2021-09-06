using EXON.SubData.Services;
using EXON.SubModel.Models;
using MetroFramework.Forms;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EXON.Common;

namespace EXON.GradedEssay
{
    public partial class frmSpeaking : MetroForm
    {
        #region Service
        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private StaffService _StaffService;
        private DivisionShiftService _DivisionShiftService;
        private ContestantShiftService _ContestantShiftService;
        private ContestantService _ContestantService;
        private ContestantTestService _ContestantTestService;
        private AnswersheetService _AnswersheetService;
        private AnswersheetSpeakingService _AnswersheetSpeakingService;
        #endregion Service

        private string columnClick;

        private int CurrentContestID { get; set; }

        private int CurrentShiftID
        {
            get
            {
                try
                {
                    return int.Parse(cbShift.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentSubjectID
        {
            get
            {
                try
                {
                    return int.Parse(cbSubject.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        public frmSpeaking(int contestID)
        {
            CurrentContestID = contestID;
            InitializeComponent();
            InitializeService();
            InitializeControl();
        }
        private void InitializeService()
        {
            _ContestService = new ContestService();
            _ShiftService = new ShiftService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            _DivisionShiftService = new DivisionShiftService();
            _ContestantShiftService = new ContestantShiftService();
            _ContestantService = new ContestantService();
            _StaffService = new StaffService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetService = new AnswersheetService();
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
        }

        private void InitializeControl()
        {
            this.Text = string.Format("Kì Thi: {0} - Chấm Thi Nói", _ContestService.GetById(CurrentContestID).ContestName);

            cbShift.DataSource = (from s in _ShiftService.GetAll(CurrentContestID)
                                  from ds in _DivisionShiftService.GetAll()
                                  where s.ShiftID == ds.ShiftID
                                  select ds).ToList();
            cbShift.DisplayMember = "DivisionShiftID";
            cbShift.ValueMember = "DivisionShiftID";

            cbSubject.DataSource = (from sc in _ScheduleService.GetAllByContest(CurrentContestID)
                                    from sb in _SubjectService.GetAll()
                                    where sc.SubjectID == sb.SubjectID
                                    select sb).ToList();
            cbSubject.DisplayMember = "SubjectName";
            cbSubject.ValueMember = "SubjectID";
        }

        private void cbShift_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (CurrentShiftID > 0 && CurrentSubjectID > 0)
            {
                DIVISION_SHIFTS ds = _DivisionShiftService.GetById(CurrentShiftID);
                SCHEDULE sc = _ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectID);
                if (ds != null && sc != null)
                {
                    int index = 1;
                    List<ContestantSpeakingResult> listContestant = (from cs in _ContestantShiftService.GetAllByScheduleShift(sc.ScheduleID, ds.DivisionShiftID)
                                                                     from c in _ContestantService.GetAll()
                                                                     where cs.ContestantID == c.ContestantID
                                                                     select new ContestantSpeakingResult
                                                                     {
                                                                         STT = index++,
                                                                         ShiftName = GetShiftName(cs.DivisionShiftID),
                                                                         ContestantCode = c.ContestantCode,
                                                                         FullName = c.FullName,
                                                                         DOB = DateTimeHelpers.ConvertUnixToDateTime(c.DOB.Value)
                                                                           .ToShortDateString(),
                                                                         Score = GetScore(cs.ContestantShiftID),
                                                                          ContestantShiftID= cs.ContestantShiftID,
                                                                         PrintResult = "In"
                                                                     }).ToList();
                    gvMain.DataSource = listContestant;
                }
            }
            else gvMain.DataSource = null;
        }

        private string GetShiftName(int divisionShiftID)
        {
            DIVISION_SHIFTS ds = _DivisionShiftService.GetById(divisionShiftID);
            if (ds != null)
            {
                SHIFT shift = _ShiftService.GetById(ds.ShiftID);
                if (shift != null)
                    return shift.ShiftName;
            }
            return string.Empty;
        }
        private string GetScore(int? contestantShiftID)
        {
            if (contestantShiftID.HasValue)
            {
                CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID.Value);
                if (ct != null)
                {
                    ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                    if (anw != null)
                    {
                        ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                        if (aw != null)
                        {
                            return aw.SpeakingScore.ToString();
                        }
                    }
                    else
                    {
                        anw = new ANSWERSHEET
                        {
                            ContestantTestID = ct.ContestantTestID,
                            Status = 4002
                        };
                        _AnswersheetService.Add(anw);
                        _AnswersheetService.Save();
                    }
                }
            }
            return string.Empty;
        }

        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            SUBJECT subject = _SubjectService.GetById(CurrentSubjectID);
            if (subject != null)
            {
                try
                {
                    List<STAFF> listStaff = _StaffService.GetAll().ToList();

                    cbStaff1.DataSource = listStaff;
                    cbStaff1.DisplayMember = "FullName";
                    cbStaff1.ValueMember = "StaffID";

                    cbStaff2.DataSource = listStaff;
                    cbStaff2.DisplayMember = "FullName";
                    cbStaff2.ValueMember = "StaffID";
                }
                catch
                {
                    MessageBox.Show("Không Lấy Được Dữ Liệu Giáo Viên.", "Thông Báo");
                    Application.Exit();
                }
            }
            else
            {
                cbStaff1.DataSource = null;
                cbStaff2.DataSource = null;
            }
        }

        private void frmSpeaking_Load(object sender, EventArgs e)
        {
            cbShift_SelectedValueChanged(sender, e);
            cbShift_SelectedValueChanged(sender, e);
        }

        private void gvMain_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (gvMain.DataSource == null || (columnClick != "cScore" && columnClick != "cTopic"))
                return;
            try
            {
                string v = gvMain.Rows[e.RowIndex].Cells[columnClick].Value.ToString();
                if (v.IndexOf('.') >= 0) float.Parse(v);
                else int.Parse(v);
            }
            catch
            {
                MessageBox.Show("Chỉ Nhấp Số. Nếu là số thập phân sử dụng '.' thay vì ','.", "Sai Định Dạng");
                gvMain.CellValueChanged -= gvMain_CellValueChanged;
                gvMain.Rows[e.RowIndex].Cells[columnClick].Value = string.Empty;
                gvMain.CellValueChanged += gvMain_CellValueChanged;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnClick = gvMain.Columns[e.ColumnIndex].Name;
        }

        private void gvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int id;
            try
            {
                id = (int)gvMain.CurrentRow.Cells["cContestantShiftID"].Value;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                 e.RowIndex >= 0)
                {
                    try
                    {
                        ReportRoomDiagrams.FrmSpeakingScore frm = new ReportRoomDiagrams.FrmSpeakingScore(id);
                        if(frm!=null)
                        frm.ShowDialog();
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception ex) { }

        }
    }
    public class ContestantSpeakingResult
    {
        public int STT { get; set; }
        public string ShiftName { get; set; }
        public string ContestantCode { get; set; }
        public int ContestantShiftID { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string Score { get; set; }
        public string PrintResult { get; set; }
    }
}