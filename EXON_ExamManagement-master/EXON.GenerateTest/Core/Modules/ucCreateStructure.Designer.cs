namespace EXON.GenerateTest.Core.Controls
{
    partial class ucCreateStructure
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gcStructTest = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartOrderInTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderOfTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotalScore = new MetroFramework.Controls.MetroLabel();
            this.lbTotalQuestion = new MetroFramework.Controls.MetroLabel();
            this.lbTotalTopic = new MetroFramework.Controls.MetroLabel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcStructTest)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcStructTest);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(885, 805);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu Trúc Đề";
            // 
            // gcStructTest
            // 
            this.gcStructTest.AllowUserToAddRows = false;
            this.gcStructTest.AllowUserToDeleteRows = false;
            this.gcStructTest.AllowUserToOrderColumns = true;
            this.gcStructTest.AllowUserToResizeRows = false;
            this.gcStructTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gcStructTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gcStructTest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gcStructTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gcStructTest.ColumnHeadersHeight = 20;
            this.gcStructTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.TopicID,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.PartOrderInTest,
            this.ParSubjectID,
            this.OrderOfTopic});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gcStructTest.DefaultCellStyle = dataGridViewCellStyle2;
            this.gcStructTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcStructTest.EnableHeadersVisualStyles = false;
            this.gcStructTest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcStructTest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gcStructTest.Location = new System.Drawing.Point(4, 19);
            this.gcStructTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcStructTest.MultiSelect = false;
            this.gcStructTest.Name = "gcStructTest";
            this.gcStructTest.ReadOnly = true;
            this.gcStructTest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gcStructTest.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gcStructTest.RowHeadersVisible = false;
            this.gcStructTest.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gcStructTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gcStructTest.Size = new System.Drawing.Size(877, 687);
            this.gcStructTest.TabIndex = 2;
            this.gcStructTest.SelectionChanged += new System.EventHandler(this.gcStructTest_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "TopicName";
            this.Column1.HeaderText = "Chủ Đề";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // TopicID
            // 
            this.TopicID.DataPropertyName = "TopicID";
            this.TopicID.HeaderText = "ID";
            this.TopicID.Name = "TopicID";
            this.TopicID.ReadOnly = true;
            this.TopicID.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Level1";
            this.Column2.FillWeight = 80F;
            this.Column2.HeaderText = "Level 1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Level2";
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "Level 2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Level3";
            this.Column4.FillWeight = 80F;
            this.Column4.HeaderText = "Level 3";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Level4";
            this.Column5.FillWeight = 80F;
            this.Column5.HeaderText = "Level 4";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // PartOrderInTest
            // 
            this.PartOrderInTest.DataPropertyName = "PartOrderInTest";
            this.PartOrderInTest.FillWeight = 80F;
            this.PartOrderInTest.HeaderText = "Phần thi";
            this.PartOrderInTest.Name = "PartOrderInTest";
            this.PartOrderInTest.ReadOnly = true;
            this.PartOrderInTest.Width = 80;
            // 
            // ParSubjectID
            // 
            this.ParSubjectID.DataPropertyName = "ParSubjectID";
            this.ParSubjectID.FillWeight = 80F;
            this.ParSubjectID.HeaderText = "PartID";
            this.ParSubjectID.Name = "ParSubjectID";
            this.ParSubjectID.ReadOnly = true;
            this.ParSubjectID.Visible = false;
            this.ParSubjectID.Width = 80;
            // 
            // OrderOfTopic
            // 
            this.OrderOfTopic.DataPropertyName = "OrderOfTopic";
            this.OrderOfTopic.FillWeight = 80F;
            this.OrderOfTopic.HeaderText = "Thứ Tự";
            this.OrderOfTopic.Name = "OrderOfTopic";
            this.OrderOfTopic.ReadOnly = true;
            this.OrderOfTopic.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTotalScore);
            this.groupBox2.Controls.Add(this.lbTotalQuestion);
            this.groupBox2.Controls.Add(this.lbTotalTopic);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(4, 706);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(877, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống Kê";
            // 
            // lbTotalScore
            // 
            this.lbTotalScore.AutoSize = true;
            this.lbTotalScore.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbTotalScore.Location = new System.Drawing.Point(271, 60);
            this.lbTotalScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalScore.Name = "lbTotalScore";
            this.lbTotalScore.Size = new System.Drawing.Size(104, 20);
            this.lbTotalScore.Style = MetroFramework.MetroColorStyle.Lime;
            this.lbTotalScore.TabIndex = 2;
            this.lbTotalScore.Text = "Tổng Số Điểm";
            // 
            // lbTotalQuestion
            // 
            this.lbTotalQuestion.AutoSize = true;
            this.lbTotalQuestion.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbTotalQuestion.Location = new System.Drawing.Point(9, 60);
            this.lbTotalQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalQuestion.Name = "lbTotalQuestion";
            this.lbTotalQuestion.Size = new System.Drawing.Size(83, 20);
            this.lbTotalQuestion.Style = MetroFramework.MetroColorStyle.Lime;
            this.lbTotalQuestion.TabIndex = 1;
            this.lbTotalQuestion.Text = "Số Câu Hỏi";
            // 
            // lbTotalTopic
            // 
            this.lbTotalTopic.AutoSize = true;
            this.lbTotalTopic.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbTotalTopic.Location = new System.Drawing.Point(9, 25);
            this.lbTotalTopic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalTopic.Name = "lbTotalTopic";
            this.lbTotalTopic.Size = new System.Drawing.Size(78, 20);
            this.lbTotalTopic.Style = MetroFramework.MetroColorStyle.Lime;
            this.lbTotalTopic.TabIndex = 0;
            this.lbTotalTopic.Text = "Số Chủ Đề";
            // 
            // pnMain
            // 
            this.pnMain.AutoScroll = true;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(885, 0);
            this.pnMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnMain.MinimumSize = new System.Drawing.Size(800, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(800, 805);
            this.pnMain.TabIndex = 2;
            // 
            // ucCreateStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucCreateStructure";
            this.Size = new System.Drawing.Size(1625, 805);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcStructTest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gcStructTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnMain;
        private MetroFramework.Controls.MetroLabel lbTotalScore;
        private MetroFramework.Controls.MetroLabel lbTotalQuestion;
        private MetroFramework.Controls.MetroLabel lbTotalTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartOrderInTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderOfTopic;
    }
}
