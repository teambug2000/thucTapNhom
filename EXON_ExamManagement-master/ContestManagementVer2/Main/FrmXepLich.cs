using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.ImportLichThi;
using EXON.Common;
using EXON.Data.Services;
using EXON_EM.Data.Service;
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
    public partial class FrmXepLich : MetroForm
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region Hàm khởi tạo

        public FrmXepLich(CONTEST _kt)
        {
            InitializeComponent();
            kithi = _kt;
            DAO.DBService.Reload();
        }

        #endregion Hàm khởi tạo

        #region Sự kiện

        private void btnDanhSachDangKy_Click(object sender, EventArgs e)
        {
            //kithi = db.CONTESTS.Where(p => p.ContestID == 12).FirstOrDefaultOrDefault();
            ucDanhSachDangKy form = new ucDanhSachDangKy(kithi);
            panelMain.Controls.Clear();
            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            if (kithi.Status != (int)ContestStatus.RegisterDone)
            {
                if (kithi.Status == (int)ContestStatus.Accepted)
                {
                    //if (kithi.EndRegistration < DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now))
                    //{
                    //    kithi.Status = (int)ContestStatus.RegisterDone;
                    //    Contest_Service consv = new Contest_Service();
                    //    EXON_EM.Data.Model.CONTEST con = consv.Find(kithi.ContestID);
                    //    con.Status = (int)ContestStatus.RegisterDone;
                    //    try
                    //    {
                    //        consv.Update(con);
                    //        consv.Save();
                    //    }
                    //    catch { }
                    //}
                    //else
                    //{
                    MessageBox.Show("Kì thi chưa hoàn thành đăng ký",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    //    return;
                    //}
                }

                if (kithi.Status == (int)ContestStatus.Cancel)
                {
                    MessageBox.Show("Kì thi đã bị hủy",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                if (kithi.Status != (int)ContestStatus.RegisterDone)
                {
                    MessageBox.Show("Kì thi đã được xếp lịch",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    ucLichThi form1 = new ucLichThi(kithi);
                    panelMain.Controls.Clear();
                    form1.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(form1);
                }
                return;
            }
            FrmConfigDiaDiem form = new FrmConfigDiaDiem(kithi);
            form.ShowDialog();

            if (kithi.Status == (int)ContestStatus.ScheduleShiftDone)
            {
                ucLichThi form12 = new ucLichThi(kithi);
                panelMain.Controls.Clear();
                form12.Dock = DockStyle.Fill;
                panelMain.Controls.Add(form12);
            }
        }

        private void btnLichThi_Click(object sender, EventArgs e)
        {
            if (kithi.Status <= (int)ContestStatus.RegisterDone)
            {
                MessageBox.Show("Kì thi chưa được xếp lịch",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            ucLichThi form = new ucLichThi(kithi);
            panelMain.Controls.Clear();
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
        }

        private void btnCauHinhXepLich_Click(object sender, EventArgs e)
        {
            if (kithi.Status != (int)ContestStatus.RegisterDone)
            {
                if (kithi.Status == (int)ContestStatus.Accepted)
                {
                    //if (kithi.EndRegistration < DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now))
                    //{
                    //    kithi.Status = (int)ContestStatus.RegisterDone;
                    //    Contest_Service consv = new Contest_Service();
                    //    EXON_EM.Data.Model.CONTEST con = consv.Find(kithi.ContestID);
                    //    con.Status = (int)ContestStatus.RegisterDone;
                    //    try
                    //    {
                    //        consv.Update(con);
                    //        consv.Save();
                    //    }
                    //    catch { }
                    //}
                    //else
                    //{
                    MessageBox.Show("Kì thi chưa hoàn thành đăng ký",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return;
                    //}
                }

                if (kithi.Status == (int)ContestStatus.Cancel)
                {
                    MessageBox.Show("Kì thi đã bị hủy",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }

            FrmConfigDiaDiem form = new FrmConfigDiaDiem(kithi);
            form.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // kiểm tra trạng thái của kì thi
            if (kithi.Status == (int)ContestStatus.Accepted || kithi.ContestID == (int)ContestStatus.New)
            {
                MessageBox.Show("Kì thi chưa hoàn thành đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kithi.Status >= (int)ContestStatus.ScheduleShiftDone)
            {
                MessageBox.Show("Kì thi đã được xếp lịch", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kithi.Status >= (int)ContestStatus.RegisterDone)
            {
                // Đọc danh sách Lịch thi từ file excel

                // Lựa chọn file xls
                OpenFileDialog a = new OpenFileDialog();
                a.Filter = "Excel File | *.xls; *.xlsx";
                a.ShowDialog();

                /// Đọc vào chi tiết lịch thi
                var listLichThi = OfficeHelper.ReadChiTietLichThi(a.FileName);

                ////// Đọc từ file excel thành công
                List<DiaDiem>
                    listDiaDiem = new List<DiaDiem>() {
                        new DiaDiem() {TenDiaDiem="HVKTQS", MaDiaDiem="HVKTQS" },
                        new DiaDiem() {TenDiaDiem="TP Hồ Chí Minh",MaDiaDiem="HCM" }
                    };
                List<KhoiThi> listKhoiThi = new List<KhoiThi>() {
                    new KhoiThi() {Ten = "L1",ListMonThi =new List<string>() {"Tiếng Anh", "Lập trình cơ bản" } },
                    new KhoiThi() {Ten = "L2",ListMonThi = new List<string>() {"Tiếng Anh", "Ngôn ngữ lập trình" }}
                };

                if (listLichThi != null)
                {
                    ImportLichThiHelper.ImportLichThi(kithi.ContestID, listLichThi);
                }
            }
        }

        #endregion Sự kiện

        #region Hàm hỗ trợ

        //private SHIFT getShift(string SubjectName, DateTime Ngay, int Kip, DonViThi dvt)
        //{
        //    /// Lấy ra danh sách ca thi phù hợp
        //    List<SHIFT> temp = db.SHIFTS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID)
        //                            .ToList();
        //    List<SHIFT> listCaThi = new List<SHIFT>();
        //    foreach (var item in temp)
        //    {
        //        DateTime shiftDate = DateTimeHelpers.ConvertUnixToDateTime(item.ShiftDate);

        //        if (shiftDate.Year == Ngay.Year && shiftDate.Month == Ngay.Month && shiftDate.Day == Ngay.Day)
        //        {
        //            // trùng ngày thi - tiếp tục phải kiểm tra kíp
        //            DateTime StartTime = DateTimeHelpers.ConvertUnixToDateTime(item.StartTime);

        //            int kipcathi = 0;
        //            if (StartTime.Hour > 12) kipcathi = 1;
        //            if (kipcathi == Kip) listCaThi.Add(item);
        //        }
        //    }
        //    listCaThi = listCaThi.OrderBy(p => p.StartTime).ToList();

        //    // Tìm ca thi thích hợp để tra về kết quả
        //    List<SCHEDULE> dsMonThi = dvt.dsMonThi.OrderByDescending(p => p.TimeOfTest).ToList();
        //    SUBJECT monthi = getSubject(SubjectName);

        //    int index = -1;
        //    for (int i = 0; i < dsMonThi.Count; i++)
        //    {
        //        SCHEDULE sche = dsMonThi[i];
        //        if (sche.SubjectID == monthi.SubjectID)
        //        {
        //            index = i;
        //            break;
        //        }
        //    }

        //    SHIFT ans;
        //    try
        //    {
        //        ans = listCaThi[index];
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //    return ans;
        //}

        #endregion Hàm hỗ trợ

        #region Hàm chức năng

        //private List<DonViThi> dsDonViThi;
        //private void ImportLichThi(List<ChiTietLichThi> listLichThi)
        //{
        //    dsDonViThi = new List<DonViThi>();

        //    // Sắp xếp các môn thi theo thứ tự thời gian
        //    List<SCHEDULE> listMonThi = db.SCHEDULES.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList()
        //                                .OrderBy(p => p.TimeOfTest).ToList();

        //    // lấy ra danh sách các môn thi đăng kí ở 1 đơn vị thi (1 phòng thi tại 1 kíp)
        //    foreach (var item in listLichThi)
        //    {
        //        LOCATION diadiem = getLocation(item.LocationName);
        //        ROOMTEST phongthi = getRoomTest(item.LocationName, item.RoomtestName);
        //        DateTime ngaythi = item.ShiftDate;
        //        SUBJECT monthi = getSubject(item.SubjectName);
        //        SCHEDULE monthict = getSchedule(monthi);

        //        int Kip = item.Kip;

        //        DonViThi donvithi = new DonViThi();

        //        try
        //        {
        //            donvithi = dsDonViThi.Where(p => p.diadiem == diadiem && p.phongthi == phongthi && p.ngaythi == ngaythi && p.Kip == Kip).First();
        //        }
        //        catch
        //        {
        //            donvithi = null;
        //        }

        //        if (donvithi == null)
        //        {
        //            donvithi = new DonViThi();
        //            donvithi.diadiem = diadiem;
        //            donvithi.phongthi = phongthi;
        //            donvithi.ngaythi = ngaythi;
        //            donvithi.Kip = Kip;
        //            donvithi.dsMonThi = new List<SCHEDULE>();
        //            dsDonViThi.Add(donvithi);
        //        }

        //        int cnt = donvithi.dsMonThi.Where(p => p.ScheduleID == monthict.ScheduleID).ToList().Count;
        //        if (cnt == 0) donvithi.dsMonThi.Add(monthict);
        //    }

        //    // Thêm lịch thi
        //    foreach (var item in listLichThi)
        //    {
        //        // Lấy các thông tin
        //        LOCATION diadiem = getLocation(item.LocationName);
        //        ROOMTEST phongthi = getRoomTest(item.LocationName, item.RoomtestName);

        //        SUBJECT monthi = getSubject(item.SubjectName);
        //        SCHEDULE monthict = getSchedule(monthi);
        //        CONTESTANT thisinh = getContestant(item.ContestantCode, item.FullName);

        //        /// Lấy thông tin về đơn vị thi
        //        DateTime ngaythi = item.ShiftDate;
        //        int Kip = item.Kip;

        //        DonViThi donvithi = dsDonViThi.Where(p => p.diadiem == diadiem && p.phongthi == phongthi && p.ngaythi == ngaythi && p.Kip == Kip).FirstOrDefault();

        //        // lấy ra ca thi phù hợp để thêm vào
        //        SHIFT cathi = getShift(item.SubjectName, item.ShiftDate, item.Kip, donvithi);

        //        // Kiểm tra nếu có 1 thông tin không hợp lệ thì thông báo
        //        if (diadiem == null || phongthi == null || cathi == null || monthi == null || monthict == null)
        //        {
        //            MessageBox.Show("Chi tiết số thứ tự " + item.STT + " không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            continue;
        //        }

        //        // Kiểm tra division Shift
        //        DIVISION_SHIFTS dv = getDivi(phongthi, cathi);
        //        if (dv == null)
        //        {
        //            try
        //            {
        //                dv = new DIVISION_SHIFTS();
        //                dv.ShiftID = cathi.ShiftID;
        //                dv.RoomTestID = phongthi.RoomTestID;
        //                dv.Status = 1;
        //                db.DIVISION_SHIFTS.Add(dv);
        //                db.SaveChanges();
        //            }
        //            catch
        //            {
        //            }
        //        }

        //        // Thêm contestant Shift
        //        CONTESTANTS_SHIFTS ct = new CONTESTANTS_SHIFTS();
        //        ct.ShiftID = dv.DivisionShiftID;
        //        ct.ContestantID = thisinh.ContestantID;
        //        ct.ScheduleID = monthict.ScheduleID;
        //        ct.Status = 1;

        //        try
        //        {
        //            db.CONTESTANTS_SHIFTS.Add(ct);
        //            db.SaveChanges();
        //        }
        //        catch
        //        {
        //        }
        //    }

        //    // Thông báo thêm lịch thi thành công
        //    MessageBox.Show("Thêm lịch thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    // Gán lại trạng thái của cuộc thi
        //    kithi.Status = (int)ContestStatus.ScheduleShiftDone;
        //    db.SaveChanges();
        //}

        #endregion Hàm chức năng

        private void FrmXepLich_Load(object sender, EventArgs e)
        {
            ucLichThi form = new ucLichThi(kithi);
            panelMain.Controls.Clear();
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
        }
    }
}