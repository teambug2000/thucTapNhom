namespace EXON.GenerateTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Ribbon = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel0 = new System.Windows.Forms.RibbonPanel();
            this.rbiCreateStruct = new System.Windows.Forms.RibbonButton();
            this.rbiUpdateStruct = new System.Windows.Forms.RibbonButton();
            this.rbiCreatePart = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rbiExportStructToDoc = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.rbiImportStructTest = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rbiCreateOriginalTest = new System.Windows.Forms.RibbonButton();
            this.cbAutoNumberOfTest = new System.Windows.Forms.RibbonCheckBox();
            this.cbOriginalTestNotSame = new System.Windows.Forms.RibbonCheckBox();
            this.upNumberOfTest = new System.Windows.Forms.RibbonUpDown();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbiDeleteOriginalTest = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.bbiViewOriginalTest = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.bbiExportDoc = new System.Windows.Forms.RibbonButton();
            this.bbiExportPdf = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.rbiAccepted = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbiCreateTest = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.rbiCreateAllTest = new System.Windows.Forms.RibbonButton();
            this.cbGenerateFromOriginalTest = new System.Windows.Forms.RibbonCheckBox();
            this.cbGenerateFromBank = new System.Windows.Forms.RibbonCheckBox();
            this.cbRandomQuestion = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.rbiDeleteTest = new System.Windows.Forms.RibbonButton();
            this.rbiDeleteAllTest = new System.Windows.Forms.RibbonButton();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton13 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton14 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.mtcMain = new MetroFramework.Controls.MetroTabControl();
            this.mtpStructure = new MetroFramework.Controls.MetroTabPage();
            this.mtpOriginalTest = new MetroFramework.Controls.MetroTabPage();
            this.mtpTest = new MetroFramework.Controls.MetroTabPage();
            this.pnButton = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.mtcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ribbon
            // 
            this.Ribbon.CaptionBarVisible = false;
            this.Ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ribbon.Location = new System.Drawing.Point(20, 30);
            this.Ribbon.Minimized = false;
            this.Ribbon.Name = "Ribbon";
            // 
            // 
            // 
            this.Ribbon.OrbDropDown.BorderRoundness = 8;
            this.Ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.Ribbon.OrbDropDown.Name = "";
            this.Ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.Ribbon.OrbDropDown.TabIndex = 0;
            this.Ribbon.OrbImage = null;
            this.Ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.Ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.Ribbon.Size = new System.Drawing.Size(1201, 94);
            this.Ribbon.TabIndex = 0;
            this.Ribbon.Tabs.Add(this.ribbonTab1);
            this.Ribbon.Tabs.Add(this.ribbonTab2);
            this.Ribbon.Tabs.Add(this.ribbonTab3);
            this.Ribbon.Tabs.Add(this.ribbonTab4);
            this.Ribbon.Tabs.Add(this.ribbonTab5);
            this.Ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.Ribbon.Text = "ribbon1";
            this.Ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Green;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel0);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanel9);
            this.ribbonTab1.Text = "Cấu Trúc Đề";
            // 
            // ribbonPanel0
            // 
            this.ribbonPanel0.ButtonMoreVisible = false;
            this.ribbonPanel0.Items.Add(this.rbiCreateStruct);
            this.ribbonPanel0.Items.Add(this.rbiUpdateStruct);
            this.ribbonPanel0.Items.Add(this.rbiCreatePart);
            this.ribbonPanel0.Text = "Thêm/Sửa Cấu Trúc";
            // 
            // rbiCreateStruct
            // 
            this.rbiCreateStruct.Image = global::EXON.GenerateTest.Properties.Resources.Add_32x32;
            this.rbiCreateStruct.MinimumSize = new System.Drawing.Size(40, 0);
            this.rbiCreateStruct.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateStruct.SmallImage")));
            this.rbiCreateStruct.Text = "";
            this.rbiCreateStruct.ToolTip = "Nhập Cấu Trúc";
            this.rbiCreateStruct.ToolTipTitle = "Nhập Cấu Trúc";
            // 
            // rbiUpdateStruct
            // 
            this.rbiUpdateStruct.Image = global::EXON.GenerateTest.Properties.Resources.Edit_32x32;
            this.rbiUpdateStruct.MinimumSize = new System.Drawing.Size(40, 0);
            this.rbiUpdateStruct.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiUpdateStruct.SmallImage")));
            this.rbiUpdateStruct.Text = "";
            this.rbiUpdateStruct.ToolTip = "Sửa Cấu Trúc";
            this.rbiUpdateStruct.ToolTipTitle = "Sửa Cấu Trúc";
            // 
            // rbiCreatePart
            // 
            this.rbiCreatePart.Image = global::EXON.GenerateTest.Properties.Resources.Build_32x32;
            this.rbiCreatePart.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreatePart.SmallImage")));
            this.rbiCreatePart.ToolTip = "Thêm Phần Thi";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.rbiExportStructToDoc);
            this.ribbonPanel3.Text = "Xuất Báo Cáo";
            // 
            // rbiExportStructToDoc
            // 
            this.rbiExportStructToDoc.Image = global::EXON.GenerateTest.Properties.Resources.ExportToDOC_32x32;
            this.rbiExportStructToDoc.MinimumSize = new System.Drawing.Size(40, 0);
            this.rbiExportStructToDoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiExportStructToDoc.SmallImage")));
            this.rbiExportStructToDoc.Text = "";
            this.rbiExportStructToDoc.ToolTip = "Xuất Ra Doc";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.ButtonMoreVisible = false;
            this.ribbonPanel9.Items.Add(this.rbiImportStructTest);
            this.ribbonPanel9.Text = "Nhập từ file";
            // 
            // rbiImportStructTest
            // 
            this.rbiImportStructTest.Image = global::EXON.GenerateTest.Properties.Resources.icon_show_product_img_32;
            this.rbiImportStructTest.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiImportStructTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiImportStructTest.SmallImage")));
            this.rbiImportStructTest.Text = "";
            this.rbiImportStructTest.ToolTip = "Nhập Từ Doc";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel4);
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Panels.Add(this.ribbonPanel5);
            this.ribbonTab2.Panels.Add(this.ribbonPanel7);
            this.ribbonTab2.Text = "Sinh Đề Gốc";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.rbiCreateOriginalTest);
            this.ribbonPanel4.Items.Add(this.cbAutoNumberOfTest);
            this.ribbonPanel4.Items.Add(this.cbOriginalTestNotSame);
            this.ribbonPanel4.Items.Add(this.upNumberOfTest);
            this.ribbonPanel4.Text = "Sinh Đề Gốc";
            // 
            // rbiCreateOriginalTest
            // 
            this.rbiCreateOriginalTest.Image = global::EXON.GenerateTest.Properties.Resources.Add_32x32;
            this.rbiCreateOriginalTest.MinimumSize = new System.Drawing.Size(40, 0);
            this.rbiCreateOriginalTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateOriginalTest.SmallImage")));
            this.rbiCreateOriginalTest.Text = "";
            this.rbiCreateOriginalTest.ToolTip = "Sinh Đề Thi Gốc";
            // 
            // cbAutoNumberOfTest
            // 
            this.cbAutoNumberOfTest.Text = "Tự Động Tính Số Đề";
            this.cbAutoNumberOfTest.CheckBoxCheckChanged += new System.EventHandler(this.cbAutoNumberOfTest_CheckBoxCheckChanged);
            // 
            // cbOriginalTestNotSame
            // 
            this.cbOriginalTestNotSame.Checked = true;
            this.cbOriginalTestNotSame.Text = "Đề Gốc Không Trùng Nhau";
            this.cbOriginalTestNotSame.CheckBoxCheckChanged += new System.EventHandler(this.cbOriginalTestNotSame_CheckBoxCheckChanged);
            // 
            // upNumberOfTest
            // 
            this.upNumberOfTest.Text = "Số Đề Thi";
            this.upNumberOfTest.TextBoxText = "1";
            this.upNumberOfTest.TextBoxWidth = 50;
            this.upNumberOfTest.Value = "1";
            this.upNumberOfTest.TextBoxTextChanged += new System.EventHandler(this.upNumberOfTest_TextBoxTextChanged);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.rbiDeleteOriginalTest);
            this.ribbonPanel2.Text = "Xóa Đề thi";
            // 
            // rbiDeleteOriginalTest
            // 
            this.rbiDeleteOriginalTest.Image = global::EXON.GenerateTest.Properties.Resources.Delete_32x32;
            this.rbiDeleteOriginalTest.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiDeleteOriginalTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiDeleteOriginalTest.SmallImage")));
            this.rbiDeleteOriginalTest.Text = "";
            this.rbiDeleteOriginalTest.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rbiDeleteOriginalTest.ToolTip = "Xóa Đề Thi";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.bbiViewOriginalTest);
            this.ribbonPanel5.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel5.Items.Add(this.bbiExportDoc);
            this.ribbonPanel5.Items.Add(this.bbiExportPdf);
            this.ribbonPanel5.Text = "Xem/Export Đề Thi";
            // 
            // bbiViewOriginalTest
            // 
            this.bbiViewOriginalTest.Image = global::EXON.GenerateTest.Properties.Resources.icon_show_product_img_32;
            this.bbiViewOriginalTest.MinimumSize = new System.Drawing.Size(40, 0);
            this.bbiViewOriginalTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("bbiViewOriginalTest.SmallImage")));
            this.bbiViewOriginalTest.Text = "";
            this.bbiViewOriginalTest.ToolTip = "Xem Đề Thi";
            // 
            // bbiExportDoc
            // 
            this.bbiExportDoc.Image = global::EXON.GenerateTest.Properties.Resources.ExportToDOC_32x32;
            this.bbiExportDoc.MinimumSize = new System.Drawing.Size(40, 0);
            this.bbiExportDoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("bbiExportDoc.SmallImage")));
            this.bbiExportDoc.Text = "";
            this.bbiExportDoc.ToolTip = "Xuất Ra Doc";
            // 
            // bbiExportPdf
            // 
            this.bbiExportPdf.Image = global::EXON.GenerateTest.Properties.Resources.ExportToPDF_32x32;
            this.bbiExportPdf.MinimumSize = new System.Drawing.Size(40, 0);
            this.bbiExportPdf.SmallImage = ((System.Drawing.Image)(resources.GetObject("bbiExportPdf.SmallImage")));
            this.bbiExportPdf.Text = "";
            this.bbiExportPdf.ToolTip = "Xuất Ra Pdf";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.ButtonMoreVisible = false;
            this.ribbonPanel7.Items.Add(this.rbiAccepted);
            this.ribbonPanel7.Text = "Phê Duyệt Đề";
            // 
            // rbiAccepted
            // 
            this.rbiAccepted.Image = global::EXON.GenerateTest.Properties.Resources.Task_32x32;
            this.rbiAccepted.MinimumSize = new System.Drawing.Size(40, 0);
            this.rbiAccepted.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiAccepted.SmallImage")));
            this.rbiAccepted.Text = "";
            this.rbiAccepted.ToolTip = "Phê Duyệt Đề Thi";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel1);
            this.ribbonTab3.Panels.Add(this.ribbonPanel8);
            this.ribbonTab3.Text = "Sinh Đề Thi";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.rbiCreateTest);
            this.ribbonPanel1.Items.Add(this.rbiCreateAllTest);
            this.ribbonPanel1.Items.Add(this.cbGenerateFromOriginalTest);
            this.ribbonPanel1.Items.Add(this.cbGenerateFromBank);
            this.ribbonPanel1.Items.Add(this.cbRandomQuestion);
            this.ribbonPanel1.Text = "Sinh Đề";
            // 
            // rbiCreateTest
            // 
            this.rbiCreateTest.DropDownItems.Add(this.ribbonButton1);
            this.rbiCreateTest.DropDownItems.Add(this.ribbonButton6);
            this.rbiCreateTest.Image = global::EXON.GenerateTest.Properties.Resources.Add_32x32;
            this.rbiCreateTest.MinimumSize = new System.Drawing.Size(40, 0);
            this.rbiCreateTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateTest.SmallImage")));
            this.rbiCreateTest.Text = "";
            this.rbiCreateTest.ToolTip = "Sinh Đề Thi";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "ribbonButton6";
            // 
            // rbiCreateAllTest
            // 
            this.rbiCreateAllTest.Image = global::EXON.GenerateTest.Properties.Resources.Code_Central;
            this.rbiCreateAllTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateAllTest.SmallImage")));
            this.rbiCreateAllTest.ToolTip = "Sinh tất cả đề thi";
            // 
            // cbGenerateFromOriginalTest
            // 
            this.cbGenerateFromOriginalTest.Checked = true;
            this.cbGenerateFromOriginalTest.Text = "Sinh Đề Từ Đề Thi Gốc";
            this.cbGenerateFromOriginalTest.CheckBoxCheckChanged += new System.EventHandler(this.cbGenerateFromOriginalTest_CheckBoxCheckChanged);
            // 
            // cbGenerateFromBank
            // 
            this.cbGenerateFromBank.Text = "Sinh Đề  Trực Tiếp Từ NH";
            this.cbGenerateFromBank.CheckBoxCheckChanged += new System.EventHandler(this.cbGenerateFromBank_CheckBoxCheckChanged);
            // 
            // cbRandomQuestion
            // 
            this.cbRandomQuestion.Checked = true;
            this.cbRandomQuestion.Text = "Đảo Câu Hỏi";
            this.cbRandomQuestion.CheckBoxCheckChanged += new System.EventHandler(this.cbRandomQuestion_CheckBoxCheckChanged);
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.ButtonMoreVisible = false;
            this.ribbonPanel8.Items.Add(this.rbiDeleteTest);
            this.ribbonPanel8.Items.Add(this.rbiDeleteAllTest);
            this.ribbonPanel8.Text = "Xóa Đề Thi";
            // 
            // rbiDeleteTest
            // 
            this.rbiDeleteTest.Image = global::EXON.GenerateTest.Properties.Resources.Delete_32x32;
            this.rbiDeleteTest.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiDeleteTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiDeleteTest.SmallImage")));
            this.rbiDeleteTest.Text = "";
            this.rbiDeleteTest.ToolTip = "Xóa Đề Thi";
            // 
            // rbiDeleteAllTest
            // 
            this.rbiDeleteAllTest.Image = global::EXON.GenerateTest.Properties.Resources.icon_show_product_img_32;
            this.rbiDeleteAllTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiDeleteAllTest.SmallImage")));
            this.rbiDeleteAllTest.ToolTip = "Xóa tất cả đề thi";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Text = "Cài Đặt";
            this.ribbonTab4.Visible = false;
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Panels.Add(this.ribbonPanel6);
            this.ribbonTab5.Text = "Hỗ Trợ";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.ribbonButton13);
            this.ribbonPanel6.Items.Add(this.ribbonButton14);
            this.ribbonPanel6.Text = "Hướng dẫn";
            // 
            // ribbonButton13
            // 
            this.ribbonButton13.Image = global::EXON.GenerateTest.Properties.Resources.Index_32x32;
            this.ribbonButton13.MinimumSize = new System.Drawing.Size(40, 0);
            this.ribbonButton13.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton13.SmallImage")));
            this.ribbonButton13.Text = "";
            this.ribbonButton13.ToolTip = "Hướng Dẫn";
            // 
            // ribbonButton14
            // 
            this.ribbonButton14.Image = global::EXON.GenerateTest.Properties.Resources.Build_32x32;
            this.ribbonButton14.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton14.SmallImage")));
            this.ribbonButton14.Text = "";
            this.ribbonButton14.ToolTip = "Thông Tin";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::EXON.GenerateTest.Properties.Resources.icon_panel_right_32;
            this.ribbonButton3.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Nhập Cấu Trúc";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = global::EXON.GenerateTest.Properties.Resources.Edit_32x32;
            this.ribbonButton4.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Sửa Cấu Trúc";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = global::EXON.GenerateTest.Properties.Resources.icon_show_product_img_32;
            this.ribbonButton5.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "Xem Đề Thi";
            // 
            // mtcMain
            // 
            this.mtcMain.Controls.Add(this.mtpStructure);
            this.mtcMain.Controls.Add(this.mtpOriginalTest);
            this.mtcMain.Controls.Add(this.mtpTest);
            this.mtcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mtcMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mtcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.mtcMain.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.mtcMain.ItemSize = new System.Drawing.Size(50, 40);
            this.mtcMain.Location = new System.Drawing.Point(20, 706);
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.RightToLeftLayout = true;
            this.mtcMain.SelectedIndex = 2;
            this.mtcMain.ShowToolTips = true;
            this.mtcMain.Size = new System.Drawing.Size(1201, 46);
            this.mtcMain.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtcMain.TabIndex = 5;
            this.mtcMain.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtcMain.UseSelectable = true;
            this.mtcMain.UseStyleColors = true;
            this.mtcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.mtcMain_Selected);
            // 
            // mtpStructure
            // 
            this.mtpStructure.HorizontalScrollbarBarColor = true;
            this.mtpStructure.HorizontalScrollbarHighlightOnWheel = true;
            this.mtpStructure.HorizontalScrollbarSize = 10;
            this.mtpStructure.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.mtpStructure.Location = new System.Drawing.Point(4, 44);
            this.mtpStructure.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.mtpStructure.Name = "mtpStructure";
            this.mtpStructure.Size = new System.Drawing.Size(1193, -2);
            this.mtpStructure.Style = MetroFramework.MetroColorStyle.Green;
            this.mtpStructure.TabIndex = 0;
            this.mtpStructure.Text = "Module Cấu Trúc Đề";
            this.mtpStructure.ToolTipText = "Module Cấu trúc đề";
            this.mtpStructure.VerticalScrollbarBarColor = true;
            this.mtpStructure.VerticalScrollbarHighlightOnWheel = false;
            this.mtpStructure.VerticalScrollbarSize = 10;
            // 
            // mtpOriginalTest
            // 
            this.mtpOriginalTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtpOriginalTest.HorizontalScrollbarBarColor = true;
            this.mtpOriginalTest.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpOriginalTest.HorizontalScrollbarSize = 10;
            this.mtpOriginalTest.Location = new System.Drawing.Point(4, 44);
            this.mtpOriginalTest.Name = "mtpOriginalTest";
            this.mtpOriginalTest.Size = new System.Drawing.Size(1193, -2);
            this.mtpOriginalTest.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtpOriginalTest.TabIndex = 2;
            this.mtpOriginalTest.Text = "Module Sinh Đề Thi Gốc";
            this.mtpOriginalTest.VerticalScrollbarBarColor = true;
            this.mtpOriginalTest.VerticalScrollbarHighlightOnWheel = false;
            this.mtpOriginalTest.VerticalScrollbarSize = 10;
            // 
            // mtpTest
            // 
            this.mtpTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtpTest.HorizontalScrollbarBarColor = true;
            this.mtpTest.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpTest.HorizontalScrollbarSize = 10;
            this.mtpTest.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.mtpTest.Location = new System.Drawing.Point(4, 44);
            this.mtpTest.Name = "mtpTest";
            this.mtpTest.Size = new System.Drawing.Size(1193, 0);
            this.mtpTest.TabIndex = 3;
            this.mtpTest.Text = "Module Sinh Đề Thi";
            this.mtpTest.VerticalScrollbarBarColor = true;
            this.mtpTest.VerticalScrollbarHighlightOnWheel = false;
            this.mtpTest.VerticalScrollbarSize = 10;
            // 
            // pnButton
            // 
            this.pnButton.AutoScroll = true;
            this.pnButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnButton.Location = new System.Drawing.Point(20, 124);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(200, 582);
            this.pnButton.TabIndex = 6;
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(220, 124);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1001, 582);
            this.pnMain.TabIndex = 7;
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = global::EXON.GenerateTest.Properties.Resources.Code_Central;
            this.ribbonButton7.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "Sinh Đề Gốc";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbTitle.Location = new System.Drawing.Point(16, 8);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(38, 19);
            this.lbTitle.TabIndex = 11;
            this.lbTitle.Text = "Tilte";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 772);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.mtcMain);
            this.Controls.Add(this.Ribbon);
            this.DisplayHeader = false;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "Hệ Thống Sinh Đề Thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mtcMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbiCreateTest;
        private System.Windows.Forms.RibbonButton rbiDeleteOriginalTest;
        private System.Windows.Forms.RibbonPanel ribbonPanel0;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton rbiCreateStruct;
        private System.Windows.Forms.RibbonButton rbiUpdateStruct;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton bbiViewOriginalTest;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton bbiExportDoc;
        private System.Windows.Forms.RibbonButton bbiExportPdf;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbonButton13;
        private System.Windows.Forms.RibbonButton ribbonButton14;
        private System.Windows.Forms.RibbonCheckBox cbGenerateFromOriginalTest;
        private System.Windows.Forms.RibbonCheckBox cbGenerateFromBank;
        public System.Windows.Forms.Ribbon Ribbon;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbiExportStructToDoc;
        private MetroFramework.Controls.MetroTabControl mtcMain;
        private MetroFramework.Controls.MetroTabPage mtpStructure;
        private MetroFramework.Controls.MetroTabPage mtpOriginalTest;
        private MetroFramework.Controls.MetroTabPage mtpTest;
        private System.Windows.Forms.Panel pnButton;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton rbiCreateOriginalTest;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton rbiAccepted;
        private System.Windows.Forms.RibbonUpDown upNumberOfTest;
        private System.Windows.Forms.RibbonCheckBox cbAutoNumberOfTest;
        private System.Windows.Forms.RibbonCheckBox cbOriginalTestNotSame;
        private System.Windows.Forms.RibbonCheckBox cbRandomQuestion;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonButton rbiDeleteTest;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonButton rbiImportStructTest;
        internal System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.RibbonButton rbiCreatePart;
        private System.Windows.Forms.RibbonButton rbiCreateAllTest;
        private System.Windows.Forms.RibbonButton rbiDeleteAllTest;
    }
}