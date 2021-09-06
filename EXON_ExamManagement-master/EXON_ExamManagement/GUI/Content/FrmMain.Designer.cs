namespace EXON_ExamManagement
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelMain = new MetroFramework.Controls.MetroPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvContest = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKiThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mbtnChamThi = new MetroFramework.Controls.MetroButton();
            this.mbtnChuyenDuLieuVe = new MetroFramework.Controls.MetroButton();
            this.lbGiamSatTo = new System.Windows.Forms.Label();
            this.mbtnExit = new MetroFramework.Controls.MetroButton();
            this.lbGiamSatFrom = new System.Windows.Forms.Label();
            this.mbtnCauHinhHeThong = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnDanhSachKeHoach = new MetroFramework.Controls.MetroButton();
            this.btnLapKeHoachThi = new MetroFramework.Controls.MetroButton();
            this.btnToChucThi = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChuanBiThi = new System.Windows.Forms.Button();
            this.btnSinhDeThi = new System.Windows.Forms.Button();
            this.btnXepLich = new System.Windows.Forms.Button();
            this.btnDangKiThi = new System.Windows.Forms.Button();
            this.btnLapKeHoach = new System.Windows.Forms.Button();
            this.lbChuanBiThiTo = new System.Windows.Forms.Label();
            this.lbChuanBiThiFrom = new System.Windows.Forms.Label();
            this.lbSinhDeThiTo = new System.Windows.Forms.Label();
            this.lbSinhDeThiFrom = new System.Windows.Forms.Label();
            this.lbXepLichThiTo = new System.Windows.Forms.Label();
            this.lbXepLichThiFrom = new System.Windows.Forms.Label();
            this.lbSinhDeGocTo = new System.Windows.Forms.Label();
            this.lbSinhDeGocFrom = new System.Windows.Forms.Label();
            this.lbRegisterTo = new System.Windows.Forms.Label();
            this.lbRegisterFrom = new System.Windows.Forms.Label();
            this.btnSinhDeThiGoc = new MetroFramework.Controls.MetroButton();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerUpdateSTTContest = new System.Windows.Forms.Timer(this.components);
            this.btn_XoaKyThi = new MetroFramework.Controls.MetroButton();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContest)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.HorizontalScrollbarBarColor = true;
            this.panelMain.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMain.HorizontalScrollbarSize = 12;
            this.panelMain.Location = new System.Drawing.Point(23, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1332, 678);
            this.panelMain.TabIndex = 0;
            this.panelMain.VerticalScrollbarBarColor = true;
            this.panelMain.VerticalScrollbarHighlightOnWheel = false;
            this.panelMain.VerticalScrollbarSize = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panelStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1330, 676);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvContest);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1330, 429);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các kì thi";
            // 
            // dgvContest
            // 
            this.dgvContest.AllowUserToResizeColumns = false;
            this.dgvContest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContest.BackgroundColor = System.Drawing.Color.White;
            this.dgvContest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContest.ColumnHeadersHeight = 30;
            this.dgvContest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Status,
            this.STT,
            this.TenKiThi,
            this.TrangThai});
            this.dgvContest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContest.EnableHeadersVisualStyles = false;
            this.dgvContest.GridColor = System.Drawing.Color.Black;
            this.dgvContest.Location = new System.Drawing.Point(3, 19);
            this.dgvContest.MultiSelect = false;
            this.dgvContest.Name = "dgvContest";
            this.dgvContest.ReadOnly = true;
            this.dgvContest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContest.RowHeadersWidth = 25;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContest.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContest.RowTemplate.Height = 30;
            this.dgvContest.RowTemplate.ReadOnly = true;
            this.dgvContest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContest.Size = new System.Drawing.Size(1057, 407);
            this.dgvContest.TabIndex = 7;
            this.dgvContest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContest_CellClick);
            this.dgvContest.SelectionChanged += new System.EventHandler(this.dgvContest_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 30F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenKiThi
            // 
            this.TenKiThi.DataPropertyName = "TenKiThi";
            this.TenKiThi.HeaderText = "Tên kì thi";
            this.TenKiThi.Name = "TenKiThi";
            this.TenKiThi.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái kì thi";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_XoaKyThi);
            this.panel3.Controls.Add(this.mbtnChamThi);
            this.panel3.Controls.Add(this.mbtnChuyenDuLieuVe);
            this.panel3.Controls.Add(this.lbGiamSatTo);
            this.panel3.Controls.Add(this.mbtnExit);
            this.panel3.Controls.Add(this.lbGiamSatFrom);
            this.panel3.Controls.Add(this.mbtnCauHinhHeThong);
            this.panel3.Controls.Add(this.metroButton1);
            this.panel3.Controls.Add(this.btnDanhSachKeHoach);
            this.panel3.Controls.Add(this.btnLapKeHoachThi);
            this.panel3.Controls.Add(this.btnToChucThi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1060, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 407);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // mbtnChamThi
            // 
            this.mbtnChamThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.chamthi;
            this.mbtnChamThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbtnChamThi.ForeColor = System.Drawing.Color.Black;
            this.mbtnChamThi.Location = new System.Drawing.Point(161, 291);
            this.mbtnChamThi.Name = "mbtnChamThi";
            this.mbtnChamThi.Size = new System.Drawing.Size(157, 62);
            this.mbtnChamThi.TabIndex = 64;
            this.mbtnChamThi.UseSelectable = true;
            this.mbtnChamThi.Visible = false;
            this.mbtnChamThi.Click += new System.EventHandler(this.mbtnChamThi_Click);
            // 
            // mbtnChuyenDuLieuVe
            // 
            this.mbtnChuyenDuLieuVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mbtnChuyenDuLieuVe.DisplayFocus = true;
            this.mbtnChuyenDuLieuVe.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnChuyenDuLieuVe.ForeColor = System.Drawing.Color.Black;
            this.mbtnChuyenDuLieuVe.Location = new System.Drawing.Point(3, 291);
            this.mbtnChuyenDuLieuVe.Name = "mbtnChuyenDuLieuVe";
            this.mbtnChuyenDuLieuVe.Size = new System.Drawing.Size(255, 42);
            this.mbtnChuyenDuLieuVe.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnChuyenDuLieuVe.TabIndex = 4;
            this.mbtnChuyenDuLieuVe.Text = "     Chuyển dữ liệu thi về";
            this.mbtnChuyenDuLieuVe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnChuyenDuLieuVe.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnChuyenDuLieuVe.UseCustomBackColor = true;
            this.mbtnChuyenDuLieuVe.UseCustomForeColor = true;
            this.mbtnChuyenDuLieuVe.UseSelectable = true;
            this.mbtnChuyenDuLieuVe.UseStyleColors = true;
            this.mbtnChuyenDuLieuVe.Visible = false;
            this.mbtnChuyenDuLieuVe.Click += new System.EventHandler(this.mbtnChuyenDuLieuVe_Click);
            // 
            // lbGiamSatTo
            // 
            this.lbGiamSatTo.AutoSize = true;
            this.lbGiamSatTo.Location = new System.Drawing.Point(-5, 374);
            this.lbGiamSatTo.Name = "lbGiamSatTo";
            this.lbGiamSatTo.Size = new System.Drawing.Size(38, 16);
            this.lbGiamSatTo.TabIndex = 63;
            this.lbGiamSatTo.Text = "Đến: ";
            this.lbGiamSatTo.Visible = false;
            // 
            // mbtnExit
            // 
            this.mbtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mbtnExit.DisplayFocus = true;
            this.mbtnExit.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnExit.ForeColor = System.Drawing.Color.Black;
            this.mbtnExit.Location = new System.Drawing.Point(3, 195);
            this.mbtnExit.Name = "mbtnExit";
            this.mbtnExit.Size = new System.Drawing.Size(255, 42);
            this.mbtnExit.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnExit.TabIndex = 3;
            this.mbtnExit.Text = "     Thoát";
            this.mbtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnExit.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnExit.UseCustomBackColor = true;
            this.mbtnExit.UseCustomForeColor = true;
            this.mbtnExit.UseSelectable = true;
            this.mbtnExit.UseStyleColors = true;
            this.mbtnExit.Click += new System.EventHandler(this.mbtnExit_Click);
            // 
            // lbGiamSatFrom
            // 
            this.lbGiamSatFrom.AutoSize = true;
            this.lbGiamSatFrom.Location = new System.Drawing.Point(-5, 356);
            this.lbGiamSatFrom.Name = "lbGiamSatFrom";
            this.lbGiamSatFrom.Size = new System.Drawing.Size(36, 16);
            this.lbGiamSatFrom.TabIndex = 63;
            this.lbGiamSatFrom.Text = "Từ : ";
            this.lbGiamSatFrom.Visible = false;
            // 
            // mbtnCauHinhHeThong
            // 
            this.mbtnCauHinhHeThong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mbtnCauHinhHeThong.DisplayFocus = true;
            this.mbtnCauHinhHeThong.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnCauHinhHeThong.ForeColor = System.Drawing.Color.Black;
            this.mbtnCauHinhHeThong.Location = new System.Drawing.Point(3, 147);
            this.mbtnCauHinhHeThong.Name = "mbtnCauHinhHeThong";
            this.mbtnCauHinhHeThong.Size = new System.Drawing.Size(255, 42);
            this.mbtnCauHinhHeThong.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnCauHinhHeThong.TabIndex = 3;
            this.mbtnCauHinhHeThong.Text = "     Cấu hình hệ thống";
            this.mbtnCauHinhHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnCauHinhHeThong.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnCauHinhHeThong.UseCustomBackColor = true;
            this.mbtnCauHinhHeThong.UseCustomForeColor = true;
            this.mbtnCauHinhHeThong.UseSelectable = true;
            this.mbtnCauHinhHeThong.UseStyleColors = true;
            this.mbtnCauHinhHeThong.Click += new System.EventHandler(this.mbtnCauHinhHeThong_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Location = new System.Drawing.Point(3, 339);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(255, 42);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "     In danh sách các kì thi";
            this.metroButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Visible = false;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnDanhSachKeHoach
            // 
            this.btnDanhSachKeHoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDanhSachKeHoach.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDanhSachKeHoach.ForeColor = System.Drawing.Color.Black;
            this.btnDanhSachKeHoach.Location = new System.Drawing.Point(3, 51);
            this.btnDanhSachKeHoach.Name = "btnDanhSachKeHoach";
            this.btnDanhSachKeHoach.Size = new System.Drawing.Size(255, 42);
            this.btnDanhSachKeHoach.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDanhSachKeHoach.TabIndex = 1;
            this.btnDanhSachKeHoach.Text = "     Xem lại các kì thi";
            this.btnDanhSachKeHoach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachKeHoach.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDanhSachKeHoach.UseCustomBackColor = true;
            this.btnDanhSachKeHoach.UseCustomForeColor = true;
            this.btnDanhSachKeHoach.UseSelectable = true;
            this.btnDanhSachKeHoach.UseStyleColors = true;
            this.btnDanhSachKeHoach.Click += new System.EventHandler(this.btnDanhSachKeHoach_Click_1);
            // 
            // btnLapKeHoachThi
            // 
            this.btnLapKeHoachThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLapKeHoachThi.DisplayFocus = true;
            this.btnLapKeHoachThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnLapKeHoachThi.ForeColor = System.Drawing.Color.Black;
            this.btnLapKeHoachThi.Location = new System.Drawing.Point(3, 3);
            this.btnLapKeHoachThi.Name = "btnLapKeHoachThi";
            this.btnLapKeHoachThi.Size = new System.Drawing.Size(255, 42);
            this.btnLapKeHoachThi.Style = MetroFramework.MetroColorStyle.Green;
            this.btnLapKeHoachThi.TabIndex = 0;
            this.btnLapKeHoachThi.Text = "     Lập mới kế hoạch thi";
            this.btnLapKeHoachThi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLapKeHoachThi.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLapKeHoachThi.UseCustomBackColor = true;
            this.btnLapKeHoachThi.UseCustomForeColor = true;
            this.btnLapKeHoachThi.UseSelectable = true;
            this.btnLapKeHoachThi.UseStyleColors = true;
            this.btnLapKeHoachThi.Click += new System.EventHandler(this.btnLapKeHoachThi_Click);
            // 
            // btnToChucThi
            // 
            this.btnToChucThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step7;
            this.btnToChucThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToChucThi.ForeColor = System.Drawing.Color.Black;
            this.btnToChucThi.Location = new System.Drawing.Point(-2, 291);
            this.btnToChucThi.Name = "btnToChucThi";
            this.btnToChucThi.Size = new System.Drawing.Size(157, 62);
            this.btnToChucThi.TabIndex = 61;
            this.btnToChucThi.UseSelectable = true;
            this.btnToChucThi.Visible = false;
            this.btnToChucThi.Click += new System.EventHandler(this.btnToChucThi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChuanBiThi);
            this.panel1.Controls.Add(this.btnSinhDeThi);
            this.panel1.Controls.Add(this.btnXepLich);
            this.panel1.Controls.Add(this.btnDangKiThi);
            this.panel1.Controls.Add(this.btnLapKeHoach);
            this.panel1.Controls.Add(this.lbChuanBiThiTo);
            this.panel1.Controls.Add(this.lbChuanBiThiFrom);
            this.panel1.Controls.Add(this.lbSinhDeThiTo);
            this.panel1.Controls.Add(this.lbSinhDeThiFrom);
            this.panel1.Controls.Add(this.lbXepLichThiTo);
            this.panel1.Controls.Add(this.lbXepLichThiFrom);
            this.panel1.Controls.Add(this.lbSinhDeGocTo);
            this.panel1.Controls.Add(this.lbSinhDeGocFrom);
            this.panel1.Controls.Add(this.lbRegisterTo);
            this.panel1.Controls.Add(this.lbRegisterFrom);
            this.panel1.Controls.Add(this.btnSinhDeThiGoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 130);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnChuanBiThi
            // 
            this.btnChuanBiThi.BackColor = System.Drawing.Color.White;
            this.btnChuanBiThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step61;
            this.btnChuanBiThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChuanBiThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuanBiThi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuanBiThi.ForeColor = System.Drawing.Color.White;
            this.btnChuanBiThi.Location = new System.Drawing.Point(1079, 5);
            this.btnChuanBiThi.Name = "btnChuanBiThi";
            this.btnChuanBiThi.Size = new System.Drawing.Size(193, 72);
            this.btnChuanBiThi.TabIndex = 64;
            this.btnChuanBiThi.Text = "Chuẩn bị\r\nthi";
            this.btnChuanBiThi.UseVisualStyleBackColor = false;
            this.btnChuanBiThi.Click += new System.EventHandler(this.btnChuanBiThi_Click);
            // 
            // btnSinhDeThi
            // 
            this.btnSinhDeThi.BackColor = System.Drawing.Color.White;
            this.btnSinhDeThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step51;
            this.btnSinhDeThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSinhDeThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhDeThi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhDeThi.ForeColor = System.Drawing.Color.White;
            this.btnSinhDeThi.Location = new System.Drawing.Point(817, 5);
            this.btnSinhDeThi.Name = "btnSinhDeThi";
            this.btnSinhDeThi.Size = new System.Drawing.Size(193, 72);
            this.btnSinhDeThi.TabIndex = 64;
            this.btnSinhDeThi.Text = "Sinh đề\r\nthi";
            this.btnSinhDeThi.UseVisualStyleBackColor = false;
            this.btnSinhDeThi.Click += new System.EventHandler(this.btnSinhDeThi_Click);
            // 
            // btnXepLich
            // 
            this.btnXepLich.BackColor = System.Drawing.Color.White;
            this.btnXepLich.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step31;
            this.btnXepLich.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXepLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXepLich.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXepLich.ForeColor = System.Drawing.Color.White;
            this.btnXepLich.Location = new System.Drawing.Point(555, 7);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(193, 72);
            this.btnXepLich.TabIndex = 64;
            this.btnXepLich.Text = "In lịch\r\nthi";
            this.btnXepLich.UseVisualStyleBackColor = false;
            this.btnXepLich.Click += new System.EventHandler(this.btnXepLich_Click);
            // 
            // btnDangKiThi
            // 
            this.btnDangKiThi.BackColor = System.Drawing.Color.White;
            this.btnDangKiThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step21;
            this.btnDangKiThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDangKiThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKiThi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKiThi.ForeColor = System.Drawing.Color.White;
            this.btnDangKiThi.Location = new System.Drawing.Point(293, 7);
            this.btnDangKiThi.Name = "btnDangKiThi";
            this.btnDangKiThi.Size = new System.Drawing.Size(193, 72);
            this.btnDangKiThi.TabIndex = 64;
            this.btnDangKiThi.Text = "Đăng ký\r\nthi";
            this.btnDangKiThi.UseVisualStyleBackColor = false;
            this.btnDangKiThi.Click += new System.EventHandler(this.btnDangKiThi_Click);
            // 
            // btnLapKeHoach
            // 
            this.btnLapKeHoach.BackColor = System.Drawing.Color.White;
            this.btnLapKeHoach.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step11;
            this.btnLapKeHoach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLapKeHoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapKeHoach.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapKeHoach.ForeColor = System.Drawing.Color.White;
            this.btnLapKeHoach.Location = new System.Drawing.Point(43, 7);
            this.btnLapKeHoach.Name = "btnLapKeHoach";
            this.btnLapKeHoach.Size = new System.Drawing.Size(181, 72);
            this.btnLapKeHoach.TabIndex = 64;
            this.btnLapKeHoach.Text = "Lập kế\r\nhoạch";
            this.btnLapKeHoach.UseVisualStyleBackColor = false;
            this.btnLapKeHoach.Click += new System.EventHandler(this.btnLapKeHoach_Click);
            // 
            // lbChuanBiThiTo
            // 
            this.lbChuanBiThiTo.AutoSize = true;
            this.lbChuanBiThiTo.Location = new System.Drawing.Point(1084, 100);
            this.lbChuanBiThiTo.Name = "lbChuanBiThiTo";
            this.lbChuanBiThiTo.Size = new System.Drawing.Size(38, 16);
            this.lbChuanBiThiTo.TabIndex = 63;
            this.lbChuanBiThiTo.Text = "Đến: ";
            // 
            // lbChuanBiThiFrom
            // 
            this.lbChuanBiThiFrom.AutoSize = true;
            this.lbChuanBiThiFrom.Location = new System.Drawing.Point(1084, 82);
            this.lbChuanBiThiFrom.Name = "lbChuanBiThiFrom";
            this.lbChuanBiThiFrom.Size = new System.Drawing.Size(36, 16);
            this.lbChuanBiThiFrom.TabIndex = 63;
            this.lbChuanBiThiFrom.Text = "Từ : ";
            // 
            // lbSinhDeThiTo
            // 
            this.lbSinhDeThiTo.AutoSize = true;
            this.lbSinhDeThiTo.Location = new System.Drawing.Point(815, 100);
            this.lbSinhDeThiTo.Name = "lbSinhDeThiTo";
            this.lbSinhDeThiTo.Size = new System.Drawing.Size(38, 16);
            this.lbSinhDeThiTo.TabIndex = 63;
            this.lbSinhDeThiTo.Text = "Đến: ";
            // 
            // lbSinhDeThiFrom
            // 
            this.lbSinhDeThiFrom.AutoSize = true;
            this.lbSinhDeThiFrom.Location = new System.Drawing.Point(815, 82);
            this.lbSinhDeThiFrom.Name = "lbSinhDeThiFrom";
            this.lbSinhDeThiFrom.Size = new System.Drawing.Size(36, 16);
            this.lbSinhDeThiFrom.TabIndex = 63;
            this.lbSinhDeThiFrom.Text = "Từ : ";
            // 
            // lbXepLichThiTo
            // 
            this.lbXepLichThiTo.AutoSize = true;
            this.lbXepLichThiTo.Location = new System.Drawing.Point(557, 100);
            this.lbXepLichThiTo.Name = "lbXepLichThiTo";
            this.lbXepLichThiTo.Size = new System.Drawing.Size(38, 16);
            this.lbXepLichThiTo.TabIndex = 63;
            this.lbXepLichThiTo.Text = "Đến: ";
            // 
            // lbXepLichThiFrom
            // 
            this.lbXepLichThiFrom.AutoSize = true;
            this.lbXepLichThiFrom.Location = new System.Drawing.Point(557, 82);
            this.lbXepLichThiFrom.Name = "lbXepLichThiFrom";
            this.lbXepLichThiFrom.Size = new System.Drawing.Size(36, 16);
            this.lbXepLichThiFrom.TabIndex = 63;
            this.lbXepLichThiFrom.Text = "Từ : ";
            // 
            // lbSinhDeGocTo
            // 
            this.lbSinhDeGocTo.AutoSize = true;
            this.lbSinhDeGocTo.Location = new System.Drawing.Point(474, 36);
            this.lbSinhDeGocTo.Name = "lbSinhDeGocTo";
            this.lbSinhDeGocTo.Size = new System.Drawing.Size(38, 16);
            this.lbSinhDeGocTo.TabIndex = 63;
            this.lbSinhDeGocTo.Text = "Đến: ";
            this.lbSinhDeGocTo.Visible = false;
            // 
            // lbSinhDeGocFrom
            // 
            this.lbSinhDeGocFrom.AutoSize = true;
            this.lbSinhDeGocFrom.Location = new System.Drawing.Point(474, 18);
            this.lbSinhDeGocFrom.Name = "lbSinhDeGocFrom";
            this.lbSinhDeGocFrom.Size = new System.Drawing.Size(36, 16);
            this.lbSinhDeGocFrom.TabIndex = 63;
            this.lbSinhDeGocFrom.Text = "Từ : ";
            this.lbSinhDeGocFrom.Visible = false;
            // 
            // lbRegisterTo
            // 
            this.lbRegisterTo.AutoSize = true;
            this.lbRegisterTo.Location = new System.Drawing.Point(290, 100);
            this.lbRegisterTo.Name = "lbRegisterTo";
            this.lbRegisterTo.Size = new System.Drawing.Size(38, 16);
            this.lbRegisterTo.TabIndex = 63;
            this.lbRegisterTo.Text = "Đến: ";
            // 
            // lbRegisterFrom
            // 
            this.lbRegisterFrom.AutoSize = true;
            this.lbRegisterFrom.Location = new System.Drawing.Point(290, 82);
            this.lbRegisterFrom.Name = "lbRegisterFrom";
            this.lbRegisterFrom.Size = new System.Drawing.Size(36, 16);
            this.lbRegisterFrom.TabIndex = 63;
            this.lbRegisterFrom.Text = "Từ : ";
            // 
            // btnSinhDeThiGoc
            // 
            this.btnSinhDeThiGoc.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step3;
            this.btnSinhDeThiGoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSinhDeThiGoc.Location = new System.Drawing.Point(633, -18);
            this.btnSinhDeThiGoc.Name = "btnSinhDeThiGoc";
            this.btnSinhDeThiGoc.Size = new System.Drawing.Size(158, 62);
            this.btnSinhDeThiGoc.TabIndex = 59;
            this.btnSinhDeThiGoc.UseSelectable = true;
            this.btnSinhDeThiGoc.Visible = false;
            this.btnSinhDeThiGoc.Click += new System.EventHandler(this.btnSinhDeThiGoc_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.pictureBox1);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatus.Location = new System.Drawing.Point(0, 0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1330, 117);
            this.panelStatus.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::EXON_ExamManagement.Properties.Resources.LogoHVnew3;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1330, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timerUpdateSTTContest
            // 
            this.timerUpdateSTTContest.Enabled = true;
            this.timerUpdateSTTContest.Interval = 120000;
            this.timerUpdateSTTContest.Tick += new System.EventHandler(this.timerUpdateSTTContest_Tick);
            // 
            // btn_XoaKyThi
            // 
            this.btn_XoaKyThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_XoaKyThi.DisplayFocus = true;
            this.btn_XoaKyThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btn_XoaKyThi.ForeColor = System.Drawing.Color.Black;
            this.btn_XoaKyThi.Location = new System.Drawing.Point(3, 99);
            this.btn_XoaKyThi.Name = "btn_XoaKyThi";
            this.btn_XoaKyThi.Size = new System.Drawing.Size(255, 42);
            this.btn_XoaKyThi.Style = MetroFramework.MetroColorStyle.Green;
            this.btn_XoaKyThi.TabIndex = 65;
            this.btn_XoaKyThi.Text = "     Xóa kỳ thi";
            this.btn_XoaKyThi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XoaKyThi.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_XoaKyThi.UseCustomBackColor = true;
            this.btn_XoaKyThi.UseCustomForeColor = true;
            this.btn_XoaKyThi.UseSelectable = true;
            this.btn_XoaKyThi.UseStyleColors = true;
            this.btn_XoaKyThi.Click += new System.EventHandler(this.btn_XoaKyThi_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1378, 772);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 24);
            this.Text = "HỆ THỐNG THI TRỰC TUYẾN";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContest)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnToChucThi;
        private MetroFramework.Controls.MetroButton btnSinhDeThiGoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKiThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroButton mbtnCauHinhHeThong;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnDanhSachKeHoach;
        private MetroFramework.Controls.MetroButton btnLapKeHoachThi;
        private MetroFramework.Controls.MetroButton mbtnChuyenDuLieuVe;
        private MetroFramework.Controls.MetroButton mbtnExit;
        private System.Windows.Forms.Label lbGiamSatTo;
        private System.Windows.Forms.Label lbGiamSatFrom;
        private System.Windows.Forms.Label lbChuanBiThiTo;
        private System.Windows.Forms.Label lbChuanBiThiFrom;
        private System.Windows.Forms.Label lbSinhDeThiTo;
        private System.Windows.Forms.Label lbSinhDeThiFrom;
        private System.Windows.Forms.Label lbXepLichThiTo;
        private System.Windows.Forms.Label lbXepLichThiFrom;
        private System.Windows.Forms.Label lbSinhDeGocTo;
        private System.Windows.Forms.Label lbSinhDeGocFrom;
        private System.Windows.Forms.Label lbRegisterTo;
        private System.Windows.Forms.Label lbRegisterFrom;
        private System.Windows.Forms.Timer timerUpdateSTTContest;
        private MetroFramework.Controls.MetroButton mbtnChamThi;
        private System.Windows.Forms.Button btnLapKeHoach;
        private System.Windows.Forms.Button btnDangKiThi;
        private System.Windows.Forms.Button btnXepLich;
        private System.Windows.Forms.Button btnSinhDeThi;
        private System.Windows.Forms.Button btnChuanBiThi;
        private MetroFramework.Controls.MetroButton btn_XoaKyThi;
    }
}

