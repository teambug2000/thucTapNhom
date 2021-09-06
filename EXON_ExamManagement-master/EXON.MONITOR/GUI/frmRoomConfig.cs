using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using EXON.MONITOR.Control;
using EXON.SubData.Services;
namespace EXON.MONITOR.GUI
{
    public partial class frmRoomConfig : MetroForm
    {
        private int _roomtestID;
        private IRoomTestService _RoomTestService;
        ucQuanLyMayThi ucQL;
        public frmRoomConfig()
        {
            InitializeComponent();
        }
        public frmRoomConfig(int _RoomtestID)
        {
            InitializeComponent();
            this._RoomTestService = new RoomTestService();
            this._roomtestID = _RoomtestID;
            this.Text = "Quản lý máy thi tại phòng thi " + _RoomTestService.GetById(_RoomtestID).RoomTestName;
        }
        private void frmRoomConfig_Load(object sender, EventArgs e)
        {
            ucQL = new ucQuanLyMayThi(_roomtestID);
            ucQL.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ucQL);
        }
    }
}
