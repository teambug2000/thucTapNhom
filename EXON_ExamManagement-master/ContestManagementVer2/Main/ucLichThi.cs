using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.Report;

namespace ContestManagementVer2.Main
{
    public partial class ucLichThi : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region Hàm khởi tạo
        public ucLichThi(CONTEST ct)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            kithi = ct;
        }
        #endregion

        #region LoadForm
        private void LoadDgvCaThi()
        {
            int i = 1;
            dgvCaThi.DataSource = (from ctg in db.SHIFTS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().OrderBy(p => p.ShiftDate)
                                   select new
                                   {
                                       ID = ctg.ShiftID,
                                       CaThi = ctg.ShiftName,
                                       BatDau = DAO.Helper.ConvertUnixToDateTime((int)ctg.StartTime).ToString("HH : mm"),
                                       KetThuc = DAO.Helper.ConvertUnixToDateTime((int)ctg.EndTime).ToString("HH : mm"),
                                       ShiftDate = ctg.ShiftDate
                                   }
                                  )
                                  .OrderBy(p => p.ShiftDate)
                                  .Select(p => new
                                  {
                                      ID = p.ID,
                                      CaThi = p.CaThi,
                                      BatDau = p.BatDau,
                                      KetThuc = p.KetThuc,
                                      ShiftDate = p.ShiftDate,
                                      STT = i++
                                  })
                                  .ToList();

            LoadDgvLichThi();
        }
        private void LoadDgvLichThi()
        {
            int i = 1;
            try
            {
                int Shiftid = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                int RoomTestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;

                int id = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == Shiftid && p.RoomTestID == RoomTestID).FirstOrDefault().DivisionShiftID;

                dgvLichThi.DataSource = (
                                            from lt in db.CONTESTANTS_SHIFTS.Where(pz => pz.Status == 1 && pz.ShiftID == id).ToList()
                                            from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && lt.ContestantID == pz.ContestantID).ToList()
                                            from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID && pz.RegisterID == ts.RegisterID).ToList()
                                            from mt in db.SCHEDULES.Where(pz => pz.Status == 1 && pz.ContestID == kithi.ContestID && pz.ScheduleID == lt.ScheduleID).ToList()
                                            select new
                                            {
                                                ID = lt.ContestantShiftID,
                                                SBD = ts.ContestantCode,
                                                STT = i++,
                                                HoTen = tt.FullName,
                                                NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)tt.DOB).ToString("dd/MM/yyyy"),
                                                MonThi = db.SUBJECTS.Where(p => p.SubjectID == mt.SubjectID).FirstOrDefault().SubjectName
                                            }
                                        ).ToList();
            }
            catch (Exception e)
            {
            }
        }
        private void LoadDgvPhongThi()
        {
            try
            {
                int i = 1;
                int ID = (int)cbxLocation.SelectedValue;

                dgvRoomTest.DataSource = db.ROOMTESTS.Where(p => p.LocationID == ID && p.Status > 0).ToList()
                                         .Select(p => new
                                         {
                                             IDPhongThi = p.RoomTestID,
                                             STT = i++,
                                             PhongThi = p.RoomTestName,
                                             SoLuong = p.MaxSeatMount
                                         })
                                         .ToList();
            }
            catch
            {
                // Chả có địa điểm nào được chọn :D
            }
        }
        private void LoadInitControl()
        {
            // Load CbxDia diem
            cbxLocation.DataSource = db.LOCATIONS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList();
            cbxLocation.DisplayMember = "LocationName";
            cbxLocation.ValueMember = "LocationID";

            LoadDgvPhongThi();
        }
        private void ucLichThi_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvCaThi();
        }
        #endregion

        #region Sự kiện ngầm
        private void dgvCaThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCaThi.SelectedRows.Count < 1) return;
            try
            {
                LoadDgvLichThi();
            }
            catch
            {

            }
        }

        private void cbxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvPhongThi();
        }

        private void dgvRoomTest_SelectionChanged(object sender, EventArgs e)
        {
            LoadDgvLichThi();
        }
        #endregion

        #region Sự kiện
        private void btnInLichThi_Click(object sender, EventArgs e)
        {
            try
            {
                int Shiftid = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                int RoomTestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;

                int id = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == Shiftid && p.RoomTestID == RoomTestID).FirstOrDefault().DivisionShiftID;

                DIVISION_SHIFTS dv = db.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == id).FirstOrDefault();
                FrmRpLichThiTheoCaThi lichthi = new FrmRpLichThiTheoCaThi(dv);
                lichthi.ShowDialog();
            }
            catch { }
        }

        private void btnInKetQuaCaThi_Click(object sender, EventArgs e)
        {
            try
            {
                int Shiftid = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                int RoomTestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;

                int id = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == Shiftid && p.RoomTestID == RoomTestID).FirstOrDefault().DivisionShiftID;

                DIVISION_SHIFTS dv = db.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == id).FirstOrDefault();
                FrmRpKetQuaTheoCaThi lichthi = new FrmRpKetQuaTheoCaThi(dv);
                lichthi.ShowDialog();
            }
            catch { }
        }

        private void btnInKetQuaThiSinh_Click(object sender, EventArgs e)
        {
            try
            {
                int ContestantShiftID = (int)dgvLichThi.SelectedRows[0].Cells["IDLichThi"].Value;
                CONTESTANTS_SHIFTS lt = db.CONTESTANTS_SHIFTS.Where(p => p.ContestantShiftID == ContestantShiftID).FirstOrDefault();
                CONTESTANT thisinh = db.CONTESTANTS.Where(p => p.ContestantID == lt.ContestantID).FirstOrDefault();

                FrmRpKetQuaTheoThiSinh form = new FrmRpKetQuaTheoThiSinh(thisinh);
                form.ShowDialog();
            }
            catch { }
        }
        #endregion

        #region Code xóa ca thi, thí sinh trong ca thi sau khi xếp lịch thi
        // Code xóa ca thi, thí sinh trong ca thi khi đã xếp lịch của anh Đại K51
        private void tmi_XoaCaThi_Click(object sender, EventArgs e)
        {
            if (dgvCaThi.CurrentRow.Cells["IDCaThi"] == null)
                return;
            int shiftID = Convert.ToInt32(dgvCaThi.CurrentRow.Cells["IDCaThi"].Value);
            string shiftName = db.SHIFTS.Where(p => p.ShiftID == shiftID).Select(p => p.ShiftName).FirstOrDefault();

            DialogResult confirm = MessageBox.Show("Chắc chắn xóa ca thi: " + shiftName, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                using (System.Data.Entity.DbContextTransaction tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        List<int> lstShift = db.SHIFTS.Where(p => p.ShiftID == shiftID).Select(p => p.ShiftID).ToList();
                        List<int> lstDivShf = db.DIVISION_SHIFTS.Where(p => lstShift.Contains(p.ShiftID)).Select(p => p.DivisionShiftID).ToList();
                        List<int> lstConShf = db.CONTESTANTS_SHIFTS.Where(p => lstDivShf.Contains(p.ShiftID)).Select(p => p.ContestantShiftID).ToList();
                        List<int> lstBagOfTest = db.BAGOFTESTS.Where(p => lstDivShf.Contains(p.DivisionShiftID)).Select(p => p.BagOfTestID).ToList();
                        List<int> lstTest = db.TESTS.Where(p => lstBagOfTest.Contains(p.BagOfTestID)).Select(p => p.TestID).ToList();
                        List<int> lstVioCon = db.VIOLATIONS_CONTESTANTS.Where(p => lstConShf.Contains(p.ContestantShiftID)).Select(p => p.ViolationDetailID).ToList();
                        List<int> lstConTest = db.CONTESTANTS_TESTS.Where(p => lstConShf.Contains(p.ContestantShiftID)).Select(p => p.ContestantTestID).ToList();
                        List<int> lstTestDetails = db.TEST_DETAILS.Where(p => lstTest.Contains(p.TestID)).Select(p => p.TestDetailID).ToList();
                        List<int> lstAnswerSheet = db.ANSWERSHEETS.Where(p => lstConTest.Contains(p.ContestantTestID)).Select(p => p.AnswerSheetID).ToList();
                        List<int> lstAnsSheetDetail = db.ANSWERSHEET_DETAILS.Where(p => lstAnswerSheet.Contains(p.AnswerSheetID)).Select(p => p.AnswerSheetDetailID).ToList();

                        // Bắt đầu xóa từ các bảng con trước, bảng cha sau
                        db.ANSWERSHEET_DETAILS.RemoveRange(db.ANSWERSHEET_DETAILS.Where(p => lstAnsSheetDetail.Contains(p.AnswerSheetDetailID)));
                        db.ANSWERSHEETS.RemoveRange(db.ANSWERSHEETS.Where(p => lstAnswerSheet.Contains(p.AnswerSheetID)));
                        db.TEST_DETAILS.RemoveRange(db.TEST_DETAILS.Where(p => lstTestDetails.Contains(p.TestDetailID)));
                        db.CONTESTANTS_TESTS.RemoveRange(db.CONTESTANTS_TESTS.Where(p => lstConTest.Contains(p.ContestantTestID)));
                        db.VIOLATIONS_CONTESTANTS.RemoveRange(db.VIOLATIONS_CONTESTANTS.Where(p => lstVioCon.Contains(p.ViolationDetailID)));
                        db.TESTS.RemoveRange(db.TESTS.Where(p => lstTest.Contains(p.TestID)));
                        db.BAGOFTESTS.RemoveRange(db.BAGOFTESTS.Where(p => lstBagOfTest.Contains(p.BagOfTestID)));
                        db.CONTESTANTS_SHIFTS.RemoveRange(db.CONTESTANTS_SHIFTS.Where(p => lstConShf.Contains(p.ContestantShiftID)));
                        db.DIVISION_SHIFTS.RemoveRange(db.DIVISION_SHIFTS.Where(p => lstDivShf.Contains(p.DivisionShiftID)));
                        db.SHIFTS.RemoveRange(db.SHIFTS.Where(p => lstShift.Contains(p.ShiftID)));
                        db.SaveChanges();

                        tran.Commit();
                        MessageBox.Show("Đã xóa ca thi: " + shiftName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thế xóa ca thi: " + shiftName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tran.Rollback();
                    }
                }
            }
        }

        private void tmi_XoaThiSinh_Click(object sender, EventArgs e)
        {
            if (dgvLichThi.CurrentRow.Cells["SBDThiSinh"] == null)
                return;
            string contestantCode = dgvLichThi.CurrentRow.Cells["SBDThiSinh"].Value.ToString();
            int contestantID = db.CONTESTANTS.Where(p => p.ContestantCode == contestantCode).Select(p => p.ContestantID).FirstOrDefault();
            string contestantName = db.CONTESTANTS.Where(p => p.ContestantCode == contestantCode).Select(p => p.REGISTER.FullName).FirstOrDefault();
            if (dgvCaThi.CurrentRow.Cells["IDCaThi"] == null)
                return;
            int shiftID = Convert.ToInt32(dgvCaThi.CurrentRow.Cells["IDCaThi"].Value);
            string shiftName = db.SHIFTS.Where(p => p.ShiftID == shiftID).Select(p => p.ShiftName).FirstOrDefault();

            DialogResult confirm = MessageBox.Show("Chắc chắn xóa thí sinh: " + contestantName + " khỏi ca thi: " + shiftName, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                using (System.Data.Entity.DbContextTransaction tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        List<int> lstDivShf = db.DIVISION_SHIFTS.Where(p => p.ShiftID == shiftID).Select(p => p.DivisionShiftID).ToList();
                        List<int> lstConShf = db.CONTESTANTS_SHIFTS.Where(p => p.ContestantID == contestantID && lstDivShf.Contains(p.ShiftID)).Select(p => p.ContestantShiftID).ToList();
                        List<int> lstVioCon = db.VIOLATIONS_CONTESTANTS.Where(p => lstConShf.Contains(p.ContestantShiftID)).Select(p => p.ViolationDetailID).ToList();
                        List<int> lstConTest = db.CONTESTANTS_TESTS.Where(p => lstConShf.Contains(p.ContestantShiftID)).Select(p => p.ContestantTestID).ToList();
                        List<int> lstAnswerSheet = db.ANSWERSHEETS.Where(p => lstConTest.Contains(p.ContestantTestID)).Select(p => p.AnswerSheetID).ToList();
                        List<int> lstAnsSheetDetail = db.ANSWERSHEET_DETAILS.Where(p => lstAnswerSheet.Contains(p.AnswerSheetID)).Select(p => p.AnswerSheetDetailID).ToList();

                        // Bắt đầu xóa từ các bảng con trước, bảng cha sau
                        db.ANSWERSHEET_DETAILS.RemoveRange(db.ANSWERSHEET_DETAILS.Where(p => lstAnsSheetDetail.Contains(p.AnswerSheetDetailID)));
                        db.ANSWERSHEETS.RemoveRange(db.ANSWERSHEETS.Where(p => lstAnswerSheet.Contains(p.AnswerSheetID)));
                        db.CONTESTANTS_TESTS.RemoveRange(db.CONTESTANTS_TESTS.Where(p => lstConTest.Contains(p.ContestantTestID)));
                        db.VIOLATIONS_CONTESTANTS.RemoveRange(db.VIOLATIONS_CONTESTANTS.Where(p => lstVioCon.Contains(p.ViolationDetailID)));
                        db.CONTESTANTS_SHIFTS.RemoveRange(db.CONTESTANTS_SHIFTS.Where(p => lstConShf.Contains(p.ContestantShiftID)));
                        db.SaveChanges();

                        tran.Commit();
                        MessageBox.Show("Đã xóa thí sinh: " + contestantName + " khỏi ca thi: " + shiftName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thế xóa thí sinh: " + contestantName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tran.Rollback();
                    }
                }
            }            
        }

        private void dgvCaThi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dgvCaThi.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    cms_Cathi.Show(dgvCaThi, new Point(e.X, e.Y));
                    dgvCaThi.CurrentCell = dgvCaThi.Rows[currentMouseOverRow].Cells[1];
                }
            }
        }

        private void dgvLichThi_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    int currentMouseOverRow = dgvLichThi.HitTest(e.X, e.Y).RowIndex;
            //    if (currentMouseOverRow >= 0)
            //    {
            //        cms_ThiSinhCaThi.Show(dgvLichThi, new Point(e.X, e.Y));
            //        dgvLichThi.CurrentCell = dgvLichThi.Rows[currentMouseOverRow].Cells[1];
            //    }
            //}
        }
        #endregion Code xóa ca thi, thí sinh trong ca thi sau khi xếp lịch thi
    }
}
