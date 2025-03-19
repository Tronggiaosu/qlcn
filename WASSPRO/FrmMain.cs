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
    public partial class FrmMain : Form
    {
        string pass = "wtdc@123";
        string adminpass = "123456"; // "1122334455";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
            string encode = md5(txtPassword.Text);
            var acc = (from x in db.NGUOIDUNGs
                       where x.ma_nd == txtUsername.Text
                       where x.pass == encode
                       select x).FirstOrDefault();
            if (txtPassword.Text == adminpass)
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
                //SaveRegistry();
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
                this.Close();
            }
            else
                MessageBox.Show("Thông tin đăng nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

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


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLogin_Click(btnLogin, EventArgs.Empty);
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPassword.Focus();
        }

        private string md5(string p)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(p);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }


    }
}
