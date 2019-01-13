//Halcon.MVision.IHalAcqTrigger

using HalconDotNet;
using System.Collections.Generic;

namespace Halcon.MVision
{
   public interface IHalAcqTrigger
    {
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple AcqHandle
        {
            set;
        }
        /// <summary>
        /// 获取或设置相机触发使能
        /// </summary>
        bool TriggeModel
        {
            get;
            set;
        }
        
        /// <summary>
        /// 获取或设置相机当前触发源
        /// </summary>
        HTuple CurrentTriggerSource
        {
            get;
            set;
        }

        /// <summary>
        /// 获取相机所有触发源
        /// </summary>
       HTuple TriggerSource
        {
            get;
        }

        event HalChangedEventHandler Changed;
    }
}
