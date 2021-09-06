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
    public class TestDetailBUS
    {
        private static TestDetailBUS instance;
        public static TestDetailBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestDetailBUS();
                }
                return instance;
            }
        }
        private TestDetailBUS() { }
        public TEST_DETAILS InsertTestDetail(TEST_DETAILS testDetail, SqlConnection sql)
        {
            return TestDetailDAO.Instance.InsertTestDetail(testDetail, sql);
        }
    }
}
