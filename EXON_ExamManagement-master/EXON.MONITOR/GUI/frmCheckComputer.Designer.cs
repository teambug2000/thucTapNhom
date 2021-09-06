namespace EXON.MONITOR.GUI
{
    partial class frmCheckComputer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRoomTest = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRoomTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mItemMenuCheckinRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).BeginInit();
            this.metroContextMenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRoomTest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 326);
            this.panel1.TabIndex = 0;
            // 
            // dgvRoomTest
            // 
            this.dgvRoomTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cSTT,
            this.cRoomTestName});
            this.dgvRoomTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoomTest.Location = new System.Drawing.Point(0, 0);
            this.dgvRoomTest.Name = "dgvRoomTest";
            this.dgvRoomTest.Size = new System.Drawing.Size(555, 326);
            this.dgvRoomTest.TabIndex = 0;
            this.dgvRoomTest.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRoomTest_CellMouseClick);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "RoomTestID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.Visible = false;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            // 
            // cRoomTestName
            // 
            this.cRoomTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cRoomTestName.DataPropertyName = "RoomTestName";
            this.cRoomTestName.HeaderText = "Tên phòng thi";
            this.cRoomTestName.Name = "cRoomTestName";
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemMenuCheckinRoom,
            this.toolStripSeparator1});
            this.metroContextMenu2.Name = "metroContextMenu1";
            this.metroContextMenu2.Size = new System.Drawing.Size(174, 32);
            // 
            // mItemMenuCheckinRoom
            // 
            this.mItemMenuCheckinRoom.Name = "mItemMenuCheckinRoom";
            this.mItemMenuCheckinRoom.Size = new System.Drawing.Size(173, 22);
            this.mItemMenuCheckinRoom.Text = "&Kiểm tra phòng thi";
            this.mItemMenuCheckinRoom.Click += new System.EventHandler(this.mItemMenuCheckinRoom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // frmCheckComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 406);
            this.Controls.Add(this.panel1);
            this.Name = "frmCheckComputer";
            this.Text = "Danh sách các phòng thi";
            this.Load += new System.EventHandler(this.frmCheckComputer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).EndInit();
            this.metroContextMenu2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRoomTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRoomTestName;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuCheckinRoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}