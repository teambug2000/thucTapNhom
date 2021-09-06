using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
   public  class RoomdiagramDAO
    {

        private static RoomdiagramDAO instance;

        public static RoomdiagramDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomdiagramDAO();
                }
                return instance;
            }
        }
    }
}
