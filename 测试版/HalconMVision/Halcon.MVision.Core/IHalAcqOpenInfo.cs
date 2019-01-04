// Halcon.MVision.IHalAcqOpenInfo
using HalconDotNet;

namespace Halcon.MVision
{
    /// <summary>
    /// 包含初始化相机的信息和相机采集图像的句柄
    /// 相机初始化事件参数类
    /// </summary>
    public interface IHalAcqOpenInfo
    {

        /// <summary>
        ///  获取或设置Halcon采集图像接口名称
        ///  如："GigEVision"、"1394IIDC"、"pylon"
        ///  、"SaperaLT"、"SiliconSoftware"、"ADLINK"等
        /// </summary>
        HTuple Name
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置图像水平分辨率，默认值是1
        /// </summary>
        HTuple HorizontalResolution
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置图像垂直分辨率
        /// </summary>
        HTuple VerticalResolution
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置图像高度
        /// </summary>
        HTuple ImageHeight
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置图像宽度
        /// </summary>
        HTuple ImageWitdth
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置图像左上角起始行
        /// </summary>
        HTuple StartRow
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置图像左上角起始列
        /// </summary>
        HTuple StartColumn
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置图像场，全图or半图
        /// </summary>
        HTuple Field
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置位深度，默认值为-1表示设备默认值
        /// </summary>
        HTuple BitsPerChannel
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置图像颜色空间或视频格式
        /// </summary>
        HTuple ColorSpace
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置具有设备特定含义的通用参数
        /// </summary>
        HTuple Generic
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置外触发模式
        /// </summary>
        HTuple ExternalTrigger
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置使用相机类型
        /// </summary>
        HTuple CameraType
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置采集图像设备名称
        /// </summary>
        HTuple Device
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置采集图像设备的连接端口
        /// </summary>
        HTuple Port
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置多路复用器的摄像输入线（-1:设备的特有默认值）
        /// </summary>
        HTuple LineIn
        {
            get;
            set;
        }


    }
}
