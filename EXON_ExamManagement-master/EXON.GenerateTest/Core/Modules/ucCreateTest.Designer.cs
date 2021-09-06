namespace EXON.GenerateTest.Core.Controls
{
    partial class ucCreateTest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbStaffCreate = new MetroFramework.Controls.MetroLabel();
            this.lbDateCreate = new MetroFramework.Controls.MetroLabel();
            this.lbTotalScore = new MetroFramework.Controls.MetroLabel();
            this.lbTotalQuestion = new MetroFramework.Controls.MetroLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcShift = new System.Windows.Forms.DataGridView();
            this.ShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumContestant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gcOriginalTest = new System.Windows.Forms.DataGridView();
            this.cTestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbiShowTest = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcShift)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOriginalTest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bbiShowTest);
            this.groupBox1.Controls.Add(this.lbStaffCreate);
            this.groupBox1.Controls.Add(this.lbDateCreate);
            this.groupBox1.Controls.Add(this.lbTotalScore);
            this.groupBox1.Controls.Add(this.lbTotalQuestion);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(665, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 758);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Đề";
            // 
            // lbStaffCreate
            // 
            this.lbStaffCreate.AutoSize = true;
            this.lbStaffCreate.Location = new System.Drawing.Point(6, 131);
            this.lbStaffCreate.Name = "lbStaffCreate";
            this.lbStaffCreate.Size = new System.Drawing.Size(75, 19);
            this.lbStaffCreate.TabIndex = 3;
            this.lbStaffCreate.Text = "Người Tạo:";
            // 
            // lbDateCreate
            // 
            this.lbDateCreate.AutoSize = true;
            this.lbDateCreate.Location = new System.Drawing.Point(6, 97);
            this.lbDateCreate.Name = "lbDateCreate";
            this.lbDateCreate.Size = new System.Drawing.Size(66, 19);
            this.lbDateCreate.TabIndex = 2;
            this.lbDateCreate.Text = "Ngày Tạo";
            // 
            // lbTotalScore
            // 
            this.lbTotalScore.AutoSize = true;
            this.lbTotalScore.Location = new System.Drawing.Point(6, 63);
            this.lbTotalScore.Name = "lbTotalScore";
            this.lbTotalScore.Size = new System.Drawing.Size(96, 19);
            this.lbTotalScore.TabIndex = 1;
            this.lbTotalScore.Text = "Tổng Số Điểm:";
            // 
            // lbTotalQuestion
            // 
            this.lbTotalQuestion.AutoSize = true;
            this.lbTotalQuestion.Location = new System.Drawing.Point(6, 29);
            this.lbTotalQuestion.Name = "lbTotalQuestion";
            this.lbTotalQuestion.Size = new System.Drawing.Size(92, 19);
            this.lbTotalQuestion.TabIndex = 0;
            this.lbTotalQuestion.Text = "Tổng Số Câu: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(665, 758);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcShift);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 361);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Ca Thi";
            // 
            // gcShift
            // 
            this.gcShift.AllowUserToAddRows = false;
            this.gcShift.AllowUserToDeleteRows = false;
            this.gcShift.AllowUserToOrderColumns = true;
            this.gcShift.BackgroundColor = System.Drawing.Color.White;
            this.gcShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gcShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShiftID,
            this.SubjectID,
            this.SubjectName,
            this.SubjectCode,
            this.ShiftName,
            this.ShiftDate,
            this.ScheduleID,
            this.NumContestant});
            this.gcShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShift.Location = new System.Drawing.Point(3, 16);
            this.gcShift.Name = "gcShift";
            this.gcShift.ReadOnly = true;
            this.gcShift.Size = new System.Drawing.Size(659, 342);
            this.gcShift.TabIndex = 3;
            this.gcShift.SelectionChanged += new System.EventHandler(this.gcShift_SelectionChanged);
            // 
            // ShiftID
            // 
            this.ShiftID.DataPropertyName = "ShiftID";
            this.ShiftID.HeaderText = "ShiftID";
            this.ShiftID.Name = "ShiftID";
            this.ShiftID.ReadOnly = true;
            this.ShiftID.Visible = false;
            // 
            // SubjectID
            // 
            this.SubjectID.DataPropertyName = "SubjectID";
            this.SubjectID.HeaderText = "SubjectID";
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.ReadOnly = true;
            this.SubjectID.Visible = false;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "Môn Thi (Phút)";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // SubjectCode
            // 
            this.SubjectCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectCode.DataPropertyName = "SubjectCode";
            this.SubjectCode.HeaderText = "Mã Môn";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            // 
            // ShiftName
            // 
            this.ShiftName.DataPropertyName = "ShiftName";
            this.ShiftName.HeaderText = "Ca Thi";
            this.ShiftName.Name = "ShiftName";
            this.ShiftName.ReadOnly = true;
            // 
            // ShiftDate
            // 
            this.ShiftDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShiftDate.DataPropertyName = "ShiftDate";
            this.ShiftDate.HeaderText = "Ngày Thi";
            this.ShiftDate.Name = "ShiftDate";
            this.ShiftDate.ReadOnly = true;
            // 
            // ScheduleID
            // 
            this.ScheduleID.DataPropertyName = "ScheduleID";
            this.ScheduleID.HeaderText = "ScheduleID";
            this.ScheduleID.Name = "ScheduleID";
            this.ScheduleID.ReadOnly = true;
            this.ScheduleID.Visible = false;
            // 
            // NumContestant
            // 
            this.NumContestant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumContestant.DataPropertyName = "NumContestant";
            this.NumContestant.HeaderText = "Số Thí Sinh";
            this.NumContestant.Name = "NumContestant";
            this.NumContestant.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gcOriginalTest);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(665, 393);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Đề Thi";
            // 
            // gcOriginalTest
            // 
            this.gcOriginalTest.AllowUserToAddRows = false;
            this.gcOriginalTest.AllowUserToDeleteRows = false;
            this.gcOriginalTest.AllowUserToOrderColumns = true;
            this.gcOriginalTest.BackgroundColor = System.Drawing.Color.White;
            this.gcOriginalTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gcOriginalTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcOriginalTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTestID,
            this.TestName,
            this.TestDate});
            this.gcOriginalTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOriginalTest.Location = new System.Drawing.Point(3, 16);
            this.gcOriginalTest.Name = "gcOriginalTest";
            this.gcOriginalTest.ReadOnly = true;
            this.gcOriginalTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gcOriginalTest.Size = new System.Drawing.Size(659, 374);
            this.gcOriginalTest.TabIndex = 8;
            this.gcOriginalTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gcOriginalTest_CellClick);
            this.gcOriginalTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gcOriginalTest_CellContentClick);
            // 
            // cTestID
            // 
            this.cTestID.DataPropertyName = "TestID";
            this.cTestID.HeaderText = "ID";
            this.cTestID.Name = "cTestID";
            this.cTestID.ReadOnly = true;
            this.cTestID.Visible = false;
            // 
            // TestName
            // 
            this.TestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TestName.DataPropertyName = "TestName";
            this.TestName.HeaderText = "Tên Đề Thi";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            // 
            // TestDate
            // 
            this.TestDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TestDate.DataPropertyName = "TestDate";
            this.TestDate.HeaderText = "Ngày Tạo";
            this.TestDate.Name = "TestDate";
            this.TestDate.ReadOnly = true;
            // 
            // bbiShowTest
            // 
            this.bbiShowTest.Location = new System.Drawing.Point(84, 166);
            this.bbiShowTest.Name = "bbiShowTest";
            this.bbiShowTest.Size = new System.Drawing.Size(75, 23);
            this.bbiShowTest.TabIndex = 4;
            this.bbiShowTest.Text = "Xem đề thi";
            this.bbiShowTest.UseSelectable = true;
            this.bbiShowTest.Click += new System.EventHandler(this.bbiShowTest_Click);
            // 
            // ucCreateTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucCreateTest";
            this.Size = new System.Drawing.Size(911, 758);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcShift)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOriginalTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel lbStaffCreate;
        private MetroFramework.Controls.MetroLabel lbDateCreate;
        private MetroFramework.Controls.MetroLabel lbTotalScore;
        private MetroFramework.Controls.MetroLabel lbTotalQuestion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gcShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumContestant;
        private System.Windows.Forms.DataGridView gcOriginalTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestDate;
        private MetroFramework.Controls.MetroButton bbiShowTest;
    }
}
