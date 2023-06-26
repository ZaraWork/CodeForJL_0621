using DevExpress.XtraPrinting;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_OnlineCalibrate_BX_Form : Form
    {
        public IPM_Bill_OnlineScaleService MainService { get; set; }
        public PM_OnlineCalibrate_BX_Form()
        {
            InitializeComponent();
        }
        private void PM_OnlineCalibrate_BX_Form_Shown(Object obj,EventArgs e)
        {
            date_StartTime.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();            
            ht.Add("startTime", DateTime.ParseExact(date_StartTime.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyyMMddHHmmss"));
            ht.Add("endTime", DateTime.ParseExact(date_EndTime.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyyMMddHHmmss"));
            ht.Add("pondNo", txt_PondNo.Text);

            gcl_main.DataSource = MainService.ExecuteDB_QueryOnlineScaleCalibreateByHashTable(ht);             

        }
        /// <summary>
        /// 报表导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gvw_main.DataRowCount <= 0)
            {
                MessageBox.Show("当前无数据可导出!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;            
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsxExportOptions options = new XlsxExportOptions();//使用xlsx
                options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;                
                gvw_main.ExportToXlsx(fileDialog.FileName, options);                
            }
        }
    }
}
