using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class OnlineCalibrate
    {
        public string t_calibrate_no;//校准记录编号

        public string t_operate_flag;//操作标识

        public string t_pond_no;//磅号

        public string t_calibrate_time;//校准时间

        public string t_calibrate_man;//校准人员

        public decimal t_standardWeight;//标准重量

        public decimal t_calibrateWeight;//校准实际重量

        public decimal t_weight_deviation_up;//上偏差

        public decimal t_weight_deviation_down;//下偏差

        public string t_reserve_v1;

        public string t_reserve_v2;

        public string t_reserve_v3;

        public string t_reserve_v4;

        public string t_reserve_v5;

        public string t_reserve_v6;
        
    }
}
