using ContestManagementVer2.ImportLichThi;
using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MetroFramework.Forms;

namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmImport : MetroForm
    {
        private List<InfoContestant> lstContestant = new List<InfoContestant>();
        private List<KhoiThi> lstKhoithi = new List<KhoiThi>();
        private List<DiaDiem> lstLocation = new List<DiaDiem>();
        private List<GROUP> lstGroup = new List<GROUP>();
        private int _contestid = 0;
        private BackgroundWorker bw;
        private frmLoading frm = new frmLoading();

        public frmImport(int contestid)
        {
            InitializeComponent();
            _contestid = contestid;
            dgvContestant.AutoGenerateColumns = false;
            //frm.Show();
        }
        
        // code lấy ds từ file excel của a Hoàng K50
        // code này đã được sao chép và sử dụng trong frmImportExcel.cs
        private void btnGetFile_Click(object sender, EventArgs e)
        {
            lstContestant = new List<InfoContestant>();
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Lấy dữ liệu từ file Excel";
            //For any other formats
            of.Filter = "Excel File | *.xls; *.xlsx";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && of.FileName != null)
                {
                    textBox1.Text = of.FileName;

                    frm.Show();

                    lstContestant = frm.GetContestant(of.FileName);
                    frm.Hide();
                    //lstContestant = ReadDataFromExcelFile(of.FileName);
                    if (lstContestant != null && lstContestant.Count != 0)
                    {
                        dgvContestant.DataSource = lstContestant;
                        btnImport.Enabled = true;
                    }
                }
                //ptbImage.Image = Image.FromFile(of.FileName);
            }
            of.Dispose();
        }

        private List<InfoContestant> ReadDataFromExcelFile(string FileName)
        {
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
                for (int i = 0; i < rowCount; i++)
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

                    //temp.Sex = (string)xlRange.Cells[i, 5].value.ToString();
                    temp.IdCardNumber = (string)xlRange.Cells[i, 5].value.ToString();
                    //temp.CurrentAddress = (string)xlRange.Cells[i, 7].value.ToString();
                    temp.KhoiThi = (string)xlRange.Cells[i, 6].value.ToString().Trim();
                    //temp.LocationCode = (string)xlRange.Cells[i, 8].value.ToString().Trim();
                    temp.Roomtest = (string)xlRange.Cells[i, 7].value.ToString().Trim();
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
                    //temp.ExamTime = (string)xlRange.Cells[i, 13].value.ToString();
                    //if (xlRange.Cells[i, 7].value.ToString() == "Chiều") temp.Kip = 1; else temp.Kip = 0;

                    //CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                    //string kz = (string)xlRange.Cells[i, 8].value.ToString();
                    //temp.ShiftDate = DateTime.Parse(kz, MyCultureInfo);

                    lstresult.Add(temp);
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

        private List<DiaDiem> ReadDataLocationFromExcelFile(string FileName)
        {
            List<DiaDiem> lstresult = new List<DiaDiem>();
            int dem = 0;
            try
            {
                var xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 2; i <= rowCount; i++)
                {
                    dem = i;
                    DiaDiem temp = new DiaDiem();
                    temp.MaDiaDiem = xlRange.Cells[i, 2].value.ToString().Trim();
                    temp.TenDiaDiem = xlRange.Cells[i, 3].value.ToString().Trim();
                    lstresult.Add(temp);
                }

                //xlWorksheet.Columns.AutoFit();
                //xlWorkBook.Save();
                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu trong file địa điểm phòng thi: " + ex.Message + "\n\nDòng: " + (dem - 1).ToString());
            }
            finally
            {
            }
            return lstresult;
        }

        // code nhập ds thí sinh đã lấy trong file excel vào csdl của a Hoàng K50
        private void btnImport_Click(object sender, EventArgs e)
        {
            EOSDbContext db = new EOSDbContext();
            lstGroup = db.GROUPS.Where(x => x.ContestID == _contestid).ToList();
            if (lstContestant.Count != 0)
            {
                if (lstGroup.Count != 0)
                {
                    pgbLoading.Visible = lb1.Visible = true;
                    btnGetFile.Enabled = false;
                    btnImport.Enabled = false;
                    bw = new BackgroundWorker();
                    bw.WorkerReportsProgress = true; // ho tro bao cao tien do
                    bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh
                                                          // su kien
                    bw.DoWork += bw_DoWork;
                    bw.ProgressChanged += bw_ProgressChanged;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync();
                }
                else MessageBox.Show("Chưa có khối thi!");
            }
            else MessageBox.Show("Chưa có danh sách thí sinh!");
        }

        private void LoadData()
        {
            EOSDbContext db = new EOSDbContext();
            if (lstContestant != null && lstContestant.Count != 0)
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                    //string kz = (string)xlRange.Cells[i, 8].value.ToString();
                    //temp.ShiftDate = DateTime.Parse(kz, MyCultureInfo);
                    RegisterService regservice = new RegisterService();
                    SubjectService subservice = new SubjectService();
                    ContestantService contestantservice = new ContestantService();
                    REGISTER reg;
                    SUBJECT subject;
                    CONTESTANT contestant;
                    CONTESTANTS_SUBJECTS consub;
                    int dem = 0;
                    bw.ReportProgress(0);
                    foreach (InfoContestant item in lstContestant)
                    {
                        reg = new REGISTER();
                        reg.FullName = item.FullName;
                        reg.DOB = DateTimeHelpers.ConvertDateTimeToUnix(item.DOB);
                        reg.Sex = GetSex(item.Sex);
                        reg.IdentityCardNumber = item.IdCardNumber;
                        reg.CurrentAddress = item.CurrentAddress;
                        reg.RegisteredDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                        reg.Status = 1;
                        reg.ContestID = _contestid;
                        regservice.Add(reg);
                        try
                        {
                            regservice.Save();
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show("Lưu thông tin thí sinh " + reg.FullName + " thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //tran.Rollback();
                            return;
                        }
                        contestant = new CONTESTANT();
                        contestant.RegisterID = reg.RegisterID;
                        contestant.Status = 4001;
                        contestant.ContestantCode = item.ContestantCode;
                        contestantservice.Add(contestant);
                        try
                        {
                            contestantservice.Save();
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show("Lưu thông tin thí sinh " + reg.FullName + " thất bại.\nToàn bộ thông tin đã nhập sẽ bị xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //tran.Rollback();
                            return;
                        }

                        foreach (var it in lstGroup)
                        {
                            if (item.KhoiThi == it.GroupName)
                            {
                                try
                                {
                                    foreach (var sub in it.GROUP_SUBJECTS)
                                    {
                                        consub = new CONTESTANTS_SUBJECTS();
                                        consub.ContestantID = contestant.ContestantID;
                                        consub.Status = 1;
                                        consub.SubjectID = sub.SubjectID;
                                        db.CONTESTANTS_SUBJECTS.Add(consub);
                                        db.SaveChanges();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Thêm môn thi cho thí sinh " + reg.FullName + " không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }
                            }
                        }
                        dem++;
                        bw.ReportProgress(dem * 100 / lstContestant.Count);
                        
                    }
                    try
                    {
                        if(dem==lstContestant.Count)
                        {
                            ts.Complete();
                            MessageBox.Show("Nhập thành công " + dem.ToString() + "/" + lstContestant.Count.ToString() + " thí sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm = new frmLoading();
                            frm.Show();
                            //Thread.Sleep(1000);
                            frm.ImportContestant(_contestid, lstContestant);
                            frm.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nhập thành công " + dem.ToString() + "/" + lstContestant.Count.ToString() + " thí sinh!\nVui lòng kiểm tra lại danh sách và tiến hành nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    catch (Exception ex)
                    {
                        //tran.Rollback();
                        MessageBox.Show("Nhập không thành công!\n Toàn bộ dữ liệu đã nhập sẽ bị xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }        

        private int GetSex(string sex)
        {
            if (sex == "Nữ" || sex == "nữ")
                return 0;
            else return 1;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnGetFile.Enabled = true;
            btnImport.Enabled = false;
            btnXepLich.Enabled = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbLoading.Value = e.ProgressPercentage;
            lb1.Text = pgbLoading.Value.ToString() + "%";
            Application.DoEvents();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();

            //ImportLichThiHelper.ImportLichThi(_contestid, lstContestant, lstKhoithi);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnXepLich_Click_1(object sender, EventArgs e)
        {
            frm = new frmLoading();
            frm.Show();
            //Thread.Sleep(1000);
            frm.ImportContestant(_contestid, lstContestant);
            frm.Hide();
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            frm.Show();
            frm.Hide();
        }
    }

    public class KhoiThidgv
    {
        public string Ten { get; set; }
        public string Monthi1 { get; set; }
        public string Monthi2 { get; set; }
        public string Monthi3 { get; set; }
    }    
}