using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateDB.Main;
using EXON.Common;
using System.Threading;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using EXON.Data.Services;

namespace CreateDB
{
    public partial class frmLoading : Form
    {
        private BackgroundWorker bw;
        private Encrypter _encrypt = null;
        private Main.Main model = new Main.Main();
        private Quiz.Quiz quiz = new Quiz.Quiz();

        //int _dsID = 0;
        private static int status = 0;

        private int countSuccessfull = 0;
        private List<int> _lsDvisionShiftID = new List<int>();
        private int issucc = 1;

        public frmLoading(List<int> lsDSID)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            _lsDvisionShiftID = lsDSID;
            lbinfo.Text = "Chuyển dữ liệu " + lsDSID.Count.ToString() + " ca thi";
            //_dsID = id;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(1000);
            //if (issucc != 0)
            //MessageBox.Show("Hoàn Thành quá trình chuyển CSDL");
            //else MessageBox.Show("Quá trình chuyển CSDL bị gián đoạn!");
            //Main.CONTEST contest = new Main.CONTEST();

            this.Close();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbLoading.Value = e.ProgressPercentage;
            lbRate.Text = pgbLoading.Value.ToString() + "%";
            Application.DoEvents();
        }

        // code chuyển dữ liệu thi lên server thi của a Hoàng K50
        // Đã chỉnh sửa: câu hỏi của mỗi ca thi chỉ được chuyển đúng 1 lần
        // Người chỉnh sửa: A Đại K51
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (Staff() == 1)
            {
                if (Position() == 1)
                {
                    if (Contest() == 1)
                    {
                        if (Location2() == 1)
                        {
                            if (RoomTest() == 1)
                            {
                                if (Violation() == 1)
                                {
                                    if (Schedule() == 1)
                                    {
                                        if (Shift() == 1)
                                        {
                                            if (Contestant() == 1)
                                            {
                                                if (ExaminationCouncil() == 1)
                                                {
                                                    //chuyển dữ liệu các bảng QUESTION, SUBQUESTION, ANSWER, TEMP... trước
                                                    List<Question2Transfer> lstQuestion2Transfer = new List<Question2Transfer>();
                                                    FindQuestion2Transfer(lstQuestion2Transfer);
                                                    lstQuestion2Transfer = lstQuestion2Transfer.OrderByDescending(p => p.DivisionShiftID).ToList();
                                                    Question(lstQuestion2Transfer);

                                                    foreach (int i in _lsDvisionShiftID)
                                                    {
                                                        if (BagOfTest(i) == 0) issucc = 0;
                                                    }
                                                    issucc = 1;
                                                    Main.Main m = new Main.Main();
                                                    Main.CONTEST ct = new Main.CONTEST();
                                                    ct = m.CONTESTS.Where(x => x.ContestID == AppSession.ContestID).SingleOrDefault();
                                                    ct.Status = (int)ContestStatus.PrepareTestDone;
                                                    m.SaveChanges();
                                                    MessageBox.Show("Hoàn Thành quá trình chuyển CSDL");
                                                    //return ();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            issucc = 0;
        }

        private delegate void SetLB();

        private void SetLabelText()
        {
            switch (status)
            {
                case 11:

                    lbStaff.ForeColor = Color.Blue;
                    lbStaff.Text = "Đang chuyển dữ liệu cán bộ...";
                    break;

                case 12:
                    lbStaff.ForeColor = Color.Green;
                    lbStaff.Text = "Chuyển dữ liệu cán bộ thành công!";
                    break;

                case 13:
                    lbStaff.ForeColor = Color.Red;
                    lbStaff.Text = "Chuyển dữ liệu cán bộ thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 21:
                    this.Height += 25;
                    lbRoomTest.ForeColor = Color.Blue;
                    lbRoomTest.Text = "Đang chuyển dữ liệu phòng thi...";
                    break;

                case 22:
                    lbRoomTest.ForeColor = Color.Green;
                    lbRoomTest.Text = "Chuyển dữ liệu phòng thi thành công!";
                    break;

                case 23:
                    lbRoomTest.ForeColor = Color.Red;
                    lbRoomTest.Text = "Chuyển dữ liệu phòng thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 31:
                    this.Height += 25;
                    lbViolation.ForeColor = Color.Blue;
                    lbViolation.Text = "Đang chuyển dữ liệu lỗi vi phạm...";
                    break;

                case 32:
                    lbViolation.ForeColor = Color.Green;
                    lbViolation.Text = "Chuyển dữ liệu lỗi vi phạm thành công!";
                    break;

                case 33:
                    lbViolation.ForeColor = Color.Red;
                    lbViolation.Text = "Chuyển dữ liệu lỗi vi phạm thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 41:
                    this.Height += 25;
                    lbSchedule.ForeColor = Color.Blue;
                    lbSchedule.Text = "Đang chuyển dữ liệu môn thi...";
                    break;

                case 42:
                    lbSchedule.ForeColor = Color.Green;
                    lbSchedule.Text = "Chuyển dữ liệu môn thi thành công!";
                    break;

                case 43:
                    lbSchedule.ForeColor = Color.Red;
                    lbSchedule.Text = "Chuyển dữ liệu môn thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 51:
                    this.Height += 25;
                    lbShift.ForeColor = Color.Blue;
                    lbShift.Text = "Đang chuyển dữ liệu ca thi...";
                    break;

                case 52:
                    lbShift.ForeColor = Color.Green;
                    lbShift.Text = "Chuyển dữ liệu ca thi thành công!";
                    break;

                case 53:
                    lbShift.ForeColor = Color.Red;
                    lbShift.Text = "Chuyển dữ liệu ca thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 61:
                    this.Height += 25;
                    lbContestant.ForeColor = Color.Blue;
                    lbContestant.Text = "Đang chuyển dữ liệu thí sinh...";
                    break;

                case 62:
                    lbContestant.ForeColor = Color.Green;
                    lbContestant.Text = "Chuyển dữ liệu thí sinh thành công!";
                    break;

                case 63:
                    lbContestant.ForeColor = Color.Red;
                    lbContestant.Text = "Chuyển dữ liệu thí sinh thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 71:
                    this.Height += 25;
                    lbExam.ForeColor = Color.Blue;
                    lbExam.Text = "Đang chuyển dữ liệu hội đồng thi...";
                    break;

                case 72:

                    lbExam.ForeColor = Color.Green;
                    lbExam.Text = "Chuyển dữ liệu hội đồng thi thành công!";
                    break;

                case 73:
                    lbExam.ForeColor = Color.Red;
                    lbExam.Text = "Chuyển dữ liệu hội đồng thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 81:
                    this.Height += 25;
                    lbTest.ForeColor = Color.Blue;
                    lbTest.Text = "Đang chuyển dữ liệu đề thi...";
                    break;

                case 82:

                    lbTest.ForeColor = Color.Green;
                    lbTest.Text = "Chuyển dữ liệu đề thi thành công!";
                    break;

                case 83:
                    lbTest.ForeColor = Color.Red;
                    lbTest.Text = "Chuyển dữ liệu đề thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 84:
                    this.Height += 25;
                    lbTest.ForeColor = Color.Blue;
                    lbTest.Text = "Đang chuyển dữ liệu câu hỏi thi... ";
                    break;

                case 111:
                    this.Height += 25;
                    lbPosition.ForeColor = Color.Blue;
                    lbPosition.Text = "Đang chuyển dữ liệu chức vụ...";
                    break;

                case 112:
                    lbPosition.ForeColor = Color.Green;
                    lbPosition.Text = "Chuyển dữ liệu chức vụ thành công!";
                    break;

                case 113:
                    lbPosition.ForeColor = Color.Red;
                    lbPosition.Text = "Chuyển dữ liệu chức vụ thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 121:
                    this.Height += 25;
                    lbContest.ForeColor = Color.Blue;
                    lbContest.Text = "Đang chuyển dữ liệu kỳ thi...";
                    break;

                case 122:

                    lbContest.ForeColor = Color.Green;
                    lbContest.Text = "Chuyển dữ liệu kỳ thi thành công!";
                    break;

                case 123:
                    lbContest.ForeColor = Color.Red;
                    lbContest.Text = "Chuyển dữ liệu kỳ thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 131:
                    this.Height += 25;
                    lbLocation.ForeColor = Color.Blue;
                    lbLocation.Text = "Đang chuyển dữ liệu địa điểm thi...";
                    break;

                case 132:

                    lbLocation.ForeColor = Color.Green;
                    lbLocation.Text = "Chuyển dữ liệu địa điểm thi thành công!";
                    break;

                case 133:
                    lbLocation.ForeColor = Color.Red;
                    lbLocation.Text = "Chuyển dữ liệu địa điểm thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                default:
                    this.Height += 25;
                    if (status == _lsDvisionShiftID.Count)
                        lbDivision.ForeColor = Color.Green;
                    else lbDivision.ForeColor = Color.Blue;
                    lbDivision.Text = "Chuyển Xong " + status.ToString() + " ca thi";
                    break;
            }
        }

        public int RoomTest()//2.
        {
            status = 21;
            if (lbRoomTest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.ROOMTEST> lsRoom = new List<Main.ROOMTEST>();
            lsRoom = model.ROOMTESTS.Where(x => x.LocationID == AppSession.LocationID).ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsRoom)
            {
                if (!quiz.ROOMTESTS.Any(x => x.RoomTestID == item.RoomTestID))
                {
                    Quiz.ROOMTEST room = new Quiz.ROOMTEST();
                    room.RoomTestID = item.RoomTestID;
                    room.RoomTestName = item.RoomTestName;
                    room.MaxSeatMount = item.MaxSeatMount;
                    room.MaxSupervisor = item.MaxSupervisor;
                    room.Status = item.Status;
                    room.LocationID = (Int32)item.LocationID;
                    try
                    {
                        quiz.ROOMTESTS.Add(room);
                        quiz.SaveChanges();
                        int count2 = 0;
                        foreach (var roomdiaitem in item.ROOMDIAGRAMS)
                        {
                            Quiz.ROOMDIAGRAM roomdia = new Quiz.ROOMDIAGRAM();
                            roomdia.RoomDiagramID = roomdiaitem.RoomDiagramID;
                            roomdia.ComputerCode = roomdiaitem.ComputerCode;
                            roomdia.ComputerName = roomdiaitem.ComputerName;
                            roomdia.Status = roomdiaitem.Status;
                            roomdia.RoomTestID = roomdiaitem.RoomTestID;
                            try
                            {
                                quiz.ROOMDIAGRAMS.Add(roomdia);
                                quiz.SaveChanges();
                                count2++;
                            }
                            catch
                            { }
                        }
                        if (count2 == item.ROOMDIAGRAMS.Count)
                        {
                            count++;
                            bw.ReportProgress(count / lsRoom.Count);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chuyển ROOMTESTS: \n" + room.RoomTestID.ToString() + ": " + room.RoomTestName + ex.Message);
                    }
                }
            }
            if (count == lsRoom.Count)
            {
                status = 22;
                if (lbRoomTest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 22;
                if (lbRoomTest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsRoom.Count;
            }
        }

        public int Violation()//3.
        {
            status = 31;
            if (lbViolation.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.VIOLATION> lsViolation = new List<Main.VIOLATION>();
            lsViolation = model.VIOLATIONS.ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsViolation)
            {
                try
                {
                    if (!quiz.VIOLATIONS.Any(x => x.ViolationID == item.ViolationID))
                    {
                        Quiz.VIOLATION violation = new Quiz.VIOLATION();
                        violation.ViolationID = item.ViolationID;
                        violation.ViolationName = item.ViolationName;
                        violation.Description = item.Description;
                        violation.Level = item.Level;
                        violation.Status = item.Status;

                        quiz.VIOLATIONS.Add(violation);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count / lsViolation.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển VIOLATIONS: " + item.ViolationID.ToString() + ": " + item.ViolationName + "\n" + ex.Message);
                }
            }
            if (count == lsViolation.Count)
            {
                status = 32;
                if (lbViolation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 33;
                if (lbViolation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsViolation.Count;
            }
        }

        public int Schedule() //4.  bảng schedule, subject
        {
            status = 41;
            if (lbSchedule.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();

            List<Main.SCHEDULE> lsSchedule = new List<Main.SCHEDULE>();
            int count = 0;
            try
            {
                lsSchedule = model.SCHEDULES.Where(x => x.ContestID == AppSession.ContestID).ToList();
                Quiz.Quiz quiz = new Quiz.Quiz();

                bw.ReportProgress(0);
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
            foreach (var item in lsSchedule)
            {
                int debug_val = 0;
                try
                {
                    Quiz.SCHEDULE schedule = new Quiz.SCHEDULE();
                    Quiz.SUBJECT subject = new Quiz.SUBJECT();
                    if (!quiz.SUBJECTS.Any(x => x.SubjectID == item.SUBJECT.SubjectID))
                    {
                        try
                        {
                            subject.SubjectID = item.SUBJECT.SubjectID;
                            debug_val = 1;
                            subject.SubjectName = item.SUBJECT.SubjectName;
                            debug_val = 2;
                            subject.SubjectCode = item.SUBJECT.SubjectCode;
                            debug_val = 3;
                            subject.Status = item.SUBJECT.Status;
                            debug_val = 4;
                            quiz.SUBJECTS.Add(subject);
                            debug_val = 5;
                            quiz.SaveChanges();
                            debug_val = 6;
                        }
                        catch (DbEntityValidationException dbEx)
                        {
                            string ex = "";
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    ex = ex + "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage + "\n";

                                }
                            }
                            MessageBox.Show(ex);
                        }
                    }
                    if (!quiz.SCHEDULES.Any(x => x.ScheduleID == item.ScheduleID))
                    {
                        schedule.ScheduleID = item.ScheduleID;
                        debug_val = 7;
                        schedule.TimeOfTest = item.TimeOfTest;
                        debug_val = 8;
                        schedule.TimeToSubmit = item.TimeToSubmit;
                        debug_val = 9;
                        schedule.Status = item.Status;
                        debug_val = 10;
                        schedule.ContestID = item.ContestID;
                        debug_val = 11;
                        schedule.ContestTypeName = item.CONTEST_TYPES.ContestTypeName;
                        debug_val = 12;
                        schedule.SubjectID = item.SubjectID;
                        debug_val = 13;
                        quiz.SCHEDULES.Add(schedule);
                        debug_val = 14;
                        quiz.SaveChanges();
                        debug_val = 15;
                    }
                    if (!quiz.PARTS.Any(x => x.ScheduleID == item.ScheduleID))
                    {
                        List<PART> cur_path = model.PARTS.Where(x => x.ScheduleID == item.ScheduleID).ToList();
                        debug_val = 16;
                        PartService _PartService = new PartService();
                        foreach (PART each_part in cur_path)
                        {
                            Quiz.PART new_path = new Quiz.PART();
                            EXON.Model.Models.PART part = new EXON.Model.Models.PART();
                            debug_val = 17;
                            new_path.PartID = each_part.PartID;
                            part.PartID = each_part.PartID;
                            debug_val = 18;
                            new_path.CreatedDate = each_part.CreatedDate;
                            part.CreatedDate = each_part.CreatedDate;
                            debug_val = 19;
                            new_path.Status = each_part.Status;
                            part.Status = each_part.Status;
                            debug_val = 20;
                            new_path.ScheduleID = each_part.ScheduleID;
                            part.ScheduleID = each_part.ScheduleID;
                            debug_val = 21;
                            new_path.CreateStaffID = each_part.CreateStaffID;
                            part.CreateStaffID = each_part.CreateStaffID;
                            debug_val = 22;
                            new_path.Name = each_part.Name;
                            part.Name = each_part.Name;
                            debug_val = 23;
                            new_path.OrderOfQuestion = each_part.OrderOfQuestion;
                            part.OrderOfQuestion = each_part.OrderOfQuestion;
                            debug_val = 24;
                            new_path.OrderInTest = each_part.OrderInTest;
                            part.OrderInTest = each_part.OrderInTest;
                            debug_val = 25;
                            new_path.Shuffle = each_part.Shuffle;
                            part.Shuffle = each_part.Shuffle;
                            debug_val = 26;
                            quiz.PARTS.Add(new_path);
                            debug_val = 27;
                            _PartService.Add(part);
                            //_PartService.Save();
                            quiz.SaveChanges();
                            debug_val = 28;
                        }
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsSchedule.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển SCHEDULES: " + item.ScheduleID.ToString() + " " + item.SUBJECT.SubjectName + " \n" + ex.Message + "///" + debug_val);
                }
            }
            if (count == lsSchedule.Count)
            {
                status = 42;
                if (lbSchedule.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 43;
                if (lbSchedule.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsSchedule.Count;
            }
        }

        public int Position() //1.1 bảng  POSITIONS
        {
            status = 111;
            if (lbPosition.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            model = new Main.Main();
            quiz = new Quiz.Quiz();
            List<Main.POSITION> lsPosition = new List<Main.POSITION>();
            lsPosition = model.POSITIONS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsPosition)
            {
                try
                {
                    if (!quiz.POSITIONS.Any(x => x.PositionID == item.PositionID))
                    {
                        Quiz.POSITION position = new Quiz.POSITION();
                        position.PositionID = item.PositionID;
                        position.PositionCode = item.PositionCode;
                        position.PositionName = item.PositionName;
                        position.Permission = item.Permission;
                        position.Status = item.Status;
                        quiz.POSITIONS.Add(position);
                        quiz.SaveChanges();
                    }
                    count++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển POSITIONS " + item.PositionID.ToString() + ": " + item.PositionName + "\n" + ex.Message);
                }
            }
            if (count == lsPosition.Count)
            {
                List<Main.STAFFS_POSITIONS> ls = new List<Main.STAFFS_POSITIONS>();
                ls = model.STAFFS_POSITIONS.ToList();
                int count2 = 0;
                foreach (var itemst in ls)
                {
                    try
                    {
                        if (!quiz.STAFFS_POSITIONS.Any(x => x.StaffID == itemst.StaffID))
                        {
                            Quiz.STAFFS_POSITIONS staff = new Quiz.STAFFS_POSITIONS();
                            staff.PositionID = itemst.PositionID;
                            staff.StaffPositionID = itemst.StaffPositionID;
                            staff.StaffID = itemst.StaffID;
                            quiz.STAFFS_POSITIONS.Add(staff);
                            quiz.SaveChanges();
                        }
                        count2++;
                        bw.ReportProgress(count2 * 100 / ls.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chuyển STAFFS_POSITIONS\n" + itemst.StaffPositionID.ToString() + "\n" + ex.Message);
                    }
                }
                if (count2 == ls.Count)
                {
                    status = 112;
                    if (lbPosition.InvokeRequired)
                    {
                        SetLB set = new SetLB(SetLabelText);
                        Invoke(set);
                    }
                    else
                    {
                        SetLabelText();
                    }
                    return 1;
                }
                else
                {
                    status = 123;
                    if (lbPosition.InvokeRequired)
                    {
                        SetLB set = new SetLB(SetLabelText);
                        Invoke(set);
                    }
                    else
                    {
                        SetLabelText();
                    }
                    return count2 - ls.Count;
                }
            }
            else
                return count - lsPosition.Count;
        }

        public int Contest() //1.2 bảng Contest
        {
            status = 121;
            if (lbContest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            model = new Main.Main();
            quiz = new Quiz.Quiz();
            List<Main.CONTEST> lsContest = new List<Main.CONTEST>();
            lsContest = model.CONTESTS.Where(x => x.ContestID == AppSession.ContestID).ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsContest)
            {
                try
                {
                    Quiz.CONTEST contest = new Quiz.CONTEST();
                    if (quiz.CONTESTS.Where(x => x.ContestID == item.ContestID).Count() == 0)
                    {
                        contest.ContestID = item.ContestID;
                        contest.Status = 7;
                        contest.ContestName = item.ContestName;
                        contest.Description = item.Description;
                        contest.CreatedDate = item.CreatedDate;
                        contest.EndDate = item.EndDate;
                        contest.AcceptedDate = item.AcceptedDate;
                        contest.BeginRegistration = item.BeginRegistration;
                        contest.EndRegistration = item.EndRegistration;
                        contest.CreatedQuestionEndDate = item.CreatedQuestionEndDate;
                        contest.CreatedQuestionStartDate = item.CreatedQuestionStartDate;
                        contest.SchoolYear = item.SchoolYear;
                        contest.CreatedStaffID = item.CreatedStaffID;
                        contest.AcceptedStaffID = item.AcceptedStaffID;

                        quiz.CONTESTS.Add(contest);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsContest.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển CONTESTS " + item.ContestName + "\n" + ex.Message);
                }
            }
            if (count == lsContest.Count)
            {
                status = 122;
                if (lbContest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 123;
                if (lbContest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsContest.Count;
            }
        }

        public int Location2() //1.3 bảng Location
        {
            status = 131;
            if (lbLocation.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            model = new Main.Main();
            quiz = new Quiz.Quiz();
            List<Main.LOCATION> lsLocation = new List<Main.LOCATION>();
            lsLocation = model.LOCATIONS.Where(x => x.LocationID == AppSession.LocationID).ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsLocation)
            {
                try
                {
                    if (!quiz.LOCATIONS.Any(x => x.LocationID == item.LocationID))
                    {
                        Quiz.LOCATION location = new Quiz.LOCATION();
                        location.ContestID = item.ContestID;
                        location.Status = item.Status;
                        location.LocationName = item.LocationName;
                        location.LocationID = item.LocationID;
                        quiz.LOCATIONS.Add(location);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsLocation.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển LOCATIONS " + item.LocationID.ToString() + item.LocationName + "\n" + ex.Message);
                }
            }
            if (count == lsLocation.Count)
            {
                status = 132;
                if (lbLocation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 133;
                if (lbLocation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsLocation.Count;
            }
        }

        public int Contestant() //6. chuyển BẢNG CONTESTANTS, FINGERPRINTS, CONTESTANT_SHIFT(có SCHEDULES trước)
        {
            status = 61;
            if (lbContestant.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.CONTESTANT> lsContestant = new List<Main.CONTESTANT>();
            lsContestant = model.CONTESTANTS.Where(x => x.REGISTER.ContestID == AppSession.ContestID).ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsContestant)
            {
                try
                {
                    //if (!quiz.CONTESTANTS.Any(x => x.ContestantID == item.ContestantID))
                    {
                        Quiz.CONTESTANT contestant_quiz = new Quiz.CONTESTANT();
                        contestant_quiz.ContestantCode = item.ContestantCode;
                        contestant_quiz.ContestantID = item.ContestantID;
                        contestant_quiz.CurrentAddress = item.REGISTER.CurrentAddress;
                        //contestant_quiz.ContestantType = item.REGISTER.CONTESTANT_TYPES.ContestantTypeName;
                        contestant_quiz.DOB = (Int32)item.REGISTER.DOB;
                        contestant_quiz.Ethnic = item.REGISTER.Ethnic;
                        contestant_quiz.FullName = item.REGISTER.FullName;
                        contestant_quiz.HighSchool = item.REGISTER.HighSchool;
                        contestant_quiz.IdentityCardNumber = item.REGISTER.IdentityCardNumber;
                        contestant_quiz.Image = item.REGISTER.Image;
                        contestant_quiz.PlaceOfBirth = item.REGISTER.PlaceOfBirth;
                        if (item.REGISTER.Sex != null)
                            contestant_quiz.Sex = (Int32)item.REGISTER.Sex;
                        else
                            contestant_quiz.Sex = null;
                        contestant_quiz.Status = item.Status;
                        contestant_quiz.StudentCode = item.REGISTER.StudentCode;
                        if (item.REGISTER.TrainingSystem != null)
                            contestant_quiz.TrainingSystem = item.REGISTER.TrainingSystem.ToString();
                        else
                            contestant_quiz.TrainingSystem = null;
                        contestant_quiz.Unit = item.REGISTER.Unit;
                        try
                        {
                            quiz.CONTESTANTS.Add(contestant_quiz);
                            quiz.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi chuyển CONTESTANTS " + item.ContestantID.ToString() + item.REGISTER.FullName + "\n" + ex.Message);
                        }
                        foreach (var i in item.FINGERPRINTS)
                        {
                            Quiz.FINGERPRINT finger = new Quiz.FINGERPRINT();
                            finger.FingerprintID = i.FingerprintID;
                            finger.FingerprintImage = i.FingerprintImage;
                            finger.FilePath = i.FilePath;
                            finger.TimeSaveFingerprint = i.TimeSaveFingerprint;
                            finger.Status = i.Status;
                            finger.ContestantID = i.ContestantID;
                            try
                            {
                                quiz.FINGERPRINTS.Add(finger);
                                quiz.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi chuyển FINGERPRINTS " + item.ContestantID.ToString() + item.REGISTER.FullName + "\n" + ex.Message);
                            }
                        }
                        foreach (var i in item.CONTESTANTS_SHIFTS)
                        {
                            int kt = 0;
                            foreach (int id in _lsDvisionShiftID)
                            {
                                if (i.ShiftID == id)
                                {
                                    kt = 1;
                                    break;
                                }
                            }
                            if (kt == 1)
                            {
                                Quiz.CONTESTANTS_SHIFTS conshift = new Quiz.CONTESTANTS_SHIFTS();
                                conshift.ContestantShiftID = i.ContestantShiftID;
                                conshift.DivisionShiftID = i.ShiftID;
                                conshift.ScheduleID = i.ScheduleID;
                                conshift.Status = item.Status;
                                conshift.ContestantID = i.ContestantID;
                                conshift.IsCheckFingerprint = 2;
                                try
                                {
                                    quiz.CONTESTANTS_SHIFTS.Add(conshift);
                                    quiz.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi ContestantShift " + ex.Message);
                                }
                            }
                        }
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsContestant.Count);
                }
                catch (Exception ex)
                {
                }
            }
            if (count == lsContestant.Count)
            {
                status = 62;
                if (lbContestant.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 63;
                if (lbContestant.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsContestant.Count;
            }
        }

        public int Staff() //1.bảng STAFFS
        {
            status = 11;
            if (lbStaff.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.STAFF> lsstaff = new List<Main.STAFF>();
            lsstaff = model.STAFFS.ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsstaff)
            {
                try
                {
                    if (!quiz.STAFFS.Any(x => x.StaffID == item.StaffID))
                    {
                        Quiz.STAFF staff = new Quiz.STAFF();
                        staff.FullName = item.FullName;
                        //staff.Username = item.StaffID.ToString();
                        staff.DOB = item.DOB;
                        staff.Sex = item.Sex;
                        staff.IdentityCardNumber = item.IdentityCardNumber;
                        staff.AcademicRank = item.AcademicRank;
                        staff.Degree = item.Degree;
                        staff.Status = item.Status;
                        staff.StaffID = item.StaffID;
                        quiz.STAFFS.Add(staff);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsstaff.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển STAFFS " + item.StaffID.ToString() + ": " + item.FullName + "\n" + ex.Message);
                }
            }
            if (count == lsstaff.Count)
            {
                status = 12;
                if (lbStaff.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 13;
                if (lbStaff.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }

                return count - lsstaff.Count;
            }
        }

        public int Shift() //5. bản SHIFTS, DIVISION_SHIFTS (có staff, roomtesst trước)
        {
            status = 51;
            if (lbShift.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            Main.Main model = new Main.Main();
            List<Main.SHIFT> lsShift = new List<Main.SHIFT>();
            // Chỉ chuyển những ca thi có tại địa điểm thi đang chuyển 
            List<int> lstRoomTest = model.ROOMTESTS.Where(p => p.LocationID == AppSession.LocationID).Select(p => p.RoomTestID).ToList();
            List<int> lstShift = model.DIVISION_SHIFTS.Where(p => lstRoomTest.Contains(p.RoomTestID)).Select(p => p.ShiftID).Distinct().ToList();
            lsShift = model.SHIFTS.Where(x => lstShift.Contains(x.ShiftID)).ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            foreach (var item in lsShift)
            {
                try
                {
                    if (!quiz.SHIFTS.Any(x => x.ShiftID == item.ShiftID))
                    {
                        Quiz.SHIFT shift = new Quiz.SHIFT();
                        shift.ContestID = item.ContestID;
                        shift.ShiftName = item.ShiftName;
                        shift.ShiftID = item.ShiftID;
                        shift.ShiftDate = item.ShiftDate;
                        shift.StartTime = item.StartTime;
                        shift.EndTime = item.EndTime;
                        shift.Status = item.Status;
                        quiz.SHIFTS.Add(shift);
                        quiz.SaveChanges();
                        int count2 = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển SHIFTS " + item.ShiftID.ToString() + ": " + item.ShiftName + "\n" + ex.Message);
                }
            }
            List<DIVISION_SHIFTS> lstdivisionshift = new List<DIVISION_SHIFTS>();
            lstdivisionshift = model.DIVISION_SHIFTS.Where(x => x.SHIFT.ContestID == AppSession.ContestID).ToList();
            foreach (var i in lstdivisionshift)
            {
                int kt = 0;
                foreach (int id in _lsDvisionShiftID)
                {
                    if (i.DivisionShiftID == id)
                    {
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1)
                {
                    if (!quiz.DIVISION_SHIFTS.Any(x => x.DivisionShiftID == i.DivisionShiftID))//Kiem tra divshift
                    {
                        Quiz.DIVISION_SHIFTS divisionshift = new Quiz.DIVISION_SHIFTS();
                        divisionshift.DivisionShiftID = i.DivisionShiftID;
                        divisionshift.Status = i.Status;
                        divisionshift.ShiftID = i.ShiftID;
                        divisionshift.StartDate = i.SHIFT.ShiftDate;
                        divisionshift.StartTime = i.SHIFT.StartTime;
                        divisionshift.EndTime = i.SHIFT.EndTime;
                        //divisionshift.SupervisorID = i.SupervisorID;
                        divisionshift.RoomTestID = i.RoomTestID;
                        divisionshift.Key = i.Key;
                        divisionshift.CheckFinger = 2;
                        try
                        {
                            quiz.DIVISION_SHIFTS.Add(divisionshift);
                            quiz.SaveChanges();
                            count++;
                            bw.ReportProgress(count * 100 / _lsDvisionShiftID.Count);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi chuyển DIVISION_SHIFTS " + i.DivisionShiftID.ToString() + "\n" + ex.Message);
                        }
                    }
                }
            }
            if (count == _lsDvisionShiftID.Count)
            {
                status = 52;
                if (lbShift.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 53;
                if (lbShift.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
            }
            return count - lsShift.Count;
        }

        public void FindQuestion2Transfer(List<Question2Transfer> lstQuestion2Transfer)
        {
            Main.Main main = new Main.Main();
            List<int> lst_div_shifts_ID = main.DIVISION_SHIFTS.Where(p => _lsDvisionShiftID.Contains(p.DivisionShiftID)).Select(p => p.DivisionShiftID).ToList();
            foreach (int div_shf_id in lst_div_shifts_ID)
            {
                List<int> lst_bag = main.BAGOFTESTS.Where(p => p.DivisionShiftID == div_shf_id).Select(p => p.BagOfTestID).ToList();
                List<int> lst_test = main.TESTS.Where(p => lst_bag.Contains(p.BagOfTestID)).Select(p => p.TestID).ToList();
                //List<int> lst_question = main.TEST_DETAILS.Where(p => lst_test.Contains(p.TestID)).Select(p => p.QuestionID).Distinct().ToList();
                List<TEST_DETAILS> lst_test_details = main.TEST_DETAILS.Where(p => lst_test.Contains(p.TestID)).ToList();
                foreach (var item in lst_test_details)
                {
                    Question2Transfer qst2trf = new Question2Transfer();
                    qst2trf.QuestionID = item.QuestionID;
                    qst2trf.DivisionShiftID = div_shf_id;
                    qst2trf.Score = item.Score;
                    if (!lstQuestion2Transfer.Contains(qst2trf))
                        lstQuestion2Transfer.Add(qst2trf);
                }
            }
        }

        public void Question(List<Question2Transfer> lstQuestion2Transfer) // chuyển bảng QUESTION_TEMP, QUESTION, SUBQUESTION_TEMP, SUBQUESTION, ANSWER
        {
            status = 84;
            if (lbTest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            int count = 0;
            Main.Main main = new Main.Main();
            Quiz.Quiz quiz = new Quiz.Quiz();

            List<int> lstQuestion = lstQuestion2Transfer.Select(p => p.QuestionID).Distinct().ToList();
            foreach (var item in lstQuestion)
            {
                QUESTION main_ques = main.QUESTIONS.Where(p => p.QuestionID == item).FirstOrDefault();
                Quiz.QUESTION question2 = new Quiz.QUESTION();
                question2.QuestionID = main_ques.QuestionID;
                //question2.QuestionContent = it.QUESTION.QuestionContent;
                question2.QuestionFormat = (Int32)main_ques.QuestionFormat;
                question2.Level = main_ques.Level;
                question2.IsSingleChoice = main_ques.QUESTION_TYPES.IsSingleChoice;
                question2.IsQuiz = main_ques.QUESTION_TYPES.IsQuiz;
                question2.IsQuestionContent = main_ques.QUESTION_TYPES.IsQuestionContent;
                question2.IsParagraph = main_ques.QUESTION_TYPES.IsParagraph;
                question2.NumberAnswer = main_ques.QUESTION_TYPES.NumberAnswer;
                question2.NumberSubQuestion = main_ques.QUESTION_TYPES.NumberSubQuestion;
                question2.Audio = main_ques.Audio;
                question2.Type = main_ques.QUESTION_TYPES.Type;
                question2.HeightToDisplay = main_ques.HeightToDisplay;

                try
                {
                    //quiz.QUESTIONS_TEMP.Add(question);
                    quiz.QUESTIONS.Add(question2);
                    quiz.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển QUESTIONS: " + main_ques.QuestionID.ToString() + "\n" + ex.Message);
                }
            }

            List<int> lstSubQuestion = main.SUBQUESTIONS.Where(p => lstQuestion.Contains(p.QuestionID)).Select(p => p.SubQuestionID).ToList();
            foreach (var item in lstSubQuestion)
            {
                Main.SUBQUESTION itemsub = main.SUBQUESTIONS.Where(p => p.SubQuestionID == item).FirstOrDefault();
                Quiz.SUBQUESTION sub = new Quiz.SUBQUESTION();
                double score = lstQuestion2Transfer.Where(p => p.QuestionID == itemsub.QuestionID).Select(p => p.Score).FirstOrDefault();
                sub.SubQuestionID = itemsub.SubQuestionID;
                //sub.SubQuestionContent = itemsub.SubQuestionContent;
                sub.Score = score;                                        // chỗ này có vẻ không cần thiết lắm
                sub.QuestionID = itemsub.QuestionID;
                sub.HeightToDisplay = itemsub.HeightToDisplay;

                try
                {
                    quiz.SUBQUESTIONS.Add(sub);
                    quiz.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển SUBQUESTIONS " + itemsub.SubQuestionID.ToString() + "\n" + ex.Message);
                }
            }

            List<int> lstAnswer = main.ANSWERS.Where(p => lstSubQuestion.Contains(p.SubQuestionID)).Select(p => p.AnswerID).ToList();
            foreach (var item in lstAnswer)
            {
                Main.ANSWER itemans = main.ANSWERS.Where(p => p.AnswerID == item).FirstOrDefault();
                Quiz.ANSWER ans = new Quiz.ANSWER();
                ans.AnswerID = itemans.AnswerID;
                ans.AnswerContent = itemans.AnswerContent;
                ans.IsCorrect = itemans.IsCorrect;
                ans.SubQuestionID = itemans.SubQuestionID;
                ans.HeightToDisplay = itemans.HeightToDisplay;

                try
                {
                    quiz.ANSWERS.Add(ans);
                    //quiz.ANSWERS_TEMP.Add(anstemp);
                    quiz.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển ANSWERS " + itemans.AnswerID.ToString() + "\n" + ex.Message);
                }
            }

            foreach (var item in lstQuestion2Transfer)
            {
                //if (item.DivisionShiftID == 12 && item.QuestionID == 1082)
                //{

                //}
                Main.DIVISION_SHIFTS divshf = main.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == item.DivisionShiftID).FirstOrDefault();
                _encrypt = new Encrypter(divshf.Key);
                QUESTION main_ques = main.QUESTIONS.Where(p => p.QuestionID == item.QuestionID).FirstOrDefault();
                Quiz.QUESTIONS_TEMP question = new Quiz.QUESTIONS_TEMP();
                Quiz.QUESTION question2 = new Quiz.QUESTION();
                //if (!quiz.QUESTIONS_TEMP.Any(x => x.QuestionID == main_ques.QuestionID && x.DivisionShiftID == item.Value))
                {
                    question.QuestionID = main_ques.QuestionID;
                    question.QuestionContent = _encrypt.Encrypt1000(main_ques.QuestionContent);
                    question.DivisionShiftID = item.DivisionShiftID;
                    question.Type = main_ques.QUESTION_TYPES.Type;
                    quiz.QUESTIONS_TEMP.Add(question);
                    quiz.SaveChanges();
                    //if (!quiz.QUESTIONS.Any(x => x.QuestionID == main_ques.QuestionID))
                    //{
                    //    question2.QuestionID = main_ques.QuestionID;
                    //    //question2.QuestionContent = it.QUESTION.QuestionContent;
                    //    question2.QuestionFormat = (Int32)main_ques.QuestionFormat;
                    //    question2.Level = main_ques.Level;
                    //    question2.IsSingleChoice = main_ques.QUESTION_TYPES.IsSingleChoice;
                    //    question2.IsQuiz = main_ques.QUESTION_TYPES.IsQuiz;
                    //    question2.IsQuestionContent = main_ques.QUESTION_TYPES.IsQuestionContent;
                    //    question2.IsParagraph = main_ques.QUESTION_TYPES.IsParagraph;
                    //    question2.NumberAnswer = main_ques.QUESTION_TYPES.NumberAnswer;
                    //    question2.NumberSubQuestion = main_ques.QUESTION_TYPES.NumberSubQuestion;
                    //    question2.Audio = main_ques.Audio;
                    //    question2.Type = main_ques.QUESTION_TYPES.Type;

                    //    try
                    //    {
                    //        //quiz.QUESTIONS_TEMP.Add(question);
                    //        quiz.QUESTIONS.Add(question2);
                    //        quiz.SaveChanges();
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show("Lỗi chuyển QUESTIONS: " + main_ques.QuestionID.ToString() + "\n" + ex.Message);
                    //    }
                    //}
                }
                var lsSubquestion = main_ques.SUBQUESTIONS;
                foreach (var itemsub in lsSubquestion)
                {
                    //if (!quiz.SUBQUESTIONS_TEMP.Any(x => x.SubQuestionID == itemsub.SubQuestionID && x.DivisionShiftID == item.Value))
                    {
                        Quiz.SUBQUESTIONS_TEMP subtemp = new Quiz.SUBQUESTIONS_TEMP();
                        subtemp.SubQuestionID = itemsub.SubQuestionID;
                        subtemp.SubQuestionContent = _encrypt.Encrypt1000(itemsub.SubQuestionContent);
                        subtemp.QuestionID = itemsub.QuestionID;
                        //subtemp.Score = it.Score;                                         chỗ này có vẻ không cần thiết lắm
                        subtemp.DivisionShiftID = item.DivisionShiftID;
                        quiz.SUBQUESTIONS_TEMP.Add(subtemp);
                        quiz.SaveChanges();
                        //if (!quiz.SUBQUESTIONS.Any(x => x.SubQuestionID == itemsub.SubQuestionID))
                        //{
                        //    Quiz.SUBQUESTION sub = new Quiz.SUBQUESTION();
                        //    sub.SubQuestionID = itemsub.SubQuestionID;
                        //    //sub.SubQuestionContent = itemsub.SubQuestionContent;
                        //    //sub.Score = it.Score;                                         chỗ này có vẻ không cần thiết lắm
                        //    sub.QuestionID = itemsub.QuestionID;

                        //    try
                        //    {
                        //        quiz.SUBQUESTIONS.Add(sub);
                        //        quiz.SaveChanges();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show("Lỗi chuyển SUBQUESTIONS " + itemsub.SubQuestionID.ToString() + "\n" + ex.Message);
                        //    }
                        //}
                        //var lsAnswer = itemsub.ANSWERS;
                        //foreach (var itemans in lsAnswer)
                        //{
                        //    Quiz.ANSWER ans = new Quiz.ANSWER();
                        //    //if (quiz.ANSWERS.Where(x => x.AnswerID == itemans.AnswerID).ToList().Count == 0)
                        //    {
                        //        ans.AnswerID = itemans.AnswerID;
                        //        ans.AnswerContent = itemans.AnswerContent;
                        //        ans.IsCorrect = itemans.IsCorrect;
                        //        ans.SubQuestionID = itemans.SubQuestionID;

                        //        try
                        //        {
                        //            quiz.ANSWERS.Add(ans);
                        //            //quiz.ANSWERS_TEMP.Add(anstemp);
                        //            quiz.SaveChanges();
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            MessageBox.Show("Lỗi chuyển ANSWERS " + itemans.AnswerID.ToString() + "\n" + ex.Message);
                        //        }
                        //    }
                        //}
                    }
                }
                bw.ReportProgress(++count * 100 / lstQuestion2Transfer.Count);
            }
        }

        public object GetDataValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }

            return value;
        }

        public int BagOfTest(int _dsID) //7. bang BAGOFTEST,TEST,TEST_DETAILS, QUESTION_TEMP, SUBQUESTION_TEMP, ANSWERS_TEMP
        {
            status = 81;
            if (lbTest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            Main.Main main = new Main.Main();
            Quiz.Quiz quiz = new Quiz.Quiz();
            Main.BAGOFTEST bg = new BAGOFTEST();
            bg = main.BAGOFTESTS.Where(x => x.DivisionShiftID == _dsID).FirstOrDefault();
            if (bg != null)
            {
                if (!quiz.BAGOFTESTS.Any(x => x.DivisionShiftID == bg.DivisionShiftID))
                {
                    Quiz.BAGOFTEST bagOfTest = new Quiz.BAGOFTEST();
                    bagOfTest.BagOfTestID = bg.BagOfTestID;
                    bagOfTest.DivisionShiftID = bg.DivisionShiftID;
                    bagOfTest.Status = bg.Status;
                    bagOfTest.NumberOfTest = bg.NumberOfTest;
                    //luu bag of test vao csdl de lay BagOfTestID
                    try
                    {
                        if (!quiz.BAGOFTESTS.Any(x => x.BagOfTestID == bg.BagOfTestID))
                        {
                            Quiz.DIVISION_SHIFTS dsquiz = new Quiz.DIVISION_SHIFTS();
                            dsquiz = quiz.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == _dsID).SingleOrDefault();
                            string key = dsquiz.Key;
                            if (key == null)
                            {
                                //key = new Random().Next(100000, 999999).ToString();
                                //dsquiz.Key = key;
                                MessageBox.Show("Đề thi của ca thi " + dsquiz.SHIFT.ShiftName + ", phòng thi " + dsquiz.ROOMTEST.RoomTestName + " chưa được niêm phong!");
                                return 0;
                            }
                            _encrypt = new Encrypter(key);
                            quiz.SaveChanges();
                            quiz.BAGOFTESTS.Add(bagOfTest);
                            quiz.SaveChanges();
                            if (bg.TESTS.Count == 0)
                            {
                                MessageBox.Show("Túi đề thi của phòng " + dsquiz.ROOMTEST.RoomTestName + ", ca thi " + dsquiz.SHIFT.ShiftName + " chưa có đề thi! Vui lòng kiểm tra lại và chuyển lại CSDL!");
                                return 0;
                            }
                        }
                        int count = 0;

                        foreach (var itemtest in bg.TESTS)
                        {
                            Quiz.TEST test = new Quiz.TEST()
                            {
                                BagOfTestID = itemtest.BagOfTestID,
                                SubjectID = itemtest.SubjectID,
                                TestID = itemtest.TestID,
                                Status = 1
                            };
                            //Luu Test vao csdls
                            try
                            {
                                //if (!quiz.TESTS.Any(x => x.TestID == test.TestID))
                                {
                                    quiz.TESTS.Add(test);
                                    quiz.SaveChanges();
                                }

                                foreach (var it in main.TEST_DETAILS.Where(x => x.TestID == itemtest.TestID))
                                {
                                    //Quiz.TEST_DETAILS tsDetail = new Quiz.TEST_DETAILS();

                                    #region Phần này đã đc chuyển lên function Question()
                                    //Quiz.QUESTIONS_TEMP question = new Quiz.QUESTIONS_TEMP();
                                    //Quiz.QUESTION question2 = new Quiz.QUESTION();
                                    //if (!quiz.QUESTIONS_TEMP.Any(x => x.QuestionID == it.QuestionID && x.DivisionShiftID == _dsID))
                                    //{
                                    //    question.QuestionID = it.QuestionID;
                                    //    question.QuestionContent = _encrypt.Encrypt1000(it.QUESTION.QuestionContent);
                                    //    //question.QuestionFormat = (Int32)it.QUESTION.QuestionFormat;
                                    //    //question.Level = it.QUESTION.Level;
                                    //    //question.IsSingleChoice = it.QUESTION.QUESTION_TYPES.IsSingleChoice;
                                    //    //question.IsQuiz = it.QUESTION.QUESTION_TYPES.IsQuiz;
                                    //    //question.IsQuestionContent = it.QUESTION.QUESTION_TYPES.IsQuestionContent;
                                    //    //question.IsParagarph = it.QUESTION.QUESTION_TYPES.IsParagraph;
                                    //    //question.NumberAnswer = it.QUESTION.QUESTION_TYPES.NumberAnswer;
                                    //    //question.NumberSubQuestion = it.QUESTION.QUESTION_TYPES.NumberSubQuestion;
                                    //    question.DivisionShiftID = _dsID;
                                    //    //question.Audio = it.QUESTION.Audio;
                                    //    question.Type = it.QUESTION.QUESTION_TYPES.Type;
                                    //    quiz.QUESTIONS_TEMP.Add(question);
                                    //    quiz.SaveChanges();
                                    //    if (!quiz.QUESTIONS.Any(x => x.QuestionID == it.QuestionID))
                                    //    {
                                    //        question2.QuestionID = it.QuestionID;
                                    //        //question2.QuestionContent = it.QUESTION.QuestionContent;
                                    //        question2.QuestionFormat = (Int32)it.QUESTION.QuestionFormat;
                                    //        question2.Level = it.QUESTION.Level;
                                    //        question2.IsSingleChoice = it.QUESTION.QUESTION_TYPES.IsSingleChoice;
                                    //        question2.IsQuiz = it.QUESTION.QUESTION_TYPES.IsQuiz;
                                    //        question2.IsQuestionContent = it.QUESTION.QUESTION_TYPES.IsQuestionContent;
                                    //        question2.IsParagraph = it.QUESTION.QUESTION_TYPES.IsParagraph;
                                    //        question2.NumberAnswer = it.QUESTION.QUESTION_TYPES.NumberAnswer;
                                    //        question2.NumberSubQuestion = it.QUESTION.QUESTION_TYPES.NumberSubQuestion;
                                    //        question2.Audio = it.QUESTION.Audio;
                                    //        question2.Type = it.QUESTION.QUESTION_TYPES.Type;
                                    //        question2.HeightToDisplay = it.QUESTION.HeightToDisplay;
                                    //        try
                                    //        {
                                    //            quiz.QUESTIONS_TEMP.Add(question);
                                    //            quiz.QUESTIONS.Add(question2);
                                    //            quiz.SaveChanges();
                                    //        }
                                    //        catch (Exception ex)
                                    //        {
                                    //            MessageBox.Show("Lỗi chuyển QUESTIONS: " + it.QuestionID.ToString() + "\n" + ex.Message);
                                    //        }
                                    //    }
                                    //    var lsSubquestion = it.QUESTION.SUBQUESTIONS;
                                    //    foreach (var itemsub in lsSubquestion)
                                    //    {
                                    //        if (!quiz.SUBQUESTIONS_TEMP.Any(x => x.SubQuestionID == itemsub.SubQuestionID && x.DivisionShiftID == _dsID))
                                    //        {
                                    //            Quiz.SUBQUESTIONS_TEMP subtemp = new Quiz.SUBQUESTIONS_TEMP();
                                    //            subtemp.SubQuestionID = itemsub.SubQuestionID;
                                    //            subtemp.SubQuestionContent = _encrypt.Encrypt1000(itemsub.SubQuestionContent);
                                    //            subtemp.QuestionID = itemsub.QuestionID;
                                    //            subtemp.Score = it.Score;
                                    //            subtemp.DivisionShiftID = _dsID;
                                    //            quiz.SUBQUESTIONS_TEMP.Add(subtemp);
                                    //            if (!quiz.SUBQUESTIONS.Any(x => x.SubQuestionID == itemsub.SubQuestionID))
                                    //            {
                                    //                Quiz.SUBQUESTION sub = new Quiz.SUBQUESTION();
                                    //                sub.SubQuestionID = itemsub.SubQuestionID;
                                    //                //sub.SubQuestionContent = itemsub.SubQuestionContent;
                                    //                sub.Score = it.Score;
                                    //                sub.QuestionID = itemsub.QuestionID;
                                    //                sub.HeightToDisplay = itemsub.HeightToDisplay;
                                    //                try
                                    //                {
                                    //                    quiz.SUBQUESTIONS.Add(sub);
                                    //                    quiz.SaveChanges();
                                    //                }
                                    //                catch (Exception ex)
                                    //                {
                                    //                    MessageBox.Show("Lỗi chuyển SUBQUESTIONS " + itemsub.SubQuestionID.ToString() + "\n" + ex.Message);
                                    //                }
                                    //            }
                                    //            var lsAnswer = itemsub.ANSWERS;
                                    //            foreach (var itemans in lsAnswer)
                                    //            {
                                    //                //Quiz.ANSWERS_TEMP anstemp = new Quiz.ANSWERS_TEMP();
                                    //                Quiz.ANSWER ans = new Quiz.ANSWER();
                                    //                //anstemp.AnswerID = itemans.AnswerID;
                                    //                //anstemp.AnswerContent = itemans.AnswerContent;
                                    //                //anstemp.IsCorrect = itemans.IsCorrect;
                                    //                //anstemp.SubQuestionID = itemans.SubQuestionID;
                                    //                //anstemp.DivisionShiftID = _dsID;
                                    //                //quiz.ANSWERS_TEMP.Add(anstemp);
                                    //                //quiz.SaveChanges();
                                    //                if (quiz.ANSWERS.Where(x => x.AnswerID == itemans.AnswerID).ToList().Count == 0)
                                    //                {
                                    //                    ans.AnswerID = itemans.AnswerID;
                                    //                    ans.AnswerContent = itemans.AnswerContent;
                                    //                    ans.IsCorrect = itemans.IsCorrect;
                                    //                    ans.SubQuestionID = itemans.SubQuestionID;
                                    //                    ans.HeightToDisplay = itemans.HeightToDisplay;
                                    //                    try
                                    //                    {
                                    //                        quiz.ANSWERS.Add(ans);
                                    //                        //quiz.ANSWERS_TEMP.Add(anstemp);
                                    //                        quiz.SaveChanges();
                                    //                    }
                                    //                    catch (Exception ex)
                                    //                    {
                                    //                        MessageBox.Show("Lỗi chuyển ANSWERS " + itemans.AnswerID.ToString() + "\n" + ex.Message);
                                    //                    }
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    #endregion Phần này đã đc chuyển lên function Question()
                                    //if (quiz.TESTS.Where(x => x.TestID == testid).ToList().Count == 0)
                                    // {//////////////////////////////////////////////////////////////////////// chỗ này đặt debug                                
                                    //tsDetail.TestID = it.TestID;
                                    //tsDetail.RandomAnswer = it.RandomAnswer;
                                    //tsDetail.NumberIndex = it.NumberIndex;
                                    //tsDetail.Score = it.Score;
                                    //tsDetail.TestDetailID = it.TestDetailID;
                                    //tsDetail.QuestionID = it.QuestionID;
                                    //tsDetail.Status = it.Status;
                                    try
                                    {
                                        //if (quiz.TEST_DETAILS.Where(x => x.TestDetailID == test.TestID).Count() == 0)
                                        //{
                                        string query = "insert into TEST_DETAILS(TestDetailID, RandomAnswer, NumberIndex, Score, Status, TestID, QuestionID) values(@TestDetailID, @RandomAnswer, @NumberIndex, @Score, @Status, @TestID, @QuestionID)";
                                        List<SqlParameter> para = new List<SqlParameter>();
                                        para.Add(new SqlParameter("@TestDetailID", GetDataValue(it.TestDetailID)));
                                        para.Add(new SqlParameter("@RandomAnswer", GetDataValue(it.RandomAnswer)));
                                        para.Add(new SqlParameter("@NumberIndex", GetDataValue(it.NumberIndex)));
                                        para.Add(new SqlParameter("@Score", GetDataValue(it.Score)));
                                        para.Add(new SqlParameter("@Status", GetDataValue(it.Status)));
                                        para.Add(new SqlParameter("@TestID", GetDataValue(it.TestID)));
                                        para.Add(new SqlParameter("@QuestionID", GetDataValue(it.QuestionID)));
                                        quiz.Database.ExecuteSqlCommand(query, para.ToArray());
                                        //quiz.TEST_DETAILS.Add(tsDetail);
                                        quiz.SaveChanges();
                                        //}
                                    }
                                    catch (Exception e)
                                    {
                                        //MessageBox.Show("Lỗi chuyển TESTS_DETAILS: " + it.TestDetailID.ToString() + "\n" + e.Message);
                                    }

                                    // }

                                    //lưu subquestion
                                }
                                count++;
                                bw.ReportProgress(count * 100 / bg.TESTS.Count);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Lỗi chuyển TESTS: " + itemtest.TestID.ToString() + "\n" + e.Message);
                            }
                        }

                        if (count == bg.TESTS.Count)
                        {
                            countSuccessfull++;
                            status = countSuccessfull;
                            if (lbDivision.InvokeRequired)
                            {
                                SetLB set = new SetLB(SetLabelText);
                                Invoke(set);
                            }
                            else
                            {
                                SetLabelText();
                            }
                        }
                        else
                        {
                            status = 83;
                            if (lbTest.InvokeRequired)
                            {
                                SetLB set = new SetLB(SetLabelText);
                                Invoke(set);
                            }
                            else
                            {
                                SetLabelText();
                            }
                        }
                        if (countSuccessfull == _lsDvisionShiftID.Count)
                        {
                            status = 82;
                            if (lbTest.InvokeRequired)
                            {
                                SetLB set = new SetLB(SetLabelText);
                                Invoke(set);
                            }
                            else
                            {
                                SetLabelText();
                            }
                        }
                        else
                        {
                            status = 83;
                            if (lbTest.InvokeRequired)
                            {
                                SetLB set = new SetLB(SetLabelText);
                                Invoke(set);
                            }
                            else
                            {
                                SetLabelText();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chuyển BAGOFTESTS: " + bagOfTest.BagOfTestID.ToString() + "\n" + ex.Message);
                        return 0;
                    }
                }
                else
                {
                    DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
                    dv = main.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == _dsID).SingleOrDefault();
                    MessageBox.Show("Ca thi " + dv.SHIFT.ShiftName + " phòng " + dv.ROOMTEST.RoomTestName + " không có đề thi!");
                }
                //}
                //}
                return 1;
            }
            return 0;
        }

        public int ExaminationCouncil()//7
        {
            status = 71;
            if (lbExam.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            Main.Main model = new Main.Main();
            List<Main.EXAMINATIONCOUNCIL_STAFFS> lsExamStaff = new List<Main.EXAMINATIONCOUNCIL_STAFFS>();
            lsExamStaff = model.EXAMINATIONCOUNCIL_STAFFS.Where(x => x.LocationID == AppSession.LocationID).ToList();
            List<Main.EXAMINATIONCOUNCIL_POSITIONS> lsExamPosition = new List<Main.EXAMINATIONCOUNCIL_POSITIONS>();
            lsExamPosition = model.EXAMINATIONCOUNCIL_POSITIONS.ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count1 = 0;
            int count2 = 0;
            foreach (var i in lsExamPosition)
            {
                try
                {
                    if (!quiz.EXAMINATIONCOUNCIL_POSITIONS.Any(x => x.ExaminationCouncil_PositionID == i.ExaminationCouncil_PositionID))
                    {
                        Quiz.EXAMINATIONCOUNCIL_POSITIONS examposition = new Quiz.EXAMINATIONCOUNCIL_POSITIONS();
                        examposition.ExaminationCouncil_PositionID = i.ExaminationCouncil_PositionID;
                        examposition.ExaminationCouncil_PositionCode = i.ExaminationCouncil_PositionCode;
                        examposition.ExaminationCouncil_PositionName = i.ExaminationCouncil_PositionName;
                        examposition.Permission = i.Permission;
                        examposition.Status = i.Status;
                        quiz.EXAMINATIONCOUNCIL_POSITIONS.Add(examposition);
                        quiz.SaveChanges();
                    }
                    count1++;
                }
                catch (Exception ex)
                {
                    string a = ex.ToString();
                }
            }
            if (count1 == lsExamPosition.Count)
            {
                foreach (var item in lsExamStaff)
                {
                    try
                    {
                        if (!quiz.EXAMINATIONCOUNCIL_STAFFS.Any(x => x.ExaminationCouncil_StaffID == item.ExaminationCouncil_StaffID))
                        {
                            Quiz.EXAMINATIONCOUNCIL_STAFFS examstaff = new Quiz.EXAMINATIONCOUNCIL_STAFFS();
                            examstaff.ExaminationCouncil_StaffID = item.ExaminationCouncil_StaffID;
                            examstaff.ContestID = item.ContestID;
                            examstaff.StaffID = item.StaffID;
                            examstaff.ExaminationCouncil_PositionID = item.ExaminationCouncil_PositionID;
                            examstaff.LocationID = item.LocationID;
                            examstaff.UserName = item.UserName;
                            examstaff.Password = item.Password;
                            examstaff.Status = item.Status;
                            quiz.EXAMINATIONCOUNCIL_STAFFS.Add(examstaff);
                            quiz.SaveChanges();
                            //if (examstaff.EXAMINATIONCOUNCIL_POSITIONS.ExaminationCouncil_PositionCode == "DT")
                            //{
                            //    foreach (int dvid in _lsDvisionShiftID)
                            //    {
                            //        Quiz.DIVISIONSHIFT_SUPERVISOR disu = new Quiz.DIVISIONSHIFT_SUPERVISOR();
                            //        disu.DivisionShiftID = dvid;
                            //        disu.SupervisorID = examstaff.StaffID;
                            //        quiz.DIVISIONSHIFT_SUPERVISOR.Add(disu);
                            //        try
                            //        {
                            //            quiz.SaveChanges();
                            //        }
                            //        catch (Exception ex)
                            //        {
                            //            string s = ex.Message;
                            //        }
                            //    }
                            //}
                        }

                        count2++;
                        bw.ReportProgress(count2 * 100 / lsExamStaff.Count);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.ToString();
                    }
                }
            }

            if (count2 == lsExamStaff.Count)
            {
                status = 72;
                if (lbExam.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 73;
                if (lbExam.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count2 - lsExamStaff.Count;
            }
        }
        private void frmLoading_Load(object sender, EventArgs e)
        {
            string sql = @"
            delete SPEAKING_TEACHER
            delete WRITING_TEACHER
            delete TESTNUMBER
            delete from ANSWERSHEET_SPEAKING
            delete ANSWERSHEET_WRITING
            delete from ANSWERSHEET_DETAILS
            delete from ANSWERSHEETS
            delete from CONTESTANTPAUSE
            delete from DIVSIONSHIFT_PAUSE
            delete from SHIFTSPAUSE
            delete from CONTESTANTS_TESTS
            delete from VIOLATIONS_CONTESTANTS
            delete from answers
            delete from answers_temp
            delete from subquestions
            delete from subquestions_temp
            delete from TEST_DETAILS
            delete from TESTS
            delete from BAGOFTESTS
            delete from QUESTIONS
            delete from QUESTIONS_TEMP
            delete from DIVISIONSHIFT_SUPERVISOR
            delete from EXAMINATIONCOUNCIL_STAFFS
            delete from EXAMINATIONCOUNCIL_POSITIONS
            delete from PARTS
            delete from CONTESTANTS_SHIFTS
            delete from FINGERPRINTS
            delete from contestants
            delete from DIVISION_SHIFTS
            delete from shifts

            delete from schedules
            delete from SUBJECTS

            delete from VIOLATIONS
            delete from ROOMDIAGRAMS
            delete from ROOMTESTS
            delete from STAFFS_POSITIONS
            delete from LOCATIONS
            delete from CONTESTS

            delete from STAFFS
            delete from POSITIONS";

            try
            {
                int k = quiz.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                MessageBox.Show("Xóa dữ liệu cũ thất bại!\n" + s);
                this.Close();
            }
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh
            // su kien
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bw.CancelAsync();
            }
            catch { }
        }
    }

    public class Question2Transfer
    {
        public int QuestionID { get; set; }
        public int DivisionShiftID { get; set; }
        public double Score { get; set; }
        public override bool Equals(object obj)
        {
            Question2Transfer qst = (Question2Transfer)obj;
            if (this.QuestionID != qst.QuestionID)
                return false;
            if (this.DivisionShiftID != qst.DivisionShiftID)
                return false;
            return true;
        }

        public static bool operator ==(Question2Transfer qst1, Question2Transfer qst2)
        {
            return qst1.Equals(qst2);
        }

        public static bool operator !=(Question2Transfer qst1, Question2Transfer qst2)
        {
            return !qst1.Equals(qst2);
        }
    }
}