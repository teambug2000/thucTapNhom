namespace EXON.GradedEssay
{
    partial class frmSpeaking
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cbStaff2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStaff1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintResult = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(767, 573);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(367, 83);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(178, 21);
            this.cbSubject.TabIndex = 20;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Môn thi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Danh sách thí sinh";
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToAddRows = false;
            this.gvMain.AllowUserToDeleteRows = false;
            this.gvMain.AllowUserToOrderColumns = true;
            this.gvMain.BackgroundColor = System.Drawing.Color.White;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTestNumberIndex,
            this.Column4,
            this.cMTS,
            this.Column1,
            this.Column2,
            this.cTopic,
            this.cScore,
            this.cContestantShiftID,
            this.btnPrintResult});
            this.gvMain.Location = new System.Drawing.Point(42, 181);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(850, 386);
            this.gvMain.TabIndex = 17;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellValueChanged);
            // 
            // cbStaff2
            // 
            this.cbStaff2.FormattingEnabled = true;
            this.cbStaff2.Location = new System.Drawing.Point(367, 116);
            this.cbStaff2.Name = "cbStaff2";
            this.cbStaff2.Size = new System.Drawing.Size(178, 21);
            this.cbStaff2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Giáo viên 2";
            // 
            // cbStaff1
            // 
            this.cbStaff1.FormattingEnabled = true;
            this.cbStaff1.Location = new System.Drawing.Point(106, 116);
            this.cbStaff1.Name = "cbStaff1";
            this.cbStaff1.Size = new System.Drawing.Size(178, 21);
            this.cbStaff1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Giáo viên 1";
            // 
            // cbShift
            // 
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Location = new System.Drawing.Point(106, 83);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(178, 21);
            this.cbShift.TabIndex = 12;
            this.cbShift.SelectedValueChanged += new System.EventHandler(this.cbShift_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã Ca Thi";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(636, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Xuất Biểu Mẫu";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cTestNumberIndex
            // 
            this.cTestNumberIndex.DataPropertyName = "STT";
            this.cTestNumberIndex.HeaderText = "STT";
            this.cTestNumberIndex.Name = "cTestNumberIndex";
            this.cTestNumberIndex.ReadOnly = true;
            this.cTestNumberIndex.Width = 50;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ShiftName";
            this.Column4.HeaderText = "Ca Thi";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // cMTS
            // 
            this.cMTS.DataPropertyName = "ContestantCode";
            this.cMTS.HeaderText = "Mã Thí Sinh";
            this.cMTS.Name = "cMTS";
            this.cMTS.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "FullName";
            this.Column1.HeaderText = "Họ Tên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "DOB";
            this.Column2.HeaderText = "Ngày Sinh";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // cTopic
            // 
            this.cTopic.HeaderText = "Chủ Đề";
            this.cTopic.Name = "cTopic";
            // 
            // cScore
            // 
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Điểm";
            this.cScore.Name = "cScore";
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.DataPropertyName = "PrintResult";
            this.btnPrintResult.HeaderText = "In Kết Quả";
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnPrintResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmSpeaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 619);
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
            this.Name = "frmSpeaking";
            this.Text = "frmSpeaking";
            this.Load += new System.EventHandler(this.frmSpeaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.ComboBox cbStaff2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStaff1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
        private System.Windows.Forms.DataGridViewButtonColumn btnPrintResult;
    }
}