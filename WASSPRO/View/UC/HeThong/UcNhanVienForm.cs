using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HeThong
{
    public partial class UcNhanVienForm : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcNhanVienForm()
        {
            InitializeComponent();
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            LoadLoaiNV();
            LoadPB();
            LoadNhanVien();
            LoadTo();
            cboCV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCV.DataSource = db.DM_CHUCVU.ToList();
            cboCV.ValueMember = "ChucvuID";
            cboCV.DisplayMember = "Tenchucvu";
        }

        private void LoadTo()
        {
            var groups = from a in db.DM_TO orderby a.TENTO select a;
            if (groups != null)
            {
                cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cboTo.DataSource = groups.ToList();
                cboTo.DisplayMember = "TENTO";
                cboTo.ValueMember = "TO_ID";
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

        private void LoadLoaiNV()
        {
            var groups = from a in db.DM_LOAINHANVIEN orderby a.Tenloai select a;
            if (groups != null)
            {
                groupListBox.DataSource = groups.ToList();
                groupListBox.DisplayMember = "tenloai";
                groupListBox.ValueMember = "id_loainv";
            }
        }

        private void LoadNhanVien()
        {
            var users = from a in db.NHANVIENs orderby a.hoten select a;
            if (users != null)
            {
                dataGridView1.DataSource = users.ToList();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
                SetSelectRow(0);
            }
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
            // this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (editButton.Text == "Sửa")
            {
                EnableControl(true);
                EditState();
            }
            else
            {
                if (!IsDataOK()) return;
                decimal pTOID = decimal.Parse(cboTo.SelectedValue.ToString());
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value.ToString());
                var nv = (from a in db.NHANVIENs where a.NV_ID == id select a).FirstOrDefault();
                int ChucvuID = int.Parse(cboCV.SelectedValue.ToString());
                nv.maNV = maNVtextBox.Text.Trim();
                nv.hoten = hotentextBox.Text.Trim();
                nv.ngaysinh = ngaysinhdateTimePicker.Value;
                nv.gioitinh = gioitinhcheckBox.Checked;
                nv.soCMND = cmndtextBox.Text;
                nv.ChucvuID = ChucvuID;
                nv.ngaycap = ngaycapdateTimePicker.Value;
                nv.noicap = noicaptextBox.Text;
                nv.diachithuongtru = diachi1textBox.Text;
                nv.diachitamtru = diachi2textBox.Text;
                nv.SDT_NV = sdt1textBox.Text;
                nv.SDT_codinh = sdt2textBox.Text;
                if (chkTo.Checked == true)
                    nv.TO_ID = pTOID;
                nv.maPB = ((QLCongNo.DM_PHONGBAN)(pbcheckedListBox.CheckedItems[0])).maPB;
                // Loại nhân viên
                // Xóa các loại NV hiện có
                var loaiNVs = (from a in db.NHANVIEN_LNV where a.NV_ID == id select a).ToList();
                if (loaiNVs.Count > 0)
                {
                    foreach (NHANVIEN_LNV loaiNV in loaiNVs)
                        db.NHANVIEN_LNV.Remove(loaiNV);
                }
                // Thêm mới loại NV
                for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
                {
                    NHANVIEN_LNV nv_loaiNV = new NHANVIEN_LNV();
                    nv_loaiNV.NV_ID = id;
                    nv_loaiNV.ID_LoaiNV = ((QLCongNo.DM_LOAINHANVIEN)(groupListBox.CheckedItems[ListIndex])).ID_LoaiNV;
                    db.NHANVIEN_LNV.Add(nv_loaiNV);
                } // for
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DefaultState();
                LoadNhanVien();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[idColumn.Name].Value) == id)
                    {
                        SetSelectRow(i);
                        break;
                    }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (addButton.Text == "Thêm")
            {
                ClearText();
                EnableControl(true);
                AddState();
                hotentextBox.Focus();
            }
            else
            {
                if (!IsDataOK()) return;
                decimal pTOID = decimal.Parse(cboTo.SelectedValue.ToString());
                int ChucvuID = int.Parse(cboCV.SelectedValue.ToString());
                NHANVIEN nv = new NHANVIEN();
                nv.maNV = maNVtextBox.Text.Trim();
                nv.hoten = hotentextBox.Text.Trim();
                nv.ngaysinh = ngaysinhdateTimePicker.Value;
                nv.gioitinh = gioitinhcheckBox.Checked;
                nv.soCMND = cmndtextBox.Text;
                nv.ngaycap = ngaycapdateTimePicker.Value;
                nv.noicap = noicaptextBox.Text;
                nv.diachithuongtru = diachi1textBox.Text;
                nv.diachitamtru = diachi2textBox.Text;
                nv.SDT_NV = sdt1textBox.Text;
                nv.ChucvuID = ChucvuID;
                nv.SDT_codinh = sdt2textBox.Text;
                nv.isxoathanhtoan = false;
                if (chkTo.Checked == true)
                    nv.TO_ID = pTOID;
                nv.maPB = ((QLCongNo.DM_PHONGBAN)(pbcheckedListBox.CheckedItems[0])).maPB;
                nv.TO_ID = pTOID;
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                // Thêm mới loại NV
                decimal nv_id = (from a in db.NHANVIENs where a.maNV == maNVtextBox.Text select a.NV_ID).FirstOrDefault();
                for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
                {
                    NHANVIEN_LNV nv_loaiNV = new NHANVIEN_LNV();
                    nv_loaiNV.NV_ID = nv_id;
                    nv_loaiNV.ID_LoaiNV = ((QLCongNo.DM_LOAINHANVIEN)(groupListBox.CheckedItems[ListIndex])).ID_LoaiNV;
                    db.NHANVIEN_LNV.Add(nv_loaiNV);
                } // for
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien();
                DefaultState();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value.ToString());
                var nv = (from a in db.NHANVIENs where a.NV_ID == id select a).FirstOrDefault();
                var nguoidung = db.NGUOIDUNGs.Where(x => x.manv == nv.maNV).FirstOrDefault();
                if (nguoidung != null)
                {
                    var nguoidungquyen = db.NGUOIDUNG_QUYEN.Where(x => x.nguoidung_id == nguoidung.nguoidung_id).ToList();
                    db.NGUOIDUNG_QUYEN.RemoveRange(nguoidungquyen);
                    db.NGUOIDUNGs.Remove(nguoidung);
                    db.SaveChanges();
                }

                var nhanvienLNV = db.NHANVIEN_LNV.Where(x => x.NV_ID == nv.NV_ID).ToList();
                var giaophieu = db.GiaoPhieux.Where(x => x.id_nv == nv.NV_ID).ToList();
                db.NHANVIEN_LNV.RemoveRange(nhanvienLNV);
                db.GiaoPhieux.RemoveRange(giaophieu);
                db.NHANVIENs.Remove(nv);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien();
                ClearText();
                //SetSelectRow(0);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //catch
            //{
            //    MessageBox.Show("Không xóa được nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DefaultState();
            SetSelectRow(0);
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            TimKiem(maNVtextBox.Text);
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void DefaultState()
        {
            addButton.Text = "Thêm";
            editButton.Text = "Sửa";
            addButton.Enabled = true;
            editButton.Enabled = true;
            deleteButton.Enabled = true;
            EnableControl(false);
        }

        private void EditState()
        {
            editButton.Text = "Lưu";
            addButton.Enabled = false;
            deleteButton.Enabled = false;
            cancelButton.Enabled = true;
        }

        private void AddState()
        {
            addButton.Text = "Lưu";
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            cancelButton.Enabled = true;
        }

        private void EnableControl(bool p)
        {
            maNVtextBox.Enabled = p;
            hotentextBox.Enabled = p;
            gioitinhcheckBox.Enabled = p;
            ngaysinhdateTimePicker.Enabled = p;
            cmndtextBox.Enabled = p;
            ngaycapdateTimePicker.Enabled = p;
            noicaptextBox.Enabled = p;
            diachi1textBox.Enabled = p;
            diachi2textBox.Enabled = p;
            sdt1textBox.Enabled = p;
            sdt2textBox.Enabled = p;
            groupListBox.Enabled = p;
            pbcheckedListBox.Enabled = p;
            dataGridView1.Enabled = !p;
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
            noicaptextBox.Text = row.Cells[noicapColumn.Name].Value != null ? row.Cells[noicapColumn.Name].Value.ToString() : "";
            diachi1textBox.Text = row.Cells[diachi1Column.Name].Value != null ? row.Cells[diachi1Column.Name].Value.ToString() : "";
            diachi2textBox.Text = row.Cells[diachi2Column.Name].Value != null ? row.Cells[diachi2Column.Name].Value.ToString() : "";
            sdt1textBox.Text = row.Cells[sdtColumn.Name].Value != null ? row.Cells[sdtColumn.Name].Value.ToString() : "";
            sdt2textBox.Text = row.Cells[sdt2Column.Name].Value != null ? row.Cells[sdt2Column.Name].Value.ToString() : "";
            // Loại nhân viên
            int nv_id = Convert.ToInt32(row.Cells[idColumn.Name].Value);
            var objNhanvien = db.NHANVIENs.Where(x => x.NV_ID == nv_id).FirstOrDefault();
            //cboCV.SelectedValue = objNhanvien.ChucvuID;
            if (objNhanvien != null && objNhanvien.ChucvuID != null)
            {
                cboCV.SelectedValue = objNhanvien.ChucvuID;
            }
            else
            {
                cboCV.SelectedIndex = -1; 
                MessageBox.Show("Không tìm thấy chức vụ cho nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var loaiNVs = from a in db.NHANVIEN_LNV where a.NV_ID == nv_id select a;
            foreach (NHANVIEN_LNV loaiNV in loaiNVs.ToList())
            {
                for (int i = 0; i < groupListBox.Items.Count; i++)
                {
                    if (((QLCongNo.DM_LOAINHANVIEN)(groupListBox.Items[i])).ID_LoaiNV == loaiNV.ID_LoaiNV)
                    {
                        // set selected item as checked
                        groupListBox.SetItemChecked(i, true);
                    }
                }
            }
            // Phòng ban
            for (int i = 0; i < pbcheckedListBox.Items.Count; i++)
            {
                if (((QLCongNo.DM_PHONGBAN)(pbcheckedListBox.Items[i])).maPB == dataGridView1.SelectedRows[0].Cells[pbColumn.Name].Value.ToString())
                {
                    pbcheckedListBox.SetItemChecked(i, true);
                    break;
                }
            }
        }

        private void ClearText()
        {
            maNVtextBox.Text = "";
            hotentextBox.Text = "";
            ngaysinhdateTimePicker.Value = DateTime.Now;
            cmndtextBox.Text = "";
            ngaycapdateTimePicker.Value = DateTime.Now;
            noicaptextBox.Text = "";
            diachi1textBox.Text = "";
            diachi2textBox.Text = "";
            sdt1textBox.Text = "";
            sdt2textBox.Text = "";
            for (int i = 0; i < groupListBox.Items.Count; i++)
            {
                groupListBox.SetItemChecked(i, false);
                groupListBox.ClearSelected();
            }
            for (int i = 0; i < pbcheckedListBox.Items.Count; i++)
            {
                pbcheckedListBox.SetItemChecked(i, false);
                pbcheckedListBox.ClearSelected();
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

        private bool IsDataOK()
        {
            if (maNVtextBox.Text.Trim() == "" || groupListBox.CheckedItems.Count == 0 || pbcheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Thông tin chưa đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (addButton.Enabled)
            {
                var list = (from a in db.NHANVIENs where a.maNV == maNVtextBox.Text.Trim() select a.maNV).ToList();
                if (list.Count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void groupListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int ListIndex;
            groupListBox.ItemCheck -= groupListBox_ItemCheck;

            for (ListIndex = 0; ListIndex < groupListBox.Items.Count; ListIndex++)
            {
                if (groupListBox.SelectedIndex == ListIndex)
                {
                    // set selected item as checked
                    groupListBox.SetItemChecked(ListIndex, true);
                }
            } // for
            groupListBox.ItemCheck += groupListBox_ItemCheck;
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

        private void groupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ListIndex;
            groupListBox.SelectedIndexChanged -= groupListBox_SelectedIndexChanged;

            for (ListIndex = 0; ListIndex < groupListBox.Items.Count; ListIndex++)
            {
                // Unchecked all items that is not currently selected
                if (groupListBox.SelectedIndex == ListIndex)
                {
                    // set selected item as checked
                    groupListBox.SetItemChecked(ListIndex, true);
                }
            } // for
            groupListBox.SelectedIndexChanged += groupListBox_SelectedIndexChanged;
        }

        private void pbcheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ListIndex;
            pbcheckedListBox.SelectedIndexChanged -= pbcheckedListBox_SelectedIndexChanged;

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
            pbcheckedListBox.SelectedIndexChanged += pbcheckedListBox_SelectedIndexChanged;
        }

        private void maNVtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                TimKiem(maNVtextBox.Text);
        }

        private void TimKiem(string manv)
        {
            decimal pTOID = decimal.Parse(cboTo.SelectedValue.ToString());
            var nhanvien = db.NHANVIENs.ToList();
            if (chkTo.Checked == true)
                nhanvien = nhanvien.Where(x => x.TO_ID == pTOID).ToList();
            if (nhanvien != null)
            {
                dataGridView1.DataSource = nhanvien.ToList();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
            }
            else
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}