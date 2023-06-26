using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_Bill_Belt_HistoryServiceImpl : IPM_Bill_Belt_HistoryService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<PM_Bill_Belt_History> ExecuteDB_QueryPM_Bill_BeltHistoryByHashtable(Hashtable ht)
        {
            IList<PM_Bill_Belt_History> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Bill_Belt_History>("QueryPM_Bill_Belt_HistoryByHashtable", ht);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }            
            return rs;
        }

        public object ExecuteDB_InsertPM_Bill_Belt(PM_Bill_Belt_History historyBill)
        {
            object rs;
            try
            {                
                rs = CommonDao.ExecuteInsert("InsertPM_Bill_Belt_History", historyBill);                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
        
        public PM_Bill_Belt_History ExecuteDB_QueryPM_Bill_BeltHistoryByWgtlistno(int I_Intid)
        {
            PM_Bill_Belt_History rs;
            try
            {
                rs = CommonDao.ExecuteQueryForObject<PM_Bill_Belt_History>("QueryPM_Bill_Belt_HistoryByWgtlistno", I_Intid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
    }
}
