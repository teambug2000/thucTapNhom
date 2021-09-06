using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.Model.Models;

namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmFilter : MetroFramework.Forms.MetroForm
    {
        private EOSDbContext db = new EOSDbContext();
        private int _contestid = 0;
        List<FilterLocation> lstLocation = new List<FilterLocation>();
        List<FilterRoomtest> lstRoomtest = new List<FilterRoomtest>();
        public int currentLocationID;
        public int currentRoomtestID;

        public frmFilter(int id)
        {
            InitializeComponent();
            _contestid = id;

            lstLocation = db.LOCATIONS.Where(p => p.ContestID == _contestid).Select(p => new FilterLocation
            {
                LocationID = p.LocationID,
                LocationName = p.LocationName
            }).ToList();            

            List<int> lst_tempLocation = lstLocation.Select(p => p.LocationID).ToList();
            lstRoomtest = db.ROOMTESTS.Where(p => lst_tempLocation.Contains((int)p.LocationID)).Select(p => new FilterRoomtest
            {
                RoomtestID = p.RoomTestID,
                RoomtestName = p.RoomTestName,
                LocationID = (int)p.LocationID
            }).ToList();

            cbx_DiaDiemThi.DisplayMember = "LocationName";
            cbx_DiaDiemThi.ValueMember = "LocationID";
            cbx_DiaDiemThi.DataSource = lstLocation;

            cbx_PhongThi.DisplayMember = "RoomtestName";
            cbx_PhongThi.ValueMember = "RoomtestID";
            currentLocationID = Convert.ToInt32(cbx_DiaDiemThi.SelectedValue);
            cbx_PhongThi.DataSource = lstRoomtest.Where(p => p.LocationID == currentLocationID).ToList();
            currentRoomtestID = Convert.ToInt32(cbx_PhongThi.SelectedValue);
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {

        }

        private void cbx_DiaDiemThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_PhongThi.DisplayMember = "RoomtestName";
            cbx_PhongThi.ValueMember = "RoomtestID";
            currentLocationID = Convert.ToInt32(cbx_DiaDiemThi.SelectedValue);
            cbx_PhongThi.DataSource = lstRoomtest.Where(p => p.LocationID == currentLocationID).ToList();
            currentRoomtestID = Convert.ToInt32(cbx_PhongThi.SelectedValue);
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbx_PhongThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLocationID = Convert.ToInt32(cbx_DiaDiemThi.SelectedValue);
            currentRoomtestID = Convert.ToInt32(cbx_PhongThi.SelectedValue);
        }

        private void frmFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }

    public class FilterLocation
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }

    public class FilterRoomtest
    {
        public int RoomtestID { get; set; }
        public string RoomtestName { get; set; }
        public int LocationID { get; set; }
    }
}
