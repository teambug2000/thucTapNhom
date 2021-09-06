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
namespace EXON.GradedEssay
{
    public partial class frmMain : MetroForm
    {
       private int ContestID;
        public frmMain( int _ContestID)
        {

            InitializeComponent();
            this.ContestID = _ContestID;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            frmWriting frm = new frmWriting(ContestID);
            frm.ShowDialog();
        }

        private void mbtnSpeaking_Click(object sender, EventArgs e)
        {
            frmSpeaking frm = new frmSpeaking(ContestID);
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
