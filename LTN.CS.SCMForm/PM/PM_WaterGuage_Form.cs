using DevExpress.XtraPrinting;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_WaterGuage_Form : Form
    {
        private IPM_WaterGuageService MainService { get; set; }


        public PM_WaterGuage_Form()
        {
            InitializeComponent();
        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("materialName", txt_materialName.Text);
            ht.Add("contractNo", txt_contractNo.Text);
            ht.Add("shipName", txt_shipName.Text);
            ht.Add("hangCiNo", txt_voyageNo.Text);
            string arriveTime = string.Empty;
            if (!string.IsNullOrEmpty(ArriveDate.Text))
            {
                arriveTime = Convert.ToDateTime(ArriveDate.Text).ToString("yyyyMMddHHmmss");
            }
            ht.Add("arriveTime", arriveTime);
            var rss = MainService.ExecuteDB_QueryWaterGuageInfoAll(ht);
            
            if (rss != null)
            {
                List<PM_Water_Guage_Info> data = rss.ToList();
                data.ForEach(r =>
                {
                    System.Globalization.CultureInfo Culinfo = CultureInfo.GetCultureInfo("zh-cn");
                   
                    if (r.C_BERTH_DT != null)
                    {

                        DateTime dt;
                        IFormatProvider ifp = new CultureInfo("zh-CN", true);
                        if (DateTime.TryParseExact(r.C_BERTH_DT, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                        {
                            r.C_BERTH_DT = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                });
            }
            gridControl1.DataSource = rss;
            gridView1.BestFitColumns();
        }

        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            if (gridControl1.DataSource == null)
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
                gridView1.ExportToXls(fileDialog.FileName, options);
            }
        }
    }
}
