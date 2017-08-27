using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Common
{
    public class ExcelHelper
    {
        //读取Excel，转化成datatable类型   
        public static DataTable ConvertExcelFileToTable(string filePath)
        {
            try
            {

                string strConn;
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle.Tables[0];
            }
            catch (Exception e)
            {
                Log.LogMsg("ConvertExcelFileToTable:" + e.Message,"super");
                DataTable dt = new DataTable();
                DataColumnCollection columns = dt.Columns;
                columns.Add("ProductTypeNo", typeof(System.String));
                DataRow datarow = dt.NewRow();
                datarow["ProductTypeNo"] = e.Message;
                dt.Rows.Add(datarow);
                return dt;
            }
        }
        /// <summary>  
        /// 导出速度最快  
        /// </summary>  
        /// <param name="list"><列名，数据></param>  
        /// <param name="filepath"></param>  
        /// <returns></returns>  
        public static void NewExport(List<DictionaryEntry> list, string filepath)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbookdata = null;
         Microsoft.Office.Interop.Excel.Worksheet worksheetdata = null;
            Microsoft.Office.Interop.Excel.Range rangedata;

            workbookdata = appexcel.Workbooks.Add();

            //设置对象不可见  
            appexcel.Visible = false;
            appexcel.DisplayAlerts = false;
            try
            {
                foreach (var lv in list)
                {
                    var keys = lv.Key as List<string>;
                    var values = lv.Value as List<IList<object>>;
                    worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, workbookdata.ActiveSheet);
                   

                    for (int i = 0; i < keys.Count - 1; i++)
                    {
                        //给工作表赋名称  
                        worksheetdata.Name = keys[0];//列名的第一个数据位表名  
                        worksheetdata.Cells[1, i + 1] = keys[i + 1];
                    }

                    //因为第一行已经写了表头，所以所有数据都应该从a2开始  
                    rangedata = worksheetdata.get_Range("a1", miss);
                    Microsoft.Office.Interop.Excel.Range xlrang = null;

                    //irowcount为实际行数，最大行  
                    int irowcount = values.Count;
                    int iparstedrow = 0, icurrsize = 0;

                    //ieachsize为每次写行的数值，可以自己设置  
                    int ieachsize = 10000;

                    //icolumnaccount为实际列数，最大列数  
                    int icolumnaccount = keys.Count - 1;

                    //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数  
                    object[,] objval = new object[ieachsize, icolumnaccount];
                    icurrsize = ieachsize;

                    while (iparstedrow < irowcount)
                    {
                        if ((irowcount - iparstedrow) < ieachsize)
                            icurrsize = irowcount - iparstedrow;

                        //用for循环给数组赋值  
                        for (int i = 0; i < icurrsize; i++)
                        {
                            for (int j = 0; j < icolumnaccount; j++)
                            {
                                var v = values[i + iparstedrow][j];
                                objval[i, j] = v != null ? v.ToString() : "";
                            }
                        }
                        string X = "A" + ((int)(iparstedrow + 2)).ToString();
                        string col = "";
                        if (icolumnaccount <= 26)
                        {
                            col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                        }
                        else
                        {
                            col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                        }
                        xlrang = worksheetdata.get_Range(X, col);
                        xlrang.NumberFormat = "@";
                        // 调用range的value2属性，把内存中的值赋给excel  
                        xlrang.Value2 = objval;
                        iparstedrow = iparstedrow + icurrsize;
                    }
                }  
                ((Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets["Sheet1"]).Delete();
                ((Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets["Sheet2"]).Delete();
                ((Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets["Sheet3"]).Delete();
                //保存工作表  
                workbookdata.SaveAs(filepath, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                workbookdata.Close(false, miss, miss);
                appexcel.Workbooks.Close();
                appexcel.Quit();
                appexcel = null;  
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                if (appexcel != null)
                {
                    workbookdata.Close(true, Type.Missing, Type.Missing);
                    workbookdata = null;
                    appexcel.Quit();
                    appexcel = null;  
                }
            }  
        }
    }
}
