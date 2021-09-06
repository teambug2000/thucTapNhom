namespace EXON.RegisterManager.Module.Forms
{
    partial class frmImport
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
            this.lb = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.pgbLoading = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnXepLich = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvContestant = new System.Windows.Forms.DataGridView();
            this.clmSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKhoiThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoomtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShiftDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContestant)).BeginInit();
            this.SuspendLayout();
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(1210, 52);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(0, 13);
            this.lb.TabIndex = 4;
            // 
            // lb1
            // 
            this.lb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(1195, 94);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(15, 13);
            this.lb1.TabIndex = 6;
            this.lb1.Text = "%";
            this.lb1.Visible = false;
            // 
            // pgbLoading
            // 
            this.pgbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbLoading.Location = new System.Drawing.Point(39, 84);
            this.pgbLoading.Name = "pgbLoading";
            this.pgbLoading.Size = new System.Drawing.Size(1131, 23);
            this.pgbLoading.TabIndex = 5;
            this.pgbLoading.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetFile);
            this.panel1.Controls.Add(this.btnXepLich);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.lb1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pgbLoading);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 116);
            this.panel1.TabIndex = 0;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(531, 42);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 0;
            this.btnGetFile.Text = "Chọn file";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // btnXepLich
            // 
            this.btnXepLich.Enabled = false;
            this.btnXepLich.Location = new System.Drawing.Point(1037, 34);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(145, 35);
            this.btnXepLich.TabIndex = 8;
            this.btnXepLich.Text = "Xếp Lịch";
            this.btnXepLich.UseVisualStyleBackColor = true;
            this.btnXepLich.Click += new System.EventHandler(this.btnXepLich_Click_1);
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(846, 34);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(145, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập thông tin thí sinh";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Danh sách thí sinh";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(474, 20);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvContestant);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1234, 462);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thí sinh";
            // 
            // dgvContestant
            // 
            this.dgvContestant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContestant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSTT,
            this.clmSBD,
            this.clmHoTen,
            this.clmDOB,
            this.clmSex,
            this.clmCMND,
            this.clmDiaChi,
            this.clmKhoiThi,
            this.clmRoomtest,
            this.clmShiftDate,
            this.clmShift});
            this.dgvContestant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContestant.Location = new System.Drawing.Point(3, 16);
            this.dgvContestant.Name = "dgvContestant";
            this.dgvContestant.Size = new System.Drawing.Size(1228, 443);
            this.dgvContestant.TabIndex = 4;
            // 
            // clmSTT
            // 
            this.clmSTT.DataPropertyName = "STT";
            this.clmSTT.HeaderText = "STT";
            this.clmSTT.Name = "clmSTT";
            this.clmSTT.Width = 50;
            // 
            // clmSBD
            // 
            this.clmSBD.DataPropertyName = "ContestantCode";
            this.clmSBD.HeaderText = "SBD";
            this.clmSBD.Name = "clmSBD";
            this.clmSBD.Width = 120;
            // 
            // clmHoTen
            // 
            this.clmHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmHoTen.DataPropertyName = "FullName";
            this.clmHoTen.HeaderText = "Họ Tên";
            this.clmHoTen.Name = "clmHoTen";
            // 
            // clmDOB
            // 
            this.clmDOB.DataPropertyName = "DOB";
            this.clmDOB.HeaderText = "Ngày sinh";
            this.clmDOB.Name = "clmDOB";
            this.clmDOB.Width = 120;
            // 
            // clmSex
            // 
            this.clmSex.DataPropertyName = "Sex";
            this.clmSex.HeaderText = "Giới tính";
            this.clmSex.Name = "clmSex";
            this.clmSex.Visible = false;
            this.clmSex.Width = 80;
            // 
            // clmCMND
            // 
            this.clmCMND.DataPropertyName = "IDCardNumber";
            this.clmCMND.HeaderText = "Số CMND";
            this.clmCMND.Name = "clmCMND";
            this.clmCMND.Width = 150;
            // 
            // clmDiaChi
            // 
            this.clmDiaChi.DataPropertyName = "CurrentAddress";
            this.clmDiaChi.HeaderText = "Địa chỉ hiện tại";
            this.clmDiaChi.Name = "clmDiaChi";
            this.clmDiaChi.Visible = false;
            this.clmDiaChi.Width = 150;
            // 
            // clmKhoiThi
            // 
            this.clmKhoiThi.DataPropertyName = "KhoiThi";
            this.clmKhoiThi.HeaderText = "Khối thi";
            this.clmKhoiThi.Name = "clmKhoiThi";
            // 
            // clmRoomtest
            // 
            this.clmRoomtest.DataPropertyName = "Roomtest";
            this.clmRoomtest.HeaderText = "Phòng thi";
            this.clmRoomtest.Name = "clmRoomtest";
            // 
            // clmShiftDate
            // 
            this.clmShiftDate.DataPropertyName = "ExamDate";
            this.clmShiftDate.HeaderText = "Ngày thi";
            this.clmShiftDate.Name = "clmShiftDate";
            this.clmShiftDate.Width = 150;
            // 
            // clmShift
            // 
            this.clmShift.DataPropertyName = "Shift";
            this.clmShift.HeaderText = "Kíp thi";
            this.clmShift.Name = "clmShift";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 658);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmImport";
            this.Text = "Import thí sinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContestant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pgbLoading;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnXepLich;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvContestant;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKhoiThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoomtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShiftDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShift;
    }
}