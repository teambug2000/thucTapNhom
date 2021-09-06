namespace EXON.GenerateTest.Core.Controls
{
    partial class ucAudioQuestion
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
            this.tbProcess = new MetroFramework.Controls.MetroTrackBar();
            this.lbFilename = new MetroFramework.Controls.MetroLabel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lbCurrentTime = new MetroFramework.Controls.MetroLabel();
            this.lbMaxLength = new MetroFramework.Controls.MetroLabel();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbProcess
            // 
            this.tbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProcess.BackColor = System.Drawing.Color.Transparent;
            this.tbProcess.Location = new System.Drawing.Point(17, 45);
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(519, 23);
            this.tbProcess.TabIndex = 0;
            this.tbProcess.Text = "metroTrackBar1";
            this.tbProcess.Value = 0;
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(17, 12);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(66, 19);
            this.lbFilename.TabIndex = 1;
            this.lbFilename.Text = "File name";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(17, 112);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.AutoSize = true;
            this.lbCurrentTime.Location = new System.Drawing.Point(17, 71);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(33, 19);
            this.lbCurrentTime.TabIndex = 3;
            this.lbCurrentTime.Text = "0:00";
            // 
            // lbMaxLength
            // 
            this.lbMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaxLength.AutoSize = true;
            this.lbMaxLength.Location = new System.Drawing.Point(500, 71);
            this.lbMaxLength.Name = "lbMaxLength";
            this.lbMaxLength.Size = new System.Drawing.Size(36, 19);
            this.lbMaxLength.TabIndex = 4;
            this.lbMaxLength.Text = "NaN";
            this.lbMaxLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(98, 112);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 5;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // ucAudioQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.lbMaxLength);
            this.Controls.Add(this.lbCurrentTime);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lbFilename);
            this.Controls.Add(this.tbProcess);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(0, 140);
            this.Name = "ucAudioQuestion";
            this.Size = new System.Drawing.Size(565, 167);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTrackBar tbProcess;
        private MetroFramework.Controls.MetroLabel lbFilename;
        private System.Windows.Forms.Button btnPlay;
        private MetroFramework.Controls.MetroLabel lbCurrentTime;
        private MetroFramework.Controls.MetroLabel lbMaxLength;
        private System.Windows.Forms.Button btnLoadFile;
    }
}
