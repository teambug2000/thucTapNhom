namespace EXON.RegisterManager.Module.Forms
{
    partial class frmImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcel));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pgb_step1 = new System.Windows.Forms.ProgressBar();
            this.lbl_step1 = new System.Windows.Forms.Label();
            this.lbl_step2 = new System.Windows.Forms.Label();
            this.pgb_step2 = new System.Windows.Forms.ProgressBar();
            this.lbl_step3 = new System.Windows.Forms.Label();
            this.pgb_step3 = new System.Windows.Forms.ProgressBar();
            this.btn_ChooseFile = new System.Windows.Forms.Button();
            this.btn_HuyBo = new System.Windows.Forms.Button();
            this.lbl_percent1 = new System.Windows.Forms.Label();
            this.lbl_percent2 = new System.Windows.Forms.Label();
            this.lbl_percent3 = new System.Windows.Forms.Label();
            //this.bw_step1 = new System.ComponentModel.BackgroundWorker();
            //this.bw_step2 = new System.ComponentModel.BackgroundWorker();
            //this.bw_step3 = new System.ComponentModel.BackgroundWorker();
            this.bw_step1 = new AbortableBackgroundWorker();
            this.bw_step2 = new AbortableBackgroundWorker();
            this.bw_step3 = new AbortableBackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "______________________________________________________________________";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(81, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(367, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(653, 93);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn File Excel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(363, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kiểm Tra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(617, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhập DS Thí Sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(638, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Và Xếp Lịch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(325, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tính Hợp Lệ Ca Thi";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(211, 93);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(90, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(497, 93);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(90, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // pgb_step1
            // 
            this.pgb_step1.Location = new System.Drawing.Point(9, 263);
            this.pgb_step1.Name = "pgb_step1";
            this.pgb_step1.Size = new System.Drawing.Size(221, 30);
            this.pgb_step1.TabIndex = 11;
            // 
            // lbl_step1
            // 
            this.lbl_step1.AutoSize = true;
            this.lbl_step1.Location = new System.Drawing.Point(6, 247);
            this.lbl_step1.Name = "lbl_step1";
            this.lbl_step1.Size = new System.Drawing.Size(46, 13);
            this.lbl_step1.TabIndex = 12;
            this.lbl_step1.Text = "Status...";
            // 
            // lbl_step2
            // 
            this.lbl_step2.AutoSize = true;
            this.lbl_step2.Location = new System.Drawing.Point(287, 247);
            this.lbl_step2.Name = "lbl_step2";
            this.lbl_step2.Size = new System.Drawing.Size(46, 13);
            this.lbl_step2.TabIndex = 14;
            this.lbl_step2.Text = "Status...";
            // 
            // pgb_step2
            // 
            this.pgb_step2.Location = new System.Drawing.Point(282, 263);
            this.pgb_step2.Name = "pgb_step2";
            this.pgb_step2.Size = new System.Drawing.Size(221, 30);
            this.pgb_step2.TabIndex = 13;
            // 
            // lbl_step3
            // 
            this.lbl_step3.AutoSize = true;
            this.lbl_step3.Location = new System.Drawing.Point(557, 247);
            this.lbl_step3.Name = "lbl_step3";
            this.lbl_step3.Size = new System.Drawing.Size(46, 13);
            this.lbl_step3.TabIndex = 16;
            this.lbl_step3.Text = "Status...";
            // 
            // pgb_step3
            // 
            this.pgb_step3.Location = new System.Drawing.Point(555, 263);
            this.pgb_step3.Name = "pgb_step3";
            this.pgb_step3.Size = new System.Drawing.Size(221, 30);
            this.pgb_step3.TabIndex = 15;
            // 
            // btn_ChooseFile
            // 
            this.btn_ChooseFile.Location = new System.Drawing.Point(72, 189);
            this.btn_ChooseFile.Name = "btn_ChooseFile";
            this.btn_ChooseFile.Size = new System.Drawing.Size(83, 23);
            this.btn_ChooseFile.TabIndex = 17;
            this.btn_ChooseFile.Text = "Chọn File";
            this.btn_ChooseFile.UseVisualStyleBackColor = true;
            this.btn_ChooseFile.Click += new System.EventHandler(this.btn_ChooseFile_Click);
            // 
            // btn_HuyBo
            // 
            this.btn_HuyBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HuyBo.Location = new System.Drawing.Point(360, 322);
            this.btn_HuyBo.Name = "btn_HuyBo";
            this.btn_HuyBo.Size = new System.Drawing.Size(101, 37);
            this.btn_HuyBo.TabIndex = 18;
            this.btn_HuyBo.Text = "Hủy Bỏ";
            this.btn_HuyBo.UseVisualStyleBackColor = true;
            this.btn_HuyBo.Click += new System.EventHandler(this.btn_HuyBo_Click);
            // 
            // lbl_percent1
            // 
            this.lbl_percent1.AutoSize = true;
            this.lbl_percent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_percent1.Location = new System.Drawing.Point(236, 276);
            this.lbl_percent1.Name = "lbl_percent1";
            this.lbl_percent1.Size = new System.Drawing.Size(20, 17);
            this.lbl_percent1.TabIndex = 19;
            this.lbl_percent1.Text = "%";
            // 
            // lbl_percent2
            // 
            this.lbl_percent2.AutoSize = true;
            this.lbl_percent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_percent2.Location = new System.Drawing.Point(509, 276);
            this.lbl_percent2.Name = "lbl_percent2";
            this.lbl_percent2.Size = new System.Drawing.Size(20, 17);
            this.lbl_percent2.TabIndex = 20;
            this.lbl_percent2.Text = "%";
            // 
            // lbl_percent3
            // 
            this.lbl_percent3.AutoSize = true;
            this.lbl_percent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_percent3.Location = new System.Drawing.Point(782, 276);
            this.lbl_percent3.Name = "lbl_percent3";
            this.lbl_percent3.Size = new System.Drawing.Size(20, 17);
            this.lbl_percent3.TabIndex = 21;
            this.lbl_percent3.Text = "%";
            // 
            // bw_step1
            // 
            this.bw_step1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_step1_DoWork);
            this.bw_step1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_step1_ProgressChanged);
            this.bw_step1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_step1_RunWorkerCompleted);
            // 
            // bw_step2
            // 
            this.bw_step2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_step2_DoWork);
            this.bw_step2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_step2_ProgressChanged);
            this.bw_step2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_step2_RunWorkerCompleted);
            // 
            // bw_step3
            // 
            this.bw_step3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_step3_DoWork);
            this.bw_step3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_step3_ProgressChanged);
            this.bw_step3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_step3_RunWorkerCompleted);
            // 
            // frmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 382);
            this.Controls.Add(this.lbl_percent3);
            this.Controls.Add(this.lbl_percent2);
            this.Controls.Add(this.lbl_percent1);
            this.Controls.Add(this.btn_HuyBo);
            this.Controls.Add(this.btn_ChooseFile);
            this.Controls.Add(this.lbl_step3);
            this.Controls.Add(this.pgb_step3);
            this.Controls.Add(this.lbl_step2);
            this.Controls.Add(this.pgb_step2);
            this.Controls.Add(this.lbl_step1);
            this.Controls.Add(this.pgb_step1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmImportExcel";
            this.Resizable = false;
            this.Text = "                         NHẬP DANH SÁCH THÍ SINH VÀ XẾP LỊCH";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImportExcel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ProgressBar pgb_step1;
        private System.Windows.Forms.Label lbl_step1;
        private System.Windows.Forms.Label lbl_step2;
        private System.Windows.Forms.ProgressBar pgb_step2;
        private System.Windows.Forms.Label lbl_step3;
        private System.Windows.Forms.ProgressBar pgb_step3;
        private System.Windows.Forms.Button btn_ChooseFile;
        private System.Windows.Forms.Button btn_HuyBo;
        private System.Windows.Forms.Label lbl_percent1;
        private System.Windows.Forms.Label lbl_percent2;
        private System.Windows.Forms.Label lbl_percent3;
        private AbortableBackgroundWorker bw_step1;
        private AbortableBackgroundWorker bw_step2;
        private AbortableBackgroundWorker bw_step3;
    }
}