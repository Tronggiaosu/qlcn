using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class GroupForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public GroupForm()
        {
            InitializeComponent();
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            LoadGroup();
        }

        private void LoadGroup()
        {
            var groups = from g in db.DM_QUYEN select g;
            if (groups != null)
                dataGridView1.DataSource = groups.ToList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (!IsDataOK()) return;
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value.ToString());
                var editGroup = (from g in db.DM_QUYEN where g.quyen_id == id select g).FirstOrDefault();
                editGroup.tenquyen = txtGroupName.Text.Trim();
                db.SaveChanges();
                DefaultState();
                LoadGroup();
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
                if (!IsDataOK()) return;
                DM_QUYEN addGroup = new DM_QUYEN();
                addGroup.tenquyen = txtGroupName.Text.Trim();
                db.DM_QUYEN.Add(addGroup);
                db.SaveChanges();
                LoadGroup();
                DefaultState();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                var editGroup = (from g in db.DM_QUYEN where g.quyen_id == id select g).FirstOrDefault();
                db.DM_QUYEN.Remove(editGroup);
                db.SaveChanges();
                LoadGroup();
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
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                DisplayText(row);
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
            string groupName = row.Cells[0].Value.ToString().Trim();
            txtGroupName.Text = groupName;
            if (groupName == "Quản trị hệ thống")
            {
                editButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            else
            {
                editButton.Enabled = true;
                deleteButton.Enabled = true;
            }
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

                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[nameColumn.Name];
            }
        }

        private bool IsDataOK()
        {
            if (txtGroupName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                var list = (from a in db.DM_QUYEN where a.tenquyen == txtGroupName.Text.Trim() select a).FirstOrDefault();
                if (list != null)
                {
                    MessageBox.Show("Tên nhóm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGroupName.Focus();
                    return false;
                }
            }
            return true;
        }
    }
}
