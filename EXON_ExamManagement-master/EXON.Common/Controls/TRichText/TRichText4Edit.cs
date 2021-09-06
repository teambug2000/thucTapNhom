using System;
using System.Drawing;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.Common
{
    public class TRichText4Edit : TRichTextBase
    {
        public TRichText4Edit() : base()
        {
            this.ContentsResized += rtb_ContentsResized;
        }

        protected override void AfterInit()
        {
            FormatContent();

            this.Focus();
            this.SelectionStart = this.Text.Length;
        }

        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((TRichText4Edit)sender).Height = e.NewRectangle.Height;
        }

        public int CurrentHeight
        {
            get
            {
                //Log.Instance.WriteLog(LogType.INFO, $"get height richtextbox {this.Height}");

                // text chỉ có ảnh
                if (string.IsNullOrEmpty(this.Text.Trim().Replace("\n", string.Empty)) && this.Height < 120) return 120;

                // quá nhỏ, ví dụ như chỉ có số;
                if (this.Height < 50) return 70;

                // kích thước thông thường
                if (this.Height < 1500) return this.Height;              

                // quá lớn
                return 1000;
            }
        }

        public void FormatContent()
        {
            //this.SelectAll();
            //SelectionFontName = "Times New Roman";
            //SelectionFontSize = 12;
            //SelectionTextColor = Color.Black;
            //this.DeselectAll();
        }
    }
}