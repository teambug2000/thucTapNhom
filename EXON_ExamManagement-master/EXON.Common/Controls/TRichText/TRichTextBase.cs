using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.Common
{
    public class TRichTextBase : RichTextBox
    {
        protected int previousHeight { get; set; }
        protected int currentHeight { get; set; }

        public TRichTextBase()
        {
            this.BorderStyle = BorderStyle.None;
            this.Font = new Font("Times New Roman", 14);
        }
        public virtual void InitControl(string Rtf, int Height = 0, bool isRtf = true)
        {
            if (isRtf) this.Rtf = Rtf;
            else this.Text = Rtf;
            this.Height = Height != 0 ? Height : this.Height;

            AfterInit();
        }

        protected virtual void AfterInit() { }

        protected Control GetRoot(string name)
        {
            Control root = this;
            Control parent = this.Parent;
            while (parent != null)
            {
                root = parent;
                parent = parent.Parent;
            }
            Control[] listChild = root.Controls.Find(name, true);
            if (listChild != null && listChild.Length > 0) return listChild[0];
            else return null;
        }

        private static IntPtr moduleHandle = IntPtr.Zero;
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);

        private bool frozen = false;
        protected Point lastScroll = Point.Empty;
        protected IntPtr lastEvent = IntPtr.Zero;
        private int lastIndex = 0;
        private int lastWidth = 0;

        //scroll
        protected const int WM_HSCROLL = 0x114;
        protected const int WM_VSCROLL = 0x115;
        protected const int WM_MOUSEWHEEL = 0x20A;

        private const int WM_PAINT = 0xF;
        private const int WM_SETREDRAW = 0xB;
        private const int WM_USER = 0x400;

        private const int EM_SETCHARFORMAT = (WM_USER + 68);
        private const int SCF_SELECTION = 0x0001;
        private const int EM_GETEVENTMASK = WM_USER + 59;
        private const int EM_SETEVENTMASK = WM_USER + 69;
        private const int EM_GETSCROLLPOS = WM_USER + 221;
        private const int EM_SETSCROLLPOS = WM_USER + 222;

        private const UInt32 CFE_BOLD = 0x0001;
        private const UInt32 CFE_ITALIC = 0x0002;
        private const UInt32 CFE_UNDERLINE = 0x0004;
        private const UInt32 CFE_STRIKEOUT = 0x0008;
        private const UInt32 CFE_PROTECTED = 0x0010;
        private const UInt32 CFE_LINK = 0x0020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;
        private const UInt32 CFE_SUBSCRIPT = 0x00010000;        /* Superscript and subscript are */
        private const UInt32 CFE_SUPERSCRIPT = 0x00020000;      /*  mutually exclusive			 */

        private const int CFM_SMALLCAPS = 0x0040;               /* (*)	*/
        private const int CFM_ALLCAPS = 0x0080;                 /* Displayed by 3.0	*/
        private const int CFM_HIDDEN = 0x0100;                  /* Hidden by 3.0 */
        private const int CFM_OUTLINE = 0x0200;                 /* (*)	*/
        private const int CFM_SHADOW = 0x0400;                  /* (*)	*/
        private const int CFM_EMBOSS = 0x0800;                  /* (*)	*/
        private const int CFM_IMPRINT = 0x1000;                 /* (*)	*/
        private const int CFM_DISABLED = 0x2000;
        private const int CFM_REVISED = 0x4000;

        private const int CFM_BACKCOLOR = 0x04000000;
        private const int CFM_LCID = 0x02000000;
        private const int CFM_UNDERLINETYPE = 0x00800000;       /* Many displayed by 3.0 */
        private const int CFM_WEIGHT = 0x00400000;
        private const int CFM_SPACING = 0x00200000;             /* Displayed by 3.0	*/
        private const int CFM_KERNING = 0x00100000;             /* (*)	*/
        private const int CFM_STYLE = 0x00080000;               /* (*)	*/
        private const int CFM_ANIMATION = 0x00040000;           /* (*)	*/
        private const int CFM_REVAUTHOR = 0x00008000;

        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_CHARSET = 0x08000000;
        private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;

        private const byte CFU_UNDERLINENONE = 0x00000000;
        private const byte CFU_UNDERLINE = 0x00000001;
        private const byte CFU_UNDERLINEWORD = 0x00000002;      /* (*) displayed as ordinary underline	*/
        private const byte CFU_UNDERLINEDOUBLE = 0x00000003;    /* (*) displayed as ordinary underline	*/
        private const byte CFU_UNDERLINEDOTTED = 0x00000004;
        private const byte CFU_UNDERLINEDASH = 0x00000005;
        private const byte CFU_UNDERLINEDASHDOT = 0x00000006;
        private const byte CFU_UNDERLINEDASHDOTDOT = 0x00000007;
        private const byte CFU_UNDERLINEWAVE = 0x00000008;
        private const byte CFU_UNDERLINETHICK = 0x00000009;
        private const byte CFU_UNDERLINEHAIRLINE = 0x0000000A;  /* (*) displayed as ordinary underline	*/

        [StructLayout(LayoutKind.Sequential)]
        protected struct CHARFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public uint dwEffects;
            public int yHeight;
            public int yOffset;
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public short wWeight;
            public short sSpacing;
            public int crBackColor;
            public int LCID;
            public uint dwReserved;
            public short sStyle;
            public short wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
        }

        [DllImport("user32", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref CHARFORMAT lParam);

        [DllImport("user32.dll")]
        protected static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);

        [DllImport("user32.dll")]
        protected static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);

        protected override CreateParams CreateParams
        {
            get
            {
                if (moduleHandle == IntPtr.Zero)
                {
                    string path = System.IO.Path.Combine(Application.StartupPath, @".\Libs\RICHED20.DLL");
                    moduleHandle = LoadLibrary(path);
                    if ((long)moduleHandle < 0x20)
                    {
                        moduleHandle = Handle;
                        Log.Instance.WriteErrorLog(LogType.FATAL, "RICHED20.DLL is missing!");
                    }
                }
                CreateParams createParams = base.CreateParams;
                createParams.ClassName = "RichEdit20W";
                if (this.Multiline)
                {
                    if (((this.ScrollBars & RichTextBoxScrollBars.Horizontal) != RichTextBoxScrollBars.None) && !base.WordWrap)
                    {
                        createParams.Style |= 0x100000;
                        if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None)
                        {
                            createParams.Style |= 0x2000;
                        }
                    }
                    if ((this.ScrollBars & RichTextBoxScrollBars.Vertical) != RichTextBoxScrollBars.None)
                    {
                        createParams.Style |= 0x200000;
                        if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None)
                        {
                            createParams.Style |= 0x2000;
                        }
                    }
                }
                if ((BorderStyle.FixedSingle == base.BorderStyle) && ((createParams.Style & 0x800000) != 0))
                {
                    createParams.Style &= -8388609;
                    createParams.ExStyle |= 0x200;
                }
                return createParams;
            }
        }

        [Browsable(false)]
        [DefaultValue(typeof(bool), "False")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool FreezeDrawing
        {
            get { return frozen; }
            set
            {
                if (value != frozen)
                {
                    frozen = value;
                    if (frozen)
                    {
                        this.SuspendLayout();
                        SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                        SendMessage(this.Handle, EM_GETSCROLLPOS, 0, ref lastScroll);
                        lastEvent = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
                        lastIndex = this.SelectionStart;
                        lastWidth = this.SelectionLength;
                    }
                    else
                    {
                        this.Select(lastIndex, lastWidth);
                        SendMessage(this.Handle, EM_SETEVENTMASK, 0, lastEvent);
                        SendMessage(this.Handle, EM_SETSCROLLPOS, 0, ref lastScroll);
                        SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                        this.Invalidate();
                        this.ResumeLayout();
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected Font CurrentFont
        {
            get
            {
                Font result = this.Font;
                if (this.SelectionLength == 0)
                {
                    result = SelectionFont;
                }
                else
                {
                    using (TRichText4Edit rb = new TRichText4Edit())
                    {
                        rb.FreezeDrawing = true;
                        rb.SelectAll();
                        rb.SelectedRtf = this.SelectedRtf;
                        rb.Select(0, 1);
                        result = rb.SelectionFont;
                    }
                }
                return result;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string SelectionFontName
        {
            get { return CurrentFont.FontFamily.Name; }
            set
            {
                CHARFORMAT cf = new CHARFORMAT();
                cf.cbSize = Marshal.SizeOf(cf);
                cf.szFaceName = new char[32];
                cf.dwMask = CFM_FACE;
                value.CopyTo(0, cf.szFaceName, 0, Math.Min(31, value.Length));
                IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
                Marshal.StructureToPtr(cf, lParam, false);
                SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected float SelectionFontSize
        {
            get { return CurrentFont.Size; }
            set
            {
                CHARFORMAT cf = new CHARFORMAT();
                cf.cbSize = Marshal.SizeOf(cf);
                cf.dwMask = CFM_SIZE;
                cf.yHeight = Convert.ToInt32(value * 20);
                IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
                Marshal.StructureToPtr(cf, lParam, false);
                SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected Color SelectionTextColor
        {
            set
            {
                CHARFORMAT cf = new CHARFORMAT();
                cf.cbSize = Marshal.SizeOf(cf);
                cf.crTextColor = ColorTranslator.ToWin32(value);
                cf.dwMask = CFM_COLOR;
                IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
                Marshal.StructureToPtr(cf, lParam, false);
                SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            }
        }
    }
}