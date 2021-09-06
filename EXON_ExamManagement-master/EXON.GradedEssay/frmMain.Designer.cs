namespace EXON.GradedEssay
{
    partial class frmMain
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
            this.mbtnWritting = new MetroFramework.Controls.MetroButton();
            this.mbtnSpeaking = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // mbtnWritting
            // 
            this.mbtnWritting.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnWritting.Highlight = true;
            this.mbtnWritting.Location = new System.Drawing.Point(78, 131);
            this.mbtnWritting.Name = "mbtnWritting";
            this.mbtnWritting.Size = new System.Drawing.Size(143, 66);
            this.mbtnWritting.TabIndex = 0;
            this.mbtnWritting.Text = "Chấm thi viết";
            this.mbtnWritting.UseSelectable = true;
            this.mbtnWritting.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // mbtnSpeaking
            // 
            this.mbtnSpeaking.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnSpeaking.Highlight = true;
            this.mbtnSpeaking.Location = new System.Drawing.Point(346, 131);
            this.mbtnSpeaking.Name = "mbtnSpeaking";
            this.mbtnSpeaking.Size = new System.Drawing.Size(138, 66);
            this.mbtnSpeaking.TabIndex = 1;
            this.mbtnSpeaking.Text = "Chấm thi nói";
            this.mbtnSpeaking.UseSelectable = true;
            this.mbtnSpeaking.Click += new System.EventHandler(this.mbtnSpeaking_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 312);
            this.Controls.Add(this.mbtnSpeaking);
            this.Controls.Add(this.mbtnWritting);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 24);
            this.Text = "Chấm thi ngoại ngữ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton mbtnWritting;
        private MetroFramework.Controls.MetroButton mbtnSpeaking;
    }
}