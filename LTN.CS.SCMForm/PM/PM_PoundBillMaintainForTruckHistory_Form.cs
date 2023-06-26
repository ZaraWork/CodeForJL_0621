using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using LTN.CS.Base;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_PoundBillMaintainForTruckHistory_Form : CoreForm
    {
        public IPM_Bill_TruckService MainService { get; set; }
        private int selectMainId { get; set; }
        private bool queryMain { get; set; }
        private int selectMainRowNum { get; set; }
        public PM_PoundBillMaintainForTruckHistory_Form()
        {
            InitializeComponent();
        }
        private void PM_PoundBillMaintainForTruckHistory_Form_Shown(object sender, EventArgs e)
        {
            date_StartTime.EditValue = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd 00:00:00");
            date_EndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            Query();
        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
        }


        private void Query(bool isFirst = false)
        {
            try
            {
                int selectLeftIdOld = selectMainId;
                queryMain = false;
                Hashtable ht = new Hashtable();
                ht.Add("PlanNo", txt_PlanNo.Text.Trim());
                ht.Add("WgtNo", txt_WgtNo.Text.Trim());
                ht.Add("CARNAME", txt_CarName.Text.Trim());
                if (!string.IsNullOrEmpty(date_StartTime.Text) && !string.IsNullOrEmpty(date_EndTime.Text))
                {
                    ht.Add("StartTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_StartTime.Text)));
                    ht.Add("EndTime", CommonHelper.TimeToStr14(MyDateTimeHelper.ConvertToDateTimeDefaultNow(date_EndTime.Text)));

                }
                var result = MainService.ExecuteDB_QueryPM_Bill_TruckHistoryByHashtable(ht);
                gCtrl_TruckPoundBill.DataSource = result;
                if (!isFirst)
                {
                    selectMainId = selectLeftIdOld;
                    SetMainFocusRow();
                }
                queryMain = true;
            }
            catch (Exception)
            {
            }
        }
        private void SetMainFocusRow()
        {
            int rowcount = gView_TruckPoundBill.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_Bill_Truck_History group = gView_TruckPoundBill.GetRow(i) as PM_Bill_Truck_History;
                    if (group.I_INTID == selectMainId)
                    {
                        gView_TruckPoundBill.FocusedRowHandle = i;
                        selectMainRowNum = i;
                        isFocused = true;
                        break;
                    }
                }
            }
            if (!isFocused)
            {
                if (rowcount - 1 < selectMainRowNum)
                {
                    gView_TruckPoundBill.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gView_TruckPoundBill.FocusedRowHandle = selectMainRowNum;
                }
            }
        }

        private void gView_TruckPoundBill_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var item = gView_TruckPoundBill.GetRow(e.RowHandle) as PM_Bill_Truck_History;
            if (item == null)
                return;
            if (!String.IsNullOrEmpty(item.C_UPDATECOLUMNS))
            {
                if (item.C_UPDATECOLUMNS=="作废")
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }
                string[] columns = item.C_UPDATECOLUMNS.Split('|');
                if (columns!=null && columns.Contains(e.Column.FieldName))
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gCtrl_TruckPoundBill.DataSource==null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.FileName = Text;
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsxExportOptions options = new XlsxExportOptions();
                options.TextExportMode = TextExportMode.Text;
                gView_TruckPoundBill.ExportToXlsx(fileDialog.FileName, options);
            }
        }
        //新增
        /// <summary>
        /// 委托单号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
            }
        }
        /// <summary>
        /// 车号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CarName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
            }
        }
        /// <summary>
        /// 磅单号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_WgtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
            }
        }
        //恢复数据行颜色改变
        private void gView_TruckPoundBill_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var item = gView_TruckPoundBill.GetRowCellValue(e.RowHandle, "I_RESERVEFLAG1");
            if (item != null)
            {
                int dataflag = Convert.ToInt32(gView_TruckPoundBill.GetRowCellValue(e.RowHandle, "I_RESERVEFLAG1"));
                if (dataflag == 1)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
                if (dataflag == 2)
                {
                    e.Appearance.BackColor = Color.YellowGreen;
                }
            }


        }

        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            //string[] isPower = {"admin","管理员","韦东云"};
            //if (Array.IndexOf(isPower, SessionHelper.LogUserNickName) < 0)
            //{ MessageBox.Show("当前用户不具有操作权限");
            //  return;
            //}

            try
            {
                var item = gView_TruckPoundBill.GetFocusedRow() as PM_Bill_Truck_History;
                if (item == null)
                    return;
                if (item.I_RESERVEFLAG1 == 0)
                {
                    MessageBox.Show("该数据为修改数据，不可恢复");
                    return;
                }
                if (item.I_RESERVEFLAG1 == 2)
                {
                    MessageBox.Show("该数据已恢复");
                    return;
                }
                var tip = string.Format("是否恢复磅单:\n{0}", item.C_WGTLISTNO);
                if (MessageDxUtil.ShowYesNoAndTips(tip) == DialogResult.No)
                {
                    return;
                }
                var password = XtraInputBox.Show("请输入密码", "密码验证", "");
                if (password != null)
                {
                    if (password.ToString().Trim() == "sb2022301")
                    {
                        var rs = MainService.ExecuteDB_QueryTruckIsRepeatByPlanNo(item.C_PLANNO);
                        if (rs.Count != 0)
                        {
                            MessageBox.Show("对应委托已经有磅单数据，不可恢复");
                        }
                        else
                        {
                            //恢复磅单状态
                            var pond = MainService.ExecuteDB_QueryTruckByWgtlistNo(item.C_WGTLISTNO);
                            pond.C_BILLSTATE = item.C_BILLSTATE;
                            pond.C_PLANSTATUS = "I";
                            pond.C_UPLOADSTATUE = "N";
                            pond.C_UPDATETIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                            pond.C_UPDATEUSERNAME = SessionHelper.LogUserNickName;
                            MainService.ExecuteDB_UpdateTruckPondByIntId(pond);

                            //历史表信息改变
                            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddr = ipHost.AddressList[0];
                            item.I_RESERVEFLAG1 = 2;
                            item.C_UPDATEHISTORYUSER = SessionHelper.LogUserNickName;
                            item.C_UPDATEHISTORYTIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                            item.C_COMPUTERIP = ipAddr.ToString();
                            MainService.ExecuteDB_UpdateTruckHistroyDataFlagByIntId(item);
                            Query();
                        }
                    }

                    else
                    {
                        MessageBox.Show("密码错误");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }

        }

        
        
    }
}
