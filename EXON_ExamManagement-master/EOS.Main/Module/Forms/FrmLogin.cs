using EXON.Common;
using EXON.Data.Services;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EXON.Main.Module.Forms
{
    public partial class FrmLogin : MetroForm
    {
        private StaffService _StaffService;
        public class account
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        public LoginStatus LoginStatus
        {
            get;
            private set;
        }

        public int CurrentStaffId
        {
            get;
            private set;
        }

        public List<account> Readjs()
        {
            if (System.IO.File.Exists("account.json"))
            {
                FileStream fs = new FileStream("account.json", FileMode.Open);
                StreamReader rd = new StreamReader(fs, Encoding.UTF8);
                string jsonAccount = rd.ReadToEnd();
                fs.Close();
                if (jsonAccount != " ")
                {
                    var acc = JsonConvert.DeserializeObject<List<account>>(jsonAccount);
                    return acc;
                }
                else return null;
                
            }
            else
            {
                FileStream fs = File.Create("account.json");
                fs.Close();
                return null;
            }
           
        }

        public void Writejs(List<account> list) // luu them tai khoan vao file json
        {
            string json = JsonConvert.SerializeObject(list);
            json = json.Insert(1, "\n");
            json = json.Insert(json.Length - 1, "\n");
            int i;
            for (i = 0; i < json.Length; i++)
            {
                if (json[i].ToString() == "}" && json[i + 1].ToString() == ",")
                {
                    json = json.Insert(i + 2, "\n");
                }
            }
            File.WriteAllText("account.json", json);
        }
        public FrmLogin()
        {
            _StaffService = new StaffService();
            InitializeComponent();
            LoginStatus = LoginStatus.None;
            this.ControlBox = false;

            if(Readjs() != null)
            {
                List<account> list = Readjs();
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        cbbUsername.Items.Add(list[i].username);
                    }
                }
            }
            
            //this.txtPassword.Text = "02082015";
            //this.cbbUsername.Text = "thieunv";
            cbbUsername.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(cbbUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(Properties.Resources.NotInputMessage, Properties.Resources.Error);
                    return;
                }
                else
                {
                    if (_StaffService.Login(cbbUsername.Text, txtPassword.Text))
                    {
                        LoginStatus = LoginStatus.Login;
                        CurrentStaffId = _StaffService.GetIdByUserPass(cbbUsername.Text, txtPassword.Text);
                        this.Hide();
                        if (ceLuuMatKhau.Checked == true)
                        {

                            account acc = new account();
                            acc.username = cbbUsername.Text;
                            acc.password = txtPassword.Text;
                            
                            if(Readjs() != null)
                            {
                                List<account> list = Readjs();
                                int key = 1;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i].username == acc.username && list[i].password == acc.password)
                                    {
                                        key = 0;
                                        break;
                                    }
                                    else if(list[i].username == acc.username && list[i].password != acc.password)
                                    {
                                        list[i].password = acc.password;
                                        Writejs(list);
                                        key = 0;
                                        break;
                                    }
                                }
                                if (key == 1)
                                {
                                    list.Add(acc);
                                    Writejs(list);
                                }
                            }
                            else
                            {
                                List<account> list = new List<account>();
                                list.Add(acc);
                                Writejs(list);
                            }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.NotLoginMessage, Properties.Resources.Notification);
                        txtPassword.Text = string.Empty;
                    }
                }
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(Properties.Resources.NotConnectServerMessage, Properties.Resources.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            LoginStatus = LoginStatus.Close;
            this.Close();
        }

        private void ceHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ceHienMatKhau.Checked)
                txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '*';
        }

        private void cbbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<account> list = Readjs();
            if (cbbUsername.SelectedIndex >= 0 && cbbUsername.SelectedIndex < list.Count)
            {
                txtPassword.Text = list[cbbUsername.SelectedIndex].password;
            }
        }
    }
}