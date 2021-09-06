namespace EXON.RegisterManager.Module.Forms
{
    partial class frmFilter
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_DiaDiemThi = new System.Windows.Forms.ComboBox();
            this.cbx_PhongThi = new System.Windows.Forms.ComboBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa điểm thi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng thi";
            // 
            // cbx_DiaDiemThi
            // 
            this.cbx_DiaDiemThi.FormattingEnabled = true;
            this.cbx_DiaDiemThi.Location = new System.Drawing.Point(106, 77);
            this.cbx_DiaDiemThi.Name = "cbx_DiaDiemThi";
            this.cbx_DiaDiemThi.Size = new System.Drawing.Size(154, 21);
            this.cbx_DiaDiemThi.TabIndex = 2;
            this.cbx_DiaDiemThi.SelectedIndexChanged += new System.EventHandler(this.cbx_DiaDiemThi_SelectedIndexChanged);
            // 
            // cbx_PhongThi
            // 
            this.cbx_PhongThi.FormattingEnabled = true;
            this.cbx_PhongThi.Location = new System.Drawing.Point(106, 111);
            this.cbx_PhongThi.Name = "cbx_PhongThi";
            this.cbx_PhongThi.Size = new System.Drawing.Size(154, 21);
            this.cbx_PhongThi.TabIndex = 3;
            this.cbx_PhongThi.SelectedIndexChanged += new System.EventHandler(this.cbx_PhongThi_SelectedIndexChanged);
            // 
            // btn_filter
            // 
            this.btn_filter.Location = new System.Drawing.Point(127, 171);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(92, 32);
            this.btn_filter.TabIndex = 4;
            this.btn_filter.Text = "Lọc";
            this.btn_filter.UseVisualStyleBackColor = true;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 256);
            this.Controls.Add(this.btn_filter);
            this.Controls.Add(this.cbx_PhongThi);
            this.Controls.Add(this.cbx_DiaDiemThi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFilter";
            this.Text = "Bộ lọc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFilter_FormClosing);
            this.Load += new System.EventHandler(this.frmFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_DiaDiemThi;
        private System.Windows.Forms.ComboBox cbx_PhongThi;
        private System.Windows.Forms.Button btn_filter;
    }
}