using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Globalization;
using System.Windows.Forms;

using pSpaceCTLNET;
using LTN.CS.SCMService.PT.Interface;
using LTN.CS.SCMService.SM.Interface;
using LTN.CS.SCMEntities.PT;
using System.Threading;
using LTN.CS.SCMEntities.SM;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_BeltHandlerServiceImpl : IPM_BeltHandlerService
    {
        public ICommonDao CommonDao { get; set; }
        public IPM_Bill_BeltScaleService beltService { get; set; }
        public IPT_BeltScalePlanService PT_BeltScalePlanService { get; set; }
        public ISM_BeltNumberService beltNumberService { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        private DbConnector dbconnector;

        public string numStr = "0";       

        public void Login()
        {
            try
            {
                //string _serverName = "172.16.130.40";
                //string _serverName = "10.110.132.30";
                //string _serverName = "10.211.48.155";
                string _serverName = "10.200.112.155";

                string _userName = "admin";
                string _pwd = "admin888";
                pSpaceCTLNET.Common.StartAPI();
                dbconnector = new DbConnector();
                dbconnector.ServerName = _serverName;
                dbconnector.UserName = _userName;
                dbconnector.Password = _pwd;
                //DbError dr = dbconnector.Connect();
                if (!dbconnector.IsConnected())
                {
                    DbError err = dbconnector.Connect();
                    if (err.HasErrors)
                    {
                        MessageBox.Show("连接仪表失败---" + err.ErrorMessage);
                        Dispose();
                    }
                }
                //if (dbconnector)
                //{
                //    InserLog("连接仪表失败---" + dr.ErrorMessage);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库异常" + ex.Message);
                Dispose();
            }
        }

        public void Dispose()
        {
            if (dbconnector != null && dbconnector.IsConnected())
            {
                dbconnector.Disconnect();
                pSpaceCTLNET.Common.StopAPI();
                //InserLog("关闭仪表数据库连接");
            }
        }

        public List<PM_BeltTimeCount> getBeltRunTime(Hashtable ht)
        {
            List<PM_BeltTimeCount> list = new List<PM_BeltTimeCount>();
            #region                  
            /*
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("A202", "MT101VI01P");
            dic.Add("DK502", "SJ105VI01P");
            dic.Add("K105", "LT111VI01P");
            dic.Add("RJ1", "SJ107VI01P");
            dic.Add("GM302", "SJ109VI01P");
            dic.Add("GM501", "SJ110VI01P");
            dic.Add("A102", "MT102VI01P");
            dic.Add("GM202", "SJ108VI01P");
            dic.Add("JF7", "SJ117VI01P");
            dic.Add("A302", "MT103VI01P");
            dic.Add("Y101", "SJ116VI01P");
            dic.Add("Y201", "SJ114VI01P");
            dic.Add("LS101", "LT109VI01P");
            dic.Add("LS102", "LT108VI01P");
            dic.Add("BM104", "JH106VI01P");
            dic.Add("LJ101", "LT116VI01P");
            dic.Add("A402", "MT104VI01P");
            dic.Add("LJ103", "LT117VI01P");
            dic.Add("B502", "ZL108VI01P");
            dic.Add("B505", "ZL112VI01P");
            dic.Add("B506", "ZL113VI01P");
            dic.Add("J101", "LT112VI01P");
            dic.Add("J201", "LT113VI01P");
            dic.Add("KK5", "SJ106VI01P");
            dic.Add("GM401", "SJ111VI01P");
            dic.Add("成202", "SJ104VI01P");
            dic.Add("F101", "LT113VI01P");
            dic.Add("F201", "LT114VI01P");
            dic.Add("SJ102", "LT115VI01P");
            dic.Add("球团成一", "SJ203VI01P");
            dic.Add("成102", "SJ115VI01P");
            */
            #endregion
            Dictionary<string, string> dic = getBeltTagInfoDictionary("VI");
            string startTime = ht["startTime"].ToString();
            string endTime = ht["endTime"].ToString();
            string beltNo = ht["beltNo"].ToString();//后续用于判断
            //int interval = Convert.ToInt32(ht["interval"].ToString());
            if (!string.IsNullOrEmpty(beltNo))
            {
                if (dic.ContainsKey(beltNo))
                {
                    PM_BeltTimeCount beltCount = new PM_BeltTimeCount();
                    beltCount.c_beltname = beltNo;
                    beltCount.c_beltno = beltNo;
                    string tagName = dic[beltNo].ToString();
                    beltCount.c_beltInfo = tagName;
                    int count = 0;
                    DateTime start = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    DateTime end = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    List<HisDataSet> hisDataList = getHisData(start, end, tagName);
                    if (hisDataList.Count > 0)
                    {
                        List<DateTime> timeList = new List<DateTime>();
                        //List<TimeSpan> timeSpanList = new List<TimeSpan>();
                        bool flag = true;
                        DateTime timeStamp1 = new DateTime();
                        DateTime timeStamp2 = new DateTime();

                        for (int i = hisDataList.Count - 1; i >= 0; i--)
                        {
                            HisDataSet hds = hisDataList[i];
                            if (hds.Count > 0)
                            {
                                for (int j = hds[0].Data.Count - 1; j >= 0; j--)
                                {
                                    try
                                    {
                                        if (hds[0].Data[j].Value != null && hds[0].Data[j].TimeStamp != null)
                                        {
                                            Double _value = Convert.ToDouble(hds[0].Data[j].Value.ToString());
                                            if (_value > 0.01 && flag == true)
                                            {
                                                timeStamp1 = hds[0].Data[j].TimeStamp;
                                                timeList.Add(timeStamp1);
                                                flag = false;
                                            }
                                            else if (_value <= 0.01 && flag == false)
                                            {
                                                timeStamp2 = hds[0].Data[j].TimeStamp;
                                                flag = true;
                                                timeList.Add(timeStamp2);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //continue;
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                        if (timeList.Count > 0)
                        {
                            if (timeList.Count % 2 == 1)
                            {
                                DateTime time = hisDataList[0][0].Data[0].TimeStamp;

                                timeList.Add(time);
                            }
                        }
                        //根据timeList计算出皮带秤时长
                        for (int i = 0; i < timeList.Count - 1; i += 2)
                        {
                            DateTime time1 = timeList[i];
                            DateTime time2 = timeList[i + 1];
                            TimeSpan span = time1 - time2;
                            count += Convert.ToInt32(span.TotalSeconds);
                        }
                    }
                    beltCount.c_beltTimeTotalCount = count.ToString();
                    list.Add(beltCount);

                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (string key in dic.Keys)
                {
                    PM_BeltTimeCount beltCount = new PM_BeltTimeCount();
                    beltCount.c_beltname = key;
                    beltCount.c_beltno = key;
                    string tagName = dic[key].ToString();
                    beltCount.c_beltInfo = tagName;
                    int count = 0;
                    DateTime start = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    DateTime end = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    List<HisDataSet> hisDataList = getHisData(start, end, tagName);

                    if (hisDataList.Count > 0)
                    {
                        List<DateTime> timeList = new List<DateTime>();
                        //List<TimeSpan> timeSpanList = new List<TimeSpan>();
                        bool flag = true;
                        DateTime timeStamp1 = new DateTime();
                        DateTime timeStamp2 = new DateTime();

                        for (int i = hisDataList.Count - 1; i >= 0; i--)
                        {
                            HisDataSet hds = hisDataList[i];
                            if (hds.Count > 0)
                            {
                                for (int j = hds[0].Data.Count - 1; j >= 0; j--)
                                {
                                    try
                                    {
                                        if (hds[0].Data[j].Value != null && hds[0].Data[j].TimeStamp != null)
                                        {
                                            Double _value = Convert.ToDouble(hds[0].Data[j].Value.ToString());
                                            if (_value > 0.01 && flag == true)
                                            {
                                                timeStamp1 = hds[0].Data[j].TimeStamp;
                                                timeList.Add(timeStamp1);
                                                flag = false;
                                            }
                                            else if (_value <= 0.01 && flag == false)
                                            {
                                                timeStamp2 = hds[0].Data[j].TimeStamp;
                                                flag = true;
                                                timeList.Add(timeStamp2);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //continue;
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                        if (timeList.Count > 0)
                        {
                            if (timeList.Count % 2 == 1)
                            {
                                DateTime time = hisDataList[0][0].Data[0].TimeStamp;

                                timeList.Add(time);
                            }
                        }
                        //根据timeList计算出皮带秤时长
                        for (int i = 0; i < timeList.Count - 1; i += 2)
                        {
                            DateTime time1 = timeList[i];
                            DateTime time2 = timeList[i + 1];
                            TimeSpan span = time1 - time2;
                            count += Convert.ToInt32(span.TotalSeconds);
                        }
                    }
                    beltCount.c_beltTimeTotalCount = count.ToString();
                    list.Add(beltCount);
                }
            }
            return list;
        }

        public List<HisDataSet> getHisData(DateTime startTime, DateTime endTime, string tagName)
        {             
            #region
            /*
            tagDic.Add("A202", "MT101FQ01P");
            tagDic.Add("K105", "LT111FQ01P");
            tagDic.Add("RJ1", "SJ107FQ01P");
            tagDic.Add("GM302", "SJ109FQ01P");
            tagDic.Add("GM501", "SJ110FQ01P");
            tagDic.Add("A102", "MT102FQ01P");
            tagDic.Add("GM202", "SJ108FQ01P");
            tagDic.Add("JF7", "SJ117FQ01P");
            tagDic.Add("A302", "MT103FQ01P");
            tagDic.Add("Y101", "SJ116FQ01P");
            tagDic.Add("Y201", "SJ114FQ01P");
            tagDic.Add("LS101", "LT109FQ01P");
            tagDic.Add("LS102", "LT108FQ01P");
            tagDic.Add("BM104", "JH106FQ01P");
            tagDic.Add("LJ101", "LT116FQ01P");
            tagDic.Add("A402", "MT104FQ01P");
            tagDic.Add("LJ103", "LT117FQ01P");
            tagDic.Add("B502", "ZL108FQ01P");
            tagDic.Add("B505", "ZL112FQ01P");
            tagDic.Add("B506", "ZL113FQ01P");
            tagDic.Add("J101", "LT112FQ01P");
            tagDic.Add("J201", "LT113FQ01P");
            tagDic.Add("KK5", "SJ106FQ01P");
            tagDic.Add("GM401", "SJ111FQ01P");
            tagDic.Add("DK302", "SJ122FQ01P");
            tagDic.Add("DK402", "SJ123FQ01P");
            tagDic.Add("DK502", "SJ124FQ01P");
            tagDic.Add("DK602", "SJ125FQ01P");
            tagDic.Add("ZC101", "SJ126FQ01P");
            tagDic.Add("ZCP1", "SJ127FQ01P");            
            */
            #endregion

            //Dictionary<string, string> tagDic = getBeltTagInfoDictionary("FQ");            
            //string tagName = tagDic[beltNo];
            Login();

            List<HisDataSet> hisdatalist = new List<HisDataSet>();

            if (dbconnector.IsConnected())
            {

                //HisDataSet hisdataset = null;

                TagTree tagTree = TagTree.CreateInstance(dbconnector);
                TagNode tagNode = new TagNode();
                tagNode = tagTree.GetTreeRoot();

                TagVector tag = new TagVector();
                tag = tagNode.SelectNodes("[Name=" + tagName + "]@His_isSave");

                if (endTime > System.DateTime.Now)
                {
                    //查询时间不能超过当前时间，否则为空而出错
                    endTime = System.DateTime.Now;
                }

                while (startTime < endTime)
                {
                    //获取历史时间
                    HisDataSet hisdataset = new HisDataSet();
                    //TimeSpan ts = new TimeSpan(0, 0, 1);

                    if (startTime.AddHours(1) > endTime)
                    {
                        //查询方法一
                        BatchResults rslt = DataIO.ReadRaw(dbconnector, tag, startTime, endTime, hisdataset, 10000, true);

                        //查询方法二
                        //BatchResults rslt = DataIO.ReadProcessed(dbConnector, tag, startTime, endTime, ts, AggregateEnum.INTERPOLATIVE, hisdataset);
                        hisdatalist.Add(hisdataset);

                        startTime = endTime;
                    }
                    else
                    {
                        try
                        {
                            BatchResults rslt = DataIO.ReadRaw(dbconnector, tag, startTime, startTime.AddHours(1), hisdataset, 10000, true);

                            //BatchResults rslt = DataIO.ReadProcessed(dbConnector, tag, startTime, endTime, ts, AggregateEnum.INTERPOLATIVE, hisdataset);
                            hisdatalist.Add(hisdataset);

                            //将开始时间改为上次的结束时间
                            //startTime = hisdataset[0].Data[hisdataset[0].Data.Count - 1].TimeStamp.AddSeconds(1);
                            startTime = startTime.AddHours(1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            Dispose();
            return hisdatalist;

        }
        /// <summary>
        /// 获取时间点的数据
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public RealHisData getHisData(DateTime Time, string tagName)
        {
            Login();
            RealHisData result = null;
            //string sqlStr = "select c_beltno,c_bitno,c_beltFiNo,c_beltViNo from  SM_BeltBitNo a order by a.I_IntId desc";            
            try
            {
                #region
                /*
                Dictionary<string, string> tagDic = new Dictionary<string, string>();
                tagDic.Add("A202", "MT101FQ01P");
                tagDic.Add("K105", "LT111FQ01P");
                tagDic.Add("RJ1", "SJ107FQ01P");
                tagDic.Add("GM302", "SJ109FQ01P");
                tagDic.Add("GM501", "SJ110FQ01P");
                tagDic.Add("A102", "MT102FQ01P");
                tagDic.Add("GM202", "SJ108FQ01P");
                tagDic.Add("JF7", "SJ117FQ01P");
                tagDic.Add("A302", "MT103FQ01P");
                tagDic.Add("Y101", "SJ116FQ01P");
                tagDic.Add("Y201", "SJ114FQ01P");
                tagDic.Add("LS101", "LT109FQ01P");
                tagDic.Add("LS102", "LT108FQ01P");
                tagDic.Add("BM104", "JH106FQ01P");
                tagDic.Add("LJ101", "LT116FQ01P");
                tagDic.Add("A402", "MT104FQ01P");
                tagDic.Add("LJ103", "LT117FQ01P");
                tagDic.Add("B502", "ZL108FQ01P");
                tagDic.Add("B505", "ZL112FQ01P");
                tagDic.Add("B506", "ZL113FQ01P");
                tagDic.Add("J101", "LT112FQ01P");
                tagDic.Add("J201", "LT113FQ01P");
                tagDic.Add("KK5", "SJ106FQ01P");
                tagDic.Add("GM401", "SJ111FQ01P");
                tagDic.Add("DK302", "SJ122FQ01P");
                tagDic.Add("DK402", "SJ123FQ01P");
                tagDic.Add("DK502", "SJ124FQ01P");
                tagDic.Add("DK602", "SJ125FQ01P");
                tagDic.Add("ZC101", "SJ126FQ01P");
                tagDic.Add("ZCP1", "SJ127FQ01P");                
                string tagName = tagDic[beltNo];
                */
                #endregion
                /*
                IList<SM_BeltNumber> array = CommonDao.ExecuteQueryForList<SM_BeltNumber>("selectSM_BeltNumberAll_New", null);
                Dictionary<string, string> tagDic = getBeltTagInfoDictionary("FQ");
                
                string tagName = tagDic[beltNo];
                */
                DateTime EndTime = Time;
                DateTime StartTime = EndTime.AddMinutes(-30);
                List<HisDataSet> hisdatalist = new List<HisDataSet>();
                if (dbconnector.IsConnected())
                {
                    TagTree tagTree = TagTree.CreateInstance(dbconnector);
                    TagNode tagNode = new TagNode();
                    tagNode = tagTree.GetTreeRoot();

                    TagVector tag = new TagVector();
                    tag = tagNode.SelectNodes("[Name=" + tagName + "]@His_isSave");

                    HisDataSet hisdataset = new HisDataSet();
                    //读取仪表数据  左闭右开区间
                    BatchResults rslt = DataIO.ReadRaw(dbconnector, tag, StartTime, EndTime, hisdataset, 10000, true);
                    hisdatalist.Add(hisdataset);
                }
                else
                {                    
                    Login();
                }
                HisDataSet s = hisdatalist.FirstOrDefault();
                if (s != null && s.Count > 0)
                {
                    TagHisValues t = s[0] as TagHisValues;
                    if (t != null && t.Data.Count > 1)
                    {
                        result = t.Data[t.Data.Count - 2] as RealHisData;
                        if (Convert.ToInt32(result.Value) < 0)
                        {
                            result.Value = 0;
                        }
                        
                    }
                    else if (t != null && t.Data.Count == 1)
                    {
                        result = t.Data[t.Data.Count - 1] as RealHisData;
                        if (Convert.ToInt32(result.Value) < 0)
                        {
                            result.Value = 0;
                        }
                    }
                    else
                    {
                        result = new RealHisData();
                        result.Value = 0;
                        result.TimeStamp = StartTime;                       
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result = null;
                Dispose();
            }
            Dispose();
            return result;
        }
        /// <summary>
        /// 2022.7.5 新增 处理新材料溶剂皮带秤皮带号、启停时间更新的委托业务
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public Dictionary<string,Decimal> getBeltCount(Hashtable ht)
        {
            Dictionary<string, Decimal> dic = new Dictionary<string, Decimal>();
            string beltno = ht["beltno"].ToString();
            string planno = ht["planno"].ToString();
            DateTime startTime = Str14ToTime(ht["startTime"].ToString());
            DateTime stopTime = Str14ToTime(ht["stopTime"].ToString());

            Dictionary<string, string> tagDic = getBeltTagInfoDictionary("FQ");            
            string tagName = tagDic[beltno];

            //RealHisData HisStartData = getHisData(startTime, beltno);
            //RealHisData HisStopData = getHisData(stopTime, beltno);
            RealHisData HisStartData = getHisData(startTime, tagName);
            RealHisData HisStopData = getHisData(stopTime, tagName);
            if (HisStartData == null || HisStopData == null)
            {
                return null;
            }
            decimal startWgt = Convert.ToDecimal(HisStartData.Value);
            decimal stopWgt =  Convert.ToDecimal(HisStopData.Value);
            dic.Add("startWeight", startWgt);
            dic.Add("stopWeight", stopWgt);
            //对相应的磅单进行处理、得到总量数据


            IList<PM_Bill_Belt> list = beltService.ExecuteDB_QueryBeltHourlyPondByPlan(planno);
            List<string> s = new List<string>();
            foreach(PM_Bill_Belt bill in list)
            {
                s.Add(bill.C_Wgtlistno);                
            }            
            
            //重新生成新的小时量
            List<PM_Bill_Belt> belts = ExecuteDB_CreateBeltBillForRJ(planno, startTime, stopTime);
            if (belts.Count == 0)
            {
                MessageBox.Show("重新生成小时量异常");
                return null;
            }
            
            //将小时量的净重和相加得到总量
            //IList<PM_Bill_Belt> belts = beltService.ExecuteDB_QueryBeltHourlyPondByPlan(planno);
            decimal totalNum = 0;
            if (belts != null && belts.Count > 0)
            {
                foreach (PM_Bill_Belt billBelt in belts)
                {
                    totalNum += Convert.ToDecimal(billBelt.N_Netwgt);
                    //将小时量插入数据库
                    beltService.ExecuteDB_InsertPM_Bill_Belt_ForRJ(billBelt);
                }
            }            
            dic.Add("netWgt", totalNum);

            var markResult = beltService.ExecuteDB_UpdatePM_Bill_Belt_Mark(s);//将之前的小时量磅单标记掉
            numStr = "0";
            return dic;
        }
        /// <summary>
        /// 将字符串转化为时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime Str14ToTime(string str)
        {
            try
            {
                DateTime dt;
                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                dt = DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                return dt;
            }
            catch
            {
                return new DateTime();
            }
        }
        /// <summary>
        /// 获取小时
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime Str14ToHourTime(string str)
        {
            try
            {
                DateTime dt = Str14ToTime(str);
                int m = dt.Minute * (-1);    //获取当前时间的分钟部分
                int s = dt.Second * (-1);    //获取当前时间的秒部分
                dt = dt.AddMinutes(m).AddSeconds(s);
                return dt;
            }
            catch
            {
                return DateTime.Parse("21000000000000");
            }


        }
        /// <summary>
        /// 插入小时量     
        /// </summary>
        /// <returns></returns>
        public List<PM_Bill_Belt> ExecuteDB_CreateBeltBillForRJ(string planno, DateTime startTime, DateTime endTime)
        {
            List<PM_Bill_Belt> billsToInsert = new List<PM_Bill_Belt>();                        
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("PlanNo", planno);
                IList<PT_BeltScalePlan> BeltPlans = PT_BeltScalePlanService.ExecuteDB_QueryBeltScalePlanByHashTable(ht);
                if(BeltPlans != null && BeltPlans.Count > 0)
                {
                    PT_BeltScalePlan BeltPlan = BeltPlans.FirstOrDefault();                    
                    string beltno = BeltPlan.C_Beltno;
                    string starttime = startTime.ToString("yyyyMMddHHmmss");
                    string endtime = endTime.ToString("yyyyMMddHHmmss");
                    if (endTime > DateTime.Now)
                    {
                        return null;
                    }
                    Dictionary<string, string> tagDic = getBeltTagInfoDictionary("FQ");
                    string tagName = tagDic[beltno];

                    //判断开始时间与结束时间是否在同一个小时时间段内  如果在，直接判断净重并生成磅单
                    if (Str14ToHourTime(starttime) == Str14ToHourTime(endtime))
                    {
                        RealHisData HisStartData = getHisData(startTime, tagName);
                        RealHisData HisStopData = getHisData(endTime, tagName);
                        if (HisStartData == null || HisStopData == null)
                        {
                            return null;
                        }
                        else
                        {
                            PM_Bill_Belt bill = InsertBeltBillAndBeltWgtDataForRJ(BeltPlan, HisStartData, HisStopData, starttime, endtime);
                            if (bill != null)
                            {
                                billsToInsert.Add(bill);
                            }                            
                        }
                    }
                    else
                    {
                        //如果不在，就逐步判断净重并生成小时量磅单
                        DateTime tempTime = Str14ToHourTime(starttime).AddHours(1);
                        while (tempTime <= endTime)
                        {
                            string timeStr = tempTime.ToString("yyyyMMddHHmmss");
                            RealHisData HisStartData1 = getHisData(Str14ToTime(starttime), tagName);
                            RealHisData HisStopData1 = getHisData(Str14ToTime(timeStr), tagName);
                            if (HisStartData1 == null || HisStopData1 == null)
                            {
                                return null;
                            }
                            else 
                            {
                                PM_Bill_Belt bill = InsertBeltBillAndBeltWgtDataForRJ(BeltPlan, HisStartData1, HisStopData1, starttime, timeStr);
                                if (bill != null)
                                {
                                    billsToInsert.Add(bill);
                                }
                                    
                            }
                            starttime = timeStr;
                            tempTime = Str14ToTime(timeStr).AddHours(1);
                        }
                        //插入最后一节磅单
                        RealHisData HisStartData2 = getHisData(Str14ToTime(starttime), tagName);
                        RealHisData HisStopData2 = getHisData(Str14ToTime(endtime), tagName);
                        if (HisStartData2 == null || HisStopData2 == null)
                        {
                            return null;
                        }
                        else
                        {
                            PM_Bill_Belt bill = InsertBeltBillAndBeltWgtDataForRJ(BeltPlan, HisStartData2, HisStopData2, starttime, endtime);
                            if (bill != null)
                            {
                                billsToInsert.Add(bill);
                            }                            
                        }                       
                    }
                }                                                              
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);                                            
            }
            return billsToInsert;
        }
        /// <summary>
        /// 插入溶剂皮带秤小时量磅单
        /// </summary>
        /// <param name="BeltPlan"></param>
        /// <param name="HisStartData"></param>
        /// <param name="HisStopData"></param>
        /// <param name="MeasureStartTime"></param>
        /// <param name="MeasureStopTime"></param>
        /// <param name="isFullPond"></param>
        /// <param name="totalNum"></param>
        private PM_Bill_Belt InsertBeltBillAndBeltWgtDataForRJ(PT_BeltScalePlan BeltPlan, RealHisData HisStartData, RealHisData HisStopData, string MeasureStartTime, string MeasureStopTime)
        {
            PM_Bill_Belt BeltBill = new PM_Bill_Belt();
            try
            {
                /*
                string value = BeltPlan.C_Beltno + DateTime.Now.ToString("yyyyMMdd") + "%";
                // string WgtNo = CommonDao.ExecuteQueryForObject<string>("CreateWgtNo", value);
                
                 string WgtNo = beltService.ExecuteDB_QueryWgtlistno(value);                                
                 if (!string.IsNullOrEmpty(WgtNo))
                 {
                     WgtNo = WgtNo.Substring(WgtNo.Length - 18, 18);
                     WgtNo = (Int64.Parse(WgtNo) + 1).ToString();
                     WgtNo = WgtNo.Substring(WgtNo.Length - 4, 4);
                     Thread.Sleep(500);
                     WgtNo = BeltPlan.C_Beltno + DateTime.Now.ToString("yyyyMMddHHmmss") + WgtNo;
                 }
                 else
                 {
                     WgtNo = BeltPlan.C_Beltno + DateTime.Now.ToString("yyyyMMddHHmmss") + "0001";
                 }
                 */

                /*
                int num = Int32.Parse(numStr) + 1;
                string WgtNo = BeltPlan.C_Beltno + DateTime.Now.ToString("yyyyMMddHHmmss") + (num < 10 ? ("000" + num.ToString()) : ("00" + num.ToString()));
                numStr = num.ToString();

                */

                string str = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                System.Random r = new System.Random();
                string result = string.Empty;


                //生成一个5位长的随机字符，具体长度可以自己更改
                for (int i = 0; i < 4; i++)
                {
                    int m = r.Next(0, 62);//这里下界是0，随机数可以取到，上界应该是62，因为随机数取不到上界，也就是最大61
                    string s = str.Substring(m, 1);
                    result += s;
                }
                string WgtNo = BeltPlan.C_Beltno + DateTime.Now.ToString("yyyyMMddHHmmss") + result;

                //绑定计划信息到实体
                BeltBill.C_Planno = BeltPlan.C_Planno;
                //修改  新材料溶剂皮带秤的委托单独处理   后续处理，现在暂时没有使用这些字段
                /*
                if (BeltPlan.C_Planno.Substring(0, 2) == "A0" || BeltPlan.C_Planno.Substring(0, 2) == "A6")
                {
                    BeltBill.C_RESERVE4 = BeltPlan.C_RESERVE4;
                    BeltBill.C_RESERVE5 = BeltPlan.C_RESERVE5;
                    BeltBill.C_RESERVE6 = BeltPlan.C_RESERVE6;
                    BeltBill.C_RESERVE7 = BeltPlan.C_RESERVE7;
                    BeltBill.C_RESERVE8 = BeltPlan.C_RESERVE8;
                }
                else
                {
                    BeltBill.C_RESERVE4 = null;
                    BeltBill.C_RESERVE5 = null;
                    BeltBill.C_RESERVE6 = null;
                    BeltBill.C_RESERVE7 = null;
                    BeltBill.C_RESERVE8 = null;
                }
                */
                //对于溶剂皮带秤磅单不需要再做区分了
                BeltBill.C_RESERVE4 = BeltPlan.C_RESERVE4;
                BeltBill.C_RESERVE5 = BeltPlan.C_RESERVE5;
                BeltBill.C_RESERVE6 = BeltPlan.C_RESERVE6;
                BeltBill.C_RESERVE7 = BeltPlan.C_RESERVE7;
                BeltBill.C_RESERVE8 = BeltPlan.C_RESERVE8;

                BeltBill.C_Materialno = BeltPlan.C_Materialno;
                BeltBill.C_Materialname = BeltPlan.C_Materialname;
                BeltBill.C_Fromdeptno = BeltPlan.C_Fromdeptno;
                BeltBill.C_Fromdeptname = BeltPlan.C_Fromdeptname;
                BeltBill.C_Fromstoreno = BeltPlan.C_Fromstoreno;
                BeltBill.C_Fromstorename = BeltPlan.C_Fromstorename;
                BeltBill.C_Todeptno = BeltPlan.C_Todeptno;
                BeltBill.C_Todeptname = BeltPlan.C_Todeptname;
                BeltBill.C_Tostoreno = BeltPlan.C_Tostoreno;
                BeltBill.C_Tostorename = BeltPlan.C_Tostorename;
                BeltBill.C_Beltno = BeltPlan.C_Beltno;
                BeltBill.C_Beltname = BeltPlan.C_Beltname;
                BeltBill.C_Shipno = BeltPlan.C_Shipno;
                BeltBill.C_Contractno = BeltPlan.C_Contractno;
                BeltBill.C_Voyageno = BeltPlan.C_Voyageno;
                BeltBill.C_Starttime = BeltPlan.C_Starttime;
                BeltBill.C_Endtime = BeltPlan.C_Stoptime;
                BeltBill.C_Createtime = BeltPlan.C_Createtime;
                BeltBill.C_Createname = BeltPlan.C_Createname;
                BeltBill.C_Remark = BeltPlan.C_Remark;
                BeltBill.C_Reserve1 = BeltPlan.C_Reserve1;
                BeltBill.C_Reserve2 = BeltPlan.C_Reserve2;
                BeltBill.C_Reserve3 = BeltPlan.C_Reserve3;
                BeltBill.I_Reserve1 = BeltPlan.I_Reserve1;
                BeltBill.I_Reserve2 = BeltPlan.I_Reserve2;
                BeltBill.I_Reserve3 = BeltPlan.I_Reserve3;

               
                //绑定重量信息
                BeltBill.C_Wgtlistno = WgtNo;
                BeltBill.N_Startwgt = Convert.ToDecimal(HisStartData.Value);
                BeltBill.N_Endwgt = Convert.ToDecimal(HisStopData.Value);

                BeltBill.I_Reserve1 = 0;
                BeltBill.C_Uploadstatus = "Y";

                if ((BeltBill.N_Endwgt - BeltBill.N_Startwgt) < -500 && (Str14ToTime(MeasureStopTime) > Str14ToTime(MeasureStartTime)))
                {
                    //计算正确的磅单实绩         
                    Dictionary<string,Decimal> dic = getActureDataByTime(MeasureStartTime, MeasureStopTime, BeltBill.C_Beltno, BeltBill.N_Startwgt, BeltBill.N_Endwgt);
                    if(dic["flag"] == 0)
                    {
                        BeltBill.N_Netwgt = dic["value"];
                    }
                    else
                    {
                        MessageBox.Show("获取最大值异常");
                        return null;
                    }
                    
                }
                else
                {
                    BeltBill.N_Netwgt = BeltBill.N_Endwgt - BeltBill.N_Startwgt;
                }

                BeltBill.C_Measurestarttime = MeasureStartTime;
                BeltBill.C_Measureendtime = MeasureStopTime;
                BeltBill.C_Billcreatetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                BeltBill.C_Measureman = "自动";
                BeltBill.C_Billcreateusername = "自动";
                //beltService.ExecuteDB_InsertPM_Bill_Belt_ForRJ(BeltBill);
                /*
                //插入重量信息
                BeltWeightData StartWeight = new BeltWeightData();
                StartWeight.BELTNO = BeltPlan.C_Beltno;
                StartWeight.BELTNAME = BeltPlan.C_Beltname;
                StartWeight.COLLTIME = Str14ToTime(MeasureStartTime);
                StartWeight.ACCUWEIGHT = Convert.ToDecimal(HisStartData.Value);
                StartWeight.METERTIME = HisStartData.TimeStamp;
                BeltWeightData StopWeight = new BeltWeightData();
                StopWeight.BELTNO = BeltPlan.C_Beltno;
                StopWeight.BELTNAME = BeltPlan.C_Beltname;
                StopWeight.COLLTIME = Str14ToTime(MeasureStopTime);
                StopWeight.ACCUWEIGHT = Convert.ToDecimal(HisStopData.Value);
                StopWeight.METERTIME = HisStopData.TimeStamp;
                CommonDao.ExecuteInsertForInt("InsertBeltWeightData", StartWeight);
                CommonDao.ExecuteInsertForInt("InsertBeltWeightData", StopWeight);
                */

            }
            catch (Exception ex)
            {
                BeltBill = null;
            }
            return BeltBill;
        }
        /// <summary>
        /// 计算正确重量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        private Dictionary<string, Decimal> getActureDataByTime(String startTime, String endTime, string beltNo,decimal startValue,decimal endValue)
        {

            //该时段内最大值 - 初始值  + 结束值  = 净重                                   
            Decimal maxValue = 0;
            Dictionary<string, Decimal> dic = new Dictionary<string, Decimal>();
            decimal flag = 0;
            Dictionary<string, string> tagDic = getBeltTagInfoDictionary("FQ");
            string tagName = tagDic[beltNo];
            List<HisDataSet> hisDataList = getHisData(Str14ToTime(startTime), Str14ToTime(endTime), tagName);
            if (hisDataList.Count > 0)
            {
                if (hisDataList[0].Count > 0)
                {
                    try
                    {
                        //1.正常返回的list里面只会有一个HisDataSet 
                        List<RealHisData> testData = hisDataList[0][0].Data.ToList();                        
                        double lastNum = hisDataList[0][0].Data[testData.Count - 1].Value == null ? 0 : Convert.ToDouble(hisDataList[0][0].Data[testData.Count - 1].Value);
                        List<Decimal> list = new List<Decimal>();
                        foreach (RealHisData data in testData)
                        {
                            if (data.Value == null) continue;
                            
                            Decimal _value = Convert.ToDecimal(data.Value);                            
                            list.Add(_value);
                        }                        
                        if (list.Count > 0)
                        {
                            list.Sort();
                            maxValue = list.Last();                           
                        }                       
                    }
                    catch (Exception ex)
                    {
                        flag = 1;
                    }
                }
            }            
            decimal value = maxValue - startValue + endValue;
            dic.Add("value", value);
            dic.Add("flag", flag);
            return dic;
        }

        public Dictionary<string,string> getBeltTagInfoDictionary(string type)
        {
            //IList<SM_BeltNumber> array = CommonDao.ExecuteQueryForList<SM_BeltNumber>("selectSM_BeltNumberAll_New", null);
            IList<SM_BeltNumber> array = beltNumberService.ExecuteDB_QueryAll();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (array != null && array.Count > 0)
            {
                foreach (SM_BeltNumber belt in array)
                {
                    switch (type)
                    {
                        case "FQ":
                            dic.Add(belt.BeltId.C_Beltno, belt.BITNO);
                            break;
                        case "FI":
                            dic.Add(belt.BeltId.C_Beltno, belt.C_BeltFINo);
                            break;
                        case "VI":
                            dic.Add(belt.BeltId.C_Beltno, belt.C_BeltVINo);
                            break;
                    }                    
                }
            }
            return dic;
        }
    }
}
