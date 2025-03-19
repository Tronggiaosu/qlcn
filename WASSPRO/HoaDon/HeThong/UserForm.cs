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

    public partial class UserForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        decimal nguoidung_id = 0;
        string manv = "";
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            LoadPB();
            LoadNhom();
        }

        private void LoadNhom()
        {
            var groups = from a in db.DM_QUYEN orderby a.tenquyen select a;
            if (groups != null)
            {
                nhomcheckedListBox.DataSource = groups.ToList();
                nhomcheckedListBox.DisplayMember = "tenquyen";
                nhomcheckedListBox.ValueMember = "quyen_id";
            }
        }

        private void LoadPB()
        {
            var groups = from a in db.DM_PHONGBAN orderby a.tenPB select a;
            if (groups != null)
            {
                pbcheckedListBox.DataSource = groups.ToList();
                pbcheckedListBox.DisplayMember = "tenpb";
                pbcheckedListBox.ValueMember = "mapb";
            }
        }

        private void LoadUser()
        {
            var users = from u in db.NGUOIDUNGs select u;
            if (users != null)
            {
                dataGridView1.DataSource = users.ToList();
                SetSelectRow(0);
            }
        }

        private void pbcheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int ListIndex;

            pbcheckedListBox.ItemCheck -= pbcheckedListBox_ItemCheck;

            for (ListIndex = 0; ListIndex < pbcheckedListBox.Items.Count; ListIndex++)
            {
                // Unchecked all items that is not currently selected
                if (pbcheckedListBox.SelectedIndex != ListIndex)
                {
                    // set item as unchecked
                    pbcheckedListBox.SetItemChecked(ListIndex, false);
                } // if
                else
                {
                    // set selected item as checked
                    pbcheckedListBox.SetItemChecked(ListIndex, true);
                }
            } // for
            pbcheckedListBox.ItemCheck += pbcheckedListBox_ItemCheck;
        }

        private void pbcheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ListIndex;
            pbcheckedListBox.SelectedIndexChanged -= pbcheckedListBox_SelectedIndexChanged;

            for (ListIndex = 0;
                 ListIndex < pbcheckedListBox.Items.Count;
                 ListIndex++)
            {
                // Unchecked all items that is not currently selected
                if (pbcheckedListBox.SelectedIndex != ListIndex)
                {
                    // set item as unchecked
                    pbcheckedListBox.SetItemChecked(ListIndex, false);
                } // if
                else
                {
                    // set selected item as checked
                    pbcheckedListBox.SetItemChecked(ListIndex, true);
                }
            } // for
            pbcheckedListBox.SelectedIndexChanged += pbcheckedListBox_SelectedIndexChanged;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                DisplayText(row);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (manv == "")
                {
                    MessageBox.Show("Chưa chọn nhân viên để tạo tài khoản!");
                    return;
                }
                if (!IsDataOK()) return;
                if (nguoidung_id == 0) //chưa có tài khoản
                {
                    var nhanvien = db.NHANVIENs.Where(x => x.maNV == maNVtextBox.Text).FirstOrDefault();
                    NGUOIDUNG nd = new NGUOIDUNG();
                    nd.ma_nd = usernametextBox.Text;
                    nd.pass = md5("123456");
                    nd.manv = manv;
                    nd.isLock = chkLock.Checked;
                    nd.macaddress = txtMAC.Text;
                    nd.modelname = txtSerial.Text;
                    nd.nv_id = nhanvien.NV_ID;
                    db.NGUOIDUNGs.Add(nd);
                    db.SaveChanges();
                    nguoidung_id = (from a in db.NGUOIDUNGs where a.manv == manv select a.nguoidung_id).FirstOrDefault();
                    // Thêm mới quyền
                    for (int ListIndex = 0; ListIndex < nhomcheckedListBox.CheckedItems.Count; ListIndex++)
                    {
                        NGUOIDUNG_QUYEN nd_q_1 = new NGUOIDUNG_QUYEN();
                        nd_q_1.nguoidung_id = nguoidung_id;
                        nd_q_1.quyen_id = ((QLCongNo.DM_QUYEN)(nhomcheckedListBox.CheckedItems[ListIndex])).quyen_id;
                        db.NGUOIDUNG_QUYEN.Add(nd_q_1);
                        db.SaveChanges();
                    } // for

                    var pnhanvien = db.NHANVIENs.Where(x => x.NV_ID == nhanvien.NV_ID).FirstOrDefault();
                    pnhanvien.somay = usernametextBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công! Mật khẩu mặc định: 123456", "Thông báo");
                }
                else //edit
                {
                    var nhanvien = db.NHANVIENs.Where(x => x.maNV == maNVtextBox.Text).FirstOrDefault();
                    var nguoidung = (from a in db.NGUOIDUNGs where a.nguoidung_id == nguoidung_id select a).FirstOrDefault();
                    nguoidung.ma_nd = usernametextBox.Text;
                    nguoidung.isLock = chkLock.Checked;
                    nguoidung.macaddress = txtMAC.Text;
                    nguoidung.modelname = txtSerial.Text;
                    nguoidung.nv_id = nhanvien.NV_ID;
                    // Xóa các quyền hiện có
                    var nd_q = (from a in db.NGUOIDUNG_QUYEN where a.nguoidung_id == nguoidung_id select a).ToList();
                    if (nd_q.Count > 0)
                    {
                        foreach (NGUOIDUNG_QUYEN nd_q_1 in nd_q)
                            db.NGUOIDUNG_QUYEN.Remove(nd_q_1);
                    }
                    // Thêm mới quyền
                    for (int ListIndex = 0; ListIndex < nhomcheckedListBox.CheckedItems.Count; ListIndex++)
                    {
                        NGUOIDUNG_QUYEN nd_q_1 = new NGUOIDUNG_QUYEN();
                        nd_q_1.nguoidung_id = nguoidung_id;
                        nd_q_1.quyen_id = ((QLCongNo.DM_QUYEN)(nhomcheckedListBox.CheckedItems[ListIndex])).quyen_id;
                        db.NGUOIDUNG_QUYEN.Add(nd_q_1);
                        db.SaveChanges();
                    } // for
                    var pnhanvien = db.NHANVIENs.Where(x => x.NV_ID == nhanvien.NV_ID).FirstOrDefault();
                    pnhanvien.somay = usernametextBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }
                db.SaveChanges();
            }
            catch { }
        }

        private bool IsDataOK()
        {
            if (usernametextBox.Text.Trim() == "")
            {
                MessageBox.Show("Chưa có tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (nguoidung_id == 0)
                {
                    var list = (from a in db.NGUOIDUNGs where a.ma_nd == usernametextBox.Text.Trim() select a.ma_nd).ToList();
                    if (list.Count > 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            return true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (pbcheckedListBox.CheckedItems.Count == 0) return;
            string mapb = ((QLCongNo.DM_PHONGBAN)(pbcheckedListBox.CheckedItems[0])).maPB;
            var nv = (from a in db.NHANVIENs where a.maPB == mapb select a).ToList();
            if (nv.Count > 0)
            {
                dataGridView1.DataSource = nv;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
            }
            else
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo");
        }     

        private void DisplayText(DataGridViewRow row)
        {
            ClearText();
            maNVtextBox.Text = row.Cells[manvColumn.Name].Value != null ? row.Cells[manvColumn.Name].Value.ToString() : "";
            hotentextBox.Text = row.Cells[hotenColumn.Name].Value != null ? row.Cells[hotenColumn.Name].Value.ToString() : "";
            ngaysinhdateTimePicker.Value = row.Cells[ngaysinhColumn.Name].Value != null ? (DateTime)row.Cells[ngaysinhColumn.Name].Value : DateTime.Now;
            gioitinhcheckBox.Checked = row.Cells[gioitinhColumn.Name].Value != null ? (bool)row.Cells[gioitinhColumn.Name].Value : true;
            cmndtextBox.Text = row.Cells[cmndColumn.Name].Value != null ? row.Cells[cmndColumn.Name].Value.ToString() : "";
            ngaycapdateTimePicker.Value = row.Cells[ngaycapColumn.Name].Value != null ? (DateTime)row.Cells[ngaycapColumn.Name].Value : DateTime.Now;
            diachi1textBox.Text = row.Cells[diachi1Column.Name].Value != null ? row.Cells[diachi1Column.Name].Value.ToString() : "";
            diachi2textBox.Text = row.Cells[diachi2Column.Name].Value != null ? row.Cells[diachi2Column.Name].Value.ToString() : "";
            sdt1textBox.Text = row.Cells[sdtColumn.Name].Value != null ? row.Cells[sdtColumn.Name].Value.ToString() : "";
            sdt2textBox.Text = row.Cells[sdt2Column.Name].Value != null ? row.Cells[sdt2Column.Name].Value.ToString() : "";          
            for (int i = 0; i < pbcheckedListBox.Items.Count; i++)
            {
                if (((QLCongNo.DM_PHONGBAN)(pbcheckedListBox.Items[i])).maPB == dataGridView1.SelectedRows[0].Cells[pbColumn.Name].Value.ToString())
                {
                    pbcheckedListBox.SetItemChecked(i, true);
                    break;
                }
            }       
            //Phần người dùng
            manv = row.Cells[manvColumn.Name].Value.ToString();
            var nguoidung = (from a in db.NGUOIDUNGs where a.manv == manv select a).FirstOrDefault();
            if (nguoidung != null)
            {
                usernametextBox.Text = nguoidung.ma_nd;
                chkLock.Checked = (bool)nguoidung.isLock;
                txtMAC.Text = nguoidung.macaddress;
                txtSerial.Text = nguoidung.modelname;
                nguoidung_id = nguoidung.nguoidung_id;
                var quyen = from a in db.NGUOIDUNG_QUYEN where a.nguoidung_id == nguoidung_id select a;
                foreach (NGUOIDUNG_QUYEN nd_q in quyen.ToList())
                {
                    for (int i = 0; i < nhomcheckedListBox.Items.Count; i++)
                    {
                        if (((QLCongNo.DM_QUYEN)(nhomcheckedListBox.Items[i])).quyen_id == nd_q.quyen_id)
                        {
                            // set selected item as checked
                            nhomcheckedListBox.SetItemChecked(i, true);
                        }
                    }
                }
            }
            else nguoidung_id = 0;
        }

        private void ClearText()
        {
            maNVtextBox.Text = "";
            hotentextBox.Text = "";
            ngaysinhdateTimePicker.Value = DateTime.Now;
            cmndtextBox.Text = "";
            ngaycapdateTimePicker.Value = DateTime.Now;
            diachi1textBox.Text = "";
            diachi2textBox.Text = "";
            sdt1textBox.Text = "";
            sdt2textBox.Text = "";
            usernametextBox.Text = "";
            txtMAC.Text = "";
            txtSerial.Text = "";
            for (int i = 0; i < nhomcheckedListBox.Items.Count; i++)
            {
                nhomcheckedListBox.SetItemChecked(i, false);
            } 
        }
        private void SetSelectRow(int i)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = null;

                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
            }
        }
        private string md5(string p)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(p);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        private void resetPassButton_Click(object sender, EventArgs e)
        {
            if (nguoidung_id == 0) return;
            var nd = (from a in db.NGUOIDUNGs where a.nguoidung_id == nguoidung_id select a).FirstOrDefault();
            nd.pass = md5("123456");
            db.SaveChanges();
            MessageBox.Show("Reset mật khẩu thành công, mật khẩu mặc định: 123456", "Thông báo");
        }

        private void nhomcheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            nhomcheckedListBox.SelectedIndexChanged -= nhomcheckedListBox_SelectedIndexChanged;

            for (int ListIndex = 0; ListIndex < nhomcheckedListBox.Items.Count; ListIndex++)
            {
                if (nhomcheckedListBox.SelectedIndex == ListIndex)
                {
                    // set selected item as checked
                    nhomcheckedListBox.SetItemChecked(ListIndex, true);
                }
            } // for
            nhomcheckedListBox.SelectedIndexChanged += nhomcheckedListBox_SelectedIndexChanged;
        }

        private void maNVtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                var nv = (from a in db.NHANVIENs where a.maNV == maNVtextBox.Text select a).ToList();
                if (nv.Count > 0)
                {
                    dataGridView1.DataSource = nv;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                        dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
                }
                else
                    MessageBox.Show("Không tìm thấy thông tin!", "Thông báo");
            }
        }

       
    }
}
