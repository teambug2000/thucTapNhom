using MetroFramework.Forms;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace EXON.Common
{
    public partial class SplashScreen : MetroForm
    {
        #region Member Variables

        // Threading
        private static SplashScreen ms_frmSplash = null;
        private static Thread ms_oThread = null;

        // Fade in and out.
        private double m_dblOpacityIncrement = 0.5;
        private double m_dblOpacityDecrement = 0.8;
        private const int TIMER_INTERVAL = 500;

        // Status and progress bar
        private string m_sStatus;

        private string m_sTimeRemaining;
        private Rectangle m_rProgress;

        // Self-calibration support
        private int m_iActualTicks = 0;
        private static int step = 0;
        private static int totalStep;

        private static bool isFisrtShow;
        private static bool isAutoIncrement;
        private const int defaultIncrement = 2;

        #endregion Member Variables

        public SplashScreen()
        {
            InitializeComponent();
            this.Opacity = 0.0;
            this.ControlBox = false;
            UpdateTimer.Interval = TIMER_INTERVAL;
            UpdateTimer.Start();
        }

        #region Public Static Methods

        /// <summary>
        /// Mặc định tự động tăng
        /// Nếu sét giá trị, sử dụng hàm SetIncrement() cho các bước
        /// </summary>
        /// <param name="total"></param>
        static public void ShowSplashScreen(int total = 0)
        {
            if (ms_frmSplash != null)
                return;

            if (!isFisrtShow)
            {
                if (total != 0)
                {
                    totalStep = total;
                }
                else
                {
                    totalStep = 100;
                    isAutoIncrement = true;
                }

                isFisrtShow = true;
            }
            ms_oThread = new Thread(new ThreadStart(SplashScreen.ShowForm));
            ms_oThread.IsBackground = true;
            ms_oThread.SetApartmentState(ApartmentState.STA);
            ms_oThread.Start();
            while (ms_frmSplash == null || ms_frmSplash.IsHandleCreated == false)
            {
                System.Threading.Thread.Sleep(TIMER_INTERVAL);
            }
        }

        static public void SetIncrement()
        {
            if (step < totalStep) step++;
        }

        static public void CloseForm()
        {
            if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
            {
                ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
            }
            step = 0;
            isFisrtShow = false;
            isAutoIncrement = false;
            ms_oThread = null;
            ms_frmSplash = null;

        }

        /// <summary>
        /// Cập nhật tiêu đề form
        /// </summary>
        /// <param name="newStatus"></param>
        static public void SetStatus(string newStatus)
        {
            if (ms_frmSplash == null)
                return;
            ms_frmSplash.m_sStatus = newStatus;
        }

        /// <summary>
        /// Đưa về trạng thái hoàn thành
        /// </summary>
        static public void DoComplete()
        {
            step = totalStep;
        }

        #endregion Public Static Methods

        #region Private Methods

        static private void ShowForm()
        {
            ms_frmSplash = new SplashScreen();
            Application.Run(ms_frmSplash);
        }
        public static SplashScreen GetSplashScreen()
        {
            return ms_frmSplash;
        }
        public static void CloseFormWithButton()
        {
            if (ms_frmSplash == null)
                return;
            if (ms_frmSplash.InvokeRequired)
                ms_frmSplash.Invoke(new MethodInvoker(delegate
                 {
                     ms_frmSplash.ControlBox = true;
                     ms_frmSplash.Refresh();
                 }));
            else ms_frmSplash.ControlBox = true;
        }

        #endregion Private Methods
        private void UpdateTimer_Tick(object sender, System.EventArgs e)
        {
            lblStatus.Text = m_sStatus;

            if (m_dblOpacityIncrement > 0)
            {
                m_iActualTicks++;
                if (this.Opacity < 1)
                    this.Opacity += m_dblOpacityIncrement;
            }
            else
            {
                if (this.Opacity > 0)
                    this.Opacity += m_dblOpacityIncrement;
                else
                {
                    UpdateTimer.Stop();
                    this.Close();
                }
            }

            if (step < totalStep)
            {
                if (isAutoIncrement) step += defaultIncrement;

                float m_dblLastCompletionFraction = ((float)step) / totalStep;
                int width = (int)Math.Floor(pnlStatus.ClientRectangle.Width * m_dblLastCompletionFraction);
                int height = pnlStatus.ClientRectangle.Height;
                int x = pnlStatus.ClientRectangle.X;
                int y = pnlStatus.ClientRectangle.Y;
                if (width > 0 && height > 0)
                {
                    m_rProgress = new Rectangle(x, y, width, height);
                    if (!pnlStatus.IsDisposed)
                    {
                        Graphics g = pnlStatus.CreateGraphics();
                        LinearGradientBrush brBackground = new LinearGradientBrush(m_rProgress, Color.Orange, Color.OrangeRed, LinearGradientMode.Horizontal);
                        g.FillRectangle(brBackground, m_rProgress);
                        g.Dispose();
                    }

                    string parterm = isAutoIncrement ? string.Format("Đã xử lý {0}%", (int)((float)step / totalStep * 100)) : string.Format("Đã xử lý {0}/{1} dữ liệu yêu cầu", step, totalStep);
                    m_sTimeRemaining = (step >= totalStep) ? string.Format("Hoàn thành. Chờ trong giây lát...") : parterm;
                }
            }
            lblTimeRemaining.Text = m_sTimeRemaining;
        }
        private void SplashScreen_DoubleClick(object sender, System.EventArgs e)
        {
            CloseForm();
        }
        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
            //{
            //    ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
            //}
            //step = 0;
            //isFisrtShow = false;
            //isAutoIncrement = false;
            //ms_oThread = null;
            //ms_frmSplash = null;
        }
    }
}