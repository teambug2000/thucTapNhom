using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2.XepLichThi
{
    public static class FileProcess
    {
        public static string ReadFile(string path)
        {
            string ans = "";
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader rd = new StreamReader(fs, Encoding.UTF8);
                ans = rd.ReadToEnd();
                rd.Close();
                fs.Close();
            }

            return ans;
        }

        public static List<TinhThanh> getTinhThanhConfig(string path)
        {
            string a = ReadFile(path);
            List<TinhThanh> ans = new List<TinhThanh>();

            List<string> lb = a.Split(';').ToList();

            foreach (var item in lb)
            {
                try
                {
                    List<string> pc = item.Split('-').ToList();
                    TinhThanh z = new TinhThanh();
                    z.Ten = pc[0].Trim();
                    z.LocationID = Int32.Parse(pc[1]);
                    ans.Add(z);
                }
                catch
                {

                }
            }

            return ans;
        } 
        
    }
}
