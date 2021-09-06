using EXON.MONITOR.Common;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.MONITOR.Control;
using EXON.SubData.Services;
using MetroFramework.Controls;
using MetroFramework.Forms;
using UserHelper;
using System.Net;
using MetroFramework;
using EXON.MONITOR.Report;

namespace EXON.MONITOR.GUI
{
    public partial class frmServer : MetroForm
    {
        #region Declare

        private int supervisorID;
        private IStaffService _StaffService;
        private IShiftService _ShiftService;
        private IRoomTestService _RoomTestService;
        private IDivisionShiftService _DivisionShiftService;
        private IContestantShiftService _ContestantShiftService;
        private IContestantTestService _ContesttantTestService;
        private IContestantService _ContestantService;
        private IRoomDiagramService _RoomdiagramService;
        private ITestNumberService _TestNumberService;
        private IScheduleService _ScheduleService;
        private IBagOfTestService _BagOfTestService;
        private ITestService _TestService;
        private IExaminationcouncilStaffService _ExaminationcouncilStaffService;
        private IViolationContestantService _ViolationContestantService;
        private IViolationService _ViolationService;

        public delegate void SendWorking(bool isprogress);

        private SendWorking s;
        private int index;
        private int countDivisionShift;
        private int divisionShiftID;
        private int shiftID;
        private int roomTestID;
        private int[] indexPage = new int[10];
        private int[] ListShiftID = new int[10];
        private int[] ListDivisionShiftID = new int[10];
        private SHIFT shift;
        private ROOMTEST room;
        static public ServerSide serverSocket;
        private List<ContestantInformation> lstCIConnected = new List<ContestantInformation>();

        private delegate void SendInfoUCServer(ServerSide sersocket);

        private string IP;
        static public int check = 0;

        #endregion Declare

        public frmServer()
        {
            InitializeComponent();
            _StaffService = new StaffService();
            _ShiftService = new ShiftService();
            _RoomTestService = new RoomTestService();
            _DivisionShiftService = new DivisionShiftService();
            _RoomdiagramService = new RoomDiagramService();
            if (AppSession.StaffID > 0)
            {
                supervisorID = AppSession.StaffID;
                setFullScreen();
                STAFF staff = _StaffService.GetById(supervisorID);
                lblSupervisorName.Text = "Giám Sát: " + staff.FullName;
                UserHelper.Ultis.GetCurrentIP(out IP);
                serverSocket = new UserHelper.ServerSide(IP, 3001);

                serverSocket.ClientConnected += serverSocket_ClientConnected;
                serverSocket.ClientDisConnected += serverSocket_ClientDisconnected;
            }
        }

        private void serverSocket_ClientConnected(object sender, object data)
        {
            var client = data as SocketController;
            IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;

            client.Receive += client_Receive;
        }

        private int GetIndexClientFromList(SocketController sc)
        {
            IPEndPoint remote = (IPEndPoint)sc.Sock.RemoteEndPoint;
            int index = lstCIConnected.FindIndex(x => x.IPPORT == string.Format("{0}:{1}", remote.Address, remote.Port));
            return index;
        }

        private void serverSocket_ClientDisconnected(object sender, object data)
        {
            try
            {
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                var client = data as SocketController;

                IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;
                int index = GetIndexClientFromList(client);
                if (index > -1)
                {
                    ContestantInformation CI = lstCIConnected[index];
                    CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                    CONTESTANT contestant = new CONTESTANT();

                    string recieveRomTestID = _RoomdiagramService.GetByComputername(CI.UserTransfer.ComputerName).ToString();
                    ucServer uc = new ucServer();

                    foreach (MetroTabPage item in tabControl1.TabPages)
                    {
                        if (recieveRomTestID == item.Name)
                        {
                            uc = (ucServer)item.Controls[0];
                            break;
                        }
                    }
                    //if (CI.UserTransfer.Status == UserHelper.Common.STATUS_DOING_BUT_INTERRUPT)
                    //{
                    //    uc.SetText(string.Format("Tự tắt chương trình. Vui lòng kiểm tra máy thi này [{0}]", CI.UserTransfer.ComputerName));
                    //}
                    //else
                    //{
                    if (CI.UserTransfer.Status != UserHelper.Common.STATUS_FINISHED)
                    {
                        //contestantShift = _ContestantShiftService.GetById(client.ContestShiftID);
                        if (contestantShift != null)
                        {
                            contestant = _ContestantService.GetById(client.UserID);
                            if (contestant != null)
                            {
                                DateTime timeDisconnect = Common.DatetimeConvert.GetDateTimeServer();
                                contestantShift.Status = UserHelper.Common.STATUS_DOING_BUT_INTERRUPT;
                                _ContestantShiftService.Update(contestantShift);
                                _ContestantShiftService.Save();
                                uc.SetText(string.Format("Thí sinh [{0}] mất kết nối lúc : [{1}]", contestant.FullName, timeDisconnect.ToString("HH: mm:ss")));
                                uc.SetupdateUC(client.UserID);
                            }
                        }
                    }
                    //}

                    lstCIConnected.RemoveAt(GetIndexClientFromList(client));
                    serverSocket.ClientList.Remove(client);
                }
                client.Dispose();
            }
            catch
            {
            }
        }

        private void client_Receive(object sender, object data)
        {
            var client = (SocketController)sender;
            UserTransformation Recieve = new UserTransformation();
            Recieve = Ultis.FromJSONToObject((string)data);
            client.UserID = Recieve.UserID;
            CONTESTANT contestant = new CONTESTANT();
            contestant = _ContestantService.GetSigleByUserCode(Recieve.UserCode);
            if (Recieve.Status == UserHelper.Common.STATUS_LOGGED || Recieve.Status == UserHelper.Common.STATUS_LOGGED_DO_NOT_FINISH)
            {
                ContestantInformation CI = new ContestantInformation();
                CI.IPPORT = string.Format("{0}:{1}", client.IPERemote.Address, client.IPERemote.Port);
                CI.LoginStatus = Recieve.Status;
                CI.UserTransfer = Recieve;
                lstCIConnected.Add(CI);
            }
            if (Recieve.Status == UserHelper.Common.STATUS_REPORT_ERROR)
            {
                if (contestant != null)
                {
                    MetroMessageBox.Show(this, "Thí sinh" + contestant.FullName + " thông báo lỗi tại vị trí " +
                        Recieve.ComputerName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1, 150);
                }
            }

            int recieveRomTestID = _RoomdiagramService.GetByComputername(Recieve.ComputerName);//.ToString();
            ucServer uc = new ucServer();

            foreach (MetroTabPage item in tabControl1.TabPages)
            {
                if (recieveRomTestID != null && recieveRomTestID.ToString() == item.Name)
                {
                    foreach (var ucitem in item.Controls)
                    {
                        if (ucitem is ucServer)
                        {
                            uc = (ucServer)ucitem;
                            break;
                        }
                    }
                }
            }

            //if (Recieve.ComputerName != null && Recieve.Status == UserHelper.Common.STATUS_LOGGED)
            //{
            //    uc.CheckComputerForContestant(Recieve.ComputerName, Recieve.UserID);
            //}
            if (Recieve.Status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
            {
                uc.HandleEnableDivisionTest();
            }
            if (Recieve.Status == UserHelper.Common.STATUS_READY)
            {
                uc.HandleEnableStartTest();
            }

            uc.SetupdateUC(Recieve.UserID);
        }

        public void HandelInfo(DivisionShift ds)
        {
            for (int i = 0; i < ListDivisionShiftID.Count(); i++)
            {
                if (ds.DivisionShiftID == ListDivisionShiftID[i])
                {
                    tabControl1.SelectedIndex = i;
                    return;
                }
            }

            ListDivisionShiftID[countDivisionShift] = ds.DivisionShiftID;

            ListShiftID[countDivisionShift] = ds.ShiftID;
            this.shiftID = ds.ShiftID;
            this.divisionShiftID = ds.DivisionShiftID;
            countDivisionShift++;
            DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetById(divisionShiftID);
            if (divisionShift != null)
            {
                roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
            }
            GetInfoShift();
            handelPannelDiagram();
        }

        public void handelPannelDiagram()
        {
            MetroTabPage tabroom = new MetroTabPage();
            indexPage[index] = index++;
            DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetById(divisionShiftID);
            tabroom.Name = divisionShift.RoomTestID.ToString();
            tabroom.Text = "Phòng: " + divisionShift.ROOMTEST.RoomTestName;
            tabControl1.TabPages.Add(tabroom);
            Control.ucServer ucServer = new Control.ucServer(divisionShift);
            //SendInfoUCServer siuc = new SendInfoUCServer(ucServer.HandelInfoFromFrmServer);
            //siuc(serverSocket);
            ucServer.btnDivisionTestClick += new EventHandler(divisionshiftClick);
            ucServer.Dock = DockStyle.Fill;

            tabroom.Controls.Add(ucServer);
        }

        private void divisionshiftClick(object sender, EventArgs e)
        {
        }

        private void GetInfoShift()
        {
            shift = _ShiftService.GetById(shiftID);

            if (shift != null)
            {
                if (shift.ShiftName != null)
                {
                    lblShiftName.Text = "Ca:" + shift.ShiftName;
                    lblStartTime.Text = "Thời gian bắt đầu: " + DatetimeConvert.ConvertUnixToDateTime(shift.StartTime).ToString("HH: mm:ss");
                    lblEndTime.Text = "Thời gian Kết thúc: " + DatetimeConvert.ConvertUnixToDateTime(shift.EndTime).ToString("HH: mm:ss");

                    DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetById(divisionShiftID);
                    roomTestID = divisionShift.RoomTestID;
                    if (divisionShift != null)
                    {
                        room = _RoomTestService.GetById(Convert.ToInt32(divisionShift.RoomTestID));
                        roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
                        if (room != null)
                        {
                            roomTestID = room.RoomTestID;
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    lblShiftName.Text = "Mã ca: " + shift.ShiftID;
                }
            }
        }

        private void setFullScreen()
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.WindowState = FormWindowState.Normal;
        }

        private void tabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            frmServer_Load(sender, e);
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            setFullScreen();
            GetInfoShift();
            tabControl1.SelectedIndex = countDivisionShift - 1;
        }

        private void mbtnPrint_Click(object sender, EventArgs e)
        {
            metroContextMenu2.Show(mbtnPrint, new Point(0, mbtnPrint.Height));
        }

        private void mItemPrintContestant_Click(object sender, EventArgs e)
        {
        }

        private void mItemPrintResultContestant_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport(divisionShiftID, supervisorID, shiftID);
            frm.ShowDialog();
        }

        private void mItemPrintSpeaking_Click(object sender, EventArgs e)
        {
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverSocket != null)
            {
                serverSocket.CloseSocket();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            foreach (int i in indexPage)
            {
                if (e.TabPageIndex == i)

                {
                    divisionShiftID = ListDivisionShiftID[i];
                    shiftID = ListShiftID[i];
                }
            }
        }
    }
}