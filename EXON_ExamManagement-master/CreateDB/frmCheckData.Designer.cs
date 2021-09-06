namespace CreateDB
{
    partial class frmCheckData
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
            this.pbPercent = new System.Windows.Forms.ProgressBar();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cbCheckCountTest = new System.Windows.Forms.CheckBox();
            this.cbSLCauHoi = new System.Windows.Forms.CheckBox();
            this.lbPercent = new System.Windows.Forms.Label();
            this.cbCheckData = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbPercent
            // 
            this.pbPercent.Location = new System.Drawing.Point(51, 56);
            this.pbPercent.Name = "pbPercent";
            this.pbPercent.Size = new System.Drawing.Size(563, 23);
            this.pbPercent.TabIndex = 0;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(48, 100);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(16, 15);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "...";
            // 
            // cbCheckCountTest
            // 
            this.cbCheckCountTest.AutoSize = true;
            this.cbCheckCountTest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCheckCountTest.Location = new System.Drawing.Point(51, 154);
            this.cbCheckCountTest.Name = "cbCheckCountTest";
            this.cbCheckCountTest.Size = new System.Drawing.Size(110, 19);
            this.cbCheckCountTest.TabIndex = 2;
            this.cbCheckCountTest.Text = "Số lượng đề thi";
            this.cbCheckCountTest.UseVisualStyleBackColor = true;
            // 
            // cbSLCauHoi
            // 
            this.cbSLCauHoi.AutoSize = true;
            this.cbSLCauHoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSLCauHoi.Location = new System.Drawing.Point(51, 190);
            this.cbSLCauHoi.Name = "cbSLCauHoi";
            this.cbSLCauHoi.Size = new System.Drawing.Size(120, 19);
            this.cbSLCauHoi.TabIndex = 2;
            this.cbSLCauHoi.Text = "Số lượng câu hỏi";
            this.cbSLCauHoi.UseVisualStyleBackColor = true;
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.Location = new System.Drawing.Point(629, 66);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(21, 13);
            this.lbPercent.TabIndex = 1;
            this.lbPercent.Text = "0%";
            // 
            // cbCheckData
            // 
            this.cbCheckData.AutoSize = true;
            this.cbCheckData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCheckData.Location = new System.Drawing.Point(51, 225);
            this.cbCheckData.Name = "cbCheckData";
            this.cbCheckData.Size = new System.Drawing.Size(146, 19);
            this.cbCheckData.TabIndex = 2;
            this.cbCheckData.Text = "Kiểm tra dữ liệu đề thi";
            this.cbCheckData.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "KIỂM TRA DỮ LIỆU";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(539, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmCheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 268);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCheckData);
            this.Controls.Add(this.cbSLCauHoi);
            this.Controls.Add(this.cbCheckCountTest);
            this.Controls.Add(this.lbPercent);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.pbPercent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCheckData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra dữ liệu";
            this.Load += new System.EventHandler(this.frmCheckData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbPercent;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.CheckBox cbCheckCountTest;
        private System.Windows.Forms.CheckBox cbSLCauHoi;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.CheckBox cbCheckData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}