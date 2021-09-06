using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class CustomeRichTextbox : RichTextBox
    {
        public CustomeRichTextbox(bool isHaveBorder = false)
        {
            this.BackColor = System.Drawing.Color.White;
            this.WordWrap = true;
            this.BorderStyle = isHaveBorder ? BorderStyle.FixedSingle : BorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(700, 80);
            this.ReadOnly = false;

         //   this.ContentsResized += rtb_ContentsResized;
           // if (!isHaveBorder) this.TextChanged += rtb_TextChanged;
        }

        //public void HighLightText()
        //{
        //    this.SelectAll();
        //    this.SelectionHighLight = true;
        //    this.DeselectAll();
        //}
        //internal void BoldText()
        //{
        //    this.SelectAll();
        //    this.SelectionBold = true;
        //    this.DeselectAll();
        //}

        //private void rtb_TextChanged(object sender, EventArgs e)
        //{
        //    this.SelectAll();
        //    SelectionFontName = Properties.Resources.Font;
        //    SelectionFontSize = float.Parse(Properties.Resources.FontSize);
        //    this.DeselectAll();
        //}

        //private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        //{
        //    ((RichTextBox)sender).Height = e.NewRectangle.Height + 10;
        //    ((RichTextBox)sender).Width = e.NewRectangle.Width;
        //}
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        if (moduleHandle == IntPtr.Zero)
        //        {
        //            string path = System.IO.Path.Combine(Application.StartupPath, @"Libs\RICHED20.DLL");
        //            moduleHandle = LoadLibrary(path);
        //            if ((long)moduleHandle < 0x20) throw new Win32Exception(Marshal.GetLastWin32Error(), "RichEdit control appears to be missing");
        //        }
        //        CreateParams createParams = base.CreateParams;
        //        createParams.ClassName = "RichEdit20W";
        //        if (this.Multiline)
        //        {
        //            if (((this.ScrollBars & RichTextBoxScrollBars.Horizontal) != RichTextBoxScrollBars.None) && !base.WordWrap)
        //            {
        //                createParams.Style |= 0x100000;
        //                if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None)
        //                {
        //                    createParams.Style |= 0x2000;
        //                }
        //            }
        //            if ((this.ScrollBars & RichTextBoxScrollBars.Vertical) != RichTextBoxScrollBars.None)
        //            {
        //                createParams.Style |= 0x200000;
        //                if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None)
        //                {
        //                    createParams.Style |= 0x2000;
        //                }
        //            }
        //        }
        //        if ((BorderStyle.FixedSingle == base.BorderStyle) && ((createParams.Style & 0x800000) != 0))
        //        {
        //            createParams.Style &= -8388609;
        //            createParams.ExStyle |= 0x200;
        //        }
        //        return createParams;
        //    }
        //}

        //private static IntPtr moduleHandle;

        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //static extern IntPtr LoadLibrary(string lpFileName);

        ////Font
        //#region params

        //private const int WM_PAINT = 0xF;
        //private const int WM_SETREDRAW = 0xB;
        //private const int WM_USER = 0x400;

        //private const int EM_SETCHARFORMAT = (WM_USER + 68);
        //private const int SCF_SELECTION = 0x0001;
        //private const int EM_GETEVENTMASK = WM_USER + 59;
        //private const int EM_SETEVENTMASK = WM_USER + 69;
        //private const int EM_GETSCROLLPOS = WM_USER + 221;
        //private const int EM_SETSCROLLPOS = WM_USER + 222;

        //private const UInt32 CFE_BOLD = 0x0001;
        //private const UInt32 CFE_ITALIC = 0x0002;
        //private const UInt32 CFE_UNDERLINE = 0x0004;
        //private const UInt32 CFE_STRIKEOUT = 0x0008;
        //private const UInt32 CFE_PROTECTED = 0x0010;
        //private const UInt32 CFE_LINK = 0x0020;
        //private const UInt32 CFE_AUTOCOLOR = 0x40000000;
        //private const UInt32 CFE_SUBSCRIPT = 0x00010000;        /* Superscript and subscript are */
        //private const UInt32 CFE_SUPERSCRIPT = 0x00020000;      /*  mutually exclusive			 */

        //private const int CFM_SMALLCAPS = 0x0040;           /* (*)	*/
        //private const int CFM_ALLCAPS = 0x0080;         /* Displayed by 3.0	*/
        //private const int CFM_HIDDEN = 0x0100;          /* Hidden by 3.0 */
        //private const int CFM_OUTLINE = 0x0200;         /* (*)	*/
        //private const int CFM_SHADOW = 0x0400;          /* (*)	*/
        //private const int CFM_EMBOSS = 0x0800;          /* (*)	*/
        //private const int CFM_IMPRINT = 0x1000;         /* (*)	*/
        //private const int CFM_DISABLED = 0x2000;
        //private const int CFM_REVISED = 0x4000;

        //private const int CFM_BACKCOLOR = 0x04000000;
        //private const int CFM_LCID = 0x02000000;
        //private const int CFM_UNDERLINETYPE = 0x00800000;       /* Many displayed by 3.0 */
        //private const int CFM_WEIGHT = 0x00400000;
        //private const int CFM_SPACING = 0x00200000;         /* Displayed by 3.0	*/
        //private const int CFM_KERNING = 0x00100000;         /* (*)	*/
        //private const int CFM_STYLE = 0x00080000;           /* (*)	*/
        //private const int CFM_ANIMATION = 0x00040000;       /* (*)	*/
        //private const int CFM_REVAUTHOR = 0x00008000;


        //private const UInt32 CFM_BOLD = 0x00000001;
        //private const UInt32 CFM_ITALIC = 0x00000002;
        //private const UInt32 CFM_UNDERLINE = 0x00000004;
        //private const UInt32 CFM_STRIKEOUT = 0x00000008;
        //private const UInt32 CFM_PROTECTED = 0x00000010;
        //private const UInt32 CFM_LINK = 0x00000020;
        //private const UInt32 CFM_SIZE = 0x80000000;
        //private const UInt32 CFM_COLOR = 0x40000000;
        //private const UInt32 CFM_FACE = 0x20000000;
        //private const UInt32 CFM_OFFSET = 0x10000000;
        //private const UInt32 CFM_CHARSET = 0x08000000;
        //private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        //private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;

        

        //private const byte CFU_UNDERLINENONE = 0x00000000;
        //private const byte CFU_UNDERLINE = 0x00000001;
        //private const byte CFU_UNDERLINEWORD = 0x00000002; /* (*) displayed as ordinary underline	*/
        //private const byte CFU_UNDERLINEDOUBLE = 0x00000003; /* (*) displayed as ordinary underline	*/
        //private const byte CFU_UNDERLINEDOTTED = 0x00000004;
        //private const byte CFU_UNDERLINEDASH = 0x00000005;
        //private const byte CFU_UNDERLINEDASHDOT = 0x00000006;
        //private const byte CFU_UNDERLINEDASHDOTDOT = 0x00000007;
        //private const byte CFU_UNDERLINEWAVE = 0x00000008;
        //private const byte CFU_UNDERLINETHICK = 0x00000009;
        //private const byte CFU_UNDERLINEHAIRLINE = 0x0000000A; /* (*) displayed as ordinary underline	*/

        //#endregion

        //[StructLayout(LayoutKind.Sequential)]
        //private struct CHARFORMAT
        //{
        //    public int cbSize;
        //    public uint dwMask;
        //    public uint dwEffects;
        //    public int yHeight;
        //    public int yOffset;
        //    public int crTextColor;
        //    public byte bCharSet;
        //    public byte bPitchAndFamily;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        //    public char[] szFaceName;
        //    public short wWeight;
        //    public short sSpacing;
        //    public int crBackColor;
        //    public int LCID;
        //    public uint dwReserved;
        //    public short sStyle;
        //    public short wKerning;
        //    public byte bUnderlineType;
        //    public byte bAnimation;
        //    public byte bRevAuthor;
        //}

        //[DllImport("user32", CharSet = CharSet.Auto)]
        //private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref CHARFORMAT lParam);

        //[DllImport("user32.dll")]
        //private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);

        //[DllImport("user32.dll")]
        //private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);

        //private bool frozen = false;
        //private Point lastScroll = Point.Empty;
        //private IntPtr lastEvent = IntPtr.Zero;
        //private int lastIndex = 0;
        //private int lastWidth = 0;
        //[Browsable(false)]
        //[DefaultValue(typeof(bool), "False")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public bool FreezeDrawing
        //{
        //    get { return frozen; }
        //    set
        //    {
        //        if (value != frozen)
        //        {
        //            frozen = value;
        //            if (frozen)
        //            {
        //                this.SuspendLayout();
        //                SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
        //                SendMessage(this.Handle, EM_GETSCROLLPOS, 0, ref lastScroll);
        //                lastEvent = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
        //                lastIndex = this.SelectionStart;
        //                lastWidth = this.SelectionLength;
        //            }
        //            else
        //            {
        //                this.Select(lastIndex, lastWidth);
        //                SendMessage(this.Handle, EM_SETEVENTMASK, 0, lastEvent);
        //                SendMessage(this.Handle, EM_SETSCROLLPOS, 0, ref lastScroll);
        //                SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
        //                this.Invalidate();
        //                this.ResumeLayout();
        //            }
        //        }
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public Font CurrentFont
        //{
        //    get
        //    {
        //        Font result = this.Font;
        //        if (this.SelectionLength == 0)
        //        {
        //            result = SelectionFont;
        //        }
        //        else
        //        {
        //            using (CustomeRichTextbox rb = new CustomeRichTextbox())
        //            {
        //                rb.FreezeDrawing = true;
        //                rb.SelectAll();
        //                rb.SelectedRtf = this.SelectedRtf;
        //                rb.Select(0, 1);
        //                result = rb.SelectionFont;
        //            }
        //        }
        //        return result;
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string SelectionFontName
        //{
        //    get { return CurrentFont.FontFamily.Name; }
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.szFaceName = new char[32];
        //        cf.dwMask = CFM_FACE;
        //        value.CopyTo(0, cf.szFaceName, 0, Math.Min(31, value.Length));
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public float SelectionFontSize
        //{
        //    get { return CurrentFont.Size; }
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.dwMask = CFM_SIZE;
        //        cf.yHeight = Convert.ToInt32(value * 20);
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public bool SelectionBold
        //{
        //    get { return CurrentFont.Bold; }
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.dwMask = CFM_BOLD;
        //        cf.dwEffects = value ? CFM_BOLD : 0;
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public bool SelectionItalic
        //{
        //    get { return CurrentFont.Italic; }
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.dwMask = CFM_ITALIC;
        //        cf.dwEffects = value ? CFM_ITALIC : 0;
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public bool SelectionStrikeout
        //{
        //    get { return CurrentFont.Strikeout; }
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.dwMask = CFM_STRIKEOUT;
        //        cf.dwEffects = value ? CFM_STRIKEOUT : 0;
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public bool SelectionUnderline
        //{
        //    get { return CurrentFont.Underline; }
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.dwMask = CFM_UNDERLINE;
        //        cf.dwEffects = value ? CFM_UNDERLINE : 0;
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public bool SelectionHighLight
        //{
        //    set
        //    {
        //        CHARFORMAT cf = new CHARFORMAT();
        //        cf.cbSize = Marshal.SizeOf(cf);
        //        cf.crTextColor = ColorTranslator.ToWin32(Color.Red);
        //        cf.dwMask = CFM_BOLD | CFM_COLOR;
        //        cf.dwEffects = value ? CFM_BOLD : 0;
        //        IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
        //        Marshal.StructureToPtr(cf, lParam, false);
        //        SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        //    }
        //}
    }
}