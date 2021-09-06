namespace EXON.GenerateTest.Core.Forms
{
    partial class frmPart
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
            this.nbOrder = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbShuffle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // nbOrder
            // 
            this.nbOrder.Location = new System.Drawing.Point(114, 161);
            this.nbOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nbOrder.Name = "nbOrder";
            this.nbOrder.Size = new System.Drawing.Size(49, 20);
            this.nbOrder.TabIndex = 59;
            this.nbOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(114, 91);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(362, 63);
            this.txtName.TabIndex = 58;
            this.txtName.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "STT Phần Thi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Tên Phần Thi";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(401, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(320, 191);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 54;
            this.btnOK.Text = "Thêm ";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbShuffle
            // 
            this.cbShuffle.FormattingEnabled = true;
            this.cbShuffle.Items.AddRange(new object[] {
            "Không",
            "Có",
            "--Chọn--"});
            this.cbShuffle.Location = new System.Drawing.Point(243, 160);
            this.cbShuffle.Name = "cbShuffle";
            this.cbShuffle.Size = new System.Drawing.Size(233, 21);
            this.cbShuffle.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Đảo câu";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(114, 65);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(362, 20);
            this.txtSubjectName.TabIndex = 51;
            this.txtSubjectName.Tag = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Tên Môn Thi";
            // 
            // frmPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 245);
            this.Controls.Add(this.nbOrder);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbShuffle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label1);
            this.Name = "frmPart";
            this.Text = "Thêm Phần Thi";
            ((System.ComponentModel.ISupportInitialize)(this.nbOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nbOrder;
        private System.Windows.Forms.RichTextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbShuffle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label1;
    }
}