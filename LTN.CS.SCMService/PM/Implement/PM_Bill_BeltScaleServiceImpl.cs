using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using System.Net;
using LTN.CS.Core.Helper;

namespace LTN.CS.SCMService.PM.Implement
{
   public  class PM_Bill_BeltScaleServiceImpl: IPM_Bill_BeltScaleService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IPM_Bill_Belt_HistoryService historyService { get; set; }
        public IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable(Hashtable ht)
        {
            IList<PM_Bill_Belt> rs;            
            if (ht["totalNum"].ToString() == "Y")
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_Totally", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }
            else
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_All", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }                   
            return rs;
        }

        public IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable2(Hashtable ht)
        {
            IList<PM_Bill_Belt> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable2", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdatePM_Bill_Belt(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {
                //将修改记录插入到历史表
                PM_Bill_Belt_History history = CreateBillBeltHistoryInfo(BeltBill, "U");
               
                rs = CommonDao.ExecuteUpdate("UpdatePM_Bill_Belt", BeltBill);

                if(history != null)
                {
                    var result = historyService.ExecuteDB_InsertPM_Bill_Belt(history);
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertPM_Bill_Belt(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {
                string WgtNo = CommonDao.ExecuteQueryForObject<string>("CreateWgtNo", null);

                BeltBill.C_Wgtlistno = BeltBill.C_Beltno + WgtNo;
                rs = CommonDao.ExecuteInsert("InsertPM_Bill_Belt", BeltBill);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InvalidPM_Bill_Belt(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("InvalidPM_Bill_Belt", BeltBill);
                //将作废磅单数据插入到操作记录表中
                PM_Bill_Belt_History beltHistoryInfo = CreateBillBeltHistoryInfo(BeltBill, "D");
                var result = historyService.ExecuteDB_InsertPM_Bill_Belt(beltHistoryInfo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<PM_Belt_ServerLog> ExecuteDB_QueryBeltServerLog(Hashtable ht)
        {
            IList<PM_Belt_ServerLog> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Belt_ServerLog>("QueryPM_Belt_ServerLog", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<PM_Bill_Belt> ExecuteDB_QueryBeltHourlyPondByPlan(string planno)
        {
            IList<PM_Bill_Belt> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByPlan", planno);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdatePM_Bill_Belt_Mark(List<string> s)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteUpdate("updatePM_Bill_Belt_Mark", s);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }        

        public string ExecuteDB_QueryWgtlistno(string value)
        {
            string rs;
            try
            {
                rs = CommonDao.ExecuteQueryForObject<string>("CreateWgtNo_New", value);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_InsertPM_Bill_Belt_ForRJ(PM_Bill_Belt BeltBill)
        {
            object rs;
            try
            {                
                rs = CommonDao.ExecuteInsert("InsertPM_Bill_BeltForRJ", BeltBill);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        /// <summary>
        /// 2022-11-15 新增 按开始时间查询
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable_startTime(Hashtable ht)
        {
            IList<PM_Bill_Belt> rs;
            if (ht["totalNum"].ToString() == "Y")
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_Totally_StartTime", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }
            else
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_All_StartTime", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }
            return rs;
        }

        /// <summary>
        /// 2022-11-15 新增 按结束时间查询
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public IList<PM_Bill_Belt> ExecuteDB_QueryPM_Bill_BeltByHashtable_endTime(Hashtable ht)
        {
            IList<PM_Bill_Belt> rs;
            if (ht["totalNum"].ToString() == "Y")
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_Totally_EndTime", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }
            else
            {
                try
                {
                    rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("QueryPM_Bill_BeltByHashtable_All_EndTime", ht);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    rs = null;
                }
            }
            return rs;
        }

        

        public PM_Bill_Belt ExecuteDB_QueryPM_Bill_BeltByWgtListNo(string wgtlistno)
        {
            PM_Bill_Belt rs;
            try
            {                
                rs = CommonDao.ExecuteQueryForObject<PM_Bill_Belt>("QueryPM_Bill_BeltByWgtListNo", wgtlistno);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }


        ///历史记录相关
        private PM_Bill_Belt_History CreateBillBeltHistoryInfo(PM_Bill_Belt bill, string operateFlag)
        {
            PM_Bill_Belt_History history = null;                        
            if (bill == null) return history;
            history = valuationBeltHistory(bill);
            string wgtlistno = bill.C_Wgtlistno;
            Dictionary<string, string> dic = null;
            if (operateFlag.Equals("D"))
            {
                history.C_Planstatus = "D";
                history.I_BillStatus = 1;
                history.c_changedFields = "c_planStatus|i_billStatus";
                history.c_changedContent = "c_planStatus:I-->D|i_billStatus:0-->1";                                                                             
            }
            else
            {
                //分析修改了哪些字段、从什么改成了什么                              
                PM_Bill_Belt oldBill = ExecuteDB_QueryPM_Bill_BeltByWgtListNo(wgtlistno);                
                dic = ComparecurrentBill(bill, oldBill);
                if (string.IsNullOrEmpty(dic["columns"].ToString()) && string.IsNullOrEmpty(dic["content"].ToString())) return null;
                history.c_changedFields = dic["columns"].ToString();
                history.c_changedContent = dic["content"].ToString();
            }
            
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            history.c_operateIp = ipAddr.ToString();
            history.c_historyUpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            history.c_historyUpdateUserName = SessionHelper.LogUserNickName;
            return history;
        }

        private PM_Bill_Belt_History valuationBeltHistory(PM_Bill_Belt bill)
        {
            PM_Bill_Belt_History history = new PM_Bill_Belt_History();
            history.C_Planstatus = bill.C_Planstatus;
            history.C_Planno = bill.C_Planno;
            history.C_Materialno = bill.C_Materialno;
            history.C_Materialname = bill.C_Materialname;
            history.C_Fromdeptno = bill.C_Fromdeptno;
            history.C_Fromdeptname = bill.C_Fromdeptname;
            history.C_Fromstoreno = bill.C_Fromstoreno;
            history.C_Fromstorename = bill.C_Fromstorename;
            history.C_Todeptno = bill.C_Todeptno;
            history.C_Todeptname = bill.C_Todeptname;
            history.C_Tostoreno = bill.C_Tostoreno;
            history.C_Tostorename = bill.C_Tostorename;
            history.C_Beltno = bill.C_Beltno;
            history.C_Beltname = bill.C_Beltname;
            history.C_Shipno = bill.C_Shipno;
            history.C_Contractno = bill.C_Contractno;
            history.C_Voyageno = bill.C_Voyageno;
            history.C_Starttime = bill.C_Starttime;
            history.C_Endtime = bill.C_Endtime;
            history.C_Createtime = bill.C_Createtime;
            history.C_Createname = bill.C_Createtime;
            history.C_Remark = bill.C_Remark;
            history.C_Reserve1 = bill.C_Reserve1;
            history.C_Reserve2 = bill.C_Reserve2;
            history.C_Reserve3 = bill.C_Reserve3;
            history.I_Reserve1 = bill.I_Reserve1;
            history.I_Reserve2 = bill.I_Reserve2;
            history.I_Reserve3 = bill.I_Reserve3;
            history.C_Wgtlistno = bill.C_Wgtlistno;
            history.N_Startwgt = bill.N_Startwgt;
            history.N_Endwgt = bill.N_Endwgt;
            history.N_Netwgt = bill.N_Netwgt;
            history.C_Measurestarttime = bill.C_Measurestarttime;
            history.C_Measureendtime = bill.C_Measureendtime;
            history.C_Measureman = bill.C_Measureman;
            history.C_Updateusername = bill.C_Updateusername;
            history.C_Updatetime = bill.C_Updatetime;
            history.C_Billcreatetime = bill.C_Billcreatetime;
            history.C_Billcreateusername = bill.C_Billcreateusername;
            history.I_BillStatus = bill.I_BillStatus;
            history.C_RESERVE4 = bill.C_RESERVE4;
            history.C_RESERVE5 = bill.C_RESERVE5;
            history.C_RESERVE6 = bill.C_RESERVE6;
            history.C_RESERVE7 = bill.C_RESERVE7;
            history.C_RESERVE8 = bill.C_RESERVE8;
            return history;
        }

        /// <summary>
        /// 获取修改前后磅单数据不同的字段
        /// </summary>
        /// <param name="TruckBill"></param>
        /// <param name="OldTruckBill"></param>
        /// <returns></returns>
        public Dictionary<string, string> ComparecurrentBill(PM_Bill_Belt currentBill, PM_Bill_Belt oldBill)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string columns = string.Empty;
            string content = string.Empty;
            Type t1 = currentBill.GetType();
            Type t2 = oldBill.GetType();
            System.Reflection.PropertyInfo[] properties1 = t1.GetProperties();
            System.Reflection.PropertyInfo[] properties2 = t2.GetProperties();
            List<string> list = new List<string>() { "C_Uploadstatus", "C_Updateusername", "C_Updatetime" };
            for (int i = 0; i < properties1.Length; i++)
            {
                if (properties1[i].GetValue(currentBill, null) == null && properties2[i].GetValue(oldBill, null) == null)
                {
                    continue;
                }
                else if (properties1[i].GetValue(currentBill, null) == null || properties2[i].GetValue(oldBill, null) == null)
                {
                    object p1 = properties1[i].GetValue(currentBill, null);
                    object p2 = properties2[i].GetValue(oldBill, null);
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
                        columns += properties1[i].Name.ToString() + "|";
                        content += properties1[i].Name.ToString() + ":"  + (string.IsNullOrEmpty(StrValue2) ? "null" : StrValue2) + "-->" + (string.IsNullOrEmpty(StrValue1) ? "null" : StrValue1) + "|";
                        continue;
                    }
                }
                else if (properties1[i].GetValue(currentBill, null).ToString() != properties2[i].GetValue(oldBill, null).ToString())
                {
                    string p1 = properties1[i].GetValue(currentBill, null).ToString();
                    string p2 = properties2[i].GetValue(oldBill, null).ToString();
                    if (list.Contains(properties1[i].Name.ToString())) continue;
                    if (properties1[i].Name.ToString().Equals("N_Netwgt"))
                    {
                        if (decimal.Parse(p1) - decimal.Parse(p2) == 0) continue;
                    }
                    columns += properties1[i].Name.ToString() + "|";
                    content += properties1[i].Name.ToString() + ":"+ (string.IsNullOrEmpty(p2)?"null":p2) +"-->" +(string.IsNullOrEmpty(p1)?"null":p1) + "|";
                }
            }
            dic.Add("columns", columns);
            dic.Add("content", content);
            return dic;
        }

    }
}
