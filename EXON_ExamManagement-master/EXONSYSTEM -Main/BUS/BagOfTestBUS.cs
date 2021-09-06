using DAO.DAO;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BagOfTestBUS
    {
        private static BagOfTestBUS instance;
        public static BagOfTestBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BagOfTestBUS();
                }
                return instance;
            }
        }
        private BagOfTestBUS() { }

        public BAGOFTEST GetBagOfTestByDivisionShiftID(int currentDivisionShiftId, SqlConnection sql)
        {
            return BagOfTestDAO.Instance.GetBagOfTestByDivisionShiftID(currentDivisionShiftId, sql);
        }
        public BAGOFTEST InsertBagOfTest(BAGOFTEST bagOfTest, SqlConnection sql)
        {
            return BagOfTestDAO.Instance.InsertBagOfTest(bagOfTest, sql);
        }
        public BAGOFTEST UpdateBagOfTest(int DivisonShiftID, BAGOFTEST bagOfTest, SqlConnection sql)
        {
            return BagOfTestDAO.Instance.UpdateBagOfTest(DivisonShiftID ,bagOfTest, sql);
        }
    }
}
