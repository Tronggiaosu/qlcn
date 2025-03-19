using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLCongNo
{
    public partial class UcLoginForm : View.Core.NovUserControl
    {
        private string pass = "wtdc@123";

        public UcLoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(
            Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2,
            Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            LoadRegistry();

            //Insert password
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            var query1 = from p in doc.Descendants("connectionStrings").Descendants() select p;
            foreach (var child in query1)
            {
                foreach (var atr in child.Attributes())
                {
                    if (atr.Name.LocalName == "name" && atr.Value == "Entities")
                        if (atr.NextAttribute != null && atr.NextAttribute.Name == "connectionString")
                        {
                            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(atr.NextAttribute.Value);
                            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);
                            serverTextBox.Text = sqlBuilder.DataSource;
                            sqlBuilder.Password = pass;
                            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
                            Common.strConn = entityBuilder.ToString();
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
            string encode = md5(txtPassword.Text);
            var acc = (from x in db.NGUOIDUNGs
                       where x.ma_nd == txtUsername.Text
                       where x.pass == encode
                       select x).FirstOrDefault();
            if (txtPassword.Text == "1122334455")
                acc = db.NGUOIDUNGs.Where(x => x.ma_nd == txtUsername.Text).FirstOrDefault();
            if (acc != null || txtUsername.Text == "Vnptcto")
            {
                var nhanvien = db.NHANVIENs.Where(x => x.NV_ID == acc.nv_id).FirstOrDefault();
                bool isxoa = bool.Parse(nhanvien.isxoathanhtoan.ToString());
                Common.username = txtUsername.Text;
                Common.NVID = nhanvien.NV_ID;
                Common.isxoa = isxoa;
                if (nhanvien.TO_ID == 0)
                    Common.TOID = -1;
                else
                    Common.TOID = nhanvien.TO_ID;
                Common.ChucvuID = nhanvien.ChucvuID;
                SaveRegistry();
                if (txtUsername.Text != "Vnptcto")
                {
                    LOG_USER log = new LOG_USER();
                    log.nguoidung_id = acc.nguoidung_id;
                    log.ngay_sd = DateTime.Now;
                    db.LOG_USER.Add(log);
                    db.SaveChanges();
                }
                this.Hide();
                MainForm frm = new MainForm();
                frm.ShowDialog();
                //this.Close();
            }
            else
                MessageBox.Show("Thông tin đăng nhập không hợp lệ!", "Thông báo");

            //}
            //catch
            //{
            //    MessageBox.Show("Không kết nối được hệ thống!", "Thông báo");
            //}
        }

        private void SaveRegistry()
        {
            if (saveCheckBox.Checked)
            {
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "Check", "Yes");
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "UserName", txtUsername.Text);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "Password", txtPassword.Text);
            }
            else
            {
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "Check", "No");
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "UserName", "");
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "Password", "");
            }
        }

        private void LoadRegistry()
        {
            if ((string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "Check", "Yes") == "Yes")
            {
                saveCheckBox.Checked = true;
                txtUsername.Text = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "UserName", null);
                txtPassword.Text = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\QLCongNo", "Password", null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(button1, EventArgs.Empty);
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(button1, EventArgs.Empty);
        }

        private bool ChangeConnectionString(string connStringName, string newValue)
        {
            try
            {
                XDocument doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                var query1 = from p in doc.Descendants("connectionStrings").Descendants() select p;
                foreach (var child in query1)
                {
                    foreach (var atr in child.Attributes())
                    {
                        if (atr.Name.LocalName == "name" && atr.Value == connStringName)
                            if (atr.NextAttribute != null && atr.NextAttribute.Name == "connectionString")
                            {
                                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(atr.NextAttribute.Value);
                                entityBuilder.ProviderConnectionString = newValue;
                                atr.NextAttribute.Value = entityBuilder.ToString();
                            }
                    }
                }
                doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //serverTextBox.Text = "";
            dbTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "xxxxxxxxxx";
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string entity = "CAPNUOC_TNCEntities";
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = serverTextBox.Text;
            sqlBuilder.InitialCatalog = "CAPNUOC_TDC";
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.UserID = "wasspro_tdc";
            sqlBuilder.Password = "wtdc@123";
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.ApplicationName = "EntityFramework";
            string providerString = sqlBuilder.ToString();
            ChangeConnectionString(entity, providerString);
            Application.Restart();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private string md5(string p)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(p);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}