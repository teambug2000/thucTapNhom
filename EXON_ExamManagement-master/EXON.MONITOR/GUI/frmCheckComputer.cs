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
using EXON.SubData.Services;
namespace EXON.MONITOR.GUI
{
  
    public partial class frmCheckComputer : MetroForm
    {
       private IRoomTestService _RoomTestService;
        private List<RoomTest> lstRoomtest;
        public frmCheckComputer()
        {
            InitializeComponent();
            this._RoomTestService = new RoomTestService();
        }

        private void frmCheckComputer_Load(object sender, EventArgs e)
        {
            int count = 0;
            lstRoomtest = new List<RoomTest>();
            lstRoomtest.AddRange(from obj in _RoomTestService.GetAll().ToList()
                                 select new RoomTest
                                 {
                                     STT = ++count,
                                     RoomTestID = obj.RoomTestID.ToString(),
                                     RoomTestName = obj.RoomTestName
                                 });
            dgvRoomTest.DataSource = lstRoomtest;
        }

        private void mItemMenuCheckinRoom_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvRoomTest.SelectedRows;
            if (rows != null)
            {
                int index = dgvRoomTest.CurrentRow.Index;
                int roomID = int.Parse(dgvRoomTest.Rows[index].Cells[0].Value.ToString());

                frmRoomConfig frm = new frmRoomConfig(roomID);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn cần chọn phòng thi");
            }
        }

        private void dgvRoomTest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvRoomTest.Rows[e.RowIndex].Selected = true;
                dgvRoomTest.CurrentCell = dgvRoomTest[e.ColumnIndex, e.RowIndex];

                var pos = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex,
             e.RowIndex, false).Location;
                pos.X += e.X;
                pos.Y += e.Y;
                metroContextMenu2.Show((DataGridView)sender, pos);
            }
        }
    }
    public class RoomTest
    {
        public string RoomTestID { get; set; }
        public string RoomTestName { get; set; }

        public int STT { get; set; }

    }
}
