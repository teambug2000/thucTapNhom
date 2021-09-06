using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoiDongThiVer2.report;
using EXON.SubModel.Models;
namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class ucTrangThaiDiaDiem : UserControl
    {
        private MTAQuizDbContext db = DAO.DBService.db;
        private LOCATION diadiem = new LOCATION();

        #region Hàm khởi tạo
        public ucTrangThaiDiaDiem(LOCATION a)
        {
            InitializeComponent();
            diadiem = a;
            DAO.DBService.Reload();
        }

        #endregion

        #region LoadForm
        private void LoadDgvPhongThi()
        {
            try
            {
                int stt = 0;
                var listPhongThi = db.ROOMTESTS.Where(p => p.LocationID == diadiem.LocationID).ToList()
                                   .Select(p => new
                                   {
                                       ID = p.RoomTestID,
                                       STT = ++stt,
                                       TenPhong = p.RoomTestName,
                                       SoCho = p.MaxSeatMount
                                   })
                                   .ToList();
                dgvPhongThi.DataSource = listPhongThi;
            }
            catch { }
        }

        private void LoadInitControl()
        {
            try
            {
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID && p.Status>0).FirstOrDefault();
                DateTime dt = DAO.Helper.ConvertUnixToDateTime((int) kithi.CreatedQuestionEndDate);
                dateNgayThi.Value = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

                cbxKip.SelectedIndex = 0;
            }
            catch { }
        }

        
        private void LoadDgvCaThi()
        {
            // 43200 là 12 giờ trưa

            try
            {
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                int stt = 0;
                var listCaThi = db.SHIFTS.Where(p => p.ContestID == kithi.ContestID && p.Status>0).ToList()
                                .Where(p => ok(p.ShiftDate, dateNgayThi.Value) && p.StartTime >= 43200 * cbxKip.SelectedIndex && p.StartTime< 43200*(cbxKip.SelectedIndex+1))
                                .ToList()
                                .Select(p => new
                                {
                                    ID = p.ShiftID,
                                    STT = ++stt,
                                    TenCaThi = p.ShiftName,
                                    NgayThi = DAO.Helper.ConvertUnixToDateTime(p.ShiftDate).ToString("dd/MM/yyyy"),
                                    BatDau = DAO.Helper.ConvertUnixToDateTime(p.StartTime).ToString("HH:mm"),
                                    KetThuc = DAO.Helper.ConvertUnixToDateTime(p.EndTime).ToString("HH:mm")
                                })
                                .ToList();

                dgvCaThi.DataSource = listCaThi;
            }
            catch
            {

            }
        }
        private void ucTrangThaiDiaDiem_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvPhongThi();
            LoadDgvCaThi();
        }
        #endregion

        #region sự kiện ngầm
        private void dateNgayThi_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvCaThi();
        }

        private void cbxKip_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvCaThi();
        }
        #endregion

        #region Hàm chức năng
        private bool ok(int x, DateTime k)
        {
            DateTime a = DAO.Helper.ConvertUnixToDateTime(x);

            if (a.Year != k.Year) return false;
            if (a.Month != k.Month) return false;
            if (a.Day != k.Day) return false;

            return true;
        }

        private DIVISION_SHIFTS GetDivisionShiftWithiD()
        {
            try
            {
                int shiftID, RoomtestID;
                shiftID = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                RoomtestID = (int)dgvPhongThi.SelectedRows[0].Cells["IDPhongThi"].Value;
                return db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == shiftID && p.RoomTestID == RoomtestID).First();
            }
            catch { }
            return new DIVISION_SHIFTS();   
        }

        #endregion

        #region Sự kiện
        private void btnTrangThaiPhongThi_Click(object sender, EventArgs e)
        {
            DIVISION_SHIFTS dv = GetDivisionShiftWithiD();
            if (dv.DivisionShiftID == 0)
            {
                MessageBox.Show("Chưa có ca thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmTrangThaiPhongThi tg = new FrmTrangThaiPhongThi(dv);
            tg.ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int RoomtestID = (int)dgvPhongThi.SelectedRows[0].Cells["IDPhongThi"].Value;
            ROOMTEST phongthi = db.ROOMTESTS.Where(p => p.RoomTestID == RoomtestID).FirstOrDefault();

            FrmRpKetQuaKipThi form = new FrmRpKetQuaKipThi(phongthi, dateNgayThi.Value, cbxKip.SelectedIndex);
            form.ShowDialog();
        }
        #endregion
    }
}
