//Halcon.MVision.Implementation.Internal.HalAcqExposure
using HalconDotNet;
using System;
using System.Runtime.Serialization;
//**********************************************
//文件名：HalAcqExposure
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：相机曝光控制类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/12 16:20:49
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    [Serializable]
    public class HalAcqExposure : CAcqOperatorBase,IHalAcqExposure,ISerializable,IHalChangedEvent,ICloneable
    {
        [NonSerialized]
        private HTuple __acqHandle;
     
        private HTuple exposureMin = 0.0;
     
        private HTuple exposureMax = 1000000.0;

        private HTuple exposure = 5000.0;

        #region StateFlags

        public const long SfExposure= 1L;

        public const long SfExposureMin = 2L;

        public const long SfExposureMax = 4L;
        #endregion

        private static StateFlagsCollection _stateFlags;

        #region 构造函数

        private HalAcqExposure(HalAcqExposure other)
        {
            //设置相机句柄
            __acqHandle = other.__acqHandle;
            GetStateFlags();
            Changed = null;

            exposure = other.exposure;
            exposureMin = other.exposureMin;
            exposureMax = other.exposureMax;
        }

        public HalAcqExposure(ref HTuple hAcq)
        {
            __acqHandle = hAcq;
            if (__acqHandle.TupleNotEqual(null))
            {
                GetStateFlags();
                InitializeParams();
            }
        }

        /// <summary>
        /// 反序列化构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private HalAcqExposure(SerializationInfo info, StreamingContext context)
        {
          
            GetStateFlags();
            exposure = (HTuple)info.GetValue("exposure",typeof(HTuple));
            exposureMin = (HTuple)info.GetValue("exposureMin",typeof(HTuple));
            exposureMax = (HTuple)info.GetValue("exposureMax",typeof(HTuple));
        }
        #endregion


        #region 属性

        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple IHalAcqExposure.AcqHandle
        {
            set
            {
                if (value.TupleNotEqual(__acqHandle)&& value.TupleNotEqual( null))
                {
                    __acqHandle = value;
                    //设置曝光参数
                    SetCameraExposureTime(exposure);
                }
            }
        }
        /// <summary>
        /// 获取相机曝光最小值
        /// </summary>
        double IHalAcqExposure.MinExposure
        {
            get
            {
                return exposureMin;
            }
        }
        /// <summary>
        /// 获取相机最大值
        /// </summary>
        double IHalAcqExposure.MaxExposure
        {
            get { return exposureMax; }
        }
        /// <summary>
        /// 获取或设置相机曝光时间
        /// </summary>
        double IHalAcqExposure.Exposure
        {
            get { return exposure; }
            set
            {
                if (value != exposure)
                {
                    if (SetCameraExposureTime(value))
                    {
                        exposure = value;
                        if (Changed != null)
                            Changed(this, new HalChangedEventArgs(0));
                    }
                }
            }
        }

        public int ChangedEventSuspended
        {
            get { return 0; }
        }

        public StateFlagsCollection StateFlags
        {
            get { return GetStateFlags(); }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 挂起change事件
        /// </summary>
        public void SuspendChangedEvent()
        {

        }

        /// <summary>
        /// 重新引发change事件
        /// </summary>
        public void ResumeAndRaiseChangedEvent()
        {

        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 获取相机内参中的曝光参数
        /// </summary>
        private void InitializeParams()
        {
            //获取相机曝光最大最小值
            GetExposureTimeMaxAndMin();
            //获取相机曝光时间
            GetCameraExposureTime();
        }

        private static StateFlagsCollection GetStateFlags()
        {
            if (_stateFlags == null)
            {
                HalAcqExposure._stateFlags = new StateFlagsCollection(typeof(HalAcqExposure));
            }
            return HalAcqExposure._stateFlags;
        }

        /// <summary>
        /// 获取相机曝光
        /// </summary>
        private void GetCameraExposureTime()
        {
            exposure = GetParam(__acqHandle,new HTuple("ExposureTime"));
        }


        /// <summary>
        /// 获取相机曝光最大值和最小值
        /// </summary>
        private void GetExposureTimeMaxAndMin()
        {
            exposureMin = GetParamRangeMin(__acqHandle,new HTuple("ExposureTime"));
            exposureMax = GetParamRangeMax(__acqHandle,new HTuple("ExposureTime"));
        }
        /// <summary>
        /// 设置相机曝光
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool SetCameraExposureTime(HTuple value)
        {
           return SetParam(__acqHandle, new HTuple("ExposureTime"),value);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info,context);
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("exposure",exposure,typeof(HTuple));
            info.AddValue("exposureMin",exposureMin,typeof(HTuple));
            info.AddValue("exposureMax",exposureMax,typeof(HTuple));
        }


        object ICloneable.Clone()
        {
            return Clone();
        }

        protected virtual object Clone()
        {
            return new HalAcqExposure(this);
        }

        #endregion

        #region 委托



        #endregion

        #region 事件

        public event HalChangedEventHandler Changed;

        #endregion
    }
}
