using System;
using System.Windows.Forms;

namespace EXON.Common
{
    public class TRichText4Display : TRichTextBase
    {
        public TRichText4Display() : base()
        {
            this.BackColor = System.Drawing.Color.White;
        }

        protected override void AfterInit()
        {
            previousHeight = currentHeight = this.Height;
            this.Resize += TRichTextBase_Resize;
            this.ReadOnly = true;
        }

        private void TRichTextBase_Resize(object sender, EventArgs e)
        {
            if (this.Parent == null) return;
            previousHeight = currentHeight;
            currentHeight = this.Height;

            if (this.Parent.GetType() == typeof(GroupBox))
            {
                GroupBox group = (this.Parent as GroupBox);
                if (group != null)
                {
                    group.Height += currentHeight - previousHeight;
                }
                return;
            }

            UserControl parent = (this.Parent.Parent as UserControl);
            if (parent != null)
            {
                parent.Height += currentHeight - previousHeight;
            }
            else
            {
                this.Parent.Height = currentHeight;
                parent = (this.Parent.Parent.Parent.Parent as UserControl);
                if (parent != null)
                {
                    parent.Height += currentHeight - previousHeight;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                Panel pnMain = GetRoot("pnQuestion") as Panel;
                if (pnMain != null && pnMain.VerticalScroll.Visible)
                {
                    SendMessage(pnMain.Handle, m.Msg, (Int32)m.WParam, ref lastScroll);
                }
            }
        }
    }
}