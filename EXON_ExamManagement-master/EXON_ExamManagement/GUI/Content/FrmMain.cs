using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Module;
using EXON_EM.Data;
using EXON_EM.Data.Model;
using EXON_EM.Data.Service;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace EXON_ExamManagement
{
    public partial class FrmMain : MetroForm
    {
        private int index = 0, index1 = 0;
        public static SqlConnection Sql = new SqlConnection( ConfigurationManager.ConnectionStrings["EXON_DbContext"].ConnectionString);

        public object FrmLapKeHoachThi { get; private set; }

        #region Constructor

        public FrmMain()
        {
            InitializeComponent();
            InitializeLogin();
        }

        #endregion Constructor

        #region LoadForm

        private void UpdateContestStatus()
        {
            //ContestService _contestService = new ContestService();
            //int idKiThi = 0;
            //try
            //{
            //    idKiThi = (int)dgvContest.Rows[index1].Cells["ID"].Value;
            //}
            //catch { }
            //var contest = _contestService.GetById(idKiThi);
            //if (contest != null)
            //{
            //    List<MetroButton> listButtonControl = new List<MetroButton>
            //{
            //    btnLapKeHoach,
            //    btnDangKiThi,
            //    btnSinhDeThiGoc,
            //    btnXepLich,
            //    btnSinhDeThi,
            //    btnChuanBiThi
            //    //btnToChucThi
            //};
            //    foreach (MetroButton b in listButtonControl)
            //        b.Enabled = false;
            //    int endEnable = 0;
            //    btnChuanBiThi.Enabled = true;
            //    switch ((ContestStatus)(contest.Status))
            //    {
            //        case ContestStatus.New:
            //            endEnable = 0;
            //            break;

            //        case ContestStatus.Accepted:
            //            endEnable = 1;
            //            break;

            //        case ContestStatus.RegisterDone:
            //            endEnable = 3;
            //            break;

            //        case ContestStatus.GenerateOriginalDone:
            //            endEnable = 3;
            //            break;

            //        case ContestStatus.ScheduleShiftDone:
            //            endEnable = 4;
            //            break;

            //        case ContestStatus.GenereateTestDone:
            //            endEnable = 5;
            //            break;
            //          case ContestStatus.PrepareTestDone:
            //               endEnable = 6;
            //             break;
            //        default:
            //            endEnable = 6;
            //    }
            //    for (int i = 0; i <= endEnable; i++)
            //    {
            //        listButtonControl[i].Enabled = true;
            //        if (i == 1) listButtonControl[2].Enabled = true;
            //    }
            //}
        }

        private void LoadInitControl()
        {
            List<STAFFS_POSITIONS> staffpositions = new Contest_Service().GetStaffPosition(BaseControl.CurrentStaffId);
            if (staffpositions != null)
            {
                foreach (STAFFS_POSITIONS item in staffpositions)
                {
                    if (item.POSITION.Permission == 1)
                    {
                        btnLapKeHoach.Enabled = btnDangKiThi.Enabled = btnSinhDeThi.Enabled = btnSinhDeThiGoc.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnXepLich.Enabled = true;
                    }
                    else
                    {
                        switch (item.POSITION.PositionCode)
                        {
                            case "TLKT":
                                btnLapKeHoach.Enabled = true;
                                btnChuanBiThi.Enabled = true;
                                btnSinhDeThi.Enabled = true;
                                btnXepLich.Enabled = true;
                                break;

                            case "CBTN":
                                btnDangKiThi.Enabled = true;
                                break;

                            case "GV":
                                btnSinhDeThiGoc.Enabled = true;
                                break;

                            case "CNBM":
                                btnSinhDeThiGoc.Enabled = true;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void LoadDgvContest()
        {
            if (btnDanhSachKeHoach.Text == "     Các kì thi đang diễn ra")
            {
                try
                {
                    List<CONTEST> dsCuocThi = new Contest_Service().getAll().Where(p => p.Status != (int)ContestStatus.Cancel).ToList();
                    //if (cbxLoai.SelectedIndex == 0)
                    //{
                    // kì thi đang diễn ra
                    //dsCuocThi = dsCuocThi.Where(p => p.Status != 3 && p.Status != 2).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 1)
                    //{
                    //    // kì thi đã kết thúc
                    //    dsCuocThi = dsCuocThi.Where(p => p.Status ==3 ).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 2)
                    //{
                    //    // kì thi theo khoảng thời gian
                    //    dsCuocThi = dsCuocThi
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.BeginDate) >= dateBatDau.Value)
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.EndDate) <= dateKetThuc.Value)
                    //                .ToList();
                    //}

                    int i = 0;
                    dgvContest.DataSource = dsCuocThi
                                            .Select(p => new
                                            {
                                                ID = p.ContestID,
                                                STT = ++i,
                                                TenKiThi = p.ContestName,
                                                TrangThai = Helper.TrangThaiKiThi(p.Status),
                                                Status = p.Status
                                            })
                                            .ToList();

                    // load Color
                    foreach (DataGridViewRow row in dgvContest.Rows)
                    {
                        int gt = (int)Convert.ToInt32(row.Cells["Status"].Value);
                        row.DefaultCellStyle.BackColor = ThamSoHeThong.getMauCuocThi(gt);
                    }

                    // Load Index
                    //index = index1;
                    //dgvContest.Rows[index].Cells["STT"].Selected = true;
                    //dgvContest.Select();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    List<CONTEST> dsCuocThi = new Contest_Service().getAll().Where(p => p.Status != (int)ContestStatus.Cancel && p.Status != (int)ContestStatus.ContestDone).ToList();
                    //if (cbxLoai.SelectedIndex == 0)
                    //{
                    // kì thi đang diễn ra
                    //dsCuocThi = dsCuocThi.Where(p => p.Status != (int)ContestStatus.ContestDone && p.Status != (int)ContestStatus.Cancel).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 1)
                    //{
                    //    // kì thi đã kết thúc
                    //    dsCuocThi = dsCuocThi.Where(p => p.Status ==3 ).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 2)
                    //{
                    //    // kì thi theo khoảng thời gian
                    //    dsCuocThi = dsCuocThi
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.BeginDate) >= dateBatDau.Value)
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.EndDate) <= dateKetThuc.Value)
                    //                .ToList();
                    //}

                    int i = 0;
                    dgvContest.DataSource = dsCuocThi
                                            .Select(p => new
                                            {
                                                ID = p.ContestID,
                                                STT = ++i,
                                                TenKiThi = p.ContestName,
                                                TrangThai = Helper.TrangThaiKiThi(p.Status),
                                                Status = p.Status
                                            })
                                            .ToList();

                    // load Color
                    foreach (DataGridViewRow row in dgvContest.Rows)
                    {
                        int gt = (int)Convert.ToInt32(row.Cells["Status"].Value);
                        row.DefaultCellStyle.BackColor = ThamSoHeThong.getMauCuocThi(gt);
                    }
                    btnDanhSachKeHoach.Text = "     Xem lại các kì thi";
                    // Load Index
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    return;
                }
            }
            try
            {
                dgvContest.Rows[0].Selected = true;
            }
            catch { }
        }

        private void LoadIndex()
        {
            index = index1;
            dgvContest.Rows[index].Cells["STT"].Selected = true;
            dgvContest.Select();
        }

        private void UpdateStatusRegistedContest()
        {
            Contest_Service consv = new Contest_Service();
            List<CONTEST> lstcon = new List<CONTEST>();
            lstcon = consv.getAll().Where(p => p.Status == (int)ContestStatus.PrepareTestDone).ToList();
            foreach (CONTEST con in lstcon)
            {
                //if(con.EndRegistration< DateTimeHelpers.ConvertDateTimeToUnix( SystemTimeService.Now))
                //{
                //    con.Status = 4;
                //    try
                //    {
                //        consv.Update(con);
                //        consv.Save();
                //    }
                //    catch
                //    {
                //    }
                //}
                if (con.EndDate < DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now))
                {
                    con.Status = (int)ContestStatus.ContestDone;
                    try
                    {
                        consv.Update(con);
                        consv.Save();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //LoadInitControl();
            //UpdateStatusRegistedContest();
            LoadDgvContest();
            LoadLabelTime();
        }

        #endregion LoadForm

        private void LoadLabelTime()
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                CONTEST con = new Contest_Service().Find(idKiThi);
                lbRegisterFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.BeginRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbRegisterTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.EndRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeGocFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.BeginRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeGocTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionStartDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbXepLichThiFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.EndRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbXepLichThiTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionStartDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeThiFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionStartDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeThiTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionEndDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbChuanBiThiFrom.Text = "Từ : " + "Sau khi sinh đề thi xong.";
                lbChuanBiThiTo.Text = "Đến: " + "Trước khi thi.";
                lbGiamSatFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime((int)con.BeginDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbGiamSatTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime((int)con.EndDate).ToString("HH:mm:ss dd/MM/yyyy");
            }
            catch
            {
                //MessageBox.Show("Chưa chọn kì thi",
                //               "Thông báo",
                //               MessageBoxButtons.OK,
                //               MessageBoxIcon.Error);
            }
        }

        #region Sự kiện

        private void btnLapKeHoachThi_Click(object sender, EventArgs e)
        {
            ContestManagementVer2.Main.Start z = new ContestManagementVer2.Main.Start();
            z.LapKeHoachThi(BaseControl.CurrentStaffId);
            LoadDgvContest();
        }

        private void btnDanhSachKeHoach_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLyKiThi_Click(object sender, EventArgs e)
        {
        }

        #endregion Sự kiện

        private EXON.Main.Module.Forms.FrmLogin login;

        private void InitializeLogin()
        {
            if (login == null) login = new EXON.Main.Module.Forms.FrmLogin();
            this.Hide();
            login.ShowDialog();
            if (login.LoginStatus == EXON.Common.LoginStatus.Login)
            {
                BaseControl.CurrentStaffId = login.CurrentStaffId;
                this.Show();
            }
            else if (login.LoginStatus == LoginStatus.Close)
            {
                if (Application.MessageLoop)
                    Application.Exit();
                else Environment.Exit(1);
            }
        }

        #region Sự kiện ngầm

        private void dateKetThuc_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvContest();
        }

        private void cbxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvContest();
        }

        private void dgvContest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ucTrangThaiKiThi uc = new ucTrangThaiKiThi();
            //panelStatus.Controls.Clear();
            //panelStatus.Controls.Add(uc);
            try
            {
                index = dgvContest.SelectedRows[0].Index;
                index1 = index;
                CheckContest();
                LoadLabelTime();
                //UpdateContestStatus();
            }
            catch
            {
            }
            // CheckContest();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnLapKeHoach_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                if (idKiThi > 0)
                {
                    ContestManagementVer2.Main.Start z = new ContestManagementVer2.Main.Start();
                    z.QuanLyKeHoachThi(BaseControl.CurrentStaffId, idKiThi);
                    LoadDgvContest();
                    UpdateContestStatus();
                    LoadIndex();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnDangKiThi_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                if (idKiThi > 0)
                {
                    EXON.RegisterManager.Module.frmMain formMain = new EXON.RegisterManager.Module.frmMain(idKiThi, BaseControl.CurrentStaffId);
                    formMain.Show();
                    UpdateContestStatus();
                    LoadIndex();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSinhDeThiGoc_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                if (idKiThi > 0)
                {
                    EXON.GenerateTest.frmMain test = new EXON.GenerateTest.frmMain(idKiThi, 0, BaseControl.CurrentStaffId, Sql.ToString());
                    test.ShowDialog();
                    LoadDgvContest();
                    UpdateContestStatus();
                    LoadIndex();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnToChucThi_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralManagement.Supervisors.frmSupervisorManage temp = new GeneralManagement.Supervisors.frmSupervisorManage(BaseControl.CurrentStaffId);
                if (temp != null)
                    temp.ShowDialog();
                UpdateContestStatus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnChuanBiThi_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                if (idKiThi > 0)
                {
                    CreateDB.MFrmMain temp = new CreateDB.MFrmMain(idKiThi, BaseControl.CurrentStaffId);
                    temp.ShowDialog();
                    LoadDgvContest();
                    UpdateContestStatus();
                    LoadIndex();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                if (idKiThi > 0)
                {
                    ContestManagementVer2.Main.Start z = new ContestManagementVer2.Main.Start();
                    z.XepLich(BaseControl.CurrentStaffId, idKiThi);
                    LoadDgvContest();
                    UpdateContestStatus();
                    LoadIndex();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mbtnCauHinhHeThong_Click(object sender, EventArgs e)
        {
            //string _pass = "123456";
            //string _user = "admin";
            ExamManagement.GUI.FrmMain frm = new ExamManagement.GUI.FrmMain(BaseControl.CurrentStaffId);
            frm.ShowDialog();
        }

        private void mbtnChuyenDuLieuVe_Click(object sender, EventArgs e)
        {
            bool _checkExam = false;
            string conn = ConfigurationManager.ConnectionStrings["MTA_QUIZ"].ConnectionString;
            SqlConnection connect = new SqlConnection(conn);
            try
            {
                connect.Open();
                _checkExam = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối server thi thất bại\n" + ex.ToString());
            }
            finally
            {
                connect.Close();
            }
            if (_checkExam)
            {
                CreateDB.frmLoading2 frm = new CreateDB.frmLoading2();
                frm.ShowDialog();
            }
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
        }

        private void btnDanhSachKeHoach_Click_1(object sender, EventArgs e)
        {
            if (btnDanhSachKeHoach.Text == "     Xem lại các kì thi")
            {
                btnDanhSachKeHoach.Text = "     Các kì thi đang diễn ra";
            }
            else
            {
                btnDanhSachKeHoach.Text = "     Xem lại các kì thi";
            }
            LoadDgvContest();
        }

        private void mbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSinhDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                if (idKiThi > 0)
                {
                    string conn = Sql.ConnectionString.ToString();
                    EXON.GenerateTest.frmMain test = new EXON.GenerateTest.frmMain(idKiThi, 1, BaseControl.CurrentStaffId, conn);
                    test.ShowDialog();
                    LoadDgvContest();
                    LoadIndex();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void timerUpdateSTTContest_Tick(object sender, EventArgs e)
        {
            //CheckContest();
        }

        private void dgvContest_SelectionChanged(object sender, EventArgs e)
        {
            UpdateContestStatus();
        }

        private void mbtnChamThi_Click(object sender, EventArgs e)
        {
            int idcon = 0;
            try
            {
                idcon = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
            }
            catch { }
            EXON.GradedEssay.frmMain frm = new EXON.GradedEssay.frmMain(51);
            frm.Show();
        }

        private void btn_XoaKyThi_Click(object sender, EventArgs e)
        {
            if (dgvContest.SelectedRows == null)
                MessageBox.Show("Vui lòng chọn 1 kỳ thi");
            int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
            if (idKiThi > 0)
            {
                DialogResult confirm = MessageBox.Show("Chắc chắn xóa kỳ thi đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    EXON_DbContext db = new EXON_DbContext();
                    using (System.Data.Entity.DbContextTransaction tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // Level 2
                            List<int> lstExamConcilStaft = db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.ContestID == idKiThi).Select(p => p.ExaminationCouncil_StaffID).ToList();
                            List<int> lstContestFee = db.CONTEST_FEES.Where(p => p.ContestID == idKiThi).Select(p => p.ContestFee).ToList();
                            List<int> lstLocation = db.LOCATIONS.Where(p => p.ContestID == idKiThi).Select(p => p.LocationID).ToList();
                            List<int> lstGroup = db.GROUPS.Where(p => p.ContestID == idKiThi).Select(p => p.GroupID).ToList();
                            List<int> lstSchdule = db.SCHEDULES.Where(p => p.ContestID == idKiThi).Select(p => p.ScheduleID).ToList();
                            List<int> lstOriginalTest = db.ORIGINAL_TESTS.Where(p => p.ContestID == idKiThi).Select(p => p.OriginalTestID).ToList();
                            List<int> lstShift = db.SHIFTS.Where(p => p.ContestID == idKiThi).Select(p => p.ShiftID).ToList();
                            List<int> lstRegister = db.REGISTERS.Where(p => p.ContestID == idKiThi).Select(p => p.RegisterID).ToList();
                            List<int> lstContestants = db.CONTESTANTS.Where(p => lstRegister.Contains(p.RegisterID)).Select(p => p.ContestantID).ToList();
                            List<int> lstRegSub = db.REGISTERS_SUBJECTS.Where(p => lstRegister.Contains(p.RegisterID)).Select(p => p.RegisterSubjectID).ToList();
                            List<int> lstReceipts = db.RECEIPTS.Where(p => lstRegister.Contains(p.RegisterID)).Select(p => p.ReceiptID).ToList();
                            // Level 3
                            List<int> lstRoomtest = db.ROOMTESTS.Where(p => lstLocation.Contains((int)p.LocationID)).Select(p => p.RoomTestID).ToList();
                            List<int> lstGroupSub = db.GROUP_SUBJECTS.Where(p => lstGroup.Contains((int)p.GroupID)).Select(p => p.Group_SubjectID).ToList();
                            List<int> lstStructure = db.STRUCTURES.Where(p => lstSchdule.Contains(p.ScheduleID)).Select(p => p.StructureID).ToList();
                            List<int> lstConSub = db.CONTESTANTS_SUBJECTS.Where(p => lstContestants.Contains((int)p.ContestantID)).Select(p => p.ContestantSubjectID).ToList();
                            List<int> lstFinger = db.FINGERPRINTS.Where(p => lstContestants.Contains(p.ContestantID)).Select(p => p.FingerprintID).ToList();
                            List<int> lstPart = db.PARTS.Where(p => lstSchdule.Contains((int)p.ScheduleID)).Select(p => p.PartID).ToList();               
                            // Level 4
                            List<int> lstDivShf = db.DIVISION_SHIFTS.Where(p => lstShift.Contains(p.ShiftID)).Select(p => p.DivisionShiftID).ToList();
                            List<int> lstRoomDiagram = db.ROOMDIAGRAMS.Where(p => lstRoomtest.Contains(p.RoomTestID)).Select(p => p.RoomDiagramID).ToList();
                            List<int> lstStrucDetail = db.STRUCTURE_DETAILS.Where(p => lstStructure.Contains(p.StructureID)).Select(p => p.StructureDetailID).ToList();
                            List<int> lstPartDetail = db.PARTS_DETAILS.Where(p => lstPart.Contains((int)p.PartID)).Select(p => p.PartDetailID).ToList();
                            // Level 5
                            List<int> lstConShf = db.CONTESTANTS_SHIFTS.Where(p => lstDivShf.Contains(p.ShiftID) && lstContestants.Contains(p.ContestantID)).Select(p => p.ContestantShiftID).ToList();
                            List<int> lstBagOfTest = db.BAGOFTESTS.Where(p => lstDivShf.Contains(p.DivisionShiftID)).Select(p => p.BagOfTestID).ToList();
                            // Level 6
                            List<int> lstTest = db.TESTS.Where(p => lstBagOfTest.Contains(p.BagOfTestID)).Select(p => p.TestID).ToList();
                            List<int> lstVioCon = db.VIOLATIONS_CONTESTANTS.Where(p => lstConShf.Contains(p.ContestantShiftID)).Select(p => p.ViolationDetailID).ToList();
                            // Level 7
                            List<int> lstConTest = db.CONTESTANTS_TESTS.Where(p => lstConShf.Contains(p.ContestantShiftID)).Select(p => p.ContestantTestID).ToList();
                            List<int> lstTestDetails = db.TEST_DETAILS.Where(p => lstTest.Contains(p.TestID)).Select(p => p.TestDetailID).ToList();
                            List<int> lstOriTestDetail = db.ORIGINAL_TEST_DETAILS.Where(p => lstOriginalTest.Contains(p.OriginalTestID)).Select(p => p.OriginalTestDetailID).ToList();
                            // Level 8
                            List<int> lstAnswerSheet = db.ANSWERSHEETS.Where(p => lstConTest.Contains(p.ContestantTestID)).Select(p => p.AnswerSheetID).ToList();
                            // Level 9
                            List<int> lstAnsSheetDetail = db.ANSWERSHEET_DETAILS.Where(p => lstAnswerSheet.Contains(p.AnswerSheetID)).Select(p => p.AnswerSheetDetailID).ToList();

                            // Bắt đầu xóa từ các bảng con trước, bảng cha sau
                            db.ANSWERSHEET_DETAILS.RemoveRange(db.ANSWERSHEET_DETAILS.Where(p => lstAnsSheetDetail.Contains(p.AnswerSheetDetailID)));

                            db.ANSWERSHEETS.RemoveRange(db.ANSWERSHEETS.Where(p => lstAnswerSheet.Contains(p.AnswerSheetID)));

                            db.ORIGINAL_TEST_DETAILS.RemoveRange(db.ORIGINAL_TEST_DETAILS.Where(p => lstOriTestDetail.Contains(p.OriginalTestDetailID)));
                            db.TEST_DETAILS.RemoveRange(db.TEST_DETAILS.Where(p => lstTestDetails.Contains(p.TestDetailID)));
                            db.CONTESTANTS_TESTS.RemoveRange(db.CONTESTANTS_TESTS.Where(p => lstConTest.Contains(p.ContestantTestID)));

                            db.VIOLATIONS_CONTESTANTS.RemoveRange(db.VIOLATIONS_CONTESTANTS.Where(p => lstVioCon.Contains(p.ViolationDetailID)));
                            db.TESTS.RemoveRange(db.TESTS.Where(p => lstTest.Contains(p.TestID)));

                            db.BAGOFTESTS.RemoveRange(db.BAGOFTESTS.Where(p => lstBagOfTest.Contains(p.BagOfTestID)));
                            db.CONTESTANTS_SHIFTS.RemoveRange(db.CONTESTANTS_SHIFTS.Where(p => lstConShf.Contains(p.ContestantShiftID)));

                            db.PARTS_DETAILS.RemoveRange(db.PARTS_DETAILS.Where(p => lstPartDetail.Contains(p.PartDetailID)));
                            db.STRUCTURE_DETAILS.RemoveRange(db.STRUCTURE_DETAILS.Where(p => lstStrucDetail.Contains(p.StructureDetailID)));
                            db.ROOMDIAGRAMS.RemoveRange(db.ROOMDIAGRAMS.Where(p => lstRoomDiagram.Contains(p.RoomDiagramID)));
                            db.DIVISION_SHIFTS.RemoveRange(db.DIVISION_SHIFTS.Where(p => lstDivShf.Contains(p.DivisionShiftID)));

                            db.PARTS.RemoveRange(db.PARTS.Where(p => lstPart.Contains(p.PartID)));
                            db.FINGERPRINTS.RemoveRange(db.FINGERPRINTS.Where(p => lstFinger.Contains(p.FingerprintID)));
                            db.CONTESTANTS_SUBJECTS.RemoveRange(db.CONTESTANTS_SUBJECTS.Where(p => lstConSub.Contains(p.ContestantSubjectID)));
                            db.STRUCTURES.RemoveRange(db.STRUCTURES.Where(p => lstStructure.Contains(p.StructureID)));
                            db.GROUP_SUBJECTS.RemoveRange(db.GROUP_SUBJECTS.Where(p => lstGroupSub.Contains(p.Group_SubjectID)));
                            db.ROOMTESTS.RemoveRange(db.ROOMTESTS.Where(p => lstRoomtest.Contains(p.RoomTestID)));

                            db.RECEIPTS.RemoveRange(db.RECEIPTS.Where(p => lstReceipts.Contains(p.ReceiptID)));
                            db.REGISTERS_SUBJECTS.RemoveRange(db.REGISTERS_SUBJECTS.Where(p => lstRegSub.Contains(p.RegisterSubjectID)));
                            db.CONTESTANTS.RemoveRange(db.CONTESTANTS.Where(p => lstContestants.Contains(p.ContestantID)));
                            db.REGISTERS.RemoveRange(db.REGISTERS.Where(p => lstRegister.Contains(p.RegisterID)));
                            db.SHIFTS.RemoveRange(db.SHIFTS.Where(p => lstShift.Contains(p.ShiftID)));
                            db.ORIGINAL_TESTS.RemoveRange(db.ORIGINAL_TESTS.Where(p => lstOriginalTest.Contains(p.OriginalTestID)));
                            db.SCHEDULES.RemoveRange(db.SCHEDULES.Where(p => lstSchdule.Contains(p.ScheduleID)));
                            db.GROUPS.RemoveRange(db.GROUPS.Where(p => lstGroup.Contains(p.GroupID)));
                            db.LOCATIONS.RemoveRange(db.LOCATIONS.Where(p => lstLocation.Contains(p.LocationID)));
                            db.CONTEST_FEES.RemoveRange(db.CONTEST_FEES.Where(p => lstContestFee.Contains(p.ContestFee)));
                            db.EXAMINATIONCOUNCIL_STAFFS.RemoveRange(db.EXAMINATIONCOUNCIL_STAFFS.Where(p => lstExamConcilStaft.Contains(p.ExaminationCouncil_StaffID)));

                            db.CONTESTS.RemoveRange(db.CONTESTS.Where(p => p.ContestID == idKiThi));
                            db.SaveChanges();
                            tran.Commit();
                            MessageBox.Show("Đã xóa kỳ thi");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xóa kỳ thi không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tran.Rollback();
                        }
                    }                    
                    LoadDgvContest();
                }
            }
        }

        private void CheckContest()
        {
            int idcon = 0;
            try
            {
                idcon = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
            }
            catch { }
            Contest_Service consv = new Contest_Service();
            CONTEST con = consv.Find(idcon);
            long timenow = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
            if (con != null)
            {
                if (con.EndDate < timenow)
                {
                    if (con.Status != (int)ContestStatus.ContestDone)
                    {
                        con.Status = (int)ContestStatus.ContestDone;
                        try
                        {
                            consv.Update(con);
                            consv.Save();
                            LoadDgvContest();
                        }
                        catch
                        {
                        }
                    }
                }
                else if (con.Status != (int)ContestStatus.New)
                {
                    if (timenow > con.EndRegistration)
                    {
                        if (con.Status == (int)ContestStatus.Accepted) //trạng thái đăng ký
                        {
                            con.Status = (int)ContestStatus.RegisterDone;
                            try
                            {
                                consv.Update(con);
                                consv.Save();
                                LoadDgvContest();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                            //btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                            //btnXepLich.Enabled = true;
                            //btnSinhDeThiGoc.Enabled = true;
                        }
                        //if (timenow > con.CreatedQuestionStartDate && timenow < con.CreatedQuestionEndDate)
                        //{
                        //    if (con.Status == 5) // trạng thái đã xếp lịch
                        //    {
                        //        //btnLapKeHoach.Enabled = btnXepLich.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                        //        //btnSinhDeThi.Enabled = true;
                        //        //btnSinhDeThiGoc.Enabled = true;
                        //    }
                        //    else
                        //    {
                        //        if (con.Status == 6)
                        //        {
                        //            //btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnXepLich.Enabled = btnSinhDeThiGoc.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                        //            //btnChuanBiThi.Enabled = true;

                        //        }
                        //        else
                        //        {
                        //            //btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                        //            //btnXepLich.Enabled = true;
                        //            //btnSinhDeThiGoc.Enabled = true;
                        //        }
                        //    }
                        //}
                        //else if (con.Status == 7)
                        //{
                        //    //btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnSinhDeThiGoc.Enabled = btnXepLich.Enabled = btnDangKiThi.Enabled = false;
                        //    //btnChuanBiThi.Enabled = btnToChucThi.Enabled = true;
                        //}
                    }
                    //else
                    //{
                    //    if (con.Status == 4) //trạng thái đã hoàn thành đăng ký
                    //    {
                    //        //btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                    //        //btnXepLich.Enabled = true;
                    //        //btnSinhDeThiGoc.Enabled = true;
                    //    }
                    //    else
                    //    {
                    //        //btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnSinhDeThiGoc.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnXepLich.Enabled = false;
                    //        //btnDangKiThi.Enabled = true;
                    //    }
                    //}
                }
                else
                {
                    //btnDangKiThi.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnXepLich.Enabled = false;
                    //btnLapKeHoach.Enabled = true;
                }
            }
        }

        #endregion Sự kiện ngầm
    }
}