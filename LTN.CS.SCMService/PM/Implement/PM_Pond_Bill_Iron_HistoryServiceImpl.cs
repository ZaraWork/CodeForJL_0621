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
    public class PM_Pond_Bill_Iron_HistoryServiceImpl : IPM_Pond_Bill_Iron_HistoryService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public IList<PM_Pond_Bill_Iron_History> ExecuteDB_QueryPM_Pond_Bill_Iron_HistoryByHashtable(Hashtable ht)
        {
            IList<PM_Pond_Bill_Iron_History> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron_History>("QueryPM_Pond_Bill_Iron_HistoryByHashtable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }

        public IList<PM_Pond_Bill_Iron> ExecuteDB_QueryIronIsRepeatByPlanNo(string PlanNo)
        {
            IList<PM_Pond_Bill_Iron> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Iron>("QueryIronDataIsRepeatByPlanNo", PlanNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
        public object ExecuteDB_UpdateIronPondByIntId(PM_Pond_Bill_Iron pond)
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

        public object ExecuteDB_UpdateIronHistroyDataFlagByIntId(PM_Pond_Bill_Iron_History history)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteUpdate("UpdateIronDataFlagByIntId", history);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        public PM_Pond_Bill_Iron ExecuteDB_QueryIronByWgtlistNo(string WgtlistNo)
        {
            PM_Pond_Bill_Iron result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<PM_Pond_Bill_Iron>("QueryBywgiston1", WgtlistNo);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
      
    }
}
