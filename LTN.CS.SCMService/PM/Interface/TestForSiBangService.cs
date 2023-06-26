using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;

namespace LTN.CS.SCMService.PM.Interface
{
    public interface TestForSiBangService
    {
        IList<TestForSiBang> ExecuteDB_queryTestInfoAll();

        IList<TestForSiBang> ExecuteDB_queryTestInfoByName(string name);       
    }
}
