using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class UcDMGhiChuForm : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcDMGhiChuForm()
        {
            InitializeComponent();
        }

        private void DMGhiChuForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadLoaiYC();
            LoadGhiChu();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void LoadGhiChu()
        {
            var gc = from a in db.DM_GHICHU select new { a.ghichuid, a.noidung, a.DM_LOAIYEUCAU.tenloai_yc };
            if (gc != null)
                dataGridView1.DataSource = gc.ToList();
        }

        private void LoadLoaiYC()
        {
            var yc = from a in db.DM_LOAIYEUCAU select a;
            yccomboBox.DataSource = yc.ToList();
            yccomboBox.DisplayMember = "tenloai_yc";
            yccomboBox.ValueMember = "maloai_yc";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (editButton.Text == "Sửa")
            {
                EnableControl(true);
                txtGroupName.Focus();
                EditState();
            }
            else
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value.ToString());
                var editGroup = (from g in db.DM_GHICHU where g.ghichuid == id select g).FirstOrDefault();
                editGroup.noidung = txtGroupName.Text.Trim();
                editGroup.maloai_yc = yccomboBox.SelectedValue.ToString();
                db.SaveChanges();
                DefaultState();
                LoadGhiChu();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (addButton.Text == "Thêm")
            {
                ClearText();
                EnableControl(true);
                txtGroupName.Focus();
                AddState();
            }
            else
            {
                DM_GHICHU addGroup = new DM_GHICHU();
                addGroup.noidung = txtGroupName.Text.Trim();
                addGroup.maloai_yc = yccomboBox.SelectedValue.ToString();
                db.DM_GHICHU.Add(addGroup);
                db.SaveChanges();
                LoadGhiChu();
                DefaultState();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                var editGroup = (from g in db.DM_GHICHU where g.ghichuid == id select g).FirstOrDefault();
                db.DM_GHICHU.Remove(editGroup);
                db.SaveChanges();
                LoadGhiChu();
                ClearText();
                SetSelectRow(0);
            }
            catch
            {
                MessageBox.Show("Không xóa được nhóm này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DefaultState();
            SetSelectRow(0);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DisplayText(dataGridView1.SelectedRows[0]);
            }
        }

        private void DefaultState()
        {
            addButton.Text = "Thêm";
            editButton.Text = "Sửa";
            addButton.Enabled = true;
            editButton.Enabled = true;
            deleteButton.Enabled = true;
            cancelButton.Enabled = false;
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
            txtGroupName.Enabled = p;
        }

        private void DisplayText(DataGridViewRow row)
        {
            txtGroupName.Text = row.Cells[ghichuColumn.Name].Value != null ? row.Cells[ghichuColumn.Name].Value.ToString().Trim() : "";
            yccomboBox.Text = row.Cells[ycColumn.Name].Value != null ? row.Cells[ycColumn.Name].Value.ToString().Trim() : "";
        }

        private void ClearText()
        {
            txtGroupName.Text = "";
        }

        private void SetSelectRow(int i)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = null;

                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[idColumn.Name];
            }
        }
    }
}