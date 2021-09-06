using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class BagOfTestDAO
    {
        private static BagOfTestDAO instance;
        public static BagOfTestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BagOfTestDAO();
                }
                return instance;
            }
        }

        private BagOfTestDAO() { }
        public EXON.Model.Models.BAGOFTEST GetBagOfTestByDivisionShiftID(int DivisionShiftID, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.BAGOFTEST _bagOFTest = new EXON.Model.Models.BAGOFTEST();
                using (var command = new SqlCommand("select * from BAGOFTESTS where DivisionShiftID = @id", sql))
                {
                    command.Parameters.Add("@id", DivisionShiftID);
                    if (sql.State != ConnectionState.Open)
                        sql.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EXON.Model.Models.BAGOFTEST bagOFTest = new EXON.Model.Models.BAGOFTEST();
                            bagOFTest.BagOfTestID = Convert.ToInt32(reader["BagOfTestID"].ToString());
                            bagOFTest.NumberOfTest = Convert.ToInt32(reader["NumberOfTest"].ToString());
                            bagOFTest.Status = Convert.ToInt32(reader["Status"].ToString());
                            bagOFTest.DivisionShiftID = Convert.ToInt32(reader["DivisionShiftID"].ToString());
                            _bagOFTest = bagOFTest;
                        }
                    }
                }

                return _bagOFTest;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EXON.Model.Models.BAGOFTEST InsertBagOfTest(EXON.Model.Models.BAGOFTEST bagOfTest ,SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.BAGOFTEST _bagOFTest = new EXON.Model.Models.BAGOFTEST();
                using (var command = new SqlCommand("INSERT INTO BAGOFTESTS (NumberOfTest, Status, DivisionShiftID) OUTPUT INSERTED.BagOfTestID VALUES (@numberOfTest, @status, @divisionShiftID)", sql))
                {
                    command.Parameters.Add("@numberOfTest", bagOfTest.NumberOfTest);
                    command.Parameters.Add("@status", bagOfTest.Status);
                    command.Parameters.Add("@divisionShiftID", bagOfTest.DivisionShiftID);
                    bagOfTest.BagOfTestID = (int)command.ExecuteScalar();
                    _bagOFTest = bagOfTest;
                }
                return _bagOFTest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EXON.Model.Models.BAGOFTEST UpdateBagOfTest(int DivisonShiftID, EXON.Model.Models.BAGOFTEST bagOfTest, SqlConnection sql)
        {
            try
            {
                EXON.Model.Models.BAGOFTEST _bagOFTest = new EXON.Model.Models.BAGOFTEST();
                using (var command = new SqlCommand("UPDATE BAGOFTESTS SET NumberOfTest = @numberOfTest, Status = @status  WHERE DivisionShiftID = @divisionShiftID", sql))
                {
                    command.Parameters.Add("@numberOfTest", bagOfTest.NumberOfTest);
                    command.Parameters.Add("@status", bagOfTest.Status);
                    command.Parameters.Add("@divisionShiftID", bagOfTest.DivisionShiftID);
                    command.ExecuteNonQuery();
                    _bagOFTest = bagOfTest;
                }
                return _bagOFTest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
