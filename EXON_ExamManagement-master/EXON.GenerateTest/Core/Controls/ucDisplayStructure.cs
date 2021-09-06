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
    public partial class ucDisplayStructure : UserControl
    {
        private STRUCTURE currentStructure;
        private TOPIC currentTopic;
        private List<NumericUpDown> listNumScore;
        private List<NumericUpDown> listNumQuestion;

        private StructureDetailService _StructureDetailService;
        private PartDetailService _PartDetailService;
        private PartService _PartService;
        public int TotalNumQuestion { get; private set; }
        public double TotalScore { get; private set; }
        public int StructureId { get; private set; }
        public int TopicId { get; private set; }

        public int ScheduleId { get; private set; }


        private Color defaultColor;

        public delegate void UpdateEventHandle();

        public event UpdateEventHandle UpdateUserControl;

        public ucDisplayStructure(STRUCTURE structureTest, TOPIC topic)
        {
            InitializeComponent();
            this.currentStructure = structureTest;
            this.currentTopic = topic;
            this.StructureId = structureTest.StructureID;
            this.TopicId = topic.TopicID;
            this.ScheduleId = structureTest.ScheduleID;
            defaultColor = this.BackColor;

            _StructureDetailService = new StructureDetailService();
            _PartDetailService = new PartDetailService();
            _PartService = new PartService();
            listNumQuestion = new List<NumericUpDown>() { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4 };
            listNumScore = new List<NumericUpDown>() { numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8 };

            InitControls();
            InitEvent();

            this.Dock = DockStyle.Top;
            this.AutoSize = true;
            this.DoubleBuffered = true;
        }

        private void InitEvent()
        {
            foreach (NumericUpDown n in listNumScore)
                n.ValueChanged += NumericValueChanged;
            foreach (NumericUpDown n in listNumQuestion)
                n.ValueChanged += NumericValueChanged;
        }

        private void InitControls()
        {
            TotalNumQuestion = 0;
            TotalScore = 0;

            _StructureDetailService = new StructureDetailService();
            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
                .GetAll(currentStructure.StructureID, currentTopic.TopicID)
                .ToList();

            lbTopicName.Text = currentTopic.TopicName;
            lbLv1.Text = Properties.Resources.Level1;
            lbLv2.Text = Properties.Resources.Level2;
            lbLv3.Text = Properties.Resources.Level3;
            lbLv4.Text = Properties.Resources.Level4;

            for (int i = 0; i < listNumQuestion.Count; i++)
            {
                if (i < listStructureDetail.Count)
                {
                    TotalNumQuestion += listStructureDetail[i].NumberQuestions;
                    TotalScore += listStructureDetail[i].Score * listStructureDetail[i].NumberQuestions;

                    listNumQuestion[i].Value = listStructureDetail[i].NumberQuestions;
                    listNumScore[i].Value = (decimal)listStructureDetail[i].Score > 0 ? (decimal)listStructureDetail[i].Score : 1;
                }
                else
                {
                    listNumQuestion[i].Value = 0;
                    listNumScore[i].Value = 0.00M;
                }
            }

            lbNoQ.Text = TotalNumQuestion.ToString();
            lbNoS.Text = TotalScore.ToString("00.00");
            if (CheckHasValue()) EnableEdit(true);
            else EnableEdit(false);


            //Phan Part
            EnableEditPart(true);
            InitCbPartSubject();
        }
        private void InitCbPartSubject()
        {
            //var listPart1 = _PartService.GetByScheduleId(ScheduleId).ToList().OrderBy(x => x.OrderInTest);
            var listPart1 = _PartService.GetByScheduleId(ScheduleId).ToList();
            if (listPart1!= null)
            {
                List<PART> listPart = new List<PART>();
                if (listPart1 != null)
                {
                    PART p = new PART();
                    p.OrderInTest = 0;
                    p.PartID = 0;
                    listPart.Add(p);

                    listPart.AddRange(listPart1);

                    cbPartSubject.DataSource = listPart;
                    cbPartSubject.DisplayMember = "OrderInTest";
                    cbPartSubject.ValueMember = "PartID";
                }
                else
                {
                    PART p = new PART();
                    p.OrderInTest = 0;
                    p.PartID = 0;
                    listPart.Add(p);
                    cbPartSubject.DataSource = listPart;
                    cbPartSubject.DisplayMember = "OrderInTest";
                    cbPartSubject.ValueMember = "PartID";
                }

                PARTS_DETAILS partSDT = new PARTS_DETAILS();
                partSDT = _PartDetailService.GetByTopicId(TopicId);
                if (partSDT == null)
                {
                    cbPartSubject.SelectedIndex = 0;
                    nbOrderTopic.Value = 1;
                    nbOrderPart.Value = 1;
                }
                else
                {
                    txtName.Rtf = partSDT.PART.Name;
                    cbPartSubject.SelectedValue = partSDT.PART.PartID;
                    cbShuffle.SelectedIndex = partSDT.PART.Shuffle.Value;
                    nbOrderTopic.Value = partSDT.OrderOfTopic.Value;
                    nbOrderPart.Value = partSDT.PART.OrderInTest.Value;
                } 
            }
        }
        private void NumericValueChanged(object sender, EventArgs e)
        {
            TotalScore = 0;
            TotalNumQuestion = 0;

            for (int i = 0; i < listNumQuestion.Count; i++)
                TotalNumQuestion += (int)listNumQuestion[i].Value;
            for (int i = 0; i < listNumScore.Count; i++)
                TotalScore += (double)(listNumScore[i].Value * listNumQuestion[i].Value);

            lbNoQ.Text = TotalNumQuestion.ToString();
            lbNoS.Text = TotalScore.ToString("00.00");
        }

        public void Refesh()
        {
            InitControls();
        }

        public bool CheckCorrectStructureDetail(int structureId, int topicId)
        {
            return (StructureId == structureId) && (TopicId == topicId);
        }

        private bool CheckHasValue()
        {
            foreach (NumericUpDown n in listNumQuestion)
            {
                if (n.Value != 0)
                    return true;
            }
            return false;
        }

        internal void ChangeColor(bool v)
        {
            if (v) this.BackColor = Color.LightCyan;
            else this.BackColor = defaultColor;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
               .GetAll(currentStructure.StructureID, currentTopic.TopicID)
               .ToList();
            try
            {
                for (int i = 0; i < listNumQuestion.Count; i++)
                {
                    if (i < listStructureDetail.Count)
                    {
                        listStructureDetail[i].NumberQuestions = (int)listNumQuestion[i].Value;
                        listStructureDetail[i].Score = (double)listNumScore[i].Value;
                        _StructureDetailService.Update(listStructureDetail[i]);
                    }
                }
                _StructureDetailService.Save();
                MetroMessageBox.Show(this, Properties.Resources.UpdateSuccessMessage, Properties.Resources.Notification,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                EnableEdit(true);
                UpdateUserControl();

                Log.Instance.WriteLog(LogType.INFO, string.Format("Update structure id {0} of topic {1}",
                    currentStructure.StructureID,
                    currentTopic.TopicName));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Notification,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when update structure {0} of topic {1}, error: {2}",
                    currentStructure.StructureID,
                    currentTopic.TopicName,
                    ex.Message));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableEdit(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
               .GetAll(currentStructure.StructureID, currentTopic.TopicID)
               .ToList();

            try
            {
                for (int i = 0; i < listNumQuestion.Count; i++)
                {
                    if (i < listStructureDetail.Count)
                    {
                        listStructureDetail[i].NumberQuestions = 0;
                        listStructureDetail[i].Score = 0;
                        _StructureDetailService.Update(listStructureDetail[i]);
                    }
                }
                _StructureDetailService.Save();
                MetroMessageBox.Show(this, Properties.Resources.DeleteSuccessMessage, Properties.Resources.Notification);
                foreach (NumericUpDown n in listNumQuestion) { n.Enabled = false; n.Value = 0; }
                foreach (NumericUpDown n in listNumScore) { n.Enabled = false; n.Value = 1; }

                EnableEdit(true);
                Update();

                Log.Instance.WriteLog(LogType.INFO, string.Format("Update structure id {0} of topic {1}",
                   currentStructure.StructureID,
                   currentTopic.TopicName));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Notification);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when update structure {0} of topic {1}, error: {2}",
                    currentStructure.StructureID,
                    currentTopic.TopicName,
                    ex.Message));
            }
        }

        private void EnableEdit(bool b)
        {
            btnEdit.Enabled = b;
            btnUpdate.Enabled = !b;
            btnDelete.Enabled = !b;

            foreach (NumericUpDown n in listNumQuestion) n.Enabled = !b;
            foreach (NumericUpDown n in listNumScore) n.Enabled = !b;
        }
        private void EnableEditPart(bool b)
        {
            btnEditPart.Enabled = b;
            btnUpdatePart.Enabled = !b;
            btnDeletePart.Enabled = !b;

            txtName.Enabled = !b;
            cbPartSubject.Enabled = !b;
            cbShuffle.Enabled = !b;
            nbOrderTopic.Enabled = !b;
            nbOrderPart.Enabled = !b;

        }
        private void btnEditPart_Click(object sender, EventArgs e)
        {
            EnableEditPart(false);
        }

        private void btnUpdatePart_Click(object sender, EventArgs e)
        {
            try
            {
                PARTS_DETAILS partSDT = new PARTS_DETAILS();
                partSDT = _PartDetailService.GetByTopicId(TopicId);
                int PartID = Convert.ToInt32(cbPartSubject.SelectedValue);
                var partSubject = _PartService.GetById(PartID);
                bool IsPartCorrect = true;

                if (partSDT == null)//Them moi PART_SUBJECT_DETAIL
                {
                    if (cbPartSubject.SelectedIndex != 0)
                    {
                        partSDT = new PARTS_DETAILS();
                        partSDT.TopicID = this.TopicId;
                        partSDT.PartID = PartID;
                        partSDT.Status = 1;
                        if (partSubject.PARTS_DETAILS != null)
                        {
                            partSDT.OrderOfTopic = partSubject.PARTS_DETAILS.ToList().Count + 1;

                        }
                        else partSDT.OrderOfTopic = 1;
                        partSDT.OrderOfTopic = Convert.ToInt32(nbOrderTopic.Value);

                        _PartDetailService.Add(partSDT);
                        _PartDetailService.Save();

                        partSDT.PART.Name = txtName.Rtf;
                        partSDT.PART.Shuffle = cbShuffle.SelectedIndex;
                        partSDT.PART.OrderInTest = Convert.ToInt32(nbOrderPart.Value);
                        _PartService.Save();

                        if (!btnUpdate.Enabled) UpdateOrderQues();
                        lblOrderQues.Text = partSDT.PART.OrderOfQuestion.Value.ToString();
                    }

                }
                else
                {
                    if (cbPartSubject.SelectedIndex != 0)// Da co PART_SUBJECT_DETAIL
                    {
                        partSDT.TopicID = this.TopicId;
                        partSDT.PartID = PartID;
                        if (partSubject.PARTS_DETAILS != null)
                        {
                            bool iscontain = partSubject.PARTS_DETAILS.Contains(partSDT);
                            if (!iscontain)
                            {
                                partSDT.OrderOfTopic = partSubject.PARTS_DETAILS.ToList().Count + 1;
                            }

                        }
                        else partSDT.OrderOfTopic = 1;
                        partSDT.OrderOfTopic = Convert.ToInt32(nbOrderTopic.Value);
                        _PartDetailService.Save();

                        partSDT.PART.Name = txtName.Rtf;
                        partSDT.PART.Shuffle = cbShuffle.SelectedIndex;
                        partSDT.PART.OrderInTest = Convert.ToInt32(nbOrderPart.Value);
                        _PartService.Save();
                        if (!btnUpdate.Enabled) UpdateOrderQues();
                        lblOrderQues.Text = partSDT.PART.OrderOfQuestion.Value.ToString();
                    }
                    else
                    {
                        _PartDetailService.Delete(partSDT.PartDetailID);
                        _PartDetailService.Save();
                        if (lbNoQ.Text != "0") IsPartCorrect = false;
                    }
                }
                if (IsPartCorrect) NotificationBox.Show(Properties.Resources.UpdateSuccessMessage, NotificationBox.AlertType.success);
                else NotificationBox.Show(Properties.Resources.WarningDialog + "Chủ Đề Không Thuộc Phần Nào", NotificationBox.AlertType.warnig);
                EnableEditPart(true);
                Update();
                if (!btnUpdate.Enabled) UpdateUserControl();
                Log.Instance.WriteLog(LogType.INFO, string.Format("Update part subject detail id {0} of topic {1}",
                   partSDT.PartDetailID,
                   currentTopic.TopicName));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Notification);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when update structure {0} of topic {1}, error: {2}",
                     currentStructure.StructureID,
                     currentTopic.TopicName,
                     ex.Message));
            }
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            try
            {
                int PartID = Convert.ToInt32(cbPartSubject.SelectedValue);
                var listPSDT = _PartDetailService.GetAllByPartID(PartID).ToList();
                PARTS_DETAILS partSDT = new PARTS_DETAILS();
                partSDT = _PartDetailService.GetByTopicId(TopicId);

                if (listPSDT != null)
                {
                    foreach (var item in listPSDT)
                    {
                        _PartDetailService.Delete(item.PartDetailID);
                        _PartDetailService.Save();
                    }
                }
                _PartService.Delete(PartID);
                _PartService.Save();
                NotificationBox.Show(Properties.Resources.DeleteSuccessMessage, NotificationBox.AlertType.success);
                cbPartSubject.SelectedIndex = 0;
                InitCbPartSubject();
                EnableEditPart(false);
                Update();
                UpdateUserControl();
                Log.Instance.WriteLog(LogType.INFO, string.Format("Update  part subject detail id {0} of topic {1}",
                  partSDT.PartDetailID,
                  currentTopic.TopicName));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Notification);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when update structure {0} of topic {1}, error: {2}",
                    currentStructure.StructureID,
                    currentTopic.TopicName,
                    ex.Message));
            }
        }
        private void UpdateOrderQues()
        {
            var listPart = _PartService.GetByScheduleId(ScheduleId).OrderBy(x => x.OrderInTest).ToList();
            int count = 0;
            if (listPart != null)
            {
                for (int i = 0; i < listPart.Count; i++)
                {
                    if (i == 0)
                    {
                        count = 1;
                        listPart[i].OrderOfQuestion = 1;
                        _PartService.Save();
                    }
                    else
                    {
                        count = 1;
                        for (int j = 0; j < i; j++)
                        {
                            var listPartDT = _PartDetailService.GetAllByPartID(listPart[j].PartID);
                            foreach (var item in listPartDT)
                            {
                                var numberOfQues = item.TOPIC.STRUCTURE_SUBJECT_DETAILS.FirstOrDefault().NumberQuestions;
                                count = count + numberOfQues;
                            }
                        }
                        listPart[i].OrderOfQuestion = count;
                        _PartService.Save();
                    }
                }
            }
        }

        private void cbPartSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOrderQues();
            if (cbPartSubject.SelectedIndex != 0)
            {
                PART partSubject = _PartService.GetById(Convert.ToInt32(cbPartSubject.SelectedValue));
                txtName.Rtf = partSubject.Name;
                cbShuffle.SelectedIndex = partSubject.Shuffle.Value;
                lblOrderQues.Text = partSubject.OrderOfQuestion.ToString();

            }
            else
            {
                txtName.Rtf = null;
                cbShuffle.SelectedIndex = 2;
                lblOrderQues.Text = "0";
            }
        }
    }
}