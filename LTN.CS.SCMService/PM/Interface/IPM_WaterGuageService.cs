using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_WaterGuageService
    {
        IList<PM_Water_Guage_Info> ExecuteDB_QueryWaterGuageInfoAll(Hashtable ht);
    }
}
