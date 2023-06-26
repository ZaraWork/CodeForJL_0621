using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_DataComparisonForBeltAndSupplies
    {
        public string shipName { get; set; }
        public string contractNo{ get; set; }
        public string materialName { get; set; }
        public string voyageNo { get; set; }
        public string plan_id { get; set; }
        public decimal waterGuage_weight { get; set; }
        public decimal wharf_beltWeight { get; set; }
        public decimal beltWeight { get; set; }
        public decimal suppliesWeight { get; set; }
        public string shipArriveTime { get; set; }
        public string mw { get; set; }
        public string sw { get; set; }
    }
}
