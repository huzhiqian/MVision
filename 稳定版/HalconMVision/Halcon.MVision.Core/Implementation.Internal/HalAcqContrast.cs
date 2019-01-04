//Halcon.MVision.Implementation.Internal.HalAcqContrast
using System;
using HalconDotNet;
using System.Runtime.Serialization;

//**********************************************
//文件名：HalAcqContrast
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：设置相机对比度参数
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/16 15:31:30
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    [Serializable]
    public class HalAcqContrast : CAcqOperatorBase, IHalAcqContrast,IHalChangedEvent,ISerializable,ICloneable
    {
        [NonSerialized]
        private HTuple __acqHandle;

        private HTuple contrast;
        [NonSerialized]
        private bool isExist = false;
        private HTuple contrastMin;
        private HTuple contrastMax;

        #region stateFalgs

        /// <summary>
        /// 当OffsetY发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long Sfcontrast = 1L;

        public const long SfcontrastMin = 2L;

        public const long SfcontrastMax = 4L;
        #endregion

        private static StateFlagsCollection _stateFlags = null;

        #region 构造函数

        private HalAcqContrast(HalAcqContrast other)
        {
            //设置相机句柄
            __acqHandle = other.__acqHandle;
            GetStateFlages();
            Changed = null;

            contrast = other.contrast;
            contrastMin = other.contrast;
            contrastMax = other.contrastMax;
        }

        public HalAcqContrast(HTuple hAcq)
        {
            __acqHandle = hAcq;
            if (__acqHandle.TupleNotEqual(null))
            {
                _stateFlags = GetStateFlages();

            }
        }
        /// <summary>
        /// 序列化构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private HalAcqContrast(SerializationInfo info, StreamingContext context)
        {
           _stateFlags= GetStateFlages();
          contrast=  (HTuple)info.GetValue("contrast", typeof(HTuple));
           contrastMin= (HTuple)info.GetValue("contrastMin", typeof(HTuple));
           contrastMax=  (HTuple)info.GetValue("contrastMax", typeof(HTuple));
        }

        #endregion


        #region 属性
        /// <summary>
        /// 设置相机句柄
        /// </summary>
        HTuple IHalAcqContrast.AcqHandle
        {
            set
            {
                if (value.TupleNotEqual(__acqHandle) && value.TupleNotEqual(null))
                {
                    __acqHandle = value;
                    InitializePram();
                }
            }
        }
        /// <summary>
        /// 设置相机对比度
        /// </summary>
        HTuple IHalAcqContrast.Contrast
        {
            get { return contrast; }
            set
            {
                if (__acqHandle.TupleNotEqual(null))
                {
                    SetContrast(value);
                }
            }
        }

        bool IHalAcqContrast.IsExist
        {
            get { return isExist; }
        }

        /// <summary>
        /// 获取对比度最小值
        /// </summary>
        HTuple IHalAcqContrast.ContrastMin
        {
            get { return contrastMin; }
        }

        /// <summary>
        /// 获取对比度最大值
        /// </summary>
        HTuple IHalAcqContrast.ContrastMax
        {
            get { return contrastMax; }
        }

       public int ChangedEventSuspended
        {
            get { return 0; }
        }

       public StateFlagsCollection StateFlags
        {
            get { return _stateFlags; }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 暂停时中止已更改的事件，可以多次调用。对于每一个SuspendChangedEvent的调用，
        /// 必须对ResumeAndRaiseChangedEvent进行相应的调用
        /// </summary>
        public void SuspendChangedEvent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在调用SuspendChangedEvent重启已更改事件的引发。如果SuspendChangedEvent计数
        /// 减少到零，并且事件被挂起时进行了任何更改，则还会引发改变事件。对于每次SuspendChangedEvent的调用
        /// 必须之后调用改事件一次。
        /// </summary>
        public void ResumeAndRaiseChangedEvent()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 加载相机参数
        /// </summary>
        private void InitializePram()
        {
            GetContrast();
            GetContrastMinAndMax();
        }

        /// <summary>
        /// 获取状态位数据集
        /// </summary>
        /// <returns></returns>
        private static StateFlagsCollection GetStateFlages()
        {
            if (_stateFlags == null)
            {
                HalAcqContrast._stateFlags = new StateFlagsCollection(typeof(HalAcqImageProperty));
            }
            return HalAcqContrast._stateFlags;
        }

        /// <summary>
        /// 获取对比度值
        /// </summary>
        private void GetContrast()
        {
            contrast = GetParam(__acqHandle,new HTuple("Contrast"));
        }
        /// <summary>
        /// 设置对比度
        /// </summary>
        private void SetContrast(HTuple value)
        {
            SetParam(__acqHandle,new HTuple("Contrast"),value);
        }

        private void GetContrastMinAndMax()
        {
            contrastMin = GetParamRangeMin(__acqHandle, "Contrast");
            contrastMax = GetParamRangeMax(__acqHandle, "Contrast");
        }

     
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info,context);
        }

        protected void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("contrast", contrast,typeof(HTuple));
            info.AddValue("contrastMin", contrastMin, typeof(HTuple));
            info.AddValue("contrastMax", contrastMax,typeof(HTuple));
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        protected virtual object Clone()
        {
            return new HalAcqContrast(this);
        }

        #endregion

        #region 委托



        #endregion

        #region 事件

        public event HalChangedEventHandler Changed;

        #endregion
    }
}
