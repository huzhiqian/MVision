//Halcon.MVision.Implementation.Internal.IAcqOperatorBase
using System;
using HalconDotNet;

namespace Halcon.MVision.Implementation.Internal
{

    /// <summary>
    /// Acq类操作基础接口
    /// </summary>
   internal interface IAcqOperatorBase
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <param name="param">参数值</param>>
        /// <returns></returns>
        bool SetParam(HTuple deviceHandle,HTuple paramName,HTuple param);

        /// <summary>
        /// 获取设备参数
        /// </summary>
        /// <param name="deviceHanlde">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        HTuple GetParam(HTuple deviceHanlde, HTuple paramName);

        /// <summary>
        /// 获取设备参数列表
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        HTuple GetParamValues(HTuple deviceHandle,HTuple paramName);

        /// <summary>
        /// 获取设备参数范围
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        HTuple GetParamRange(HTuple deviceHandle,HTuple paramName);

        /// <summary>
        /// 获取参数最小值
        /// </summary>
        /// <param name="deviceHandle"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        HTuple GetParamRangeMin(HTuple deviceHandle,HTuple paramName);

        /// <summary>
        /// 获取参数最大值
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        HTuple GetParamRangeMax(HTuple deviceHandle,HTuple paramName);

        /// <summary>
        /// 判断参数是否存在
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名称</param>
        /// <returns></returns>
        bool JudgeParamExist(HTuple deviceHandle, HTuple paramName);
    }
}
