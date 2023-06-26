using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IBatisNet.Common.Logging;
using LTN.CS.SCMDao.Common;
using LTN.CS.SCMEntities.PM;
using LTN.CS.SCMService.PM.Interface;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_DataComparisonServiceImpl:IPM_DataComparisonService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        /// <summary>
        /// 获取铁运的外发作业计划号
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public Dictionary<string,string> ExecuteDB_QueryPlanId(Hashtable ht)
        {
            Dictionary<string, string> dic = null;
            string resultStr = CommonDao.ExecuteQueryForObject<string>("SelectBeltAndSuppliesData", ht);
            if (!string.IsNullOrEmpty(resultStr))
            {
                dic.Add("planId", resultStr);
            }
            return dic;
        }

        /// <summary>
        /// 获得内转皮带秤数据和装车铁运数据
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public IList<PM_DataComparisonForBeltAndSupplies> ExecuteDB_QueryBeltAndSuppliesData(Hashtable ht)
        {
            IList<PM_DataComparisonForBeltAndSupplies> result;
            try
            {
                result = CommonDao.ExecuteQueryForList<PM_DataComparisonForBeltAndSupplies>("SelectBeltAndSuppliesData", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public IList<string> ExecuteDB_QueryContractNos(Hashtable ht)
        {
            IList<string> result = null;
            try
            {
                result = CommonDao.ExecuteQueryForList<string>("SelectContractNoByShipNameAndMaterial", ht);                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

       

        public Dictionary<string,object> ExecuteDB_QueryBeltData(string contractNo)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            try
            {
                object sum = CommonDao.ExecuteQueryForObject<object>("SelectBeltWeightByContractNo", contractNo);
                
                dic.Add("sum", sum == null ?0:Convert.ToDecimal(sum));

                IList<PM_Bill_Belt> dataList = CommonDao.ExecuteQueryForList<PM_Bill_Belt>("SelectBeltDataByContractNo", contractNo);
                if(dataList != null && dataList.Count > 0)
                {
                    PM_Bill_Belt data = dataList[0];
                    dic.Add("planId", data.C_Reserve3);
                    dic.Add("materialName", data.C_Materialname);
                }
                else
                {
                    dic.Add("planId", "");
                    dic.Add("materialName", "");
                }
                               
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                dic = null;
            }
            return dic;

        }

        public object ExecuteDB_QuerySuppliesWeight(string plan_id)
        {
            object result;
            try
            {
                result = CommonDao.ExecuteQueryForObject<object>("SelectSuppliesWeightByPlanId",plan_id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }
        
        public IList<PM_Water_Guage_Info> ExecuteDB_QueryWaterGuageInfoByContractNo(string contractNo,string shipName)
        {
            IList<PM_Water_Guage_Info> result;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("contractNo", contractNo);
                ht.Add("shipName", shipName);
                result = CommonDao.ExecuteQueryForList<PM_Water_Guage_Info>("SelectWaterGuageInfoByContractNo", ht);
                //result = CommonDao.ExecuteQueryForList<PM_Water_Guage_Info>("SelectWaterGuageInfoByContractNo", ht);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
            }
            return result;
        }

        public object ExecuteDB_QueryMTBeltWeight(string str, string str2)
        {
            object result;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("contractNo", str);
                ht.Add("shipName", str2);
                result = CommonDao.ExecuteQueryForObject<object>("SelectMTBeltWeightByContractNo",ht);
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
