using LTN.CS.Base.Common;
using LTN.CS.SCMEntities.SM;
using System;
using System.Linq;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_RawData_MoveTrain_New
    {
        public int IntId { get; set; }// 主键
        public SM_PoundSite_Info SiteNo { get; set; }//磅点
        public string OrderNo { get; set; }// 车序
        public string CarNo { get; set; }// 车号
        public string FormationTag { get; set; }// 车组
        public Decimal WeightData { get; set; }// 重量
        public Decimal Speed { get; set; }// 车速
        public string WeightTime { get; set; }// 过磅时间
        public WeightTypeObj WeightFlag { get; set; }// 重量类型
        public RawDataStatusObj DataFlag { get; set; }// 数据状态
        public int IsUse { get; set; }
        public string CreateUser { get; set; }// 新增人员
        public string CreateTime { get; set; }// 新增时间
        public string UpdateUser { get; set; }// 修改人员
        public string UpdateTime { get; set; }// 修改时间

        //新增字段--潘鹏
        
        public string Reserve1 { get; set; }
        public string Reserve2 { get; set; }
        public Decimal PZ { get; set; }
        //新增字段--潘鹏
        public string Reserve3 { get; set; }
        public string Reserve4 { get; set; }
        public Decimal PZ2 { get; set; }

        public string CarType { get; set; }//车型
        public string TareWeight { get; set; }//皮重
        public string NetWgt { get; set; }//净重

        public string StandardWeight { get; set; }//标重
        public string StandardTareWeight { get; set; }//标皮
        public string CZ { get; set; }//超载
    }
}
