namespace ContestManagementVer2.Main
{
    partial class FrmConfigDiaDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigDiaDiem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.txtSoLuongThiSinh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDiaDiemThi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new MetroFramework.Controls.MetroButton();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.btnHuy = new MetroFramework.Controls.MetroButton();
            this.btnXepLich = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdUuTienThiSinh = new System.Windows.Forms.RadioButton();
            this.rdUuTienMonThi = new System.Windows.Forms.RadioButton();
            this.groupDiaDiem_Tinh = new System.Windows.Forms.GroupBox();
            this.dgvDiaDiem_Tinh = new System.Windows.Forms.DataGridView();
            this.groupTinhThanh = new System.Windows.Forms.GroupBox();
            this.dgvDsTinhThanh = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongSoCho = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupDiaDiem_Tinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaDiem_Tinh)).BeginInit();
            this.groupTinhThanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsTinhThanh)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.txtTongSoCho);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.txtSoLuongThiSinh);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.cbxDiaDiemThi);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnRemove);
            this.panelMain.Controls.Add(this.btnSelect);
            this.panelMain.Controls.Add(this.btnHuy);
            this.panelMain.Controls.Add(this.btnXepLich);
            this.panelMain.Controls.Add(this.groupBox3);
            this.panelMain.Controls.Add(this.groupDiaDiem_Tinh);
            this.panelMain.Controls.Add(this.groupTinhThanh);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(20, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1260, 675);
            this.panelMain.TabIndex = 0;
            // 
            // txtSoLuongThiSinh
            // 
            this.txtSoLuongThiSinh.AutoSize = true;
            this.txtSoLuongThiSinh.Location = new System.Drawing.Point(822, 562);
            this.txtSoLuongThiSinh.Name = "txtSoLuongThiSinh";
            this.txtSoLuongThiSinh.Size = new System.Drawing.Size(15, 17);
            this.txtSoLuongThiSinh.TabIndex = 27;
            this.txtSoLuongThiSinh.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tổng số lượng thí sinh: ";
            // 
            // cbxDiaDiemThi
            // 
            this.cbxDiaDiemThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDiaDiemThi.FormattingEnabled = true;
            this.cbxDiaDiemThi.Items.AddRange(new object[] {
            "Ca thi chính thức",
            "Ca thi dự phòng"});
            this.cbxDiaDiemThi.Location = new System.Drawing.Point(758, 25);
            this.cbxDiaDiemThi.Name = "cbxDiaDiemThi";
            this.cbxDiaDiemThi.Size = new System.Drawing.Size(358, 25);
            this.cbxDiaDiemThi.TabIndex = 25;
            this.cbxDiaDiemThi.SelectedIndexChanged += new System.EventHandler(this.cbxDiaDiemThi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Địa điểm thi:";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemove.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnRemove.ForeColor = System.Drawing.Color.Green;
            this.btnRemove.Location = new System.Drawing.Point(584, 283);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(69, 51);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnRemove.UseCustomBackColor = true;
            this.btnRemove.UseCustomForeColor = true;
            this.btnRemove.UseSelectable = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.White;
            this.btnSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.BackgroundImage")));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelect.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSelect.ForeColor = System.Drawing.Color.Green;
            this.btnSelect.Location = new System.Drawing.Point(584, 202);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(69, 51);
            this.btnSelect.TabIndex = 22;
            this.btnSelect.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSelect.UseCustomBackColor = true;
            this.btnSelect.UseCustomForeColor = true;
            this.btnSelect.UseSelectable = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHuy.Location = new System.Drawing.Point(1101, 625);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(135, 36);
            this.btnHuy.TabIndex = 21;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnHuy.UseCustomBackColor = true;
            this.btnHuy.UseCustomForeColor = true;
            this.btnHuy.UseSelectable = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXepLich
            // 
            this.btnXepLich.BackColor = System.Drawing.Color.White;
            this.btnXepLich.Enabled = false;
            this.btnXepLich.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXepLich.ForeColor = System.Drawing.Color.Green;
            this.btnXepLich.Location = new System.Drawing.Point(960, 625);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(135, 36);
            this.btnXepLich.TabIndex = 20;
            this.btnXepLich.Text = "Xếp lịch";
            this.btnXepLich.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXepLich.UseCustomBackColor = true;
            this.btnXepLich.UseCustomForeColor = true;
            this.btnXepLich.UseSelectable = true;
            this.btnXepLich.Click += new System.EventHandler(this.btnXepLich_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdUuTienThiSinh);
            this.groupBox3.Controls.Add(this.rdUuTienMonThi);
            this.groupBox3.Location = new System.Drawing.Point(19, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(545, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ưu tiên Xếp lịch";
            // 
            // rdUuTienThiSinh
            // 
            this.rdUuTienThiSinh.AutoSize = true;
            this.rdUuTienThiSinh.Location = new System.Drawing.Point(284, 23);
            this.rdUuTienThiSinh.Name = "rdUuTienThiSinh";
            this.rdUuTienThiSinh.Size = new System.Drawing.Size(115, 21);
            this.rdUuTienThiSinh.TabIndex = 1;
            this.rdUuTienThiSinh.Text = "Ưu tiên thí sinh";
            this.rdUuTienThiSinh.UseVisualStyleBackColor = true;
            this.rdUuTienThiSinh.CheckedChanged += new System.EventHandler(this.rdUuTienThiSinh_CheckedChanged);
            // 
            // rdUuTienMonThi
            // 
            this.rdUuTienMonThi.AutoSize = true;
            this.rdUuTienMonThi.Checked = true;
            this.rdUuTienMonThi.Location = new System.Drawing.Point(50, 23);
            this.rdUuTienMonThi.Name = "rdUuTienMonThi";
            this.rdUuTienMonThi.Size = new System.Drawing.Size(117, 21);
            this.rdUuTienMonThi.TabIndex = 0;
            this.rdUuTienMonThi.TabStop = true;
            this.rdUuTienMonThi.Text = "Ưu tiên môn thi";
            this.rdUuTienMonThi.UseVisualStyleBackColor = true;
            this.rdUuTienMonThi.CheckedChanged += new System.EventHandler(this.rdUuTienThiSinh_CheckedChanged);
            // 
            // groupDiaDiem_Tinh
            // 
            this.groupDiaDiem_Tinh.Controls.Add(this.dgvDiaDiem_Tinh);
            this.groupDiaDiem_Tinh.Location = new System.Drawing.Point(672, 73);
            this.groupDiaDiem_Tinh.Name = "groupDiaDiem_Tinh";
            this.groupDiaDiem_Tinh.Size = new System.Drawing.Size(564, 464);
            this.groupDiaDiem_Tinh.TabIndex = 1;
            this.groupDiaDiem_Tinh.TabStop = false;
            this.groupDiaDiem_Tinh.Text = "Danh sách tỉnh của địa điểm thi";
            // 
            // dgvDiaDiem_Tinh
            // 
            this.dgvDiaDiem_Tinh.AllowUserToResizeColumns = false;
            this.dgvDiaDiem_Tinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiaDiem_Tinh.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiaDiem_Tinh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDiaDiem_Tinh.ColumnHeadersHeight = 30;
            this.dgvDiaDiem_Tinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Ten2,
            this.dataGridViewTextBoxColumn3});
            this.dgvDiaDiem_Tinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiaDiem_Tinh.EnableHeadersVisualStyles = false;
            this.dgvDiaDiem_Tinh.GridColor = System.Drawing.Color.Black;
            this.dgvDiaDiem_Tinh.Location = new System.Drawing.Point(3, 20);
            this.dgvDiaDiem_Tinh.MultiSelect = false;
            this.dgvDiaDiem_Tinh.Name = "dgvDiaDiem_Tinh";
            this.dgvDiaDiem_Tinh.ReadOnly = true;
            this.dgvDiaDiem_Tinh.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDiaDiem_Tinh.RowHeadersWidth = 25;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDiaDiem_Tinh.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDiaDiem_Tinh.RowTemplate.Height = 30;
            this.dgvDiaDiem_Tinh.RowTemplate.ReadOnly = true;
            this.dgvDiaDiem_Tinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiaDiem_Tinh.Size = new System.Drawing.Size(558, 441);
            this.dgvDiaDiem_Tinh.TabIndex = 5;
            // 
            // groupTinhThanh
            // 
            this.groupTinhThanh.Controls.Add(this.dgvDsTinhThanh);
            this.groupTinhThanh.Location = new System.Drawing.Point(19, 73);
            this.groupTinhThanh.Name = "groupTinhThanh";
            this.groupTinhThanh.Size = new System.Drawing.Size(548, 574);
            this.groupTinhThanh.TabIndex = 0;
            this.groupTinhThanh.TabStop = false;
            this.groupTinhThanh.Text = "Danh sách tỉnh của thí sinh";
            // 
            // dgvDsTinhThanh
            // 
            this.dgvDsTinhThanh.AllowUserToResizeColumns = false;
            this.dgvDsTinhThanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDsTinhThanh.BackgroundColor = System.Drawing.Color.White;
            this.dgvDsTinhThanh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDsTinhThanh.ColumnHeadersHeight = 30;
            this.dgvDsTinhThanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Ten,
            this.SoLuong});
            this.dgvDsTinhThanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDsTinhThanh.EnableHeadersVisualStyles = false;
            this.dgvDsTinhThanh.GridColor = System.Drawing.Color.Black;
            this.dgvDsTinhThanh.Location = new System.Drawing.Point(3, 20);
            this.dgvDsTinhThanh.MultiSelect = false;
            this.dgvDsTinhThanh.Name = "dgvDsTinhThanh";
            this.dgvDsTinhThanh.ReadOnly = true;
            this.dgvDsTinhThanh.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDsTinhThanh.RowHeadersWidth = 25;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDsTinhThanh.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDsTinhThanh.RowTemplate.Height = 30;
            this.dgvDsTinhThanh.RowTemplate.ReadOnly = true;
            this.dgvDsTinhThanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDsTinhThanh.Size = new System.Drawing.Size(542, 551);
            this.dgvDsTinhThanh.TabIndex = 4;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 15F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // Ten
            // 
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Tên tỉnh";
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.FillWeight = 30F;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STT";
            this.dataGridViewTextBoxColumn1.FillWeight = 15F;
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Ten2
            // 
            this.Ten2.DataPropertyName = "Ten";
            this.Ten2.HeaderText = "Tên tỉnh";
            this.Ten2.Name = "Ten2";
            this.Ten2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn3.FillWeight = 30F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 590);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tổng số chỗ: ";
            // 
            // txtTongSoCho
            // 
            this.txtTongSoCho.AutoSize = true;
            this.txtTongSoCho.Location = new System.Drawing.Point(765, 590);
            this.txtTongSoCho.Name = "txtTongSoCho";
            this.txtTongSoCho.Size = new System.Drawing.Size(15, 17);
            this.txtTongSoCho.TabIndex = 29;
            this.txtTongSoCho.Text = "0";
            // 
            // FrmConfigDiaDiem
            // 
            this.ClientSize = new System.Drawing.Size(1300, 755);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.Name = "FrmConfigDiaDiem";
            this.Resizable = false;
            this.Text = "CẤU HÌNH XẾP LỊCH";
            this.Load += new System.EventHandler(this.FrmConfigDiaDiem_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupDiaDiem_Tinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaDiem_Tinh)).EndInit();
            this.groupTinhThanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsTinhThanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupTinhThanh;
        private System.Windows.Forms.GroupBox groupDiaDiem_Tinh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdUuTienThiSinh;
        private System.Windows.Forms.RadioButton rdUuTienMonThi;
        private MetroFramework.Controls.MetroButton btnHuy;
        private MetroFramework.Controls.MetroButton btnXepLich;
        private MetroFramework.Controls.MetroButton btnRemove;
        private MetroFramework.Controls.MetroButton btnSelect;
        private System.Windows.Forms.DataGridView dgvDsTinhThanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDiaDiemThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtSoLuongThiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridView dgvDiaDiem_Tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label txtTongSoCho;
        private System.Windows.Forms.Label label3;
    }
}