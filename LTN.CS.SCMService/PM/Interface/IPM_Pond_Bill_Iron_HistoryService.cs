using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Pond_Bill_Iron_HistoryService
    {
        IList<PM_Pond_Bill_Iron_History> ExecuteDB_QueryPM_Pond_Bill_Iron_HistoryByHashtable(Hashtable ht);
        IList<PM_Pond_Bill_Iron> ExecuteDB_QueryIronIsRepeatByPlanNo(string PlanNo);
        PM_Pond_Bill_Iron ExecuteDB_QueryIronByWgtlistNo(string WgtlistNo);
        object ExecuteDB_UpdateIronPondByIntId(PM_Pond_Bill_Iron pond);
        object ExecuteDB_UpdateIronHistroyDataFlagByIntId(PM_Pond_Bill_Iron_History history);
        
    }
}
