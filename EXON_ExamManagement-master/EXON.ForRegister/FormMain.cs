using EXON.Common;
using EXON_EM.Data;
using EXON_EM.Data.Model;
using EXON_EM.Data.Service;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubData;
using EXON.SubModel;

namespace EXON.ForRegister
{
    public partial class FormMain : MetroForm
    {
        private int index = 0, index1 = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckConnectionString())
            {
                EXON.Register.frmRegister frm = new Register.frmRegister();
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            EXONSYSTEM.Layout.frmConfigApplication frm = new EXONSYSTEM.Layout.frmConfigApplication();
            this.Hide();
            frm.runwork();
            //frm.ShowDialog();
            //this.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (CheckConnectionStringMTAQuiz())
            {
                LoadDgvContest();
            }
            else
            {
                Application.Exit();
            }
        }

        private bool CheckConnectionString()
        {
            string conn2 = ConfigurationManager.ConnectionStrings["EXON_DbContext"].ConnectionString;
            SqlConnection connect2 = new SqlConnection(conn2);
            try
            {
                connect2.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối máy chủ thất bại\n" + ex.Message);
                return false;
            }
            finally
            {
                connect2.Close();
            }
            return true;
        }

        private bool CheckConnectionStringMTAQuiz()
        {
            string conn2 = ConfigurationManager.ConnectionStrings["MTA_QUIZ_1"].ConnectionString;
            SqlConnection connect2 = new SqlConnection(conn2);
            try
            {
                connect2.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối máy chủ thất bại\n" + ex.Message);
                return false;
            }
            finally
            {
                connect2.Close();
            }
            return true;
        }

        private void LoadDgvContest()
        {
            SubData.Services.ContestService conservice = new SubData.Services.ContestService();
            try
            {
                List<EXON.SubModel.Models.CONTEST> dsCuocThi = conservice.GetAll().Where(x => x.Status != (int)ContestStatus.ContestDone && x.Status != (int)ContestStatus.Cancel).ToList();
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
                    row.DefaultCellStyle.BackColor = getMauCuocThi(gt);
                }

                // Load Index
                dgvContest.Rows[index].Cells["STT"].Selected = true;
                dgvContest.Select();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return;
            }
        }

        private Color getMauCuocThi(int status)
        {
            switch (status)
            {
                case (int)ContestStatus.Cancel: return Color.Red;
                case (int)ContestStatus.ContestDone: return Color.Green;
                case (int)ContestStatus.PrepareTestDone: return Color.LightGreen;
                default: return Color.White;
            }
        }
    }
}