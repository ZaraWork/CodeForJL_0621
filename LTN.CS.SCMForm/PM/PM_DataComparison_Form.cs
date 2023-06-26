using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LTN.CS.SCMService.PM.Interface;
using LTN.CS.SCMEntities.PM;
using DevExpress.XtraPrinting;
using System.Globalization;

namespace LTN.CS.SCMForm.PM
{
    public partial class PM_DataComparison_Form : Form
    {
        private IPM_DataComparisonService MainService { get; set; }
        public PM_DataComparison_Form()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 对四组数据进行查询并处理封装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gToolStripButton1_Click(object sender, EventArgs e)
        {
            //如果什么条件都不输入，则不进行查询，提示用户输入信息

            if (string.IsNullOrEmpty(txt_shipName.Text))
            {
                MessageBox.Show("船名不能为空");
                return;
            }
            //封装查询数据
            Hashtable ht = new Hashtable();
            string contractNo = string.IsNullOrEmpty(txt_contractNo.Text) ? "" : txt_contractNo.Text.Trim();
            string materialName = string.IsNullOrEmpty(txt_materialName.Text) ? "" : txt_materialName.Text.Trim();
            string shipName = txt_shipName.Text.Trim();            
            string voyageNo = string.IsNullOrEmpty(txt_voyageNo.Text) ? "" : txt_voyageNo.Text.Trim();
            string arriveDate = string.Empty;
            if(!string.IsNullOrEmpty(ArriveDate.Text))
            {
                DateTime time = ArriveDate.DateTime;
                arriveDate = time.ToString("yyyyMMddHHmmss");
            }
            ht.Add("materialName", materialName);
            ht.Add("shipName", shipName);
            ht.Add("contractNo", contractNo);
            ht.Add("voyageNo", voyageNo);
            ht.Add("arriveDate", arriveDate);
            
            /*
            List<PM_DataComparisonForBeltAndSupplies> resultList = new List<PM_DataComparisonForBeltAndSupplies>();
            PM_DataComparisonForBeltAndSupplies data = new PM_DataComparisonForBeltAndSupplies();
            data.shipName = "永晟319";
            data.contractNo = "450006247300010";
            data.materialName = "主焦煤|3级|进口|蒙古";
            data.voyageNo = "Z200930001";
            data.shipArriveTime = DateTime.ParseExact("20221015024052", "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString();
            data.waterGuage_weight = 9050;
            data.suppliesWeight = (decimal)8802.48;
            data.wharf_beltWeight = 8866;
            data.beltWeight = 8908;

            if (data.waterGuage_weight > 0 && data.wharf_beltWeight > 0)
            {
                decimal num = (decimal)((data.waterGuage_weight - data.wharf_beltWeight) / data.waterGuage_weight);
                data.mw = num.ToString("0.0%");
            }
            if (data.waterGuage_weight > 0 && data.suppliesWeight > 0)
            {
                decimal num = (decimal)((data.waterGuage_weight - data.suppliesWeight) / data.waterGuage_weight);
                data.sw = num.ToString("0.0%");
            }


            resultList.Add(data);
            gridControl1.DataSource = resultList;
            gridView1.BestFitColumns();
            */
            
            
       //结果集
       List<PM_DataComparisonForBeltAndSupplies> resultList = new List<PM_DataComparisonForBeltAndSupplies>();
       //根据船名(+品名)  查有多少个采购订单

       IList<string> contractNoList = MainService.ExecuteDB_QueryContractNos(ht);
       if(contractNoList != null && contractNoList.Count > 0)
       {
           foreach(string contract in contractNoList)
           {
               PM_DataComparisonForBeltAndSupplies data = new PM_DataComparisonForBeltAndSupplies();
               data.contractNo = contract;
               data.shipName = shipName;
               //查码头皮带秤净重总和
               var wharfBeltWeight = MainService.ExecuteDB_QueryMTBeltWeight(contract,shipName);
               if(wharfBeltWeight != null)
               {
                   Decimal mtBeltWeight = Convert.ToDecimal(wharfBeltWeight);
                   data.wharf_beltWeight = mtBeltWeight;
               }

               //查内转皮带秤净重总和
               Dictionary<string,object> dic = MainService.ExecuteDB_QueryBeltData(contract);
               if(dic != null)
               {
                   data.beltWeight = Convert.ToDecimal(dic["sum"]);

                   //data.materialName = dic["materialName"] == null ?string.Empty:dic["materialName"].ToString();

                   if(dic["planId"] != null && dic["planId"].ToString() != "")
                   {
                       string plan_id = dic["planId"].ToString();
                       data.plan_id = plan_id;
                       //通过planId查轨道衡磅单
                       Decimal suppliseWeight = Convert.ToDecimal(MainService.ExecuteDB_QuerySuppliesWeight(plan_id));
                       data.suppliesWeight = suppliseWeight;
                   }                        
               }
               //通过采购订单号查询对应的水尺数据
               IList<PM_Water_Guage_Info> waterGuageInfoList = MainService.ExecuteDB_QueryWaterGuageInfoByContractNo(contract,shipName);
               if(waterGuageInfoList != null && waterGuageInfoList.Count > 0)
               {
                        PM_Water_Guage_Info waterGuageInfo = new PM_Water_Guage_Info();
                        Decimal waterSum = 0;
                        //相同的合同订单号、船名的水尺数据算到一起去
                        foreach(PM_Water_Guage_Info info in waterGuageInfoList)
                        {
                            waterSum += info.C_NET_WEIGHT;
                        }
                        waterGuageInfo.C_NET_WEIGHT = waterSum;


                        data.waterGuage_weight = Convert.ToDecimal(waterGuageInfo.C_NET_WEIGHT);
                        if (data.waterGuage_weight > 0)
                        {
                            data.waterGuage_weight = data.waterGuage_weight / 1000;
                        }
                        data.voyageNo = waterGuageInfo.C_HANGCI_NO;
                        data.materialName = waterGuageInfo.C_GOODS_NAME;
                        data.shipArriveTime = waterGuageInfo.C_BERTH_DT;
                        if (data.shipArriveTime != null)
                        {
                            //data.shipArriveTime = Convert.ToDateTime(data.shipArriveTime).ToString("yyyyMMddHHmmss");
                            data.shipArriveTime = DateTime.ParseExact(data.shipArriveTime, "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString();
                        }
                        if (data.waterGuage_weight > 0 && data.wharf_beltWeight > 0)
                        {
                            decimal num = (decimal)((data.waterGuage_weight - data.wharf_beltWeight) / data.waterGuage_weight);
                            data.mw = num.ToString("0.0%");
                        }
                        if (data.waterGuage_weight > 0 && data.suppliesWeight > 0)
                        {
                            decimal num = (decimal)((data.waterGuage_weight - data.suppliesWeight) / data.waterGuage_weight);
                            data.sw = num.ToString("0.0%");
                        }

                    }
               

               resultList.Add(data);
           }

           gridControl1.DataSource = resultList;
           gridView1.BestFitColumns();
       }
       else
       {
           MessageBox.Show("未查到该船数据");
           gridControl1.DataSource = null;
           return;
       }
      
       
        }

        private void gToolStripButton2_Click(object sender, EventArgs e)
        {
            if (gridControl1.DataSource == null)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Text;

            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions();
                options.SheetName = fileDialog.FileName;
                options.TextExportMode = TextExportMode.Text;
                gridView1.ExportToXls(fileDialog.FileName, options);
            }
        }
    }
}
