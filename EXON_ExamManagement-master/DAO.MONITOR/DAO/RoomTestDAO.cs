using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
  public   class RoomTestDAO
    {

        private static RoomTestDAO instance;

        public static RoomTestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomTestDAO();
                }
                return instance;
            }
        }
    }
}
