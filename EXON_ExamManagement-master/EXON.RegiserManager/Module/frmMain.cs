using EOS.Main.Module.Forms;
using EXON.Common;
using EXON.Data.Services;
using EXON.RegisterManager.Module.Controls;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace EXON.RegisterManager.Module
{
    public partial class frmMain : MetroForm
    {
        public ModulesNavigator modulesNavigator;
        private ContestService _ContestService;
        private StaffService _StaffService;

        //int _contestID = 0;
        private int CurrentContestID
        {
            get; set;
        }

        private FrmLogin login;

        public frmMain()
        {
            InitializeService();
            InitializeComponent();
            InitializeLogin();
            //RibbonButtonsInitialize();
            //InitializeTreeView();
            InitializeUcDangKy();
        }

        public frmMain(int contestID, int staffid)
        {
            CurrentContestID = contestID;
            BaseControl.CurrentStaffId = staffid;
            InitializeService();
            InitializeComponent();
            InitializeLogin();
            //RibbonButtonsInitialize();
            //InitializeTreeView();
            InitializeUcDangKy();
        }

        private void InitializeService()
        {
            _ContestService = new ContestService();
            _StaffService = new StaffService();
        }

        private void InitializeLogin()
        {
            if (modulesNavigator == null) modulesNavigator = new ModulesNavigator(pcMain);
            if (BaseControl.CurrentStaffId > 0)
            {
                STAFF currentStaff = _StaffService.GetById(BaseControl.CurrentStaffId);
                bhiStaff.Text = "Xin Chào " + currentStaff.FullName;
            }
        }

        private void InitializeUcDangKy()
        {
            try
            {
                BaseModule.CurrentContestID = CurrentContestID;
                _ContestService = new ContestService();
                CONTEST contest = new CONTEST();
                contest = _ContestService.GetById(CurrentContestID);
                BaseModule.CurrentContestStatus = contest.Status;
                stripStatusContest.Text = "Kỳ thi " + contest.ContestName;

                ucQuanLiThiSinh dangki = new ucQuanLiThiSinh();
                modulesNavigator.ChangeGroup(dangki);
                //modulesNavigator.CurrentModule.Refresh();
            }
            catch (Exception ex)
            { }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (modulesNavigator == null)
                this.Close();
        }
    }
}