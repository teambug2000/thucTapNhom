using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace EXON.RegisterManager.Module.Forms
{
    // Code import và xếp lịch theo khối thi (từ file Excel mẫu)
    public partial class frmImportExcel : MetroFramework.Forms.MetroForm
    {
        private List<InfoContestant> lstContestant = new List<InfoContestant>();
        string filename = "";
        int _contestid;        
        List<CaThi> lstCaThiExcel = new List<CaThi>();
        bool step1done = true;
        bool step2done = true;
        bool step3done = true;

        public frmImportExcel(int contestID)
        {
            InitializeComponent();
            _contestid = contestID;

            bw_step1.WorkerReportsProgress = true;
            bw_step1.WorkerSupportsCancellation = true;
            bw_step2.WorkerReportsProgress = true;
            bw_step2.WorkerSupportsCancellation = true;
            bw_step3.WorkerReportsProgress = true;
            bw_step3.WorkerSupportsCancellation = true;
        }

        #region Hàm trợ năng
        private void set_lblstatus1(string text, Color color)
        {
            lbl_step1.Invoke((Action)(() => {
                lbl_step1.Text = text;
                lbl_step1.ForeColor = color;
            }));
        }

        private void set_lblstatus2(string text, Color color)
        {
            lbl_step2.Invoke((Action)(() => {
                lbl_step2.Text = text;
                lbl_step2.ForeColor = color;
            }));
        }

        private void set_lblstatus3(string text, Color color)
        {
            lbl_step3.Invoke((Action)(() => {
                lbl_step3.Text = text;
                lbl_step3.ForeColor = color;
            }));
        }

        private int GetSex(string sex)
        {
            if (sex == "Nữ" || sex == "nữ")
                return 0;
            else return 1;
        }
        #endregion Hàm trợ năng

        #region Sự kiện
        private void bw_step1_DoWork(object sender, DoWorkEventArgs e)
        {
            lstContestant = GetContestant(filename);
        }

        private void bw_step1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb_step1.Value = e.ProgressPercentage;
            lbl_percent1.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bw_step1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (step1done == true)
            {
                set_lblstatus1("Hoàn thành.", Color.Green);
                bw_step2.RunWorkerAsync();
            }
        }

        private void bw_step2_DoWork(object sender, DoWorkEventArgs e)
        {
            KiemTraTinhHopLe();
        }

        private void bw_step2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb_step2.Value = e.ProgressPercentage;
            lbl_percent2.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bw_step2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (step2done == true)
            {
                set_lblstatus2("Hoàn thành.", Color.Green);
                bw_step3.RunWorkerAsync();
            }            
        }

        private void bw_step3_DoWork(object sender, DoWorkEventArgs e)
        {
            Import2DB();
        }

        private void bw_step3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb_step3.Value = e.ProgressPercentage;
            lbl_percent3.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bw_step3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (step3done == true)
            {
                set_lblstatus3("Hoàn thành.", Color.Green);
                btn_HuyBo.Enabled = true;
            }
            btn_ChooseFile.Enabled = true;
        }

        private void btn_ChooseFile_Click(object sender, EventArgs e)
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
                    filename = of.FileName;
                    bw_step1.RunWorkerAsync();
                    btn_HuyBo.Enabled = true;
                    btn_ChooseFile.Enabled = false;
                    //lstContestant = GetContestant(of.FileName);
                    //if (lstContestant != null && lstContestant.Count != 0)
                    //{

                    //}
                }
            }
            of.Dispose();
        }

        private void btn_HuyBo_Click(object sender, EventArgs e)
        {
            if (bw_step1.IsBusy == true)
            {
                step1done = false;
                bw_step1.Abort();
                set_lblstatus1("Đã dừng.", Color.Red);
            }                
            if (bw_step2.IsBusy == true)
            {
                step2done = false;
                bw_step2.Abort();
                set_lblstatus2("Đã dừng.", Color.Red);
            }                
            if (bw_step3.IsBusy == true)
            {
                step3done = false;
                bw_step3.Abort();
                set_lblstatus3("Đã dừng.", Color.Red);
            }
            btn_ChooseFile.Enabled = true;
            btn_HuyBo.Enabled = false;
        }

        private void frmImportExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bw_step1.IsBusy == true || bw_step2.IsBusy == true || bw_step3.IsBusy == true)
            {
                DialogResult confirm = MessageBox.Show("Thoát và hủy quá trình nhập, xếp lịch theo khối thi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    if (bw_step1.IsBusy == true)
                    {
                        step1done = false;
                        bw_step1.Abort();
                    }
                    if (bw_step2.IsBusy == true)
                    {
                        step2done = false;
                        bw_step2.Abort();
                    }
                    if (bw_step3.IsBusy == true)
                    {
                        step3done = false;
                        bw_step3.Abort();
                    }
                }
                else if (e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = true;
            }            
        }
        #endregion Sự kiện

        #region Step1
        public List<InfoContestant> GetContestant(string FileName)
        {
            step1done = true;
            set_lblstatus1("Đang lấy dữ liệu...", Color.Blue);
            List<InfoContestant> lstresult = new List<InfoContestant>();
            bw_step1.ReportProgress(0);
            int dem = 0;
            string error_message = "";

            try
            {
                error_message = "Lỗi kết nối CSDL, vui lòng kiểm tra lại kết nối.";
                EOSDbContext db = new EOSDbContext();
                CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                error_message = "Lỗi mở file Excel, vui lòng kiểm tra lại tính hợp lệ của file.";
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
                    dem = i;
                    InfoContestant temp = new InfoContestant();
                    error_message = "STT ở dòng " + i.ToString() + " không phải là số nguyên";
                    temp.STT = (int)xlRange.Cells[i, 1].value;
                    error_message = "Số báo danh ở dòng " + i.ToString() + " bị thiếu";
                    temp.ContestantCode = (string)xlRange.Cells[i, 2].value.ToString().Trim();
                    error_message = "Tên Thí sinh ở dòng " + i.ToString() + " bị thiếu";
                    temp.FullName = (string)xlRange.Cells[i, 3].value.ToString().Trim();
                    try
                    {
                        error_message = "Ngày sinh ở dòng " + i.ToString() + " bị thiếu hoặc sai định dạng ngày";
                        temp.DOB = (DateTime)xlRange.Cells[i, 4].value;
                    }
                    catch
                    {
                        error_message = "Ngày sinh ở dòng " + i.ToString() + " bị thiếu hoặc sai định dạng ngày";
                        string kz = (string)xlRange.Cells[i, 4].value.ToString();
                        temp.DOB = DateTime.Parse(kz, MyCultureInfo);
                    }
                    error_message = "Số CMND ở dòng " + i.ToString() + " bị thiếu";
                    //temp.Sex = (string)xlRange.Cells[i, 5].value.ToString().Trim();
                    temp.IdCardNumber = (string)xlRange.Cells[i, 5].value.ToString();
                    //temp.CurrentAddress = (string)xlRange.Cells[i, 7].value.ToString();
                    error_message = "Khối thi ở dòng " + i.ToString() + " bị thiếu";
                    temp.KhoiThi = (string)xlRange.Cells[i, 6].value.ToString().Trim();
                    //temp.LocationCode = (string)xlRange.Cells[i, 8].value.ToString().Trim();
                    error_message = "Phòng thi ở dòng " + i.ToString() + " bị thiếu";
                    temp.Roomtest = (string)xlRange.Cells[i, 7].value.ToString().Trim();
                    //temp.CurrentAddress = (string)xlRange.Cells[i, 9].value.ToString().Trim();
                    //temp.Sex = 1;
                    try
                    {
                        error_message = "Ngày sinh ở dòng " + i.ToString() + " bị thiếu hoặc sai định dạng ngày";
                        temp.ExamDate = (DateTime)xlRange.Cells[i, 8].value;
                    }
                    catch
                    {
                        error_message = "Ngày sinh ở dòng " + i.ToString() + " bị thiếu hoặc sai định dạng ngày";
                        string kz = (string)xlRange.Cells[i, 8].value.ToString();
                        temp.ExamDate = DateTime.Parse(kz, MyCultureInfo);
                    }
                    error_message = "Ca thi ở dòng " + i.ToString() + " bị thiếu";
                    temp.Shift = (string)xlRange.Cells[i, 9].value.ToString();
                    error_message = "Giờ bắt đầu thi ở dòng " + i.ToString() + " bị thiếu";
                    temp.ExamTime = (string)xlRange.Cells[i, 10].value.ToString();
                    error_message = "Địa điểm thi ở dòng " + i.ToString() + " bị thiếu";
                    temp.LocationCode = (string)xlRange.Cells[i, 11].value.ToString();

                    if (temp.ContestantCode == "" || temp.FullName == "" || temp.IdCardNumber == "" || temp.KhoiThi == "" || temp.Roomtest == ""
                        || temp.Shift == "" || temp.ExamTime == "" || temp.LocationCode == "")
                        throw new Exception(error_message);
                    //temp.ExamTime = (string)xlRange.Cells[i, 13].value.ToString();
                    //if (xlRange.Cells[i, 7].value.ToString() == "Chiều") temp.Kip = 1; else temp.Kip = 0;

                    //CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                    //string kz = (string)xlRange.Cells[i, 8].value.ToString();
                    //temp.ShiftDate = DateTime.Parse(kz, MyCultureInfo);

                    lstresult.Add(temp);
                    bw_step1.ReportProgress((int)Math.Ceiling((double)(i - startindex) / (rowCount - startindex) * 100));
                }

                //xlWorksheet.Columns.AutoFit();
                // xlWorkBook.Save();

                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                if (ex.Message != "Thread was being aborted.")
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình lấy dữ liệu.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    set_lblstatus1("Lỗi.", Color.Red);
                    step1done = false;
                }                                    
            }
            finally
            {
            }
            if (lstresult == null || lstresult.Count() == 0)
            {
                MessageBox.Show("Không có thí sinh nào trong danh sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                set_lblstatus1("Lỗi.", Color.Red);
                step1done = false;
            }                
            return lstresult;
        }
        #endregion Step1        

        #region Step2
        public void KiemTraTinhHopLe()
        {
            step2done = true;
            try
            {
                // Lấy ds tất cả lịch thi (đôi một khác nhau)
                EOSDbContext db = new EOSDbContext();
                List<LichThi> lstLichThi = new List<LichThi>();
                foreach (InfoContestant item in lstContestant)
                {
                    LichThi lt = new LichThi();
                    lt.ExamDate = item.ExamDate;
                    lt.LocationCode = item.LocationCode;
                    lt.Roomtest = item.Roomtest;
                    lt.KhoiThi = item.KhoiThi;
                    List<string> giothi = item.ExamTime.Split('h').ToList();
                    lt.StartHour = Convert.ToInt32(giothi[0]);
                    lt.StartMinus = Convert.ToInt32(giothi[1]);
                    if (lstLichThi.Where(p => p == lt).Count() == 0)
                        lstLichThi.Add(lt);
                }

                // Kiểm tra ngày thi của lịch thi có nằm trong ngày tổ chức thi không
                foreach(LichThi item in lstLichThi)
                {
                    CONTEST contest = db.CONTESTS.Where(p => p.ContestID == _contestid).FirstOrDefault();
                    DateTime contest_begindate = Convert.ToDateTime(DateTimeHelpers.ConvertUnixToDateTime((int)contest.BeginDate).ToString("dd/MM/yyyy"));
                    DateTime contest_enddate = Convert.ToDateTime(DateTimeHelpers.ConvertUnixToDateTime((int)contest.EndDate).ToString("dd/MM/yyyy"));
                    if (item.ExamDate > contest_enddate || item.ExamDate < contest_begindate)
                    {
                        MessageBox.Show("Ngày thi: " + item.ExamDate.ToString("dd/MM/yyyy") + " không nằm trong thời gian tổ chức thi: " +
                            DateTimeHelpers.ConvertUnixToDateTime((int)contest.BeginDate).ToString("dd/MM/yyyy") + "-" + DateTimeHelpers.ConvertUnixToDateTime((int)contest.EndDate).ToString("dd/MM/yyyy")
                            , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        set_lblstatus2("Lỗi.", Color.Red);
                        step2done = false;
                        return;
                    }
                }

                //// Lấy ds tất cả các ca thi trong ds lịch thi (đã có thông tin môn thi, thời gian bắt đầu và kết thúc ca thi)
                //lstCaThiExcel = new List<CaThi>();
                //foreach (LichThi item in lstLichThi)
                //{
                //    GROUP group = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == item.KhoiThi).FirstOrDefault();
                //    int temp_starttime = item.StartHour * 3600 + item.StartMinus * 60;
                //    foreach (var grp_sub in group.GROUP_SUBJECTS.OrderBy(p => p.Ordinal))
                //    {
                //        CaThi ct = new CaThi();
                //        int scheduleID = db.SCHEDULES.Where(p => p.ContestID == _contestid && p.SubjectID == grp_sub.SubjectID).Select(p => p.ScheduleID).FirstOrDefault();
                //        int time_of_test = db.SCHEDULES.Where(p => p.ContestID == _contestid && p.SubjectID == grp_sub.SubjectID).Select(p => p.TimeOfTest).FirstOrDefault();
                //        ct.ExamDate = item.ExamDate;
                //        ct.LocationCode = item.LocationCode;
                //        ct.Roomtest = item.Roomtest;
                //        ct.KhoiThi = item.KhoiThi;
                //        ct.StartHour = item.StartHour;
                //        ct.StartMinus = item.StartMinus;
                //        ct.StartTime = temp_starttime;
                //        ct.EndTime = ct.StartTime + time_of_test;
                //        ct.MonThi_ID = (int)grp_sub.SubjectID;
                //        ct.Schedule_ID = scheduleID;
                //        lstCaThiExcel.Add(ct);
                //        temp_starttime = ct.EndTime + 5 * 60; // +5*60 do có 5 phút nghỉ giữa 2 ca thi
                //    }
                //}

                // Lấy ds tất cả ca thi trong ds lịch thi (đã có thông tin môn thi, thời gian bắt đầu và kết thúc ca thi)
                // 1 ca thi có thể có nhiều Khối thi khác nhau
                // Thuật toán: Xét tất cả ca thi có ngày thi, thời gian bắt đầu, địa điểm thi, phòng thi giống nhau
                //             Tìm ra 
                foreach (LichThi item in lstLichThi)
                {
                    List<LichThi> same_as_item = lstLichThi.Where(p => p.ExamDate == item.ExamDate && p.LocationCode == item.LocationCode 
                                                            && p.Roomtest == item.Roomtest && p.StartHour == item.StartHour).ToList();
                    int[] maxTimeOfTest = new int[10];
                    List<string> allGroupName = same_as_item.Select(p => p.KhoiThi).ToList();
                    List<GROUP> allGroup = db.GROUPS.Where(p => p.ContestID == _contestid && allGroupName.Contains(p.GroupName)).ToList();
                    foreach (GROUP gp in allGroup)
                    {
                        foreach (var grp_sub in gp.GROUP_SUBJECTS.OrderBy(p => p.Ordinal))
                        {
                            int time_of_test = db.SCHEDULES.Where(p => p.ContestID == _contestid && p.SubjectID == grp_sub.SubjectID).Select(p => p.TimeOfTest).FirstOrDefault();
                            if (maxTimeOfTest[(int)grp_sub.Ordinal] <= time_of_test)
                                maxTimeOfTest[(int)grp_sub.Ordinal] = time_of_test;
                        }
                    }
                    GROUP group = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == item.KhoiThi).FirstOrDefault();
                    int temp_starttime = item.StartHour * 3600 + item.StartMinus * 60;
                    foreach (var grp_sub in group.GROUP_SUBJECTS.OrderBy(p => p.Ordinal))
                    {
                        CaThi ct = new CaThi();
                        int scheduleID = db.SCHEDULES.Where(p => p.ContestID == _contestid && p.SubjectID == grp_sub.SubjectID).Select(p => p.ScheduleID).FirstOrDefault();
                        int time_of_test = maxTimeOfTest[(int)grp_sub.Ordinal];
                        ct.ExamDate = item.ExamDate;
                        ct.LocationCode = item.LocationCode;
                        ct.Roomtest = item.Roomtest;
                        ct.KhoiThi = item.KhoiThi;
                        ct.StartHour = item.StartHour;
                        ct.StartMinus = item.StartMinus;
                        ct.StartTime = temp_starttime;
                        ct.EndTime = ct.StartTime + time_of_test;
                        ct.MonThi_ID = (int)grp_sub.SubjectID;
                        ct.Schedule_ID = scheduleID;
                        ct.KhoiThi = item.KhoiThi;
                        lstCaThiExcel.Add(ct);
                        temp_starttime = ct.EndTime + 5 * 60; // +5*60 do có 5 phút nghỉ giữa 2 ca thi
                    }              
                }

                // Lấy tất cả các ca thi đã có trong hệ thống của kỳ thi hiện tại
                List<CaThi> lstAllCaThi = new List<CaThi>();
                List<CaThi> existed_Cathi = new List<CaThi>();
                var temp_existed_CaThi = (from shf in db.SHIFTS
                                          join div_shf in db.DIVISION_SHIFTS on shf.ShiftID equals div_shf.ShiftID
                                          join room in db.ROOMTESTS on div_shf.RoomTestID equals room.RoomTestID
                                          join location in db.LOCATIONS on room.LocationID equals location.LocationID
                                          where shf.ContestID == _contestid
                                          select new
                                          {
                                              ShiftDate = shf.ShiftDate,
                                              LocationName = location.LocationName,
                                              RoomTestName = room.RoomTestName,
                                              StartTime = shf.StartTime,
                                              EndTime = shf.EndTime,
                                              DivisionShiftID = div_shf.DivisionShiftID
                                          }).ToList();
                foreach (var item in temp_existed_CaThi)
                {
                    CaThi temp_ct = new CaThi(DateTimeHelpers.ConvertUnixToDateTime(item.ShiftDate), 1, 1,
                                 item.LocationName, item.RoomTestName, "", 1, item.StartTime, item.EndTime,
                                 item.DivisionShiftID, 1);
                    existed_Cathi.Add(temp_ct);
                }
                // Trộn tất cả ca thi trong hệ thống và ca thi trong file excel thành 1 list mới
                lstAllCaThi.AddRange(existed_Cathi);
                lstAllCaThi.AddRange(lstCaThiExcel);

                bw_step2.ReportProgress(0);
                // Kiểm tra tính hợp lệ của các ca thi trong list mới tạo       
                bool isValid_DivisionShift = true;
                for (int i = 0; i < lstAllCaThi.Count(); i++)
                {
                    for (int j = i + 1; j < lstAllCaThi.Count(); j++)
                    {
                        isValid_DivisionShift = lstAllCaThi[i].isConflict(lstAllCaThi[j]);
                        if (isValid_DivisionShift == false)
                        {
                            MessageBox.Show("Ca thi xung đột thời gian: \n" +
                                lstAllCaThi[i].LocationCode + ", " + lstAllCaThi[i].Roomtest + ", " + lstAllCaThi[i].ExamDate.ToString("dd/MM/yyyy") + ", " + lstAllCaThi[i].KhoiThi + ", "
                                + DateTimeHelpers.ConvertUnixToDateTime(lstAllCaThi[i].StartTime) + "-" + DateTimeHelpers.ConvertUnixToDateTime(lstAllCaThi[i].EndTime)
                                + "\n" +
                                lstAllCaThi[j].LocationCode + ", " + lstAllCaThi[j].Roomtest + ", " + lstAllCaThi[j].ExamDate.ToString("dd/MM/yyyy") + ", " + lstAllCaThi[j].KhoiThi + ", "
                                + DateTimeHelpers.ConvertUnixToDateTime(lstAllCaThi[j].StartTime) + "-" + DateTimeHelpers.ConvertUnixToDateTime(lstAllCaThi[j].EndTime),
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    if (isValid_DivisionShift == false)
                        break;
                    bw_step2.ReportProgress((int)Math.Ceiling((double)(i + 1) / lstAllCaThi.Count() * 100));
                }
                if (isValid_DivisionShift == false)
                    step2done = false;
            }
            catch (Exception ex)
            {
                if (ex.Message != "Thread was being aborted.")
                {
                    MessageBox.Show(ex.ToString());
                    set_lblstatus2("Lỗi.", Color.Red);
                    step2done = false;
                }
            }
        }
        #endregion Step2

        #region Step3
        public void Import2DB()
        {
            step3done = true;
            set_lblstatus3("Đang nhập dữ liệu vào CSDL...", Color.Blue);
            bw_step3.ReportProgress(0);
            // Nếu như các ca thi hợp lệ thì tiến hành import ca thi và thí sinh
            EOSDbContext db = new EOSDbContext();
            using (System.Data.Entity.DbContextTransaction tran = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (CaThi ct in lstCaThiExcel)
                    {
                        SHIFT new_shf = new SHIFT();
                        new_shf.ShiftName = "Ca thi " + ct.ExamDate.ToString("dd/MM/yyyy ") + (ct.StartTime / 3600) + "h" + (ct.StartTime % 3600 / 60).ToString("00") + " - " + (ct.EndTime / 3600) + "h" + (ct.EndTime % 3600 / 60).ToString("00")
                            + ", " + ct.LocationCode + "." + ct.Roomtest;
                        new_shf.ShiftDate = DateTimeHelpers.ConvertDateTimeToUnix(ct.ExamDate);
                        new_shf.StartTime = ct.StartTime;
                        new_shf.EndTime = ct.EndTime;
                        new_shf.Status = 1;
                        new_shf.ContestID = _contestid;
                        // chỗ này nên có ktra trùng trước khi thêm
                        var existed_shift = db.SHIFTS.Where(p => p.ShiftName == new_shf.ShiftName && p.ContestID == _contestid && p.ShiftDate == new_shf.ShiftDate && p.StartTime == new_shf.StartTime && p.EndTime == new_shf.EndTime);
                        if (existed_shift.Count() == 0)
                        {
                            db.SHIFTS.Add(new_shf);
                            db.SaveChanges();
                        }
                        else
                            new_shf.ShiftID = existed_shift.FirstOrDefault().ShiftID;

                        DIVISION_SHIFTS new_divshf = new DIVISION_SHIFTS();
                        new_divshf.ShiftID = new_shf.ShiftID;
                        int roomID = db.ROOMTESTS.Where(p => p.RoomTestName == ct.Roomtest && p.LOCATION.ContestID == _contestid && p.LOCATION.LocationName == ct.LocationCode).Select(p => p.RoomTestID).FirstOrDefault();
                        new_divshf.RoomTestID = roomID;
                        //new_divshf.SupervisorID = ;
                        new_divshf.Status = 1;
                        // chỗ này nên có ktra trùng trước khi thêm
                        if (db.DIVISION_SHIFTS.Where(p => p.ShiftID == new_divshf.ShiftID && p.RoomTestID == new_divshf.RoomTestID).Count() == 0)
                        {
                            db.DIVISION_SHIFTS.Add(new_divshf);
                            db.SaveChanges();
                            ct.Division_shift_ID = new_divshf.DivisionShiftID;
                        }
                        else
                            ct.Division_shift_ID = db.DIVISION_SHIFTS.Where(p => p.ShiftID == new_divshf.ShiftID && p.RoomTestID == new_divshf.RoomTestID)
                                .Select(p => p.DivisionShiftID).FirstOrDefault();
                    }

                    int dem = 0;
                    foreach (InfoContestant item in lstContestant)
                    {
                        // Thêm vào bảng REGISTER
                        REGISTER reg = new REGISTER();
                        reg.FullName = item.FullName;
                        reg.DOB = DateTimeHelpers.ConvertDateTimeToUnix(item.DOB);
                        reg.Sex = GetSex(item.Sex);
                        reg.IdentityCardNumber = item.IdCardNumber;
                        reg.CurrentAddress = item.CurrentAddress;
                        reg.RegisteredDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                        reg.Status = 1;
                        reg.ContestID = _contestid;
                        if (db.REGISTERS.Where(p => p.FullName == reg.FullName && p.DOB == reg.DOB && p.ContestID == reg.ContestID
                            && p.IdentityCardNumber == reg.IdentityCardNumber && p.Sex == reg.Sex).Count() == 0)
                        {
                            db.REGISTERS.Add(reg);
                            db.SaveChanges();
                        }
                        else
                            reg.RegisterID = db.REGISTERS.Where(p => p.FullName == reg.FullName && p.DOB == reg.DOB && p.ContestID == reg.ContestID
                            && p.IdentityCardNumber == reg.IdentityCardNumber && p.Sex == reg.Sex).Select(p => p.RegisterID).FirstOrDefault();
                        // Thêm vào bảng CONTESTANT
                        CONTESTANT contestant = new CONTESTANT();
                        contestant.RegisterID = reg.RegisterID;
                        contestant.Status = 4001;
                        contestant.ContestantCode = item.ContestantCode;
                        if (db.CONTESTANTS.Where(p => p.RegisterID == contestant.RegisterID && p.ContestantCode == contestant.ContestantCode).Count() == 0)
                        {
                            db.CONTESTANTS.Add(contestant);
                            db.SaveChanges();
                        }
                        else
                            contestant.ContestantID = db.CONTESTANTS.Where(p => p.RegisterID == contestant.RegisterID && p.ContestantCode == contestant.ContestantCode)
                                .Select(p => p.ContestantID).FirstOrDefault();
                        // Thêm vào bảng CONTESTANT_SUBJECT
                        GROUP group = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == item.KhoiThi).FirstOrDefault();
                        foreach (var grp_sub in group.GROUP_SUBJECTS.OrderBy(p => p.Ordinal))
                        {
                            CONTESTANTS_SUBJECTS con_sub = new CONTESTANTS_SUBJECTS();
                            con_sub.ContestantID = contestant.ContestantID;
                            con_sub.Status = 1;
                            con_sub.SubjectID = grp_sub.SubjectID;
                            if (db.CONTESTANTS_SUBJECTS.Where(p => p.ContestantID == con_sub.ContestantID && p.SubjectID == con_sub.SubjectID).Count() == 0)
                            {
                                db.CONTESTANTS_SUBJECTS.Add(con_sub);
                                db.SaveChanges();
                            }
                        }
                        // Thêm vào bảng CONTESTANT_SHIFT
                        foreach (var grp_sub in group.GROUP_SUBJECTS.OrderBy(p => p.Ordinal))
                        {
                            List<string> giothi = item.ExamTime.Split('h').ToList();
                            int startHour = Convert.ToInt32(giothi[0]);
                            int startMinus = Convert.ToInt32(giothi[1]);
                            CaThi ct = lstCaThiExcel.Where(p => p.LocationCode == item.LocationCode && p.Roomtest == item.Roomtest && p.KhoiThi == item.KhoiThi
                                                            && p.ExamDate == item.ExamDate && p.MonThi_ID == grp_sub.SubjectID && p.StartHour == startHour && p.StartMinus == startMinus).FirstOrDefault();

                            // Kiểm tra xem thí sinh có đang tham gia ca thi nào khác hay không
                            // Nếu có thì sẽ dừng quá trình nhập và không lưu bất kỳ thông tin gì
                            int ngaythi = DateTimeHelpers.ConvertDateTimeToUnix(ct.ExamDate);
                            List<int> existed_shift = db.SHIFTS.Where(p => p.ContestID == _contestid && p.ShiftDate == ngaythi
                                    && (((p.StartTime >= ct.StartTime && p.StartTime <= ct.EndTime) || (p.EndTime >= ct.StartTime && p.EndTime <= ct.EndTime))
                                    || ((ct.StartTime >= p.StartTime && ct.StartTime <= p.EndTime) || (ct.EndTime >= p.StartTime && ct.EndTime <= p.EndTime)))).Select(p => p.ShiftID).ToList();
                            List<int> existed_divshift = db.DIVISION_SHIFTS.Where(p => existed_shift.Contains(p.ShiftID)).Select(p => p.DivisionShiftID).ToList();
                            List<CONTESTANTS_SHIFTS> conflict_conshf = db.CONTESTANTS_SHIFTS.Where(p => existed_divshift.Contains(p.ShiftID) && p.ContestantID == contestant.ContestantID).ToList();
                            if (conflict_conshf.Count() > 0)
                            {
                                MessageBox.Show("Thí sinh: " + item.FullName + " đã có lịch thi trong khoảng thời gian: " + ct.ExamDate.ToString("dd/MM/yyyy ") + ", "
                                    + (ct.StartTime / 3600) + "h" + (ct.StartTime % 3600 / 60).ToString("00") + " - " + (ct.EndTime / 3600) + "h" + (ct.EndTime % 3600 / 60).ToString("00")
                                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                List<SHIFT> lstshf = db.SHIFTS.Where(p => existed_shift.Contains(p.ShiftID)).ToList();
                                List<DIVISION_SHIFTS> lstdivshf = db.DIVISION_SHIFTS.Where(p => existed_shift.Contains(p.ShiftID)).ToList();
                                step3done = false;
                                set_lblstatus3("Lỗi.", Color.Red);
                                return;
                            }

                            CONTESTANTS_SHIFTS con_shf = new CONTESTANTS_SHIFTS();
                            con_shf.ShiftID = ct.Division_shift_ID;
                            con_shf.ContestantID = contestant.ContestantID;
                            con_shf.ScheduleID = ct.Schedule_ID;
                            con_shf.Status = 1;
                            if (db.CONTESTANTS_SHIFTS.Where(p => p.ShiftID == con_shf.ShiftID && p.ContestantID == con_shf.ContestantID && p.ScheduleID == con_shf.ScheduleID).Count() == 0)
                            {
                                db.CONTESTANTS_SHIFTS.Add(con_shf);
                                db.SaveChanges();
                            }
                        }
                        bw_step3.ReportProgress((int)Math.Ceiling((double)++dem / lstContestant.Count() * 100));
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex.Message != "Thread was being aborted.")
                    {
                        MessageBox.Show(ex.ToString());
                        tran.Rollback();
                        set_lblstatus3("Lỗi.", Color.Red);
                        step3done = false;
                    }
                }
            }
        }
        #endregion Step3        
    }

    #region Class bổ trợ
    public class LichThi
    {
        public DateTime ExamDate { get; set; }
        public int StartHour { get; set; }
        public int StartMinus { get; set; }
        public string LocationCode { get; set; }
        public string Roomtest { get; set; }
        public string KhoiThi { get; set; }

        public override bool Equals(object obj)
        {
            LichThi lt = (LichThi)obj;
            if (this.ExamDate != lt.ExamDate)
                return false;
            if (this.StartHour != lt.StartHour)
                return false;
            if (this.StartMinus != lt.StartMinus)
                return false;
            if (this.LocationCode != lt.LocationCode)
                return false;
            if (this.Roomtest != lt.Roomtest)
                return false;
            if (this.KhoiThi != lt.KhoiThi)
                return false;
            return true;
        }

        public static bool operator ==(LichThi lt1, LichThi lt2)
        {
            return lt1.Equals(lt2);
        }

        public static bool operator !=(LichThi lt1, LichThi lt2)
        {
            return !lt1.Equals(lt2);
        }
    }
    
    public class CaThi
    {
        public CaThi()
        {

        }
        public CaThi(DateTime date, int s_hour, int s_minus, string location, string room,
            string khoithi, int monthiid, int starttime, int endtime, int div_shf_id, int schedule_id)
        {
            this.ExamDate = date;
            this.StartHour = s_hour;
            this.StartMinus = s_minus;
            this.LocationCode = location;
            this.Roomtest = room;
            this.KhoiThi = khoithi;
            this.MonThi_ID = monthiid;
            this.StartTime = starttime;
            this.EndTime = endtime;
            this.Division_shift_ID = div_shf_id;
            this.Schedule_ID = schedule_id;
        }
        public DateTime ExamDate { get; set; }
        public int StartHour { get; set; }
        public int StartMinus { get; set; }
        public string LocationCode { get; set; }
        public string Roomtest { get; set; }
        public string KhoiThi { get; set; }
        public int MonThi_ID { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Division_shift_ID { get; set; }
        public int Schedule_ID { get; set; }

        public bool isConflict(CaThi ct)
        {
            if (this.LocationCode == ct.LocationCode)
                if (this.Roomtest == ct.Roomtest)
                    if (this.ExamDate == ct.ExamDate)
                    {
                        if (this.StartTime < ct.StartTime)
                        {
                            if (this.EndTime < ct.StartTime)
                                return true;
                            else
                                return false;
                        }
                        else if (this.StartTime == ct.StartTime)
                        {
                            if (this.EndTime == ct.EndTime)
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            if (this.StartTime > ct.EndTime)
                                return true;
                            else
                                return false;
                        }
                    }
            return true;
        }
    }

    public class AbortableBackgroundWorker : BackgroundWorker
    {

        private Thread workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true; //We must set Cancel property to true!
                Thread.ResetAbort(); //Prevents ThreadAbortException propagation
            }
        }


        public void Abort()
        {
            if (workerThread != null)
            {
                workerThread.Abort();
                workerThread = null;
            }
        }
    }
    #endregion Class bổ trợ
}
