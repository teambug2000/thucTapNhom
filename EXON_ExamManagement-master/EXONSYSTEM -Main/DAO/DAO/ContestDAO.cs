using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAO.DAO
{
    public class ContestDAO
    {
        private static ContestDAO instance;
        public static ContestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContestDAO();
                }
                return instance;
            }
        }
        private ContestDAO() { }

        public void GetContestByShiftTime(string ComputerName, out Contest ContestOut, out ErrorController EC)
        {
            Contest C = new Contest();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                try
                {
                    int  currentnow =(int)DAO.ConvertDateTime.GetDateTimeServer().TimeOfDay.TotalSeconds;
                    int datenow = DAO.ConvertDateTime.ConvertDateTimeToUnix(DAO.ConvertDateTime.GetDateTimeServer()) / 86400;
                    ROOMDIAGRAM  RD = DB.ROOMDIAGRAMS.SingleOrDefault(x => x.ComputerName == ComputerName);
                    if (RD != null)
                    {
                        SHIFT sh = DB.SHIFTS.Where(x => x.EndTime >= currentnow && x.ShiftDate / 86400 == datenow).OrderBy(x => x.StartTime).FirstOrDefault();
                        if (sh != null)
                        {
                                
                            ROOMTEST RT = DB.ROOMTESTS.Where(x => x.RoomTestID == RD.RoomTestID).SingleOrDefault();

                            DIVISION_SHIFTS ds = DB.DIVISION_SHIFTS.Where(x => x.RoomTestID == RT.RoomTestID && x.ShiftID == sh.ShiftID).SingleOrDefault();
                            if (ds != null)
                            {
                                CONTESTANTS_SHIFTS cshift = DB.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == ds.DivisionShiftID && x.RoomDiagramID== RD.RoomDiagramID).SingleOrDefault();
                                if (cshift != null)
                                {
                                    if(cshift.IsCheckFingerprint!=null && cshift.IsCheckFingerprint!=0)
                                    {
                                        C.ContestName = ds.SHIFT.CONTEST.ContestName;
                                        C.StartTime = ds.SHIFT.StartTime;
                                        C.EndTime = ds.SHIFT.EndTime;
                                        C.ShiftDate = ds.SHIFT.ShiftDate;
                                        C.Subject = cshift.SCHEDULE.SUBJECT.SubjectName;
                                        C.TimeOfTest = cshift.SCHEDULE.TimeOfTest+ 300;//5p kiem tra b
                                        C.DivisionShiftID = cshift.DivisionShiftID;
                                        C.RoomID = ds.RoomTestID;
                                        C.RoomName = ds.ROOMTEST.RoomTestName;
                                        C.ComputerCode = RD.ComputerCode;
                                        C.ScheduleID = cshift.ScheduleID;
                                        C.ComputerName = RD.ComputerName;
                                        C.TimeToSubmit = cshift.SCHEDULE.TimeToSubmit;
                                        ContestOut = C;
                                        EC = new ErrorController(Common.STATUS_OK, "Get contest information succedsfully");
                                    }
                                    else
                                    {
                                        ContestOut = null;
                                        EC = new ErrorController(Common.STATUS_ERROR, "Thí sinh chưa xác thực!");
                                    }
                                    //C.ContestID = SS.SHIFT.ContestID??default(int);
                                   
                                }
                                else
                                {
                                    ContestOut = null;
                                    EC = new ErrorController(Common.STATUS_ERROR, "Máy không tham gia thi!");

                                }
                            }
                            else
                                   {
                                  ContestOut = null;
                                     EC = new ErrorController(Common.STATUS_ERROR, "Không thể lấy dữ liệu ca thi");
                                // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                                      }
                        }
                        else
                        {
                            ContestOut = null;
                            EC = new ErrorController(Common.STATUS_ERROR, "Thời gian ca thi chưa đến hoặc đã hết!");
                            // trường hợp này lỗi do k lấy dc dữ liệu từ DB.

                        }
                    }
                    else
                    {
                        ContestOut = null;
                        EC = new ErrorController(Common.STATUS_ERROR, "Máy chưa được đăng ký!");

                        // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                    }

                }
                catch (Exception ex)
                {
                    ContestOut = null;
                    EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, "Có lỗi khi lấy dữ liệu"));
                    // đây là trường hợp lỗi khi sử dụng try catch thường sẽ là unknown
                }
            }
        }
        public void GetContestByComputerName(string ComputerName, out Contest ContestOut, out ErrorController EC)
        {
            Contest C = new Contest();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                try
                {
                    ROOMDIAGRAM RD = DB.ROOMDIAGRAMS.SingleOrDefault(x => x.ComputerName == ComputerName);

                    if (RD != null)
                    {
                        CONTESTANTS_SHIFTS CSH = RD.CONTESTANTS_SHIFTS.SingleOrDefault();
                        DIVISION_SHIFTS SS = RD.ROOMTEST.DIVISION_SHIFTS.SingleOrDefault(x => x.ShiftID == CSH.DIVISION_SHIFTS.ShiftID && x.RoomTestID == CSH.DIVISION_SHIFTS.RoomTestID);
                        if (SS != null && CSH != null)
                        {
                            //C.ContestID = SS.SHIFT.ContestID??default(int);
                            C.ContestName = SS.SHIFT.CONTEST.ContestName;
                            C.StartTime = SS.SHIFT.StartTime;
                            C.EndTime = SS.SHIFT.EndTime;
                            C.ShiftDate = SS.SHIFT.ShiftDate;
                            C.Subject = CSH.SCHEDULE.SUBJECT.SubjectName;
                            C.TimeOfTest = CSH.SCHEDULE.TimeOfTest+300;
                            C.DivisionShiftID = CSH.DivisionShiftID;
                            C.RoomID = SS.RoomTestID;
                            C.RoomName = SS.ROOMTEST.RoomTestName;
                            C.ComputerCode = RD.ComputerCode;
                            C.ScheduleID = CSH.ScheduleID;
                            C.ComputerName = RD.ComputerName;
                            C.TimeToSubmit = CSH.SCHEDULE.TimeToSubmit;
                            ContestOut = C;
                            EC = new ErrorController(Common.STATUS_OK, "Get contest information successfully");
                            // den day la xong nhiem vu của hàm này., thì a trả ra STATUS_OK 
                        }
                        else
                        {
                            ContestOut = null;
                            EC = new ErrorController(Common.STATUS_ERROR, "Can not get SHIFTS_STAFFS by ComputerName");
                            // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                        }
                    }
                    else
                    {
                        ContestOut = null;
                        EC = new ErrorController(Common.STATUS_ERROR, "Can not get ROOMDIAGRAMS by ComputerName");
                        // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                    }
                }
                catch (Exception ex)
                {
                    ContestOut = null;
                    EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
                    // đây là trường hợp lỗi khi sử dụng try catch thường sẽ là unknown
                }
            }
        }

        public EXON.Model.Models.CONTEST InsertContest(EXON.Model.Models.CONTEST contest, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.CONTEST _contest = new EXON.Model.Models.CONTEST();
                using (var command = new SqlCommand("INSERT INTO CONTESTS (ContestName, Description, CreatedDate, EndDate,"
                    +" AcceptedDate, BeginRegistration, EndRegistration, CreatedQuestionStartDate, CreatedQuestionEndDate,"
                    +" SchoolYear, Status, CreatedStaffID, AcceptedStaffID, BeginDate)" +
                    " VALUES (@contestName, @description, @createDate, @endDate,"
                    + " @acceptedDate, @beginRegistration, @endRegistration, @createdQuestionStartDate, @createdQuestionEndDate,"
                    + " @schoolYear, @status, @createdStaffID, @acceptedStaffID, @beginDate) WHERE ContestID = @id", sql))
                {
                    command.Parameters.Add("@contestName", _contest.ContestName);
                    command.Parameters.Add("@description", _contest.Description);
                    command.Parameters.Add("@createDate", _contest.CreatedDate);
                    command.Parameters.Add("@endDate", _contest.EndDate);
                    command.Parameters.Add("@acceptedDate", _contest.AcceptedDate);
                    command.Parameters.Add("@beginRegistration", _contest.BeginRegistration);
                    command.Parameters.Add("@endRegistration", _contest.EndRegistration);
                    command.Parameters.Add("@createdQuestionStartDate", _contest.CreatedQuestionStartDate);
                    command.Parameters.Add("@createdQuestionEndDate", _contest.CreatedQuestionEndDate);
                    command.Parameters.Add("@schoolYear", _contest.SchoolYear);
                    command.Parameters.Add("@status", _contest.Status);
                    command.Parameters.Add("@createdStaffID", _contest.CreatedStaffID);
                    command.Parameters.Add("@acceptedStaffID", _contest.AcceptedStaffID);
                    command.Parameters.Add("@beginDate", _contest.BeginDate);
                    command.Parameters.Add("@id", _contest.ContestID);
                    command.ExecuteNonQuery();
                }
                return _contest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EXON.Model.Models.CONTEST GetContestByContestID(int CurrentContestID, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.CONTEST _contest = new EXON.Model.Models.CONTEST();
                using (var command = new SqlCommand("select * from CONTESTS where ContestID = @id", sql))
                {
                    command.Parameters.Add("@id", CurrentContestID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EXON.Model.Models.CONTEST contest = new EXON.Model.Models.CONTEST();
                            contest.ContestID = Convert.ToInt32(reader["CONTESTID"].ToString());
                            contest.Description = reader["Description"].ToString();
                            contest.CreatedDate = Convert.ToInt32(reader["CreatedDate"].ToString());
                            contest.EndDate = Convert.ToInt32(reader["EndDate"].ToString());
                            //contest.AcceptedDate = Convert.ToInt32(reader["AcceptedDate"].ToString());
                            contest.BeginRegistration = Convert.ToInt32(reader["BeginRegistration"].ToString());
                            contest.EndRegistration = Convert.ToInt32(reader["EndRegistration"].ToString());
                            contest.CreatedQuestionStartDate = Convert.ToInt32(reader["CreatedQuestionStartDate"].ToString());
                            //contest.SchoolYear = reader["SchoolYear"].ToString();
                            contest.Status = Convert.ToInt32(reader["Status"].ToString());
                            contest.CreatedStaffID = Convert.ToInt32(reader["CreatedStaffID"].ToString());
                            contest.AcceptedStaffID = Convert.ToInt32(reader["AcceptedStaffID"].ToString());
                            contest.BeginDate = Convert.ToInt32(reader["BeginDate"].ToString());
                            _contest = contest;
                        }

                    }
                    return _contest;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EXON.Model.Models.CONTEST UpdateContest(EXON.Model.Models.CONTEST contest, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.CONTEST _contest = new EXON.Model.Models.CONTEST();
                //using (var command = new SqlCommand("UPDATE CONTESTS SET ContestName = @contestName, Description =  @description, CreatedDate = @createDate, EndDate = @endDate,"
                //    + " AcceptedDate = @acceptedDate , BeginRegistration = @beginRegistration, EndRegistration = @endRegistration, CreatedQuestionStartDate = @createdQuestionStartDate, CreatedQuestionEndDate = @createdQuestionEndDate,"
                //    + " SchoolYear = @schoolYear, Status = @status, CreatedStaffID = @createdStaffID, AcceptedStaffID = @acceptedStaffID, BeginDate = @beginDate where ContestID= @id", sql))
                using (var command = new SqlCommand("UPDATE CONTESTS SET Status = @status where ContestID= @id", sql))
                {
                    //command.Parameters.Add("@contestName", _contest.ContestName);
                    //command.Parameters.Add("@description", _contest.Description);
                    //command.Parameters.Add("@createDate", _contest.CreatedDate);
                    //command.Parameters.Add("@endDate", _contest.EndDate);
                    //command.Parameters.Add("@acceptedDate", _contest.AcceptedDate);
                    // command.Parameters.Add("@beginRegistration", _contest.BeginRegistration);
                    //command.Parameters.Add("@endRegistration", _contest.EndRegistration);
                    //command.Parameters.Add("@createdQuestionStartDate", _contest.CreatedQuestionStartDate);
                    //command.Parameters.Add("@createdQuestionEndDate", _contest.CreatedQuestionEndDate);
                    //command.Parameters.Add("@schoolYear", _contest.SchoolYear);
                    command.Parameters.Add("@status", _contest.Status);
                    //command.Parameters.Add("@createdStaffID", _contest.CreatedStaffID);
                    //command.Parameters.Add("@acceptedStaffID", _contest.AcceptedStaffID);
                    //command.Parameters.Add("@beginDate", _contest.BeginDate);
                    command.Parameters.Add("@id", _contest.ContestID);
                    command.ExecuteNonQuery();
                    _contest = contest;
                }
                return _contest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
