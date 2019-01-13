//Halcon.MVision.Implementation.Internal.HalAcqBrightness
using HalconDotNet;
using System;
using System.Runtime.Serialization;

//**********************************************
//文件名：HalAcqBrightness
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：相机亮度值控制类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/14 22:05:56
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    [Serializable]
    public class HalAcqBrightness : CAcqOperatorBase, IHalAcqBrightness, IHalChangedEvent, ISerializable, ICloneable
    {
        [NonSerialized]
        private HTuple __acqhandle;

        private HTuple brightness;
        private HTuple brightnessMin;
        private HTuple brightnessMax;

        #region StateFlags
        [NonSerialized]
        public const long SfBrightness = 1;
        [NonSerialized]
        public const long SfBrightnessMin = 2;
        [NonSerialized]
        public const long SfBrightnessMax = 4;
        #endregion

        [NonSerialized]
        private bool isExist = false;
        [NonSerialized]
        private static StateFlagsCollection _stateFlags = null;
        #region 构造函数

        private HalAcqBrightness(HalAcqBrightness other)
        {
            //设置相机句柄
            __acqhandle = other.__acqhandle;
            Changed = null;
            GetStateFlages();

            brightness = other.brightness;
            brightnessMin = other.brightnessMin;
            brightnessMax = other.brightnessMax;
            GetParamIsExist();
        }

        public HalAcqBrightness(ref HTuple hAcq)
        {
            __acqhandle = hAcq;
            if (__acqhandle.TupleNotEqual(null))
            {
                GetStateFlages();
                //获取相机中的参数
                InitializeParam();
                GetParamIsExist();
            }
        }
        /// <summary>
        /// 反序列化构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private HalAcqBrightness(SerializationInfo info, StreamingContext context)
        {
           
            GetStateFlages();
            //反序列化相机参数
           brightness= (HTuple)info.GetValue("brightness", typeof(HTuple));
           brightnessMin= (HTuple)info.GetValue("brightnessMin", typeof(HTuple));
           brightnessMax= (HTuple)info.GetValue("brightnessMax", typeof(HTuple));
           
        }

        #endregion


        #region 属性
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple IHalAcqBrightness.AcqHandle
        {
            set
            {
                if (value.TupleNotEqual(__acqhandle) && value.TupleNotEqual(null))
                {
                    __acqhandle = value;
                    //设置相机参数
                    ResetCamhandleTosetparam();
                    GetParamIsExist();
                }
            }
        }
        /// <summary>
        /// 获取或设置相机对比度
        /// </summary>
        HTuple IHalAcqBrightness.Brightness
        {
            get { return brightness; }
            set
            {
                if (__acqhandle.TupleNotEqual(value) && value.TupleNotEqual(null))
                {
                    if (value != brightness)
                        if (SetBrightness(value))
                        {
                            brightness = value;
                            if (Changed != null)
                                Changed(this,new HalChangedEventArgs(0));
                        }         
                }
            }
        }
        /// <summary>
        /// 获取该相机内参是否存在
        /// </summary>
        bool IHalAcqBrightness.IsExist
        {
            get { return isExist; }
        }

        /// <summary>
        /// 获取亮度值最小值
        /// </summary>
        HTuple IHalAcqBrightness.BrightnessMin
        {
            get { return brightnessMin; }
        }

        /// <summary>
        /// 获取相机亮度值的最大值
        /// </summary>
        HTuple IHalAcqBrightness.BrightnessMax
        {
            get { return brightnessMax; }
        }

        int IHalChangedEvent.ChangedEventSuspended
        {
            get { return 0; }
        }

        StateFlagsCollection Get_StateFlags()
        {
            return HalAcqBrightness._stateFlags;
        }
        StateFlagsCollection IHalChangedEvent.StateFlags
        {
            get { return Get_StateFlags(); }
        }
        #endregion

        #region 公共方法



        #endregion

        #region 私有方法

        /// <summary>
        /// 获取状态位数据集
        /// </summary>
        /// <returns></returns>
        private static StateFlagsCollection GetStateFlages()
        {
            if (_stateFlags == null)
            {
                HalAcqBrightness._stateFlags = new StateFlagsCollection(typeof(HalAcqImageProperty));
            }
            return HalAcqBrightness._stateFlags;
        }
        /// <summary>
        /// 重置相机句柄重置相机参数
        /// </summary>
        private void ResetCamhandleTosetparam()
        {
            SetBrightness(brightness);
        }

        /// <summary>
        /// 通过相机句柄获取相机参数
        /// </summary>
        private void InitializeParam()
        {
            GetBrightnessValue();
            GetBrightnessMax();
            GetBrightnessMin();
        }
        /// <summary>
        /// 获取相机亮度值
        /// </summary>
        private void GetBrightnessValue()
        {
            brightness = GetParam(__acqhandle, new HTuple("Brightness"));

        }

        private void GetBrightnessMin()
        {
            brightnessMin = GetParamRangeMin(__acqhandle, new HTuple("Brightness"));
        }

        private void GetBrightnessMax()
        {
            brightnessMax = GetParamRangeMax(__acqhandle, new HTuple("Brightness"));
        }

        /// <summary>
        /// 设置相机亮度值
        /// </summary>
        /// <param name="value"></param>
        private bool SetBrightness(HTuple value)
        {
            if (!isExist) return false;
            bool result = false;
            result = SetParam(__acqhandle, new HTuple("Brightness"), value);
            GetBrightnessMax();
            GetBrightnessMin();

            return result;
        }

        void IHalChangedEvent.SuspendChangedEvent()
        {
            throw new NotImplementedException();
        }

        void IHalChangedEvent.ResumeAndRaiseChangedEvent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);//序列化数据
        }
        /// <summary>
        /// 执行具体的序列化，可被重写
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("brightness", brightness, typeof(HTuple));
            info.AddValue("brightnessMin", brightnessMin, typeof(HTuple));
            info.AddValue("brightnessMax", brightnessMax, typeof(HTuple));
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        protected virtual object Clone()
        {
            return new HalAcqBrightness(this)
;
        }


        /// <summary>
        /// 判断参数是否存在
        /// </summary>
        private void GetParamIsExist()
        {
            isExist = JudgeParamExist(__acqhandle, new HTuple("Brightness"));
        }
        #endregion

        #region 委托



        #endregion

        #region 事件

        public event HalChangedEventHandler Changed;//对象参数改变事件

        #endregion
    }
}
