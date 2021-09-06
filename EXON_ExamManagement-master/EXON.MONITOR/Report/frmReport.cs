using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel.Models;
using EXON.MONITOR.Common;

namespace EXON.MONITOR.Report
{
    public partial class frmReport : Form
    {
        private int divisionShiftID;
        private int SupervisorID;
        private SHIFT shift = new SHIFT();
        private int roomTestID;
        private int shiftID;

        public frmReport()
        {
            InitializeComponent();
        }

        public frmReport(int _DivisionShiftID, int _SupervisorID, int _shiftID)
        {
            this.shiftID = _shiftID;
            this.divisionShiftID = _DivisionShiftID;
            this.SupervisorID = _SupervisorID;

            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
           
            this.pR_REPORTCONTESTANTTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");

            this.pR_REPORTCONTESTANTTableAdapter.Fill(this.mTA_QUIZ_8DataSet.PR_REPORTCONTESTANT, divisionShiftID, SupervisorID);
            this.sTAFFSTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
            this.sHIFTSTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
            this.rOOMTESTSTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
            this.contestantNotCompleteApdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
            this.contestantNotCompleteApdapter.Fill(this.mTA_QUIZ_8DataSet.ContestantNotComplete, divisionShiftID);
            this.sHIFTSTableAdapter.Fill(this.mTA_QUIZ_8DataSet.SHIFTS, divisionShiftID);
            this.rOOMTESTSTableAdapter.Fill(this.mTA_QUIZ_8DataSet.ROOMTESTS, divisionShiftID);
            this.sTAFFSTableAdapter.Fill(this.mTA_QUIZ_8DataSet.STAFFS, SupervisorID);
            this.reportViewer1.RefreshReport();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

      

    
    }
}