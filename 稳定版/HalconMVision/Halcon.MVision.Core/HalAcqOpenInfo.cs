using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Halcon.MVision;
using HalconDotNet;

//**********************************************
//文件名：HalAcqOpenInfo
//命名空间：Halcon.MVision
//CLR版本：4.0.30319.42000
//内容：
//功能：存储打开相机信息
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/1/8 11:16:33
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    [Serializable]
    internal class HalAcqOpenInfo : IHalAcqOpenInfo,ISerializable
    {
        private HTuple name = "GigEVision2";    //相机接口类型名
        private HTuple horizontalResolution=0;    //相机水平分辨率
        private HTuple verticalResolution=0;      //相机垂直方向分辨率
        private HTuple imageHeight=0;
        private HTuple imageWidth=0;
        private HTuple startRow=0;
        private HTuple startColumn=0;
        private HTuple field = "progressive";       //图像场，全图or半图
        private HTuple bitsPerChannel = -1;
        private HTuple colorSpace= "default";
        private HTuple generic= -1;
        private HTuple externalTrigger = "false";
        private HTuple cameraType= "default";
        private HTuple device;
        private HTuple port = 0;
        private HTuple lineIn =-1;
        #region 构造函数

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="deviceName">相机名称</param>
        public HalAcqOpenInfo(HTuple deviceName)
        {
            device = deviceName;

        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="deviceName">相机名称</param>
        /// <param name="colorspace">视频格式/颜色空间</param>
        public HalAcqOpenInfo(HTuple deviceName,HTuple colorspace)
        {
            device = deviceName;
            colorSpace = colorspace;
        }

        public HalAcqOpenInfo(SerializationInfo info, StreamingContext context)
        {
            name= (HTuple)info.GetValue("name",  typeof(HTuple));
            horizontalResolution=(HTuple)info.GetValue("horizontalResolution", typeof(HTuple));
            verticalResolution=(HTuple)info.GetValue("verticalResolution", typeof(HTuple));
            imageHeight=(HTuple)info.GetValue("imageHeight", typeof(HTuple));
            imageWidth=(HTuple)info.GetValue("imageWidth", typeof(HTuple));
            startRow=(HTuple)info.GetValue("startRow", typeof(HTuple));
            startColumn=(HTuple)info.GetValue("startColumn", typeof(HTuple));
            field=(HTuple)info.GetValue("field", typeof(HTuple));
            bitsPerChannel=(HTuple)info.GetValue("bitsPerChannel", typeof(HTuple));
            colorSpace=(HTuple)info.GetValue("colorSpace", typeof(HTuple));
            generic=(HTuple)info.GetValue("generic", typeof(HTuple));
            externalTrigger=(HTuple)info.GetValue("externalTrigger", typeof(HTuple));
            cameraType=(HTuple)info.GetValue("cameraType", typeof(HTuple));
            device=(HTuple)info.GetValue("device", typeof(HTuple));
            port=(HTuple)info.GetValue("port", typeof(HTuple));
            lineIn=(HTuple)info.GetValue("lineIn", typeof(HTuple));
        }
        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置Halcon采集图像接口名称
        /// 如："GigEVision"、"1394IIDC"、"pylon"
        /// 、"SaperaLT"、"SiliconSoftware"、"ADLINK"等
        /// </summary>
        HTuple IHalAcqOpenInfo.Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 获取或设置图像水平分辨率，默认值是1
        /// </summary>
        HTuple IHalAcqOpenInfo.HorizontalResolution
        {
            get { return horizontalResolution; }
            set { horizontalResolution = value; }
        }

        /// <summary>
        /// 获取或设置图像垂直分辨率
        /// </summary>
        HTuple IHalAcqOpenInfo.VerticalResolution
        {
            get { return verticalResolution; }
            set { verticalResolution = value; }
        }

        /// <summary>
        /// 获取或设置图像高度
        /// </summary>
        HTuple IHalAcqOpenInfo.ImageHeight
        {
            get { return imageHeight; }
            set { imageHeight = value; }
        }

        /// <summary>
        /// 获取或设置图像宽度
        /// </summary>
        HTuple IHalAcqOpenInfo.ImageWitdth
        {
            get { return imageWidth; }
            set { imageWidth = value; }
        }

        /// <summary>
        /// 获取或设置图像左上角起始行
        /// </summary>
        HTuple IHalAcqOpenInfo.StartRow
        {
            get { return startRow; }
            set { startRow = value; }
        }
        /// <summary>
        /// 获取或设置图像左上角起始列
        /// </summary>
        HTuple IHalAcqOpenInfo.StartColumn
        {
            get { return startColumn; }
            set { startColumn = value; }
        }

        /// <summary>
        /// 获取或设置图像场，全图or半图
        /// </summary>
        HTuple IHalAcqOpenInfo.Field
        {
            get { return field; }
            set { field = value; }
        }

        /// <summary>
        /// 获取或设置位深度，默认值为-1表示设备默认值
        /// </summary>
        HTuple IHalAcqOpenInfo.BitsPerChannel
        {
            get { return bitsPerChannel; }
            set { bitsPerChannel = value; }
        }
        /// <summary>
        /// 获取或设置图像颜色空间或视频格式
        /// </summary>
        HTuple IHalAcqOpenInfo.ColorSpace
        {
            get { return colorSpace; }
            set { colorSpace = value; }
        }

        /// <summary>
        /// 获取或设置具有设备特定含义的通用参数
        /// </summary>
        HTuple IHalAcqOpenInfo.Generic
        {
            get { return generic; }
            set { generic = value; }
        }

        /// <summary>
        /// 获取或设置外触发模式
        /// </summary>
        HTuple IHalAcqOpenInfo.ExternalTrigger
        {
            get { return externalTrigger; }
            set { externalTrigger = value; }
        }

        /// <summary>
        /// 获取或设置使用相机类型
        /// </summary>
        HTuple IHalAcqOpenInfo.CameraType
        {
            get { return cameraType; }
            set { cameraType = value; }
        }

        /// <summary>
        /// 获取或设置采集图像设备名称
        /// </summary>
        HTuple IHalAcqOpenInfo.Device
        {
            get { return device; }
            set { device = value; }
        }

        /// <summary>
        /// 获取或设置采集图像设备的连接端口
        /// </summary>
        HTuple IHalAcqOpenInfo.Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// 获取或设置多路复用器的摄像输入线（-1:设备的特有默认值）
        /// </summary>
        HTuple IHalAcqOpenInfo.LineIn
        {
            get { return    lineIn; }
            set { lineIn = value; }
        }

         void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info,context);
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name",name,typeof(HTuple));
            info.AddValue("horizontalResolution", horizontalResolution, typeof(HTuple));
            info.AddValue("verticalResolution", verticalResolution, typeof(HTuple));
            info.AddValue("imageHeight", imageHeight, typeof(HTuple));
            info.AddValue("imageWidth", imageWidth, typeof(HTuple));
            info.AddValue("startRow", startRow, typeof(HTuple));
            info.AddValue("startColumn", startColumn, typeof(HTuple));
            info.AddValue("field", field, typeof(HTuple));
            info.AddValue("bitsPerChannel", bitsPerChannel, typeof(HTuple));
            info.AddValue("colorSpace", colorSpace, typeof(HTuple));
            info.AddValue("generic", generic, typeof(HTuple));
            info.AddValue("externalTrigger", externalTrigger, typeof(HTuple));
            info.AddValue("cameraType", cameraType, typeof(HTuple));
            info.AddValue("device", device, typeof(HTuple));
            info.AddValue("port", port, typeof(HTuple));
            info.AddValue("lineIn", lineIn, typeof(HTuple));
        }
        #endregion

        #region 公共方法



        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
