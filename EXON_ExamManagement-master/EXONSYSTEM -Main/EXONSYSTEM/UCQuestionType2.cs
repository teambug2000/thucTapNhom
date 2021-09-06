using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXONSYSTEM.Common;
using DAO.DataProvider;

namespace EXONSYSTEM
{
    public partial class UCQuestionType2 : UserControl
    {
        public Control mbtnControl { get; set; }
        public Questions q;
        private AnswersheetDetail AD;
        public UCQuestionType2()
        {
            InitializeComponent();
          
            this.BackColor = Constant.COLOR_WHITE;
            mpnAnswers.BackColor = Constant.COLOR_WHITE;
            pnTitleOfQuestion.BackColor = Constant.COLOR_WHITE;
        }

        private void UCQuestionType2_Load(object sender, EventArgs e)
        {
            pnTitleOfQuestion.Location = new Point(10, 10);
            pnTitleOfQuestion.Width = this.Width - 20;

            lbNumber.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Underline | FontStyle.Bold);
            lbNumber.Text = string.Format(Properties.Resources.MSG_GUI_0020, q.NO);
            lbNumber.Location = new Point(0, 0);
            lbNumber.Width = 80;
            Controllers.Instance.HandleRichTextBoxStyle(rtbTitleOfQuestion);
            rtbTitleOfQuestion.Location = new Point(lbNumber.Width, 0);
            rtbTitleOfQuestion.Width = pnTitleOfQuestion.Width - lbNumber.Width;
            Binding dbTitleOfQuestion = new Binding("Rtf", q, "TitleOfQuestion");
            rtbTitleOfQuestion.DataBindings.Add(dbTitleOfQuestion);
        }
        public void HandleQuestion(Questions qs, int AnswerSheetID)
        {
            q = qs;
            AD = new AnswersheetDetail();
            AD.SubQuestionID = q.SubQuestionID;
            AD.AnswerSheetID = AnswerSheetID;
        }
    }
}
