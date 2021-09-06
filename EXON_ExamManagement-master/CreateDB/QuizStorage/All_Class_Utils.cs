using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDB.QuizStorage
{
    public partial class ANSWER
    {
        public ANSWER()
        {

        }

        public ANSWER(Quiz.ANSWER ans)
        {
            this.AnswerID = ans.AnswerID;
            this.AnswerContent = ans.AnswerContent;
            this.IsCorrect = ans.IsCorrect;
            this.SubQuestionID = ans.SubQuestionID;
            this.HeightToDisplay = ans.HeightToDisplay;
        }

        public override bool Equals(object obj)
        {
            Quiz.ANSWER ans = (Quiz.ANSWER)obj;
            // Cách giải thích giống với Question
            if (this.AnswerID == ans.AnswerID)
                return true;
            if (this.AnswerContent != ans.AnswerContent)
                return false;
            if (this.IsCorrect != ans.IsCorrect)
                return false;
            if (this.SubQuestionID != ans.SubQuestionID)
                return false;
            if (this.HeightToDisplay != ans.HeightToDisplay)
                return false;
            return true;
        }

        public static bool operator ==(ANSWER ans1, Quiz.ANSWER ans2)
        {
            return ans1.Equals(ans2);
        }

        public static bool operator !=(ANSWER ans1, Quiz.ANSWER ans2)
        {
            return !ans1.Equals(ans2);
        }
    }

    public partial class ANSWERS_TEMP
    {
        public ANSWERS_TEMP()
        {

        }

        public ANSWERS_TEMP(Quiz.ANSWERS_TEMP ans_temp)
        {
            this.AnswerTempID = ans_temp.AnswerTempID;
            this.AnswerID = ans_temp.AnswerID;
            this.AnswerContent = ans_temp.AnswerContent;
            this.IsCorrect = ans_temp.IsCorrect;
            this.SubQuestionID = ans_temp.SubQuestionID;
            this.SubQuestionTempID = ans_temp.SubQuestionTempID;
            this.DivisionShiftID = ans_temp.DivisionShiftID;
        }

        public override bool Equals(object obj)
        {
            Quiz.ANSWERS_TEMP ans_temp = (Quiz.ANSWERS_TEMP)obj;
            if (this.AnswerID != ans_temp.AnswerID)
                return false;
            if (this.AnswerContent != ans_temp.AnswerContent)
                return false;
            if (this.IsCorrect != ans_temp.IsCorrect)
                return false;
            if (this.SubQuestionID != ans_temp.SubQuestionID)
                return false;
            if (this.SubQuestionTempID != ans_temp.SubQuestionTempID)
                return false;
            if (this.DivisionShiftID != ans_temp.DivisionShiftID)
                return false;
            return true;
        }

        public static bool operator ==(ANSWERS_TEMP ans_temp1, Quiz.ANSWERS_TEMP ans_temp2)
        {
            return ans_temp1.Equals(ans_temp2);
        }

        public static bool operator !=(ANSWERS_TEMP ans_temp1, Quiz.ANSWERS_TEMP ans_temp2)
        {
            return !ans_temp1.Equals(ans_temp2);
        }
    }

    public partial class ANSWERSHEET
    {
        public ANSWERSHEET(Quiz.ANSWERSHEET anssheet)
        {
            this.AnswerSheetID = anssheet.AnswerSheetID;
            this.TestScores = anssheet.TestScores;
            this.EssayPoints = anssheet.EssayPoints;
            this.Status = anssheet.Status;
            this.ContestantTestID = anssheet.ContestantTestID;
            this.StaffID = anssheet.StaffID;

            ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
            ANSWERSHEET_SPEAKING = new HashSet<ANSWERSHEET_SPEAKING>();
            ANSWERSHEET_WRITING = new HashSet<ANSWERSHEET_WRITING>();
        }

        public override bool Equals(object obj)
        {
            Quiz.ANSWERSHEET anssheet = (Quiz.ANSWERSHEET)obj;
            if (this.TestScores != anssheet.TestScores)
                return false;
            if (this.EssayPoints != anssheet.EssayPoints)
                return false;
            if (this.Status != anssheet.Status)
                return false;
            if (this.ContestantTestID != anssheet.ContestantTestID)
                return false;
            if (this.StaffID != anssheet.StaffID)
                return false;
            return true;
        }

        public static bool operator ==(ANSWERSHEET anssheet1, Quiz.ANSWERSHEET anssheet2)
        {
            return anssheet1.Equals(anssheet2);
        }

        public static bool operator !=(ANSWERSHEET anssheet1, Quiz.ANSWERSHEET anssheet2)
        {
            return !anssheet1.Equals(anssheet2);
        }
    }

    public partial class ANSWERSHEET_DETAILS
    {
        public ANSWERSHEET_DETAILS()
        {

        }

        public ANSWERSHEET_DETAILS(Quiz.ANSWERSHEET_DETAILS anssheet_detail)
        {
            this.AnswerSheetDetailID = anssheet_detail.AnswerSheetDetailID;
            this.ChoosenAnswer = anssheet_detail.ChoosenAnswer;
            this.AnswerContent = anssheet_detail.AnswerContent;
            this.LastTime = anssheet_detail.LastTime;
            this.Status = anssheet_detail.Status;
            this.AnswerSheetID = anssheet_detail.AnswerSheetID;
            this.SubQuestionID = anssheet_detail.SubQuestionID;
            this.Score = anssheet_detail.Score;
            this.Comment = anssheet_detail.Comment;
            this.AnswerSheetFile = anssheet_detail.AnswerSheetFile;
        }

        public override bool Equals(object obj)
        {
            Quiz.ANSWERSHEET_DETAILS anssheet_detail = (Quiz.ANSWERSHEET_DETAILS)obj;
            if (this.ChoosenAnswer != anssheet_detail.ChoosenAnswer)
                return false;
            if (this.AnswerContent != anssheet_detail.AnswerContent)
                return false;
            if (this.LastTime != anssheet_detail.LastTime)
                return false;
            if (this.Status != anssheet_detail.Status)
                return false;
            if (this.AnswerSheetID != anssheet_detail.AnswerSheetID)
                return false;
            if (this.SubQuestionID != anssheet_detail.SubQuestionID)
                return false;
            if (this.Score != anssheet_detail.Score)
                return false;
            if (this.Comment != anssheet_detail.Comment)
                return false;
            if (this.AnswerSheetFile != anssheet_detail.AnswerSheetFile)
                return false;
            return true;
        }

        public static bool operator ==(ANSWERSHEET_DETAILS anssheet_detail1, Quiz.ANSWERSHEET_DETAILS anssheet_detail2)
        {
            return anssheet_detail1.Equals(anssheet_detail2);
        }

        public static bool operator !=(ANSWERSHEET_DETAILS anssheet_detail1, Quiz.ANSWERSHEET_DETAILS anssheet_detail2)
        {
            return !anssheet_detail1.Equals(anssheet_detail2);
        }
    }

    public partial class ANSWERSHEET_SPEAKING
    {
        public ANSWERSHEET_SPEAKING(Quiz.ANSWERSHEET_SPEAKING anssheet_speak)
        {
            this.AnswerSheetSpeakingID = anssheet_speak.AnswerSheetSpeakingID;
            this.AnswerSheetID = anssheet_speak.AnswerSheetID;
            this.SpeakingScore = anssheet_speak.SpeakingScore;
            this.SpeakingScore2 = anssheet_speak.SpeakingScore2;
            this.Status = anssheet_speak.Status;

            SPEAKING_TEACHER = new HashSet<SPEAKING_TEACHER>();
        }

        public override bool Equals(object obj)
        {
            Quiz.ANSWERSHEET_SPEAKING anssheet_speak = (Quiz.ANSWERSHEET_SPEAKING)obj;
            if (this.AnswerSheetID != anssheet_speak.AnswerSheetID)
                return false;
            if (this.SpeakingScore != anssheet_speak.SpeakingScore)
                return false;
            if (this.SpeakingScore2 != anssheet_speak.SpeakingScore2)
                return false;
            if (this.Status != anssheet_speak.Status)
                return false;
            return true;
        }

        public static bool operator ==(ANSWERSHEET_SPEAKING anssheet_speak1, Quiz.ANSWERSHEET_SPEAKING anssheet_speak2)
        {
            return anssheet_speak1.Equals(anssheet_speak2);
        }

        public static bool operator !=(ANSWERSHEET_SPEAKING anssheet_speak1, Quiz.ANSWERSHEET_SPEAKING anssheet_speak2)
        {
            return !anssheet_speak1.Equals(anssheet_speak2);
        }
    }

    public partial class ANSWERSHEET_WRITING
    {
        public ANSWERSHEET_WRITING(Quiz.ANSWERSHEET_WRITING anssheet_writing)
        {
            this.AnswerSheetWritingID = anssheet_writing.AnswerSheetWritingID;
            this.AnswerSheetID = anssheet_writing.AnswerSheetID;
            this.WritingScore = anssheet_writing.WritingScore;
            this.WritingScore2 = anssheet_writing.WritingScore2;
            this.Status = anssheet_writing.Status;

            WRITING_TEACHER = new HashSet<WRITING_TEACHER>();
        }

        public override bool Equals(object obj)
        {
            Quiz.ANSWERSHEET_WRITING anssheet_writing = (Quiz.ANSWERSHEET_WRITING)obj;
            if (this.AnswerSheetID != anssheet_writing.AnswerSheetID)
                return false;
            if (this.WritingScore != anssheet_writing.WritingScore)
                return false;
            if (this.WritingScore2 != anssheet_writing.WritingScore2)
                return false;
            if (this.Status != anssheet_writing.Status)
                return false;
            return true;
        }

        public static bool operator ==(ANSWERSHEET_WRITING anssheet_writing1, Quiz.ANSWERSHEET_WRITING anssheet_writing2)
        {
            return anssheet_writing1.Equals(anssheet_writing2);
        }

        public static bool operator !=(ANSWERSHEET_WRITING anssheet_writing1, Quiz.ANSWERSHEET_WRITING anssheet_writing2)
        {
            return !anssheet_writing1.Equals(anssheet_writing2);
        }
    }

    public partial class BAGOFTEST
    {
        public BAGOFTEST(Quiz.BAGOFTEST bag)
        {
            this.BagOfTestID = bag.BagOfTestID;
            this.NumberOfTest = bag.NumberOfTest;
            this.Status = bag.Status;
            this.DivisionShiftID = bag.DivisionShiftID;

            TESTS = new HashSet<TEST>();
        }

        public override bool Equals(object obj)
        {
            Quiz.BAGOFTEST bag = (Quiz.BAGOFTEST)obj;
            if (this.NumberOfTest != bag.NumberOfTest)
                return false;
            if (this.Status != bag.Status)
                return false;
            if (this.DivisionShiftID != bag.DivisionShiftID)
                return false;
            return true;
        }

        public static bool operator ==(BAGOFTEST bag1, Quiz.BAGOFTEST bag2)
        {
            return bag1.Equals(bag2);
        }

        public static bool operator !=(BAGOFTEST bag1, Quiz.BAGOFTEST bag2)
        {
            return !bag1.Equals(bag2);
        }
    }

    public partial class CONTEST
    {
        public CONTEST(Quiz.CONTEST cont)
        {
            this.ContestID = cont.ContestID;
            this.AcceptedDate = cont.AcceptedDate;
            this.AcceptedStaffID = cont.AcceptedStaffID;
            this.BeginRegistration = cont.BeginRegistration;
            this.ContestName = cont.ContestName;
            this.CreatedDate = cont.CreatedDate;
            this.CreatedQuestionEndDate = cont.CreatedQuestionEndDate;
            this.CreatedQuestionStartDate = cont.CreatedQuestionStartDate;
            this.CreatedStaffID = cont.CreatedStaffID;
            this.Description = cont.Description;
            this.EndDate = cont.EndDate;
            this.EndRegistration = cont.EndRegistration;
            this.SchoolYear = cont.SchoolYear;
            this.Status = cont.Status;

            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            LOCATIONS = new HashSet<LOCATION>();
            SHIFTS = new HashSet<SHIFT>();
        }

        public override bool Equals(object obj)
        {
            Quiz.CONTEST cont = (Quiz.CONTEST)obj;
            if (this.ContestName != cont.ContestName)
                return false;
            if (this.CreatedDate != cont.CreatedDate)
                return false;
            if (this.EndDate != cont.EndDate)
                return false;
            if (this.AcceptedDate != cont.AcceptedDate)
                return false;
            if (this.BeginRegistration != cont.BeginRegistration)
                return false;
            if (this.EndRegistration != cont.EndRegistration)
                return false;
            if (this.CreatedQuestionStartDate != cont.CreatedQuestionStartDate)
                return false;
            if (this.CreatedQuestionEndDate != cont.CreatedQuestionEndDate)
                return false;
            return true;
        }

        public static bool operator ==(CONTEST c1, Quiz.CONTEST c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(CONTEST c1, Quiz.CONTEST c2)
        {
            return !c1.Equals(c2);
        }
    }

    public partial class CONTESTANT
    {
        public CONTESTANT(Quiz.CONTESTANT contestant)
        {
            this.ContestantID = contestant.ContestantID;
            this.ContestantCode = contestant.ContestantCode;
            this.ContestantType = contestant.ContestantType;
            this.FullName = contestant.FullName;
            this.DOB = contestant.DOB;
            this.Ethnic = contestant.Ethnic;
            this.PlaceOfBirth = contestant.PlaceOfBirth;
            this.HighSchool = contestant.HighSchool;
            this.Sex = contestant.Sex;
            this.IdentityCardNumber = contestant.IdentityCardNumber;
            this.Unit = contestant.Unit;
            this.CurrentAddress = contestant.CurrentAddress;
            this.TrainingSystem = contestant.TrainingSystem;
            this.StudentCode = contestant.StudentCode;
            this.Image = contestant.Image;
            this.Status = contestant.Status;

            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            FINGERPRINTS = new HashSet<FINGERPRINT>();
        }

        public override bool Equals(object obj)
        {
            Quiz.CONTESTANT contestant = (Quiz.CONTESTANT)obj;
            if (this.ContestantCode != contestant.ContestantCode)
                return false;
            if (this.ContestantType != contestant.ContestantType)
                return false;
            if (this.FullName != contestant.FullName)
                return false;
            if (this.DOB != contestant.DOB)
                return false;
            if (this.Ethnic != contestant.Ethnic)
                return false;
            if (this.PlaceOfBirth != contestant.PlaceOfBirth)
                return false;
            if (this.HighSchool != contestant.HighSchool)
                return false;
            if (this.Sex != contestant.Sex)
                return false;
            if (this.IdentityCardNumber != contestant.IdentityCardNumber)
                return false;
            if (this.Unit != contestant.Unit)
                return false;
            if (this.CurrentAddress != contestant.CurrentAddress)
                return false;
            if (this.TrainingSystem != contestant.TrainingSystem)
                return false;
            if (this.StudentCode != contestant.StudentCode)
                return false;
            if (this.Image != contestant.Image)
                return false;
            if (this.Status != contestant.Status)
                return false;
            return true;
        }

        public static bool operator ==(CONTESTANT contestant1, Quiz.CONTESTANT contestant2)
        {
            return contestant1.Equals(contestant2);
        }

        public static bool operator !=(CONTESTANT contestant1, Quiz.CONTESTANT contestant2)
        {
            return !contestant1.Equals(contestant2);
        }
    }

    public partial class CONTESTANTPAUSE
    {
        public CONTESTANTPAUSE()
        {

        }

        public CONTESTANTPAUSE(Quiz.CONTESTANTPAUSE conpause)
        {
            this.ContestantPauseID = conpause.ContestantPauseID;
            this.ContestantTestID = conpause.ContestantTestID;
            this.ContestantPauseClickTime = conpause.ContestantPauseClickTime;
            this.ContestantRealPauseTime = conpause.ContestantRealPauseTime;
            this.ContestantRealRestartTime = conpause.ContestantRealRestartTime;
            this.Note = conpause.Note;
            this.ContestantRestartTime = conpause.ContestantRestartTime;
        }

        public override bool Equals(object obj)
        {
            Quiz.CONTESTANTPAUSE conpause = (Quiz.CONTESTANTPAUSE)obj;
            if (this.ContestantTestID != conpause.ContestantTestID)
                return false;
            if (this.ContestantPauseClickTime != conpause.ContestantPauseClickTime)
                return false;
            if (this.ContestantRealPauseTime != conpause.ContestantRealPauseTime)
                return false;
            if (this.ContestantRestartTime != conpause.ContestantRestartTime)
                return false;
            if (this.Note != conpause.Note)
                return false;
            if (this.ContestantRealRestartTime != conpause.ContestantRealRestartTime)
                return false;
            return true;
        }

        public static bool operator ==(CONTESTANTPAUSE conpause1, Quiz.CONTESTANTPAUSE conpause2)
        {
            return conpause1.Equals(conpause2);
        }

        public static bool operator !=(CONTESTANTPAUSE conpause1, Quiz.CONTESTANTPAUSE conpause2)
        {
            return !conpause1.Equals(conpause2);
        }
    }

    public partial class CONTESTANTS_SHIFTS
    {
        public CONTESTANTS_SHIFTS(Quiz.CONTESTANTS_SHIFTS con_shift)
        {
            this.ContestantShiftID = con_shift.ContestantShiftID;
            this.Status = con_shift.Status;
            this.IsCheckFingerprint = con_shift.IsCheckFingerprint;
            this.TimeCheck = con_shift.TimeCheck;
            this.TimeStarted = con_shift.TimeStarted;
            this.TimeWorked = con_shift.TimeWorked;
            this.DivisionShiftID = con_shift.DivisionShiftID;
            this.ScheduleID = con_shift.ScheduleID;
            this.ContestantID = con_shift.ContestantID;
            this.RoomDiagramID = con_shift.RoomDiagramID;

            CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            TESTNUMBERs = new HashSet<TESTNUMBER>();
            VIOLATIONS_CONTESTANTS = new HashSet<VIOLATIONS_CONTESTANTS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.CONTESTANTS_SHIFTS con_shift = (Quiz.CONTESTANTS_SHIFTS)obj;
            if (this.Status != con_shift.Status)
                return false;
            if (this.IsCheckFingerprint != con_shift.IsCheckFingerprint)
                return false;
            if (this.TimeCheck != con_shift.TimeCheck)
                return false;
            if (this.TimeStarted != con_shift.TimeStarted)
                return false;
            if (this.TimeWorked != con_shift.TimeWorked)
                return false;
            if (this.DivisionShiftID != con_shift.DivisionShiftID)
                return false;
            if (this.ScheduleID != con_shift.ScheduleID)
                return false;
            if (this.ContestantID != con_shift.ContestantID)
                return false;
            if (this.RoomDiagramID != con_shift.RoomDiagramID)
                return false;
            return true;
        }

        public static bool operator ==(CONTESTANTS_SHIFTS con_shift1, Quiz.CONTESTANTS_SHIFTS con_shift2)
        {
            return con_shift1.Equals(con_shift2);
        }

        public static bool operator !=(CONTESTANTS_SHIFTS con_shift1, Quiz.CONTESTANTS_SHIFTS con_shift2)
        {
            return !con_shift1.Equals(con_shift2);
        }
    }

    public partial class CONTESTANTS_TESTS
    {
        public CONTESTANTS_TESTS(Quiz.CONTESTANTS_TESTS con_test)
        {
            this.ContestantTestID = con_test.ContestantTestID;
            this.Status = con_test.Status;
            this.ContestantShiftID = con_test.ContestantShiftID;
            this.TestID = con_test.TestID;
            this.SubmitTime = con_test.SubmitTime;
            this.ContestantAddTime = con_test.ContestantAddTime;

            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            CONTESTANTPAUSEs = new HashSet<CONTESTANTPAUSE>();
        }

        public override bool Equals(object obj)
        {
            Quiz.CONTESTANTS_TESTS con_test = (Quiz.CONTESTANTS_TESTS)obj;
            if (this.Status != con_test.Status)
                return false;
            if (this.ContestantShiftID != con_test.ContestantShiftID)
                return false;
            if (this.TestID != con_test.TestID)
                return false;
            if (this.SubmitTime != con_test.SubmitTime)
                return false;
            if (this.ContestantShiftID != con_test.ContestantShiftID)
                return false;
            return true;
        }

        public static bool operator ==(CONTESTANTS_TESTS con_test1, Quiz.CONTESTANTS_TESTS con_test2)
        {
            return con_test1.Equals(con_test2);
        }

        public static bool operator !=(CONTESTANTS_TESTS con_test1, Quiz.CONTESTANTS_TESTS con_test2)
        {
            return !con_test1.Equals(con_test2);
        }
    }

    public partial class DIVISION_SHIFTS
    {
        public DIVISION_SHIFTS(Quiz.DIVISION_SHIFTS div_shift)
        {
            this.DivisionShiftID = div_shift.DivisionShiftID;
            this.Status = div_shift.Status;
            this.ShiftID = div_shift.ShiftID;
            this.RoomTestID = div_shift.RoomTestID;
            this.Key = div_shift.Key;
            this.CheckFinger = div_shift.CheckFinger;
            this.StartDate = div_shift.StartDate;
            this.StartTime = div_shift.StartTime;
            this.EndTime = div_shift.EndTime;
            this.DivisionShiftAddTime = div_shift.DivisionShiftAddTime;

            BAGOFTESTS = new HashSet<BAGOFTEST>();
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            DIVISIONSHIFT_SUPERVISOR = new HashSet<DIVISIONSHIFT_SUPERVISOR>();
            DIVSIONSHIFT_PAUSE = new HashSet<DIVSIONSHIFT_PAUSE>();
        }

        public override bool Equals(object obj)
        {
            Quiz.DIVISION_SHIFTS div_shift = (Quiz.DIVISION_SHIFTS)obj;
            if (this.Status != div_shift.Status)
                return false;
            if (this.ShiftID != div_shift.ShiftID)
                return false;
            if (this.RoomTestID != div_shift.RoomTestID)
                return false;
            if (this.Key != div_shift.Key)
                return false;
            if (this.CheckFinger != div_shift.CheckFinger)
                return false;
            if (this.StartDate != div_shift.StartDate)
                return false;
            if (this.StartTime != div_shift.StartTime)
                return false;
            if (this.EndTime != div_shift.EndTime)
                return false;
            if (this.DivisionShiftAddTime != div_shift.DivisionShiftAddTime)
                return false;
            return true;
        }

        public static bool operator ==(DIVISION_SHIFTS div_shift1, Quiz.DIVISION_SHIFTS div_shift2)
        {
            return div_shift1.Equals(div_shift2);
        }

        public static bool operator !=(DIVISION_SHIFTS div_shift1, Quiz.DIVISION_SHIFTS div_shift2)
        {
            return !div_shift1.Equals(div_shift2);
        }
    }

    public partial class DIVISIONSHIFT_SUPERVISOR
    {
        public DIVISIONSHIFT_SUPERVISOR()
        {

        }

        public DIVISIONSHIFT_SUPERVISOR(Quiz.DIVISIONSHIFT_SUPERVISOR div_supvi)
        {
            this.DivisionShift_SupervisorID = div_supvi.DivisionShift_SupervisorID;
            this.SupervisorID = div_supvi.SupervisorID;
            this.DivisionShiftID = div_supvi.DivisionShiftID;
        }

        public override bool Equals(object obj)
        {
            Quiz.DIVISIONSHIFT_SUPERVISOR div_supvi = (Quiz.DIVISIONSHIFT_SUPERVISOR)obj;
            if (this.SupervisorID != div_supvi.SupervisorID)
                return false;
            if (this.DivisionShiftID != div_supvi.DivisionShiftID)
                return false;
            return true;
        }

        public static bool operator ==(DIVISIONSHIFT_SUPERVISOR div_supvi1, Quiz.DIVISIONSHIFT_SUPERVISOR div_supvi2)
        {
            return div_supvi1.Equals(div_supvi2);
        }

        public static bool operator !=(DIVISIONSHIFT_SUPERVISOR div_supvi1, Quiz.DIVISIONSHIFT_SUPERVISOR div_supvi2)
        {
            return !div_supvi1.Equals(div_supvi2);
        }
    }

    public partial class DIVSIONSHIFT_PAUSE
    {
        public DIVSIONSHIFT_PAUSE()
        {

        }

        public DIVSIONSHIFT_PAUSE(Quiz.DIVSIONSHIFT_PAUSE div_pause)
        {
            this.DivisionShiftPauseID = div_pause.DivisionShiftPauseID;
            this.DivisionShiftID = div_pause.DivisionShiftID;
            this.DivisionShiftPauseClickTime = div_pause.DivisionShiftPauseClickTime;
            this.DivisionShiftRealPauseTime = div_pause.DivisionShiftRealPauseTime;
            this.DivisionShiftRestartTime = div_pause.DivisionShiftRestartTime;
            this.Note = div_pause.Note;
        }

        public override bool Equals(object obj)
        {
            Quiz.DIVSIONSHIFT_PAUSE div_pause = (Quiz.DIVSIONSHIFT_PAUSE)obj;
            if (this.DivisionShiftID != div_pause.DivisionShiftID)
                return false;
            if (this.DivisionShiftPauseClickTime != div_pause.DivisionShiftPauseClickTime)
                return false;
            if (this.DivisionShiftRealPauseTime != div_pause.DivisionShiftRealPauseTime)
                return false;
            if (this.DivisionShiftRestartTime != div_pause.DivisionShiftRestartTime)
                return false;
            if (this.Note != div_pause.Note)
                return false;
            return true;
        }

        public static bool operator ==(DIVSIONSHIFT_PAUSE div_pause1, Quiz.DIVSIONSHIFT_PAUSE div_pause2)
        {
            return div_pause1.Equals(div_pause2);
        }

        public static bool operator !=(DIVSIONSHIFT_PAUSE div_pause1, Quiz.DIVSIONSHIFT_PAUSE div_pause2)
        {
            return !div_pause1.Equals(div_pause2);
        }
    }

    public partial class EXAMINATIONCOUNCIL_POSITIONS
    {
        public EXAMINATIONCOUNCIL_POSITIONS(Quiz.EXAMINATIONCOUNCIL_POSITIONS exc_pos)
        {
            this.ExaminationCouncil_PositionID = exc_pos.ExaminationCouncil_PositionID;
            this.ExaminationCouncil_PositionCode = exc_pos.ExaminationCouncil_PositionCode;
            this.ExaminationCouncil_PositionName = exc_pos.ExaminationCouncil_PositionName;
            this.Permission = exc_pos.Permission;
            this.Status = exc_pos.Status;

            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.EXAMINATIONCOUNCIL_POSITIONS exc_pos = (Quiz.EXAMINATIONCOUNCIL_POSITIONS)obj;
            if (this.ExaminationCouncil_PositionCode != exc_pos.ExaminationCouncil_PositionCode)
                return false;
            if (this.ExaminationCouncil_PositionName != exc_pos.ExaminationCouncil_PositionName)
                return false;
            if (this.Permission != exc_pos.Permission)
                return false;
            if (this.Status != exc_pos.Status)
                return false;
            return true;
        }

        public static bool operator ==(EXAMINATIONCOUNCIL_POSITIONS exc_pos1, Quiz.EXAMINATIONCOUNCIL_POSITIONS exc_pos2)
        {
            return exc_pos1.Equals(exc_pos2);
        }

        public static bool operator !=(EXAMINATIONCOUNCIL_POSITIONS exc_pos1, Quiz.EXAMINATIONCOUNCIL_POSITIONS exc_pos2)
        {
            return !exc_pos1.Equals(exc_pos2);
        }
    }

    public partial class EXAMINATIONCOUNCIL_STAFFS
    {
        public EXAMINATIONCOUNCIL_STAFFS(Quiz.EXAMINATIONCOUNCIL_STAFFS exc_stf)
        {
            this.ExaminationCouncil_StaffID = exc_stf.ExaminationCouncil_StaffID;
            this.StaffID = exc_stf.StaffID;
            this.ExaminationCouncil_PositionID = exc_stf.ExaminationCouncil_PositionID;
            this.LocationID = exc_stf.LocationID;
            this.UserName = exc_stf.UserName;
            this.Password = exc_stf.Password;
            this.Status = exc_stf.Status;
            this.ContestID = exc_stf.ContestID;

            DIVISIONSHIFT_SUPERVISOR = new HashSet<DIVISIONSHIFT_SUPERVISOR>();
        }

        public override bool Equals(object obj)
        {
            Quiz.EXAMINATIONCOUNCIL_STAFFS exc_stf = (Quiz.EXAMINATIONCOUNCIL_STAFFS)obj;
            if (this.StaffID != exc_stf.StaffID)
                return false;
            if (this.ExaminationCouncil_PositionID != exc_stf.ExaminationCouncil_PositionID)
                return false;
            if (this.LocationID != exc_stf.LocationID)
                return false;
            if (this.UserName != exc_stf.UserName)
                return false;
            if (this.Password != exc_stf.Password)
                return false;
            if (this.Status != exc_stf.Status)
                return false;
            if (this.ContestID != exc_stf.ContestID)
                return false;
            return true;
        }

        public static bool operator ==(EXAMINATIONCOUNCIL_STAFFS exc_stf1, Quiz.EXAMINATIONCOUNCIL_STAFFS exc_stf2)
        {
            return exc_stf1.Equals(exc_stf2);
        }

        public static bool operator !=(EXAMINATIONCOUNCIL_STAFFS exc_stf1, Quiz.EXAMINATIONCOUNCIL_STAFFS exc_stf2)
        {
            return !exc_stf1.Equals(exc_stf2);
        }
    }

    public partial class FINGERPRINT
    {
        public FINGERPRINT()
        {

        }

        public FINGERPRINT(Quiz.FINGERPRINT fing)
        {
            this.FingerprintID = fing.FingerprintID;
            this.FingerprintImage = fing.FingerprintImage;
            this.FilePath = fing.FilePath;
            this.TimeSaveFingerprint = fing.TimeSaveFingerprint;
            this.Status = fing.Status;
            this.ContestantID = fing.ContestantID;
        }

        public override bool Equals(object obj)
        {
            Quiz.FINGERPRINT fing = (Quiz.FINGERPRINT)obj;
            if (this.FingerprintImage != fing.FingerprintImage)
                return false;
            if (this.FilePath != fing.FilePath)
                return false;
            if (this.TimeSaveFingerprint != fing.TimeSaveFingerprint)
                return false;
            if (this.Status != fing.Status)
                return false;
            if (this.ContestantID != fing.ContestantID)
                return false;
            return true;
        }

        public static bool operator ==(FINGERPRINT fing1, Quiz.FINGERPRINT fing2)
        {
            return fing1.Equals(fing2);
        }

        public static bool operator !=(FINGERPRINT fing1, Quiz.FINGERPRINT fing2)
        {
            return !fing1.Equals(fing2);
        }
    }

    public partial class LOCATION
    {
        public LOCATION(Quiz.LOCATION loca)
        {
            this.LocationID = loca.LocationID;
            this.LocationName = loca.LocationName;
            this.Status = loca.Status;
            this.ContestID = loca.ContestID;

            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            ROOMTESTS = new HashSet<ROOMTEST>();
        }

        public override bool Equals(object obj)
        {
            Quiz.LOCATION loca = (Quiz.LOCATION)obj;
            if (this.LocationName != loca.LocationName)
                return false;
            if (this.Status != loca.Status)
                return false;
            if (this.ContestID != loca.ContestID)
                return false;
            return true;
        }

        public static bool operator ==(LOCATION loca1, Quiz.LOCATION loca2)
        {
            return loca1.Equals(loca2);
        }

        public static bool operator !=(LOCATION loca1, Quiz.LOCATION loca2)
        {
            return !loca1.Equals(loca2);
        }
    }

    public partial class PART
    {
        public PART()
        {

        }

        public PART(Quiz.PART part)
        {
            this.PartID = part.PartID;
            this.CreatedDate = part.CreatedDate;
            this.Status = part.Status;
            this.ScheduleID = part.ScheduleID;
            this.CreateStaffID = part.CreateStaffID;
            this.Name = part.Name;
            this.OrderOfQuestion = part.OrderOfQuestion;
            this.OrderInTest = part.OrderInTest;
            this.Shuffle = part.Shuffle;
        }

        public override bool Equals(object obj)
        {
            Quiz.PART part = (Quiz.PART)obj;
            if (this.CreatedDate != part.CreatedDate)
                return false;
            if (this.Status != part.Status)
                return false;
            if (this.ScheduleID != part.ScheduleID)
                return false;
            if (this.CreateStaffID != part.CreateStaffID)
                return false;
            if (this.Name != part.Name)
                return false;
            if (this.OrderOfQuestion != part.OrderOfQuestion)
                return false;
            if (this.OrderInTest != part.OrderInTest)
                return false;
            if (this.Shuffle != part.Shuffle)
                return false;
            return true;
        }

        public static bool operator ==(PART part1, Quiz.PART part2)
        {
            return part1.Equals(part2);
        }

        public static bool operator !=(PART part1, Quiz.PART part2)
        {
            return !part1.Equals(part2);
        }
    }

    public partial class POSITION
    {
        public POSITION(Quiz.POSITION pos)
        {
            this.PositionID = pos.PositionID;
            this.PositionCode = pos.PositionCode;
            this.PositionName = pos.PositionName;
            this.Permission = pos.Permission;
            this.Status = pos.Status;

            STAFFS_POSITIONS = new HashSet<STAFFS_POSITIONS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.POSITION pos = (Quiz.POSITION)obj;
            if (this.PositionCode != pos.PositionCode)
                return false;
            if (this.PositionName != pos.PositionName)
                return false;
            if (this.Permission != pos.Permission)
                return false;
            if (this.Status != pos.Status)
                return false;
            return true;
        }

        public static bool operator ==(POSITION p1, Quiz.POSITION p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(POSITION p1, Quiz.POSITION p2)
        {
            return !p1.Equals(p2);
        }
    }

    public partial class QUESTION
    {
        public QUESTION(Quiz.QUESTION ques)
        {
            this.QuestionID = ques.QuestionID;
            this.QuestionContent = ques.QuestionContent;
            this.QuestionFormat = ques.QuestionFormat;
            this.Level = ques.Level;
            this.IsQuiz = ques.IsQuiz;
            this.IsSingleChoice = ques.IsSingleChoice;
            this.IsParagraph = ques.IsParagraph;
            this.IsQuestionContent = ques.IsQuestionContent;
            this.NumberSubQuestion = ques.NumberSubQuestion;
            this.NumberAnswer = ques.NumberAnswer;
            this.Type = ques.Type;
            this.Audio = ques.Audio;
            this.HeightToDisplay = ques.HeightToDisplay;

            SUBQUESTIONS = new HashSet<SUBQUESTION>();
            TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.QUESTION ques = (Quiz.QUESTION)obj;
            // Vì QuestionID được chuyển về với giá trị giống với MTAQuiz trên Server thi
            // nên nếu ID đã có tức đã chuyển (mục đích chuyển giá trị giống với MTAQuiz
            // trên Server thi là để đối chiếu với ExonSystem khi cần)
            // Do đó chỗ này hơi khác với các bảng khác
            if (this.QuestionID == ques.QuestionID)
                return true;
            if (this.QuestionContent != ques.QuestionContent)
                return false;
            if (this.QuestionFormat != ques.QuestionFormat)
                return false;
            if (this.Level != ques.Level)
                return false;
            if (this.IsQuiz != ques.IsQuiz)
                return false;
            if (this.IsSingleChoice != ques.IsSingleChoice)
                return false;
            if (this.IsParagraph != ques.IsParagraph)
                return false;
            if (this.IsQuestionContent != ques.IsQuestionContent)
                return false;
            if (this.NumberSubQuestion != ques.NumberSubQuestion)
                return false;
            if (this.NumberAnswer != ques.NumberAnswer)
                return false;
            if (this.Type != ques.Type)
                return false;
            if (this.Audio != ques.Audio)
                return false;
            if (this.HeightToDisplay != ques.HeightToDisplay)
                return false;
            return true;
        }

        public static bool operator ==(QUESTION ques1, Quiz.QUESTION ques2)
        {
            return ques1.Equals(ques2);
        }

        public static bool operator !=(QUESTION ques1, Quiz.QUESTION ques2)
        {
            return !ques1.Equals(ques2);
        }
    }

    public partial class QUESTIONS_TEMP
    {
        public QUESTIONS_TEMP()
        {

        }

        public QUESTIONS_TEMP(Quiz.QUESTIONS_TEMP ques_temp)
        {
            this.QuestionTempID = ques_temp.QuestionTempID;
            this.QuestionID = ques_temp.QuestionID;
            this.QuestionContent = ques_temp.QuestionContent;
            this.QuestionFormat = ques_temp.QuestionFormat;
            this.Level = ques_temp.Level;
            this.IsQuiz = ques_temp.IsQuiz;
            this.IsSingleChoice = ques_temp.IsSingleChoice;
            this.IsParagarph = ques_temp.IsParagarph;
            this.IsQuestionContent = ques_temp.IsQuestionContent;
            this.NumberSubQuestion = ques_temp.NumberSubQuestion;
            this.NumberAnswer = ques_temp.NumberAnswer;
            this.DivisionShiftID = ques_temp.DivisionShiftID;
            this.Type = ques_temp.Type;
            this.Audio = ques_temp.Audio;
        }

        public override bool Equals(object obj)
        {
            Quiz.QUESTIONS_TEMP ques_temp = (Quiz.QUESTIONS_TEMP)obj;
            if (this.QuestionID != ques_temp.QuestionID)
                return false;
            if (this.QuestionContent != ques_temp.QuestionContent)
                return false;
            if (this.QuestionFormat != ques_temp.QuestionFormat)
                return false;
            if (this.Level != ques_temp.Level)
                return false;
            if (this.IsQuiz != ques_temp.IsQuiz)
                return false;
            if (this.IsSingleChoice != ques_temp.IsSingleChoice)
                return false;
            if (this.IsParagarph != ques_temp.IsParagarph)
                return false;
            if (this.IsQuestionContent != ques_temp.IsQuestionContent)
                return false;
            if (this.NumberSubQuestion != ques_temp.NumberSubQuestion)
                return false;
            if (this.NumberAnswer != ques_temp.NumberAnswer)
                return false;
            if (this.DivisionShiftID != ques_temp.DivisionShiftID)
                return false;
            if (this.Type != ques_temp.Type)
                return false;
            if (this.Audio != ques_temp.Audio)
                return false;
            return true;
        }

        public static bool operator ==(QUESTIONS_TEMP ques_temp1, Quiz.QUESTIONS_TEMP ques_temp2)
        {
            return ques_temp1.Equals(ques_temp2);
        }

        public static bool operator !=(QUESTIONS_TEMP ques_temp1, Quiz.QUESTIONS_TEMP ques_temp2)
        {
            return !ques_temp1.Equals(ques_temp2);
        }
    }

    public partial class ROOMDIAGRAM
    {
        public ROOMDIAGRAM(Quiz.ROOMDIAGRAM roomdia)
        {
            this.RoomDiagramID = roomdia.RoomDiagramID;
            this.ComputerCode = roomdia.ComputerCode;
            this.ComputerName = roomdia.ComputerName;
            this.ClientIP = roomdia.ClientIP;
            this.Description = roomdia.Description;
            this.Status = roomdia.Status;
            this.RoomTestID = roomdia.RoomTestID;

            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.ROOMDIAGRAM roomdia = (Quiz.ROOMDIAGRAM)obj;
            if (this.ComputerCode != roomdia.ComputerCode)
                return false;
            if (this.ComputerName != roomdia.ComputerName)
                return false;
            if (this.ClientIP != roomdia.ClientIP)
                return false;
            if (this.Description != roomdia.Description)
                return false;
            if (this.Status != roomdia.Status)
                return false;
            if (this.RoomTestID != roomdia.RoomTestID)
                return false;
            return true;
        }

        public static bool operator ==(ROOMDIAGRAM roomdia1, Quiz.ROOMDIAGRAM roomdia2)
        {
            return roomdia1.Equals(roomdia2);
        }

        public static bool operator !=(ROOMDIAGRAM roomdia1, Quiz.ROOMDIAGRAM roomdia2)
        {
            return !roomdia1.Equals(roomdia2);
        }
    }

    public partial class ROOMTEST
    {
        public ROOMTEST(Quiz.ROOMTEST roomtest)
        {
            this.RoomTestID = roomtest.RoomTestID;
            this.RoomTestName = roomtest.RoomTestName;
            this.MaxSeatMount = roomtest.MaxSeatMount;
            this.MaxSupervisor = roomtest.MaxSupervisor;
            this.Status = roomtest.Status;
            this.LocationID = roomtest.LocationID;

            DIVISION_SHIFTS = new HashSet<DIVISION_SHIFTS>();
            ROOMDIAGRAMS = new HashSet<ROOMDIAGRAM>();
        }

        public override bool Equals(object obj)
        {
            Quiz.ROOMTEST roomtest = (Quiz.ROOMTEST)obj;
            if (this.RoomTestName != roomtest.RoomTestName)
                return false;
            if (this.MaxSeatMount != roomtest.MaxSeatMount)
                return false;
            if (this.MaxSupervisor != roomtest.MaxSupervisor)
                return false;
            if (this.Status != roomtest.Status)
                return false;
            if (this.LocationID != roomtest.LocationID)
                return false;
            return true;
        }

        public static bool operator ==(ROOMTEST roomtest1, Quiz.ROOMTEST roomtest2)
        {
            return roomtest1.Equals(roomtest2);
        }

        public static bool operator !=(ROOMTEST roomtest1, Quiz.ROOMTEST roomtest2)
        {
            return !roomtest1.Equals(roomtest2);
        }
    }

    public partial class SCHEDULE
    {
        public SCHEDULE(Quiz.SCHEDULE sche)
        {
            this.ScheduleID = sche.ScheduleID;
            this.TimeToSubmit = sche.TimeToSubmit;
            this.TimeOfTest = sche.TimeOfTest;
            this.Status = sche.Status;
            this.ContestID = sche.ContestID;
            this.ContestTypeName = sche.ContestTypeName;
            this.SubjectID = sche.SubjectID;

            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            PARTS = new HashSet<PART>();
        }

        public override bool Equals(object obj)
        {
            Quiz.SCHEDULE sche = (Quiz.SCHEDULE)obj;
            if (this.TimeOfTest != sche.TimeOfTest)
                return false;
            if (this.TimeToSubmit != sche.TimeToSubmit)
                return false;
            if (this.Status != sche.Status)
                return false;
            if (this.ContestID != sche.ContestID)
                return false;
            if (this.ContestTypeName != sche.ContestTypeName)
                return false;
            if (this.SubjectID != sche.SubjectID)
                return false;
            return true;
        }

        public static bool operator ==(SCHEDULE sche1, Quiz.SCHEDULE sche2)
        {
            return sche1.Equals(sche2);
        }

        public static bool operator !=(SCHEDULE sche1, Quiz.SCHEDULE sche2)
        {
            return !sche1.Equals(sche2);
        }
    }

    public partial class SHIFT
    {
        public SHIFT(Quiz.SHIFT shift)
        {
            this.ShiftID = shift.ShiftID;
            this.ShiftName = shift.ShiftName;
            this.ShiftDate = shift.ShiftDate;
            this.StartTime = shift.StartTime;
            this.EndTime = shift.EndTime;
            this.Status = shift.Status;
            this.ContestID = shift.ContestID;
            this.ShiftAddTime = shift.ShiftAddTime;

            DIVISION_SHIFTS = new HashSet<DIVISION_SHIFTS>();
            SHIFTSPAUSEs = new HashSet<SHIFTSPAUSE>();
        }

        public override bool Equals(object obj)
        {
            Quiz.SHIFT shift = (Quiz.SHIFT)obj;
            if (this.ShiftName != shift.ShiftName)
                return false;
            if (this.ShiftDate != shift.ShiftDate)
                return false;
            if (this.StartTime != shift.StartTime)
                return false;
            if (this.EndTime != shift.EndTime)
                return false;
            if (this.Status != shift.Status)
                return false;
            if (this.ContestID != shift.ContestID)
                return false;
            if (this.ShiftAddTime != shift.ShiftAddTime)
                return false;
            return true;
        }

        public static bool operator ==(SHIFT shift1, Quiz.SHIFT shift2)
        {
            return shift1.Equals(shift2);
        }

        public static bool operator !=(SHIFT shift1, Quiz.SHIFT shift2)
        {
            return !shift1.Equals(shift2);
        }
    }

    public partial class SHIFTSPAUSE
    {
        public SHIFTSPAUSE()
        {

        }

        public SHIFTSPAUSE(Quiz.SHIFTSPAUSE shps)
        {
            this.ShiftPauseID = shps.ShiftPauseID;
            this.ShiftID = shps.ShiftID;
            this.ShiftPauseClickTime = shps.ShiftPauseClickTime;
            this.ShiftRealPauseTime = shps.ShiftRealPauseTime;
            this.ShiftRestartTime = shps.ShiftRestartTime;
            this.Note = shps.Note;
        }

        public override bool Equals(object obj)
        {
            Quiz.SHIFTSPAUSE shps = (Quiz.SHIFTSPAUSE)obj;
            if (this.ShiftID != shps.ShiftID)
                return false;
            if (this.ShiftPauseClickTime != shps.ShiftPauseClickTime)
                return false;
            if (this.ShiftRealPauseTime != shps.ShiftRealPauseTime)
                return false;
            if (this.ShiftRestartTime != shps.ShiftRestartTime)
                return false;
            if (this.Note != shps.Note)
                return false;
            return true;
        }

        public static bool operator ==(SHIFTSPAUSE shps1, Quiz.SHIFTSPAUSE shps2)
        {
            return shps1.Equals(shps2);
        }

        public static bool operator !=(SHIFTSPAUSE shps1, Quiz.SHIFTSPAUSE shps2)
        {
            return !shps1.Equals(shps2);
        }
    }

    public partial class SPEAKING_TEACHER
    {
        public SPEAKING_TEACHER()
        {

        }

        public SPEAKING_TEACHER(Quiz.SPEAKING_TEACHER speak_teach)
        {
            this.ID = speak_teach.ID;
            this.AnswerSheetSpeakingID = speak_teach.AnswerSheetSpeakingID;
            this.TeacherID = speak_teach.TeacherID;
            this.Status = speak_teach.Status;
        }

        public override bool Equals(object obj)
        {
            Quiz.SPEAKING_TEACHER speak_teach = (Quiz.SPEAKING_TEACHER)obj;
            if (this.AnswerSheetSpeakingID != speak_teach.AnswerSheetSpeakingID)
                return false;
            if (this.TeacherID != speak_teach.TeacherID)
                return false;
            if (this.Status != speak_teach.Status)
                return false;
            return true;
        }

        public static bool operator ==(SPEAKING_TEACHER speak_teach1, Quiz.SPEAKING_TEACHER speak_teach2)
        {
            return speak_teach1.Equals(speak_teach2);
        }

        public static bool operator !=(SPEAKING_TEACHER speak_teach1, Quiz.SPEAKING_TEACHER speak_teach2)
        {
            return !speak_teach1.Equals(speak_teach2);
        }
    }

    public partial class STAFF
    {
        public STAFF(Quiz.STAFF staff)
        {
            this.StaffID = staff.StaffID;
            this.FullName = staff.FullName;
            this.DOB = staff.DOB;
            this.Sex = staff.Sex;
            this.IdentityCardNumber = staff.IdentityCardNumber;
            this.AcademicRank = staff.AcademicRank;
            this.Degree = staff.Degree;
            this.Status = staff.Status;

            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            EXAMINATIONCOUNCIL_STAFFS = new HashSet<EXAMINATIONCOUNCIL_STAFFS>();
            PARTS = new HashSet<PART>();
            SPEAKING_TEACHER = new HashSet<SPEAKING_TEACHER>();
            STAFFS_POSITIONS = new HashSet<STAFFS_POSITIONS>();
            WRITING_TEACHER = new HashSet<WRITING_TEACHER>();
        }

        public override bool Equals(object obj)
        {
            Quiz.STAFF staff = (Quiz.STAFF)obj;
            if (this.FullName != staff.FullName)
                return false;
            if (this.DOB != staff.DOB)
                return false;
            if (this.Sex != staff.Sex)
                return false;
            if (this.IdentityCardNumber != staff.IdentityCardNumber)
                return false;
            if (this.AcademicRank != staff.AcademicRank)
                return false;
            if (this.Degree != staff.Degree)
                return false;
            if (this.Status != staff.Status)
                return false;
            return true;
        }

        public static bool operator ==(STAFF s1, Quiz.STAFF s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(STAFF s1, Quiz.STAFF s2)
        {
            return !s1.Equals(s2);
        }
    }

    public partial class STAFFS_POSITIONS
    {
        public STAFFS_POSITIONS()
        {

        }

        public STAFFS_POSITIONS(Quiz.STAFFS_POSITIONS stf_pos)
        {
            this.StaffPositionID = stf_pos.StaffPositionID;
            this.StaffID = stf_pos.StaffID;
            this.PositionID = stf_pos.PositionID;
        }

        public override bool Equals(object obj)
        {
            Quiz.STAFFS_POSITIONS stf_pos = (Quiz.STAFFS_POSITIONS)obj;
            if (this.StaffID != stf_pos.StaffID)
                return false;
            if (this.PositionID != stf_pos.PositionID)
                return false;
            return true;
        }

        public static bool operator ==(STAFFS_POSITIONS stf_pos1, Quiz.STAFFS_POSITIONS stf_pos2)
        {
            return stf_pos1.Equals(stf_pos2);
        }

        public static bool operator !=(STAFFS_POSITIONS stf_pos1, Quiz.STAFFS_POSITIONS stf_pos2)
        {
            return !stf_pos1.Equals(stf_pos2);
        }
    }

    public partial class SUBJECT
    {
        public SUBJECT(Quiz.SUBJECT subj)
        {
            this.SubjectID = subj.SubjectID;
            this.SubjectCode = subj.SubjectCode;
            this.SubjectName = subj.SubjectName;
            this.Status = subj.Status;

            SCHEDULES = new HashSet<SCHEDULE>();
            TESTS = new HashSet<TEST>();
        }

        public override bool Equals(object obj)
        {
            Quiz.SUBJECT subj = (Quiz.SUBJECT)obj;
            if (this.SubjectCode != subj.SubjectCode)
                return false;
            if (this.SubjectName != subj.SubjectName)
                return false;
            if (this.Status != subj.Status)
                return false;
            return true;
        }

        public static bool operator ==(SUBJECT subj1, Quiz.SUBJECT subj2)
        {
            return subj1.Equals(subj2);
        }

        public static bool operator !=(SUBJECT subj1, Quiz.SUBJECT subj2)
        {
            return !subj1.Equals(subj2);
        }
    }

    public partial class SUBQUESTION
    {
        public SUBQUESTION(Quiz.SUBQUESTION subq)
        {
            this.SubQuestionID = subq.SubQuestionID;
            this.SubQuestionContent = subq.SubQuestionContent;
            this.Score = subq.Score;
            this.QuestionID = subq.QuestionID;
            this.HeightToDisplay = subq.HeightToDisplay;

            ANSWERS = new HashSet<ANSWER>();
            ANSWERSHEET_DETAILS = new HashSet<ANSWERSHEET_DETAILS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.SUBQUESTION subq = (Quiz.SUBQUESTION)obj;
            // Cách giải thích giống với Question
            if (this.SubQuestionID == subq.SubQuestionID)
                return true;
            if (this.SubQuestionContent != subq.SubQuestionContent)
                return false;
            if (this.Score != subq.Score)
                return false;
            if (this.QuestionID != subq.QuestionID)
                return false;
            if (this.HeightToDisplay != subq.HeightToDisplay)
                return false;
            return true;
        }

        public static bool operator ==(SUBQUESTION subq1, Quiz.SUBQUESTION subq2)
        {
            return subq1.Equals(subq2);
        }

        public static bool operator !=(SUBQUESTION subq1, Quiz.SUBQUESTION subq2)
        {
            return !subq1.Equals(subq2);
        }
    }

    public partial class SUBQUESTIONS_TEMP
    {
        public SUBQUESTIONS_TEMP()
        {

        }

        public SUBQUESTIONS_TEMP(Quiz.SUBQUESTIONS_TEMP subques_temp)
        {
            this.SubQuestionTempID = subques_temp.SubQuestionTempID;
            this.SubQuestionID = subques_temp.SubQuestionID;
            this.SubQuestionContent = subques_temp.SubQuestionContent;
            this.Score = subques_temp.Score;
            this.QuestionID = subques_temp.QuestionID;
            this.QuestionTempID = subques_temp.QuestionTempID;
            this.DivisionShiftID = subques_temp.DivisionShiftID;
        }

        public override bool Equals(object obj)
        {
            Quiz.SUBQUESTIONS_TEMP subques_temp = (Quiz.SUBQUESTIONS_TEMP)obj;
            if (this.SubQuestionID != subques_temp.SubQuestionID)
                return false;
            if (this.SubQuestionContent != subques_temp.SubQuestionContent)
                return false;
            if (this.Score != subques_temp.Score)
                return false;
            if (this.QuestionID != subques_temp.QuestionID)
                return false;
            if (this.QuestionTempID != subques_temp.QuestionTempID)
                return false;
            if (this.DivisionShiftID != subques_temp.DivisionShiftID)
                return false;
            return true;
        }

        public static bool operator ==(SUBQUESTIONS_TEMP subques_temp1, Quiz.SUBQUESTIONS_TEMP subques_temp2)
        {
            return subques_temp1.Equals(subques_temp2);
        }

        public static bool operator !=(SUBQUESTIONS_TEMP subques_temp1, Quiz.SUBQUESTIONS_TEMP subques_temp2)
        {
            return !subques_temp1.Equals(subques_temp2);
        }
    }

    public partial class TEST
    {
        public TEST(Quiz.TEST test)
        {
            this.TestID = test.TestID;
            this.Status = test.Status;
            this.BagOfTestID = test.BagOfTestID;
            this.SubjectID = test.SubjectID;

            CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            TEST_DETAILS = new HashSet<TEST_DETAILS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.TEST test = (Quiz.TEST)obj;
            if (this.Status != test.Status)
                return false;
            if (this.BagOfTestID != test.BagOfTestID)
                return false;
            if (this.SubjectID != test.SubjectID)
                return false;
            return true;
        }

        public static bool operator ==(TEST test1, Quiz.TEST test2)
        {
            return test1.Equals(test2);
        }

        public static bool operator !=(TEST test1, Quiz.TEST test2)
        {
            return !test1.Equals(test2);
        }
    }

    public partial class TEST_DETAILS
    {
        public TEST_DETAILS()
        {

        }

        public TEST_DETAILS(Quiz.TEST_DETAILS test_detail)
        {
            this.TestDetailID = test_detail.TestDetailID;
            this.RandomAnswer = test_detail.RandomAnswer;
            this.NumberIndex = test_detail.NumberIndex;
            this.Score = test_detail.Score;
            this.Status = test_detail.Status;
            this.TestID = test_detail.TestID;
            this.QuestionID = test_detail.QuestionID;
        }

        //public override bool Equals(object obj)
        //{
        //    Quiz.TEST_DETAILS test_detail = (Quiz.TEST_DETAILS)obj;
        //    if (this.RandomAnswer != test_detail.RandomAnswer)
        //        return false;
        //    if (this.NumberIndex != test_detail.NumberIndex)
        //        return false;
        //    if (this.Score != test_detail.Score)
        //        return false;
        //    if (this.Status != test_detail.Status)
        //        return false;
        //    if (this.TestID != test_detail.TestID)
        //        return false;
        //    if (this.QuestionID != test_detail.QuestionID)
        //        return false;
        //    return true;
        //}

        //public static bool operator ==(TEST_DETAILS test_detail1, Quiz.TEST_DETAILS test_detail2)
        //{
        //    return test_detail1.Equals(test_detail2);
        //}

        //public static bool operator !=(TEST_DETAILS test_detail1, Quiz.TEST_DETAILS test_detail2)
        //{
        //    return !test_detail1.Equals(test_detail2);
        //}
    }

    public partial class TESTNUMBER
    {
        public TESTNUMBER()
        {

        }

        public TESTNUMBER(Quiz.TESTNUMBER test_num)
        {
            this.IDTestNumber = test_num.IDTestNumber;
            this.ContestantShiftID = test_num.ContestantShiftID;
            this.TestNumberIndex = test_num.TestNumberIndex;
        }

        public override bool Equals(object obj)
        {
            Quiz.TESTNUMBER test_num = (Quiz.TESTNUMBER)obj;
            if (this.ContestantShiftID != test_num.ContestantShiftID)
                return false;
            if (this.TestNumberIndex != test_num.TestNumberIndex)
                return false;
            return true;
        }

        public static bool operator ==(TESTNUMBER test_num1, Quiz.TESTNUMBER test_num2)
        {
            return test_num1.Equals(test_num2);
        }

        public static bool operator !=(TESTNUMBER test_num1, Quiz.TESTNUMBER test_num2)
        {
            return !test_num1.Equals(test_num2);
        }
    }

    public partial class VIOLATION
    {
        public VIOLATION(Quiz.VIOLATION vio)
        {
            this.ViolationID = vio.ViolationID;
            this.ViolationName = vio.ViolationName;
            this.Description = vio.Description;
            this.Level = vio.Level;
            this.Status = vio.Status;

            VIOLATIONS_CONTESTANTS = new HashSet<VIOLATIONS_CONTESTANTS>();
        }

        public override bool Equals(object obj)
        {
            Quiz.VIOLATION vio = (Quiz.VIOLATION)obj;
            if (this.ViolationName != vio.ViolationName)
                return false;
            if (this.Description != vio.Description)
                return false;
            if (this.Level != vio.Level)
                return false;
            if (this.Status != vio.Status)
                return false;
            return true;
        }

        public static bool operator ==(VIOLATION vio1, Quiz.VIOLATION vio2)
        {
            return vio1.Equals(vio2);
        }

        public static bool operator !=(VIOLATION vio1, Quiz.VIOLATION vio2)
        {
            return !vio1.Equals(vio2);
        }
    }

    public partial class VIOLATIONS_CONTESTANTS
    {
        public VIOLATIONS_CONTESTANTS()
        {

        }

        public VIOLATIONS_CONTESTANTS(Quiz.VIOLATIONS_CONTESTANTS vio_con)
        {
            this.ViolationDetailID = vio_con.ViolationDetailID;
            this.Status = vio_con.Status;
            this.TimeSave = vio_con.TimeSave;
            this.ViolationID = vio_con.ViolationID;
            this.ContestantShiftID = vio_con.ContestantShiftID;
        }

        public override bool Equals(object obj)
        {
            Quiz.VIOLATIONS_CONTESTANTS vio_con = (Quiz.VIOLATIONS_CONTESTANTS)obj;
            if (this.Status != vio_con.Status)
                return false;
            if (this.TimeSave != vio_con.TimeSave)
                return false;
            if (this.ViolationID != vio_con.ViolationID)
                return false;
            if (this.ContestantShiftID != vio_con.ContestantShiftID)
                return false;
            return true;
        }

        public static bool operator ==(VIOLATIONS_CONTESTANTS vio_con1, Quiz.VIOLATIONS_CONTESTANTS vio_con2)
        {
            return vio_con1.Equals(vio_con2);
        }

        public static bool operator !=(VIOLATIONS_CONTESTANTS vio_con1, Quiz.VIOLATIONS_CONTESTANTS vio_con2)
        {
            return !vio_con1.Equals(vio_con2);
        }
    }

    public partial class WRITING_TEACHER
    {
        public WRITING_TEACHER()
        {

        }

        public WRITING_TEACHER(Quiz.WRITING_TEACHER write_teach)
        {
            this.ID = write_teach.ID;
            this.AnswerSheetWritingID = write_teach.AnswerSheetWritingID;
            this.TeacherID = write_teach.TeacherID;
            this.Status = write_teach.Status;
        }

        public override bool Equals(object obj)
        {
            Quiz.WRITING_TEACHER write_teach = (Quiz.WRITING_TEACHER)obj;
            if (this.AnswerSheetWritingID != write_teach.AnswerSheetWritingID)
                return false;
            if (this.TeacherID != write_teach.TeacherID)
                return false;
            if (this.Status != write_teach.Status)
                return false;
            return true;
        }

        public static bool operator ==(WRITING_TEACHER write_teach1, Quiz.WRITING_TEACHER write_teach2)
        {
            return write_teach1.Equals(write_teach2);
        }

        public static bool operator !=(WRITING_TEACHER write_teach1, Quiz.WRITING_TEACHER write_teach2)
        {
            return !write_teach1.Equals(write_teach2);
        }
    }
}
