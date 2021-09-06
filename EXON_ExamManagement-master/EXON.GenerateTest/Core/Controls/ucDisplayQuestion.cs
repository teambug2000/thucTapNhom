using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Extensions;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucDisplayQuestion : UserControl
    {
        private QuestionService _QuestionService = new QuestionService();
        private QuestionTypeService _QuestionTypeService = new QuestionTypeService();
        private SubQuestionService _SubQuestionService = new SubQuestionService();
        private AnswerService _AnswerService = new AnswerService();
        private TopicService _TopicService = new TopicService();
        private StaffService _StaffService = new StaffService();

        public ucDisplayQuestion(int questionID, ref int index)
        {
            this.Dock = DockStyle.Top;

            InitializeComponent();
            InitializeControl(questionID, ref index);
            InitializeDetail(questionID);
        }

        private void InitializeDetail(int questionID)
        {
            QUESTION currentQuestion = _QuestionService.GetById(questionID);
            if (currentQuestion != null)
            {
                lbTopic.Text = string.Format("Chủ Đề: {0}", _TopicService
                    .GetById(currentQuestion.TopicID)
                    .TopicName);
                lbType.Text = string.Format("Thể Loại: {0}", _QuestionTypeService
                    .GetById(currentQuestion.QuestionTypeID)
                    .QuestionTypeName);
                lbLevel.Text = string.Format("Độ Khó: {0}", currentQuestion.Level);
                lbCreatedDate.Text = string.Format("Ngày Tạo: {0}",
                    DateTimeHelpers
                    .ConvertUnixToDateTime(currentQuestion.CreatedDate)
                    .ToShortDateString());
                lbCreatedBy.Text = string.Format("Người Tạo: {0}", _StaffService
                    .GetById(currentQuestion.CreatedStaffID)
                    .FullName);
                lbAcceptedBy.Text = string.Format("Người Phê Duyệt: {0}", _StaffService
                    .GetById(currentQuestion.AcceptedStaffID.Value)
                    .FullName);
            }
        }

        private void InitializeControl(int questionID, ref int index)
        {
            //pcMain.Controls.Clear();
            QUESTION currentQuestion = _QuestionService.GetById(questionID);

            if (currentQuestion != null)
            {
                QUESTION_TYPES questionType = _QuestionTypeService.GetById(currentQuestion.QuestionTypeID);
                List<SUBQUESTION> subQuestion = _SubQuestionService.GetAll(currentQuestion.QuestionID).ToList();

                int Index = questionType.NumberSubQuestion - 1;

                if (questionType.Type != (int)QuizTypeEnum.Matching && questionType.Type != (int)QuizTypeEnum.ListeningMatching)
                {
                    for (int i = questionType.NumberSubQuestion; i > 0; i--)
                    {
                        CustomeGroup grb = new CustomeGroup();
                        grb.Dock = DockStyle.Top;
                        grb.AutoSize = true;
                        grb.Name = "SubQuestion" + i;
                        grb.Padding = new Padding(10, 5, 10, 5);
                        grb.Text = "Câu hỏi " + (index + Index--);
                        grb.ForeColor = Color.Green;

                        Label lblQ = new Label();
                        lblQ.Visible = false;
                        lblQ.Name = "lblQ" + i + "ID";
                        grb.Controls.Add(lblQ);

                        List<ANSWER> listAnswer = _AnswerService
                            .GetAll(subQuestion[i - 1].SubQuestionID)
                            .ToList();
                        if (questionType.IsQuiz)
                        {
                            for (int j = questionType.NumberAnswer; j > 0; j--)
                            {
                                Panel pnl = new Panel();
                                pnl.BackColor = Color.White;
                                pnl.Dock = DockStyle.Top;
                                pnl.Size = new Size(0, 30);
                                pnl.Padding = new Padding(5, 5, 0, 5);

                                Label lbl = new Label();
                                lbl.Visible = false;
                                lbl.Name = "lblQ" + i + "Ans" + j + "ID";
                                pnl.Controls.Add(lbl);

                                CustomeRichTextbox rtb = new CustomeRichTextbox();
                                rtb.ReadOnly = true;
                                rtb.SelectionFont = new System.Drawing.Font(Properties.Resources.Font, 9,
                                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                rtb.Dock = DockStyle.Fill;
                                rtb.Name = "rtbQ" + i + "Ans" + j + "Content";
                                rtb.ScrollToCaret();
                                rtb.ReadOnly = false;
                                if (questionType.Type == null || questionType.Type == (int)QuizTypeEnum.Regular || questionType.Type == (int)QuizTypeEnum.Audio)
                                {
                                    rtb.Rtf = listAnswer[j - 1].AnswerContent;
                                    rtb.Height = listAnswer[j - 1].HeightToDisplay.Value;

                                }
                                else
                                {
                                    rtb.Text = listAnswer[j - 1].AnswerContent;
                                    rtb.Height = listAnswer[j - 1].HeightToDisplay.Value;
                                }
                                rtb.ReadOnly = true;

                                pnl.Controls.Add(rtb);

                                if (questionType.IsSingleChoice)
                                {
                                    RadioButton rdoCorrect = new RadioButton();
                                    rdoCorrect.Dock = DockStyle.Left;
                                    rdoCorrect.AutoSize = true;
                                    rdoCorrect.Name = "rdoQ" + i + "Correct" + j;
                                    rdoCorrect.Text = "Câu trả lời " + j + ".";
                                    rdoCorrect.Checked = listAnswer[j - 1].IsCorrect;

                                    pnl.Controls.Add(rdoCorrect);
                                }
                                else
                                {
                                    CheckBox chkCorrect = new CheckBox();
                                    chkCorrect.Dock = DockStyle.Left;
                                    chkCorrect.AutoSize = true;
                                    chkCorrect.Name = "chkQ" + i + "Correct" + j;
                                    chkCorrect.Text = "Câu trả lời " + j + ".";
                                    chkCorrect.Checked = listAnswer[j - 1].IsCorrect;

                                    pnl.Controls.Add(chkCorrect);
                                }

                                grb.Controls.Add(pnl);
                            }
                        }
                        if (questionType.IsQuestionContent)
                        {
                            CustomeRichTextbox rtb = new CustomeRichTextbox();
                            rtb.ReadOnly = true;
                            rtb.Dock = DockStyle.Top;
                            rtb.SelectionFont = new Font(Properties.Resources.Font, 11);
                            rtb.Name = "rtbQ" + i + "Content";
                            rtb.Size = new Size(0, 52);
                            rtb.ScrollToCaret();
                            rtb.ReadOnly = false;
                            rtb.Rtf = subQuestion[i - 1].SubQuestionContent;
                            rtb.ReadOnly = true;

                            grb.Controls.Add(rtb);
                        }

                        pcMain.Controls.Add(grb);
                    }
                }
                else if (questionType.Type == (int)QuizTypeEnum.Matching)
                {
                    CustomeGroup grb = new CustomeGroup();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Padding = new Padding(30, 5, 10, 5);
                    //grb.Text = "Câu hỏi " + (index + --Index);
                    //grb.ForeColor = Color.Green;

                    ucMatchingQuestion matching = new ucMatchingQuestion();
                    matching.Name = "ucM" + currentQuestion.QuestionID.ToString();
                    matching.Dock = DockStyle.Top;

                    bool isRtf = currentQuestion.QuestionFormat == (int)QuestionFormat.RTF;
                    matching.InitData(currentQuestion.QuestionID, isMultiAns: !questionType.IsSingleChoice, isRtf: isRtf);
                    grb.Controls.Add(matching);
                    pcMain.Controls.Add(grb);
                }
                else if (questionType.Type == (int)QuizTypeEnum.ListeningMatching)
                {
                    CustomeGroup grb = new CustomeGroup();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Padding = new Padding(30, 5, 10, 5);
                    //grb.Text = "Câu hỏi " + (index + --Index);
                    //grb.ForeColor = Color.Green;

                    ucMatchingQuestion matching = new ucMatchingQuestion();
                    matching.Name = "ucLM" + currentQuestion.QuestionID.ToString();
                    matching.Dock = DockStyle.Top;

                    bool isRtf = currentQuestion.QuestionFormat == (int)QuestionFormat.RTF;
                    matching.InitData(currentQuestion.QuestionID, isMultiAns: !questionType.IsSingleChoice, isRtf: isRtf);
                    grb.Controls.Add(matching);
                    pcMain.Controls.Add(grb);
                }

                if (questionType.Type == (int)QuizTypeEnum.Audio ||
                questionType.Type == (int)QuizTypeEnum.FillAudio || questionType.Type == (int)QuizTypeEnum.ListeningMatching)
                {

                    CustomeGroup grb = new CustomeGroup();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Padding = new Padding(10, 5, 10, 5);
                    grb.Text = "File Nghe";

                    ucAudioQuestion rtb = new ucAudioQuestion(currentQuestion.QuestionID);
                    rtb.Name = "ucAudio";
                    rtb.Dock = DockStyle.Top;
                    grb.Controls.Add(rtb);

                    pcMain.Controls.Add(grb);
                }
                if (questionType.IsParagraph)
                {
                    CustomeGroup grb = new CustomeGroup();
                    grb.Dock = DockStyle.Top;
                    grb.AutoSize = true;
                    grb.Padding = new Padding(10, 5, 10, 5);
                    grb.Text = "Đoạn văn";

                    CustomeRichTextbox rtb = new CustomeRichTextbox();
                    rtb.ReadOnly = true;
                    rtb.SelectionFont = new Font(Properties.Resources.Font, 11);
                    rtb.Dock = DockStyle.Bottom;
                    rtb.Name = "rtbParagraph";
                    rtb.ScrollToCaret();
                    rtb.ReadOnly = false;
                    rtb.Rtf = currentQuestion.QuestionContent;
                    rtb.ReadOnly = true;
                    grb.Controls.Add(rtb);

                    pcMain.Controls.Add(grb);
                }
                index += questionType.NumberSubQuestion;
            }
            UpdateSizeControl();
        }

        private void UpdateSizeControl()
        {
            int totalHeight = 0;

            IEnumerable<Control> listControl = pcMain.Controls.All().OfType<CustomeGroup>();
            int step = listControl.Count() * 5 / 4;
            step = (step > 35) ? step : 35;
            foreach (Control c in listControl)
            {
                totalHeight += c.PreferredSize.Height + step;
                step -= 2;
            }
            this.Height = listControl.Count() > 3 ? totalHeight : totalHeight + 70;
        }

        public void Accepted(bool b)
        {
            pictureBox1.Visible = b;
        }
    }
}