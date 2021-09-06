using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class TestDetailDAO
    {
        private static TestDetailDAO instance;
        public static TestDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestDetailDAO();
                }
                return instance;
            }
        }

        private TestDetailDAO() { }
        //public EXON.Model.Models.TEST_DETAILS GetTEST_DETAILSByDivisionShiftID(int DivisonShiftID, SqlConnection sql)
        //{
        //    try
        //    {
        //        EXON.Model.Models.TEST_DETAILS _TEST_DETAILS = new EXON.Model.Models.TEST_DETAILS();
        //        using (var command = new SqlCommand("select * from TEST_DETAILSS where DivisonShiftID = @id", sql))
        //        {
        //            command.Parameters.Add("@id", DivisonShiftID);
        //            //sql.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    EXON.Model.Models.TEST_DETAILS TEST_DETAILS = new EXON.Model.Models.TEST_DETAILS();
        //                    TEST_DETAILS.TEST_DETAILSID = Convert.ToInt32(reader["TEST_DETAILSID"].ToString());
        //                    TEST_DETAILS.NumberOfTest = Convert.ToInt32(reader["NumberOfTest"].ToString());
        //                    TEST_DETAILS.Status = Convert.ToInt32(reader["DivisionShiftID"].ToString());
        //                    TEST_DETAILS.DivisionShiftID = Convert.ToInt32(reader["ScheduleID"].ToString());
        //                    _TEST_DETAILS = TEST_DETAILS;
        //                }
        //            }
        //        }

        //        return _TEST_DETAILS;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        public EXON.Model.Models.TEST_DETAILS InsertTestDetail(EXON.Model.Models.TEST_DETAILS TEST_DETAILS, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.TEST_DETAILS _TEST_DETAILS = new EXON.Model.Models.TEST_DETAILS();
                using (var command = new SqlCommand("INSERT INTO TEST_DETAILS (RandomAnswer, NumberIndex, Score, Status, TestID, QuestionID) OUTPUT INSERTED.TestDetailID VALUES (@randomAnswer, @numberIndex, @score, @status, @testID, @questionID)", sql))
                {
                    command.Parameters.Add("@RandomAnswer", TEST_DETAILS.RandomAnswer);
                    command.Parameters.Add("@NumberIndex", TEST_DETAILS.NumberIndex);
                    command.Parameters.Add("@Score", TEST_DETAILS.Score);
                    command.Parameters.Add("@TestID", TEST_DETAILS.TestID);
                    command.Parameters.Add("@status", TEST_DETAILS.Status);
                    command.Parameters.Add("@QuestionID", TEST_DETAILS.QuestionID);
                    TEST_DETAILS.TestDetailID = (int)command.ExecuteScalar();
                    _TEST_DETAILS = TEST_DETAILS;
                }
                return _TEST_DETAILS;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public EXON.Model.Models.TEST_DETAILS UpdateTEST_DETAILS(int DivisonShiftID, EXON.Model.Models.TEST_DETAILS TEST_DETAILS, SqlConnection sql)
        //{
        //    try
        //    {
        //        EXON.Model.Models.TEST_DETAILS _TEST_DETAILS = new EXON.Model.Models.TEST_DETAILS();
        //        using (var command = new SqlCommand("UPDATE TEST_DETAILSS SET NumberOfTest = @numberOfTest, Status = @status  WHERE DivisionShift = @divisionShift", sql))
        //        {
        //            command.Parameters.Add("@numberOfTest", TEST_DETAILS.NumberOfTest);
        //            command.Parameters.Add("@status", TEST_DETAILS.Status);
        //            command.Parameters.Add("@divisionShift", TEST_DETAILS.DivisionShiftID);
        //            command.ExecuteNonQuery();
        //        }
        //        return _TEST_DETAILS;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
