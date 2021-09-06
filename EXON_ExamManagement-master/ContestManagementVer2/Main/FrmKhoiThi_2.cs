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

namespace ContestManagementVer2.Main
{
    public partial class FrmKhoiThi_2 : MetroFramework.Forms.MetroForm
    {
        private ExonSystem db;
        private int _contestid = 0;
        private int _currentsubid = 0;

        public FrmKhoiThi_2(int id, string name)
        {
            InitializeComponent();
            db = DAO.DBService.db;
            _contestid = id;
            lblNameContest.Text += name;
        }

        private void reloadDgvGroup()
        {
            var lstGroup = (from c in db.GROUPS
                            where c.ContestID == _contestid
                            select new
                            {
                                GroupName = c.GroupName,
                                CountSub = c.GROUP_SUBJECTS.Count
                            }
                 ).ToList();
            dgvGroup.DataSource = lstGroup;
            dgvGroup.Refresh();
        }

        private void reloadDgvSubject()
        {
            string currentGroupName = "";
            try
            {
                currentGroupName = dgvGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            }
            catch
            {
                return;
            }
            var lstSubject = (from s in db.SUBJECTS
                              from g in db.GROUPS
                              from gs in db.GROUP_SUBJECTS
                              from sch in db.SCHEDULES
                              where g.GroupName == currentGroupName && gs.GroupID == g.GroupID && gs.SubjectID == s.SubjectID && sch.SubjectID == s.SubjectID && sch.ContestID == _contestid && g.ContestID == _contestid
                              select new
                              {
                                  SubjectName = s.SubjectName,
                                  SubjectTime = sch.TimeOfTest / 60
                              }).ToList();
            dgvSubject.DataSource = lstSubject;
            dgvSubject.Refresh();
        }

        private void FrmKhoiThi_2_Load(object sender, EventArgs e)
        {
            reloadDgvGroup();
            var lstSubject = (from s in db.SUBJECTS
                              from c in db.SCHEDULES
                              where s.SubjectID == c.SubjectID && c.ContestID == _contestid
                              select new
                              {
                                  SubjectID = s.SubjectID,
                                  SubjectName = s.SubjectName,
                              }
                 ).ToList();
            lstSubject.Insert(0, new { SubjectID = 0, SubjectName = "--Chọn Môn thi--" });
            cbx_SubjectName.DataSource = lstSubject;
            cbx_SubjectName.DisplayMember = "SubjectName";
            cbx_SubjectName.ValueMember = "SubjectID";
        }

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_TenKhoiThi.Text = dgvGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            }
            catch
            {
                return;
            }
            reloadDgvSubject();
        }

        private void btn_ThemKhoiThi_Click(object sender, EventArgs e)
        {
            if (txt_TenKhoiThi.Text == "")
                return;
            else
            {
                string currentGroupName = txt_TenKhoiThi.Text;
                var existGroup = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == currentGroupName).ToList();
                if (existGroup.Count() == 0 )
                {
                    GROUP newgroup = new GROUP();
                    newgroup.GroupName = currentGroupName;
                    newgroup.ContestID = _contestid;
                    db.GROUPS.Add(newgroup);
                    db.SaveChanges();
                    reloadDgvGroup();
                    reloadDgvSubject();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại Khối thi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_SuaKhoiThi_Click(object sender, EventArgs e)
        {
            string oldGroupName = "";
            try
            {
                oldGroupName = dgvGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            }
            catch
            {
                return;
            }
            string newGroupName = txt_TenKhoiThi.Text;
            if (newGroupName == "")
                return;
            else
            {
                var existGroup = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == newGroupName).ToList();
                if (existGroup.Count() > 0)
                {
                    MessageBox.Show("Trùng tên Khối thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                   
                GROUP grp = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == oldGroupName).FirstOrDefault();
                grp.GroupName = newGroupName;
                db.SaveChanges();
                reloadDgvGroup();
                reloadDgvSubject();
            }
        }

        private void btn_XoaKhoiThi_Click(object sender, EventArgs e)
        {
            string currentGroupName = "";
            try
            {
                currentGroupName = dgvGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            }
            catch
            {
                return;
            }
            GROUP currentGroup = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == currentGroupName).FirstOrDefault();
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa khối thi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                if (confirm == DialogResult.Yes)
                {
                    db.GROUP_SUBJECTS.RemoveRange(db.GROUP_SUBJECTS.Where(p => p.GroupID == currentGroup.GroupID));
                    db.GROUPS.Remove(currentGroup);
                    db.SaveChanges();
                    reloadDgvGroup();
                    reloadDgvSubject();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_ThemMonThi_Click(object sender, EventArgs e)
        {
            string currentGroupName = "";
            try
            {
                currentGroupName = dgvGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            }
            catch
            {
                return;
            }
            GROUP currentGroup = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == currentGroupName).FirstOrDefault();
            int SubjectID = Convert.ToInt32(cbx_SubjectName.SelectedValue);
            if (SubjectID == 0)
            {
                MessageBox.Show("Vui lòng chọn môn thi");
                return;
            }
            var existSubject = db.GROUP_SUBJECTS.Where(p => p.GroupID == currentGroup.GroupID && p.SubjectID == SubjectID).ToList();
            if (existSubject.Count() == 0)
            {
                GROUP_SUBJECTS grp_sub = new GROUP_SUBJECTS();
                grp_sub.SubjectID = SubjectID;
                grp_sub.GroupID = currentGroup.GroupID;
                int groupSubCount = db.GROUP_SUBJECTS.Where(p => p.GroupID == currentGroup.GroupID).Count();
                grp_sub.Ordinal = groupSubCount + 1;
                db.GROUP_SUBJECTS.Add(grp_sub);
                db.SaveChanges();
                reloadDgvSubject();
            }
            else
            {
                MessageBox.Show("Đã có môn thi này trong khối thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaMonThi_Click(object sender, EventArgs e)
        {
            string currentGroupName = "";
            string currentSubName = "";
            try
            {
                currentGroupName = dgvGroup.CurrentRow.Cells["GroupName"].Value.ToString();
                currentSubName = dgvSubject.CurrentRow.Cells["SubjectName"].Value.ToString();
            }
            catch
            {
                return;
            }
            GROUP currentGroup = db.GROUPS.Where(p => p.ContestID == _contestid && p.GroupName == currentGroupName).FirstOrDefault();
            SUBJECT currentSub = db.SUBJECTS.Where(p => p.SubjectName == currentSubName).FirstOrDefault();
            GROUP_SUBJECTS grp_sub = db.GROUP_SUBJECTS.Where(p => p.GroupID == currentGroup.GroupID && p.SubjectID == currentSub.SubjectID).FirstOrDefault();
            db.GROUP_SUBJECTS.Remove(grp_sub);
            db.SaveChanges();

            // Update Subject's Ordinal
            var lst_grpsub = db.GROUP_SUBJECTS.Where(p => p.GroupID == currentGroup.GroupID).OrderBy(p => p.Group_SubjectID).ToList();
            int i = 0;
            foreach(var item in lst_grpsub)
            {
                item.Ordinal = ++i;           
            }
            db.SaveChanges();
            reloadDgvSubject();
        }
    }
}
