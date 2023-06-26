using LTN.CS.Base;
using LTN.CS.Base.Common;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_Bill_Supplies_Form : CoreForm
    {
        #region 实例变量
        private PM_Bill_Supplies SelectMainEntity { get; set; }
        public IPM_Bill_SuppliesService MainService { get; set; }
        public ISM_PoundSite_InfoService PondService { get; set; }
        private bool queryMain { get; set; }
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        #endregion

        #region 构造函数
        public PM_Bill_Supplies_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        private void setDataSource()
        {
            lue_BillStatus.Properties.DataSource = BillStatusObj.GetBillStatusData();
            dte_StartTime.Text = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd 00:00:00");
            dte_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
        private Hashtable setCondition()
        {
            Hashtable ht = new Hashtable();
            DateTime StartTime = Convert.ToDateTime(dte_StartTime.Text);
            DateTime EndTime = Convert.ToDateTime(dte_EndTime.Text);
            if (!string.IsNullOrEmpty(dte_StartTime.Text))
            {
                ht.Add("StartTime", StartTime.ToString("yyyyMMddHHmmss"));
            }
            if (!string.IsNullOrEmpty(dte_EndTime.Text))
            {
                ht.Add("EndTime", EndTime.ToString("yyyyMMddHHmmss"));
            }
            if (!string.IsNullOrEmpty(txt_PlanNo.Text))
            {
                ht.Add("PlanNo", txt_PlanNo.Text);
            }
            if (!string.IsNullOrEmpty(txt_WagNo.Text))
            {
                ht.Add("WagNo", txt_WagNo.Text);
            }
            if (!string.IsNullOrEmpty(lue_BillStatus.Text))
            {
                ht.Add("BillStatus", lue_BillStatus.EditValue.ToString());
            }
            return ht;
        }
        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;
                    queryMain = false;
                    var rss = MainService.ExecuteDB_QuerySuppliesPlanByHashTable(setCondition());
                    if (rss != null)
                    {
                        List<PM_Bill_Supplies> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            System.Globalization.CultureInfo Culinfo = CultureInfo.GetCultureInfo("zh-cn");
                            if (r.UpdateTime != null)
                            {
                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.UpdateTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.UpdateTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.CreateTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.CreateTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.CreateTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            if (r.PlanLimitTime != null)
                            {

                                DateTime dt;
                                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                                if (DateTime.TryParseExact(r.PlanLimitTime, "yyyyMMddHHmmss", ifp, DateTimeStyles.None, out dt))
                                {
                                    r.PlanLimitTime = dt.ToString(("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                        });
                    }
                    gcl_main.DataSource = rss;

                    gvw_main.BestFitColumns();
                    if (!isFirst)
                    {
                        selectMainId = selectLeftIdOld;
                        SetMainFocusRow();
                    }
                    queryMain = true;
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }

        /// <summary>
        /// 主档焦点行转换
        /// </summary>
        private void SetMainFocusRow()
        {

            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    PM_Bill_Supplies iron = gvw_main.GetRow(i) as PM_Bill_Supplies;
                    if (iron.IntId == selectMainId)
                    {
                        gvw_main.FocusedRowHandle = i;
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
                    gvw_main.FocusedRowHandle = rowcount - 1;
                    selectMainRowNum = rowcount - 1;
                }
                else
                {
                    gvw_main.FocusedRowHandle = selectMainRowNum;
                }
            }
        }

        /// <summary>
        /// 自定义作废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMainDelete()
        {
           /*
            try
            {
                int[] rowhandles = gvw_main.GetSelectedRows();//获得选中的行号集合
                if (rowhandles.Length == 0)
                {
                    return;
                }



                if (MessageDxUtil.ShowYesNoAndTips("确定作废当前选中数据？") == DialogResult.Yes)
                {
                    SelectMainEntity = gvw_main.GetFocusedRow() as PM_Bill_Supplies;
                    SelectMainEntity.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.InvalidMeasure };
                    SelectMainEntity.UpdateUser = SessionHelper.LogUserNickName;
                    var rs = MainService.ExecuteDB_InvalidSuppliesPlanByIntId(SelectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
           */
           
            try
            {
                int[] rowhandles = gvw_main.GetSelectedRows();//获得选中的行号集合
                if (rowhandles.Length == 0)
                {
                    return;
                }
                string planNos = string.Empty;
                for (int i = 0; i < rowhandles.Count(); i++)
                {
                    planNos += gvw_main.GetRowCellValue(rowhandles[i], "PlanNo").ToString() + "\n";
                }
                planNos = string.Format("是否作废以下委托:\n{0}", planNos);
                if (MessageDxUtil.ShowYesNoAndTips(planNos) == DialogResult.Yes)
                {
                    for (int i = 0; i < rowhandles.Count(); i++)
                    {
                        var item = gvw_main.GetRow(rowhandles[i]) as PM_Bill_Supplies;
                        //item.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        item.UpdateUser = SessionHelper.LogUserNickName;
                        item.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.InvalidMeasure };
                        var obj = MainService.ExecuteDB_InvalidSuppliesPlanByIntId(item);
                    }
                    MessageDxUtil.ShowTips("批量作废成功");
                    //刷新内容
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError("批量作废异常" + ex.Message);
                return;
            }
           
        }
        #endregion

        #region 控件事件
        private void PM_Bill_Supplies_Form_Load(object sender, EventArgs e)
        {
            InitView(gvw_main);
            setDataSource();
            SetMainGridData(true);
        }

        private void gvw_main_DoubleClick(object sender, EventArgs e)
        {
            btn_update_Click(null, null);
        }

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain)
            {
                var entity = gvw_main.GetFocusedRow() as PM_Bill_Supplies;
                if (entity != null)
                {
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                SelectMainEntity = entity;
            }
        }

        private void gvw_main_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string BillStatus = gvw_main.GetRowCellValue(e.RowHandle, "BillStatus.BillStatusDesc").ToString();
            if (BillStatus == "作废")
            {
                e.Appearance.BackColor = Color.Red;
            }
            if (BillStatus == "完成计量")
            {
                e.Appearance.BackColor = Color.Green;
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            SetMainGridData(false);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PM_SuppliesPlan_Form frm = new PM_SuppliesPlan_Form();
            frm.MainService = MainService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                SetMainGridData(false);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int[] rowhandles = gvw_main.GetSelectedRows();//获得选中的行号集合
            if (rowhandles.Length == 0)
            {
                MessageDxUtil.ShowTips("请勾选要修改的委托");
                return;
            }else if(rowhandles.Length > 1)
            {
                MessageDxUtil.ShowTips("一次只能修改一条委托，请勿勾选多条");
                return;
            }
            //SelectMainEntity = gvw_main.GetFocusedRow() as PM_Bill_Supplies;
            string planno = gvw_main.GetRowCellValue(gvw_main.FocusedRowHandle, "PlanNo").ToString();
            SelectMainEntity = MainService.ExecuteDB_QuerySuppliesByPlan(planno).FirstOrDefault();
            


            if (SelectMainEntity == null)
                return;
            PM_SuppliesPlan_Form frm = new PM_SuppliesPlan_Form();
            frm.Text = "物资委托修改";
            frm.SelectMainEntity = SelectMainEntity;
            frm.MainService = MainService;
            frm.ShowDialog();
            if (frm.SelectMainEntity != null)
            {
                SetMainGridData(false);
            }
        }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            CustomMainDelete();
        }
        #endregion

        private void txt_PlanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetMainGridData(false);
            }
        }

        private void txt_WagNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetMainGridData(false); 
            }
        }
        /// <summary>
        /// 9-20新增批量作废，主要用于处理装车楼委托错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_multiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowhandles = gvw_main.GetSelectedRows();//获得选中的行号集合
                if (rowhandles.Length == 0)
                {
                    return;
                }
                string planNos = string.Empty;
                for (int i = 0; i < rowhandles.Count(); i++)
                {
                    planNos += gvw_main.GetRowCellValue(rowhandles[i], "PlanNo").ToString() + "\n";
                }
                planNos = string.Format("是否作废以下委托:\n{0}", planNos);
                if (MessageDxUtil.ShowYesNoAndTips(planNos) == DialogResult.Yes)
                {                    
                    for (int i = 0; i < rowhandles.Count(); i++)
                    {
                        var item = gvw_main.GetRow(rowhandles[i]) as PM_Bill_Supplies;
                       

                        //item.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        item.UpdateUser = SessionHelper.LogUserNickName;
                        item.BillStatus = new BillStatusObj() { IntValue = (int)BillStatus.InvalidMeasure };
                        
                        var obj = MainService.ExecuteDB_InvalidSuppliesPlanByIntId(item);                        
                    }                    
                    MessageDxUtil.ShowTips("批量作废成功");
                    //刷新内容
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError("作废异常"+ex.Message);
                return;
            }
        }
    }
}
