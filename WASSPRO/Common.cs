using Microsoft.Office.Interop.Excel;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace QLCongNo
{
    internal class Common
    {
        public static string strConn;
        public static string username;
        public static string fullname;
        public static decimal NVID;
        public static decimal? ChucvuID;
        public static decimal? TOID;
        public static bool isxoa;

        public static void ExportExcel(DataGridView dataGridView1)
        {
            using (SaveFileDialog save = new SaveFileDialog { Filter = "Excel file|.xlsx" })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application { Visible = false, DisplayAlerts = false };
                    Workbook workBook = app.Workbooks.Add(Missing.Value);
                    Worksheet workSheet = workBook.ActiveSheet;

                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        workSheet.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            DataGridViewCell cell = dataGridView1[j, i];
                            workSheet.Cells[i + 2, j + 1] = "=\"" + cell.Value + "\"";
                        }
                    }

                    workBook.SaveAs(save.FileName, XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
                                    Missing.Value, false, false, XlSaveAsAccessMode.xlNoChange,
                                    XlSaveConflictResolution.xlUserResolution, true,
                                    Missing.Value, Missing.Value, Missing.Value);

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    workBook.Close(false, Missing.Value, Missing.Value);
                    app.Quit();

                    releaseObject(workSheet);
                    releaseObject(workBook);
                    releaseObject(app);
                }
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                if (obj != null && System.Runtime.InteropServices.Marshal.IsComObject(obj))
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                obj = null;
                GC.Collect();
            }
        }
    }
}