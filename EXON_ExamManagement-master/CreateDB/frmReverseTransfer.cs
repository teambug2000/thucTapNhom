using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateDB.Quiz;
using CreateDB.QuizStorage;

namespace CreateDB
{
    public partial class frmReverseTransfer : Form
    {
        // Các Dictionary để lưu ID của bảng trong Quiz và trong QuizStore
        #region Dictionary Definition
        Dictionary<int, int> answer_dict = new Dictionary<int, int>();
        Dictionary<int, int> answers_temp_dict = new Dictionary<int, int>();
        Dictionary<int, int> answersheet_dict = new Dictionary<int, int>();
        Dictionary<int, int> answersheet_details_dict = new Dictionary<int, int>();
        Dictionary<int, int> answersheet_speaking_dict = new Dictionary<int, int>();
        Dictionary<int, int> answersheet_writing_dict = new Dictionary<int, int>();
        Dictionary<int, int> bagoftest_dict = new Dictionary<int, int>();
        Dictionary<int, int> contest_dict = new Dictionary<int, int>();
        Dictionary<int, int> contestant_dict = new Dictionary<int, int>();
        Dictionary<int, int> contestantpause_dict = new Dictionary<int, int>();
        Dictionary<int, int> contestants_shifts_dict = new Dictionary<int, int>();
        Dictionary<int, int> contestants_tests_dict = new Dictionary<int, int>();
        Dictionary<int, int> division_shifts_dict = new Dictionary<int, int>();
        Dictionary<int, int> divisionshift_supervisor_dict = new Dictionary<int, int>();
        Dictionary<int, int> divisionshift_pause_dict = new Dictionary<int, int>();
        Dictionary<int, int> examinationcouncil_positions_dict = new Dictionary<int, int>();
        Dictionary<int, int> examinationcouncil_staffs_dict = new Dictionary<int, int>();
        Dictionary<int, int> fingerprint_dict = new Dictionary<int, int>();
        Dictionary<int, int> location_dict = new Dictionary<int, int>();
        Dictionary<int, int> part_dict = new Dictionary<int, int>();
        Dictionary<int, int> position_dict = new Dictionary<int, int>();
        Dictionary<int, int> question_dict = new Dictionary<int, int>();
        Dictionary<int, int> questions_temp_dict = new Dictionary<int, int>();
        Dictionary<int, int> roomdiagram_dict = new Dictionary<int, int>();
        Dictionary<int, int> roomtest_dict = new Dictionary<int, int>();
        Dictionary<int, int> schedule_dict = new Dictionary<int, int>();
        Dictionary<int, int> shift_dict = new Dictionary<int, int>();
        Dictionary<int, int> shiftspause_dict = new Dictionary<int, int>();
        Dictionary<int, int> speaking_teacher_dict = new Dictionary<int, int>();
        Dictionary<int, int> staffs_dict = new Dictionary<int, int>();
        Dictionary<int, int> staffs_positions_dict = new Dictionary<int, int>();
        Dictionary<int, int> subject_dict = new Dictionary<int, int>();
        Dictionary<int, int> subquestion_dict = new Dictionary<int, int>();
        Dictionary<int, int> subquestions_temp_dict = new Dictionary<int, int>();
        Dictionary<int, int> test_dict = new Dictionary<int, int>();
        Dictionary<int, int> test_details_dict = new Dictionary<int, int>();
        Dictionary<int, int> testnumber_dict = new Dictionary<int, int>();
        Dictionary<int, int> violation_dict = new Dictionary<int, int>();
        Dictionary<int, int> violations_contestants_dict = new Dictionary<int, int>();
        Dictionary<int, int> writing_teacher_dict = new Dictionary<int, int>();
        #endregion Dictionary Definition

        // List các Question, Subquestion không cần thêm, do nội dung kỳ thi bị trùng
        // (nội dung kỳ thi của 2 bản ghi trong Contest bị trùng nhau)
        List<int> lst_except_question = new List<int>();

        // List các Shift bị bỏ qua do đã bỏ qua Địa điểm thi, và các Shift bị bỏ qua do chưa hoàn thành thi
        List<int> lst_except_shift = new List<int>();
        List<int> lst_incompleted_shift = new List<int>();

        // Chuỗi lưu thông tin các kỳ thi, điểm thi đã đc chuyển về MTAQuizStorage
        string location_except_message = "";
        string contest_except_message = "";
        string divshift_except_message = "";
        string system_error_message = "";

        // DbContext
        Quiz.Quiz quizDB = new Quiz.Quiz();
        QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();

        public frmReverseTransfer()
        {
            InitializeComponent();

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;           
        }

        public void initDict()
        {
            answer_dict = new Dictionary<int, int>();
            answers_temp_dict = new Dictionary<int, int>();
            answersheet_dict = new Dictionary<int, int>();
            answersheet_details_dict = new Dictionary<int, int>();
            answersheet_speaking_dict = new Dictionary<int, int>();
            answersheet_writing_dict = new Dictionary<int, int>();
            bagoftest_dict = new Dictionary<int, int>();
            contest_dict = new Dictionary<int, int>();
            contestant_dict = new Dictionary<int, int>();
            contestantpause_dict = new Dictionary<int, int>();
            contestants_shifts_dict = new Dictionary<int, int>();
            contestants_tests_dict = new Dictionary<int, int>();
            division_shifts_dict = new Dictionary<int, int>();
            divisionshift_supervisor_dict = new Dictionary<int, int>();
            divisionshift_pause_dict = new Dictionary<int, int>();
            examinationcouncil_positions_dict = new Dictionary<int, int>();
            examinationcouncil_staffs_dict = new Dictionary<int, int>();
            fingerprint_dict = new Dictionary<int, int>();
            location_dict = new Dictionary<int, int>();
            part_dict = new Dictionary<int, int>();
            position_dict = new Dictionary<int, int>();
            question_dict = new Dictionary<int, int>();
            questions_temp_dict = new Dictionary<int, int>();
            roomdiagram_dict = new Dictionary<int, int>();
            roomtest_dict = new Dictionary<int, int>();
            schedule_dict = new Dictionary<int, int>();
            shift_dict = new Dictionary<int, int>();
            shiftspause_dict = new Dictionary<int, int>();
            speaking_teacher_dict = new Dictionary<int, int>();
            staffs_dict = new Dictionary<int, int>();
            staffs_positions_dict = new Dictionary<int, int>();
            subject_dict = new Dictionary<int, int>();
            subquestion_dict = new Dictionary<int, int>();
            subquestions_temp_dict = new Dictionary<int, int>();
            test_dict = new Dictionary<int, int>();
            test_details_dict = new Dictionary<int, int>();
            testnumber_dict = new Dictionary<int, int>();
            violation_dict = new Dictionary<int, int>();
            violations_contestants_dict = new Dictionary<int, int>();
            writing_teacher_dict = new Dictionary<int, int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void set_lblprocessing(string text)
        {
            lbl_processing.Invoke((Action)(() => {
                lbl_processing.Text = text;
                lbl_processing.ForeColor = Color.Blue;
            }));
        }

        private void set_lblresult(string text)
        {
            if (text != "clear")
            {
                lbl_completed.Invoke((Action)(() => {
                    lbl_completed.Text += "\n" + text;
                    lbl_completed.ForeColor = Color.Green;
                }));
            }
            else
            {
                lbl_completed.Invoke((Action)(() => {
                    lbl_completed.Text = "";
                    lbl_completed.ForeColor = Color.Green;
                }));
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

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            using (System.Data.Entity.DbContextTransaction tran = quizstorageDB.Database.BeginTransaction())
            {
                try
                {
                    // Level 1 Transfer
                    Contest_Transfer();
                    Position_Transfer();
                    Staff_Transfer();
                    ExaminationCounCil_Positions_Transfer();
                    Subject_Transfer();
                    Contestant_Transfer();
                    Violation_Transfer();
                    // Level 2 Transfer
                    Staffs_Positions_Transfer();
                    Location_Transfer();
                    Shift_Transfer();                    
                    Schedule_Transfer();
                    Fingerprint_Transfer();
                    // Level 3 Transfer
                    ExaminationCoundcil_Staffs_Transfer();
                    Part_Transfer();
                    ShiftsPause_Transfer();
                    RoomTest_Transfer();
                    // Level 4 Transfer
                    Division_Shifts_Transfer();
                    RoomDiagram_Transfer();
                    // Level 5 Transfer
                    DivisionShift_Supervisor_Transfer();
                    DivisionShift_Pause_Transfer();
                    BagOfTest_Transfer();
                    Contestants_Shifts_Transfer();
                    TestNumber_Transfer();
                    Test_Transfer();
                    Violations_Contestants_Transfer();
                    FindExceptQuestions();
                    Question_Transfer();
                    // Level 6 Transfer
                    Contestants_Tests_Transfer();
                    Test_Details_Transfer();
                    // Level 7 Transfer
                    Answersheet_Transfer();
                    ContestantPause_Transfer();
                    Subquestion_Transfer();
                    // Level 8 Transfer
                    Answersheet_Speaking_Transfer();
                    Answersheet_Writing_Transfer();
                    Answersheet_Details_Transfer();
                    Answer_Transfer();
                    // Level 9 Transfer
                    Speaking_Teacher_Transfer();
                    Writing_Teacher_Transfer();
                    // Level 10 Transfer
                    Questions_Temp_Transfer();
                    Subquestions_Temp_Transfer();
                    Answers_Temp_Transfer();

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex.Message != "Thread was being aborted.")
                    {
                        system_error_message = ex.Message;                        
                    }
                    else
                    {
                        system_error_message = "Đã hủy.";
                    }
                    tran.Rollback();
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbLoading.Value = e.ProgressPercentage;
            //Application.DoEvents();
            lbl_percent.Text = e.ProgressPercentage + " %";
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message = contest_except_message + location_except_message + divshift_except_message;
            //foreach(var item in contest_dict)
            //    if (item.Value == -1)
            //    {
            //        quizDB = new Quiz.Quiz();
            //        Quiz.CONTEST except_cont = quizDB.CONTESTS.Where(p => p.ContestID == item.Key).FirstOrDefault();
            //        message += "\nBỏ qua kỳ thi: " + except_cont.ContestName;
            //    }
            if (system_error_message == "")
            {
                MessageBox.Show("Đã hoàn thành chuyển dữ liệu thi về trung tâm\n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(system_error_message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        #region Level 1 Transfer
        public void Contest_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Contest...");
            bw.ReportProgress(0); int i = 0;
            try
            {                                
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.CONTEST> lst_obj = quizDB.CONTESTS.ToList();
                List<QuizStorage.CONTEST> lst_storage_obj = quizstorageDB.CONTESTS.ToList();
                foreach (Quiz.CONTEST obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại contests_dict
                    QuizStorage.CONTEST old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.CONTEST))
                    {
                        QuizStorage.CONTEST new_obj = new QuizStorage.CONTEST(obj);
                        int new_objID = quizstorageDB.CONTESTS.Select(p => p.ContestID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ContestID = new_objID;
                        quizstorageDB.CONTESTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!contest_dict.ContainsKey(obj.ContestID))
                            contest_dict.Add(obj.ContestID, new_obj.ContestID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại contests_dict
                    else
                    {
                        DialogResult confirm = MessageBox.Show("Đã có dữ liệu kỳ thi \"" + old_obj.ContestName + "\" trên CSDL. Bạn có chắc chắn muốn tiếp tục chuyển dữ liệu không?\n\n"
                            + "Chỉ tiếp tục nếu như chắc chắn rằng kỳ thi được tổ chức ở nhiều điểm thi (server thi) khác nhau.\n"
                            + "Và dữ liệu kỳ thi chuẩn bị chuyển không giống (hoặc không được backup) từ các điểm thi (server thi) đã chuyển dữ liệu.\n\n"
                            + "Bạn phải chắc chắn điều trên, vì nếu không sẽ gây ra hiện tượng trùng lặp dữ liệu thi."
                            , "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm == DialogResult.Yes)
                        {
                            if (!contest_dict.ContainsKey(obj.ContestID))
                                contest_dict.Add(obj.ContestID, old_obj.ContestID);
                        }
                        else
                        {
                            //if (!contest_dict.ContainsKey(obj.ContestID))
                            //    contest_dict.Add(obj.ContestID, -1);                            
                            contest_except_message += "Bỏ qua kỳ thi: " + obj.ContestName + ".\n";
                        }                        
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Contest.");
        }

        public void Position_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Position...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.POSITION> lst_obj = quizDB.POSITIONS.ToList();
                List<QuizStorage.POSITION> lst_storage_obj = quizstorageDB.POSITIONS.ToList();
                foreach (Quiz.POSITION obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại position_dict
                    QuizStorage.POSITION old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.POSITION))
                    {
                        QuizStorage.POSITION new_obj = new QuizStorage.POSITION(obj);
                        int new_objID = quizstorageDB.POSITIONS.Select(p => p.PositionID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.PositionID = new_objID;
                        quizstorageDB.POSITIONS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!position_dict.ContainsKey(obj.PositionID))
                            position_dict.Add(obj.PositionID, new_obj.PositionID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại position_dict
                    else
                    {
                        if (!position_dict.ContainsKey(obj.PositionID))
                            position_dict.Add(obj.PositionID, old_obj.PositionID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Position.");
        }

        public void Staff_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Staff...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.STAFF> lst_obj = quizDB.STAFFS.ToList();
                List<QuizStorage.STAFF> lst_storage_obj = quizstorageDB.STAFFS.ToList();
                foreach (Quiz.STAFF obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại staffs_dict
                    QuizStorage.STAFF old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.STAFF))
                    {
                        QuizStorage.STAFF new_obj = new QuizStorage.STAFF(obj);
                        int new_objID = quizstorageDB.STAFFS.Select(p => p.StaffID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.StaffID = new_objID;
                        quizstorageDB.STAFFS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!staffs_dict.ContainsKey(obj.StaffID))
                            staffs_dict.Add(obj.StaffID, new_obj.StaffID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại staffs_dict
                    else
                    {
                        if (!staffs_dict.ContainsKey(obj.StaffID))
                            staffs_dict.Add(obj.StaffID, old_obj.StaffID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Staff.");
        }

        public void ExaminationCounCil_Positions_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu ExaminationCounCil_Positions...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.EXAMINATIONCOUNCIL_POSITIONS> lst_obj = quizDB.EXAMINATIONCOUNCIL_POSITIONS.ToList();
                List<QuizStorage.EXAMINATIONCOUNCIL_POSITIONS> lst_storage_obj = quizstorageDB.EXAMINATIONCOUNCIL_POSITIONS.ToList();
                foreach (Quiz.EXAMINATIONCOUNCIL_POSITIONS obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại examinationcouncil_positions_dict
                    QuizStorage.EXAMINATIONCOUNCIL_POSITIONS old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.EXAMINATIONCOUNCIL_POSITIONS))
                    {
                        QuizStorage.EXAMINATIONCOUNCIL_POSITIONS new_obj = new QuizStorage.EXAMINATIONCOUNCIL_POSITIONS(obj);
                        int new_objID = quizstorageDB.EXAMINATIONCOUNCIL_POSITIONS.Select(p => p.ExaminationCouncil_PositionID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ExaminationCouncil_PositionID = new_objID;
                        quizstorageDB.EXAMINATIONCOUNCIL_POSITIONS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!examinationcouncil_positions_dict.ContainsKey(obj.ExaminationCouncil_PositionID))
                            examinationcouncil_positions_dict.Add(obj.ExaminationCouncil_PositionID, new_obj.ExaminationCouncil_PositionID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại examinationcouncil_positions_dict
                    else
                    {
                        if (!examinationcouncil_positions_dict.ContainsKey(obj.ExaminationCouncil_PositionID))
                            examinationcouncil_positions_dict.Add(obj.ExaminationCouncil_PositionID, old_obj.ExaminationCouncil_PositionID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu ExaminationCounCil_Positions.");
        }

        public void Subject_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Subject...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SUBJECT> lst_obj = quizDB.SUBJECTS.ToList();
                List<QuizStorage.SUBJECT> lst_storage_obj = quizstorageDB.SUBJECTS.ToList();
                foreach (Quiz.SUBJECT obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại subject_dict
                    QuizStorage.SUBJECT old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.SUBJECT))
                    {
                        QuizStorage.SUBJECT new_obj = new QuizStorage.SUBJECT(obj);
                        int new_objID = quizstorageDB.SUBJECTS.Select(p => p.SubjectID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.SubjectID = new_objID;
                        quizstorageDB.SUBJECTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!subject_dict.ContainsKey(obj.SubjectID))
                            subject_dict.Add(obj.SubjectID, new_obj.SubjectID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại subject_dict
                    else
                    {
                        if (!subject_dict.ContainsKey(obj.SubjectID))
                            subject_dict.Add(obj.SubjectID, old_obj.SubjectID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Subject.");
        }

        public void Contestant_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Contestant...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.CONTESTANT> lst_obj = quizDB.CONTESTANTS.ToList();
                List<QuizStorage.CONTESTANT> lst_storage_obj = quizstorageDB.CONTESTANTS.ToList();
                int new_objID = quizstorageDB.CONTESTANTS.Select(p => p.ContestantID).OrderByDescending(p => p).FirstOrDefault();
                foreach (Quiz.CONTESTANT obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại contestant_dict
                    QuizStorage.CONTESTANT old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.CONTESTANT))
                    {
                        QuizStorage.CONTESTANT new_obj = new QuizStorage.CONTESTANT(obj);                        
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ContestantID = new_objID;
                        quizstorageDB.CONTESTANTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!contestant_dict.ContainsKey(obj.ContestantID))
                            contestant_dict.Add(obj.ContestantID, new_obj.ContestantID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại contestant_dict
                    else
                    {
                        if (!contestant_dict.ContainsKey(obj.ContestantID))
                            contestant_dict.Add(obj.ContestantID, old_obj.ContestantID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Contestant.");
        }

        public void Violation_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Violation...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.VIOLATION> lst_obj = quizDB.VIOLATIONS.ToList();
                List<QuizStorage.VIOLATION> lst_storage_obj = quizstorageDB.VIOLATIONS.ToList();
                foreach (Quiz.VIOLATION obj in lst_obj)
                {
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại violation_dict
                    QuizStorage.VIOLATION old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.VIOLATION))
                    {
                        QuizStorage.VIOLATION new_obj = new QuizStorage.VIOLATION(obj);
                        int new_objID = quizstorageDB.VIOLATIONS.Select(p => p.ViolationID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ViolationID = new_objID;
                        quizstorageDB.VIOLATIONS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!violation_dict.ContainsKey(obj.ViolationID))
                            violation_dict.Add(obj.ViolationID, new_obj.ViolationID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại violation_dict
                    else
                    {
                        if (!violation_dict.ContainsKey(obj.ViolationID))
                            violation_dict.Add(obj.ViolationID, old_obj.ViolationID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Violation.");
        }

        // Chuyển về MTAQuizStorage với ID giống với ID trên MTAQuiz (mục đích đối chiếu với ExonSystem khi cần)
        public void Question_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Question...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.QUESTION> lst_obj = quizDB.QUESTIONS.ToList();
                List<QuizStorage.QUESTION> lst_storage_obj = quizstorageDB.QUESTIONS.ToList();
                foreach (Quiz.QUESTION obj in lst_obj)
                {
                    // Nếu nội dung kỳ thi đã trùng, thì không cần thêm câu hỏi của kỳ thi đó nữa
                    if (lst_except_question.Contains(obj.QuestionID))
                        continue;
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại question_dict
                    QuizStorage.QUESTION old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.QUESTION))
                    {
                        QuizStorage.QUESTION new_obj = new QuizStorage.QUESTION(obj);
                        //int new_objID = quizstorageDB.QUESTIONS.Select(p => p.QuestionID).OrderByDescending(p => p).FirstOrDefault();
                        //if (new_objID == default(int))
                        //    new_objID = 1;
                        //else new_objID += 1;
                        new_obj.QuestionID = obj.QuestionID;
                        //quizstorageDB.QUESTIONS.Add(new_obj);
                        string query = "insert into QUESTIONS(QuestionID, QuestionContent, QuestionFormat, Level, IsQuiz, IsSingleChoice, IsParagraph, IsQuestionContent, NumberSubQuestion, NumberAnswer, Type, Audio, HeightToDisplay) values(@QuestionID, @QuestionContent, @QuestionFormat, @Level, @IsQuiz, @IsSingleChoice, @IsParagraph, @IsQuestionContent, @NumberSubQuestion, @NumberAnswer, @Type, @Audio, @HeightToDisplay)";
                        List<SqlParameter> para = new List<SqlParameter>();
                        para.Add(new SqlParameter("@QuestionID", GetDataValue(new_obj.QuestionID)));
                        para.Add(new SqlParameter("@QuestionContent", GetDataValue(new_obj.QuestionContent)));
                        para.Add(new SqlParameter("@QuestionFormat", GetDataValue(new_obj.QuestionFormat)));
                        para.Add(new SqlParameter("@Level", GetDataValue(new_obj.Level)));
                        para.Add(new SqlParameter("@IsQuiz", GetDataValue(new_obj.IsQuiz)));
                        para.Add(new SqlParameter("@IsSingleChoice", GetDataValue(new_obj.IsSingleChoice)));
                        para.Add(new SqlParameter("@IsParagraph", GetDataValue(new_obj.IsParagraph)));
                        para.Add(new SqlParameter("@IsQuestionContent", GetDataValue(new_obj.IsQuestionContent)));
                        para.Add(new SqlParameter("@NumberSubQuestion", GetDataValue(new_obj.NumberSubQuestion)));
                        para.Add(new SqlParameter("@NumberAnswer", GetDataValue(new_obj.NumberAnswer)));
                        para.Add(new SqlParameter("@Type", GetDataValue(new_obj.Type)));
                        // Do Audio có kiểu đặc biệt byte[], nên phải add đặc biệt
                        SqlParameter audio_para = new SqlParameter("@Audio", SqlDbType.VarBinary);
                        audio_para.Value = GetDataValue(new_obj.Audio);
                        para.Add(audio_para);
                        para.Add(new SqlParameter("@HeightToDisplay", GetDataValue(new_obj.HeightToDisplay)));
                        quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!question_dict.ContainsKey(obj.QuestionID))
                            question_dict.Add(obj.QuestionID, new_obj.QuestionID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại question_dict
                    else
                    {
                        if (!question_dict.ContainsKey(obj.QuestionID))
                            question_dict.Add(obj.QuestionID, old_obj.QuestionID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Question.");
        }
        #endregion Level 1 Transfer             

        #region Level 2 Transfer
        public void Staffs_Positions_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Staffs_Positions...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.STAFFS_POSITIONS> lst_obj = quizDB.STAFFS_POSITIONS.ToList();
                List<QuizStorage.STAFFS_POSITIONS> lst_storage_obj = quizstorageDB.STAFFS_POSITIONS.ToList();
                foreach (Quiz.STAFFS_POSITIONS obj in lst_obj)
                {
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.StaffID = staffs_dict[(int)obj.StaffID];
                    obj.PositionID = position_dict[(int)obj.PositionID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại staffs_positions_dict                    
                    QuizStorage.STAFFS_POSITIONS old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.STAFFS_POSITIONS))
                    {
                        QuizStorage.STAFFS_POSITIONS new_obj = new QuizStorage.STAFFS_POSITIONS(obj);                        
                        quizstorageDB.STAFFS_POSITIONS.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!staffs_positions_dict.ContainsKey(obj.StaffPositionID))
                            staffs_positions_dict.Add(obj.StaffPositionID, new_obj.StaffPositionID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại staffs_positions_dict
                    else
                    {
                        if (!staffs_positions_dict.ContainsKey(obj.StaffPositionID))
                            staffs_positions_dict.Add(obj.StaffPositionID, old_obj.StaffPositionID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Staffs_Positions.");
        }

        public void Shift_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Shift...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SHIFT> lst_obj = quizDB.SHIFTS.ToList();
                List<QuizStorage.SHIFT> lst_storage_obj = quizstorageDB.SHIFTS.ToList();
                foreach (Quiz.SHIFT obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contest_dict.ContainsKey((int)obj.ContestID) || contest_dict[(int)obj.ContestID] == -1)
                        continue;
                    // Nếu ca thi liên quan đến địa điểm bị bỏ qua, thì không chuyển dữ liệu liên quan đến ca thi đó
                    if (lst_except_shift.Contains(obj.ShiftID))
                        continue;
                    // Nếu ca thi đã hoàn thành thi thì mới tiến hành chuyển dữ liệu về 
                    bool isCompleted = false;
                    foreach (Quiz.DIVISION_SHIFTS item in obj.DIVISION_SHIFTS)
                    {
                        if (item.Status == 8)
                            isCompleted = true;
                    }
                    if (isCompleted == false)
                    {
                        lst_incompleted_shift.Add(obj.ShiftID);
                        continue;
                    }
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.ContestID != null)
                        obj.ContestID = contest_dict[(int)obj.ContestID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại shift_dict                    
                    QuizStorage.SHIFT old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.SHIFT))
                    {
                        QuizStorage.SHIFT new_obj = new QuizStorage.SHIFT(obj);
                        int new_objID = quizstorageDB.SHIFTS.Select(p => p.ShiftID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ShiftID = new_objID;
                        quizstorageDB.SHIFTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!shift_dict.ContainsKey(obj.ShiftID))
                            shift_dict.Add(obj.ShiftID, new_obj.ShiftID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại shift_dict
                    else
                    {
                        if (!shift_dict.ContainsKey(obj.ShiftID))
                            shift_dict.Add(obj.ShiftID, old_obj.ShiftID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Shift.");
        }

        public void Location_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Location...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.LOCATION> lst_obj = quizDB.LOCATIONS.ToList();
                List<QuizStorage.LOCATION> lst_storage_obj = quizstorageDB.LOCATIONS.ToList();
                foreach (Quiz.LOCATION obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contest_dict.ContainsKey((int)obj.ContestID) || contest_dict[(int)obj.ContestID] == -1)
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.ContestID = contest_dict[(int)obj.ContestID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại location_dict                    
                    QuizStorage.LOCATION old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.LOCATION))
                    {
                        QuizStorage.LOCATION new_obj = new QuizStorage.LOCATION(obj);
                        int new_objID = quizstorageDB.LOCATIONS.Select(p => p.LocationID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.LocationID = new_objID;
                        quizstorageDB.LOCATIONS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!location_dict.ContainsKey(obj.LocationID))
                            location_dict.Add(obj.LocationID, new_obj.LocationID);
                    }
                    // Nếu đã trùng (đã chuyển) thì bỏ qua địa điểm thi đó
                    else
                    {
                        //if (!location_dict.ContainsKey(obj.LocationID))
                        //    location_dict.Add(obj.LocationID, -1);
                        string contestName = quizstorageDB.CONTESTS.Where(p => p.ContestID == old_obj.ContestID).Select(p => p.ContestName).FirstOrDefault();
                        DialogResult confirm = MessageBox.Show("Đã có dữ liệu điểm thi: \"" + old_obj.LocationName + "\" của kỳ thi: \"" + contestName + "\" trên CSDL trung tâm. Bạn có chắc chắn muốn tiếp tục chuyển dữ liệu không?\n\n"
                            + "Chỉ tiếp tục nếu như chắc chắn rằng cần bổ sung dữ liệu cho điểm thi.\n"
                            + "Và dữ liệu của điểm thi chuẩn bị chuyển không giống với (hoặc không được backup từ) dữ liệu điểm thi (server thi) đã chuyển.\n\n"
                            + "Bạn phải chắc chắn điều trên, vì nếu không có thể sẽ gây ra hiện tượng trùng lặp dữ liệu thi."
                            , "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm == DialogResult.Yes)
                        {
                            if (!location_dict.ContainsKey(obj.LocationID))
                                location_dict.Add(obj.LocationID, old_obj.LocationID);
                        }
                        // Nếu điểm thi không được phép chuyển, thì tất cả ca thi liên quan cũng sẽ không được chuyển về
                        // Mục đích: Để tránh dư thừa dữ liệu
                        // Giải thích: vì mỗi csdl MTAQuiz chỉ chứa duy nhất 1 điểm thi và những ca thi liên quan đến nó
                        //             nên khi ko chuyển dữ liệu điểm thi, mà không liệt kê DS các Shift liên quan,
                        //             thì sau này khi chuyển bảng SHIFT sẽ bị thừa dữ liệu
                        else
                        {
                            location_except_message += "Dữ liệu địa điểm thi: " + old_obj.LocationName + " của kỳ thi: " + contestName + " không được chuyển về trung tâm, vì đã được chuyển rồi.\n";
                            List<int> roomtests = quizDB.ROOMTESTS.Where(p => p.LocationID == obj.LocationID).Select(p => p.RoomTestID).ToList();
                            List<int> shifts = quizDB.DIVISION_SHIFTS.Where(p => roomtests.Contains(p.RoomTestID)).Select(p => p.ShiftID).Distinct().ToList();
                            lst_except_shift.AddRange(shifts);
                        }
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Location.");
        }

        public void Schedule_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Schedule...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SCHEDULE> lst_obj = quizDB.SCHEDULES.ToList();
                List<QuizStorage.SCHEDULE> lst_storage_obj = quizstorageDB.SCHEDULES.ToList();
                foreach (Quiz.SCHEDULE obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contest_dict.ContainsKey((int)obj.ContestID) || contest_dict[(int)obj.ContestID] == -1)
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.SubjectID = subject_dict[(int)obj.SubjectID];
                    if (obj.ContestID != null)
                        obj.ContestID = contest_dict[(int)obj.ContestID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại schedule_dict                    
                    QuizStorage.SCHEDULE old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.SCHEDULE))
                    {
                        QuizStorage.SCHEDULE new_obj = new QuizStorage.SCHEDULE(obj);
                        int new_objID = quizstorageDB.SCHEDULES.Select(p => p.ScheduleID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ScheduleID = new_objID;
                        quizstorageDB.SCHEDULES.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!schedule_dict.ContainsKey(obj.ScheduleID))
                            schedule_dict.Add(obj.ScheduleID, new_obj.ScheduleID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại schedule_dict
                    else
                    {
                        if (!schedule_dict.ContainsKey(obj.ScheduleID))
                            schedule_dict.Add(obj.ScheduleID, old_obj.ScheduleID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Schedule.");
        }

        public void Fingerprint_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Fingerprint...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.FINGERPRINT> lst_obj = quizDB.FINGERPRINTS.ToList();
                List<QuizStorage.FINGERPRINT> lst_storage_obj = quizstorageDB.FINGERPRINTS.ToList();
                foreach (Quiz.FINGERPRINT obj in lst_obj)
                {
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.ContestantID = contestant_dict[(int)obj.ContestantID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại fingerprint_dict                    
                    QuizStorage.FINGERPRINT old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.FINGERPRINT))
                    {
                        QuizStorage.FINGERPRINT new_obj = new QuizStorage.FINGERPRINT(obj);
                        int new_objID = quizstorageDB.FINGERPRINTS.Select(p => p.FingerprintID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.FingerprintID = new_objID;
                        quizstorageDB.FINGERPRINTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!fingerprint_dict.ContainsKey(obj.FingerprintID))
                            fingerprint_dict.Add(obj.FingerprintID, new_obj.FingerprintID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại fingerprint_dict
                    else
                    {
                        if (!fingerprint_dict.ContainsKey(obj.FingerprintID))
                            fingerprint_dict.Add(obj.FingerprintID, old_obj.FingerprintID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Fingerprint.");
        }

        // Chuyển về MTAQuizStorage với ID giống với ID trên MTAQuiz (mục đích đối chiếu với ExonSystem khi cần)
        public void Subquestion_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Subquestion...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SUBQUESTION> lst_obj = quizDB.SUBQUESTIONS.ToList();
                List<QuizStorage.SUBQUESTION> lst_storage_obj = quizstorageDB.SUBQUESTIONS.ToList();
                foreach (Quiz.SUBQUESTION obj in lst_obj)
                {
                    if (lst_except_question.Contains(obj.QuestionID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.QuestionID = question_dict[(int)obj.QuestionID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại subquestion_dict
                    QuizStorage.SUBQUESTION old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.SUBQUESTION))
                    {
                        QuizStorage.SUBQUESTION new_obj = new QuizStorage.SUBQUESTION(obj);
                        //int new_objID = quizstorageDB.SUBQUESTIONS.Select(p => p.SubQuestionID).OrderByDescending(p => p).FirstOrDefault();
                        //if (new_objID == default(int))
                        //    new_objID = 1;
                        //else new_objID += 1;
                        new_obj.SubQuestionID = obj.SubQuestionID;
                        //quizstorageDB.SUBQUESTIONS.Add(new_obj);
                        string query = "insert into SUBQUESTIONS(SubQuestionID, SubQuestionContent, Score, QuestionID, HeightToDisplay) values(@SubQuestionID, @SubQuestionContent, @Score, @QuestionID, @HeightToDisplay)";
                        List<SqlParameter> para = new List<SqlParameter>();
                        para.Add(new SqlParameter("@SubQuestionID", GetDataValue(new_obj.SubQuestionID)));
                        para.Add(new SqlParameter("@SubQuestionContent", GetDataValue(new_obj.SubQuestionContent)));
                        para.Add(new SqlParameter("@Score", GetDataValue(new_obj.Score)));
                        para.Add(new SqlParameter("@QuestionID", GetDataValue(new_obj.QuestionID)));
                        para.Add(new SqlParameter("@HeightToDisplay", GetDataValue(new_obj.HeightToDisplay)));
                        quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                        
                        //lst_storage_obj.Add(new_obj);
                        if (!subquestion_dict.ContainsKey(obj.SubQuestionID))
                            subquestion_dict.Add(obj.SubQuestionID, new_obj.SubQuestionID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại subquestion_dict
                    else
                    {
                        if (!subquestion_dict.ContainsKey(obj.SubQuestionID))
                            subquestion_dict.Add(obj.SubQuestionID, old_obj.SubQuestionID);
                    }
                   
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Subquestion.");
        }
        #endregion Level 2 Transfer

        #region Level 3 Transfer
        public void ExaminationCoundcil_Staffs_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu ExaminationCoundcil_Staffs...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.EXAMINATIONCOUNCIL_STAFFS> lst_obj = quizDB.EXAMINATIONCOUNCIL_STAFFS.ToList();
                List<QuizStorage.EXAMINATIONCOUNCIL_STAFFS> lst_storage_obj = quizstorageDB.EXAMINATIONCOUNCIL_STAFFS.ToList();
                foreach (Quiz.EXAMINATIONCOUNCIL_STAFFS obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contest_dict.ContainsKey((int)obj.ContestID) || contest_dict[(int)obj.ContestID] == -1 || !location_dict.ContainsKey((int)obj.LocationID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.StaffID != null)
                        obj.StaffID = staffs_dict[(int)obj.StaffID];
                    if (obj.ExaminationCouncil_PositionID != null)
                        obj.ExaminationCouncil_PositionID = examinationcouncil_positions_dict[(int)obj.ExaminationCouncil_PositionID];
                    if (obj.ContestID != null)
                        obj.ContestID = contest_dict[(int)obj.ContestID];
                    if (obj.LocationID != null)
                        obj.LocationID = location_dict[(int)obj.LocationID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại examinationcouncil_staffs_dict                    
                    QuizStorage.EXAMINATIONCOUNCIL_STAFFS old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.EXAMINATIONCOUNCIL_STAFFS))
                    {
                        QuizStorage.EXAMINATIONCOUNCIL_STAFFS new_obj = new QuizStorage.EXAMINATIONCOUNCIL_STAFFS(obj);
                        int new_objID = quizstorageDB.EXAMINATIONCOUNCIL_STAFFS.Select(p => p.ExaminationCouncil_StaffID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.ExaminationCouncil_StaffID = new_objID;
                        quizstorageDB.EXAMINATIONCOUNCIL_STAFFS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!examinationcouncil_staffs_dict.ContainsKey(obj.ExaminationCouncil_StaffID))
                            examinationcouncil_staffs_dict.Add(obj.ExaminationCouncil_StaffID, new_obj.ExaminationCouncil_StaffID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại examinationcouncil_staffs_dict
                    else
                    {
                        if (!examinationcouncil_staffs_dict.ContainsKey(obj.ExaminationCouncil_StaffID))
                            examinationcouncil_staffs_dict.Add(obj.ExaminationCouncil_StaffID, old_obj.ExaminationCouncil_StaffID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu ExaminationCoundcil_Staffs.");
        }

        public void Part_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Part...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.PART> lst_obj = quizDB.PARTS.ToList();
                List<QuizStorage.PART> lst_storage_obj = quizstorageDB.PARTS.ToList();
                foreach (Quiz.PART obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!schedule_dict.ContainsKey((int)obj.ScheduleID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.CreateStaffID != null)
                        obj.CreateStaffID = staffs_dict[(int)obj.CreateStaffID];
                    if (obj.ScheduleID != null)
                        obj.ScheduleID = schedule_dict[(int)obj.ScheduleID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại part_dict                    
                    QuizStorage.PART old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.PART))
                    {
                        QuizStorage.PART new_obj = new QuizStorage.PART(obj);
                        //int new_objID = quizstorageDB.PARTS.Select(p => p.PartID).OrderByDescending(p => p).FirstOrDefault();
                        //if (new_objID == default(int))
                        //    new_objID = 1;
                        //else new_objID += 1;
                        //new_obj.PartID = new_objID;
                        quizstorageDB.PARTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!part_dict.ContainsKey(obj.PartID))
                            part_dict.Add(obj.PartID, new_obj.PartID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại part_dict
                    else
                    {
                        if (!part_dict.ContainsKey(obj.PartID))
                            part_dict.Add(obj.PartID, old_obj.PartID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Part.");
        }

        public void ShiftsPause_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu ShiftsPause...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SHIFTSPAUSE> lst_obj = quizDB.SHIFTSPAUSEs.ToList();
                List<QuizStorage.SHIFTSPAUSE> lst_storage_obj = quizstorageDB.SHIFTSPAUSEs.ToList();
                foreach (Quiz.SHIFTSPAUSE obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!shift_dict.ContainsKey((int)obj.ShiftID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.ShiftID != null)
                        obj.ShiftID = shift_dict[(int)obj.ShiftID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại shiftspause_dict                    
                    QuizStorage.SHIFTSPAUSE old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.SHIFTSPAUSE))
                    {
                        QuizStorage.SHIFTSPAUSE new_obj = new QuizStorage.SHIFTSPAUSE(obj);                        
                        quizstorageDB.SHIFTSPAUSEs.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!shiftspause_dict.ContainsKey(obj.ShiftPauseID))
                            shiftspause_dict.Add(obj.ShiftPauseID, new_obj.ShiftPauseID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại shiftspause_dict
                    else
                    {
                        if (!shiftspause_dict.ContainsKey(obj.ShiftPauseID))
                            shiftspause_dict.Add(obj.ShiftPauseID, old_obj.ShiftPauseID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu ShiftsPause.");
        }

        public void RoomTest_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu RoomTest...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ROOMTEST> lst_obj = quizDB.ROOMTESTS.ToList();
                List<QuizStorage.ROOMTEST> lst_storage_obj = quizstorageDB.ROOMTESTS.ToList();
                foreach (Quiz.ROOMTEST obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!location_dict.ContainsKey((int)obj.LocationID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.LocationID = location_dict[(int)obj.LocationID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại roomtest_dict                    
                    QuizStorage.ROOMTEST old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.ROOMTEST))
                    {
                        QuizStorage.ROOMTEST new_obj = new QuizStorage.ROOMTEST(obj);
                        int new_objID = quizstorageDB.ROOMTESTS.Select(p => p.RoomTestID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.RoomTestID = new_objID;
                        quizstorageDB.ROOMTESTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!roomtest_dict.ContainsKey(obj.RoomTestID))
                            roomtest_dict.Add(obj.RoomTestID, new_obj.RoomTestID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại roomtest_dict
                    else
                    {
                        if (!roomtest_dict.ContainsKey(obj.RoomTestID))
                            roomtest_dict.Add(obj.RoomTestID, old_obj.RoomTestID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu RoomTest.");
        }

        // Chuyển về MTAQuizStorage với ID giống với ID trên MTAQuiz (mục đích đối chiếu với ExonSystem khi cần)
        public void Answer_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Answer...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ANSWER> lst_obj = quizDB.ANSWERS.ToList();
                List<QuizStorage.ANSWER> lst_storage_obj = quizstorageDB.ANSWERS.ToList();
                foreach (Quiz.ANSWER obj in lst_obj)
                {
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (!subquestion_dict.ContainsKey(obj.SubQuestionID))
                        continue;
                    obj.SubQuestionID = subquestion_dict[(int)obj.SubQuestionID];            
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại answer_dict                    
                    QuizStorage.ANSWER old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.ANSWER))
                    {
                        QuizStorage.ANSWER new_obj = new QuizStorage.ANSWER(obj);
                        //int new_objID = quizstorageDB.ANSWERS.Select(p => p.AnswerID).OrderByDescending(p => p).FirstOrDefault();
                        //if (new_objID == default(int))
                        //    new_objID = 1;
                        //else new_objID += 1;
                        new_obj.AnswerID = obj.AnswerID;
                        //quizstorageDB.ANSWERS.Add(new_obj);
                        string query = "insert into ANSWERS(AnswerID, AnswerContent, IsCorrect, SubQuestionID, HeightToDisplay) values(@AnswerID, @AnswerContent, @IsCorrect, @SubQuestionID, @HeightToDisplay)";
                        List<SqlParameter> para = new List<SqlParameter>();
                        para.Add(new SqlParameter("@AnswerID", GetDataValue(new_obj.AnswerID)));
                        para.Add(new SqlParameter("@AnswerContent", GetDataValue(new_obj.AnswerContent)));
                        para.Add(new SqlParameter("@IsCorrect", GetDataValue(new_obj.IsCorrect)));
                        para.Add(new SqlParameter("@SubQuestionID", GetDataValue(new_obj.SubQuestionID)));
                        para.Add(new SqlParameter("@HeightToDisplay", GetDataValue(new_obj.HeightToDisplay)));
                        quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                        
                        //lst_storage_obj.Add(new_obj);
                        if (!answer_dict.ContainsKey(obj.AnswerID))
                            answer_dict.Add(obj.AnswerID, new_obj.AnswerID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại answer_dict
                    else
                    {
                        if (!answer_dict.ContainsKey(obj.AnswerID))
                            answer_dict.Add(obj.AnswerID, old_obj.AnswerID);
                    }
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Answer.");
        }
        #endregion Level 3 Transfer

        #region Level 4 Transfer
        public void Division_Shifts_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Division_Shifts...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.DIVISION_SHIFTS> lst_obj = quizDB.DIVISION_SHIFTS.ToList();
                List<QuizStorage.DIVISION_SHIFTS> lst_storage_obj = quizstorageDB.DIVISION_SHIFTS.ToList();
                foreach (Quiz.DIVISION_SHIFTS obj in lst_obj)
                {
                    // Chỉ chuyển những ca thi đã thi xong.
                    if (lst_incompleted_shift.Contains(obj.ShiftID))
                    {
                        divshift_except_message += "Ca thi: " + obj.SHIFT.ShiftName + ", " + obj.ROOMTEST.LOCATION.LocationName + ", " + obj.ROOMTEST.RoomTestName + " bị bỏ qua do chưa hoàn thành thi.\n";
                        continue;
                    }
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!shift_dict.ContainsKey((int)obj.ShiftID) || !roomtest_dict.ContainsKey(obj.RoomTestID))
                        continue;
                    // Chỉ chuyển những ca thi đã thi xong.
                    if (obj.Status != 8)
                    {
                        divshift_except_message += "Ca thi: " + obj.SHIFT.ShiftName + ", " + obj.ROOMTEST.LOCATION.LocationName + ", " + obj.ROOMTEST.RoomTestName + " bị bỏ qua do chưa hoàn thành thi.\n";
                        continue;
                    }
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.ShiftID = shift_dict[(int)obj.ShiftID];
                    obj.RoomTestID = roomtest_dict[(int)obj.RoomTestID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại division_shifts_dict                    
                    QuizStorage.DIVISION_SHIFTS old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.DIVISION_SHIFTS))
                    {
                        QuizStorage.DIVISION_SHIFTS new_obj = new QuizStorage.DIVISION_SHIFTS(obj);
                        int new_objID = quizstorageDB.DIVISION_SHIFTS.Select(p => p.DivisionShiftID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.DivisionShiftID = new_objID;
                        quizstorageDB.DIVISION_SHIFTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!division_shifts_dict.ContainsKey(obj.DivisionShiftID))
                            division_shifts_dict.Add(obj.DivisionShiftID, new_obj.DivisionShiftID);
                    }
                    // Nếu đã trùng thì ko làm gì tiếp cả, tất cả dữ liệu liên quan đến ca thi này sẽ bị bỏ qua.
                    // Mục đích: tránh trùng lặp dữ liệu
                    else
                    {
                        //if (!division_shifts_dict.ContainsKey(obj.DivisionShiftID))
                        //    division_shifts_dict.Add(obj.DivisionShiftID, old_obj.DivisionShiftID);
                        divshift_except_message += "Ca thi: " + obj.SHIFT.ShiftName + ", " + obj.ROOMTEST.LOCATION.LocationName + ", " + obj.ROOMTEST.RoomTestName + " bị bỏ qua do dữ liệu đã được chuyển về rồi.\n";
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Division_Shifts.");
        }

        public void RoomDiagram_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu RoomDiagram...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ROOMDIAGRAM> lst_obj = quizDB.ROOMDIAGRAMS.ToList();
                List<QuizStorage.ROOMDIAGRAM> lst_storage_obj = quizstorageDB.ROOMDIAGRAMS.ToList();
                foreach (Quiz.ROOMDIAGRAM obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!roomtest_dict.ContainsKey((int)obj.RoomTestID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.RoomTestID != null)
                        obj.RoomTestID = roomtest_dict[(int)obj.RoomTestID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại roomdiagram_dict                    
                    QuizStorage.ROOMDIAGRAM old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.ROOMDIAGRAM))
                    {
                        QuizStorage.ROOMDIAGRAM new_obj = new QuizStorage.ROOMDIAGRAM(obj);                        
                        quizstorageDB.ROOMDIAGRAMS.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!roomdiagram_dict.ContainsKey(obj.RoomDiagramID))
                            roomdiagram_dict.Add(obj.RoomDiagramID, new_obj.RoomDiagramID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại roomdiagram_dict
                    else
                    {
                        if (!roomdiagram_dict.ContainsKey(obj.RoomDiagramID))
                            roomdiagram_dict.Add(obj.RoomDiagramID, old_obj.RoomDiagramID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu RoomDiagram.");
        }
        #endregion Level 4 Transfer

        #region Level 5 Transfer
        public void DivisionShift_Supervisor_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu DivisionShift_Supervisor...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.DIVISIONSHIFT_SUPERVISOR> lst_obj = quizDB.DIVISIONSHIFT_SUPERVISOR.ToList();
                List<QuizStorage.DIVISIONSHIFT_SUPERVISOR> lst_storage_obj = quizstorageDB.DIVISIONSHIFT_SUPERVISOR.ToList();
                foreach (Quiz.DIVISIONSHIFT_SUPERVISOR obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!division_shifts_dict.ContainsKey((int)obj.DivisionShiftID) || !examinationcouncil_staffs_dict.ContainsKey((int)obj.SupervisorID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.SupervisorID != null)
                        obj.SupervisorID = examinationcouncil_staffs_dict[(int)obj.SupervisorID];
                    if (obj.DivisionShiftID != null)
                        obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại divisionshift_supervisor_dict                    
                    QuizStorage.DIVISIONSHIFT_SUPERVISOR old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.DIVISIONSHIFT_SUPERVISOR))
                    {
                        QuizStorage.DIVISIONSHIFT_SUPERVISOR new_obj = new QuizStorage.DIVISIONSHIFT_SUPERVISOR(obj);                        
                        quizstorageDB.DIVISIONSHIFT_SUPERVISOR.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!divisionshift_supervisor_dict.ContainsKey(obj.DivisionShift_SupervisorID))
                            divisionshift_supervisor_dict.Add(obj.DivisionShift_SupervisorID, new_obj.DivisionShift_SupervisorID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại divisionshift_supervisor_dict
                    else
                    {
                        if (!divisionshift_supervisor_dict.ContainsKey(obj.DivisionShift_SupervisorID))
                            divisionshift_supervisor_dict.Add(obj.DivisionShift_SupervisorID, old_obj.DivisionShift_SupervisorID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu DivisionShift_Supervisor.");
        }

        public void DivisionShift_Pause_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu DivisionShift_Pause...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.DIVSIONSHIFT_PAUSE> lst_obj = quizDB.DIVSIONSHIFT_PAUSE.ToList();
                List<QuizStorage.DIVSIONSHIFT_PAUSE> lst_storage_obj = quizstorageDB.DIVSIONSHIFT_PAUSE.ToList();
                foreach (Quiz.DIVSIONSHIFT_PAUSE obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!division_shifts_dict.ContainsKey((int)obj.DivisionShiftID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.DivisionShiftID != null)
                        obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại divisionshift_pause_dict                    
                    QuizStorage.DIVSIONSHIFT_PAUSE old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.DIVSIONSHIFT_PAUSE))
                    {
                        QuizStorage.DIVSIONSHIFT_PAUSE new_obj = new QuizStorage.DIVSIONSHIFT_PAUSE(obj);                        
                        quizstorageDB.DIVSIONSHIFT_PAUSE.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!divisionshift_pause_dict.ContainsKey(obj.DivisionShiftPauseID))
                            divisionshift_pause_dict.Add(obj.DivisionShiftPauseID, new_obj.DivisionShiftPauseID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại divisionshift_pause_dict
                    else
                    {
                        if (!divisionshift_pause_dict.ContainsKey(obj.DivisionShiftPauseID))
                            divisionshift_pause_dict.Add(obj.DivisionShiftPauseID, old_obj.DivisionShiftPauseID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu DivisionShift_Pause.");
        }

        public void BagOfTest_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu BagOfTest...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.BAGOFTEST> lst_obj = quizDB.BAGOFTESTS.ToList();
                List<QuizStorage.BAGOFTEST> lst_storage_obj = quizstorageDB.BAGOFTESTS.ToList();
                foreach (Quiz.BAGOFTEST obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!division_shifts_dict.ContainsKey((int)obj.DivisionShiftID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại bagoftest_dict                    
                    QuizStorage.BAGOFTEST old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.BAGOFTEST))
                    {
                        QuizStorage.BAGOFTEST new_obj = new QuizStorage.BAGOFTEST(obj);
                        int new_objID = quizstorageDB.BAGOFTESTS.Select(p => p.BagOfTestID).OrderByDescending(p => p).FirstOrDefault();
                        if (new_objID == default(int))
                            new_objID = 1;
                        else new_objID += 1;
                        new_obj.BagOfTestID = new_objID;
                        quizstorageDB.BAGOFTESTS.Add(new_obj);
                        quizstorageDB.SaveChanges();
                        //lst_storage_obj.Add(new_obj);
                        if (!bagoftest_dict.ContainsKey(obj.BagOfTestID))
                            bagoftest_dict.Add(obj.BagOfTestID, new_obj.BagOfTestID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại bagoftest_dict
                    else
                    {
                        if (!bagoftest_dict.ContainsKey(obj.BagOfTestID))
                            bagoftest_dict.Add(obj.BagOfTestID, old_obj.BagOfTestID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu BagOfTest.");
        }
        
        // Không kiểm tra trùng nội dung
        public void Contestants_Shifts_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Contestants_Shifts...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.CONTESTANTS_SHIFTS> lst_obj = quizDB.CONTESTANTS_SHIFTS.ToList();
                List<QuizStorage.CONTESTANTS_SHIFTS> lst_storage_obj = quizstorageDB.CONTESTANTS_SHIFTS.ToList();
                int new_objID = quizstorageDB.CONTESTANTS_SHIFTS.Select(p => p.ContestantShiftID).OrderByDescending(p => p).FirstOrDefault();
                foreach (Quiz.CONTESTANTS_SHIFTS obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (obj.RoomDiagramID != null)
                        if (!roomdiagram_dict.ContainsKey((int)obj.RoomDiagramID))
                            continue;
                    if (!division_shifts_dict.ContainsKey((int)obj.DivisionShiftID) || !schedule_dict.ContainsKey(obj.ScheduleID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    obj.ScheduleID = schedule_dict[(int)obj.ScheduleID];
                    obj.ContestantID = contestant_dict[(int)obj.ContestantID];
                    if (obj.RoomDiagramID != null)
                        obj.RoomDiagramID = roomdiagram_dict[(int)obj.RoomDiagramID];
                    // Thêm mới, và cập nhật lại contestants_shifts_dict                    
                    QuizStorage.CONTESTANTS_SHIFTS new_obj = new QuizStorage.CONTESTANTS_SHIFTS(obj);                    
                    if (new_objID == default(int))
                        new_objID = 1;
                    else new_objID += 1;
                    new_obj.ContestantShiftID = new_objID;
                    //quizstorageDB.CONTESTANTS_SHIFTS.Add(new_obj);
                    string query = "insert into CONTESTANTS_SHIFTS values(@ContestantShiftID, @Status, @IsCheckFingerprint, @TimeCheck, @TimeStarted, @TimeWorked, @DivisionShiftID, @ScheduleID, @ContestantID, @RoomDiagramID)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@ContestantShiftID", GetDataValue(new_obj.ContestantShiftID)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    para.Add(new SqlParameter("@IsCheckFingerprint", GetDataValue(new_obj.IsCheckFingerprint)));
                    para.Add(new SqlParameter("@TimeCheck", GetDataValue(new_obj.TimeCheck)));
                    para.Add(new SqlParameter("@TimeStarted", GetDataValue(new_obj.TimeStarted)));
                    para.Add(new SqlParameter("@TimeWorked", GetDataValue(new_obj.TimeWorked)));
                    para.Add(new SqlParameter("@DivisionShiftID", GetDataValue(new_obj.DivisionShiftID)));
                    para.Add(new SqlParameter("@ScheduleID", GetDataValue(new_obj.ScheduleID)));
                    para.Add(new SqlParameter("@ContestantID", GetDataValue(new_obj.ContestantID)));
                    para.Add(new SqlParameter("@RoomDiagramID", GetDataValue(new_obj.RoomDiagramID)));                   
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    //lst_storage_obj.Add(new_obj);
                    if (!contestants_shifts_dict.ContainsKey(obj.ContestantShiftID))
                        contestants_shifts_dict.Add(obj.ContestantShiftID, new_obj.ContestantShiftID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Contestants_Shifts.");
        }
        #endregion Level 5 Transfer

        #region Level 6 Transfer
        // Không kiểm tra trùng nội dung
        public void TestNumber_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu TestNumber...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.TESTNUMBER> lst_obj = quizDB.TESTNUMBERs.ToList();
                List<QuizStorage.TESTNUMBER> lst_storage_obj = quizstorageDB.TESTNUMBERs.ToList();
                int new_objID = -1;
                foreach (Quiz.TESTNUMBER obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contestants_shifts_dict.ContainsKey((int)obj.ContestantShiftID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.ContestantShiftID != null)
                        obj.ContestantShiftID = contestants_shifts_dict[(int)obj.ContestantShiftID];
                    // Thêm mới, và cập nhật lại testnumber_dict                    
                    QuizStorage.TESTNUMBER new_obj = new QuizStorage.TESTNUMBER(obj);                    
                    //quizstorageDB.TESTNUMBERs.Add(new_obj);
                    string query = "insert into TESTNUMBER(ContestantShiftID, TestNumberIndex) values(@ContestantShiftID, @TestNumberIndex)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@ContestantShiftID", GetDataValue(new_obj.ContestantShiftID)));
                    para.Add(new SqlParameter("@TestNumberIndex", GetDataValue(new_obj.TestNumberIndex)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                    quizstorageDB.SaveChanges();
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.TESTNUMBERs.Select(p => p.IDTestNumber).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.IDTestNumber = new_objID;
                    if (!testnumber_dict.ContainsKey(obj.IDTestNumber))
                        testnumber_dict.Add(obj.IDTestNumber, new_obj.IDTestNumber);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu TestNumber.");
        }

        // Không kiểm tra trùng nội dung
        public void Test_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Test...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.TEST> lst_obj = quizDB.TESTS.ToList();
                List<QuizStorage.TEST> lst_storage_obj = quizstorageDB.TESTS.ToList();
                int new_objID = quizstorageDB.TESTS.Select(p => p.TestID).OrderByDescending(p => p).FirstOrDefault();
                foreach (Quiz.TEST obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!bagoftest_dict.ContainsKey((int)obj.BagOfTestID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.BagOfTestID = bagoftest_dict[(int)obj.BagOfTestID];
                    obj.SubjectID = subject_dict[(int)obj.SubjectID];
                    // Thêm mới, và cập nhật lại test_dict                    
                    QuizStorage.TEST new_obj = new QuizStorage.TEST(obj);                                
                    if (new_objID == default(int))
                        new_objID = 1;
                    else new_objID += 1;
                    new_obj.TestID = new_objID;
                    //quizstorageDB.TESTS.Add(new_obj);
                    string query = "insert into TESTS(TestID, Status, BagOfTestID, SubjectID) values(@TestID, @Status, @BagOfTestID, @SubjectID)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@TestID", GetDataValue(new_obj.TestID)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    para.Add(new SqlParameter("@BagOfTestID", GetDataValue(new_obj.BagOfTestID)));
                    para.Add(new SqlParameter("@SubjectID", GetDataValue(new_obj.SubjectID)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    //lst_storage_obj.Add(new_obj);
                    if (!test_dict.ContainsKey(obj.TestID))
                        test_dict.Add(obj.TestID, new_obj.TestID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Test.");
        }

        public void Violations_Contestants_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Violations_Contestants...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.VIOLATIONS_CONTESTANTS> lst_obj = quizDB.VIOLATIONS_CONTESTANTS.ToList();
                List<QuizStorage.VIOLATIONS_CONTESTANTS> lst_storage_obj = quizstorageDB.VIOLATIONS_CONTESTANTS.ToList();
                foreach (Quiz.VIOLATIONS_CONTESTANTS obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contestants_shifts_dict.ContainsKey((int)obj.ContestantShiftID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.ContestantShiftID = contestants_shifts_dict[(int)obj.ContestantShiftID];
                    obj.ViolationID = violation_dict[(int)obj.ViolationID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại violations_contestants_dict                    
                    QuizStorage.VIOLATIONS_CONTESTANTS old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.VIOLATIONS_CONTESTANTS))
                    {
                        QuizStorage.VIOLATIONS_CONTESTANTS new_obj = new QuizStorage.VIOLATIONS_CONTESTANTS(obj);                        
                        quizstorageDB.VIOLATIONS_CONTESTANTS.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!violations_contestants_dict.ContainsKey(obj.ViolationDetailID))
                            violations_contestants_dict.Add(obj.ViolationDetailID, new_obj.ViolationDetailID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại violations_contestants_dict
                    else
                    {
                        if (!violations_contestants_dict.ContainsKey(obj.ViolationDetailID))
                            violations_contestants_dict.Add(obj.ViolationDetailID, old_obj.ViolationDetailID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Violations_Contestants.");
        }
        #endregion Level 6 Transfer

        #region Level 7 Transfer
        // Không kiểm tra trùng nội dung
        public void Contestants_Tests_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Contestants_Tests...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.CONTESTANTS_TESTS> lst_obj = quizDB.CONTESTANTS_TESTS.ToList();
                List<QuizStorage.CONTESTANTS_TESTS> lst_storage_obj = quizstorageDB.CONTESTANTS_TESTS.ToList();
                int new_objID = -1;
                foreach (Quiz.CONTESTANTS_TESTS obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contestants_shifts_dict.ContainsKey((int)obj.ContestantShiftID) || !test_dict.ContainsKey(obj.TestID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.ContestantShiftID = contestants_shifts_dict[(int)obj.ContestantShiftID];
                    obj.TestID = test_dict[(int)obj.TestID];
                    // Thêm mới, và cập nhật lại contestants_tests_dict                    
                    QuizStorage.CONTESTANTS_TESTS new_obj = new QuizStorage.CONTESTANTS_TESTS(obj);                    
                    //quizstorageDB.CONTESTANTS_TESTS.Add(new_obj);
                    string query = "insert into CONTESTANTS_TESTS(Status, ContestantShiftID, TestID, SubmitTime, ContestantAddTime) values(@Status, @ContestantShiftID, @TestID, @SubmitTime, @ContestantAddTime)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    para.Add(new SqlParameter("@ContestantShiftID", GetDataValue(new_obj.ContestantShiftID)));
                    para.Add(new SqlParameter("@TestID", GetDataValue(new_obj.TestID)));
                    para.Add(new SqlParameter("@SubmitTime", GetDataValue(new_obj.SubmitTime)));
                    para.Add(new SqlParameter("@ContestantAddTime", GetDataValue(new_obj.ContestantAddTime)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.CONTESTANTS_TESTS.Select(p => p.ContestantTestID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.ContestantTestID = new_objID;
                    if (!contestants_tests_dict.ContainsKey(obj.ContestantTestID))
                        contestants_tests_dict.Add(obj.ContestantTestID, new_obj.ContestantTestID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Contestants_Tests.");
        }

        public void FindExceptQuestions()
        {
            set_lblprocessing("Đang xác định Question cần chuyển...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                quizDB = new Quiz.Quiz();
                // Lấy tất cả bản ghi hiện tại của bảng Test_Detail trên MTAQuiz
                List<Quiz.TEST_DETAILS> lst_obj = quizDB.TEST_DETAILS.ToList();
                foreach (Quiz.TEST_DETAILS obj in lst_obj)
                {
                    // Liệt kê tất cả câu hỏi của kỳ thi bị bỏ qua vào lst_except_question
                    // (những kỳ thi đã chuyển hoặc có nội dung bị trùng)
                    if (!test_dict.ContainsKey((int)obj.TestID))
                        if (!lst_except_question.Contains(obj.QuestionID))
                            lst_except_question.Add(obj.QuestionID);
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // thêm dòng này vào tự nhiên lỗi (đéo hiểu =)) )
            //set_lblresult("Hoàn thành xác định Question cần chuyển.");
        }

        // Không kiểm tra trùng nội dung (số lượng bản ghi lớn nhất)
        public void Test_Details_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Test_Details...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.TEST_DETAILS> lst_obj = quizDB.TEST_DETAILS.ToList();
                List<QuizStorage.TEST_DETAILS> lst_storage_obj = quizstorageDB.TEST_DETAILS.ToList();
                int new_objID = quizstorageDB.TEST_DETAILS.Select(p => p.TestDetailID).OrderByDescending(p => p).FirstOrDefault();
                foreach (Quiz.TEST_DETAILS obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!test_dict.ContainsKey((int)obj.TestID) || !question_dict.ContainsKey(obj.QuestionID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.QuestionID = question_dict[(int)obj.QuestionID];
                    obj.TestID = test_dict[(int)obj.TestID];
                    // Thêm mới, và cập nhật lại test_details_dict                    
                    QuizStorage.TEST_DETAILS new_obj = new QuizStorage.TEST_DETAILS(obj);
                    if (new_objID == default(int))
                        new_objID = 1;
                    else new_objID += 1;
                    new_obj.TestDetailID = new_objID;
                    //quizstorageDB.TEST_DETAILS.Add(new_obj);
                    string query = "insert into TEST_DETAILS(TestDetailID, RandomAnswer, NumberIndex, Score, Status, TestID, QuestionID) values(@TestDetailID, @RandomAnswer, @NumberIndex, @Score, @Status, @TestID, @QuestionID)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@TestDetailID", GetDataValue(new_obj.TestDetailID)));
                    para.Add(new SqlParameter("@RandomAnswer", GetDataValue(new_obj.RandomAnswer)));
                    para.Add(new SqlParameter("@NumberIndex", GetDataValue(new_obj.NumberIndex)));
                    para.Add(new SqlParameter("@Score", GetDataValue(new_obj.Score)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    para.Add(new SqlParameter("@TestID", GetDataValue(new_obj.TestID)));
                    para.Add(new SqlParameter("@QuestionID", GetDataValue(new_obj.QuestionID)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                    //lst_storage_obj.Add(new_obj);
                    if (!test_details_dict.ContainsKey(obj.TestDetailID))
                        test_details_dict.Add(obj.TestDetailID, new_obj.TestDetailID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Test_Details.");
        }
        #endregion Level 7 Transfer

        #region Level 8 Transfer
        // Không kiểm tra trùng nội dung
        public void Answersheet_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Answersheet...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ANSWERSHEET> lst_obj = quizDB.ANSWERSHEETS.ToList();
                List<QuizStorage.ANSWERSHEET> lst_storage_obj = quizstorageDB.ANSWERSHEETS.ToList();
                int new_objID = -1;
                foreach (Quiz.ANSWERSHEET obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contestants_tests_dict.ContainsKey((int)obj.ContestantTestID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.StaffID != null)
                        obj.StaffID = staffs_dict[(int)obj.StaffID];
                    obj.ContestantTestID = contestants_tests_dict[(int)obj.ContestantTestID];
                    // Thêm mới, và cập nhật lại answersheet_dict                    
                    QuizStorage.ANSWERSHEET new_obj = new QuizStorage.ANSWERSHEET(obj);                    
                    //quizstorageDB.ANSWERSHEETS.Add(new_obj);
                    string query = "insert into ANSWERSHEETS(TestScores, EssayPoints, Status, ContestantTestID, StaffID) values(@TestScores, @EssayPoints, @Status, @ContestantTestID, @StaffID)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@TestScores", GetDataValue(new_obj.TestScores)));
                    para.Add(new SqlParameter("@EssayPoints", GetDataValue(new_obj.EssayPoints)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    para.Add(new SqlParameter("@ContestantTestID", GetDataValue(new_obj.ContestantTestID)));
                    para.Add(new SqlParameter("@StaffID", GetDataValue(new_obj.StaffID)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.ANSWERSHEETS.Select(p => p.AnswerSheetID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.AnswerSheetID = new_objID;
                    if (!answersheet_dict.ContainsKey(obj.AnswerSheetID))
                        answersheet_dict.Add(obj.AnswerSheetID, new_obj.AnswerSheetID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Answersheet.");
        }

        public void ContestantPause_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu ContestantPause...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.CONTESTANTPAUSE> lst_obj = quizDB.CONTESTANTPAUSEs.ToList();
                List<QuizStorage.CONTESTANTPAUSE> lst_storage_obj = quizstorageDB.CONTESTANTPAUSEs.ToList();
                foreach (Quiz.CONTESTANTPAUSE obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!contestants_tests_dict.ContainsKey((int)obj.ContestantTestID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.ContestantTestID != null)
                        obj.ContestantTestID = contestants_tests_dict[(int)obj.ContestantTestID];
                    // Nếu chưa có bản ghi nào nội dung giống như cont 
                    // (hoặc chưa có trùng ID) thì thêm mới, và cập nhật lại contestantpause_dict                    
                    QuizStorage.CONTESTANTPAUSE old_obj = lst_storage_obj.Where(p => p == obj).FirstOrDefault();
                    if (old_obj == default(QuizStorage.CONTESTANTPAUSE))
                    {
                        QuizStorage.CONTESTANTPAUSE new_obj = new QuizStorage.CONTESTANTPAUSE(obj);                        
                        quizstorageDB.CONTESTANTPAUSEs.Add(new_obj);
                        quizstorageDB.SaveChanges();

                        if (!contestantpause_dict.ContainsKey(obj.ContestantPauseID))
                            contestantpause_dict.Add(obj.ContestantPauseID, new_obj.ContestantPauseID);
                    }
                    // Nếu đã trùng thì ko thêm mới, chỉ cập nhật lại contestantpause_dict
                    else
                    {
                        if (!contestantpause_dict.ContainsKey(obj.ContestantPauseID))
                            contestantpause_dict.Add(obj.ContestantPauseID, old_obj.ContestantPauseID);
                    }
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu ContestantPause.");
        }
        #endregion Level 8 Transfer

        #region Level 9 Transfer
        // Không kiểm tra trùng nội dung
        public void Answersheet_Speaking_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Answersheet_Speaking...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ANSWERSHEET_SPEAKING> lst_obj = quizDB.ANSWERSHEET_SPEAKING.ToList();
                List<QuizStorage.ANSWERSHEET_SPEAKING> lst_storage_obj = quizstorageDB.ANSWERSHEET_SPEAKING.ToList();
                int new_objID = -1;
                foreach (Quiz.ANSWERSHEET_SPEAKING obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!answersheet_dict.ContainsKey((int)obj.AnswerSheetID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.AnswerSheetID != null)
                        obj.AnswerSheetID = answersheet_dict[(int)obj.AnswerSheetID];
                    // Thêm mới, và cập nhật lại answersheet_speaking_dict                    
                    QuizStorage.ANSWERSHEET_SPEAKING new_obj = new QuizStorage.ANSWERSHEET_SPEAKING(obj);                    
                    //quizstorageDB.ANSWERSHEET_SPEAKING.Add(new_obj);
                    string query = "insert into ANSWERSHEET_SPEAKING(AnswerSheetID, SpeakingScore, SpeakingScore2, Status) values(@AnswerSheetID, @SpeakingScore, @SpeakingScore2, @Status)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@AnswerSheetID", GetDataValue(new_obj.AnswerSheetID)));
                    para.Add(new SqlParameter("@SpeakingScore", GetDataValue(new_obj.SpeakingScore)));
                    para.Add(new SqlParameter("@SpeakingScore2", GetDataValue(new_obj.SpeakingScore2)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.ANSWERSHEET_SPEAKING.Select(p => p.AnswerSheetSpeakingID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.AnswerSheetSpeakingID = new_objID;
                    if (!answersheet_speaking_dict.ContainsKey(obj.AnswerSheetSpeakingID))
                        answersheet_speaking_dict.Add(obj.AnswerSheetSpeakingID, new_obj.AnswerSheetSpeakingID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Answersheet_Speaking.");
        }

        // Không kiểm tra trùng nội dung
        public void Answersheet_Writing_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Answersheet_Writing...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ANSWERSHEET_WRITING> lst_obj = quizDB.ANSWERSHEET_WRITING.ToList();
                List<QuizStorage.ANSWERSHEET_WRITING> lst_storage_obj = quizstorageDB.ANSWERSHEET_WRITING.ToList();
                int new_objID = -1;
                foreach (Quiz.ANSWERSHEET_WRITING obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!answersheet_dict.ContainsKey((int)obj.AnswerSheetID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.AnswerSheetID != null)
                        obj.AnswerSheetID = answersheet_dict[(int)obj.AnswerSheetID];
                    // Thêm mới, và cập nhật lại answersheet_writing_dict                    
                    QuizStorage.ANSWERSHEET_WRITING new_obj = new QuizStorage.ANSWERSHEET_WRITING(obj);                    
                    //quizstorageDB.ANSWERSHEET_WRITING.Add(new_obj);
                    string query = "insert into ANSWERSHEET_WRITING(AnswerSheetID, WritingScore, WritingScore2, Status) values(@AnswerSheetID, @WritingScore, @WritingScore2, @Status)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@AnswerSheetID", GetDataValue(new_obj.AnswerSheetID)));
                    para.Add(new SqlParameter("@WritingScore", GetDataValue(new_obj.WritingScore)));
                    para.Add(new SqlParameter("@WritingScore2", GetDataValue(new_obj.WritingScore2)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.ANSWERSHEET_WRITING.Select(p => p.AnswerSheetWritingID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.AnswerSheetWritingID = new_objID;
                    if (!answersheet_writing_dict.ContainsKey(obj.AnswerSheetWritingID))
                        answersheet_writing_dict.Add(obj.AnswerSheetWritingID, new_obj.AnswerSheetWritingID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Answersheet_Writing.");
        }

        // Không kiểm tra trùng nội dung
        public void Answersheet_Details_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Answersheet_Details...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ANSWERSHEET_DETAILS> lst_obj = quizDB.ANSWERSHEET_DETAILS.ToList();
                List<QuizStorage.ANSWERSHEET_DETAILS> lst_storage_obj = quizstorageDB.ANSWERSHEET_DETAILS.ToList();
                int new_objID = -1;
                foreach (Quiz.ANSWERSHEET_DETAILS obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!answersheet_dict.ContainsKey((int)obj.AnswerSheetID) || !subquestion_dict.ContainsKey(obj.SubQuestionID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.AnswerSheetID = answersheet_dict[(int)obj.AnswerSheetID];
                    obj.SubQuestionID = subquestion_dict[(int)obj.SubQuestionID];
                    // Thêm mới, và cập nhật lại answersheet_details_dict                    
                    QuizStorage.ANSWERSHEET_DETAILS new_obj = new QuizStorage.ANSWERSHEET_DETAILS(obj);                    
                    //quizstorageDB.ANSWERSHEET_DETAILS.Add(new_obj);
                    string query = "insert into ANSWERSHEET_DETAILS(ChoosenAnswer, AnswerContent, LastTime, Status, AnswerSheetID, SubQuestionID, Score, Comment, AnswerSheetFile) values(@ChoosenAnswer, @AnswerContent, @LastTime, @Status, @AnswerSheetID, @SubQuestionID, @Score, @Comment, @AnswerSheetFile)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@ChoosenAnswer", GetDataValue(new_obj.ChoosenAnswer)));
                    para.Add(new SqlParameter("@AnswerContent", GetDataValue(new_obj.AnswerContent)));
                    para.Add(new SqlParameter("@LastTime", GetDataValue(new_obj.LastTime)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    para.Add(new SqlParameter("@AnswerSheetID", GetDataValue(new_obj.AnswerSheetID)));
                    para.Add(new SqlParameter("@SubQuestionID", GetDataValue(new_obj.SubQuestionID)));
                    para.Add(new SqlParameter("@Score", GetDataValue(new_obj.Score)));
                    para.Add(new SqlParameter("@Comment", GetDataValue(new_obj.Comment)));
                    // Do AnswerSheetFile có kiểu đặc biệt byte[], nên phải add đặc biệt
                    SqlParameter ansSheetFile_para = new SqlParameter("@AnswerSheetFile", SqlDbType.VarBinary);
                    ansSheetFile_para.Value = GetDataValue(new_obj.AnswerSheetFile);
                    para.Add(ansSheetFile_para);
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.ANSWERSHEET_DETAILS.Select(p => p.AnswerSheetDetailID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.AnswerSheetDetailID = new_objID;
                    if (!answersheet_details_dict.ContainsKey(obj.AnswerSheetDetailID))
                        answersheet_details_dict.Add(obj.AnswerSheetDetailID, new_obj.AnswerSheetDetailID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Answersheet_Details.");
        }
        #endregion Level 9 Transfer

        #region Level 10 Transfer
        // Không kiểm tra trùng nội dung
        public void Speaking_Teacher_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Speaking_Teacher...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SPEAKING_TEACHER> lst_obj = quizDB.SPEAKING_TEACHER.ToList();
                List<QuizStorage.SPEAKING_TEACHER> lst_storage_obj = quizstorageDB.SPEAKING_TEACHER.ToList();
                int new_objID = -1;
                foreach (Quiz.SPEAKING_TEACHER obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!answersheet_speaking_dict.ContainsKey((int)obj.AnswerSheetSpeakingID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.AnswerSheetSpeakingID = answersheet_speaking_dict[(int)obj.AnswerSheetSpeakingID];
                    // Thêm mới, và cập nhật lại speaking_teacher_dict                    
                    QuizStorage.SPEAKING_TEACHER new_obj = new QuizStorage.SPEAKING_TEACHER(obj);                    
                    //quizstorageDB.SPEAKING_TEACHER.Add(new_obj);
                    string query = "insert into SPEAKING_TEACHER(AnswerSheetSpeakingID, TeacherID, Status) values(@AnswerSheetSpeakingID, @TeacherID, @Status)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@AnswerSheetSpeakingID", GetDataValue(new_obj.AnswerSheetSpeakingID)));
                    para.Add(new SqlParameter("@TeacherID", GetDataValue(new_obj.TeacherID)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                    quizstorageDB.SaveChanges();
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.SPEAKING_TEACHER.Select(p => p.ID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.ID = new_objID;
                    if (!speaking_teacher_dict.ContainsKey(obj.ID))
                        speaking_teacher_dict.Add(obj.ID, new_obj.ID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Speaking_Teacher.");
        }

        // Không kiểm tra trùng nội dung
        public void Writing_Teacher_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Writing_Teacher...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.WRITING_TEACHER> lst_obj = quizDB.WRITING_TEACHER.ToList();
                List<QuizStorage.WRITING_TEACHER> lst_storage_obj = quizstorageDB.WRITING_TEACHER.ToList();
                int new_objID = -1;
                foreach (Quiz.WRITING_TEACHER obj in lst_obj)
                {
                    // Nếu kỳ thi của obj ko trùng thì mới tiến hành sao chép dữ liệu
                    if (!answersheet_writing_dict.ContainsKey((int)obj.AnswerSheetWritingID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    if (obj.AnswerSheetWritingID != null)
                        obj.AnswerSheetWritingID = answersheet_writing_dict[(int)obj.AnswerSheetWritingID];
                    // Thêm mới, và cập nhật lại writing_teacher_dict                    
                    QuizStorage.WRITING_TEACHER new_obj = new QuizStorage.WRITING_TEACHER(obj);                    
                    //quizstorageDB.WRITING_TEACHER.Add(new_obj);
                    string query = "insert into WRITING_TEACHER(AnswerSheetWritingID, TeacherID, Status) values(@AnswerSheetWritingID, @TeacherID, @Status)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@AnswerSheetWritingID", GetDataValue(new_obj.AnswerSheetWritingID)));
                    para.Add(new SqlParameter("@TeacherID", GetDataValue(new_obj.TeacherID)));
                    para.Add(new SqlParameter("@Status", GetDataValue(new_obj.Status)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                    quizstorageDB.SaveChanges();
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.WRITING_TEACHER.Select(p => p.ID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.ID = new_objID;
                    if (!writing_teacher_dict.ContainsKey(obj.ID))
                        writing_teacher_dict.Add(obj.ID, new_obj.ID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Writing_Teacher.");
        }

        // Không kiểm tra trùng nội dung
        public void Questions_Temp_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Questions_Temp...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.QUESTIONS_TEMP> lst_obj = quizDB.QUESTIONS_TEMP.ToList();
                List<QuizStorage.QUESTIONS_TEMP> lst_storage_obj = quizstorageDB.QUESTIONS_TEMP.ToList();
                int new_objID = -1;
                foreach (Quiz.QUESTIONS_TEMP obj in lst_obj)
                {
                    // Nếu kỳ thi bị bỏ qua, thì dữ liệu về Question_Temp của kỳ thi cũng bị bỏ qua
                    if (!question_dict.ContainsKey(obj.QuestionID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.
                    obj.QuestionID = question_dict[(int)obj.QuestionID];
                    if (obj.DivisionShiftID != null)
                        obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    // Thêm mới, và cập nhật lại questions_temp_dict
                    QuizStorage.QUESTIONS_TEMP new_obj = new QuizStorage.QUESTIONS_TEMP(obj);                    
                    //quizstorageDB.QUESTIONS_TEMP.Add(new_obj);
                    string query = "insert into QUESTIONS_TEMP(QuestionID, QuestionContent, QuestionFormat, Level, IsQuiz, IsSingleChoice, IsParagarph, IsQuestionContent, NumberSubQuestion, NumberAnswer, DivisionShiftID, Type, Audio) values(@QuestionID, @QuestionContent, @QuestionFormat, @Level, @IsQuiz, @IsSingleChoice, @IsParagarph, @IsQuestionContent, @NumberSubQuestion, @NumberAnswer, @DivisionShiftID, @Type, @Audio)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@QuestionID", GetDataValue(new_obj.QuestionID)));
                    para.Add(new SqlParameter("@QuestionContent", GetDataValue(new_obj.QuestionContent)));
                    para.Add(new SqlParameter("@QuestionFormat", GetDataValue(new_obj.QuestionFormat)));
                    para.Add(new SqlParameter("@Level", GetDataValue(new_obj.Level)));
                    para.Add(new SqlParameter("@IsQuiz", GetDataValue(new_obj.IsQuiz)));
                    para.Add(new SqlParameter("@IsSingleChoice", GetDataValue(new_obj.IsSingleChoice)));
                    para.Add(new SqlParameter("@IsParagarph", GetDataValue(new_obj.IsParagarph)));
                    para.Add(new SqlParameter("@IsQuestionContent", GetDataValue(new_obj.IsQuestionContent)));
                    para.Add(new SqlParameter("@NumberSubQuestion", GetDataValue(new_obj.NumberSubQuestion)));
                    para.Add(new SqlParameter("@NumberAnswer", GetDataValue(new_obj.NumberAnswer)));
                    para.Add(new SqlParameter("@DivisionShiftID", GetDataValue(new_obj.DivisionShiftID)));
                    para.Add(new SqlParameter("@Type", GetDataValue(new_obj.Type)));
                    // Do Audio có kiểu đặc biệt byte[], nên phải add đặc biệt
                    SqlParameter audio_para = new SqlParameter("@Audio", SqlDbType.VarBinary);
                    audio_para.Value = GetDataValue(new_obj.Audio);
                    para.Add(audio_para);
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.QUESTIONS_TEMP.Select(p => p.QuestionTempID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.QuestionTempID = new_objID;
                    if (!questions_temp_dict.ContainsKey(obj.QuestionTempID))
                        questions_temp_dict.Add(obj.QuestionTempID, new_obj.QuestionTempID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Questions_Temp.");
        }

        // Không kiểm tra trùng nội dung
        public void Subquestions_Temp_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Subquestions_Temp...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.SUBQUESTIONS_TEMP> lst_obj = quizDB.SUBQUESTIONS_TEMP.ToList();
                List<QuizStorage.SUBQUESTIONS_TEMP> lst_storage_obj = quizstorageDB.SUBQUESTIONS_TEMP.ToList();
                int new_objID = -1;
                foreach (Quiz.SUBQUESTIONS_TEMP obj in lst_obj)
                {
                    // Nếu kỳ thi bị bỏ qua, thì dữ liệu về Subquestion_Temp của kỳ thi cũng bị bỏ qua
                    if (!question_dict.ContainsKey(obj.QuestionID))
                        continue;
                    if (!division_shifts_dict.ContainsKey(obj.DivisionShiftID))
                        continue;
                    if (!subquestion_dict.ContainsKey(obj.SubQuestionID))
                        continue;
                    obj.QuestionID = question_dict[(int)obj.QuestionID];
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.                                        
                    obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    obj.SubQuestionID = subquestion_dict[(int)obj.SubQuestionID];
                    if (obj.QuestionTempID != null)
                        obj.QuestionTempID = questions_temp_dict[(int)obj.QuestionTempID];
                    // Thêm mới, và cập nhật lại subquestions_temp_dict
                    QuizStorage.SUBQUESTIONS_TEMP new_obj = new QuizStorage.SUBQUESTIONS_TEMP(obj);                    
                    //quizstorageDB.SUBQUESTIONS_TEMP.Add(new_obj);
                    string query = "insert into SUBQUESTIONS_TEMP(SubQuestionID, SubQuestionContent, Score, QuestionID, QuestionTempID, DivisionShiftID) values(@SubQuestionID, @SubQuestionContent, @Score, @QuestionID, @QuestionTempID, @DivisionShiftID)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@SubQuestionID", GetDataValue(new_obj.SubQuestionID)));
                    para.Add(new SqlParameter("@SubQuestionContent", GetDataValue(new_obj.SubQuestionContent)));
                    para.Add(new SqlParameter("@Score", GetDataValue(new_obj.Score)));
                    para.Add(new SqlParameter("@QuestionID", GetDataValue(new_obj.QuestionID)));
                    para.Add(new SqlParameter("@QuestionTempID", GetDataValue(new_obj.QuestionTempID)));
                    para.Add(new SqlParameter("@DivisionShiftID", GetDataValue(new_obj.DivisionShiftID)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());                    
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.SUBQUESTIONS_TEMP.Select(p => p.SubQuestionTempID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.SubQuestionTempID = new_objID;
                    if (!subquestions_temp_dict.ContainsKey(obj.SubQuestionTempID))
                        subquestions_temp_dict.Add(obj.SubQuestionTempID, new_obj.SubQuestionTempID);
                   
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
                quizstorageDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Subquestions_Temp.");
        }

        // Không kiểm tra trùng nội dung
        public void Answers_Temp_Transfer()
        {
            set_lblprocessing("Đang chuyển dữ liệu Answers_Temp...");
            bw.ReportProgress(0); int i = 0;
            try
            {
                // Kết nối csdl bằng Entities Framework
                // Quiz.Quiz quizDB = new Quiz.Quiz();
                // QuizStorage.QuizStorage quizstorageDB = new QuizStorage.QuizStorage();
                // Lấy tất cả bản ghi hiện tại của 2 csdl Quiz và QuizStorage
                // Mục đích để so sánh, kiểm tra trùng
                List<Quiz.ANSWERS_TEMP> lst_obj = quizDB.ANSWERS_TEMP.ToList();
                List<QuizStorage.ANSWERS_TEMP> lst_storage_obj = quizstorageDB.ANSWERS_TEMP.ToList();
                int new_objID = -1;
                foreach (Quiz.ANSWERS_TEMP obj in lst_obj)
                {
                    // Nếu kỳ thi bị bỏ qua, thì dữ liệu về Question_Temp của kỳ thi cũng bị bỏ qua
                    if (!subquestions_temp_dict.ContainsKey((int)obj.SubQuestionTempID))
                        continue;
                    if (!answer_dict.ContainsKey(obj.AnswerID))
                        continue;
                    if (!division_shifts_dict.ContainsKey(obj.DivisionShiftID))
                        continue;
                    if (!subquestion_dict.ContainsKey(obj.SubQuestionID))
                        continue;
                    // Đối với những bảng có sử dụng khoá ngoại của bảng cha,
                    // cần phải sửa lại ID của khoá ngoại theo Dictionanry đã cập nhật từ trước.                    
                    obj.AnswerID = answer_dict[(int)obj.AnswerID];
                    obj.DivisionShiftID = division_shifts_dict[(int)obj.DivisionShiftID];
                    obj.SubQuestionID = subquestion_dict[(int)obj.SubQuestionID];
                    if (obj.SubQuestionTempID != null)
                        obj.SubQuestionTempID = subquestions_temp_dict[(int)obj.SubQuestionTempID];
                    // Thêm mới, và cập nhật lại answers_temp_dict
                    QuizStorage.ANSWERS_TEMP new_obj = new QuizStorage.ANSWERS_TEMP(obj);                    
                    //quizstorageDB.ANSWERS_TEMP.Add(new_obj);
                    string query = "insert into ANSWERS_TEMP(AnswerID, AnswerContent, IsCorrect, SubQuestionID, SubQuestionTempID, DivisionShiftID) values(@AnswerID, @AnswerContent, @IsCorrect, @SubQuestionID, @SubQuestionTempID, @DivisionShiftID)";
                    List<SqlParameter> para = new List<SqlParameter>();
                    para.Add(new SqlParameter("@AnswerID", GetDataValue(new_obj.AnswerID)));
                    para.Add(new SqlParameter("@AnswerContent", GetDataValue(new_obj.AnswerContent)));
                    para.Add(new SqlParameter("@IsCorrect", GetDataValue(new_obj.IsCorrect)));
                    para.Add(new SqlParameter("@SubQuestionID", GetDataValue(new_obj.SubQuestionID)));
                    para.Add(new SqlParameter("@SubQuestionTempID", GetDataValue(new_obj.SubQuestionTempID)));
                    para.Add(new SqlParameter("@DivisionShiftID", GetDataValue(new_obj.DivisionShiftID)));
                    quizstorageDB.Database.ExecuteSqlCommand(query, para.ToArray());
                    quizstorageDB.SaveChanges();
                    // Do đây là bảng có ID tự tăng nên phải cập nhật lại ID vừa được thêm vào csdl
                    new_objID += 1;
                    if (new_objID <= 0)
                        new_objID = quizstorageDB.ANSWERS_TEMP.Select(p => p.AnswerTempID).OrderByDescending(p => p).FirstOrDefault();
                    new_obj.AnswerTempID = new_objID;
                    if (!answers_temp_dict.ContainsKey(obj.AnswerTempID))
                        answers_temp_dict.Add(obj.AnswerTempID, new_obj.AnswerTempID);
                    
                    bw.ReportProgress(++i * 100 / lst_obj.Count());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            set_lblresult("Hoàn thành chuyển dữ liệu Answers_Temp.");
        }
        #endregion Level 10 Transfer        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bw.Abort();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReverseTransfer_Shown(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                quizDB = new Quiz.Quiz();
                quizstorageDB = new QuizStorage.QuizStorage();
                initDict();
                lst_except_question.Clear();
                set_lblprocessing("");
                set_lblresult("clear");
                bw.RunWorkerAsync();
            }
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
}
