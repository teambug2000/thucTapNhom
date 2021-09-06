using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EXON.Data.Services;
using EXON.Model.Models;
using EXON.Common;
using Tung.Log;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucAudioQuestion : UserControl
    {
        private QuestionService _QuestionService = new QuestionService();
        private int questionID;

        bool loadingPlayer;
        private string url;
        private string fileName;
        //WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        private Timer time = new Timer();

        public byte[] AudioSource
        {
            get
            {
                if (string.IsNullOrEmpty(url)) return null;
                byte[] bytes;
                using (FileStream file = new FileStream(url, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                }
                return bytes;
            }
        }
        public ucAudioQuestion()
        {
            InitializeComponent();
            //wplayer.PlayStateChange += Wplayer_PlayStateChange;
            time.Tick += Time_Tick;
            time.Start();

            btnPlay.Enabled = false;
        }

        public ucAudioQuestion(int questionID)
        {
            InitializeComponent();
            //wplayer.PlayStateChange += Wplayer_PlayStateChange;
            time.Tick += Time_Tick;
            time.Start();

            this.questionID = questionID;
            btnPlay.Enabled = false;
        }

        private void Wplayer_PlayStateChange(int NewState)
        {
            if (loadingPlayer && NewState == 3)
            {
                //lbMaxLength.Text = wplayer.currentMedia.durationString;
               // tbProcess.Maximum = (int)wplayer.currentMedia.duration;
                loadingPlayer = false;
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            //if (wplayer == null) return;

            //tbProcess.Value = (int)wplayer.controls.currentPosition;
            //lbCurrentTime.Text = string.Format("{0}:{1}", (int)wplayer.controls.currentPosition / 60,
                //((int)wplayer.controls.currentPosition % 60).ToString("00"));
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (questionID > 0)
            {
                try
                {
                    string filename = DateTime.Now.ToFileTime().ToString();

                    SplashScreenManager.ShowSplashScreen();
                    QUESTION question = _QuestionService.GetById(questionID);
                    if (!Directory.Exists(Path.Combine(Application.StartupPath, "temp")))
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "temp"));
                    File.WriteAllBytes("temp/" + filename + ".mp3", question.Audio);
                    SplashScreenManager.CloseForm();

                    url = Path.Combine(Application.StartupPath, "temp/" + filename + ".mp3");
                    //wplayer.URL = url;
                    //wplayer.controls.stop();
                    btnPlay.Enabled = true;
                    btnLoadFile.Enabled = false;
                }
                catch (Exception ex)
                {
                    SplashScreenManager.CloseForm();
                    btnPlay.Enabled = false;
                    Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "Audio file .mp3 |*.mp3;";
                ofd.Title = "Chọn file âm thanh";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    url = ofd.FileName;
                    string[] splitURL = url.Split('\\');
                    if (splitURL.Length > 0)
                    {
                        btnPlay.Enabled = true;
                        fileName = splitURL[splitURL.Length - 1];
                    }
                    else
                    {
                        fileName = "";
                        url = "";
                        btnPlay.Enabled = false;
                    }

                    lbFilename.Text = fileName;
                    //wplayer.URL = url;
                    //wplayer.controls.stop();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(url)) return;
            if (btnPlay.Text == "Play")
            {
                loadingPlayer = true;
               // wplayer.controls.play();

                btnPlay.Text = "Pause";
            }
            else
            {
               // wplayer.controls.pause();
                btnPlay.Text = "Play";
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
           // if (wplayer != null)
            {
               // wplayer.controls.stop();
               // wplayer.close();
            }
        }

        internal void Clear()
        {
            url = "";
            fileName = "";

            btnPlay.Text = "Play";
            btnPlay.Enabled = false;

            lbFilename.Text = "Chọn file nghe";

           // wplayer.controls.stop();
           // wplayer = new WMPLib.WindowsMediaPlayer();
        }
    }
}
