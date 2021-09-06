using EXON.SubData.Services;

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
using EXON.MONITOR.Common;
using EXON.SubModel.Models;
using QuanLyHoiDongThiVer2.DAO;
namespace EXON.MONITOR.GUI
{
    
    public partial class frmLogin : MetroForm
    {
       
        private  ExaminationcouncilStaffService _ExaminationcouncilStaffService;
     
        public frmLogin()
        {
            InitializeComponent();
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            txtUserName.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Không được để trống","Thông báo");
                    return;
                }
                else
                {
                    if (_ExaminationcouncilStaffService.Login(txtUserName.Text, txtPassword.Text))
                    {

                        EXAMINATIONCOUNCIL_STAFFS staff = _ExaminationcouncilStaffService.GetStaffByLogin(txtUserName.Text, txtPassword.Text);
                        AppSession.UserName = txtUserName.Text.Trim();
                        AppSession.Password = txtPassword.Text.Trim();

                        AppSession.Permission = staff.EXAMINATIONCOUNCIL_POSITIONS.Permission??default(int);
                        AppSession.StaffID = staff.STAFF.StaffID;
                        AppSession.LogTime =  DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                        this.Hide();
                        if (staff.EXAMINATIONCOUNCIL_POSITIONS.Permission == 1)
                        {
                            QuanLyHoiDongThiVer2.GUI.FrmMain frm = new QuanLyHoiDongThiVer2.GUI.FrmMain(staff.STAFF.StaffID);
                            frm.ShowDialog();
                        }
                        else
                        {
                            frmSupervisorManage form = new frmSupervisorManage(AppSession.StaffID);
                            form.ShowDialog();
                        }
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.NotLoginMessage, Properties.Resources.Notification);
                        txtPassword.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                //MessageBox.Show(Properties.Resources.NotConnectServerMessage, Properties.Resources.Error);
                return;
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