using EXON.RegisterManager.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.RegisterManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //  try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            //   catch(Exception ex)
            {
                //     MessageBox.Show(ex.Message);
            }
            //Application.Run(new EXON.GetFinger.frmGetFingerPrinter());
        }
    }
}