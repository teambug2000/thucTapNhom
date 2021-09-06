namespace CreateDB
{
    partial class frmReverseTransfer
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
            this.lbl_completed = new System.Windows.Forms.Label();
            this.pgbLoading = new System.Windows.Forms.ProgressBar();
            this.lbl_percent = new System.Windows.Forms.Label();
            this.lbl_processing = new System.Windows.Forms.Label();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.bw = new CreateDB.AbortableBackgroundWorker();
            this.SuspendLayout();
            // 
            // lbl_completed
            // 
            this.lbl_completed.AutoSize = true;
            this.lbl_completed.Location = new System.Drawing.Point(29, 185);
            this.lbl_completed.Name = "lbl_completed";
            this.lbl_completed.Size = new System.Drawing.Size(54, 13);
            this.lbl_completed.TabIndex = 1;
            this.lbl_completed.Text = "Đã xử lý...";
            // 
            // pgbLoading
            // 
            this.pgbLoading.Location = new System.Drawing.Point(32, 109);
            this.pgbLoading.Name = "pgbLoading";
            this.pgbLoading.Size = new System.Drawing.Size(552, 23);
            this.pgbLoading.TabIndex = 2;
            // 
            // lbl_percent
            // 
            this.lbl_percent.AutoSize = true;
            this.lbl_percent.Location = new System.Drawing.Point(590, 119);
            this.lbl_percent.Name = "lbl_percent";
            this.lbl_percent.Size = new System.Drawing.Size(15, 13);
            this.lbl_percent.TabIndex = 3;
            this.lbl_percent.Text = "%";
            // 
            // lbl_processing
            // 
            this.lbl_processing.AutoSize = true;
            this.lbl_processing.Location = new System.Drawing.Point(29, 161);
            this.lbl_processing.Name = "lbl_processing";
            this.lbl_processing.Size = new System.Drawing.Size(66, 13);
            this.lbl_processing.TabIndex = 4;
            this.lbl_processing.Text = "Đang xử lý...";
            // 
            // btn_Huy
            // 
            this.btn_Huy.Location = new System.Drawing.Point(272, 36);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(90, 42);
            this.btn_Huy.TabIndex = 5;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // frmReverseTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 622);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.lbl_processing);
            this.Controls.Add(this.lbl_percent);
            this.Controls.Add(this.pgbLoading);
            this.Controls.Add(this.lbl_completed);
            this.MaximizeBox = false;
            this.Name = "frmReverseTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển ngược dữ liệu về máy chủ trung tâm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.frmReverseTransfer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AbortableBackgroundWorker bw;
        private System.Windows.Forms.Label lbl_completed;
        private System.Windows.Forms.ProgressBar pgbLoading;
        private System.Windows.Forms.Label lbl_percent;
        private System.Windows.Forms.Label lbl_processing;
        private System.Windows.Forms.Button btn_Huy;
    }
}

