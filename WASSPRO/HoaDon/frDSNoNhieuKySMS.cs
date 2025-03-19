using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frDSNoNhieuKySMS : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frDSNoNhieuKySMS()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //try
            //{
                int trangthai = int.Parse(cboTT.SelectedValue.ToString());
                int tudot = int.Parse(cbotudot.SelectedValue.ToString());
                int dendot = int.Parse(cbodendot.SelectedValue.ToString());
                string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                if (chkTT.Checked == false)
                    trangthai = -1;
                if (chkDot.Checked == false)
                    tudot = -1;
                if (chkTuNgayKhoa.Checked == false)
                    tungay = "";
                var data = db.getDSGuiSMS(trangthai, tungay, denngay, tudot, dendot).ToList();
                if (chksoky.Checked == true)
                    data = data.Where(x => x.soky == txtsoky.Text.TrimEnd()).ToList();
                dgvDSKhachHangNo.DataSource = data.ToList();
            //}
            //catch
            //{

            //}
        }

        private void frDSNoNhieuKySMS_Load(object sender, EventArgs e)
        {
            var trangthai = db.DM_TRANGTHAI_KH.ToList();
            cboTT.DataSource = trangthai.ToList();
            cboTT.DisplayMember = "tenTT";
            cboTT.ValueMember = "maTT";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            cbotudot.DataSource = db.DM_DOT.OrderBy(x=>x.DOT_ID).ToList();
            cbotudot.ValueMember = "DOT_ID";
            cbotudot.DisplayMember = "TENDOT";
            cbodendot.DataSource = db.DM_DOT.OrderByDescending(x => x.DOT_ID).ToList();
            cbodendot.ValueMember = "DOT_ID";
            cbodendot.DisplayMember = "TENDOT";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //try
            //{
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xls";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    int trangthai = int.Parse(cboTT.SelectedValue.ToString());
                    int tudot = int.Parse(cbotudot.SelectedValue.ToString());
                    int dendot = int.Parse(cbodendot.SelectedValue.ToString());
                    string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    if (chkTT.Checked == false)
                        trangthai = -1;
                    if (chkDot.Checked == false)
                        tudot = -1;
                    if (chkTuNgayKhoa.Checked == false)
                        tungay = "";
                    var data = db.getDSGuiSMS(trangthai, tungay, denngay, tudot, dendot).ToList();
                    if (chksoky.Checked == true)
                        data = data.Where(x => x.soky == txtsoky.Text.TrimEnd()).ToList();
                    string[] columns = { "sdt",  "DANHBO", "sotien", "tonggiam" };

                    var result = ExportExcel(ExcelExportHelper.ListToDataTable( data.ToList()), false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    MessageBox.Show("Xuất dữ liệu thành công!");
                }
            //}
            //catch
            //{

            //}
        }
        public static byte[] ExportExcel(DataTable dataTable, bool showSrNo = false, params string[] columnsToTake)
        {

            byte[] result = null;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add(String.Format("{0}", "Data"));
                int startRowFrom = 1;

                if (showSrNo)
                {
                    DataColumn dataColumn = dataTable.Columns.Add("STT", typeof(int));
                    dataColumn.SetOrdinal(0);
                    int index = 1;
                    foreach (DataRow item in dataTable.Rows)
                    {
                        item[0] = index;
                        index++;
                    }
                }


                // add the content into the Excel file  
                workSheet.Cells["A" + startRowFrom].LoadFromDataTable(dataTable, true);

                // autofit width of cells with small content  
                int columnIndex = 1;
                foreach (DataColumn column in dataTable.Columns)
                {
                    ExcelRange columnCells = workSheet.Cells[workSheet.Dimension.Start.Row, columnIndex, workSheet.Dimension.End.Row, columnIndex];
                    int maxLength = columnCells.Max(cell => (cell.Value ?? "").ToString().Count());
                    if (maxLength < 150)
                    {
                        workSheet.Column(columnIndex).AutoFit();
                    }

                    if (column.DataType == typeof(DateTime))
                    {
                        workSheet.Column(columnIndex).Style.Numberformat.Format = "dd/MM/yyyy";
                    }
                     if (column.ColumnName !="DANHBO")
                    {
                        workSheet.Column(columnIndex).Style.Numberformat.Format = "@";
                    }
                    if (column.DataType == typeof(Decimal))
                    {
                        workSheet.Column(columnIndex).Style.Numberformat.Format = "#,##0";
                    }

                    columnIndex++;
                }

                // format header - bold, yellow on black  
                using (ExcelRange r = workSheet.Cells[startRowFrom, 1, startRowFrom, dataTable.Columns.Count])
                {
                    r.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    r.Style.Font.Bold = true;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#333333"));
                }

                // format cells - add borders  
                using (ExcelRange r = workSheet.Cells[startRowFrom, 1, startRowFrom + dataTable.Rows.Count, dataTable.Columns.Count])
                {
                    r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    r.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                // removed ignored columns  
                for (int i = dataTable.Columns.Count - 1; i >= 0; i--)
                {
                    if (i == 0 && showSrNo)
                    {
                        continue;
                    }
                    if (!columnsToTake.Contains(dataTable.Columns[i].ColumnName))
                    {
                        workSheet.DeleteColumn(i + 1);
                    }
                }

                result = package.GetAsByteArray();
            }

            return result;
        }
    }
}
