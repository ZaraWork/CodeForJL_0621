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
    public class PM_Pond_Bill_Cars_PrintServiceImpl : IPM_Pond_Bill_Cars_PrintService
    {
        public ICommonDao CommonDao { get; set; }
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_InsertPM_Pond_Bill_Cars_Print(PM_Pond_Bill_Cars_Print printEntity)
        {
            object rs;
            try
            {

                rs = CommonDao.ExecuteInsert("InsertPM_Pond_Bill_Cars_Print", printEntity);
                if (rs == null)
                {
                    rs = 1;
                }
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
        public IList<PM_Pond_Bill_Cars_Print> ExecuteDB_QueryPM_Pond_Bill_Cars_PrintByHashtable(Hashtable ht)
        {
            IList<PM_Pond_Bill_Cars_Print> rs = null;
            try
            {
                rs = CommonDao.ExecuteQueryForList<PM_Pond_Bill_Cars_Print>("QueryPM_Pond_Bill_Cars_PrintByHashtable", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return rs;
        }
    }
}
