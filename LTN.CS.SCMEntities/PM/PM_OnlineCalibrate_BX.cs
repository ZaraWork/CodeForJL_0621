using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_OnlineCalibrate_BX
    {
        public string t_calibrate_no { get; set; }
        public string t_pond_no { get; set; }//磅号
        public string t_calibrate_time { get; set; }//校准时间
        public string t_calibrate_man { get; set; }//校准人员
        public decimal t_standardWeight { get; set; }//标准重量
        public decimal t_calibrateWeight { get; set; }//校准实际重量
        public decimal t_weight_deviation_up { get; set; }//上偏差
        public decimal t_weight_deviation_down { get; set; }//下偏差
        public string t_reserve_v1 { get; set; }
        public string t_reserve_v2 { get; set; }
        public string t_reserve_v3 { get; set; }
        public string t_reserve_v4 { get; set; }
        public string t_reserve_v5 { get; set; }
        public string t_reserve_v6 { get; set; }
        public int t_billStatus { get; set; }//数据状态
        public decimal t_weight_deviation { get; set; }
    }
}
