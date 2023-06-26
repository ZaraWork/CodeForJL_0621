using LTN.CS.SCMEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_Pond_Bill_Cars_Print
    {
        public int IntId { get; set; }//主键
        public string WgtlistNo { get; set; }//码单号
        public string PlanNo { get; set; }//委托单号
        public string MaterialName { get; set; }//品名名称
        public string CarName { get; set; }//车牌
        public int PrintNum { get; set; }//打印次数
        public string Printer { get; set; }//打印人
        public string PrintTime { get; set; }//打印时间
        public string ComputerIp { get; set; }//打印ip
    }
}
