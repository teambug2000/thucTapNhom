using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
    class ContestantDAO
    {
        private static ContestantDAO instance;

        public static ContestantDAO Instance
        {
           get
            {
                if (instance == null)
                {
                    instance = new ContestantDAO();
                }
                return instance;
            }
        }
       
    }
}
