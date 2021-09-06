using EXON.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ContestManagementVer2.ImportLichThi
{
    public static class OfficeHelper
    {
        public static List<InfoContestant> ReadChiTietLichThi(string FileName)
        {
            /// trả về danh sách lịch thi đọc được nếu file xls thỏa mãn
            /// Nếu file excel không thỏa mãn thì trả về null
            List<InfoContestant> ans = new List<InfoContestant>();
            int dem = 0;

            try
            {
                var xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 2; i <= rowCount; i++)
                {
                    dem = i;
                    InfoContestant temp = new InfoContestant();
                    try
                    {
                        // Nếu là 1 cột rỗng thì không Load
                        int stt = (int)xlRange[i, 1].value;
                        temp.STT = stt;
                    }
                    catch
                    {
                        continue;
                    }

                    /// Đọc các thông tin cần thiết
                    temp.ContestantCode = xlRange[i, 2].value.ToString();
                    temp.FullName = xlRange[i, 3].value.ToString();
                    temp.Sex = xlRange[i, 5].value.ToString();
                    temp.IdCardNumber = xlRange[i, 6].value.ToString();
                    temp.CurrentAddress = xlRange[i, 7].value.ToString();
                    temp.LocationCode = xlRange[i, 8].value.ToString();
                    temp.Roomtest = xlRange[i, 9].value.ToString();
                    temp.KhoiThi = xlRange[i, 10].value.ToString();

                    CultureInfo MyCultureInfo = new CultureInfo("nl-NL");
                    string kz = (string)xlRange.Cells[i, 11].value.ToString();
                    temp.ExamDate = DateTime.Parse(kz, MyCultureInfo);

                    temp.Shift = xlRange[i, 12].value.ToString();

                    ans.Add(temp);
                }

                xlWorksheet.Columns.AutoFit();
                xlWorkBook.Save();
                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch (Exception e)
            {
                string err = e.Message;
                MessageBox.Show("Load thất bại\n" + err + "\nSTT = " + (dem - 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //MessageBox.Show("Load thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return ans;
        }
    }
}