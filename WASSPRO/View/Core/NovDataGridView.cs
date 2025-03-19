using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovDataGridView : DataGridView
    {
        protected Color designBackColor;

        public NovDataGridView()
        {
            InitializeComponent();
            //visualize
            Margin = new Padding(4);
            Padding = new Padding(4);

            BorderStyle = BorderStyle.FixedSingle;
            BackgroundColor = Color.White;

            RowHeadersVisible = false;
            EnableHeadersVisualStyles = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            var colHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.FromArgb(11, 64, 156),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(11, 64, 156),
                SelectionForeColor = Color.White,
                WrapMode = DataGridViewTriState.True,
            };
            ColumnHeadersDefaultCellStyle = colHeaderStyle;

            var defaultCellStyle = new DataGridViewCellStyle
            {
                //Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                //SelectionBackColor = Color.FromArgb(255, 255, 192),
                //SelectionForeColor = Color.Black,
                WrapMode = DataGridViewTriState.True,
            };
            DefaultCellStyle = defaultCellStyle;

            var rowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                WrapMode = DataGridViewTriState.True,
            };
            RowsDefaultCellStyle = rowsDefaultCellStyle;

            var alternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.LightCyan,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                WrapMode = DataGridViewTriState.True,
            };
            AlternatingRowsDefaultCellStyle = alternatingRowsDefaultCellStyle;

            //behavior
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeColumns = true;
            AllowUserToResizeRows = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ImeMode = ImeMode.Off;
        }
    }
}