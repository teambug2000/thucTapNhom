using ContestManagementVer2.ImportLichThi;
using EXON.Common;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmLoading : Form
    {
        //int _idkithi;
        //List<InfoContestant> listLichThi;
        //List<KhoiThi> listKhoiThi;
        //public frmLoading()
        //{
        //    InitializeComponent();
        //    _idkithi = _id;
        //    listLichThi = lstLichThi;
        //    listKhoiThi = lstKhoiThi;
        //}
        public frmLoading()
        {
            InitializeComponent();
        }

        public void ImportContestant(int _idkithi, List<InfoContestant> listLichThi)
        {
            lbtext.Text = "Đang xếp lịch thi...";
            ImportLichThiHelper.ImportLichThi(_idkithi, listLichThi);
            lbPercent.Visible = false;
        }

        public List<InfoContestant> GetContestant(string FileName)
        {
            lbtext.Text = "Đang lấy dữ liệu...";
            List<InfoContestant> lstresult = new List<InfoContestant>();
            int dem = 0;

            try
            {
                EOSDbContext db = new EOSDbContext();
                CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                var xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FileName, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                int startindex = 1;
                for (int i = 1; i < rowCount; i++)
                {
                    string item = "";
                    try
                    {
                        item = xlRange.Cells[i, 1].value.ToString().Trim();
                    }
                    catch { }
                    if (item == "STT")
                    {
                        startindex = i + 1;
                        break;
                    }
                }
                for (int i = startindex; i <= rowCount; i++)
                {
                    dem++;
                    InfoContestant temp = new InfoContestant();
                    temp.STT = (int)xlRange.Cells[i, 1].value;
                    temp.ContestantCode = (string)xlRange.Cells[i, 2].value.ToString().Trim();
                    temp.FullName = (string)xlRange.Cells[i, 3].value.ToString().Trim();
                    try
                    {
                        temp.DOB = (DateTime)xlRange.Cells[i, 4].value;
                    }
                    catch
                    {
                        string kz = (string)xlRange.Cells[i, 4].value.ToString();
                        temp.DOB = DateTime.Parse(kz, MyCultureInfo);
                    }

                    //temp.Sex = (string)xlRange.Cells[i, 5].value.ToString().Trim();
                    temp.IdCardNumber = (string)xlRange.Cells[i, 5].value.ToString();
                    //temp.CurrentAddress = (string)xlRange.Cells[i, 7].value.ToString();
                    temp.KhoiThi = (string)xlRange.Cells[i, 6].value.ToString().Trim();
                    //temp.LocationCode = (string)xlRange.Cells[i, 8].value.ToString().Trim();
                    temp.Roomtest = (string)xlRange.Cells[i, 7].value.ToString().Trim();
                    //temp.CurrentAddress = (string)xlRange.Cells[i, 9].value.ToString().Trim();
                    //temp.Sex = 1;
                    try
                    {
                        temp.ExamDate = (DateTime)xlRange.Cells[i, 8].value;
                    }
                    catch
                    {
                        string kz = (string)xlRange.Cells[i, 8].value.ToString();
                        temp.ExamDate = DateTime.Parse(kz, MyCultureInfo);
                    }

                    temp.Shift = (string)xlRange.Cells[i, 9].value.ToString();
                    temp.ExamTime = (string)xlRange.Cells[i, 10].value.ToString();
                    temp.LocationCode = (string)xlRange.Cells[i, 11].value.ToString();
                    //temp.ExamTime = (string)xlRange.Cells[i, 13].value.ToString();
                    //if (xlRange.Cells[i, 7].value.ToString() == "Chiều") temp.Kip = 1; else temp.Kip = 0;

                    //CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                    //string kz = (string)xlRange.Cells[i, 8].value.ToString();
                    //temp.ShiftDate = DateTime.Parse(kz, MyCultureInfo);

                    lstresult.Add(temp);
                    lbPercent.Text = (dem * 100 / rowCount).ToString() + "%";
                }

                //xlWorksheet.Columns.AutoFit();
                // xlWorkBook.Save();

                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lay du lieu: " + ex.Message + "\n\nDong: " + (dem - 1).ToString());
            }
            finally
            {
            }
            return lstresult;
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
        }
    }
}