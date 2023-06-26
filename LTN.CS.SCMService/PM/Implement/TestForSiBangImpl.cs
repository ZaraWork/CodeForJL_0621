using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LTN.CS.SCMService.PM.Implement
{
    public class TestForSiBangImpl : TestForSiBangService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");

        public IList<TestForSiBang> ExecuteDB_queryTestInfoAll()
        {
            IList<TestForSiBang> rs;
            try
            {              
                rs = CommonDao.ExecuteQueryForList<TestForSiBang>("selectTestInfoAll", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }        
        public IList<TestForSiBang> ExecuteDB_queryTestInfoByName(string name)
        {
            IList<TestForSiBang> rs;
            try
            {
                rs = CommonDao.ExecuteQueryForList<TestForSiBang>("selectTestInfoByName", name);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }
    }
}
