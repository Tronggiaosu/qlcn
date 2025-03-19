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
    public partial class PhanQuyenForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public PhanQuyenForm()
        {
            InitializeComponent();
        }

        private void PhanQuyenForm_Load(object sender, EventArgs e)
        {
            LoadMenu();
            treeView1.ExpandAll();
            LoadGroup();
            groupListBox.SetItemChecked(0, true);
            CheckMenu();
        }

        private void LoadMenu()
        {
            MenuStrip menu = (MenuStrip)this.MdiParent.Controls["menuStrip"];
            foreach (ToolStripMenuItem tsmi in menu.Items)
            {
                TreeNode tn = new TreeNode(tsmi.Text);
                treeView1.Nodes.Add(tn);
                if (tsmi.HasDropDownItems)
                    LoadMenuItem(tsmi, tn);
            }
        }

        private void LoadMenuItem(ToolStripMenuItem tsmi, TreeNode tn)
        {
            foreach (ToolStripItem item in tsmi.DropDownItems)
            {
                if (item is ToolStripDropDownItem)
                {
                    TreeNode node = new TreeNode(item.Text);
                    tn.Nodes.Add(node);
                    if ((item as ToolStripDropDownItem).HasDropDownItems)
                        LoadDropDownItem(item, node);
                }
            }
        }

        private void LoadDropDownItem(ToolStripItem item, TreeNode node)
        {
            foreach (ToolStripItem tsi in (item as ToolStripDropDownItem).DropDownItems)
            {
                if (tsi is ToolStripDropDownItem)
                {
                    TreeNode childnode = new TreeNode(tsi.Text);
                    node.Nodes.Add(childnode);
                    if ((tsi as ToolStripDropDownItem).HasDropDownItems)
                        LoadDropDownItem(tsi, childnode);
                }
            }
        }

        private void LoadGroup()
        {
            var groups = from a in db.DM_QUYEN select a;
            if (groups != null)
            {
                groupListBox.DataSource = groups.ToList();
                groupListBox.DisplayMember = "tenquyen";
                groupListBox.ValueMember = "quyen_id";
            }
        }

        private void groupListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SetOnlyOneCheck();
            CheckMenu();
        }

        private void CheckMenu()
        {
            foreach (TreeNode node in treeView1.Nodes)
                ClearCheck(node);
            decimal groupID = ((QLCongNo.DM_QUYEN)(groupListBox.CheckedItems[0])).quyen_id;
            var menuList = from a in db.QUYEN_MENU where a.quyen_id == groupID select a;
            if (menuList != null)
                foreach (QUYEN_MENU gm in menuList.ToList())
                    foreach (TreeNode node in treeView1.Nodes)
                        SetMenuCheck(gm.ten_menu, node);

        }

        private void ClearCheck(TreeNode node)
        {
            node.Checked = true;
            foreach (TreeNode child in node.Nodes)
                ClearCheck(child);
        }

        private void SetMenuCheck(string menuName, TreeNode node)
        {
            if (node.Text == menuName)
                node.Checked = false;
            foreach (TreeNode child in node.Nodes)
                SetMenuCheck(menuName, child);

        }

        private void SetOnlyOneCheck()
        {
            int listIndex;
            groupListBox.ItemCheck -= groupListBox_ItemCheck;

            for (listIndex = 0; listIndex < groupListBox.Items.Count; listIndex++)
            {
                // Unchecked all items that is not currently selected
                if (groupListBox.SelectedIndex != listIndex)
                {
                    // set item as unchecked
                    groupListBox.SetItemChecked(listIndex, false);
                } // if
                else
                {
                    // set selected item as checked
                    groupListBox.SetItemChecked(listIndex, true);
                }
            } // for
            groupListBox.ItemCheck += groupListBox_ItemCheck;
        }

        void SetUserRight(decimal groupID, TreeNode node)
        {
            QUYEN_MENU gm = new QUYEN_MENU();
            if (!node.Checked)
            {
                gm.quyen_id = groupID;
                gm.ten_menu = node.Text;
                db.QUYEN_MENU.Add(gm);
            }
            foreach (TreeNode childnode in node.Nodes)
            {
                SetUserRight(groupID, childnode);
            }

            db.SaveChanges();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            bool check = node.Checked;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Checked = check;
            }
        }

        private void DefaultState()
        {
            editButton.Text = "Phân quyền";
            editButton.Enabled = true;
            EnableControl(false);
        }

        private void EditState()
        {
            editButton.Text = "Lưu";
            EnableControl(true);
        }

        private void EnableControl(bool p)
        {
            treeView1.Enabled = p;
            groupListBox.Enabled = !p;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (editButton.Text == "Phân quyền")
            {
                EditState();
            }
            else
            {
                decimal groupID = ((QLCongNo.DM_QUYEN)(groupListBox.CheckedItems[0])).quyen_id;
                var gm = from a in db.QUYEN_MENU where a.quyen_id == groupID select a;
                if (gm != null)
                    foreach (QUYEN_MENU gm1 in gm.ToList())
                        db.QUYEN_MENU.Remove(gm1);
                db.SaveChanges();
                foreach (TreeNode node in treeView1.Nodes)
                    SetUserRight(groupID, node);
                DefaultState();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DefaultState();
        }
    }
}
