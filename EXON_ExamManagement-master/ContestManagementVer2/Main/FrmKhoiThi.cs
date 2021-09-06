using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContestManagementVer2.CSDL_Exonsytem;
using MetroFramework;

namespace ContestManagementVer2.Main
{
    public partial class FrmKhoiThi : MetroFramework.Forms.MetroForm
    {
        private ExonSystem db;
        private int _contestid = 0;
        private int _currentsubid = 0;

        public FrmKhoiThi(int id, string name)
        {
            InitializeComponent();
            db = DAO.DBService.db;
            _contestid = id;
            lbNamecontest.Text += name;
        }

        private void FrmKhoiThi_Load(object sender, EventArgs e)
        {
            var lstSubject = (from s in db.SUBJECTS
                              from c in db.SCHEDULES
                              where s.SubjectID == c.SubjectID && c.ContestID == _contestid
                              select new
                              {
                                  SubjectID = s.SubjectID,
                                  SubjectName = s.SubjectName,
                                  Time = c.TimeOfTest / 60
                              }
                 ).ToList(); ;
            var lstGroup = (from c in db.GROUPS
                            where c.ContestID == _contestid
                            select new
                            {
                                GroupName = c.GroupName,
                                CountSub = c.GROUP_SUBJECTS.Count
                            }
                 ).ToList();
            dgvSubjectContest.DataSource = lstSubject;
            dgvGroup.DataSource = lstGroup;
        }

        private void dgvSubjectContest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSubinGroup.Rows)
            {
                if (row.Cells[0].Value.ToString() == dgvSubjectContest.CurrentRow.Cells["SubjectID"].Value.ToString())
                {
                    return;
                }
            }
            dgvSubinGroup.Rows.Add(dgvSubjectContest.CurrentRow.Cells["SubjectID"].Value.ToString(), dgvSubjectContest.CurrentRow.Cells["SubjectName"].Value.ToString(), dgvSubjectContest.CurrentRow.Cells["Time"].Value.ToString());
        }

        private void btnDeleteSub_Click(object sender, EventArgs e)
        {
            if (this.dgvSubinGroup.CurrentRow != null)
            {
                dgvSubinGroup.Rows.RemoveAt(this.dgvSubinGroup.CurrentRow.Index);
            }
        }

        private void btnThemKhoi_Click(object sender, EventArgs e)
        {
            if (txtGoupName.Text != "")
            {
                try
                {
                    GROUP group = new GROUP();
                    group.GroupName = txtGoupName.Text;
                    group.ContestID = _contestid;
                    db.GROUPS.Add(group);
                    db.SaveChanges();
                    GROUP_SUBJECTS grsub;
                    int i = 1;
                    foreach (DataGridViewRow row in dgvSubinGroup.Rows)
                    {
                        grsub = new GROUP_SUBJECTS();
                        grsub.GroupID = group.GroupID;
                        grsub.Ordinal = i;
                        grsub.SubjectID = int.Parse(row.Cells[0].Value.ToString());
                        i++;
                        db.GROUP_SUBJECTS.Add(grsub);
                    }
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var lstGroup = (from c in db.GROUPS
                                    where c.ContestID == _contestid
                                    select new
                                    {
                                        GroupName = c.GroupName,
                                        CountSub = c.GROUP_SUBJECTS.Count
                                    }
                 ).ToList();
                    dgvGroup.DataSource = lstGroup;
                    txtGoupName.Text = "";
                    dgvSubinGroup.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công!\nLỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}