namespace EXON.MONITOR.GUI
{
    partial class frmServer
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
            this.mpnlTop = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mbtnPrint = new MetroFramework.Controls.MetroButton();
            this.lblEndTime = new MetroFramework.Controls.MetroLabel();
            this.lblShiftName = new MetroFramework.Controls.MetroLabel();
            this.lblSupervisorName = new MetroFramework.Controls.MetroLabel();
            this.lblStartTime = new MetroFramework.Controls.MetroLabel();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.timerStartTest = new System.Windows.Forms.Timer(this.components);
            this.mncPrintArr = new System.Windows.Forms.ToolStripMenuItem();
            this.mncPrintResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mncPrintQuestionSpeaking = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDivisionShift = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemStartTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemChangeShift = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mItemPrintContestant = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPrintResultContestant = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mpnlTop.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroContextMenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpnlTop
            // 
            this.mpnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.mpnlTop.Controls.Add(this.metroPanel1);
            this.mpnlTop.Controls.Add(this.lblEndTime);
            this.mpnlTop.Controls.Add(this.lblShiftName);
            this.mpnlTop.Controls.Add(this.lblSupervisorName);
            this.mpnlTop.Controls.Add(this.lblStartTime);
            this.mpnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.mpnlTop.HorizontalScrollbarBarColor = true;
            this.mpnlTop.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnlTop.HorizontalScrollbarSize = 10;
            this.mpnlTop.Location = new System.Drawing.Point(20, 30);
            this.mpnlTop.Name = "mpnlTop";
            this.mpnlTop.Size = new System.Drawing.Size(1075, 38);
            this.mpnlTop.TabIndex = 6;
            this.mpnlTop.UseCustomBackColor = true;
            this.mpnlTop.UseCustomForeColor = true;
            this.mpnlTop.VerticalScrollbarBarColor = true;
            this.mpnlTop.VerticalScrollbarHighlightOnWheel = false;
            this.mpnlTop.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.Controls.Add(this.mbtnPrint);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(126, 38);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseCustomForeColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mbtnPrint
            // 
            this.mbtnPrint.AutoSize = true;
            this.mbtnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mbtnPrint.DisplayFocus = true;
            this.mbtnPrint.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtnPrint.ForeColor = System.Drawing.Color.DarkRed;
            this.mbtnPrint.Highlight = true;
            this.mbtnPrint.Location = new System.Drawing.Point(0, 0);
            this.mbtnPrint.Name = "mbtnPrint";
            this.mbtnPrint.Size = new System.Drawing.Size(123, 38);
            this.mbtnPrint.TabIndex = 4;
            this.mbtnPrint.Text = "In Danh Sách";
            this.mbtnPrint.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mbtnPrint.UseCustomBackColor = true;
            this.mbtnPrint.UseCustomForeColor = true;
            this.mbtnPrint.UseSelectable = true;
            this.mbtnPrint.Click += new System.EventHandler(this.mbtnPrint_Click);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblEndTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblEndTime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblEndTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblEndTime.ForeColor = System.Drawing.Color.Black;
            this.lblEndTime.Location = new System.Drawing.Point(678, 7);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(111, 25);
            this.lblEndTime.TabIndex = 8;
            this.lblEndTime.Text = "metroLabel3";
            this.lblEndTime.UseCustomBackColor = true;
            this.lblEndTime.UseCustomForeColor = true;
            // 
            // lblShiftName
            // 
            this.lblShiftName.AutoSize = true;
            this.lblShiftName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblShiftName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblShiftName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblShiftName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblShiftName.ForeColor = System.Drawing.Color.Black;
            this.lblShiftName.Location = new System.Drawing.Point(160, 7);
            this.lblShiftName.Name = "lblShiftName";
            this.lblShiftName.Size = new System.Drawing.Size(111, 25);
            this.lblShiftName.TabIndex = 6;
            this.lblShiftName.Text = "metroLabel2";
            this.lblShiftName.UseCustomBackColor = true;
            this.lblShiftName.UseCustomForeColor = true;
            // 
            // lblSupervisorName
            // 
            this.lblSupervisorName.AutoSize = true;
            this.lblSupervisorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblSupervisorName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblSupervisorName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSupervisorName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblSupervisorName.ForeColor = System.Drawing.Color.Black;
            this.lblSupervisorName.Location = new System.Drawing.Point(937, 7);
            this.lblSupervisorName.Name = "lblSupervisorName";
            this.lblSupervisorName.Size = new System.Drawing.Size(111, 25);
            this.lblSupervisorName.TabIndex = 5;
            this.lblSupervisorName.Text = "metroLabel1";
            this.lblSupervisorName.UseCustomBackColor = true;
            this.lblSupervisorName.UseCustomForeColor = true;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblStartTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblStartTime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblStartTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblStartTime.ForeColor = System.Drawing.Color.Black;
            this.lblStartTime.Location = new System.Drawing.Point(419, 7);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(111, 25);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Text = "metroLabel3";
            this.lblStartTime.UseCustomBackColor = true;
            this.lblStartTime.UseCustomForeColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(20, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(1075, 477);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.UseSelectable = true;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControl1_ControlAdded);
            // 
            // timerStartTest
            // 
            this.timerStartTest.Interval = 1000;
            // 
            // mncPrintArr
            // 
            this.mncPrintArr.Name = "mncPrintArr";
            this.mncPrintArr.Size = new System.Drawing.Size(248, 22);
            this.mncPrintArr.Text = "In danh sách thí sinh đã xếp chỗ";
            // 
            // mncPrintResult
            // 
            this.mncPrintResult.Name = "mncPrintResult";
            this.mncPrintResult.Size = new System.Drawing.Size(248, 22);
            this.mncPrintResult.Text = "In kết quả thí sinh đã hoàn thành";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // mncPrintQuestionSpeaking
            // 
            this.mncPrintQuestionSpeaking.Name = "mncPrintQuestionSpeaking";
            this.mncPrintQuestionSpeaking.Size = new System.Drawing.Size(248, 22);
            this.mncPrintQuestionSpeaking.Text = "In câu hỏi cho phần thi nói";
            // 
            // MenuItemDivisionShift
            // 
            this.MenuItemDivisionShift.Enabled = false;
            this.MenuItemDivisionShift.Name = "MenuItemDivisionShift";
            this.MenuItemDivisionShift.Size = new System.Drawing.Size(156, 22);
            this.MenuItemDivisionShift.Text = "&Phát đề";
            // 
            // MenuItemStartTest
            // 
            this.MenuItemStartTest.Enabled = false;
            this.MenuItemStartTest.Name = "MenuItemStartTest";
            this.MenuItemStartTest.Size = new System.Drawing.Size(156, 22);
            this.MenuItemStartTest.Text = "&Bắt đầu làm bài";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // MenuItemChangeShift
            // 
            this.MenuItemChangeShift.Name = "MenuItemChangeShift";
            this.MenuItemChangeShift.Size = new System.Drawing.Size(156, 22);
            this.MenuItemChangeShift.Text = "&Chuyển ca thi ";
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemPrintContestant,
            this.mItemPrintResultContestant,
            this.toolStripSeparator2});
            this.metroContextMenu2.Name = "metroContextMenu2";
            this.metroContextMenu2.Size = new System.Drawing.Size(249, 76);
            // 
            // mItemPrintContestant
            // 
            this.mItemPrintContestant.Name = "mItemPrintContestant";
            this.mItemPrintContestant.Size = new System.Drawing.Size(248, 22);
            this.mItemPrintContestant.Text = "In danh sách thí sinh đã xếp chỗ";
            this.mItemPrintContestant.Click += new System.EventHandler(this.mItemPrintContestant_Click);
            // 
            // mItemPrintResultContestant
            // 
            this.mItemPrintResultContestant.Name = "mItemPrintResultContestant";
            this.mItemPrintResultContestant.Size = new System.Drawing.Size(248, 22);
            this.mItemPrintResultContestant.Text = "In kết quả thí sinh đã hoàn thành";
            this.mItemPrintResultContestant.Click += new System.EventHandler(this.mItemPrintResultContestant_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(245, 6);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.mpnlTop);
            this.DisplayHeader = false;
            this.Name = "frmServer";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "frmServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.mpnlTop.ResumeLayout(false);
            this.mpnlTop.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroContextMenu2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mpnlTop;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton mbtnPrint;
        private MetroFramework.Controls.MetroLabel lblEndTime;
        private MetroFramework.Controls.MetroLabel lblShiftName;
        private MetroFramework.Controls.MetroLabel lblSupervisorName;
        private MetroFramework.Controls.MetroLabel lblStartTime;
        private MetroFramework.Controls.MetroTabControl tabControl1;
        private System.Windows.Forms.Timer timerStartTest;

        private System.Windows.Forms.ToolStripMenuItem mncPrintArr;
        private System.Windows.Forms.ToolStripMenuItem mncPrintResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mncPrintQuestionSpeaking;
       
        private System.Windows.Forms.ToolStripMenuItem MenuItemDivisionShift;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStartTest;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChangeShift;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem mItemPrintContestant;
        private System.Windows.Forms.ToolStripMenuItem mItemPrintResultContestant;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}