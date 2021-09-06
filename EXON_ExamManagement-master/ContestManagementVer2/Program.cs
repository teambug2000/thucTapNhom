using ContestManagementVer2.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestManagementVer2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmLogin());
            //Application.Run(new FrmMain());


            Start app = new Start();

            //app.LapKeHoachThi(14);
            app.XepLich(6, 12);
            //app.QuanLyKeHoachThi(6, 12);

            //FrmConfigDiaDiem form = new FrmConfigDiaDiem(65);
            //form.ShowDialog();
        }
    }
}
