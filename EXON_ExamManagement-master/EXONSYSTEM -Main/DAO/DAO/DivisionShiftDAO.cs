using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class DivisionShiftDAO
    {
        private static DivisionShiftDAO instance;
        public static DivisionShiftDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DivisionShiftDAO();
                }
                return instance;
            }
        }

        private DivisionShiftDAO() { }
        public List<EXON.Model.Models.DIVISION_SHIFTS> GetAllDivisionShiftByShiftID(int currentShiftId, List<EXON.Model.Models.DIVISION_SHIFTS> listRoomShift, SqlConnection sql)
        {
            try
            {

                using (var command = new SqlCommand("select * from DIVISION_SHIFTS where ShiftID = @id", sql))
                {
                    command.Parameters.Add("@id", currentShiftId);
                    //sql.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EXON.Model.Models.DIVISION_SHIFTS divisionShift = new EXON.Model.Models.DIVISION_SHIFTS();
                            divisionShift.DivisionShiftID = Convert.ToInt32(reader["DivisionShiftID"].ToString());
                            divisionShift.ShiftID = Convert.ToInt32(reader["ShiftID"].ToString());
                            divisionShift.Status = Convert.ToInt32(reader["Status"].ToString());
                            divisionShift.RoomTestID = Convert.ToInt32(reader["RoomTestID"].ToString());
                            //divisionShift.SupervisorID = Convert.ToInt32(reader["SupervisorID"].ToString());
                            divisionShift.Key = reader["Key"].ToString();
                            listRoomShift.Add(divisionShift);
                        }
                    }
                }

                return listRoomShift;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
