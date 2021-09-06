namespace EXON.MONITOR.Control
{
    partial class ucQuanLyMayThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckStatusCom = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddnew = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.btnFilt = new System.Windows.Forms.Button();
            this.rdOK = new System.Windows.Forms.RadioButton();
            this.rbError = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.cmbKeyName);
            this.groupBox2.Controls.Add(this.btnFilt);
            this.groupBox2.Controls.Add(this.rdOK);
            this.groupBox2.Controls.Add(this.rbError);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.gvMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1149, 460);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách máy thi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheckStatusCom);
            this.groupBox1.Controls.Add(this.btnImportExcel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.lbCount);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAddnew);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1143, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnCheckStatusCom
            // 
            this.btnCheckStatusCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckStatusCom.Location = new System.Drawing.Point(315, 11);
            this.btnCheckStatusCom.Name = "btnCheckStatusCom";
            this.btnCheckStatusCom.Size = new System.Drawing.Size(129, 30);
            this.btnCheckStatusCom.TabIndex = 10;
            this.btnCheckStatusCom.Text = "Kiểm tra tình trạng máy";
            this.btnCheckStatusCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckStatusCom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckStatusCom.UseVisualStyleBackColor = true;
            this.btnCheckStatusCom.Click += new System.EventHandler(this.btnCheckStatusCom_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.Location = new System.Drawing.Point(882, 11);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(123, 30);
            this.btnImportExcel.TabIndex = 9;
            this.btnImportExcel.Text = "Nhập từ file Excel";
            this.btnImportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Máy thi tốt";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkGreen;
            this.button4.Location = new System.Drawing.Point(129, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(19, 19);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Máy thi hỏng";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(8, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 19);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(6, 16);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(48, 13);
            this.lbCount.TabIndex = 5;
            this.lbCount.Text = "Tổng Số";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::EXON.MONITOR.Properties.Resources.refresh162;
            this.btnRefresh.Location = new System.Drawing.Point(1014, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::EXON.MONITOR.Properties.Resources.delete16;
            this.btnDelete.Location = new System.Drawing.Point(753, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddnew
            // 
            this.btnAddnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddnew.Image = global::EXON.MONITOR.Properties.Resources.add16;
            this.btnAddnew.Location = new System.Drawing.Point(477, 11);
            this.btnAddnew.Name = "btnAddnew";
            this.btnAddnew.Size = new System.Drawing.Size(109, 30);
            this.btnAddnew.TabIndex = 1;
            this.btnAddnew.Text = "Thêm mới";
            this.btnAddnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddnew.UseVisualStyleBackColor = true;
            this.btnAddnew.Click += new System.EventHandler(this.btnAddnew_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Image = global::EXON.MONITOR.Properties.Resources.Excel_icon;
            this.btnExcel.Location = new System.Drawing.Point(611, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(123, 30);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Sửa";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKeyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(89, 19);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(438, 21);
            this.cmbKeyName.TabIndex = 9;
            // 
            // btnFilt
            // 
            this.btnFilt.Image = global::EXON.MONITOR.Properties.Resources.filter;
            this.btnFilt.Location = new System.Drawing.Point(995, 15);
            this.btnFilt.Name = "btnFilt";
            this.btnFilt.Size = new System.Drawing.Size(75, 23);
            this.btnFilt.TabIndex = 8;
            this.btnFilt.Text = "Lọc";
            this.btnFilt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilt.UseVisualStyleBackColor = true;
            this.btnFilt.Click += new System.EventHandler(this.btnFilt_Click);
            // 
            // rdOK
            // 
            this.rdOK.AutoSize = true;
            this.rdOK.Location = new System.Drawing.Point(896, 18);
            this.rdOK.Name = "rdOK";
            this.rdOK.Size = new System.Drawing.Size(60, 17);
            this.rdOK.TabIndex = 7;
            this.rdOK.TabStop = true;
            this.rdOK.Text = "Máy tốt";
            this.rdOK.UseVisualStyleBackColor = true;
            // 
            // rbError
            // 
            this.rbError.AutoSize = true;
            this.rbError.Location = new System.Drawing.Point(782, 19);
            this.rbError.Name = "rbError";
            this.rbError.Size = new System.Drawing.Size(72, 17);
            this.rbError.TabIndex = 6;
            this.rbError.Text = "Máy hỏng";
            this.rbError.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(719, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(57, 17);
            this.rbAll.TabIndex = 5;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Tất Cả";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.ImageIndex = 0;
            this.btnClear.Location = new System.Drawing.Point(614, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::EXON.MONITOR.Properties.Resources.search16;
            this.btnSearch.Location = new System.Drawing.Point(533, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm Kiếm";
            // 
            // gvMain
            // 
            this.gvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMain.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cSTT,
            this.cContestantCode,
            this.cName,
            this.cStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvMain.GridColor = System.Drawing.Color.Black;
            this.gvMain.Location = new System.Drawing.Point(3, 61);
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.Size = new System.Drawing.Size(1143, 318);
            this.gvMain.TabIndex = 0;
            this.gvMain.SelectionChanged += new System.EventHandler(this.gvMain_SelectionChanged);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "RoomDiagramID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Visible = false;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.ReadOnly = true;
            this.cSTT.Width = 50;
            // 
            // cContestantCode
            // 
            this.cContestantCode.DataPropertyName = "ComputerCode";
            this.cContestantCode.HeaderText = "Mã máy";
            this.cContestantCode.Name = "cContestantCode";
            this.cContestantCode.ReadOnly = true;
            this.cContestantCode.Width = 300;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cName.DataPropertyName = "ComputerName";
            this.cName.HeaderText = "Tên máy thi";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "Status";
            this.cStatus.HeaderText = "Trạng Thái";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            this.cStatus.Width = 300;
            // 
            // ucQuanLyMayThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "ucQuanLyMayThi";
            this.Size = new System.Drawing.Size(1149, 460);
            this.Load += new System.EventHandler(this.ucQuanLyMayThi_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbKeyName;
        private System.Windows.Forms.Button btnFilt;
        private System.Windows.Forms.RadioButton rdOK;
        private System.Windows.Forms.RadioButton rbError;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddnew;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCheckStatusCom;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
    }
}
