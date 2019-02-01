//Halcon.MVision.Implementation.Internal.CHalGigEAccess
using HalconDotNet;
using System;

//**********************************************
//文件名：CHalGigEAccess
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：获取相机硬件信息类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/9 10:20:51
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    public class CHalGigEAccess:IHalGigEAccess
    {
        private HTuple __acqHandle;
        private ulong timeStampFrequency;
        private ulong timeStampCounter;
        private string macAddress;
        private string hostSubnetMask;//主机子网掩码
        private string presistentSubnetMask;//相机固定子网掩码
        private string presistentIPAddress;//相机固定的IP地址
        private string currentSubnetMask;//与相机通信的当前子网掩码
        private string hostIPAddress;   //主机IP地址
        private string currentIPAddress;//相机当前IP地址
        private string cameraSerialNumber;//相机序列号
        private string uniqueName;//设备唯一标识符
        private string deviceName;//设备名称
        private string status;
        private string gatewayAddress;//网关
        private string version;//版本号

        private string deviceModelName;//相机模型名称
        private string deviceFirmwareVersion;//相机固件版本
        #region 构造函数

        public CHalGigEAccess(ref HTuple hAcq )
        {
            if (hAcq.TupleNotEqual(null))
            {
                __acqHandle = hAcq;
                ParsedString();//解析 
            }
        }

        #endregion


        #region 属性
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple IHalGigEAccess.AcqHandle
        {
            set
            {
                if (value != __acqHandle && value.TupleNotEqual(null))
                {
                    __acqHandle = value;
                    ParsedString();
                }
            }
        }
        /// <summary>
        /// 获取相机时间戳计数器频率
        /// </summary>
        ulong IHalGigEAccess.TimeStampFrequency
        {
            get { return timeStampFrequency; }
        }

        /// <summary>
        /// 获取相机时间戳计数器的当前值
        /// </summary>
        ulong IHalGigEAccess.TimeStampCounter
        {
            get { return timeStampCounter; }
        }
        /// <summary>
        /// 获取相机的MAC地址（相机物理地址）
        /// </summary>
        string IHalGigEAccess.MacAddress
        {
            get { return macAddress; }
        }
        /// <summary>
        /// 获取相机的GigE适配器的子网掩码（上位机子网掩码）
        /// </summary>
        string IHalGigEAccess.HostSubnetMask
        {
            get { return hostSubnetMask; }
        }
        /// <summary>
        /// 获取相机固定子网掩码
        /// </summary>
        string IHalGigEAccess.PersistentSubnetMask
        {
            get { return presistentSubnetMask; }
        }       
        /// <summary>
        /// 获取相机固定的IP地址
        /// </summary>
        string IHalGigEAccess.PersistentIPAddress
        {
            get { return presistentIPAddress; }
        }
        /// <summary>
        /// 获取用于与相机通信的当前子网掩码
        /// </summary>
        string IHalGigEAccess.CurrentSubnetMask
        {
            get { return currentSubnetMask; }
        }
        /// <summary>
        /// 获取相机连接的主机的IP地址
        /// </summary>
        string IHalGigEAccess.HostIPAddress
        {
            get { return hostIPAddress; }
        }
        /// <summary>
        /// 获取与相机通信的IP地址
        /// </summary>
        string IHalGigEAccess.CurrentIPAddress
        {
            get { return currentIPAddress; }
        }
        /// <summary>
        /// 获取相机序列号
        /// </summary>
        string IHalGigEAccess.CameraSerialNumber
        {
            get { return cameraSerialNumber; }
        }

        /// <summary>
        /// 获取相机设备唯一标识符
        /// </summary>
        string IHalGigEAccess.UniqueName
        {
            get {return uniqueName; }
        }
        /// <summary>
        /// 获取相机设备名称
        /// </summary>
        string IHalGigEAccess.DeviceName
        {
            get { return deviceName; }
        }
        /// <summary>
        /// 获取相机状态
        /// </summary>
        string IHalGigEAccess.Status
        {
            get { return status; }
        }

        /// <summary>
        /// 获取相机网关
        /// </summary>
        string IHalGigEAccess.GatewayAddress
        {
            get { return gatewayAddress; }
        }
        /// <summary>
        /// 获取版本号
        /// </summary>
        string IHalGigEAccess.Version
        {
            get { return version; }
        }

        /// <summary>
        /// 获取相机型号名称
        /// </summary>
        string IHalGigEAccess.DeviceModelName
        {
            get { return deviceModelName; }
        }

        /// <summary>
        /// 获取相机固件版本号
        /// </summary>
        string IHalGigEAccess.DeviceFirmwareVersion
        {
            get { return deviceFirmwareVersion; }
        }
        #endregion

        #region 公共方法



        #endregion

        #region 私有方法
         ///<summary>
         /// 解析数据
         ///</summary>
        private void ParsedString()
        {
            if (__acqHandle == null)
                throw new NullReferenceException("GigEAccess AcqHandle");

            //获取相机名称
            HTuple hv_deviceName;
             HOperatorSet.GetFramegrabberParam(__acqHandle,"device",out hv_deviceName);
            deviceName = hv_deviceName.S;

            HTuple boardInfo,boardInfoValue;
            HOperatorSet.InfoFramegrabber("GigEVision2",new HTuple("info_boards"),out boardInfo,out boardInfoValue);
            try
            {
                foreach (var item in boardInfoValue.SArr)
                {
                    string[] strItem = new string[] { };
                    //截断字符串
                    strItem = boardInfoValue.S.Split('|');
                    if (GetBoardInfoItem(strItem, "device").Equals(deviceName))
                    {
                        uniqueName = GetBoardInfoItem(strItem, "unique_name");    //获取设备唯一标识符

                        status = GetBoardInfoItem(strItem, "status");
                        currentIPAddress = GetBoardInfoItem(strItem, "device_ip");
                        hostIPAddress = GetBoardInfoItem(strItem, "interface_ip");
                        break;
                    }
                   
                }
                //Console.WriteLine("1");
                HTuple hv_modelName;
                HOperatorSet.GetFramegrabberParam(__acqHandle,new HTuple("DeviceModelName"),out hv_modelName);
                deviceModelName = hv_deviceName.S;

                //Console.WriteLine("2");
                HTuple hv_deviceFirmware;
                HOperatorSet.GetFramegrabberParam(__acqHandle,new HTuple("DeviceFirmwareVersion"),out hv_deviceFirmware);
                deviceFirmwareVersion = hv_deviceFirmware.S;

                //Console.WriteLine("7");
                HTuple DeviceSerialNumber;
                HOperatorSet.GetFramegrabberParam(__acqHandle, "DeviceSerialNumber",out DeviceSerialNumber);
                cameraSerialNumber = DeviceSerialNumber.S;

                //Console.WriteLine("8");
                HTuple DeviceVersion;
                HOperatorSet.GetFramegrabberParam(__acqHandle, "DeviceVersion",out DeviceVersion);
                version = DeviceVersion.S;
            }
            catch (Exception)
            {
                throw new Exception("解析相机硬件信息出错！");
            }
        }

        private string GetBoardInfoItem(string[] items, string targetStr)
        {
            string[] temp;
            foreach (string str in items)
            {
                string tempstr = str.Trim();    //去掉前导空格和后导空格
                temp = tempstr.Split(':');
                if (temp[0] == targetStr)
                {
                    return temp[1];
                }
            }
            return string.Empty;
        }
        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
