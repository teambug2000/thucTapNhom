using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
   public  class ShiftDAO
    {
        private static ShiftDAO instance;

        public static ShiftDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShiftDAO();
                }
                return instance;
            }
        }
    }
}
