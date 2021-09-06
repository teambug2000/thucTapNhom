using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DAO;
namespace UploadMedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private byte[] GetMySounds()
        {
            var bytes = File.ReadAllBytes("D:/React/2426229_Nguoi_ta_noi/VoiVang-TaQuangThang-4412665.mp3");
            return bytes;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = GetMySounds();
            DAO.DAO.TestDAO.Instance.UpMedia(buffer);
        }
    }
}
