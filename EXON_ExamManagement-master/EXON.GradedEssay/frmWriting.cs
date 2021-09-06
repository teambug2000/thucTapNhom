using EXON.SubData.Services;
using EXON.SubModel.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GradedEssay
{
    public partial class frmWriting : MetroForm
    {
        #region Service
        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private StaffService _StaffService;
        private DivisionShiftService _DivisionShiftService;
        private ContestantShiftService _ContestantShiftService;
        private TestNumberService _TestNumberService;
        private ContestantTestService _ContestantTestService;
        private AnswersheetService _AnswersheetService;
        private AnswersheetWritingService _AnswersheetWritingService;
        #endregion Service

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

        public frmWriting(int contestID)
        {
            CurrentContestID = 51;
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
            _TestNumberService = new TestNumberService();
            _StaffService = new StaffService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetService = new AnswersheetService();
            _AnswersheetWritingService = new AnswersheetWritingService();
        }

        private void InitializeControl()
        {
            lbContest.Text = string.Format("Kì Thi: {0}", _ContestService.GetById(CurrentContestID).ContestName);

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

        private void cbShift_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentShiftID > 0 && CurrentSubjectID > 0)
            {
                DIVISION_SHIFTS ds = _DivisionShiftService.GetById(CurrentShiftID);
                SCHEDULE sc = _ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectID);
                if (ds != null && sc != null)
                {
                    List<ContestantResult> listContestant = (from cs in _ContestantShiftService.GetAllByScheduleShift(sc.ScheduleID, ds.DivisionShiftID)
                                                             from tn in _TestNumberService.GetAll()
                                                             where cs.ContestantShiftID == tn.ContestantShiftID
                                                             select new ContestantResult
                                                             {
                                                                 TestNumberIndex = ds.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                                                                 ContestantShiftID = tn.ContestantShiftID.Value,
                                                                 Score = GetScore(tn.ContestantShiftID),
                                                                 PrintAnswer ="In"

                                                             }).OrderBy(x => x.TestNumberIndex).ToList();

                    gvMain.DataSource = listContestant;
                }
            }
            else gvMain.DataSource = null;
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
                        ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                        if (aw != null)
                        {
                            return aw.WritingScore.ToString();
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbSubject_SelectedIndexChanged(sender, e);
            cbShift_SelectedValueChanged(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gvMain.DataSource != null)
            {
                int index = 0;
                foreach (DataGridViewRow row in gvMain.Rows)
                {
                    try
                    {
                        int contestantShiftID = int.Parse(row.Cells["cContestantShiftID"].Value.ToString());

                        string v = row.Cells["cScore"].Value.ToString();
                        float score;
                        if (v.IndexOf('.') >= 0) score = float.Parse(v);
                        else score = int.Parse(v);

                        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                        if (ct != null)
                        {
                            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                            if (anw != null)
                            {
                                ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                                if (aw != null)
                                {
                                    aw.WritingScore = score;
                                    aw.Status++;

                                    _AnswersheetWritingService.Update(aw);
                                }
                                else
                                {
                                    aw = new ANSWERSHEET_WRITING
                                    {
                                        AnswerSheetID = anw.AnswerSheetID,
                                        WritingScore = score,
                                        Status = 1
                                    };
                                    _AnswersheetWritingService.Add(aw);
                                }

                            }
                            else
                            {
                                MessageBox.Show(string.Format("Thí sinh {0} bỏ thi.", row.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");
                                continue;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Có Lối Xảy Ra", "Lối");
                            Log.Instance.WriteErrorLog(LogType.FATAL, string.Format("Contestant Test is null with ContestantShiftID = {0}", contestantShiftID));
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lối định dạng điểm thi hoặc ô để trống.", "Lối");

                        gvMain.ClearSelection();
                        gvMain.Rows[index].Selected = true;

                        Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                        return;
                    }
                    index++;
                }
                _AnswersheetWritingService.Save();
                MessageBox.Show("Nhập điểm thành công.", "Thông báo");
            }
        }

        private void gvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvMain.DataSource == null)
                return;
            try
            {
                string v = gvMain.Rows[e.RowIndex].Cells["cScore"].Value.ToString();
                if (v.IndexOf('.') >= 0) float.Parse(v);
                else int.Parse(v);
            }
            catch
            {
                MessageBox.Show("Chỉ Nhấp Số. Nếu là số thập phân sử dụng '.' thay vì ','.", "Sai Định Dạng");
                gvMain.CellValueChanged -= gvMain_CellValueChanged;
                gvMain.Rows[e.RowIndex].Cells["cScore"].Value = string.Empty;
                gvMain.CellValueChanged += gvMain_CellValueChanged;
            }
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
                        ReportRoomDiagrams.FormPrintAnswer frm = new ReportRoomDiagrams.FormPrintAnswer(id);
                        if(frm!=null)
                        frm.ShowDialog();
                    }
                    catch(Exception ex)
                    { }
                }
            }
            catch(Exception ex) { }
          
        }
    }

    public class ContestantResult
    {
        public string TestNumberIndex { get; set; }
        public int ContestantShiftID { get; set; }
        public string Score { get; set; }
        public string PrintAnswer { get; set; }
    }
}