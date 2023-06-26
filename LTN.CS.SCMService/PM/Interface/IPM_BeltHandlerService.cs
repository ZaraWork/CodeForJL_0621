﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;

using LTN.CS.SCMEntities.ConditionEntity;


namespace LTN.CS.SCMService.PM.Interface
{
    public interface IPM_BeltHandlerService
    {
        List<PM_BeltTimeCount> getBeltRunTime(Hashtable ht);

        Dictionary<string,Decimal> getBeltCount(Hashtable ht);  
        
    }
}
