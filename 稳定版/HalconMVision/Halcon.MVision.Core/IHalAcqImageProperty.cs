// Halcon.MVision.IHalAcqImageProperty
using HalconDotNet;

namespace Halcon.MVision
{
   public interface IHalAcqImageProperty
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }
        /// <summary>
        /// 获取或设置图像在起始点X
        /// </summary>
        HTuple OffsetX
        {
            get;
            set;
        }
        /// <summary>
        /// 获取OffsetX最小值
        /// </summary>
        HTuple OffsetX_Min
        {
            get;
        }
        /// <summary>
        /// 获取OffsetX最大值
        /// </summary>
        HTuple OffsetX_Max
        {
            get;
        }

        /// <summary>
        /// 图像起始点Y
        /// </summary>
        HTuple OffsetY
        {
            get;
            set;
        }

        /// <summary>
        /// 获取OffsetY最小值
        /// </summary>
        HTuple OffsetY_Min
        {
            get;
        }
        /// <summary>
        /// 获取OffsetY最大值
        /// </summary>
        HTuple OffsetY_Max
        {
            get;
        }

        /// <summary>
        /// 图像宽度
        /// </summary>
        HTuple Width
        {
            get;
            set;
        }

        /// <summary>
        /// 获取图像宽度的最小值
        /// </summary>
        HTuple Width_Min
        {
            get;
        }

        /// <summary>
        /// 获取图像宽度最大值
        /// </summary>
        HTuple Width_Max
        {
            get;
        }

        /// <summary>
        /// 图像高度
        /// </summary>
        HTuple Height
        {
            get;
            set;
        }
        /// <summary>
        /// 获取图像高度最小值
        /// </summary>
        HTuple Height_Min
        {
            get;
        }

        /// <summary>
        /// 获取图像高度最大值
        /// </summary>
        HTuple Height_Max
        {
            get;
        }

        event HalChangedEventHandler Changed;
    }
}
