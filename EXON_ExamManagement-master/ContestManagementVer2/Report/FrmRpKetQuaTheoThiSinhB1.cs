using ContestManagementVer2.CSDL_Exonsytem;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestManagementVer2.Report
{
    public partial class FrmRpKetQuaTheoThiSinhB1 : Form
    {
        private CONTESTANT thisinh = new CONTESTANT();
        private ExonSystem db = DAO.DBService.db;

        #region contructor
        public FrmRpKetQuaTheoThiSinhB1(CONTESTANT _ts)
        {
            InitializeComponent();
            thisinh = _ts;
            DAO.DBService.Reload();
        }
        #endregion


        #region LoadForm
        private void FrmRpKetQuaTheoThiSinh_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của ca thi
                
                REGISTER thongtin = db.REGISTERS.Where(p=>p.RegisterID == thisinh.RegisterID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == thongtin.ContestID).FirstOrDefault();

                CSDL_Luu_Tru.MTA_Quiz_Main z = new CSDL_Luu_Tru.MTA_Quiz_Main();

                string FullScore = "", Writing = "", Reading = "", Listening = "", Speaking = "";
                




                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("FullName",thongtin.FullName),
                    new ReportParameter("DOB",DAO.Helper.ConvertUnixToDateTime((int) thongtin.DOB).ToString("dd/MM/yyyy")),
                    new ReportParameter("SBD", thisinh.ContestantCode),
                    new ReportParameter("SDT", thongtin.TelephoneNumber),
                    new ReportParameter("Sex", thongtin.Sex == 0 ? "Nữ" : "Nam"),
                    new ReportParameter("CMND",thongtin.IdentityCardNumber),
                    new ReportParameter("Date",DateTime.Now.ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")),
                    new ReportParameter("POB",""),
                    new ReportParameter("FullScore", FullScore),
                    new ReportParameter("Writing", Writing),
                    new ReportParameter("Reading", Reading),
                    new ReportParameter("Listening",Listening),
                    new ReportParameter("Speaking", Speaking)
                };
                this.reportViewer1.LocalReport.SetParameters(listPara);


                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #endregion
    }
}
