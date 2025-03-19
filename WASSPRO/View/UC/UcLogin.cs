using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using QLCongNo.Core.Extension;
using QLCongNo.View.Core;

namespace QLCongNo
{
    public partial class UcLogin : NovUserControl
    {
        private readonly string _pass = "wtdc@123";
        private readonly string _adminpass = "123456";
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        /// <summary>
        /// Event triggered when login is successful.
        /// </summary>
        public event EventHandler LoginSuccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="UcLogin"/> class.
        /// </summary>
        public UcLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Insert password
            var doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            var connectionStringElement = doc.Descendants("connectionStrings")
                                             .Elements()
                                             .FirstOrDefault(p => p.Attribute("name")?.Value == "Entities");

            if (connectionStringElement != null)
            {
                var connectionStringAttr = connectionStringElement.Attribute("connectionString");
                if (connectionStringAttr != null)
                {
                    // TODO : VIET : why override this password?
                    var entityBuilder = new EntityConnectionStringBuilder(connectionStringAttr.Value);
                    var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString)
                    {
                        Password = _pass
                    };

                    lblServer.Text = $"{sqlBuilder.InitialCatalog}/{sqlBuilder.DataSource} VERSION: 1.2";
                    entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
                    Common.strConn = entityBuilder.ToString();
                }
            }
            RegisterEvent();
            txtUsername.Focus();
        }

        /// <summary>
        /// Registers event handlers for the controls.
        /// </summary>
        private void RegisterEvent()
        {
            txtPassword.GotFocus += (sender, e) => { ClearMessage(); };
            txtUsername.GotFocus += (sender, e) => { ClearMessage(); };
            btnLogin.Click += new EventHandler(this.btnLogin_Click);
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtUsername.KeyPress += new KeyPressEventHandler(this.txtUsername_KeyPress);
        }

        /// <summary>
        /// Handles the login button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (var db = new CAPNUOC_TNCEntities())
                {
                    // hash password
                    string encode = txtPassword.Text.ComputeMd5Hash();

                    // get user info
                    var acc = db.NGUOIDUNGs.FirstOrDefault(x => x.ma_nd == txtUsername.Text && x.pass == encode);

                    // check admin password
                    if (txtPassword.Text == _adminpass)
                    {
                        // get user without password
                        acc = db.NGUOIDUNGs.FirstOrDefault(x => x.ma_nd == txtUsername.Text);
                    }

                    // user is valid or is admin
                    if (acc != null || txtUsername.Text == "Vnptcto")
                    {
                        // get employee info
                        var nhanvien = db.NHANVIENs.FirstOrDefault(x => x.NV_ID == acc.nv_id);
                        if (nhanvien != null)
                        {
                            //save user info into common variable
                            SetCommonFields(txtUsername.Text, nhanvien);

                            // save login log
                            if (txtUsername.Text != "Vnptcto")
                            {
                                var log = new LOG_USER
                                {
                                    nguoidung_id = acc.nguoidung_id,
                                    ngay_sd = DateTime.Now
                                };
                                db.LOG_USER.Add(log);
                                db.SaveChanges();
                            }

                            // raise an event to notify the login success
                            OnLoginSuccess(EventArgs.Empty);
                        }
                    }
                    else
                    {
                        SetMessage("Thông tin đăng nhập không đúng!");
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Vui lòng kết nối WiFi công ty hoặc bật VPN để sử dụng ứng dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Sets the message to be displayed on the form.
        /// </summary>
        /// <param name="msg">The message to display.</param>
        protected void SetMessage(string msg)
        {
            LblMsg.Text = msg;
            LblMsg.Visible = true;
        }

        /// <summary>
        /// Clears the message displayed on the form.
        /// </summary>
        protected void ClearMessage()
        {
            LblMsg.Text = string.Empty;
            LblMsg.Visible = false;
        }

        /// <summary>
        /// Raises the <see cref="LoginSuccess"/> event.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnLoginSuccess(EventArgs e)
        {
            SetMessage("Đăng nhập thành công");
            LoginSuccess?.Invoke(this, e);
        }

        /// <summary>
        /// Sets common fields for the application.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="nhanvien">The employee information.</param>
        private static void SetCommonFields(string username, NHANVIEN nhanvien)
        {
            Common.username = username;
            Common.NVID = nhanvien.NV_ID;
            Common.isxoa = nhanvien.isxoathanhtoan ?? false;
            Common.TOID = nhanvien.TO_ID == 0 ? -1 : nhanvien.TO_ID;
            Common.ChucvuID = nhanvien.ChucvuID;
        }

        /// <summary>
        /// Handles the password text box key press event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLogin_Click(btnLogin, EventArgs.Empty);
        }

        /// <summary>
        /// Handles the username text box key press event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPassword.Focus();
        }
    }
}