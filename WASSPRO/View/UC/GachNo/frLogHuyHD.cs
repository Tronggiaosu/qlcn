using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcLogHuyHD : View.Core.NovUserControl
    {
        public UcLogHuyHD()
        {
            InitializeComponent();

        }

        private void frLogHuyHD_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM//yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM//yyyy HH:mm:ss";
        }
    }
}
