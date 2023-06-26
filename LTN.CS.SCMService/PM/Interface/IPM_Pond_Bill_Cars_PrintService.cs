using LTN.CS.SCMEntities.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_Pond_Bill_Cars_PrintService
    {
        object ExecuteDB_InsertPM_Pond_Bill_Cars_Print(PM_Pond_Bill_Cars_Print printEntity);
        IList<PM_Pond_Bill_Cars_Print> ExecuteDB_QueryPM_Pond_Bill_Cars_PrintByHashtable(Hashtable ht);
    }
}
