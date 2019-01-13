// Halcon.MVision.IHalAcqExposure
using HalconDotNet;

namespace Halcon.MVision
{
   public interface IHalAcqExposure
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }
        /// <summary>
        /// 获取最小曝光
        /// </summary>
        double MinExposure
        {
            get;
        }

        /// <summary>
        /// 获取最大曝光
        /// </summary>
        double MaxExposure
        {
            get;
        }
        /// <summary>
        /// 获取或设置相机曝光时间
        /// </summary>
        double Exposure
        {
            get;
            set;
        }

        event HalChangedEventHandler Changed;
    }
}
