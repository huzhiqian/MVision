//Halcon.MVision.IHalAcqContrast
using HalconDotNet;

namespace Halcon.MVision
{
   public interface IHalAcqContrast
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }
        /// <summary>
        /// 获取或设置相机对比度
        /// </summary>
        HTuple Contrast
        {
            get;
            set;
        }
        /// <summary>
        /// 获取对比对最小值
        /// </summary>
        HTuple ContrastMin
        {
            get;
        }
        /// <summary>
        /// 获取对比度最大值
        /// </summary>
        HTuple ContrastMax
        {
            get;
        }
        /// <summary>
        /// 获取该内参是否存在
        /// </summary>
        bool IsExist
        {
            get;
        }

        event HalChangedEventHandler Changed;
    }
}
