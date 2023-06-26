using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Bill_Belt_HistoryService
    {
        IList<PM_Bill_Belt_History> ExecuteDB_QueryPM_Bill_BeltHistoryByHashtable(Hashtable ht);
        object ExecuteDB_InsertPM_Bill_Belt(PM_Bill_Belt_History bill);
        PM_Bill_Belt_History ExecuteDB_QueryPM_Bill_BeltHistoryByWgtlistno(int wgtlistno);
    }
}
