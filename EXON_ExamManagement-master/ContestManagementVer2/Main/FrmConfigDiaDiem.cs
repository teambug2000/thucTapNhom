using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.XepLichThi;
using EXON.Common;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestManagementVer2.Main
{
    public partial class FrmConfigDiaDiem : MetroForm
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();
        private List<TinhThanh> listTinhThanh = new List<TinhThanh>();

        #region Hàm khởi tạo
        public FrmConfigDiaDiem(CONTEST kt)
        {
            InitializeComponent();
            kithi = kt;
        }

        public FrmConfigDiaDiem(int ContestID)
        {
            InitializeComponent();
            kithi = db.CONTESTS.Where(p => p.ContestID == ContestID).FirstOrDefault();
        }
        #endregion


        #region LoadForm

        private void LoadInitControl()
        {
            /// Load danh sách địa điểm
            cbxDiaDiemThi.DataSource = ThamSoHeThong.ListLocation;

            cbxDiaDiemThi.DisplayMember = "LocationName";
            cbxDiaDiemThi.ValueMember = "LocationID";


            if (kithi.Status >= (int)ContestStatus.ScheduleShiftDone)
            {
                btnSelect.Enabled = false;
                btnRemove.Enabled = false;

                MessageBox.Show("Kì thi đã được xếp lịch nên không thể thay đổi cấu hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            // load danh sách lưu trong biến static
            if (kithi.ContestID != ThamSoHeThong.kithi.ContestID)
            {
                ThamSoHeThong.kithi = kithi;
                ThamSoHeThong.LoadTinhThanh();
            }

            // load ưu tiên xếp lịch
            if (ThamSoHeThong.UuTienXepLich == 0)
                rdUuTienMonThi.Checked = true;
            else
                rdUuTienThiSinh.Checked = true;

            listTinhThanh = ThamSoHeThong.listTinhThanh;
        }

        private void LoadDgvTinhThanh()
        {
            // Load danh sách các tỉnh chưa được phân công
            try
            {
                int tt = 0;
                dgvDsTinhThanh.DataSource = listTinhThanh.Where(p => p.LocationID == -1).ToList()
                                            .Select(p => new
                                            {
                                                STT = ++tt,
                                                Ten = p.Ten,
                                                SoLuong = p.SoLuong
                                            })
                                            .ToList();
            }
            catch
            {

            }
        }

        private void LoadDgvDiaDiem_TinhThanh()
        {
            try
            {
                int LocationID = (int) cbxDiaDiemThi.SelectedValue;

                // Load các danh sách các tỉnh thành thuộc các địa điểm
                int tt = 0;
                dgvDiaDiem_Tinh.DataSource = listTinhThanh.Where(p => p.LocationID == LocationID)
                                             .Select(p => new
                                             {
                                                 STT = ++tt,
                                                 Ten = p.Ten,
                                                 SoLuong = p.SoLuong
                                             })
                                             .ToList();


                int SoLuong = listTinhThanh.Where(p => p.LocationID == LocationID)
                                             .Select(p => new
                                             {
                                                 STT = ++tt,
                                                 Ten = p.Ten,
                                                 SoLuong = p.SoLuong
                                             })
                                             .ToList()
                                             .Sum(p => p.SoLuong);

                int SoCho = db.ROOMTESTS.Where(p => p.LocationID == LocationID && p.Status > 0).Sum(p => p.MaxSeatMount);

                txtSoLuongThiSinh.Text = SoLuong.ToString();
                txtTongSoCho.Text = SoCho.ToString();

            }
            catch { }

        }

        private void FrmConfigDiaDiem_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadInitControl();
            LoadDgvTinhThanh();
            LoadDgvDiaDiem_TinhThanh();
        }
        #endregion


        #region Sự kiện
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                int LocationID = (int)cbxDiaDiemThi.SelectedValue;
                string TenTinh = (string) dgvDsTinhThanh.SelectedRows[0].Cells["Ten"].Value;

                TinhThanh tinh = ThamSoHeThong.listTinhThanh.Where(p => p.Ten == TenTinh).FirstOrDefault();
                tinh.LocationID = LocationID;

                LoadDgvTinhThanh();
                LoadDgvDiaDiem_TinhThanh();

                CheckXepLich();
            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string TenTinh = (string)dgvDiaDiem_Tinh.SelectedRows[0].Cells["Ten2"].Value;

                TinhThanh tinh = ThamSoHeThong.listTinhThanh.Where(p => p.Ten == TenTinh).FirstOrDefault();
                tinh.LocationID = -1;

                LoadDgvDiaDiem_TinhThanh();
                LoadDgvTinhThanh();

                CheckXepLich();
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            /// Xếp lịch :D

            XepLich lichthi = new XepLich(kithi);

            int type = 0;
            if (rdUuTienMonThi.Checked) type = 1; else type = 0;
            int z = lichthi.Run(type);

            // nếu z == 0 => xếp lịch bị lỗi
            if (z == 0)
            {
                return;
            }


            kithi.Status = (int)ContestStatus.ScheduleShiftDone;
            db.SaveChanges();

            MessageBox.Show("Xếp lịch thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Close();

            ThamSoHeThong.DaXepLich = true;
        }

        #endregion

        #region Sự kiện ngầm
        private void cbxDiaDiemThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvDiaDiem_TinhThanh();
        }
        

        private void rdUuTienThiSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdUuTienMonThi.Checked) ThamSoHeThong.UuTienXepLich = 0; else ThamSoHeThong.UuTienXepLich = 1;
        }
        #endregion

        #region Hàm chức năng
        private void CheckXepLich()
        {
            btnXepLich.Enabled = false;

            // Đã xếp lịch thì sẽ không cho phép bấm vào nút đã xếp lịch
            if (kithi.Status >= (int)ContestStatus.ScheduleShiftDone) return;

            try
            {
                int Sum = ThamSoHeThong.listTinhThanh.Where(p => p.LocationID == -1).ToList().Count;
                if (Sum == 0) btnXepLich.Enabled = true;
            }
            catch
            {

            }
        }
        #endregion

        
    }
}
