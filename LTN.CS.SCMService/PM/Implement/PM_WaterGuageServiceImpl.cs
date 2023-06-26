using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM;
using LTN.CS.SCMService.PM.Interface;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_WaterGuageServiceImpl : IPM_WaterGuageService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");       
        public IList<PM_Water_Guage_Info> ExecuteDB_QueryWaterGuageInfoAll(Hashtable ht)
        {
            IList<PM_Water_Guage_Info> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_Water_Guage_Info>("selectPM_Water_Guage_InfoByHt", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
    }
}
