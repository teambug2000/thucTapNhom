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
    public class TopicBUS
    {
        private static TopicBUS instance;
        public static TopicBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TopicBUS();
                }
                return instance;
            }
        }
        private TopicBUS() { }

        public List<TOPIC> GetAllTopic(int scheduleID, List<TOPIC> rListTopic, SqlConnection sql)
        {
            return TopicDAO.Instance.GetAllTopic(scheduleID, rListTopic, sql);
        }
    }
}
