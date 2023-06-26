using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Common
{
    public enum BusinessTypes
    {
        InFactory = 0,//进厂
        OutFactory = 1,//出厂
        Transfer = 2,//内倒
        Train = 3,//火车虚拟进厂
        cgnz = 4,//采购汽运内转
        hcjzx = 8,//火车集装箱进
    }
}
