namespace EXON.GradedEssay
{
    partial class frmWriting
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStaff1 = new System.Windows.Forms.ComboBox();
            this.cbStaff2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbContest = new System.Windows.Forms.Label();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintAnswer = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Ca Thi";
            // 
            // cbShift
            // 
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Location = new System.Drawing.Point(100, 94);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(178, 21);
            this.cbShift.TabIndex = 1;
            this.cbShift.SelectedValueChanged += new System.EventHandler(this.cbShift_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giáo viên 1";
            // 
            // cbStaff1
            // 
            this.cbStaff1.FormattingEnabled = true;
            this.cbStaff1.Location = new System.Drawing.Point(100, 127);
            this.cbStaff1.Name = "cbStaff1";
            this.cbStaff1.Size = new System.Drawing.Size(178, 21);
            this.cbStaff1.TabIndex = 3;
            // 
            // cbStaff2
            // 
            this.cbStaff2.FormattingEnabled = true;
            this.cbStaff2.Location = new System.Drawing.Point(361, 127);
            this.cbStaff2.Name = "cbStaff2";
            this.cbStaff2.Size = new System.Drawing.Size(178, 21);
            this.cbStaff2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giáo viên 2";
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToAddRows = false;
            this.gvMain.AllowUserToDeleteRows = false;
            this.gvMain.BackgroundColor = System.Drawing.Color.White;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTestNumberIndex,
            this.cScore,
            this.cContestantShiftID,
            this.btnPrintAnswer});
            this.gvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvMain.Location = new System.Drawing.Point(36, 192);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(503, 310);
            this.gvMain.TabIndex = 6;
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Danh sách thí sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Môn thi";
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(361, 94);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(178, 21);
            this.cbSubject.TabIndex = 9;
            this.cbSubject.SelectedIndexChanged += new System.EventHandler(this.cbSubject_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(414, 508);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(283, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Xuất Biểu Mẫu";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lbContest
            // 
            this.lbContest.AutoSize = true;
            this.lbContest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContest.Location = new System.Drawing.Point(33, 60);
            this.lbContest.Name = "lbContest";
            this.lbContest.Size = new System.Drawing.Size(41, 15);
            this.lbContest.TabIndex = 12;
            this.lbContest.Text = "Kì Thi:";
            // 
            // cTestNumberIndex
            // 
            this.cTestNumberIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTestNumberIndex.DataPropertyName = "TestNumberIndex";
            this.cTestNumberIndex.HeaderText = "Số Phách";
            this.cTestNumberIndex.Name = "cTestNumberIndex";
            this.cTestNumberIndex.ReadOnly = true;
            // 
            // cScore
            // 
            this.cScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Tổng Điểm";
            this.cScore.Name = "cScore";
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // btnPrintAnswer
            // 
            this.btnPrintAnswer.DataPropertyName = "PrintAnswer";
            this.btnPrintAnswer.HeaderText = "In Câu Trả Lời";
            this.btnPrintAnswer.Name = "btnPrintAnswer";
            this.btnPrintAnswer.Text = "In";
            // 
            // frmWriting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 545);
            this.Controls.Add(this.lbContest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbSubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.cbStaff2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStaff1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.label1);
            this.Name = "frmWriting";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Chấm Thi Viết";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStaff1;
        private System.Windows.Forms.ComboBox cbStaff2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
        private System.Windows.Forms.DataGridViewButtonColumn btnPrintAnswer;
    }
}