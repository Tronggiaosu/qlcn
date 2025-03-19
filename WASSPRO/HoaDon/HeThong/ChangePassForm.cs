using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class ChangePassForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public ChangePassForm()
        {
            InitializeComponent();
        }

        private void ChangePassForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Common.username;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            var user = (from u in db.NGUOIDUNGs where u.ma_nd == Common.username select u).FirstOrDefault();
            if (user.pass != md5(txtPassword.Text))
                MessageBox.Show("Mật khẩu cũ không đúng!");
            else
                if (txtNewPassword.Text != txtRetype.Text)
                    MessageBox.Show("Mật khẩu lặp lại không đúng!");
                else
                {
                    user.pass = md5(txtNewPassword.Text);
                    db.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Change();
        }

        private string md5(string p)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(p);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
