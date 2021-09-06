using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubData.Services;
using EXON.SubModel.Models;
using EXON.MONITOR.Common;
using System.Collections;
using GeneralManagement.Supervisors;
using UserHelper;
using MetroFramework;
using System.Net;
using EXON.MONITOR.GUI;
using EXON.MONITOR.Report;

namespace EXON.MONITOR.Control
{
    public partial class ucServer : UserControl
    {
        #region Declare
        private DIVISION_SHIFTS ds;
        private IContestantShiftService _ContestantShiftService;
        private IContestantTestService _ContesttantTestService;
        private IContestantService _ContestantService;
        private IRoomDiagramService _RoomdiagramService;
        private ITestNumberService _TestNumberService;
        private IDivisionShiftService _DivisionShiftService;
        private IScheduleService _ScheduleService;
        private IBagOfTestService _BagOfTestService;
        private ITestService _TestService;
        private IExaminationcouncilStaffService _ExaminationcouncilStaffService;
        private IViolationContestantService _ViolationContestantService;
        private IViolationService _ViolationService;
        private int _divisionShiftID;
        private int _roomTestID;
        private int _shiftID;
        private int _StatusDivisionShift;
        private bool isCheckArr = false;
        //private ServerSide serverSocket;
        private bool isDecrypt;
        private List<ContestantInformation> lstCIConnected = new List<ContestantInformation>();
      
        public bool CheckDivisionTest = false;
        private int _ctID;
        private int _cshID;
        #endregion
        #region Constructor
        public ucServer()
        {
            InitializeComponent();
        }
        public ucServer(DIVISION_SHIFTS _ds)
        {
            InitializeComponent();
            _RoomdiagramService = new RoomDiagramService();
            _ContestantService = new ContestantService();
            _ContestantShiftService = new ContestantShiftService();

            this.ds = _ds;
            this._divisionShiftID = ds.DivisionShiftID;
            this._roomTestID = ds.RoomTestID;
            this._shiftID = ds.ShiftID;
            this._StatusDivisionShift = ds.Status;
            if (ds != null)
            {
                if (ds.Status == (int)Constant.StatusDivisionShift.STATUS_INIT)
                {
                    //  ArrangeContestant();
                }
            }
        }
        #endregion
     
        /// <summary>
        /// Xếp chỗ cho từng thí sinh
        /// </summary>
        private void ArrangeContestant()
        {
            int count_error = 0;
            try
            {

                _DivisionShiftService = new DivisionShiftService();
                  _RoomdiagramService = new RoomDiagramService();
                _TestNumberService = new TestNumberService();
                txtMessageBox.Clear();
                _ContestantShiftService = new ContestantShiftService();
                List<int> listContestantShiftID = _ContestantShiftService.ListContestantShiftID(_divisionShiftID);
                List<int> listRoomDiaID = _RoomdiagramService.ListRoomDiaID(_roomTestID);
                List<int> listCountContestantShiftID = new List<int>();
                for (int i = 1; i <= listContestantShiftID.Count; i++)
                {
                    listCountContestantShiftID.Add(i);
                }
                if (listContestantShiftID.Count <= listRoomDiaID.Count)
                {
                    Hashtable hasData = new Hashtable();
                    //sinh so phach
                    GenTestNumberindex(listContestantShiftID, listCountContestantShiftID, out hasData);
                    foreach (DictionaryEntry entry in hasData)
                    {
                        TESTNUMBER tn = new TESTNUMBER();

                        tn.ContestantShiftID = Convert.ToInt32(entry.Key);
                        if ((int)entry.Value < 10)
                        {
                            tn.TestNumberIndex = "00" + entry.Value.ToString();
                        }
                        else if ((int)entry.Value < 100)
                        {
                            tn.TestNumberIndex = "0" + entry.Value.ToString();
                        }
                        else
                        {
                            tn.TestNumberIndex = entry.Value.ToString();
                        }
                        _TestNumberService.Add(tn);
                        _TestNumberService.Save();
                        ArrangeContestant();
                        return;
                    }

                    // xep cho
                    ArrangeForContestant(listContestantShiftID, listRoomDiaID, out hasData);

                    #region tiến hành xếp chỗ

                    foreach (DictionaryEntry entry in hasData)
                    {
                        CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                        contestantShift = _ContestantShiftService.GetById(Convert.ToInt32(entry.Key));
                        contestantShift.RoomDiagramID = Convert.ToInt32(entry.Value);
                        ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                        roomDia = _RoomdiagramService.GetById(Convert.ToInt32(entry.Value));
                        //????? contestantShift.ClientIP = roomDia.ClientIP;
                        _ContestantShiftService.Update(contestantShift);
                        _ContestantShiftService.Save();
                    }
                    if (count_error != 0)
                    {
                        txtMessageBox.Text = string.Format("Xếp chỗ bị sai {0}  vị trí. Xếp lại", (listContestantShiftID.Count - listRoomDiaID.Count));
                    }
                    else
                    {
                        lsbTrace.Items.Add(string.Format(" Xếp chỗ thành công"));
                        lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;

                        _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_ARR);
                    }

                    #endregion tiến hành xếp chỗ
                }
                else
                {
                    txtMessageBox.Text = string.Format("Không đủ chỗ để xếp. Thiếu {0} chỗ để xếp được, Bổ xung hoặc chuyển ca", count_error);
                    lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                count_error++;
            }
        }

        private void ArrangeForContestant(List<int> listContestantShiftID, List<int> listRoomDiaID, out Hashtable hasData)
        {
            List<int> lstTest = listRoomDiaID;
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in listContestantShiftID.ToList())
            {
                int rndvalue = rnd.Next(listRoomDiaID.Count);
                htbReturnData.Add(contestantShiftID, listRoomDiaID[rndvalue]);
                listRoomDiaID.RemoveAt(rndvalue);
            }
            hasData = htbReturnData;
        }

        private void GenTestNumberindex(List<int> listContestantShiftID, List<int> listCountContestantShiftID, out Hashtable hasData)
        {
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in listContestantShiftID.ToList())
            {
                int rndvalue = rnd.Next(listCountContestantShiftID.Count);
                htbReturnData.Add(contestantShiftID, listCountContestantShiftID[rndvalue]);
                listCountContestantShiftID.RemoveAt(rndvalue);
            }
            hasData = htbReturnData;
        }

        private void ucServer_Load(object sender, EventArgs e)
        {
            LoadComputer1(pnlUcComputer);
            if (ds.Status == (int)Constant.StatusDivisionShift.STATUS_INIT)
                GenerateTestForContestant();
            EnableButton(ds.Status);
        }
        private void EnableButton(int _status)
        {
            if (_status == (int)Constant.StatusDivisionShift.STATUS_INIT)
            {
                mbtnAuthen.Enabled = true;
                mbtnDecry.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == (int)Constant.StatusDivisionShift.STATUS_ARR)
            {
                mbtnAuthen.Enabled = true;
                mbtnDecry.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_VERITY)
            {
                mbtnAuthen.Enabled = true;
                mbtnDecry.Enabled = true;
                isDecrypt = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_DECRYPT)
            {
                mbtnDecry.Enabled = false;
                isDecrypt = true;
                 mbtnDivsionTest.Enabled = true;
                //mbtnDivsionTest.Enabled = true;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_DIVISIONTEST)
            {

                isDecrypt = true;
                mbtnDecry.Enabled = false;
                mbtnStartTest.Enabled = true;
                mbtnDivsionTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_STARTTEST)
            {
                mbtnDecry.Enabled = false;
                isDecrypt = true;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else
            {
                mbtnDecry.Enabled = false;
                mbtnAuthen.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
        }

        /// <summary>
        /// sinh đề cho từng thí sinh
        /// </summary>
        private void GenerateTestForContestant()
        {
            _ContestantShiftService = new ContestantShiftService();
            _ScheduleService = new ScheduleService();
            _DivisionShiftService = new DivisionShiftService();
            _ContesttantTestService = new ContestantTestService();
            _TestService = new TestService();
            _BagOfTestService = new BagOfTestService();
            try
            {
                List<SCHEDULE> listSchedule = (from obj in _ContestantShiftService.GetAllByDivisionShiftID(_divisionShiftID).Select(x => x.ScheduleID).Distinct()
                                               from schedule in _ScheduleService.GetAll().Where(x => x.ScheduleID == obj)
                                               select schedule
                                             ).ToList();

                if (listSchedule.Count > 0)
                {
                    foreach (SCHEDULE item in listSchedule)
                    {
                        if (item != null && item.SubjectID > 0)
                        {
                            List<int> listContestantShiftID = (from obj in _ContestantShiftService.GetAllByScheduleShift(item.ScheduleID, _divisionShiftID)
                                                               select obj.ContestantShiftID
                                                              ).ToList();
                            List<int> listTestIDForSubject = (from bagoftest in _BagOfTestService.GetAll().Where(x => x.DivisionShiftID == _divisionShiftID)
                                                              from Test in _TestService.GetAll().Where(x => x.BagOfTestID == bagoftest.BagOfTestID && x.SubjectID==item.SubjectID)
                                                              select Test.TestID
                                                              ).ToList();
                
                            if (listContestantShiftID.Count <= listTestIDForSubject.Count)
                            {
                                Hashtable hasData = new Hashtable();
                                GenerateTestForContestantOutHash(listContestantShiftID, listTestIDForSubject, out hasData);
                                foreach (DictionaryEntry entry in hasData)
                                {
                                    int contestantShiftID = Convert.ToInt32(entry.Key);
                                    CONTESTANTS_TESTS ct = _ContesttantTestService.GetByContestShiftId(contestantShiftID);
                                    if (ct != null)
                                    {
                                        CONTESTANTS_TESTS contestantTest = _ContesttantTestService.GetAll().Where(x => x.ContestantShiftID == contestantShiftID).SingleOrDefault();
                                        contestantTest.TestID = Convert.ToInt32(entry.Value);
                                        _ContesttantTestService.Update(contestantTest);
                                        _ContesttantTestService.Save();

                                    }
                                    else
                                    {
                                        CONTESTANTS_TESTS contestantTest = new CONTESTANTS_TESTS();
                                        contestantTest.ContestantShiftID = contestantShiftID;
                                        contestantTest.TestID = Convert.ToInt32(entry.Value);
                                        contestantTest.Status = 4001;
                                        _ContesttantTestService.Add(contestantTest);
                                        _ContesttantTestService.Save();

                                    }
                                }
                            }
                        }
                    }
                    _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_ARR);
                    mbtnAuthen.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void GenerateTestForContestantOutHash(List<int> listContestantShiftID, List<int> listTestIDForSubject, out Hashtable hasData)
        {

            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in listContestantShiftID)
            {
                int rndvalue = rnd.Next(listTestIDForSubject.Count);
                htbReturnData.Add(contestantShiftID, listTestIDForSubject[rndvalue]);
                listTestIDForSubject.RemoveAt(rndvalue);
            }
            hasData = htbReturnData;
        }


        #region UC Computer
        private void LoadComputer1(Panel pnl)
        {
            pnl.Controls.Clear();
            _DivisionShiftService = new DivisionShiftService();
            _RoomdiagramService = new RoomDiagramService();
            Point newP = new Point(5, 10);
            List<ROOMDIAGRAM> lstRoomdiagram = new List<ROOMDIAGRAM>();
            lstRoomdiagram = _RoomdiagramService.GetAll().Where(x => x.RoomTestID == _roomTestID).ToList();
            if (lstRoomdiagram.Count > 0)
            {
                for (int i = 0; i < lstRoomdiagram.Count; i++)
                {
                    ucComputer uccomputer = new ucComputer(lstRoomdiagram[i], _DivisionShiftService.GetByShiftAndRoomTest(_shiftID, _roomTestID).DivisionShiftID);
                    if (i % 6 == 0 && i != 0)
                    {
                        //newP = uccomputer.Location;
                        newP.X = 5;
                        newP.Y += uccomputer.Height + 20;
                    }
                    else if (i != 0)
                    {
                        newP.X += uccomputer.Width + 10;
                    }

                    uccomputer.Location = newP;
                    uccomputer.Name = lstRoomdiagram[i].ComputerName;
                    if (_StatusDivisionShift >= (int)Constant.StatusDivisionShift.STATUS_ARR)
                    {
                        uccomputer.DisablecbCheckFP();
                    }
                    uccomputer.ImageClick += new EventHandler(UserControl_ButtonClick);
                    uccomputer.RightClick += new EventHandler(Uccomputer_RightClick);
                    pnl.Controls.Add(uccomputer);
                }
            }
        }
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event
          
            try
            {
                ucComputer uc = (ucComputer)sender;
                txtMessageBox.Clear();
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                _ContestantShiftService = new ContestantShiftService();
                cs = _ContestantShiftService.GetById(uc.contestanshifttid);
                if (cs != null)
                {

                    #region hiển thị thông tin contestant

                    txtFullName.Text = cs.CONTESTANT.FullName;
                    txtContestantCode.Text = cs.CONTESTANT.ContestantCode;
                    txtIdentity.Text = cs.CONTESTANT.IdentityCardNumber;
                    txtDOB.Text = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToShortDateString();
                    txtContestantID.Text = cs.CONTESTANT.ContestantID.ToString();
                    txtTimesViolation.Text = Convert.ToString(cs.VIOLATIONS_CONTESTANTS.Count);
                    txtComputerName.Text = cs.ROOMDIAGRAM.ComputerName;
                    txtSubject.Text = cs.SCHEDULE.SUBJECT.SubjectName;
                    if (Convert.ToInt32(cs.CONTESTANT.Sex) == 1)
                    {
                        txtSex.Text = "Nam";
                    }
                    else
                    {
                        txtSex.Text = "Nữ";
                    }

                    int contestantID = Convert.ToInt32(txtContestantID.Text);

                    if (cs.Status == UserHelper.Common.STATUS_DOING)
                    {
                        btnViolation.Enabled = true;                  
                    }
                    else
                    {
                        btnViolation.Enabled = false ;
                    }
                    #endregion hiển thị thông tin contestant
                }
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = String.Format(ex.Message);
            }
        }

        private void Uccomputer_RightClick(object sender, EventArgs e)
        {

            try
            {
                ucComputer uc = (ucComputer)sender;
                txtMessageBox.Clear();
                _ContestantShiftService = new ContestantShiftService();
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                cs = _ContestantShiftService.GetById(uc.contestanshifttid);
                if (cs != null)
                {
                    metroContextMenu1.Show(uc, new Point(45, 45));
                    _ctID = cs.ContestantID;
                    _cshID = cs.ContestantShiftID;

                    if (cs.Status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
                    {
                        MenuItemDivisionShift.Enabled = true;
                    }
                    else if (cs.Status == UserHelper.Common.STATUS_READY)
                    {
                        MenuItemStartTest.Enabled = true;
                    }
                    else
                    {
                        MenuItemDivisionShift.Enabled = false;
                        MenuItemStartTest.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = String.Format(ex.Message);
            }
        }
        #endregion

        private void serverSocket_ClientConnected(object sender, object data)
        {
            var client = data as SocketController;
            IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;
            //SetText(remote.Address.ToString() + ":" + remote.Port.ToString() + " vừa kết nối...\n");
            //lstbTraceLog.SelectedIndex = lstbTraceLog.Items.Count - 1;
            client.Receive += client_Receive;
        }

        private delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lsbTrace.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lsbTrace.Items.Add(text);
                lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
            }
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
                // và ko pahir cập nhật thời gian đã làm bài được
                if (index > -1)
                {
                    ContestantInformation CI = lstCIConnected[index];
                    CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                    CONTESTANT contestant = new CONTESTANT();
                    contestantShift = _ContestantShiftService.GetByContestantID(_divisionShiftID, client.UserID);
                    if (contestantShift != null)
                    {
                        contestant = _ContestantService.GetById(contestantShift.ContestantID);
                        //contestantShift.Status = UserHelper.Common.STATUS_DOING_BUT_INTERRUPT;
                    }
                    if (CI.UserTransfer.Status == UserHelper.Common.STATUS_DOING_BUT_INTERRUPT)
                    {
                        SetText(string.Format("Tự tắt chương trình. Vui lòng kiểm tra máy thi này [{0}]", CI.UserTransfer.ComputerName));
                        isCheckArr = true;
                    }
                    else
                    {
                        if (CI.UserTransfer.Status != UserHelper.Common.STATUS_FINISHED)
                        {
                            if (contestantShift != null && contestant != null)
                            {
                                DateTime timeDisconnect = Common.DatetimeConvert.GetDateTimeServer();
                                contestantShift.Status = UserHelper.Common.STATUS_DOING_BUT_INTERRUPT;
                                _ContestantShiftService.Update(contestantShift);
                                _ContestantShiftService.Save();
                                SetText(string.Format("Thí sinh [{0}] mất kết nối lúc : [{1}]", contestant.FullName, timeDisconnect.ToString("HH: mm:ss")));
                                SetupdateUC(client.UserID);
                            }
                        }
                    }
                    lstCIConnected.RemoveAt(GetIndexClientFromList(client));
                    //serverSocket.ClientList.Remove(client);
                }
                client.Dispose();
            }
            catch
            {
            }
        }

        private int GetIndexClientFromList(SocketController sc)
        {
            IPEndPoint remote = (IPEndPoint)sc.Sock.RemoteEndPoint;
            int index = lstCIConnected.FindIndex(x => x.IPPORT == string.Format("{0}:{1}", remote.Address, remote.Port));
            return index;
        }

        #region Nhan tin hieu tu client

        private void client_Receive(object sender, object data)
        {
            
            var client = (SocketController)sender;
            UserTransformation Recieve = new UserTransformation();
            Recieve = Ultis.FromJSONToObject((string)data);
            client.UserID = Recieve.UserID;
            if (_RoomdiagramService.GetByComputername(Recieve.ComputerName) == _roomTestID)
            { 
                if (Recieve.ComputerName!=null && Recieve.Status==UserHelper.Common.STATUS_LOGGED)
            {
                CheckComputerForContestant(Recieve.ComputerName,Recieve.UserID);
            }
         
            //    AddToView(Recieve);
            CONTESTANT contestant = new CONTESTANT();
            contestant = _ContestantService.GetSigleByUserCode(Recieve.UserCode);
            if (Recieve.Status != UserHelper.Common.STATUS_LOGGED || Recieve.Status != UserHelper.Common.STATUS_LOGGED_DO_NOT_FINISH || Recieve.Status == UserHelper.Common.STATUS_READY)
            {
                IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;
                foreach (ContestantInformation CI in lstCIConnected)
                {
                    if (CI.IPPORT == string.Format("{0}:{1}", remote.Address, remote.Port))
                    {
                        if (Recieve.Status == UserHelper.Common.STATUS_LOGIN_FAIL)
                        {
                            CI.LoginError++;
                        }
                        CI.UserTransfer = Recieve;
                    }
                }
                if (Recieve.Status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
                {
                    HandleEnableDivisionTest();
                }

                if (Recieve.Status == UserHelper.Common.STATUS_READY)
                {
                    HandleEnableStartTest();
                }
            }


            if (Recieve.Status == UserHelper.Common.STATUS_LOGGED || Recieve.Status == UserHelper.Common.STATUS_LOGGED_DO_NOT_FINISH || Recieve.Status == UserHelper.Common.STATUS_READY)
            {
                ContestantInformation CI = new ContestantInformation();
                CI.IPPORT = string.Format("{0}:{1}", client.IPERemote.Address, client.IPERemote.Port);
                CI.LoginStatus = Recieve.Status;
                CI.UserTransfer = Recieve;
                lstCIConnected.Add(CI);
            }
            else
            {
                if (Recieve.Status == UserHelper.Common.STATUS_REPORT_ERROR)
                {
                    if (contestant != null)
                    {
                        CONTESTANTS_SHIFTS contestantShift;

                        contestantShift = new CONTESTANTS_SHIFTS();
                        contestantShift = _ContestantShiftService.GetByContestantID(_divisionShiftID, contestant.ContestantID);
                        if (contestantShift != null)
                        {
                            MetroMessageBox.Show(this, "Thí sinh" + contestant.FullName + " thông báo lỗi tại vị trí " + contestantShift.ROOMDIAGRAM.ComputerName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 150);
                        }

                    }
                }

            }
            SetupdateUC(Recieve.UserID);
            }
        }
        //edit one
        private delegate void SetLoadUCCallback(string computerName,int id);
        public void CheckComputerForContestant(string computerName, int userID)
        {
            try
            {
                if (this.pnlUcComputer.InvokeRequired)
                {
                    SetLoadUCCallback d = new SetLoadUCCallback(CheckComputerForContestant);
                    this.Invoke(d, new object[] { computerName, userID });
                }
                else
                {
                    foreach (ucComputer i in pnlUcComputer.Controls)
                    {
                        if (i.ComputerName == computerName)
                        {
                            i.LoadInfoContestantByContestantID(_divisionShiftID, userID);
                            return;
                        }
                    }

                }
            }
            catch(Exception ex)
            { }
           
            
        }

        public void HandleEnableStartTest()
        {        
            Setbtn(true, 1);

        }
        private delegate bool SetCheckUserIDCallback(int id);
        private bool SetCheckUserID(int id)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pnlUcComputer.InvokeRequired)
            {
                SetCheckUserIDCallback d = new SetCheckUserIDCallback(SetCheckUserID);
                this.Invoke(d, new object[] { id });
                return true;
            }
            else
            {
               foreach (ucComputer i in pnlUcComputer.Controls)
                        {
                            if (i.contestantid == id)
                                return true;
                        }
                return false;
            }
        }

        public void HandleEnableDivisionTest()
        {
            bool isEnable = true;
           
            Setbtn(isEnable, 0);
        }
        private delegate void SetbtnCallback(bool enable, int detail);
        private void Setbtn(bool enable, int detail)
        {
            if (this.mbtnStartTest.InvokeRequired || mbtnDivsionTest.InvokeRequired)
            {
                SetbtnCallback d = new SetbtnCallback(Setbtn);
                this.Invoke(d, new object[] { enable, detail });
            }
            else
            {
                if (detail == 1) mbtnStartTest.Enabled = enable;
                else
                {
                    if (enable && isDecrypt) mbtnDivsionTest.Enabled = true;
                }
            }
        }

        private void AddToView(UserTransformation recieve)
        {
            throw new NotImplementedException();
        }

        private delegate void SetUpdateUCCallback(int id);

        public void SetupdateUC(int id)
        {
            try
            {
                if (this.pnlUcComputer.InvokeRequired)
                {
                    SetUpdateUCCallback d = new SetUpdateUCCallback(SetupdateUC);
                    this.Invoke(d, new object[] { id });
                }
                else
                {
                    foreach (ucComputer i in pnlUcComputer.Controls)
                    {
                        if (i.contestantid == id)
                        {
                            i.LoadStatusContestan();
                            return;
                        }
                    }

                }
            }
            catch (Exception ex)
            { }
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
       
        }
        #endregion

        #region Quy trinh tổ chức thi


        private void mbtnAuthen_Click(object sender, EventArgs e)
        {
            try
            {
                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                lstcs = _ContestantShiftService.GetAllByDivisionShiftID(_divisionShiftID).ToList();
                if(_StatusDivisionShift==(int)Constant.StatusDivisionShift.STATUS_INIT)
                foreach (CONTESTANTS_SHIFTS cs in lstcs)
                {
                    if (cs.IsCheckFingerprint != 1)
                        cs.IsCheckFingerprint = 2;
                    cs.Status = 4001;
                    _ContestantShiftService.Update(cs);
                    _ContestantShiftService.Save();
                }
                if (_StatusDivisionShift <= (int)Constant.StatusDivisionShift.STATUS_ATTENDANCE)
                {

                    foreach (ucComputer uc in pnlUcComputer.Controls)
                    {
                        if (uc.contestantid > 0)
                        {
                            int ContestantShiftID = uc.contestanshifttid;
                            if (uc.CheckedConfirm == true)
                            {
                                uc.DisablecbCheckFP();

                            }
                            uc.CheckedConfirmtoload = false;
                            uc.LoadInfoContestant();
                        }
                    }
                    _DivisionShiftService.UpdateStatus(_divisionShiftID, UserHelper.Common.STATUS_VERITY); //đổi trạng thái divisionshift
                }

                //serverSocket.ClientConnected += serverSocket_ClientConnected;
                //serverSocket.ClientDisConnected += serverSocket_ClientDisconnected;
                lsbTrace.Items.Add(string.Format("Bắt đầu giám sát thi"));
                lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                btnChangeComputerName.Enabled = true;
                if (!isDecrypt)
                {
                    mbtnDecry.Enabled = true;
                }
                mbtnAuthen.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }

        private void mbtnDecry_Click(object sender, EventArgs e)
        {
            frmInputKey frm = new frmInputKey(_divisionShiftID);
            frm.Show();
            frm.Sender += Frm_Sender;
        }
        private void Frm_Sender(bool _IsDecrypt)
        {
            isDecrypt = _IsDecrypt;
            if (isDecrypt)
            {
                //if (CheckDivisionTest)
                //{
                 mbtnDivsionTest.Enabled = true;
               // }
                mbtnDecry.Enabled = false;
            }
        }

        public event EventHandler btnDivisionTestClick;

        private void mbtnDivsionTest_Click(object sender, EventArgs e)
        {
            try
            {
                _DivisionShiftService = new DivisionShiftService();
                //_ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
                //UserTransformation UT = new UserTransformation();

                //EXAMINATIONCOUNCIL_STAFFS supervisor = _ExaminationcouncilStaffService.GetByStaffID(AppSession.StaffID);
                //if (supervisor != null)
                //{
                //    UT.UserID = (int)supervisor.StaffID;
                //    UT.UserCode = supervisor.UserName;
                //}
                //else
                //{
                //    UT.UserID = 0;
                //    UT.UserCode = "SERVER";
                //}
                //// Trạng thái nhận đề thi và danh sách câu hỏi (Gửi) gửi cho thí sinh
                //UT.Status = 3011;
                //UT.Content = "Hãy lấy đề thi";
                //mbtnDivsionTest.Enabled = false;

                //// btnDivisionTest.BackColor = Color.Gray;     
                //if (frmServer.serverSocket.ClientList.Count > 0)
                //{
                //    foreach (SocketController sc in frmServer.serverSocket.ClientList)
                //    {
                //        if (CheckUserID(sc.UserID))
                //        {
                //            if (sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT)))
                //            {
                //                lsbTrace.Items.Add(string.Format("Gửi cho [{0}] trạng thái phát đề thành công", sc.UserID));
                //            }
                //            else
                //            {
                //                lsbTrace.Items.Add(string.Format("Gửi trạng thái phát đề cho [{0}] đề không thành công. Phát đề lại", sc.UserID));
                //            }
                //            lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                //        }
                //    }
                mbtnDivsionTest.Enabled = false;
                    _DivisionShiftService.UpdateStatus(_divisionShiftID, UserHelper.Common.STATUS_DIVISIONTEST);
                    lsbTrace.Items.Add(string.Format("Phát đề thành công"));
                mbtnStartTest.Enabled = true;
                //}
                //else
                //{
                //    lsbTrace.Items.Add(string.Format("Chưa có thí sinh nào kết nối tới server"));
                //    mbtnDivsionTest.Enabled = true;
                //    return;
                //}
                if(btnDivisionTestClick!=null)
                {
                    btnDivisionTestClick(this,e);
                }

            }
            catch
            {
            }

        }

        public bool CheckUserID(int userID)
        {

            Panel pnl = (Panel)pnlUcComputer;
            foreach (ucComputer i in pnl.Controls)
            {
                if (i.contestantid == userID && i.status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
                    return true;
            }
            return false;
        }

        private void mbtnStartTest_Click(object sender, EventArgs e)
        {
            try
            {
                //UserTransformation UT = new UserTransformation();
                //_ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
                //EXAMINATIONCOUNCIL_STAFFS supervisor = _ExaminationcouncilStaffService.GetByStaffID(AppSession.StaffID);
                //if (supervisor != null)
                //{
                //    UT.UserID = (int)supervisor.StaffID;
                //    UT.UserCode = supervisor.UserName;
                //}
                //else
                //{
                //    UT.UserID = 0;
                //    UT.UserCode = "SERVER";
                //}


                //// gửi trạng thái bắt đầu làm bài thi đến tất cả các thí sinh trong list danh sách
                //UT.Status = 3009;
                //UT.Content = "Tất cả bắt đầu làm bài";

                ////  AddToView(UT);
                //txtMessageBox.Clear();
                //int count_error = 0;
                //if (frmServer.serverSocket.ClientList != null)
                //{
                //    foreach (SocketController sc in frmServer.serverSocket.ClientList)
                //    {
                //        if (CheckUserIDForStartTest(sc.UserID))
                //        {
                //            sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                //        }
                //    }

                //    if (count_error > 0)
                //    {
                //        txtMessageBox.ForeColor = Color.Red;
                //        lsbTrace.Items.Add("Bắt đầu thi không thành công, Gửi lại");
                //        mbtnStartTest.Enabled = true;
                //    }
                //    else
                   // {
                        _DivisionShiftService.UpdateStatus(_divisionShiftID, UserHelper.Common.STATUS_STARTTEST);
                        mbtnStartTest.Enabled = false;
                    //}
              //  }
                //else
                //{
                //    lsbTrace.Items.Add("Nothing in server");
                //    mbtnStartTest.Enabled = true;
                //}
                //mbtnDivsionTest.Enabled = false;
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = ex.ToString();
            }

        
        }

        private bool CheckUserIDForStartTest(int userID)
        {
            foreach (ucComputer i in pnlUcComputer.Controls)
            {
                if (i.contestantid == userID && i.status == UserHelper.Common.STATUS_READY)
                    return true;
            }
            return false;
        }
        #endregion

        #region Xử lý từng thí sinh

        private void MenuItemDivisionShift_Click(object sender, EventArgs e)
        {
            UserTransformation UT = new UserTransformation();
            _ContestantShiftService = new ContestantShiftService();
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            EXAMINATIONCOUNCIL_STAFFS supervisor = _ExaminationcouncilStaffService.GetByStaffID(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }

            // Trạng thái nhận đề thi và danh sách câu hỏi (Gửi) gửi cho thí sinh
            UT.Status = 3011;
            UT.Content = "Hãy lấy đề thi";
    
            try
            {
                foreach (SocketController sc in frmServer.serverSocket.ClientList)
                {
                    if (sc.UserID == _ctID)
                    {
                        CONTESTANTS_SHIFTS contestantShift = _ContestantShiftService.GetByContestantID(_divisionShiftID, sc.UserID);
                        if (contestantShift != null)
                        {                  
                               sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                               MenuItemDivisionShift.Enabled = false;
                               lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                               SetText(string.Format("Phát đề thành công"));
                               return;
                        }
                        else
                        {
                        }
                    }
                    break;
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối với thí sinh", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuItemStartTest_Click(object sender, EventArgs e)
        {
            UserTransformation UT = new UserTransformation();
            _ContestantShiftService = new ContestantShiftService();
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            EXAMINATIONCOUNCIL_STAFFS supervisor = _ExaminationcouncilStaffService.GetByStaffID(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
       
            // gửi trạng thái bắt đầu làm bài thi đến tất cả các thí sinh trong list danh sách
            UT.Status = 3009;
            if (UT.ComputerName != null)
            {
                UT.Content = "Thí sinh " + txtFullName.Text + " bắt đầu làm bài!";
            }       
            txtMessageBox.Clear();
            int count_error = 0;
            bool kt = false;
            if (frmServer.serverSocket.ClientList.Count > 0)
            {
                foreach (SocketController sc in frmServer.serverSocket.ClientList)
                {
                    if (sc.UserID == _ctID)
                    {
                        
                            sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                            kt = true;
                            break;    
                    }
                }

                if (!kt)
                {
                    txtMessageBox.Text = "Thí sinh " + txtFullName.Text + " chưa bắt đầu làm bài!";
                    SetText(txtMessageBox.Text);
                }
                if (count_error > 0)
                {
                    txtMessageBox.ForeColor = Color.Red;
                    SetText("Bắt đầu thi không thành công, Gửi lại");
                    MenuItemStartTest.Enabled = true;
                }
            }
            else
            {
                SetText("Nothing in server");
            }
        }

        private void MenuItemChangeShift_Click(object sender, EventArgs e)
        {
            _ContestantShiftService = new ContestantShiftService();
            CONTESTANTS_SHIFTS contestantShift = _ContestantShiftService.GetById(_cshID);
            if (contestantShift != null)
            {
                frmThongBaoChuyen frmTB = new frmThongBaoChuyen();
                frmTB.Show();
                frmTB.sendWorking += new frmThongBaoChuyen.SendNotifi(FrmTB_sendWorking);
            }
        }
        private void FrmTB_sendWorking(string Reason)
        {
            try
            {
                _ContestantShiftService = new ContestantShiftService();
                CONTESTANTS_SHIFTS contestantShift = _ContestantShiftService.GetById(_cshID);
                if (contestantShift != null)
                {
                    contestantShift.Status = UserHelper.Common.STATUS_CHANGE_SHIFT;
                    contestantShift.IsCheckFingerprint = null;
                    contestantShift.RoomDiagramID = null;
                    _ContestantShiftService.Update(contestantShift);
                    _ContestantShiftService.Save();

                    txtMessageBox.Clear();
                    txtMessageBox.Text = "Chuyển ca thi thành công!";
                    LoadComputer1(pnlUcComputer);
                    frmBienBanChuyenCaThi frmBB = new frmBienBanChuyenCaThi(txtContestantCode.Text, txtFullName.Text, Reason, txtIdentity.Text, _divisionShiftID);
                    frmBB.Show();


                }
            }
            catch
            {
                MessageBox.Show("Chưa chuyển được thí sinh");
            }
        }
        #endregion

        private void btnViolation_Click(object sender, EventArgs e)
        {
            try
            {
                _ContestantShiftService = new ContestantShiftService();
                _ViolationContestantService = new ViolationContestantService();
                _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
                _ViolationService = new ViolationService();
                txtMessageBox.Clear();
            UserTransformation UT = new UserTransformation();
            EXAMINATIONCOUNCIL_STAFFS supervisor = _ExaminationcouncilStaffService.GetByStaffID(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
                DialogResult dr = MessageBox.Show(string.Format("Bạn có chắc chắn cảnh cáo thí sinh {0} không?", txtFullName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    UT.Status = 3008; // thí sinh bị cảnh cáo thì đưa ra thông báo và update vào bảng contestant_violation
                    UT.Content = "Vi phạm quy chế thi";
                    int contestantID = Convert.ToInt32(txtContestantID.Text);
                    CONTESTANTS_SHIFTS contestantShift = _ContestantShiftService.GetByContestantID(_divisionShiftID, contestantID);
                    if (contestantShift.Status == UserHelper.Common.STATUS_DOING || contestantShift.Status == UserHelper.Common.STATUS_REPORT_ERROR)
                    {
                        VIOLATION vs = _ViolationService.GetAll().FirstOrDefault();
                        
                                    VIOLATIONS_CONTESTANTS vio_contestant = new VIOLATIONS_CONTESTANTS()
                                    {
                                        Status = 1,
                                        ViolationID = vs.ViolationID,
                                        ContestantShiftID= contestantShift.ContestantShiftID,
                                        TimeSave = DatetimeConvert.ConvertDateTimeToUnix(Common.DatetimeConvert.GetDateTimeServer())
                                    };          
                                        _ViolationContestantService.Add(vio_contestant);
                                        _ViolationContestantService.Save();   
                                         int countTimesViolation =_ViolationContestantService.GetByConstestshiftID(contestantShift.ContestantShiftID).Count();
                                         txtTimesViolation.Text = Convert.ToString(countTimesViolation) + " lần";                 
                                        lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                                         LoadViolation(contestantShift.ContestantShiftID);
                                }                 
                        else
                    {
                        txtMessageBox.Text = (string.Format("Cảnh cáo chỉ được diễn ra khi trạng thái ĐANG THI"));
                        return;
                    }
                }
            }
          
            catch (Exception ex)
            {
                txtMessageBox.Text = (string.Format("Cảnh cáo thí sinh [{0}] không thành công",txtFullName.Text));
            }
        }

        private void LoadViolation(int _contestantShiftID)
        {        
           foreach (ucComputer i in pnlUcComputer.Controls)
                {
                   if (i.contestanshifttid == _contestantShiftID)
                    {
                     i.CountViolation();
                           
                      }
                 }        
        }
        private void btnChangeComputerName_Click(object sender, EventArgs e)
        {
            try
            {
                _RoomdiagramService = new RoomDiagramService();
                _ContestantShiftService = new ContestantShiftService();
                _ContestantService = new ContestantService();
                txtMessageBox.Clear();
                CONTESTANT contestant = new CONTESTANT();
                if (txtContestantID.Text != "" && cmbComName.SelectedValue != null)
                {
                    int contestantID;
                    contestantID = Convert.ToInt32(txtContestantID.Text);
                    contestant =_ContestantService.GetById(contestantID);
                    CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                    contestantShift =_ContestantShiftService.GetByContestantID(_divisionShiftID, contestantID);
                    ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                    roomDia = _RoomdiagramService.GetById(Convert.ToInt32(contestantShift.RoomDiagramID));

                    DialogResult dr = MessageBox.Show(string.Format("Bạn có chắn chắn chuyển chỗ ngồi từ {0} sang {1}?", roomDia.ComputerName, cmbComName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        roomDia.Status = 4002; // trạng thái máy hỏng
                        contestantShift.RoomDiagramID = Convert.ToInt32(cmbComName.SelectedValue);
                        contestantShift.DivisionShiftID = _divisionShiftID;
                        _RoomdiagramService.Update(roomDia);
                        _RoomdiagramService.Save();
                        _ContestantShiftService.Update(contestantShift);
                        _ContestantShiftService.Save();
                            frmBienBan frmbb = new frmBienBan(roomDia.ComputerName, cmbComName.Text, roomDia.ROOMTEST.RoomTestName, roomDia.ROOMTEST.RoomTestName, _divisionShiftID, contestant.FullName, contestant.ContestantCode);
                            frmbb.ShowDialog();
                            roomDia = _RoomdiagramService.GetById(Convert.ToInt32(contestantShift.RoomDiagramID));
                            roomDia.Status = 4001;
                            txtComputerName.Text = _RoomdiagramService.GetById(Convert.ToInt32(contestantShift.RoomDiagramID)).ComputerName;
                            txtMessageBox.Text = "Chuyển chỗ thành công";
                            cmbComName.Text = null;                         
                            roomDia.Status = 4001;
                            _RoomdiagramService.Update(roomDia);
                            _RoomdiagramService.Save();
                            LoadComputer1(pnlUcComputer);                        
                            }
         
                }
                else
                {
                    txtMessageBox.Text = " Hết vị trí có thể chuyển tới. Bạn cần tích vào chuyển chỗ và chọn máy muốn đổi tới";
                    txtMessageBox.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            { }
        }

        private void cmbComName_Click(object sender, EventArgs e)
        {
            LoadCmbComputerChange();
        }
        private void LoadCmbComputerChange()
        { 
            cmbComName.Text = "";
            List<ROOMDIAGRAM> listRoomDia = _RoomdiagramService.GetListRoomByDs(_divisionShiftID, _roomTestID);
            if (listRoomDia.Count > 0)
            {
                cmbComName.DataSource = listRoomDia;
                cmbComName.DisplayMember = "ComputerName";
                cmbComName.ValueMember = "RoomDiagramID";

                cmbComName.SelectedIndex = -1;
            }
            else
            {
                cmbComName.DataSource = null;
                cmbComName.Text = "Không có máy nào có thể chuyển đến";
            }
        }

        private void mbtnRefreshUC_Click(object sender, EventArgs e)
        {
            LoadComputer1(pnlUcComputer);
        }
    }
}
