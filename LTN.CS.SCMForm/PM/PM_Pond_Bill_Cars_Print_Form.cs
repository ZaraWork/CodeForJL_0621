using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LTN.CS.Base;
using LTN.CS.SCMService.PM.Interface;
using System.Collections;
using LTN.CS.SCMForm.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Pond_Bill_Cars_Print_Form : CoreForm
    {
        public IPM_Pond_Bill_Cars_PrintService MainService { get; set; }
        public PM_Pond_Bill_Cars_Print_Form()
        {
            InitializeComponent();
        }
        private void gridControl1_Load(object sender, EventArgs e)
        {
            InitView(gridView1);
            date_StartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            Query();
        }
        private void Query(bool isFirst = false)
        {
            try
            {
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(txt_CarName.Text.Trim()))
                {
                    ht.Add("CarName", txt_CarName.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_MaterialName.Text.Trim()))
                {
                    ht.Add("MaterialName", txt_MaterialName.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_PlanNo.Text.Trim()))
                {
                    ht.Add("PlanNo", txt_PlanNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_WgtlistNo.Text.Trim()))
                {
                    ht.Add("WgtlistNo", txt_WgtlistNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
                {
                    ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                    ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));
                }
                var rs = MainService.ExecuteDB_QueryPM_Pond_Bill_Cars_PrintByHashtable(ht);
                gridControl1.DataSource = rs;
            }
            catch (Exception)
            {
            }
        }
    }
}