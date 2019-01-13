// Halcon.MVision.IHalAcqOperator
using System;
using Halcon.MVision;
using HalconDotNet;


namespace Halcon.MVision
{
    /// <summary>
    /// 相机内参操作接口
    /// </summary>
    public interface IHalAcqOperator
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple CameraHandle
        {
            set;
        }
        //HTuple CameraHandle
        //{
        //    set;
        //}

        /// <summary>
        /// 相机曝光
        /// </summary>
        IHalAcqExposure OwnedExposureParam
        {
            get;
        }
        
        /// <summary>
        /// 相机对比度
        /// </summary>
        IHalAcqContrast OwnedContrastParam
        {
            get;
        }

        /// <summary>
        /// 相机亮度
        /// </summary>
        IHalAcqBrightness OwnedBrightnessParam
        {
            get;
        }

        /// <summary>
        /// 相机触发参数
        /// </summary>
        IHalAcqTrigger OwnedTriggerParam
        {
            get;
        }

        /// <summary>
        /// 图像属性
        /// </summary>
        IHalAcqImageProperty OwnedImagePropertyParam
        {
            get;
        }


    }
}
