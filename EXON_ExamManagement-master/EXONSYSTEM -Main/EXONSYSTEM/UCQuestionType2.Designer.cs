namespace EXONSYSTEM
{
    partial class UCQuestionType2
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
            this.pnTitleOfQuestion = new System.Windows.Forms.Panel();
            this.rtbTitleOfQuestion = new System.Windows.Forms.RichTextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.mpnAnswers = new System.Windows.Forms.Panel();
            this.pnTitleOfQuestion.SuspendLayout();
            this.mpnAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTitleOfQuestion
            // 
            this.pnTitleOfQuestion.Controls.Add(this.rtbTitleOfQuestion);
            this.pnTitleOfQuestion.Controls.Add(this.lbNumber);
            this.pnTitleOfQuestion.Location = new System.Drawing.Point(55, 3);
            this.pnTitleOfQuestion.Name = "pnTitleOfQuestion";
            this.pnTitleOfQuestion.Size = new System.Drawing.Size(636, 37);
            this.pnTitleOfQuestion.TabIndex = 5;
            // 
            // rtbTitleOfQuestion
            // 
            this.rtbTitleOfQuestion.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtbTitleOfQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtbTitleOfQuestion.Location = new System.Drawing.Point(81, 2);
            this.rtbTitleOfQuestion.Margin = new System.Windows.Forms.Padding(5);
            this.rtbTitleOfQuestion.Name = "rtbTitleOfQuestion";
            this.rtbTitleOfQuestion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbTitleOfQuestion.Size = new System.Drawing.Size(541, 33);
            this.rtbTitleOfQuestion.TabIndex = 0;
            this.rtbTitleOfQuestion.Text = "";
            // 
            // lbNumber
            // 
            this.lbNumber.Location = new System.Drawing.Point(4, 6);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(80, 21);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "Câu 999:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Answer: ";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(193, 3);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(265, 29);
            this.txtAnswer.TabIndex = 16;
            // 
            // mpnAnswers
            // 
            this.mpnAnswers.Controls.Add(this.label1);
            this.mpnAnswers.Controls.Add(this.txtAnswer);
            this.mpnAnswers.Location = new System.Drawing.Point(55, 48);
            this.mpnAnswers.Margin = new System.Windows.Forms.Padding(5);
            this.mpnAnswers.Name = "mpnAnswers";
            this.mpnAnswers.Size = new System.Drawing.Size(636, 45);
            this.mpnAnswers.TabIndex = 17;
            // 
            // UCQuestionType2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mpnAnswers);
            this.Controls.Add(this.pnTitleOfQuestion);
            this.Name = "UCQuestionType2";
            this.Size = new System.Drawing.Size(709, 98);
            this.Load += new System.EventHandler(this.UCQuestionType2_Load);
            this.pnTitleOfQuestion.ResumeLayout(false);
            this.mpnAnswers.ResumeLayout(false);
            this.mpnAnswers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitleOfQuestion;
        private System.Windows.Forms.RichTextBox rtbTitleOfQuestion;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Panel mpnAnswers;
    }
}
