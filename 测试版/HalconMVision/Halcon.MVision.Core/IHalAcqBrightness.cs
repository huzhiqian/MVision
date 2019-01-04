//Halcon.MVision.IHalAcqBrightness
using HalconDotNet;

namespace Halcon.MVision
{
   public interface IHalAcqBrightness
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }
        /// <summary>
        /// 获取或设置相机亮度值
        /// </summary>
        HTuple Brightness
        {
            get;
            set;
        }

        /// <summary>
        /// 获取亮度值的最小值
        /// </summary>
       HTuple BrightnessMin
        {
            get;
        }

        /// <summary>
        /// 获取亮度值最大值
        /// </summary>
        HTuple BrightnessMax
        {
            get;
        }
        /// <summary>
        /// 获取该内参在相机中是否存在
        /// </summary>
        bool IsExist
        {
            get;
        }
    }
}
