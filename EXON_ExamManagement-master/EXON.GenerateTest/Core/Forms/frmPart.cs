using EXON.Common;
using EXON.Data.Services;
using EXON.GenerateTest.Core.Common;
using EXON.Model.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Forms
{
    public partial class frmPart : BaseForm
    {
        private DepartmentService DepartmentService = new DepartmentService();
        private SubjectService SubjectService = new SubjectService();
        private PartService _PartSubjectService = new PartService();
        private ScheduleService _ScheduleService = new ScheduleService();

        private int ScheduleID;
        private int CurrentStaffID;
        public frmPart(int scheduleId, int currentStaffID)
        {
            InitializeComponent();
            this.ScheduleID = scheduleId;
            this.CurrentStaffID = currentStaffID;
            InitDataControl();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateField.ValidateTextBox(this.Controls))
            {
                try
                {
                    PART partSubject = new PART();
                    partSubject.Name = txtName.Rtf;
                    partSubject.OrderInTest = (int)nbOrder.Value;
                    if (cbShuffle.SelectedIndex == 2) partSubject.Shuffle = 0;
                    else partSubject.Shuffle = cbShuffle.SelectedIndex;
                    partSubject.CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                    partSubject.ScheduleID = ScheduleID;
                    partSubject.CreateStaffID = CurrentStaffID;
                    partSubject.Status = 1;
                    _PartSubjectService.Add(partSubject);
                    _PartSubjectService.Save();
                    MessageBox.Show("Thêm Dữ Liệu Thành Công!", "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ActionForm = ActionFormResult.Change;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Tên Phần Thi Quá Dài.\nPhải nhỏ hơn 10 kí tự!", "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void InitDataControl()
        {
            var schedule = _ScheduleService.GetById(ScheduleID);
            var subject = schedule.SUBJECT;
            txtSubjectName.Enabled = true;
            txtSubjectName.Text = subject.SubjectName.ToString();
            cbShuffle.SelectedIndex = 2;
        }

    }
}
