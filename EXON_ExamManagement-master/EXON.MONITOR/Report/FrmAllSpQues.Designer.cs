namespace ReportRoomDiagrams
{
    partial class FrmAllSpQues
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SpeakingQuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDataset = new ReportRoomDiagrams.ReportDataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakingQuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // SpeakingQuesBindingSource
            // 
            this.SpeakingQuesBindingSource.DataMember = "SpeakingQues";
            this.SpeakingQuesBindingSource.DataSource = this.ReportDataset;
            // 
            // ReportDataset
            // 
            this.ReportDataset.DataSetName = "ReportDataset";
            this.ReportDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SpeakingQues";
            reportDataSource1.Value = this.SpeakingQuesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EXON.MONITOR.Report.rpAllSpQues.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(710, 599);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmAllSpQues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 599);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmAllSpQues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAllQues";
            this.Load += new System.EventHandler(this.FrmAllSpQues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpeakingQuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SpeakingQuesBindingSource;
        private ReportDataset ReportDataset;
    }
}