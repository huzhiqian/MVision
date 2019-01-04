//Halcon.MVision.IHalAcqState
using HalconDotNet;


namespace Halcon.MVision
{
   public interface IHalAcqState
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }

        /// <summary>
        /// 获取相机连接状态
        /// </summary>
        bool IsCameraLinked
        {
            get;
        }

        /// <summary>
        /// 获取相机状态
        /// </summary>
        string CameraStatus
        {
            get;
        }
    }
}
