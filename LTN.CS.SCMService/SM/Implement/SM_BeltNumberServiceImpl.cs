using LTN.CS.SCMService.SM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.SM;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using LTN.CS.Core.Common;

namespace LTN.CS.SCMService.SM.Implement
{
    public class SM_BeltNumberServiceImpl : ISM_BeltNumberService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        public object ExecuteDB_DeleteBeltbitInfo(SM_BeltNumber belt)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_BeltNumber", belt);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        public object ExecuteDB_InsertBeltbitInfo(SM_BeltNumber belt)
        {
            object rs;
            try
            {
                //rs = CommonDao.ExecuteInsert("InsertSM_BeltNumber", belt);
                rs = CommonDao.ExecuteInsert("InsertSM_BeltNumber_New", belt);
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
        //selectSM_BeltNumberAll
        public IList<SM_BeltNumber> ExecuteDB_QueryAll()
        {
            IList<SM_BeltNumber> rs;
            try
            {
                //rs = CommonDao.ExecuteQueryForList<SM_BeltNumber>("selectSM_BeltNumberAll", null);
                rs = CommonDao.ExecuteQueryForList<SM_BeltNumber>("selectSM_BeltNumberAll_New", null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public IList<SM_BeltNumber> ExecuteDB_QueryBeltNumberByBeltNo(string beltno)
        {
            IList<SM_BeltNumber> rs;
            try
            {

                rs = CommonDao.ExecuteQueryForList<SM_BeltNumber>("selectSM_BeltNumberByBeltNo", beltno);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                rs = null;
            }
            return rs;
        }

        public object ExecuteDB_UpdateBeltbitInfo(SM_BeltNumber belt)
        {
            object rs;
            try
            {
                //rs = CommonDao.ExecuteUpdate("UpdateSM_BeltNumber", belt);
                rs = CommonDao.ExecuteUpdate("UpdateSM_BeltNumber_New", belt);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }

        //新增  潘鹏
        /// <summary>
        /// 按照idList批量删除，提高效率
        /// </summary>
        /// <param name="belt"></param>
        /// <returns></returns>
        public object ExecuteDB_DeleteBeltBitInfoByIntIdList(List<int> list)
        {
            object rs;
            try
            {
                rs = CommonDao.ExecuteDelete("DeleteSM_BeltInfoByIntIdList", list);
            }
            catch (Exception ex)
            {
                rs = new CustomDBError(ex.Message);
            }
            return rs;
        }
    }
}
