using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
    public class TestDAO
    {
        private static TestDAO instance;
        public static TestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestDAO();
                }
                return instance;
            }
        }
        private TestDAO() { }



    }
}
