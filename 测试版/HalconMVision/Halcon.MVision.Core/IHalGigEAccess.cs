// Halcon.MVision.Core.IHalGigEAccess
using HalconDotNet;

namespace Halcon.MVision
{
    /// <summary>
    /// 相机硬件信息接口
    /// </summary>
   public interface IHalGigEAccess
    {

        
        #region 属性
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }
        /// <summary>
        /// 获取相机时间戳计数器的频率
        /// </summary>
        ulong TimeStampFrequency
        {
            get;
        }

        /// <summary>
        /// 或取相机时间戳计数器的当前值
        /// </summary>
        ulong TimeStampCounter
        {
            get;
        }

        /// <summary>
        /// 获取相机的MAC地址（相机物理地址）
        /// </summary>
        string MacAddress
        {
            get;
        }

        /// <summary>
        /// 获取连接相机的GigE适配器的子网掩码（上位机子网掩码）
        /// </summary>
        string HostSubnetMask
        {
            get;
        }

        /// <summary>
        /// 获取相机固定子网掩码
        /// </summary>
        string PersistentSubnetMask
        {
            get;
        }

        /// <summary>
        /// 获取相机固定的IP地址
        /// </summary>
        string PersistentIPAddress
        {
            get;
        }

        /// <summary>
        /// 获取用于与相机通信的当前子网掩码
        /// </summary>
        string CurrentSubnetMask
        {
            get;
        }

        /// <summary>
        /// 获取相机连接的主机的IP地址
        /// </summary>
        string HostIPAddress
        {
            get;
        }
        
        /// <summary>
        /// 获取与相机通信的IP地址
        /// </summary>
        string CurrentIPAddress
        {
            get;
        }

        /// <summary>
        /// 或取相机序列号
        /// </summary>
        string CameraSerialNumber
        {
            get;
        }
        /// <summary>
        /// 获取设备唯一标识符
        /// </summary>
        string UniqueName
        {
            get;
        }
        /// <summary>
        /// 获取设备名称
        /// </summary>
        string DeviceName
        {
            get;
        }

        /// <summary>
        /// 获取相机状态
        /// </summary>
        string Status
        {
            get;
        }

        /// <summary>
        /// 获取网关
        /// </summary>
        string GatewayAddress
        {
            get;
        }
        /// <summary>
        /// 获取版本号
        /// </summary>
        string Version
        {
            get;
        }
        #endregion
    }
}
