using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.XepLichThi;
using EXON.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2
{
    public class ThamSoHeThong
    {
        public enum StatusKiThi
        {
            DaLapKeHoach = 0,
            DaPheDuyet = 1,
            DaHuy = 8,
            DaHoanThanh = 7,
            DaDangKy = 2,
            DaXepLich = 4,
            DaLamDe = 5,
            DaChuyenCSDL = 7
        }

        public static Color DaHoanThanh = Color.Green; //Color.FromArgb(192, 255, 192);
        public static Color DangThucHien = Color.Orange; // Color.FromArgb(255, 224, 192);
        public static Color ChuaThucHien = Color.Gray; //Color.FromArgb(255, 255, 255);

        #region Lưu cấu hình xếp lịch

        // 0: Ưu tiên môn thi, 1: Ưu tiên thí sinh
        public static int UuTienXepLich = 0;
        public static CONTEST kithi = new CONTEST();
        public static List<TinhThanh> listTinhThanh = new List<TinhThanh>();
        public static bool DaXepLich = false;

        public static List<LOCATION> ListLocation = new List<LOCATION>();
        private static List<CONTESTANT> ListContestant = new List<CONTESTANT>();

        private static ExonSystem db = DAO.DBService.db;

        public static void LoadTinhThanh()
        {

            UuTienXepLich = 0;

            if (kithi.Status == (int) ContestStatus.Accepted || kithi.Status == (int) ContestStatus.RegisterDone || kithi.Status == (int)ContestStatus.Cancel)
                DaXepLich = false;
            else
                DaXepLich = true;

            // Load danh sách địa điểm, thí sinh của kì thi
            ListLocation = db.LOCATIONS.Where(p => p.ContestID == kithi.ContestID).ToList();
            ListContestant = (
                                from ts in db.CONTESTANTS
                                from tt in db.REGISTERS
                                where ts.Status > 0
                                where tt.Status > 0
                                where ts.RegisterID == tt.RegisterID
                                where tt.ContestID == kithi.ContestID
                                select ts
                             ).ToList();

            // Load danh sách tỉnh thành
            listTinhThanh = new List<TinhThanh>();
            foreach(var item in ListContestant)
            {
                REGISTER rg = db.REGISTERS.Where(p => p.RegisterID == item.RegisterID).FirstOrDefault();
                string ten = rg.CurrentAddress;
                string TenTinh = ten.Split('-').Last().Trim();

                if (listTinhThanh.Where(p=>p.Ten == TenTinh).ToList().Count == 0)
                {
                    TinhThanh tinhthanh = new TinhThanh();
                    tinhthanh.Ten = TenTinh;
                    tinhthanh.SoLuong = 1;
                    tinhthanh.LocationID = -1;

                    listTinhThanh.Add(tinhthanh);
                }
                else
                {
                    TinhThanh tinhthanh = listTinhThanh.Where(p => p.Ten == TenTinh).FirstOrDefault();
                    tinhthanh.SoLuong++;
                }
            }

            /// Kiểm tra nếu chỉ có 1 địa điểm thì xếp luôn tất cả các thí sinh vào địa điểm đó
            if (ListLocation.Count == 1)
            {
                foreach (var item in listTinhThanh) item.LocationID = ListLocation.FirstOrDefault().LocationID;
            }
        }
        #endregion
    }
}
