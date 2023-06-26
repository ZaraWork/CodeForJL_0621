using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_DataComparisonService
    {
        Dictionary<string, string> ExecuteDB_QueryPlanId(Hashtable ht);
        IList<PM_DataComparisonForBeltAndSupplies> ExecuteDB_QueryBeltAndSuppliesData(Hashtable ht);
        IList<string> ExecuteDB_QueryContractNos(Hashtable ht);
        object ExecuteDB_QueryMTBeltWeight(string str,string str2);
        Dictionary<string, object> ExecuteDB_QueryBeltData(string str);
        object ExecuteDB_QuerySuppliesWeight(string str);
        IList<PM_Water_Guage_Info> ExecuteDB_QueryWaterGuageInfoByContractNo(string str,string str2);
    }
}
