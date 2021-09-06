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

namespace EXON.MONITOR.Control
{
    public partial class ucQuanLyMayThi : UserControl
    {
        private IRoomDiagramService _RoomDiagramService;
        private List<ROOMDIAGRAM> lstRoomdiagram;
        List<RoomDiagramFromRoomTest> lstComputer;
        private int _RoomDiagramID;
        private int _roomTestID;
        public ucQuanLyMayThi()
        {
            InitializeComponent();
        }
        public ucQuanLyMayThi(int roomtestID)
        {
            InitializeComponent();
            this._roomTestID = roomtestID;
      
            InitDataControl();
        }

        private void InitDataControl()
        {
            lstRoomdiagram = new List<ROOMDIAGRAM>();
            _RoomDiagramService = new RoomDiagramService();
          lstComputer = new List<RoomDiagramFromRoomTest>();
            lstRoomdiagram = _RoomDiagramService.GetAllByRoomTest(_roomTestID).ToList();
            int count = 0;
            for (int i = 0; i < lstRoomdiagram.Count; i++)
            {
               
                        RoomDiagramFromRoomTest rd= new RoomDiagramFromRoomTest
                                    {
                                             RoomDiagramID = lstRoomdiagram[i].RoomDiagramID,
                                              STT = ++count,
                                            ComputerCode = lstRoomdiagram[i].ComputerCode,
                                            ComputerName= lstRoomdiagram[i].ComputerName,                                       
                                             Status = lstRoomdiagram[i].Status == 4001 ? "Tốt" : "Hỏng",
                                          
                                         };
                lstComputer.Add(rd);
            }

            if (lstComputer != null)
            {
                gvMain.DataSource = lstComputer;
                lbCount.Text = string.Format("Tổng Số {0} máy thi", lstRoomdiagram.Count);
            }
            else gvMain.DataSource = null;

        
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < lstRoomdiagram.Count; i++)
            {
                collection.Add(lstRoomdiagram[i].ComputerName);
                collection.Add(lstRoomdiagram[i].ComputerCode);
             
            }

            this.cmbKeyName.AutoCompleteCustomSource = collection;
            this.cmbKeyName.AutoCompleteMode = AutoCompleteMode.Suggest;

            //UpdateButtonEnable();
        }

        private void UpdateButtonEnable()
        {
            throw new NotImplementedException();
        }

        private void ucQuanLyMayThi_Load(object sender, EventArgs e)
        {
            SetBackColor();
            
        }

        private void SetBackColor()
        {
            foreach (DataGridViewRow row in gvMain.Rows)
            {
                if (row.Cells["cStatus"].Value.ToString() == "Hỏng")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                    row.DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string a = cmbKeyName.Text;
            gvMain.DataSource = lstComputer.Where(z => z.ComputerName.Contains(a) || z.ComputerCode.Contains(a)).ToList();
            SetBackColor();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gvMain.DataSource = lstComputer;
            SetBackColor();
        }

        private void btnCheckStatusCom_Click(object sender, EventArgs e)
        {
            _RoomDiagramService.UpdateStatusbyAgent(_roomTestID);
            InitDataControl();
            SetBackColor();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            EXON.MONITOR.GUI.frmAddComputer frm = new GUI.frmAddComputer(_roomTestID, false);
            frm.ShowDialog();
            InitDataControl();
            SetBackColor();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            EXON.MONITOR.GUI.frmAddComputer frm = new GUI.frmAddComputer(_RoomDiagramID, true);
            frm.ShowDialog();
            InitDataControl();
            SetBackColor();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            EXON.MONITOR.GUI.frmImportRoom frm = new GUI.frmImportRoom(_roomTestID);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắn chắn muốn xóa máy thi này khỏi phòng thi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    _RoomDiagramService.Delete(_RoomDiagramID);
                    _RoomDiagramService.Save();
                    InitDataControl();
                    SetBackColor();
                }
            }
            catch
            {
               
            }
        }

        private void gvMain_SelectionChanged(object sender, EventArgs e)
        {
            _RoomDiagramID = int.Parse(gvMain.CurrentRow.Cells["cID"].Value.ToString());
        }

        private void btnFilt_Click(object sender, EventArgs e)
        {
            if (gvMain.DataSource == null) return;

            string NeedStatus = string.Empty;
            if (rdOK.Checked)
            {
                gvMain.DataSource = lstComputer.Where(z => z.Status == "Tốt").ToList();    
            }
            else if (rbError.Checked)
            {
                gvMain.DataSource = lstComputer.Where(z => z.Status == "Hỏng").ToList();                
            }
            else if (rbAll.Checked)
                gvMain.DataSource = lstComputer;
            SetBackColor();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitDataControl();
            SetBackColor();
        }
    }
    public enum StatusCom { error,ok};
    public class RoomDiagramFromRoomTest
    {
        public int RoomDiagramID { get; set; }
        public string ComputerCode { get; set; }
        public string ComputerName { get; set; }
          public int STT { get; set; }
        public string  Status { get; set; }
      
    }
}
