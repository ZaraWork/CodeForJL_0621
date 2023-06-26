using LTN.CS.Base.Helper;
using LTN.CS.Base.MeterOperate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.MeterOperate.Implement
{
    public class QCCodeInfoOperate : IQCCodeInfoOperate
    {             
        private readonly object locker = new object();
        
        public bool OpenPort(out string errMsg, string comPortName, int baudRate = 9600, int dataBits = 8, int stopBits = 1, int parity = 0, bool RtsEnable = false)
        {
            errMsg = string.Empty;
            bool rs = false;
            try
            {
                rs = MySerialPortHelper.SetSerialPortAndOpen(out errMsg, comPortName, baudRate, dataBits, stopBits, parity, RtsEnable);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return rs;
        }

        public void ReadQC(out string errMsg, out string QCCode, string comPortName)
        {
            errMsg = string.Empty;
            QCCode = string.Empty;          
            Boolean ifNoTag = false;
            try
            {
                lock (locker)
                {
                    //byte[] datas = MySerialPortHelper.ReadByteData(out errMsg, comPortName, 50);
                    byte[] datas = MySerialPortHelper.ReadByteData_New(out errMsg, comPortName, 50, out ifNoTag);
                    if (errMsg != string.Empty)
                    {
                       
                    }
                    if (!ifNoTag)
                    {
                        if (datas != null)
                        {
                            byte[] datasTemp = new byte[12];
                            int? startIndex = null;
                            int? endIndex = null;
                            for (int i = datas.Length - 1; i >= 0; i--)
                            {
                                if (datas[i] == 3 && startIndex == null)
                                {
                                    startIndex = i;
                                }
                                if (datas[i] == 2 && endIndex == null && startIndex != null)
                                {
                                    endIndex = i;
                                    break;
                                }
                            }
                            if (startIndex != null && endIndex != null)
                            {
                                int num = 0;
                                if ((startIndex - endIndex) == 11)
                                {
                                    for (int i = endIndex.Value + 2; i <= startIndex.Value - 4; i++)
                                    {
                                        datasTemp[num] = datas[i];
                                        num++;
                                    }
                                }
                                string laststrData = Encoding.ASCII.GetString(datasTemp).Trim();
                                //MeterWeight = int.Parse(laststrData);
                                //MeterStatus = (int)DeviceStatus.Working;                               
                            }
                        }
                        else
                        {
                            Console.WriteLine("data为空");                            
                        }
                    }
                    else
                    {
                        //MeterStatus = (int)DeviceStatus.BreakDown;
                    }

                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;                
                
            }
        }


        public bool CloseQC(out string errMsg, string comPortName)
        {
            bool rs = false;
            errMsg = string.Empty;
            lock (locker)
            {
                byte[] data_Write1 = new byte[1] { 0x5A };
                MySerialPortHelper.WriteByteData(out errMsg, comPortName, data_Write1);
                rs = true;
            }
            return rs;
        }
    }
}
