using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
   public  class ContestDAO
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
    }
}
