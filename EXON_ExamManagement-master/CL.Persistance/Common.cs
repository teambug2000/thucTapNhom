using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Persistance.Model;
namespace CL.Persistance
{
   public class Common
    {
        public static string GetConnectString(string key)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //EntityConnectionStringBuilder entityConnection = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings[key].ConnectionString);
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            string MyConnectionString = connections[key].ConnectionString;
            return MyConnectionString;
        }
        public static DateTime GetDateTimeServer()
        {
            MTAQuizEntities db = new MTAQuizEntities();
            return db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }

    }
}
