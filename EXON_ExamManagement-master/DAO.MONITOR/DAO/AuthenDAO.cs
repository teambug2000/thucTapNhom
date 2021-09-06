using DAO.MONITOR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MONITOR.DAO
{
  public class AuthenDAO
    {
        private static AuthenDAO instance;

        public static AuthenDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthenDAO();
                }
                return instance;
            }
        }
      public void Authen(string user, string pass,out ErrorController EC)
        {
          using( MTAQuizEntities Db = new MTAQuizEntities())
            {
                try
                {
                    // đặt mặc định permisstion là bao nhiêu.
                    var staffList = (from obj in Db.EXAMINATIONCOUNCIL_STAFFS
                                     from obj3 in Db.DIVISIONSHIFT_SUPERVISOR
                                     where ((obj.StaffID == obj3.SupervisorID) && (obj.UserName.Contains(user) && (obj.Password == pass)))
                                     select new { obj }).ToList();
                    if (staffList == null || staffList.Count == 0)
                        EC = new ErrorController(Common.STATUS_ERROR, "Login Fail!");
                    else
                        EC = new ErrorController(Common.STATUS_OK, "Login successfully!");
                }
                catch (Exception ex)
                {
                  
                    EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
                }
            }
        }
    }
}
