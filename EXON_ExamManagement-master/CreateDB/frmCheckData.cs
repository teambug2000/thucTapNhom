using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quiz = CreateDB.Quiz;
using main = CreateDB.Main;

namespace CreateDB
{
    public partial class frmCheckData : Form
    {
        private BackgroundWorker bw;
        private int _locationid;

        public frmCheckData(int id)
        {
            InitializeComponent();
            _locationid = id;
        }

        private void frmCheckData_Load(object sender, EventArgs e)
        {
            btnClose.Visible = false;
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh
            // su kien
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Thread.Sleep(1000);
            //if (issucc != 0)
            //MessageBox.Show("Hoàn Thành quá trình chuyển CSDL");
            //else MessageBox.Show("Quá trình chuyển CSDL bị gián đoạn!");
            //Main.CONTEST contest = new Main.CONTEST();

            //this.Close();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbPercent.Value = e.ProgressPercentage;
            lbPercent.Text = pbPercent.Value.ToString() + "%";
            Application.DoEvents();
        }

        // code kiểm tra dữ liệu đã chuyển lên server thi của a Hoàng K50       
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbStatus.Text = "Đang kiểm tra số lượng đề thi...";
                    lbStatus.ForeColor = Color.Blue;
                });
            }
            else
            {
                lbStatus.Text = "Đang kiểm tra số lượng đề thi...";
                lbStatus.ForeColor = Color.Blue;
            }
            Quiz.Quiz dbquiz = new Quiz.Quiz();
            Main.Main dbmain = new Main.Main();
            List<quiz.DIVISION_SHIFTS> lstdivisionquiz = new List<quiz.DIVISION_SHIFTS>();
            lstdivisionquiz = dbquiz.DIVISION_SHIFTS.ToList();
            List<main.DIVISION_SHIFTS> lstdivisionmain = new List<main.DIVISION_SHIFTS>();
            lstdivisionmain = dbmain.DIVISION_SHIFTS.Where(x => x.ROOMTEST.LocationID == _locationid).ToList();
            if (lstdivisionquiz.Count >= lstdivisionmain.Count)
            {
                int coutdivisonshift = 0;
                foreach (var item in lstdivisionquiz)
                {
                    int countsub = 0;
                    List<int> lstsubjectid = item.CONTESTANTS_SHIFTS.Select(x => x.SCHEDULE.SubjectID).Distinct().ToList();
                    if (lstsubjectid != null && lstsubjectid.Count != 0)
                    {
                        foreach (var subject in lstsubjectid)
                        {
                            int couttest = dbquiz.TESTS.Where(x => x.BAGOFTEST.DivisionShiftID == item.DivisionShiftID && x.SubjectID == subject).Count();
                            int coutcontestant = dbquiz.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == item.DivisionShiftID && x.SCHEDULE.SubjectID == subject).Count();
                            if (couttest >= (int)(coutcontestant * 1.5))
                            {
                                countsub++;
                            }
                            else
                            {
                                quiz.SUBJECT sub = dbquiz.SUBJECTS.Where(x => x.SubjectID == subject).FirstOrDefault();
                                MessageBox.Show("Đề thi môn " + sub.SubjectName + ", phòng " + item.ROOMTEST.RoomTestName + ", ca " + item.SHIFT.ShiftName + " bị thiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        if (countsub == lstsubjectid.Count)
                        {
                            coutdivisonshift++;
                            bw.ReportProgress(coutdivisonshift * 100 / lstdivisionquiz.Count);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phòng " + item.ROOMTEST.RoomTestName + ", ca " + item.SHIFT.ShiftName + " không có môn thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (coutdivisonshift == lstdivisionquiz.Count)
                {
                    if (cbCheckCountTest.InvokeRequired)
                    {
                        cbCheckCountTest.BeginInvoke((MethodInvoker)delegate ()
                        {
                            cbCheckCountTest.Checked = true;
                            cbCheckCountTest.ForeColor = Color.Green;
                        });
                    }
                    else
                    {
                        cbCheckCountTest.Checked = true;
                        cbCheckCountTest.ForeColor = Color.Green;
                    }
                }
                else
                {
                    if (cbCheckCountTest.InvokeRequired)
                    {
                        cbCheckCountTest.BeginInvoke((MethodInvoker)delegate ()
                        {
                            cbCheckCountTest.Checked = false;
                            cbCheckCountTest.ForeColor = Color.Red;
                        });
                    }
                    else
                    {
                        cbCheckCountTest.Checked = false;
                        cbCheckCountTest.ForeColor = Color.Red;
                    }
                }

                //số lượng câu hỏi

                bw.ReportProgress(0);
                if (lbStatus.InvokeRequired)
                {
                    lbStatus.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lbStatus.Text = "Đang kiểm tra số lượng câu hỏi...";
                        lbStatus.ForeColor = Color.Blue;
                    });
                }
                else
                {
                    lbStatus.Text = "Đang kiểm tra số lượng câu hỏi...";
                    lbStatus.ForeColor = Color.Blue;
                }
                List<quiz.TEST> lsttest = new List<quiz.TEST>();
                lsttest = dbquiz.TESTS.ToList();
                int counttest = 0;
                foreach (quiz.TEST item in lsttest)
                {

                    int countt = 0;
                    bool checkans = true;
                    foreach (quiz.TEST_DETAILS ittestdetail in item.TEST_DETAILS)
                    {
                        //countt += ittestdetail.QUESTION.NumberSubQuestion;
                        countt += dbquiz.SUBQUESTIONS.Count(x => x.QuestionID == ittestdetail.QuestionID);
                    }
                    int kt = dbmain.STRUCTURE_DETAILS.Where(x => x.STRUCTURE.SCHEDULE.SubjectID == item.SubjectID && x.STRUCTURE.SCHEDULE.ContestID == AppSession.ContestID).Sum(x => x.NumberQuestions);
                    if (countt == kt)
                    {
                        counttest++;
                        bw.ReportProgress(counttest * 100 / lsttest.Count);
                    }
                    else
                    {
                        //MessageBox.Show("Đề " + item.TestID + ", môn " + item.SUBJECT.SubjectName + " không đủ câu hỏi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (counttest == lsttest.Count)
                {
                    if (cbSLCauHoi.InvokeRequired)
                    {
                        cbSLCauHoi.BeginInvoke((MethodInvoker)delegate ()
                        {
                            cbSLCauHoi.Checked = true;
                            cbSLCauHoi.ForeColor = Color.Green;
                        });
                    }
                    else
                    {
                        cbSLCauHoi.Checked = true;
                        cbSLCauHoi.ForeColor = Color.Green;
                    }
                }
                else
                {
                    if (cbSLCauHoi.InvokeRequired)
                    {
                        cbSLCauHoi.BeginInvoke((MethodInvoker)delegate ()
                        {
                            cbSLCauHoi.Checked = false;
                            cbSLCauHoi.ForeColor = Color.Red;
                            cbSLCauHoi.Text += string.Format("({0}/{1} đề thiếu câu hỏi)", lsttest.Count - counttest, lsttest.Count);
                        });
                    }
                    else
                    {
                        cbSLCauHoi.Checked = false;
                        cbSLCauHoi.ForeColor = Color.Red;
                    }
                }

                //// kiểm tra dữ liệu câu hỏi
                //bw.ReportProgress(0);
                if (lbStatus.InvokeRequired)
                {
                    lbStatus.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lbStatus.Text = "Đang kiểm tra dữ liệu đề thi...";
                        lbStatus.ForeColor = Color.Blue;
                    });
                }
                else
                {
                    lbStatus.Text = "Đang kiểm tra dữ liệu đề thi...";
                    lbStatus.ForeColor = Color.Blue;
                }
                Encrypter _decrypt;
                coutdivisonshift = 0;
                foreach (quiz.DIVISION_SHIFTS itemdivision in lstdivisionquiz)
                {
                    _decrypt = new Encrypter(itemdivision.Key);
                    List<quiz.QUESTIONS_TEMP> lsTempQuestion = new List<quiz.QUESTIONS_TEMP>();
                    try
                    {
                        lsTempQuestion = dbquiz.QUESTIONS_TEMP.Where(x => x.DivisionShiftID == itemdivision.DivisionShiftID).ToList();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                    }

                    int count = 0;

                    foreach (var itemquestiontemp in lsTempQuestion)
                    {
                        if (itemquestiontemp.QuestionID == 964)
                        {
                        }
                        main.QUESTION Question = new main.QUESTION();
                        Question = dbmain.QUESTIONS.Where(x => x.QuestionID == itemquestiontemp.QuestionID).SingleOrDefault();
                        if (Question.QuestionContent == _decrypt.Encrypt1000(itemquestiontemp.QuestionContent))
                        {
                            List<quiz.SUBQUESTIONS_TEMP> lsSubQuestion = new List<quiz.SUBQUESTIONS_TEMP>();
                            lsSubQuestion = dbquiz.SUBQUESTIONS_TEMP.Where(x => x.DivisionShiftID == itemdivision.DivisionShiftID && x.QuestionID == itemquestiontemp.QuestionID).ToList();
                            int countlsSub = 0;
                            foreach (var itemsub in lsSubQuestion)
                            {
                                main.SUBQUESTION orisub = new main.SUBQUESTION();
                                orisub = dbmain.SUBQUESTIONS.Where(x => x.SubQuestionID == itemsub.SubQuestionID).FirstOrDefault();
                                string s = _decrypt.Encrypt1000(itemsub.SubQuestionContent);
                                //int a = orisub.SubQuestionContent.Length;
                                //int b = s.Length;
                                //int c = 0;
                                //char q;
                                //if (itemquestiontemp.QuestionID == 964)
                                //{
                                //    string enc = _decrypt.Encrypt(orisub.SubQuestionContent);
                                //    int i;
                                //    for (i = 0; i < a; i++)
                                //    {
                                //        if (orisub.SubQuestionContent[i] != s[i])
                                //        {
                                //            c++;
                                //            q = itemsub.SubQuestionContent[i];
                                //        }
                                //    }
                                //}

                                if (orisub.SubQuestionContent == s)
                                {
                                    int countans = 0;
                                    List<quiz.ANSWER> lstans = new List<quiz.ANSWER>();
                                    lstans = dbquiz.ANSWERS.Where(x => x.SubQuestionID == itemsub.SubQuestionID).ToList();
                                    foreach (var ans in lstans)
                                    {
                                        main.ANSWER orians = new main.ANSWER();
                                        orians = dbmain.ANSWERS.Where(x => x.AnswerID == ans.AnswerID).FirstOrDefault();
                                        if (orians.AnswerContent == ans.AnswerContent && orians.IsCorrect == ans.IsCorrect)
                                        {
                                            countans++;
                                        }
                                    }
                                    if (countans == lstans.Count)
                                    {
                                        countlsSub++;
                                    }
                                }
                            }
                            if (countlsSub == lsSubQuestion.Count && lsSubQuestion.Count > 0)
                            {
                                count++;
                                bw.ReportProgress(count * 100 / lsTempQuestion.Count);
                            }
                            else MessageBox.Show("Lỗi câu hỏi " + itemquestiontemp.QuestionID.ToString());
                        }
                    }
                    if (count == lsTempQuestion.Count)
                    {
                        coutdivisonshift++;
                        if (cbCheckData.InvokeRequired)
                        {
                            cbCheckData.BeginInvoke((MethodInvoker)delegate ()
                            {
                                cbCheckData.ForeColor = Color.Blue;
                                cbCheckData.Text = "Kiểm tra dữ liệu đề thi (xong " + coutdivisonshift.ToString() + " ca)";
                                cbCheckData.Checked = false;
                            });
                        }
                        else
                        {
                            cbCheckData.Text = "Kiểm tra dữ liệu đề thi (xong " + coutdivisonshift.ToString() + " ca)";
                            cbCheckData.Checked = false;
                            cbCheckData.ForeColor = Color.Blue;
                        }
                    }
                }
                if (coutdivisonshift == lstdivisionquiz.Count)
                {
                    if (cbCheckData.InvokeRequired)
                    {
                        cbCheckData.BeginInvoke((MethodInvoker)delegate ()
                        {
                            cbCheckData.Checked = true;
                            cbCheckData.ForeColor = Color.Green;
                        });
                    }
                    else
                    {
                        cbCheckData.Checked = true;
                        cbCheckData.ForeColor = Color.Green;
                    }
                }
                else
                {
                    if (cbCheckData.InvokeRequired)
                    {
                        cbCheckData.BeginInvoke((MethodInvoker)delegate ()
                        {
                            cbCheckData.Checked = false;
                            cbCheckData.ForeColor = Color.Red;
                        });
                    }
                    else
                    {
                        cbCheckData.Checked = false;
                        cbCheckData.ForeColor = Color.Red;
                    }
                }
                if (lbStatus.InvokeRequired)
                {
                    lbStatus.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lbStatus.Text = "Kiểm tra xong!";
                        lbStatus.ForeColor = Color.Green;
                    });
                }
                else
                {
                    lbStatus.Text = "Kiểm tra xong!";
                    lbStatus.ForeColor = Color.Green;
                }
                if (btnClose.InvokeRequired)
                {
                    btnClose.BeginInvoke((MethodInvoker)delegate ()
                    {
                        btnClose.Visible = true;

                    });
                }
                else
                {
                    btnClose.Visible = true;
                }
                //btnClose.Visible = true;
            }
            else
            {
                MessageBox.Show("Dữ liệu thiếu ca thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (btnClose.InvokeRequired)
                {
                    btnClose.BeginInvoke((MethodInvoker)delegate ()
                    {
                        btnClose.Visible = true;

                    });
                }
                else
                {
                    btnClose.Visible = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}