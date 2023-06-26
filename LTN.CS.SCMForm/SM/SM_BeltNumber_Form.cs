using DevExpress.XtraEditors.DXErrorProvider;
using LTN.CS.Base;
using LTN.CS.Core.Common;
using LTN.CS.Core.Helper;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMForm.Common;
using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTN.CS.SCMForm.SM
{
    public partial class SM_BeltNumber_Form : CoreForm
    {
        private EventHandler eventMainNow;
        private int selectMainId { get; set; }
        private int selectMainRowNum { get; set; }
        private SM_BeltNumber selectMainEntity { get; set; }

        private bool queryMain { get; set; }
        public ISM_BeltNumberService MainService { get; set; }
        public SM_BeltNumber_Form()
        {
            InitializeComponent();
        }
        #region 自定义方法

        private void SetMainGridData(bool isFirst)
        {
            WaitCallback wc = (o) =>
            {
                Action ac = () =>
                {
                    int selectLeftIdOld = selectMainId;

                    queryMain = false;
                    var rss = MainService.ExecuteDB_QueryAll();
                    if (rss != null)
                    {
                        List<SM_BeltNumber> data = rss.ToList();
                        data.ForEach(r =>
                        {
                            if (r.C_UpdateTime != null)
                            {
                                r.C_UpdateTime = CommonHelper.Str14ToTimeFormart(r.C_UpdateTime);
                            }
                            if (r.C_CreateTime != null)
                            {
                                r.C_CreateTime = CommonHelper.Str14ToTimeFormart(r.C_CreateTime);
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
                    SetMainEditerData();
                    SetMainEditerEnabled(false);
                    SetMainButtonEnabled(true);
                };
                Invoke(ac);
            };
            ThreadPool.QueueUserWorkItem(wc);
        }
        private void SetMainFocusRow()
        {
            int rowcount = gvw_main.RowCount;
            bool isFocused = false;
            if (selectMainId != 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    SM_BeltNumber group = gvw_main.GetRow(i) as SM_BeltNumber;
                    if (group.IntId == selectMainId)
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
        private void SetMainEditerData()
        {
            if (queryMain)
            {
                queryMain = false;
                var entity = gvw_main.GetFocusedRow() as SM_BeltNumber;
                if (entity != null)
                {
                    SetMainEditer(entity);
                }
                else
                {
                    ClearMainEditer();
                }
                selectMainEntity = entity;
                queryMain = true;
                SetMainEditerEnabled(false);
            }
        }
        private void SetMainEditerEnabled(bool enabled)
        {
            txt_BeltName.Enabled = enabled;
            txt_BeltNo.Enabled = enabled;
            txt_BitNo.Enabled = enabled;
            txt_BeltFINo.Enabled = enabled;
            txt_BeltVINo.Enabled = enabled;
            if (enabled)
            {
                txt_BeltName.Focus();
            }
        }
        private void SetMainButtonEnabled(bool enabled)
        {
            if (enabled)
            {
                btn_insert.Enabled = true;
                btn_confirm.Enabled = false;
                btn_cancel.Enabled = false;
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
            else
            {
                btn_insert.Enabled = false;
                btn_confirm.Enabled = true;
                btn_cancel.Enabled = true;
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
            }
        }
        private void SetMainEditer(SM_BeltNumber entity)
        {
            if (entity != null)
            {
                txt_BeltName.EditValue = entity.BeltId.C_Beltname;
                txt_BeltNo.EditValue = entity.BeltId.C_Beltno;
                txt_BitNo.EditValue = entity.BITNO;
                txt_BeltFINo.EditValue = entity.C_BeltFINo;
                txt_BeltVINo.EditValue = entity.C_BeltVINo;
            }
        }
        private void ClearMainEditer()
        {
            txt_BeltName.EditValue = string.Empty;
            txt_BeltNo.EditValue = string.Empty;
            txt_BitNo.EditValue = string.Empty;
            txt_BeltFINo.EditValue = string.Empty;
            txt_BeltVINo.EditValue = string.Empty;
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            ClearMainEditer();
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainInsert;
            btn_confirm.Click += eventMainNow;
        }
        private void CustomMainInsert(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                ResetSelectMainEntity();

                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_InsertBeltbitInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        selectMainId = Convert.ToInt32(rs);
                        SetMainGridData(false);
                        btn_confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            //对选中行的数据进行修改           
            int[] rows = gvw_main.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageDxUtil.ShowTips("请勾选要修改的数据");
                return;
            }
            else if(rows.Length > 1)
            {
                MessageDxUtil.ShowTips("请选择一条数据进行修改");
                return;
            }            
            SetMainEditerEnabled(true);
            SetMainButtonEnabled(false);
            eventMainNow = CustomMainUpdate;
            btn_confirm.Click += eventMainNow;
        }
        private void CustomMainUpdate(object sender, EventArgs e)
        {
            try
            {
                ResetSelectMainEntity();
                if (!dxErrorProvider1.HasErrors)
                {
                    var rs = MainService.ExecuteDB_UpdateBeltbitInfo(selectMainEntity);
                    if (rs is CustomDBError)
                    {
                        MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                    }
                    else
                    {
                        SetMainGridData(false);
                        btn_confirm.Click -= eventMainNow;
                        eventMainNow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            /*
            SM_BeltNumber bn = gvw_main.GetFocusedRow() as SM_BeltNumber;
            if (bn == null)
            {
                MessageDxUtil.ShowWarning("没有数据可以删除!");
                return;
            }
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                CustomMainDelete();
            }
            */
            int[] rows = gvw_main.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageDxUtil.ShowTips("请勾选要作废的配置信息");
                return;
            }
            var rs = MessageDxUtil.ShowYesNoAndTips("确定删除吗?");
            if (rs == DialogResult.Yes)
            {
                List<int> list = new List<int>();
                foreach(var item in rows)
                {
                    SM_BeltNumber bill = gvw_main.GetRow(item) as SM_BeltNumber;
                    list.Add(bill.IntId);
                }
                CustomMainDelete(list);
            }
        }
        private void CustomMainDelete(List<int> list)
        {
            try
            {
                //var rs = MainService.ExecuteDB_DeleteBeltbitInfo(selectMainEntity);
                var rs = MainService.ExecuteDB_DeleteBeltBitInfoByIntIdList(list);
                if (rs is CustomDBError)
                {
                    MessageDxUtil.ShowError("操作失败：" + ((CustomDBError)rs).ErrorMsg);
                }
                else
                {
                    SetMainGridData(false);
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
        private void ResetSelectMainEntity()
        {
            if (txt_BeltNo.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_BeltNo, "皮带编号为必填！", ErrorType.Information);
                return;
            }
            if (txt_BitNo.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_BitNo, "累积量位号为必填！", ErrorType.Information);
                return;
            }
            if (txt_BeltFINo.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_BitNo, "瞬时位号为必填！", ErrorType.Information);
                return;
            }
            if (txt_BeltVINo.Text == string.Empty)
            {
                dxErrorProvider1.SetError(txt_BitNo, "速度位号为必填！", ErrorType.Information);
                return;
            }

            var beltno = MainService.ExecuteDB_QueryBeltNumberByBeltNo(txt_BeltNo.Text.Trim());

            if (eventMainNow.Method.Name == "CustomMainInsert")
            {
                if (beltno != null && beltno.Count() > 0)
                {
                    dxErrorProvider1.SetError(txt_BeltNo, "该皮带编号已经存在!", ErrorType.Information);
                    return;
                }
                selectMainEntity = new SM_BeltNumber()
                {
                    C_CreateUserName = SessionHelper.LogUserNickName,
                    C_CreateTime = DateTime.Now.ToString("yyyyMMddHHmmss")
                };
            }
            if (eventMainNow.Method.Name == "CustomMainUpdate")
            {
                selectMainEntity.C_UpdateUserName = SessionHelper.LogUserNickName;
                selectMainEntity.C_UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                if (beltno != null && beltno.Count() > 0 && beltno[0].IntId != selectMainEntity.IntId)
                {
                    dxErrorProvider1.SetError(txt_BeltNo, "该皮带编号已经存在!", ErrorType.Information);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txt_BeltNo.Text))
            {
                selectMainEntity.BeltId = new PM_Bill_Belt() {  C_Beltno = txt_BeltNo.Text,C_Beltname=txt_BeltName.Text };
            }
            else
            {
                selectMainEntity.BeltId = new PM_Bill_Belt();
            }
            selectMainEntity.BITNO = txt_BitNo.Text;
            selectMainEntity.C_BeltFINo = txt_BeltFINo.Text;
            selectMainEntity.C_BeltVINo = txt_BeltVINo.Text;                        
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_confirm.Click -= eventMainNow;
            dxErrorProvider1.ClearErrors();
            eventMainNow = null;
            SetMainEditerEnabled(false);
            SetMainButtonEnabled(true);
            gvw_main_FocusedRowChanged(null, null);
        }

        #endregion

        private void gvw_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (queryMain && eventMainNow == null)
            {
                var entity = gvw_main.GetFocusedRow() as SM_BeltNumber;
                if (entity != null)
                {
                    SetMainEditer(entity);
                    selectMainId = entity.IntId;
                    selectMainRowNum = gvw_main.FocusedRowHandle;
                }
                selectMainEntity = entity;
            }
        }

        private void SM_BeltNumber_Form_Shown(object sender, EventArgs e)
        {
            SetMainGridData(false);
            SetMainButtonEnabled(true);

        }


    }
}
