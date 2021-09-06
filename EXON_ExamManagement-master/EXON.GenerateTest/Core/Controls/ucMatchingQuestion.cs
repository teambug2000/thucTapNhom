using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucMatchingQuestion : UserControl
    {
        protected int previousHeight { get; set; }
        protected int currentHeight { get; set; }

        private int currnentQuestionID;
        public ucMatchingQuestion()
        {
            InitializeComponent();
            this.Resize += UcMatchingQuestion_Resize; ;

        }



        private void UcMatchingQuestion_Resize(object sender, EventArgs e)
        {
            if (this.Parent == null || this.Parent.Parent == null) return;
            previousHeight = currentHeight;
            currentHeight = this.Height;

            ucDisplayQuestion parent = (this.Parent.Parent.Parent as ucDisplayQuestion);
            if (parent != null)
            {
                parent.Height += currentHeight - previousHeight;
            }
        }

        public void InitData(int QuestionID, bool isMultiAns = false, bool isRtf = true)
        {
            currnentQuestionID = QuestionID;
            QuestionService QuestionService = new QuestionService();

            QUESTION Question = QuestionService.GetById(QuestionID);
            //if (!string.IsNullOrEmpty(Question.QuestionContent))
            //{
            //    txtContent.InitControl(Question.QuestionContent);
            //    if (Question.HeightToDisplay.HasValue) txtContent.Height = Question.HeightToDisplay.Value;
            //}
            //else
            //{
            //    this.Height -= txtContent.Height;
            //    txtContent.Dispose();
            //}

            AnswerService answerService = new AnswerService();

            SubQuestionService subQuestionService = new SubQuestionService();
            IEnumerable<SUBQUESTION> listSubQues1 = subQuestionService.GetAll(QuestionID);
            SUBQUESTION sub = listSubQues1.First();
            IEnumerable<ANSWER> listAnswer = answerService.GetAll(sub.SubQuestionID);
            TRichText4Display[] listTextBoxAns = new TRichText4Display[] { rtbAns1, rtbAns2, rtbAns3, rtbAns4, rtbAns5, rtbAns6, rtbAns7, rtbAns8 };

            //CheckBox[] listCheckBox = new CheckBox[] { radioButton1, radioButton2, radioButton3, radioButton4 };
            Panel[] listPanelAns = new Panel[] { panel12, panel14, panel16, panel18, panel20, panel21, panel22, panel23 };


            //Init Answer
            int index = 0;
            foreach (ANSWER a in listAnswer)
            {
                listTextBoxAns[index].InitControl(a.AnswerContent, isRtf: isRtf);
                // listCheckBox[index].Checked = a.IsCorrect;
                // listCheckBox[index].ForeColor = a.IsCorrect ? Color.Red : Color.Black;
                // if (a.HeightToDisplay.HasValue) listCheckBox[index].Height = a.HeightToDisplay.Value;

                index++;
            }
            for (int i = index; i < 8; i++)
            {
                listPanelAns[i].Dispose();
                listPanelAns[i].Dispose();
                listPanelAns[i].Dispose();

                this.Height -= listPanelAns[i].Height;
            }
            //Init SubQues

            //foreach (CheckBox c in listCheckBox)
            //{
            //    if (!isMultiAns) c.CheckedChanged += RadioButton1_CheckedChanged;
            //}

            IEnumerable<SUBQUESTION> listSubQues = new SubQuestionService().GetAll(QuestionID);
            TRichText4Display[] listTextBoxQues = new TRichText4Display[] { rtbQues1, rtbQues2, rtbQues3, rtbQues4, rtbQues5 };
            Panel[] listPanelQues = new Panel[] { panel11, panel13, panel15, panel17, panel19 };
            int index1 = 0;
            foreach (SUBQUESTION subQues in listSubQues)
            {
                listTextBoxQues[index1].InitControl(subQues.SubQuestionContent, isRtf: isRtf);
                index1++;
            }
            for (int i = index1; i < 5; i++)
            {
                listPanelQues[i].Dispose();
                listPanelQues[i].Dispose();
                listPanelQues[i].Dispose();

                this.Height -= listPanelQues[i].Height;
            }


            previousHeight = currentHeight = this.Height;
        }



        internal void SetSizeAnswer()
        {
            QuestionService QuestionService = new QuestionService();
            int QuestionID = currnentQuestionID;
            QUESTION Question = new QuestionService().GetById(QuestionID);
            //if (!string.IsNullOrEmpty(Question.QuestionContent))
            //{
            //    Question.HeightToDisplay = txtContent.Height;
            //    QuestionService.Update(Question);
            //    QuestionService.Save();
            //}

            AnswerService answerService = new AnswerService();
            IEnumerable<SUBQUESTION> listSubQues = new SubQuestionService().GetAll(QuestionID);
            SUBQUESTION sub = listSubQues.First();
            IEnumerable<ANSWER> listAnswer = answerService.GetAll(sub.SubQuestionID);
            TRichText4Display[] listTextBoxAns = new TRichText4Display[] { rtbAns1, rtbAns2, rtbAns3, rtbAns4, rtbAns5, rtbAns6, rtbAns7, rtbAns8 };
            int index = 0;
            foreach (ANSWER a in listAnswer)
            {
                a.HeightToDisplay = listTextBoxAns[index].Height;
                answerService.Update(a);
                index++;
            }

            answerService.Save();

            SubQuestionService subQuestionService = new SubQuestionService();

            IEnumerable<SUBQUESTION> listSubQues1 = new SubQuestionService().GetAll(QuestionID);
            TRichText4Display[] listTextBoxQues = new TRichText4Display[] { rtbQues1, rtbQues2, rtbQues3, rtbQues4, rtbQues5 };
            int index1 = 0;
            foreach (SUBQUESTION subQues in listSubQues1)
            {

                var subQUesUpdate = subQuestionService.GetById(subQues.SubQuestionID);
                subQUesUpdate.HeightToDisplay = listTextBoxQues[index1].Height;
                subQuestionService.Update(subQUesUpdate);
                index1++;
            }
            subQuestionService.Save();

        }
    }
}
