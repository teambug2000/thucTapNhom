using ContestManagementVer2.CSDL_Exonsytem;
using EXON.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestManagementVer2.ImportLichThi
{
    public static class ImportLichThiHelper
    {
        private static ExonSystem db = DAO.DBService.db;
        private static CONTEST kithi = new CONTEST();

        #region Enum

        public enum ResultImport
        {
            Fail,
            Success
        }

        #endregion Enum

        #region Hàm hỗ trợ

        private static SCHEDULE getSchedule(SUBJECT subject)
        {
            SCHEDULE ans = db.SCHEDULES.Where(p => p.Status > 0 && p.SubjectID == subject.SubjectID && p.ContestID == kithi.ContestID).FirstOrDefault();
            return ans;
        }

        private static SUBJECT getSubject(int SubjectID)
        {
            SUBJECT ans = db.SUBJECTS.Where(p => p.Status > 0 && p.SubjectID == SubjectID).FirstOrDefault();
            return ans;
        }

        private static DIVISION_SHIFTS getDivi(ROOMTEST rt, SHIFT shift)
        {
            DIVISION_SHIFTS dv = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.RoomTestID == rt.RoomTestID && p.ShiftID == shift.ShiftID).FirstOrDefault();
            return dv;
        }

        private static CONTESTANT getContestant(int cid, string ContestantCode, string FullName)
        {
            try
            {
                CONTESTANT ans = db.CONTESTANTS.Where(p => p.ContestantCode == ContestantCode && p.Status > 0 && p.REGISTER.FullName == FullName && p.REGISTER.ContestID == cid).First();
                return ans;
            }
            catch
            {
                return null;
            }
        }

        private static LOCATION getLocation(string LocationName)
        {
            LOCATION ans;
            ans = db.LOCATIONS.Where(p => p.Status > 0 && p.LocationName == LocationName && p.ContestID == kithi.ContestID).FirstOrDefault();
            return ans;
        }

        private static GROUP getGroup(int contestid, string tenkhoi)
        {
            GROUP ans = db.GROUPS.Where(p => p.ContestID == contestid && p.GroupName == tenkhoi).FirstOrDefault();
            return ans;
        }

        private static ROOMTEST getRoomTest(int contestid, string RoomtestName)
        {
            ROOMTEST ans = db.ROOMTESTS.Where(p => p.Status > 0 && p.RoomTestName == RoomtestName && p.LOCATION.ContestID == contestid).FirstOrDefault();
            return ans;
        }

        private static SHIFT getShift(DateTime Ngay, int Kip, int index)
        {
            /// Lấy ra danh sách ca thi phù hợp
            List<SHIFT> temp = db.SHIFTS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID)
                                    .ToList();
            List<SHIFT> listCaThi = new List<SHIFT>();
            foreach (var item in temp)
            {
                DateTime shiftDate = DateTimeHelpers.ConvertUnixToDateTime(item.ShiftDate);

                if (shiftDate.Year == Ngay.Year && shiftDate.Month == Ngay.Month && shiftDate.Day == Ngay.Day)
                {
                    // trùng ngày thi - tiếp tục phải kiểm tra kíp
                    DateTime StartTime = DateTimeHelpers.ConvertUnixToDateTime(item.StartTime);

                    int kipcathi = 0;
                    if (StartTime.Hour > 12) kipcathi = 1;
                    if (kipcathi == Kip) listCaThi.Add(item);
                }
            }
            listCaThi = listCaThi.OrderBy(p => p.StartTime).ToList();

            // Tìm ca thi thích hợp để tra về kết quả

            SHIFT ans;
            try
            {
                ans = listCaThi[index];
            }
            catch
            {
                return null;
            }

            return ans;
        }

        #endregion Hàm hỗ trợ

        #region Hàm public


        // code xếp lịch thi theo ds thí sinh đã lấy từ file excel của a Hoàng K50
        public static int ImportLichThi(int _idkithi, List<InfoContestant> listLichThi)
        {
            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                kithi = db.CONTESTS.Where(p => p.ContestID == _idkithi).FirstOrDefault();

                List<SCHEDULE> listMonThi = db.SCHEDULES.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList()
                                            .OrderBy(p => p.TimeOfTest).ToList();

                List<DonViThi> dsDonViThi = new List<DonViThi>();

                foreach (var item in listLichThi)
                {
                    int index;
                    try
                    {
                        // string tenDiaDiem = listDiaDiem.Where(p => p.MaDiaDiem == item.LocationCode).FirstOrDefault().TenDiaDiem;

                        //LOCATION diadiem = getLocation(tenDiaDiem);
                        ROOMTEST phongthi = getRoomTest(kithi.ContestID, item.Roomtest);
                        DateTime ngaythi = item.ExamDate;
                        CONTESTANT thisinh = getContestant(kithi.ContestID, item.ContestantCode, item.FullName);

                        /// Lấy ra khối thi
                        GROUP Khoithi = getGroup(kithi.ContestID, item.KhoiThi);

                        if (Khoithi != null)
                        {
                            index = 0;
                            foreach (var Mon in Khoithi.GROUP_SUBJECTS)
                            {
                                SUBJECT monthi = getSubject((int)Mon.SubjectID);
                                SCHEDULE monthict = getSchedule(monthi);

                                int Kip;
                                if (item.Shift == "s" || item.Shift == "S") Kip = 0; else Kip = 1;

                                SHIFT cathi = getShift(ngaythi, Kip, index);
                                index++;

                                /// Thêm lịch thi vào csdl
                                // Kiểm tra nếu có 1 thông tin không hợp lệ thì thông báo
                                if (phongthi == null || cathi == null || monthi == null || monthict == null || thisinh == null)
                                {
                                    MessageBox.Show("Chi tiết số thứ tự " + item.STT + " không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }

                                // Kiểm tra division Shift
                                DIVISION_SHIFTS dv = getDivi(phongthi, cathi);
                                if (dv == null)
                                {
                                    try
                                    {
                                        dv = new DIVISION_SHIFTS();
                                        dv.ShiftID = cathi.ShiftID;
                                        dv.RoomTestID = phongthi.RoomTestID;
                                        dv.Status = 1;
                                        db.DIVISION_SHIFTS.Add(dv);
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Lỗi thêm ca thi: " + ex.Message);
                                    }
                                }

                                // Thêm contestant Shift
                                CONTESTANTS_SHIFTS ct = new CONTESTANTS_SHIFTS();
                                ct.ShiftID = dv.DivisionShiftID;
                                ct.ContestantID = thisinh.ContestantID;
                                ct.ScheduleID = monthict.ScheduleID;
                                ct.Status = 1;

                                try
                                {
                                    db.CONTESTANTS_SHIFTS.Add(ct);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi thêm CONTESTANTS_SHIFTS: " + ex.Message);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                try
                {
                    db.SaveChanges();
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xep lich " + ex.Message);
                }

                // Thông báo thêm lịch thi thành công
                MessageBox.Show("Thêm lịch thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Gán lại trạng thái của cuộc thi
            kithi.Status = (int)ContestStatus.ScheduleShiftDone;
            db.SaveChanges();

            return (int)ResultImport.Success;
        }

        #endregion Hàm public
    }
}