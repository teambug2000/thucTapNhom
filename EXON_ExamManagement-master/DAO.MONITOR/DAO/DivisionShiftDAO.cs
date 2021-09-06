using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
   public  class DivisionShiftDAO
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
    }
}
