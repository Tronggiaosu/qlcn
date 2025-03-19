using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.GachNo
{
    public partial class frLogHuyHD : Form
    {
        public frLogHuyHD()
        {
            InitializeComponent();

        }

        private void frLogHuyHD_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM//yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM//yyyy HH:mm:ss";
        }
    }
}
