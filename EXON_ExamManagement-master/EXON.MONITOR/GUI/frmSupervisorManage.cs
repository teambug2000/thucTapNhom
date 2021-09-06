
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using MetroFramework.Forms;
using EXON.SubModel.Models;
using EXON.MONITOR.Common;
using EXON.SubData.Services;
using NetSDKCS;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Threading;
using EXON.MONITOR.Camera;
namespace EXON.MONITOR.GUI
{
    public partial class frmSupervisorManage : MetroForm
    {
        private delegate void SendInfoToFrmSupervisor(DivisionShift ds);

        public bool checkTime = false;
        private int countcheck = 0;
        private const int DIF_TIME = 1800; // đặt thời gian hiển thị các ca thi có starttime trong khoảng 45' mới cho hiện ra
        private const int DIF_TIME_OPEN = 900; // chỉ có thể truy cập ca thi trong khoảng  30' trước khi ca thi bắt đầu
        private const int WIDTH = 300; // độ rộng của button
        private const int HEIGHT = 300; // chiều cao của button
        private int supervisorID;
        private int shiftID;
        private SHIFT shift = new SHIFT();
        private List<SHIFT> Shiftinfor = new List<SHIFT>();
        private Timer t = new Timer();
        private StaffService _StaffService;
        private ShiftService _ShiftService;
        private DivisionShiftService _DivisionShiftService;
        public frmSupervisorManage(int _StaftID)
        {
            InitializeComponent();
            _StaffService = new StaffService();
            _ShiftService = new ShiftService();
            _DivisionShiftService = new DivisionShiftService();
            try
            {
                DTO.frmServer = new frmServer();
                DataGridViewCellStyle style = dgvListRoomTest.ColumnHeadersDefaultCellStyle;
                style.Font = new Font(dgvListRoomTest.Font, FontStyle.Bold);
                supervisorID = _StaftID;
               STAFF staff =_StaffService.GetById(supervisorID);
                mbtnSupervisor.Text = staff.FullName;
                AppSession.UserName = staff.FullName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối Server.");
                this.Dispose();
            }
        }

        private void frmSupervisorManage_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.ShowInTaskbar = true;
            analogClock1.Enabled = !analogClock1.Enabled;
            dgvListRoomTest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvListRoomTest.CellMouseClick += new DataGridViewCellMouseEventHandler(DgvListRoomTest_CellMouseClick);
            t.Tick += new EventHandler(t_Tick);

            t.Start();
        }

        private void DgvListRoomTest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvListRoomTest.Rows[e.RowIndex].Selected = true;
                dgvListRoomTest.CurrentCell = dgvListRoomTest[e.ColumnIndex, e.RowIndex];
             
                var pos = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex,
             e.RowIndex, false).Location;
                pos.X += e.X;
                pos.Y += e.Y;
                metroContextMenu2.Show((DataGridView)sender, pos);
            }
        }

        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                int ss = EXON.SubModel.GetDateTimeServer.GetDateTime().Second;
                int mm = EXON.SubModel.GetDateTimeServer.GetDateTime().Minute;
                int hh = EXON.SubModel.GetDateTimeServer.GetDateTime().Hour;

                lblTimeNow.Text = "Thời gian hiện tại: " + hh + ":" + mm + ":" + ss + "";
                if (hh <= 12)
                    lblTimeNow.Text += " AM";
                else
                    lblTimeNow.Text += " PM";
                GetInfoShift();

                if (checkTime && countcheck == 0)
                {
                    countcheck = 1;
                    checkTime = false;
                    LoadDgvListRoom();
                }
            }
            catch
            {
            }
        }

        private DivisionShift ds;

        private void dgvListRoomTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void LoadDgvListRoom()
        {
            try
            {
                if (shift != null)
                {
                    if (checkTime)
                    { }
                   
                    MTAQuizDbContext Db = new MTAQuizDbContext();
                    var listRoom = (from obj in Db.DIVISION_SHIFTS
                                    from obj2 in Db.ROOMTESTS
                                    from obj3 in Db.DIVISIONSHIFT_SUPERVISOR
                                    from sh in Db.SHIFTS
                                    where (obj.DivisionShiftID == obj3.DivisionShiftID && obj3.SupervisorID == supervisorID && obj2.RoomTestID == obj.RoomTestID && sh.ShiftID == obj.ShiftID && obj.ShiftID == shift.ShiftID)
                                    select new
                                    {
                                        ShiftID = sh.ShiftID,
                                        RoomTestID = obj2.RoomTestID,
                                        RoomTestName = obj2.RoomTestName,
                                        MaxSeatMount = obj2.MaxSeatMount,
                                        Endtime = sh.EndTime,
                                        StartTime = sh.StartTime
                                    }).ToList();

                    if (listRoom.Count > 0)
                    {
                        dgvListRoomTest.Rows.Clear();
                        for (int i = 0; i < listRoom.Count; i++)
                        {
                            dgvListRoomTest.Rows.Add();
                            dgvListRoomTest.Rows[i].Cells["STT"].Value = i + 1;
                            dgvListRoomTest.Rows[i].Cells["SHIFID"].Value = listRoom[i].ShiftID.ToString();
                            dgvListRoomTest.Rows[i].Cells["RoomTestID"].Value = listRoom[i].RoomTestID.ToString();
                            dgvListRoomTest.Rows[i].Cells["RoomTestName"].Value = listRoom[i].RoomTestName.ToString();
                            dgvListRoomTest.Rows[i].Cells["MaxSeatMount"].Value = listRoom[i].MaxSeatMount.ToString();
                            dgvListRoomTest.Rows[i].Cells["Endtime"].Value = ConvertIntToDate(int.Parse(listRoom[i].Endtime.ToString())).TimeOfDay;
                            dgvListRoomTest.Rows[i].Cells["StartTime"].Value = ConvertIntToDate(int.Parse(listRoom[i].StartTime.ToString())).TimeOfDay;
                        }
                    }
                }
                else
                {
                    lblThongBao.Text = "Hiện tại ko có ca thi nào cả. ";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Hiện tại ko có phòng thi nào";
            }
        }

        public DateTime ConvertIntToDate(double number)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(number);
        }

        private void GetInfoShift()
        {
            int logTime = AppSession.LogTime;
            int TimeNow = (int)EXON.SubModel.GetDateTimeServer.GetDateTime().TimeOfDay.TotalSeconds;

            shift = _ShiftService.GetShiftNow(TimeNow, logTime, DIF_TIME, supervisorID);

            if (shift != null)
            {
                shiftID = shift.ShiftID;
                mlblContestName.Text = "Tên kỳ thi: " + shift.CONTEST.ContestName;

                lblThongBao.Text = "Hiện tại có các phòng thi có diễn ra thi bên trên";
                checkTime = true;
            }
            else
            {
                lblThongBao.Text = "Hiện tại ko có ca thi nào cả";
            }
        }

        private void dgvListRoomTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    int timeClick = Convert.ToInt32(DatetimeConvert.ConvertDateTimeToUnix(EXON.SubModel.GetDateTimeServer.GetDateTime()));

                    // Được truy cập trước 30' trước khi ca thi diễn ra

                    if ((timeClick > (shift.StartTime - DIF_TIME_OPEN)) /*&& (timeClick < shift.EndTime)*/)
                    {
                        int roomID = Convert.ToInt32(dgvListRoomTest.Rows[e.RowIndex].Cells[1].Value);
                        shiftID = int.Parse(dgvListRoomTest.Rows[e.RowIndex].Cells[6].Value.ToString());
                        DIVISION_SHIFTS divisionShift =_DivisionShiftService.GetDivisionShift(shiftID, roomID);
                        if (divisionShift != null)
                        {
                            int divisionShiftID = divisionShift.DivisionShiftID;
                            ds = new DivisionShift();
                            ds.ShiftID = shiftID;
                            ds.DivisionShiftID = divisionShiftID;

                            if (DTO.frmServer.IsDisposed)
                            {
                               DTO.frmServer = new frmServer();
                            }
                            SendInfoToFrmSupervisor sits = new SendInfoToFrmSupervisor(DTO.frmServer.HandelInfo);
                            sits(ds);
                            DTO.frmServer.Show();
                        }
                        else
                        {
                            lblThongBao.Text += ". Không có phòng thi nào của ca thi";
                            return;
                        }
                    }
                    else
                    {
                        lblThongBao.Text = "Bạn chỉ có thể truy cập vào phòng thi trong khoảng 30' trước khi ca thi diễn ra";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            countcheck = 0;
        }

        private MainWindow mainWindow; //main window object.
        private fDisConnectCallBack disConnect;

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void DisConnect(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            if (mainWindow == null)
            {
                return;
            }
            try
            {
                foreach (var item in mainWindow.m_DeviceList)
                {
                    if (lLoginID == item.LoginID)
                    {
                        //call delegate to update disconnect device information.here the thread cannot update UI,must call delegate or send message to update UI.
                        Dispatcher.CurrentDispatcher.BeginInvoke((Action<IntPtr>)UpdateTreeViewItem, item.LoginID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        private void UpdateTreeViewItem(IntPtr value)
        {
            foreach (TreeViewItem treeItem in mainWindow.treeView.Items)
            {
                if ((treeItem.Tag as Device).LoginID == value)
                {
                    treeItem.Header = (treeItem.Tag as Device).IP + "(offline)"; //set information to offline.
                }
            }
        }

        private void frmSupervisorManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
        }

        private void mbtnSupervisor_Click(object sender, EventArgs e)
        {
            metroContextMenu1.Show(mbtnSupervisor, new Point(0, mbtnSupervisor.Height));
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void mItemMenuCheckinRoom_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
            if (rows != null)
            {
                int index = dgvListRoomTest.CurrentRow.Index;
                int roomID = int.Parse(dgvListRoomTest.Rows[index].Cells[1].Value.ToString());

                frmRoomConfig frm = new frmRoomConfig(roomID);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn cần chọn phòng thi");
            }
        }

        private void mItemMenuComein_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
            //int index = dgvListRoomTest.SelectedRows[0].Index;

            if (rows != null)
            {
                int index = dgvListRoomTest.CurrentCell.RowIndex;
                int roomID = int.Parse(dgvListRoomTest.Rows[index].Cells[1].Value.ToString());
                shiftID = int.Parse(dgvListRoomTest.Rows[index].Cells[6].Value.ToString());
                DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetDivisionShift(shiftID, roomID);
                if (divisionShift != null)
                {
                    int divisionShiftID = divisionShift.DivisionShiftID;
                    ds = new DivisionShift();
                    ds.ShiftID = shiftID;
                    ds.DivisionShiftID = divisionShiftID;
                    frmServer frmServer = new frmServer() ;
                    if (DTO.frmServer.IsDisposed)
                    {
                       DTO.frmServer = new frmServer();
                    }
                    SendInfoToFrmSupervisor sits = new SendInfoToFrmSupervisor(DTO.frmServer.HandelInfo);
                    sits(ds);
                    DTO.frmServer.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhấp chọn phòng thi");
            }
        }

        private void mItemMenuTurnOn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
                if (rows.Count >= 0)
                {
                    int index = dgvListRoomTest.CurrentRow.Index;
                    string RoomName = dgvListRoomTest.Rows[index].Cells[2].Value.ToString();

                    mainWindow = new EXON.MONITOR.Camera.MainWindow(RoomName); //instance mainwindow.

                    disConnect = new fDisConnectCallBack(DisConnect); //set disconnect callback.

                    bool res = NETClient.Init(disConnect, IntPtr.Zero, null);
                    if (res == false)
                    {
                        MessageBox.Show("NETClient init failed!");
                    }
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn phòng thi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
    
        private void btnRegisterFinger_Click(object sender, EventArgs e)
        {
            frmRegisterFinger frm = new frmRegisterFinger(shiftID);
            frm.ShowDialog();
        }

        private void mbtnCheckRoom_Click(object sender, EventArgs e)
        {
            frmCheckComputer frm = new frmCheckComputer();
            frm.ShowDialog();
        }
    }
}