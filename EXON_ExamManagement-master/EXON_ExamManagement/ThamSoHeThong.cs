using EXON.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_ExamManagement
{
    public static class ThamSoHeThong
    {
        // Màu sắc cho menu các bước trong lập kế hoạch thi
        public static Color Mau_DaHoanThanh = Color.Green;
        public static Color Mau_DangThucHien = Color.DarkOrange;
        public static Color Mau_ChuaHoanThanh = Color.Gray;
        public static Color Mau_LuaChon = Color.FromArgb(255, 192, 128);
        
        // mau cua cuoc thi
        public static Color getMauCuocThi(int status)
        {
            switch (status)
            {
                case (int)ContestStatus.Cancel: return Color.Red;
                case (int)ContestStatus.ContestDone: return Color.Green;
                case (int)ContestStatus.PrepareTestDone: return Color.LightGreen;
                default : return Color.White;
            }
        }
    }
}
