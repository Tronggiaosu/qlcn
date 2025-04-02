using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QLCongNo.View.Core
{
    public partial class FrmSMS : Form
    {
        private readonly string projectID = "PJ_CONGNO";

        private readonly string accessID = "CSKH02";

        private readonly string accessKey = "bAdxxSrurNEmEz6fMh28dz1Syqg2JO7dNpbvlYQYVDWUgkwRrKJepBTYn3Usjns9ixUuF/PR3r4ZTjaZKVou1jJ0tY79UnO7cYFvfBsl8I5+O6McKQP+YdgYr27xPQ1TwKknxLNyCI4sxMqITzHoag==";

        private Dictionary<string, object[]> danhsach = new Dictionary<string, object[]>();

        public string Title
        {
            set
            {
                this.lblTitle.Text = $"Send SMS - {value}";
            }
        }
        public string Type
        {
            set
            {
                this.txtType.Text = value;
            }
        }

        public string DanhBo
        {
            set
            {
                this.txtDanhBo.Text = value;
            }
        }

        public string HoTen
        {
            set
            {
                this.txtKhachHang.Text = value;
            }
        }

        public string SDT
        {
            set
            {
                this.txtDienThoai.Text = value;
            }
        }

        public string ThongTin
        {
            set
            {
                this.txtThongTin.Text = value;
            }
        }

        public string LoaiHD { get; set; }

        public Dictionary<string, object[]> DanhSach
        {
            get => this.danhsach;
            set
            {
                this.danhsach = value;
                if (value != null && value.Count > 0)
                {
                    this.btnSend.Text = "Gửi đồng loạt";
                    this.btnSend.BackColor = Color.Teal;
                    this.lblDS.Visible = true;
                    this.lblDS.Text = $"Danh sách gồm {value.Count} khách hàng";
                    
                    Reset();
                }
                else
                {
                    this.btnSend.Text = "Gửi tin nhắn";
                    this.btnSend.BackColor = Color.SteelBlue;
                    this.lblDS.Visible = false;
                }
            }
        }

        public FrmSMS()
        {
            InitializeComponent();
            this.btnSend.Click += (sender, e) => SendSMS();
            this.ptbClose.Click += (sender, e) =>
            {
                var dialog = MessageBox.Show("Chắc chắn thoát khỏi trang này?", "Thông báo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Close();
                }
                else return;
            };
        }

        private void SendSMS()
        {
            try
            {
                var serviceID = this.accessID;
                var serviceKey = this.accessKey;
                var projectID = this.projectID;
                var appName = this.lblTitle.Text;
                var accID = Common.username;
                var type = this.txtType.Text;
                var phones = new List<string>();
                var smsContent = this.txtNoiDung.Text;
                var deviceID = GetDeviceID();
                var tag = String.Empty;

                var data = new string[4];
                var danhbo = String.Empty;
                var hoten = String.Empty;
                var thongtin = String.Empty;

                if (type.Equals("SMS_HOADON_NO") ||
                    type.Equals("SMS_HOADON_MOI") ||
                    type.Equals("SMS_HOADON_THANHTOAN"))
                {
                    //Send SMS to one person
                    var phone = this.txtDienThoai.Text;
                    danhbo = this.txtDanhBo.Text;
                    hoten = this.txtKhachHang.Text;
                    thongtin = this.txtThongTin.Text;

                    phones.Add(phone);
                }
                else 
                {
                    //Send SMS to multi people
                    foreach (var item in this.danhsach)
                    {
                        var sohopdong = item.Value.ToArray()[0] as string;
                        var phone = item.Value.ToArray()[2] as string;
                        danhbo = item.Key as string;
                        hoten = item.Value.ToArray()[1] as string;
                        thongtin = item.Value.ToArray()[4] as string;

                        phones.Add(phone);
                    }
                }

                data[0] = "01";
                data[1] = danhbo;
                data[2] = hoten;
                data[3] = thongtin;

                //Call API
                AccountTDC.Account account = new AccountTDC.Account();
                var result = account.CSKH_SendSMS(serviceID, serviceKey, projectID, appName, accID, type, phones.ToArray(), data, smsContent, deviceID, tag);
                if (result[1] == "SUCCESS")
                    MessageBox.Show("Gửi SMS thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Gửi SMS thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { 
                var msg = ex.ToString();
            }
        }

        public static string GetDeviceID()
        {
            var appID = Guid.NewGuid().ToString();
            return appID;
        }

        private void Reset()
        {
            this.txtKhachHang.Text = String.Empty;
            this.txtDanhBo.Text = String.Empty;
            this.txtDienThoai.Text = String.Empty;
            this.txtThongTin.Text = String.Empty;
            this.txtNoiDung.Text = String.Empty;
        }
    }
}
