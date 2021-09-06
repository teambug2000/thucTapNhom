namespace ContestManagementVer2.Main
{
    partial class FrmKhoiThi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSubinGroup = new System.Windows.Forms.DataGridView();
            this.IDSubIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThemKhoi = new System.Windows.Forms.Button();
            this.btnDeleteSub = new System.Windows.Forms.Button();
            this.lbNamecontest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoupName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSubjectContest = new System.Windows.Forms.DataGridView();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.Groupname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountSub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubinGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjectContest)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSubinGroup);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lbNamecontest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGoupName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(466, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 442);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm khối thi";
            // 
            // dgvSubinGroup
            // 
            this.dgvSubinGroup.AllowUserToAddRows = false;
            this.dgvSubinGroup.AllowUserToDeleteRows = false;
            this.dgvSubinGroup.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSubinGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubinGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDSubIn,
            this.cSubName,
            this.cTime});
            this.dgvSubinGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSubinGroup.Location = new System.Drawing.Point(3, 110);
            this.dgvSubinGroup.Name = "dgvSubinGroup";
            this.dgvSubinGroup.ReadOnly = true;
            this.dgvSubinGroup.Size = new System.Drawing.Size(384, 224);
            this.dgvSubinGroup.TabIndex = 4;
            // 
            // IDSubIn
            // 
            this.IDSubIn.HeaderText = "Column1";
            this.IDSubIn.Name = "IDSubIn";
            this.IDSubIn.ReadOnly = true;
            this.IDSubIn.Visible = false;
            // 
            // cSubName
            // 
            this.cSubName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cSubName.HeaderText = "Tên môn thi";
            this.cSubName.Name = "cSubName";
            this.cSubName.ReadOnly = true;
            // 
            // cTime
            // 
            this.cTime.HeaderText = "Thời gian";
            this.cTime.Name = "cTime";
            this.cTime.ReadOnly = true;
            this.cTime.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThemKhoi);
            this.panel1.Controls.Add(this.btnDeleteSub);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 105);
            this.panel1.TabIndex = 3;
            // 
            // btnThemKhoi
            // 
            this.btnThemKhoi.Location = new System.Drawing.Point(220, 43);
            this.btnThemKhoi.Name = "btnThemKhoi";
            this.btnThemKhoi.Size = new System.Drawing.Size(75, 23);
            this.btnThemKhoi.TabIndex = 0;
            this.btnThemKhoi.Text = "Thêm khối thi";
            this.btnThemKhoi.UseVisualStyleBackColor = true;
            this.btnThemKhoi.Click += new System.EventHandler(this.btnThemKhoi_Click);
            // 
            // btnDeleteSub
            // 
            this.btnDeleteSub.Location = new System.Drawing.Point(79, 43);
            this.btnDeleteSub.Name = "btnDeleteSub";
            this.btnDeleteSub.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSub.TabIndex = 0;
            this.btnDeleteSub.Text = "Xóa môn thi";
            this.btnDeleteSub.UseVisualStyleBackColor = true;
            this.btnDeleteSub.Click += new System.EventHandler(this.btnDeleteSub_Click);
            // 
            // lbNamecontest
            // 
            this.lbNamecontest.AutoSize = true;
            this.lbNamecontest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamecontest.Location = new System.Drawing.Point(20, 16);
            this.lbNamecontest.Name = "lbNamecontest";
            this.lbNamecontest.Size = new System.Drawing.Size(60, 18);
            this.lbNamecontest.TabIndex = 1;
            this.lbNamecontest.Text = "Kỳ thi: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên khối thi";
            // 
            // txtGoupName
            // 
            this.txtGoupName.Location = new System.Drawing.Point(94, 42);
            this.txtGoupName.Name = "txtGoupName";
            this.txtGoupName.Size = new System.Drawing.Size(152, 20);
            this.txtGoupName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 442);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSubjectContest);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 226);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Các môn thi có trong kì thi";
            // 
            // dgvSubjectContest
            // 
            this.dgvSubjectContest.AllowUserToAddRows = false;
            this.dgvSubjectContest.AllowUserToDeleteRows = false;
            this.dgvSubjectContest.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSubjectContest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjectContest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectID,
            this.STT,
            this.SubjectName,
            this.Time});
            this.dgvSubjectContest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubjectContest.Location = new System.Drawing.Point(3, 16);
            this.dgvSubjectContest.Name = "dgvSubjectContest";
            this.dgvSubjectContest.ReadOnly = true;
            this.dgvSubjectContest.Size = new System.Drawing.Size(440, 207);
            this.dgvSubjectContest.TabIndex = 1;
            this.dgvSubjectContest.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjectContest_CellDoubleClick);
            // 
            // SubjectID
            // 
            this.SubjectID.DataPropertyName = "SubjectID";
            this.SubjectID.HeaderText = "Column1";
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.ReadOnly = true;
            this.SubjectID.Visible = false;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "Tên môn thi";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Thời gian (phút)";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvGroup);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 216);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Các khối thi có trong kì thi";
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Groupname,
            this.CountSub});
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroup.Location = new System.Drawing.Point(3, 16);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.Size = new System.Drawing.Size(440, 197);
            this.dgvGroup.TabIndex = 2;
            // 
            // Groupname
            // 
            this.Groupname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Groupname.DataPropertyName = "GroupName";
            this.Groupname.HeaderText = "Tên khối thi";
            this.Groupname.Name = "Groupname";
            this.Groupname.ReadOnly = true;
            // 
            // CountSub
            // 
            this.CountSub.DataPropertyName = "CountSub";
            this.CountSub.HeaderText = "Số lượng môn";
            this.CountSub.Name = "CountSub";
            this.CountSub.ReadOnly = true;
            this.CountSub.Width = 200;
            // 
            // FrmKhoiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmKhoiThi";
            this.Text = "Khối thi";
            this.Load += new System.EventHandler(this.FrmKhoiThi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubinGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjectContest)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSubinGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThemKhoi;
        private System.Windows.Forms.Button btnDeleteSub;
        private System.Windows.Forms.Label lbNamecontest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoupName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvSubjectContest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Groupname;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSubIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSubName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTime;
    }
}