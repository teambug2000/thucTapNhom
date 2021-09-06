namespace ContestManagementVer2.Main
{
    partial class FrmKhoiThi_2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountSub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.btn_XoaKhoiThi = new MetroFramework.Controls.MetroButton();
            this.btn_SuaKhoiThi = new MetroFramework.Controls.MetroButton();
            this.txt_TenKhoiThi = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btn_ThemKhoiThi = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.btn_XoaMonThi = new MetroFramework.Controls.MetroButton();
            this.cbx_SubjectName = new MetroFramework.Controls.MetroComboBox();
            this.btn_ThemMonThi = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblNameContest = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
            this.metroPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.splitContainer1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(963, 451);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.metroPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.metroPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(963, 451);
            this.splitContainer1.SplitterDistance = 476;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGroup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 351);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách khối thi";
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.CountSub});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroup.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroup.Location = new System.Drawing.Point(3, 16);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.Size = new System.Drawing.Size(470, 332);
            this.dgvGroup.TabIndex = 0;
            this.dgvGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellClick);
            // 
            // GroupName
            // 
            this.GroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Tên khối thi";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // CountSub
            // 
            this.CountSub.DataPropertyName = "CountSub";
            this.CountSub.HeaderText = "Số lượng môn thi";
            this.CountSub.Name = "CountSub";
            this.CountSub.ReadOnly = true;
            this.CountSub.Width = 150;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.btn_XoaKhoiThi);
            this.metroPanel2.Controls.Add(this.btn_SuaKhoiThi);
            this.metroPanel2.Controls.Add(this.txt_TenKhoiThi);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.btn_ThemKhoiThi);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 351);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(476, 100);
            this.metroPanel2.TabIndex = 0;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // btn_XoaKhoiThi
            // 
            this.btn_XoaKhoiThi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_XoaKhoiThi.Location = new System.Drawing.Point(353, 59);
            this.btn_XoaKhoiThi.Name = "btn_XoaKhoiThi";
            this.btn_XoaKhoiThi.Size = new System.Drawing.Size(109, 23);
            this.btn_XoaKhoiThi.TabIndex = 6;
            this.btn_XoaKhoiThi.Text = "Xóa Khối thi";
            this.btn_XoaKhoiThi.UseSelectable = true;
            this.btn_XoaKhoiThi.Click += new System.EventHandler(this.btn_XoaKhoiThi_Click);
            // 
            // btn_SuaKhoiThi
            // 
            this.btn_SuaKhoiThi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_SuaKhoiThi.Location = new System.Drawing.Point(186, 59);
            this.btn_SuaKhoiThi.Name = "btn_SuaKhoiThi";
            this.btn_SuaKhoiThi.Size = new System.Drawing.Size(109, 23);
            this.btn_SuaKhoiThi.TabIndex = 5;
            this.btn_SuaKhoiThi.Text = "Sửa tên Khối thi";
            this.btn_SuaKhoiThi.UseSelectable = true;
            this.btn_SuaKhoiThi.Click += new System.EventHandler(this.btn_SuaKhoiThi_Click);
            // 
            // txt_TenKhoiThi
            // 
            this.txt_TenKhoiThi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txt_TenKhoiThi.CustomButton.Image = null;
            this.txt_TenKhoiThi.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txt_TenKhoiThi.CustomButton.Name = "";
            this.txt_TenKhoiThi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_TenKhoiThi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_TenKhoiThi.CustomButton.TabIndex = 1;
            this.txt_TenKhoiThi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_TenKhoiThi.CustomButton.UseSelectable = true;
            this.txt_TenKhoiThi.CustomButton.Visible = false;
            this.txt_TenKhoiThi.Lines = new string[0];
            this.txt_TenKhoiThi.Location = new System.Drawing.Point(155, 12);
            this.txt_TenKhoiThi.MaxLength = 32767;
            this.txt_TenKhoiThi.Name = "txt_TenKhoiThi";
            this.txt_TenKhoiThi.PasswordChar = '\0';
            this.txt_TenKhoiThi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_TenKhoiThi.SelectedText = "";
            this.txt_TenKhoiThi.SelectionLength = 0;
            this.txt_TenKhoiThi.SelectionStart = 0;
            this.txt_TenKhoiThi.ShortcutsEnabled = true;
            this.txt_TenKhoiThi.Size = new System.Drawing.Size(276, 23);
            this.txt_TenKhoiThi.TabIndex = 4;
            this.txt_TenKhoiThi.UseSelectable = true;
            this.txt_TenKhoiThi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_TenKhoiThi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(41, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Tên khối thi:";
            // 
            // btn_ThemKhoiThi
            // 
            this.btn_ThemKhoiThi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ThemKhoiThi.Location = new System.Drawing.Point(19, 59);
            this.btn_ThemKhoiThi.Name = "btn_ThemKhoiThi";
            this.btn_ThemKhoiThi.Size = new System.Drawing.Size(109, 23);
            this.btn_ThemKhoiThi.TabIndex = 2;
            this.btn_ThemKhoiThi.Text = "Thêm Khối thi";
            this.btn_ThemKhoiThi.UseSelectable = true;
            this.btn_ThemKhoiThi.Click += new System.EventHandler(this.btn_ThemKhoiThi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSubject);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 351);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách môn thi";
            // 
            // dgvSubject
            // 
            this.dgvSubject.AllowUserToAddRows = false;
            this.dgvSubject.AllowUserToDeleteRows = false;
            this.dgvSubject.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.SubjectTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubject.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubject.Location = new System.Drawing.Point(3, 16);
            this.dgvSubject.Name = "dgvSubject";
            this.dgvSubject.ReadOnly = true;
            this.dgvSubject.Size = new System.Drawing.Size(477, 332);
            this.dgvSubject.TabIndex = 0;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "Tên môn thi";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // SubjectTime
            // 
            this.SubjectTime.DataPropertyName = "SubjectTime";
            this.SubjectTime.HeaderText = "Thời gian (phút)";
            this.SubjectTime.Name = "SubjectTime";
            this.SubjectTime.ReadOnly = true;
            this.SubjectTime.Width = 150;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.btn_XoaMonThi);
            this.metroPanel4.Controls.Add(this.cbx_SubjectName);
            this.metroPanel4.Controls.Add(this.btn_ThemMonThi);
            this.metroPanel4.Controls.Add(this.metroLabel2);
            this.metroPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(0, 351);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(483, 100);
            this.metroPanel4.TabIndex = 0;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // btn_XoaMonThi
            // 
            this.btn_XoaMonThi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_XoaMonThi.Location = new System.Drawing.Point(274, 59);
            this.btn_XoaMonThi.Name = "btn_XoaMonThi";
            this.btn_XoaMonThi.Size = new System.Drawing.Size(109, 23);
            this.btn_XoaMonThi.TabIndex = 9;
            this.btn_XoaMonThi.Text = "Xóa Môn thi";
            this.btn_XoaMonThi.UseSelectable = true;
            this.btn_XoaMonThi.Click += new System.EventHandler(this.btn_XoaMonThi_Click);
            // 
            // cbx_SubjectName
            // 
            this.cbx_SubjectName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbx_SubjectName.FormattingEnabled = true;
            this.cbx_SubjectName.ItemHeight = 23;
            this.cbx_SubjectName.Location = new System.Drawing.Point(139, 12);
            this.cbx_SubjectName.Name = "cbx_SubjectName";
            this.cbx_SubjectName.Size = new System.Drawing.Size(244, 29);
            this.cbx_SubjectName.TabIndex = 8;
            this.cbx_SubjectName.UseSelectable = true;
            // 
            // btn_ThemMonThi
            // 
            this.btn_ThemMonThi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ThemMonThi.Location = new System.Drawing.Point(90, 59);
            this.btn_ThemMonThi.Name = "btn_ThemMonThi";
            this.btn_ThemMonThi.Size = new System.Drawing.Size(109, 23);
            this.btn_ThemMonThi.TabIndex = 7;
            this.btn_ThemMonThi.Text = "Thêm Môn thi";
            this.btn_ThemMonThi.UseSelectable = true;
            this.btn_ThemMonThi.Click += new System.EventHandler(this.btn_ThemMonThi_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(22, 15);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(85, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Tên môn thi:";
            // 
            // lblNameContest
            // 
            this.lblNameContest.AutoSize = true;
            this.lblNameContest.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNameContest.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNameContest.Location = new System.Drawing.Point(206, 23);
            this.lblNameContest.Name = "lblNameContest";
            this.lblNameContest.Size = new System.Drawing.Size(71, 25);
            this.lblNameContest.TabIndex = 1;
            this.lblNameContest.Text = "Kỳ thi: ";
            // 
            // FrmKhoiThi_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 531);
            this.Controls.Add(this.lblNameContest);
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmKhoiThi_2";
            this.Text = "Khối Thi";
            this.Load += new System.EventHandler(this.FrmKhoiThi_2_Load);
            this.metroPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).EndInit();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSubject;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroButton btn_XoaKhoiThi;
        private MetroFramework.Controls.MetroButton btn_SuaKhoiThi;
        private MetroFramework.Controls.MetroTextBox txt_TenKhoiThi;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btn_ThemKhoiThi;
        private MetroFramework.Controls.MetroButton btn_XoaMonThi;
        private MetroFramework.Controls.MetroComboBox cbx_SubjectName;
        private MetroFramework.Controls.MetroButton btn_ThemMonThi;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblNameContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectTime;
    }
}