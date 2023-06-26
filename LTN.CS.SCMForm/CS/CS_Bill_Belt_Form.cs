using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.PT.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

using System.Windows.Forms;

namespace LTN.CS.SCMForm.CS
{
    public partial class CS_Bill_Belt_Form : CoreForm
    {
        public IPM_Bill_BeltScaleService MainService { get; set; }
        public CS_Bill_Belt_Form()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            /*
            if (gCtrl_BeltBill.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;

            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions();
                options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;
                gView_BeltBill.ExportToXls(fileDialog.FileName, options);
            }
            */
            if (gCtrl_BeltBill.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            //fileDialog.Title = Text;           
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel) return;
            string fileName = fileDialog.FileName;
            if (fileName == "")
            {
                MessageBox.Show("请输入文件名!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            DataExportToExcel(gView_BeltBill, fileName);
        }

        private void Query()
        {
            Hashtable ht = new Hashtable();
            ht.Add("BeltNo", txt_BeltNo.Text);
            if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
            {
                ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
            }
            if (checkBox1.Checked)
            {
                ht.Add("totalNum", "Y");
            }
            else
            {
                ht.Add("totalNum", "N");
            }

            ht.Add("MaterialName", txt_materiel.Text);

            if (checkBox_startTime.Checked)
            {
                gCtrl_BeltBill.DataSource = MainService.ExecuteDB_QueryPM_Bill_BeltByHashtable_startTime(ht);
            }
            else if (checkBox_endTime.Checked)
            {
                gCtrl_BeltBill.DataSource = MainService.ExecuteDB_QueryPM_Bill_BeltByHashtable_endTime(ht);
            }
            else
            {
                gCtrl_BeltBill.DataSource = MainService.ExecuteDB_QueryPM_Bill_BeltByHashtable(ht);
            }
        }


        private void gView_BeltBill_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "C_Measurestarttime" || e.Column.FieldName == "C_Measureendtime" || e.Column.FieldName == "C_Billcreatetime" || e.Column.FieldName == "C_Updatetime")
            {
                if (e.Value != null)
                {
                    e.DisplayText = CommonHelper.Str14ToTimeFormart(e.Value.ToString());
                }
            }
        }

        private void CS_Bill_Belt_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }

        private void checkBox_startTime_Click(object sender, EventArgs e)
        {
            if (checkBox_endTime.Checked)
            {
                MessageBox.Show("已勾选按结束时间查询，不能同时以开始时间和结束时间查询");
                checkBox_startTime.CheckState = CheckState.Unchecked;
            }
        }

        private void checkBox_endTime_Click(object sender, EventArgs e)
        {
            if (checkBox_startTime.Checked)
            {
                MessageBox.Show("已勾选按开始时间查询，不能同时以开始时间和结束时间查询");
                checkBox_endTime.CheckState = CheckState.Unchecked;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gView_BeltBill.DataRowCount > 0)
            {
                Decimal result = 0;
                for (int i = 0; i < gView_BeltBill.DataRowCount; i++)
                {
                    String str = gView_BeltBill.GetRowCellValue(i, "C_Planno").ToString().Substring(0, 2);
                    if (str.Equals("A0") || str.Equals("A6"))
                    {
                        var obj = gView_BeltBill.GetRowCellValue(i, "N_Netwgt");
                        Decimal d = Decimal.Parse(obj.ToString());
                        result += Math.Round(d, 2);
                    }
                    else
                    {
                        continue;
                    }

                }
                MessageBox.Show("当前页面新材料溶剂皮带秤磅单总净重为：" + result + "吨");
            }
            else
            {
                MessageBox.Show("当前页面没有要计算的新材料溶剂皮带秤磅单数据");
            }
        }


        public static void DataExportToExcel(DevExpress.XtraGrid.Views.Grid.GridView gv, string fileName)
        {
            try
            {
                if (gv == null || gv.RowCount < 1)
                {
                    MessageBox.Show("导出数据时信息栏不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }               

                //获取列名、列标题  放到List集合中
                System.Collections.ArrayList listCaption = new System.Collections.ArrayList();
                System.Collections.ArrayList listFieldName = new System.Collections.ArrayList();
                for (int i = 0; i < gv.Columns.Count; i++)
                {
                    if (gv.Columns[i].Visible)
                    {
                        //CustomizationSearchCaption可以获取到GridView的列名
                        listCaption.Add(gv.Columns[i].CustomizationSearchCaption);
                        listFieldName.Add(gv.Columns[i].FieldName);
                    }
                }
                IWorkbook workbook = null;
                ISheet sheet;

                //保存文件
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
                saveFileDialog.RestoreDirectory = true;

                MemoryStream ms = new MemoryStream();

                string extension = Path.GetExtension(fileName);

                if (extension.Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook();
                }
                else if (extension.Equals(".xls"))
                {
                    workbook = new HSSFWorkbook();
                }
                //创建Sheet
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet("Sheet1");//Sheet的名称  
                }
                else
                {
                    MessageBox.Show("导出报表失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                sheet.ForceFormulaRecalculation = true;
                //设置几种列的样式

                ICellStyle cellStyle1 = workbook.CreateCellStyle();
                IDataFormat format = workbook.CreateDataFormat();
                //cellStyle1.DataFormat = format.GetFormat("yyyy年m月d日");                
                cellStyle1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

                //设置字体
                if (workbook is HSSFWorkbook)
                {
                    HSSFFont font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "新宋体";
                    font.FontHeightInPoints = 9;
                    cellStyle1.SetFont(font);
                }
                else if (workbook is XSSFWorkbook)
                {
                    XSSFFont font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "新宋体";
                    font.FontHeightInPoints = 9;
                    cellStyle1.SetFont(font);
                }

                cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center; //水平居中
                cellStyle1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center; //垂直居中

                //存入列名
                IRow row0 = sheet.CreateRow(0);
                for (int i = 0; i < listCaption.Count; i++)
                {
                    string captionName = listCaption[i].ToString().Trim();
                    /*
                    if (captionName.Contains('吨'))
                    {
                        captionName = captionName.Replace("(吨)", "(KG)");
                    }
                    */
                    row0.CreateCell(i).SetCellValue(captionName);

                    if (listCaption[i].ToString().Contains("号") || listCaption[i].ToString().Contains("时间") || listCaption[i].ToString().Contains("单位"))
                    {
                        sheet.SetColumnWidth(i, 10 * 500);
                    }
                    else if (listCaption[i].ToString().Contains("名称"))
                    {
                        sheet.SetColumnWidth(i, 10 * 700);
                    }
                    else
                    {
                        sheet.SetColumnWidth(i, 10 * 300);
                    }

                    //设置行高
                    row0.HeightInPoints = 15f;
                    row0.GetCell(i).CellStyle = cellStyle1;
                }
                decimal grossWgtSum = 0;
                decimal tareWgtSum = 0;
                decimal netWgtSum = 0;
                for (int r = 0; r < gv.RowCount; r++)
                {
                    //创建行row
                    IRow row = sheet.CreateRow(r + 1);
                    //创建列cell
                    for (int i = 0; i < listFieldName.Count; i++)
                    {
                        //获取每行每列的数据开始填充
                        var obj = gv.GetRowCellValue(r, listFieldName[i].ToString());
                        if (obj != null)
                        {
                            string fieledName = listFieldName[i].ToString().Trim();
                            if (fieledName == "N_Startwgt" || fieledName == "N_Endwgt" || fieledName == "N_Netwgt")
                            {
                                decimal d = Convert.ToDecimal(obj.ToString());
                                row.CreateCell(i, CellType.Numeric).SetCellValue(Convert.ToDouble(obj.ToString()));
                                switch (fieledName)
                                {
                                    case "N_Startwgt":
                                        grossWgtSum += Math.Round(d,2);
                                        break;
                                    case "N_Endwgt":
                                        tareWgtSum += Math.Round(d, 2);
                                        break;
                                    case "N_Netwgt":
                                        netWgtSum += Math.Round(d, 2);
                                        break;
                                }
                            }
                            else
                            {
                                row.CreateCell(i).SetCellValue(obj.ToString());
                            }
                        }
                        else
                        {
                            row.CreateCell(i).SetCellValue(string.Empty);
                        }
                        row.GetCell(i).CellStyle = cellStyle1;
                    }
                }
                //加上最后一行
                IRow endRow = sheet.CreateRow(gv.RowCount + 1);
                for (int i = 0; i < listFieldName.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            endRow.CreateCell(i).SetCellValue(gv.RowCount);
                            break;
                        case 4:
                            endRow.CreateCell(i).SetCellValue(grossWgtSum.ToString());
                            break;
                        case 5:
                            endRow.CreateCell(i).SetCellValue(tareWgtSum.ToString());
                            break;
                        case 6:
                            endRow.CreateCell(i).SetCellValue(netWgtSum.ToString());
                            break;
                        default:
                            endRow.CreateCell(i).SetCellValue(string.Empty);
                            break;
                    }
                    endRow.GetCell(i).CellStyle = cellStyle1;

                }
                //保存为Excel文件                  
                workbook.Write(ms);
                FileStream file = new FileStream(fileName, FileMode.Create);
                workbook.Write(file);
                file.Close();
                workbook.Close();

                MessageBox.Show("导出报表成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出报表失败！", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


    }
}
