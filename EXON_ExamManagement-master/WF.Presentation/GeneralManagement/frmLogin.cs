using GeneralManagement.Common;
using MetroFramework.Forms;
using QuanLyHoiDongThiVer2.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralManagement
{
    public partial class frmLogin : MetroForm
    {
        private ConfigApplication ca;

        public frmLogin()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int per = 0;
            int staffid = Bus.BusALL.Instance.CheckLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim(), out per);
            if (staffid != 0)
            {
                AppSession.UserName = txtUserName.Text.Trim();
                AppSession.Password = txtPassword.Text.Trim();
                //AppSession.Permission = per;
                AppSession.StaffID = staffid;
                AppSession.LogTime = /*Convert.ToInt32(DatetimeConvert.ConvertDateTimeToUnix(DateTime.Now));*/ DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                //MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                if (Bus.BusALL.Instance.GetInfoSupervisor(staffid).EXAMINATIONCOUNCIL_POSITIONS.Permission == 1)
                {
                    //FrmMain form = new QuanLyHoiDongThiVer2.GUI.FrmMain(staffid);
                    //form.ShowDialog();
                }
                else
                {
                    Form frmSupervisorManage = new Supervisors.frmSupervisorManage(staffid);
                    frmSupervisorManage.ShowDialog();
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Lỗi đăng nhập", "Tài khoản không đúng, hoặc kết nối dữ liệu không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
            }
        }

        private void ceHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ceHienMatKhau.Checked)
                txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '*';
        }
    }
}