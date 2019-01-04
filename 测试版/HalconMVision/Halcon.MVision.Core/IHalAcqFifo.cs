 //Halcon.MVision.IHalAcqFifo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halcon.MVision
{
    /// <summary>
    /// 相机接口，对相机硬件所有的操作都通过该接口
    /// </summary>
    public interface IHalAcqFifo:IHalChangedEvent
    {
        #region 属性

        /// <summary>
        /// 获取相机亮度参数
        /// </summary>
        IHalAcqBrightness OwnedBrightnessParams
        {
            get;
        }
        /// <summary>
        /// 获取相机对比度参数
        /// </summary>
        IHalAcqContrast OwnedContrastParams
        {
            get;
        }
        /// <summary>
        /// 获取相机曝光参数
        /// </summary>
        IHalAcqExposure OwendExposureParams
        {
            get;
        }

        /// <summary>
        /// 获取图像格式参数
        /// </summary>
        IHalAcqImageProperty OwendImageFormatParams
        {
            get;
        }

        /// <summary>
        /// 获取相机触发参数
        /// </summary>
        IHalAcqTrigger OwendTriggerParams
        {
            get;
        }

        /// <summary>
        /// 获取GigE参数
        /// </summary>
        IHalGigEAccess OwendGigEAccessPara
        {
            get;
        }

        #endregion

        #region 方法



        #endregion

        #region 事件



        #endregion

    }
}
