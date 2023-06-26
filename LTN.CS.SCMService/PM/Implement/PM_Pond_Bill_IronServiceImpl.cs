using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.Core.Common;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using System.Net;
using LTN.CS.Core.Helper;
using LTN.CS.Base.Common;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Pond_Bill_IronServiceImpl : IPM_Pond_Bill_IronService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryAll()
        {
            IList<PM_Pond_Bill_Iron> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        public object ExecuteDB_InsertIronInfo(PM_Pond_Bill_Iron pond)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Iron", pond);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateIronInfo(PM_Pond_Bill_Iron pond)
        {
            object rs;
            try
            {
                //2022 5.9 李佳政 
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];//获取IP
                PM_Pond_Bill_Iron OldPondBill = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Iron>("QueryBywgiston1", pond.WgtlistNo);
                PM_Pond_Bill_Iron_History HistoryPondBill = new PM_Pond_Bill_Iron_History();
                SetBillValueToHistoryBill(OldPondBill, HistoryPondBill);
                HistoryPondBill.UpDateColumns = CompareHistoryBill(pond, OldPondBill);
                HistoryPondBill.UpDateHistoryTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                HistoryPondBill.UpDateHistoryUser = SessionHelper.LogUserNickName;
                HistoryPondBill.ComputerIp = ipAddr.ToString();
                //是否修改过数据到磅单历史表？更新此数据：插入新数据
                var IsExist = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron_History>("QueryPM_Pond_Bill_Iron_History", HistoryPondBill.WgtlistNo);
                if (IsExist.Count != 0)
                {
                    CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_Iron_History", HistoryPondBill);
                }
                else
                {
                    CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Iron_History", HistoryPondBill);
                }

                rs = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_Iron", pond);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_DeleteIronInfo(PM_Pond_Bill_Iron pond)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeletePM_Pond_Bill_Iron", pond);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InvalidIronPondByIntId(PM_Pond_Bill_Iron pond)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdatePM_Pond_Bill_IronFlag", pond);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryIronPondByHashTable(Hashtable ht)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                //result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronByCond", ht);
                //修改成按照磅单修改时间来排序
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronByCond3", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryByDic(Hashtable dic)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronbyDic", dic);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryByGroup(string FormationTag)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronbyGroup", FormationTag);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }


        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryBySiteAndTagFormation(Hashtable ht)
        {
            IList<PM_Pond_Bill_Iron> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("selectPM_Pond_Bill_IronbySiteAndTagFormation", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        //2022.5.9 李佳政
        public void SetBillValueToHistoryBill(PM_Pond_Bill_Iron _OldPondBill, PM_Pond_Bill_Iron_History _HistoryPondBill)
        {
            _HistoryPondBill.PlanNo = _OldPondBill.PlanNo;
            _HistoryPondBill.HeatNo = _OldPondBill.HeatNo;
            _HistoryPondBill.BatchNo = _OldPondBill.BatchNo;
            _HistoryPondBill.LronNo = _OldPondBill.LronNo;
            _HistoryPondBill.TankNo = _OldPondBill.TankNo;
            _HistoryPondBill.ToDeptNo = _OldPondBill.ToDeptNo;
            _HistoryPondBill.ToDeptName = _OldPondBill.ToDeptName;
            _HistoryPondBill.Remark = _OldPondBill.Remark;
            _HistoryPondBill.CReserve1 = _OldPondBill.CReserve1;
            _HistoryPondBill.CReserve2 = _OldPondBill.CReserve2;
            _HistoryPondBill.CReserve3 = _OldPondBill.CReserve3;
            _HistoryPondBill.IReserve1 = _OldPondBill.IReserve1;
            _HistoryPondBill.IReserve2 = _OldPondBill.IReserve2;
            _HistoryPondBill.IReserve3 = _OldPondBill.IReserve3;
            _HistoryPondBill.PlanCreateUser = _OldPondBill.PlanCreateUser;
            _HistoryPondBill.PlanCreateTime = _OldPondBill.PlanCreateTime;
            _HistoryPondBill.IntId = _OldPondBill.IntId;
            _HistoryPondBill.WgtlistNo = _OldPondBill.WgtlistNo;
            _HistoryPondBill.GrossWgt = _OldPondBill.GrossWgt;
            _HistoryPondBill.TareWgt = _OldPondBill.TareWgt;
            _HistoryPondBill.TareWgt1 = _OldPondBill.TareWgt1;
            _HistoryPondBill.NetWgt = _OldPondBill.NetWgt;
            _HistoryPondBill.NetWgt1 = _OldPondBill.NetWgt1;
            _HistoryPondBill.SlagNum = _OldPondBill.SlagNum;
            _HistoryPondBill.NetWgt2 = _OldPondBill.NetWgt2;
            _HistoryPondBill.GrossWgtTime = _OldPondBill.GrossWgtTime;
            _HistoryPondBill.TareWgtTime = _OldPondBill.TareWgtTime;
            _HistoryPondBill.GrossWgtSiteNo = _OldPondBill.GrossWgtSiteNo;
            _HistoryPondBill.GrossWgtSiteName = _OldPondBill.GrossWgtSiteName;
            _HistoryPondBill.TareWgtSiteNo = _OldPondBill.TareWgtSiteNo;
            _HistoryPondBill.TareWgtSiteName = _OldPondBill.TareWgtSiteName;
            _HistoryPondBill.GrossWgtMan = _OldPondBill.GrossWgtMan;
            _HistoryPondBill.TareWgtMan = _OldPondBill.TareWgtMan;
            _HistoryPondBill.PondRemark = _OldPondBill.PondRemark;
            _HistoryPondBill.IntId = _OldPondBill.IntId;
            _HistoryPondBill.WgtlistNo = _OldPondBill.WgtlistNo;
            _HistoryPondBill.GrossWgt = _OldPondBill.GrossWgt;
            _HistoryPondBill.TareWgt = _OldPondBill.TareWgt;
            _HistoryPondBill.TareWgt1 = _OldPondBill.TareWgt1;
            _HistoryPondBill.NetWgt = _OldPondBill.NetWgt;
            _HistoryPondBill.NetWgt1 = _OldPondBill.NetWgt1;
            _HistoryPondBill.SlagNum = _OldPondBill.SlagNum;
            _HistoryPondBill.NetWgt2 = _OldPondBill.NetWgt2;
            _HistoryPondBill.GrossWgtTime = _OldPondBill.GrossWgtTime;
            _HistoryPondBill.TareWgtTime = _OldPondBill.TareWgtTime;
            _HistoryPondBill.GrossWgtSiteNo = _OldPondBill.GrossWgtSiteNo;
            _HistoryPondBill.GrossWgtSiteName = _OldPondBill.GrossWgtSiteName;
            _HistoryPondBill.TareWgtSiteNo = _OldPondBill.TareWgtSiteNo;
            _HistoryPondBill.TareWgtSiteName = _OldPondBill.TareWgtSiteName;
            _HistoryPondBill.GrossWgtMan = _OldPondBill.GrossWgtMan;
            _HistoryPondBill.TareWgtMan = _OldPondBill.TareWgtMan;
            _HistoryPondBill.PondRemark = _OldPondBill.PondRemark;
            _HistoryPondBill.CReserveFlag1 = _OldPondBill.CReserveFlag1;
            _HistoryPondBill.CReserveFlag2 = _OldPondBill.CReserveFlag2;
            _HistoryPondBill.CReserveFlag3 = _OldPondBill.CReserveFlag3;
            _HistoryPondBill.IReserveFlag1 = _OldPondBill.IReserveFlag1;
            _HistoryPondBill.IReserveFlag2 = _OldPondBill.IReserveFlag2;
            _HistoryPondBill.IReserveFlag3 = _OldPondBill.IReserveFlag3;
            _HistoryPondBill.CreateUser = _OldPondBill.CreateUser;
            _HistoryPondBill.CreateTime = _OldPondBill.CreateTime;
            _HistoryPondBill.UpdateUser = _OldPondBill.UpdateUser;
            _HistoryPondBill.UpdateTime = _OldPondBill.UpdateTime;
            _HistoryPondBill.DataFlag = _OldPondBill.DataFlag;
            _HistoryPondBill.BillStatus = _OldPondBill.BillStatus;
            _HistoryPondBill.TrainGroupGross = _OldPondBill.TrainGroupGross;
            _HistoryPondBill.TrainGroupTare = _OldPondBill.TrainGroupTare;
            _HistoryPondBill.PlanStatus = _OldPondBill.PlanStatus;
            _HistoryPondBill.UpLoadStatus = _OldPondBill.UpLoadStatus;


        }
        //2022.5.9 李佳政
        public string CompareHistoryBill(PM_Pond_Bill_Iron pond, PM_Pond_Bill_Iron OldPondBill)
        {
            string Columns = string.Empty;
            Type t1 = pond.GetType();
            Type t2 = OldPondBill.GetType();
            System.Reflection.PropertyInfo[] properties1 = t1.GetProperties();
            System.Reflection.PropertyInfo[] properties2 = t2.GetProperties();
            for (int i = 0; i < properties1.Length; i++)
            {
                if (properties1[i].GetValue(pond, null) == null && properties2[i].GetValue(OldPondBill, null) == null)
                {
                    continue;
                }
                //报红-在此过滤字段
                else if (properties1[i].Name == "CreateTime")
                {
                    continue;
                }

                //else if (Array.IndexOf(Unwanted, properties1[i].Name) != -1)
                //{
                //    continue;
                //}

                else if (properties1[i].GetValue(pond, null) == null || properties2[i].GetValue(OldPondBill, null) == null)
                {
                    object p1 = properties1[i].GetValue(pond, null);
                    object p2 = properties2[i].GetValue(OldPondBill, null);
                    string StrValue1 = string.Empty;
                    string StrValue2 = string.Empty;
                    if (p1 != null)
                    {
                        StrValue1 = p1.ToString();
                    }
                    if (p2 != null)
                    {
                        StrValue2 = p2.ToString();
                    }
                    if (!string.IsNullOrEmpty(StrValue1) || !string.IsNullOrEmpty(StrValue2))
                    {
                        Columns += properties1[i].Name.ToString() + "&" + p1 + "‖";
                        continue;
                    }
                }
                else if (properties1[i].GetValue(pond, null).ToString() != properties2[i].GetValue(OldPondBill, null).ToString())
                {
                    object p1 = properties1[i].GetValue(pond, null);
                    object p2 = properties2[i].GetValue(OldPondBill, null);
                    Columns += properties1[i].Name.ToString() + "&" + p1 + "‖";
                }


            }
            return Columns;

        }

        public object ExecuteDB_InsertDateToBillIron(PM_Pond_Bill_Iron pond)
        {
            object rss;
            try
            {
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                PM_Pond_Bill_Iron OldPondBill = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Iron>("QueryBywgiston1", pond.WgtlistNo);
                PM_Pond_Bill_Iron_History HistoryPondBill = new PM_Pond_Bill_Iron_History();
                SetBillValueToHistoryBill(OldPondBill, HistoryPondBill);
                //HistoryPondBill.UpDateColumns = "BillStatus.BillStatusDesc" + "&" + "作废" + "‖";
                HistoryPondBill.UpDateColumns = " ";
                HistoryPondBill.UpDateHistoryTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                HistoryPondBill.UpDateHistoryUser = SessionHelper.LogUserNickName;
                HistoryPondBill.ComputerIp = ipAddr.ToString();
                HistoryPondBill.IReserveFlag1 = 1;
                rss = CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Iron_History", HistoryPondBill);
 
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rss = null;
            }
            return rss;
        
        }



    }
}
