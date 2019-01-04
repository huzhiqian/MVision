// Halcon.MVision.Implementation.Internal.HalAcqImageProperty
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using HalconDotNet;


//**********************************************
//文件名：HalAcqImageProperty
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：获取或设置图像属性
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/16 16:43:44
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    [Serializable]
    public class HalAcqImageProperty : CAcqOperatorBase, IHalAcqImageProperty, IHalChangedEvent, ISerializable, ICloneable
    {
        [NonSerialized]
        private HTuple __acqHandle;

        private HTuple offSetX;
        private HTuple offsetX_Min;
        private HTuple offsetX_Max;

        private HTuple offSetY;
        private HTuple offsetY_Min;
        private HTuple offsetY_Max;

        private HTuple width;
        private HTuple width_Min;
        private HTuple width_Max;

        private HTuple height;
        private HTuple height_Min;
        private HTuple height_Max;

        #region Stateflags
        /// <summary>
        /// 当OffsetX发生没变更时,这个位将被设置在changed事件中
        /// </summary>
        public const long SfOffsetX = 1L;
        /// <summary>
        /// 当OffsetX_Min发生没变更时,这个位将被设置在changed事件中
        /// </summary>
        public const long SfOffsetX_Min = 2L;
        /// <summary>
        /// 当OffsetX_Max发生没变更时,这个位将被设置在changed事件中
        /// </summary>
        public const long SfOffsetX_Max = 4L;


        /// <summary>
        /// 当OffsetY发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfOffsetY = 8L;
        /// <summary>
        /// 当OffsetY_Min发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfOffsetY_Min = 16L;
        /// <summary>
        /// 当OffsetY_Max发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfOffsetY_Max = 32L;


        /// <summary>
        /// 当Width发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfWidth = 64L;
        /// <summary>
        /// 当Width_Min发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfWidth_Min = 128L;
        /// <summary>
        /// 当Width_Max发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfWidth_Max = 256L;

        /// <summary>
        /// 当Height发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfHeight = 512L;
        /// <summary>
        /// 当Height_Min发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfHeight_Min = 1024L;
        /// <summary>
        /// 当Height_Max发生变更时，这个位将被设置在changed事件中
        /// </summary>
        public const long SfHeight_max = 2048;
        #endregion

        private static StateFlagsCollection _stateFlags = null;

        private object objectLock = new object();
        /// <summary>
        /// 改变事件
        /// </summary>
        public event HalChangedEventHandler Changed;

        #region 构造函数

        private HalAcqImageProperty(HalAcqImageProperty other)
        {
            //设置相机句柄
            __acqHandle = other.__acqHandle;
            Changed = null;
            GetStateFlages();
            //设置参数
            offSetX = other.offSetX;
            offsetX_Min = other.offsetX_Min;
            offsetX_Max = other.offsetX_Max;

            offSetY = other.offSetY;
            offsetY_Min = other.offsetY_Min;
            offsetX_Max = other.offsetY_Max;

            width = other.width;
            width_Min = other.width_Min;
            width_Max = other.width_Max;

            height = other.height;
            height_Min = other.height_Min;
            height_Max = other.height_Max;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hAcq">相机句柄</param>
        public HalAcqImageProperty(ref HTuple hAcq)
        {
            __acqHandle = hAcq;
            if (__acqHandle.TupleNotEqual(null))
            {
                _stateFlags = GetStateFlages();
                //加载相机参数
                InitializeParam();
            }
        }

        /// <summary>
        /// 反序列化构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private HalAcqImageProperty(SerializationInfo info, StreamingContext context)
        {
            _stateFlags = GetStateFlages();
            //加载参数
            offSetX = (HTuple)info.GetValue("offSetX", typeof(HTuple));
            offsetX_Min = (HTuple)info.GetValue("offsetX_Min", typeof(HTuple));
            offsetX_Max = (HTuple)info.GetValue("offsetX_Max", typeof(HTuple));

            offSetY = (HTuple)info.GetValue("offsetY", typeof(HTuple));
            offsetY_Min = (HTuple)info.GetValue("offsetY_Min", typeof(HTuple));
            offsetY_Max = (HTuple)info.GetValue("offsetY_Max", typeof(HTuple));

            width = (HTuple)info.GetValue("width", typeof(HTuple));
            width_Min = (HTuple)info.GetValue("width_Min", typeof(HTuple));
            width_Max = (HTuple)info.GetValue("width_Max", typeof(HTuple));

            height = (HTuple)info.GetValue("height", typeof(HTuple));
            height_Min = (HTuple)info.GetValue("height_Min", typeof(HTuple));
            height_Max = (HTuple)info.GetValue("height_Max", typeof(HTuple));

        }

        #endregion


        #region 属性

        HTuple IHalAcqImageProperty.AcqHandle
        {
            set
            {
                if (value.TupleNotEqual(__acqHandle) && value.TupleNotEqual(null))
                {
                    __acqHandle = value;
                    //重新设置相机句柄后，重新设置参数
                    ResetCamHandleToSetparam();
                }
            }
        }
        /// <summary>
        /// 获取或设置图像左上角X偏移
        /// </summary>
        HTuple IHalAcqImageProperty.OffsetX
        {
            get { return offSetX; }
            set
            {
                if (value != offSetX)
                {
                    SetOffsetX(value);
                }
            }
        }

        /// <summary>
        /// 获取或设置图像左上角Y偏移
        /// </summary>
        HTuple IHalAcqImageProperty.OffsetY
        {
            get { return offSetY; }
            set
            {
                if (offSetY != value)
                    SetOffsetX(value);
            }
        }

        /// <summary>
        /// 获取或设置图像宽度
        /// </summary>
        HTuple IHalAcqImageProperty.Width
        {
            get { return width; }
            set
            {
                if (width != value)
                    SetWidth(value);
            }
        }

        /// <summary>
        /// 获取或设置图像高度
        /// </summary>
        HTuple IHalAcqImageProperty.Height
        {
            get { return height; }
            set
            {
                if (height != value)
                    SetHeight(value);
            }
        }

        /// <summary>
        /// 获取OffsetX最小值
        /// </summary>
        HTuple IHalAcqImageProperty.OffsetX_Min
        {
            get { return offsetX_Min; }
        }

        /// <summary>
        /// 获取OffsetX最大值
        /// </summary>
        HTuple IHalAcqImageProperty.OffsetX_Max
        {
            get { return offsetX_Max; }
        }

        /// <summary>
        /// 获取OffsetY最小值
        /// </summary>
        HTuple IHalAcqImageProperty.OffsetY_Min
        {
            get { return offsetY_Min; }
        }

        /// <summary>
        /// 获取OFfsetY最大值
        /// </summary>
        HTuple IHalAcqImageProperty.OffsetY_Max
        {
            get { return offsetY_Max; }
        }

        /// <summary>
        /// 获取图像宽度最小值
        /// </summary>
        HTuple IHalAcqImageProperty.Width_Min
        {
            get { return width_Min; }
        }
        /// <summary>
        /// 获取图像宽度最大值
        /// </summary>
        HTuple IHalAcqImageProperty.Width_Max
        {
            get { return width_Max; }
        }
        /// <summary>
        /// 获取图像高度最小值
        /// </summary>
        HTuple IHalAcqImageProperty.Height_Min
        {
            get { return height_Min; }
        }
        /// <summary>
        /// 获取图像高度最大值
        /// </summary>
        HTuple IHalAcqImageProperty.Height_Max
        {
            get { return height_Max; }
        }

        StateFlagsCollection Get_StateFlags()
        {
            return HalAcqImageProperty._stateFlags;
        }

        public StateFlagsCollection StateFlags
        {
            get { return Get_StateFlags(); }
        }

        [Browsable(false)]
        /// <summary>
        /// 获取changed事件是否挂起
        /// </summary>
        public int ChangedEventSuspended
        {
            get { return 0; }
        }


        #endregion

        #region 公共方法

        /// <summary>
        /// 暂停时中止已更改的事件，可以多次调用。对于每一个SuspendChangedEvent的调用，
        /// 必须对ResumeAndRaiseChangedEvent进行相应的调用
        /// </summary>
        public void SuspendChangedEvent()
        {

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
        /// 重置相机句柄候重置相机参数
        /// </summary>
        private void ResetCamHandleToSetparam()
        {
            SetWidth(width);
            SetHeight(height);
            SetOffsetX(offSetX);
            SetOffsetY(offSetY);
        }

        /// <summary>
        /// 通过相机句柄获取相机参数
        /// </summary>
        private void InitializeParam()
        {
            //获取相机参数
            GetOffsetX();
            GetOffsetXMin();
            GetOffsetXMax();

            GetOffsetY();
            GetOffsetYMin();
            GetOffsetYMax();

            GetWidth();
            GetWidthMin();
            GetWidthMax();

            GetHeight();
            GetHeightMin();
            GetHeightMax();
        }

        /// <summary>
        /// 获取状态位数据集
        /// </summary>
        /// <returns></returns>
        private static StateFlagsCollection GetStateFlages()
        {
            if (_stateFlags == null)
            {
                HalAcqImageProperty._stateFlags = new StateFlagsCollection(typeof(HalAcqImageProperty));
            }
            return HalAcqImageProperty._stateFlags;
        }

        /**************************************************************/
        /*                          SetParam                         */
        /************************************************************/
        /// <summary>
        /// 设置图像左上角X偏移
        /// </summary>
        /// <param name="val"></param>
        private bool SetOffsetX(int val)
        {
            if (SetParam(__acqHandle, new HTuple("OffsetX"), new HTuple(val)))
            {
                offSetX = val;
                GetOffsetXMin();
                GetOffsetXMax();
                //引发changed事件
                HalChangedEventHandler changeEvent = Changed;
                if (changeEvent != null)
                    changeEvent(this, new HalChangedEventArgs(SfOffsetX));
                return true;
            }
            return false;

        }

        /// <summary>
        /// 设置图像左上角Y偏移
        /// </summary>
        /// <param name="val"></param>
        private bool SetOffsetY(int val)
        {
            if (SetParam(__acqHandle, new HTuple("OffsetY"), new HTuple(val)))
            {
                offSetY = val;
                GetOffsetYMin();
                GetOffsetYMax();
                HalChangedEventHandler changedEvent = Changed;
                if (changedEvent != null)
                {
                    changedEvent(this, new HalChangedEventArgs(SfOffsetY));
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置图像宽度
        /// </summary>
        /// <param name="val">图像宽度值</param>
        private bool SetWidth(int val)
        {
            if (SetParam(__acqHandle, new HTuple("Width"), new HTuple(val)))
            {
                width = val;
                GetWidthMin();
                GetWidthMax();
                HalChangedEventHandler changedEvent = Changed;
                if (changedEvent != null)
                    changedEvent(this, new HalChangedEventArgs(SfWidth));
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置图像高度
        /// </summary>
        /// <param name="val">图像高度值</param>
        private bool SetHeight(int val)
        {
            if (SetParam(__acqHandle, new HTuple("Height"), new HTuple(val)))
            {
                height = val;
                GetHeightMin();
                GetHeightMax();
                HalChangedEventHandler changedEvent = Changed;
                if (changedEvent != null)
                    changedEvent(this, new HalChangedEventArgs(SfHeight));
                return true;
            }
            return false;
        }

        /***********************************************************/
        /*                       GetParam                         */
        /*********************************************************/
        /// <summary>
        /// 获取图像左上角X偏移
        /// </summary>
        private void GetOffsetX()
        {
            offSetX = GetParam(__acqHandle, new HTuple("OffsetX"));
        }

        /// <summary>
        /// 获取图像左上角Y偏移
        /// </summary>
        private void GetOffsetY()
        {
            offSetY = GetParam(__acqHandle, new HTuple("OffsetY"));
        }

        /// <summary>
        /// 获取图像宽度
        /// </summary>
        private void GetWidth()
        {
            width = GetParam(__acqHandle, new HTuple("Width"));
        }

        /// <summary>
        /// 获取图像高度
        /// </summary>
        private void GetHeight()
        {
            height = GetParam(__acqHandle, new HTuple("Height"));
        }

        /// <summary>
        /// 获取OffsetX最小值
        /// </summary>
        private void GetOffsetXMin()
        {
            offsetX_Min = GetParamRangeMin(__acqHandle, "OffsetX");
        }

        /// <summary>
        /// 获取OffsetY最大值
        /// </summary>
        private void GetOffsetXMax()
        {
            offsetX_Max = GetParamRangeMax(__acqHandle, "OffsetX");
        }

        /// <summary>
        /// 获取OffsetY最小值
        /// </summary>
        private void GetOffsetYMin()
        {
            offsetY_Min = GetParamRangeMin(__acqHandle, "OffsetY");
        }

        /// <summary>
        /// 获取OffsetY最大值
        /// </summary>
        private void GetOffsetYMax()
        {
            offsetY_Max = GetParamRangeMax(__acqHandle, "OffsetY");
        }

        /// <summary>
        /// 获取Width最小值
        /// </summary>
        private void GetWidthMin()
        {
            width_Min = GetParamRangeMin(__acqHandle, "Width");
        }

        /// <summary>
        /// 获取Width最大值
        /// </summary>
        private void GetWidthMax()
        {
            width_Max = GetParamRangeMax(__acqHandle, "Width");
        }

        /// <summary>
        /// 获取Height最小值
        /// </summary>
        private void GetHeightMin()
        {
            height_Min = GetParamRangeMin(__acqHandle, "Height");
        }

        /// <summary>
        /// 获取Height最大值
        /// </summary>
        private void GetHeightMax()
        {
            height_Max = GetParamRangeMax(__acqHandle, "Height");
        }


        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);//序列化数据
        }

        /// <summary>
        /// 序列化数据，虚函数以便后面重写
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("offsetX", offSetX, typeof(HTuple));
            info.AddValue("offsetX_Min", offsetX_Min, typeof(HTuple));
            info.AddValue("OffsetX_Max", offsetX_Max, typeof(HTuple));

            info.AddValue("offsetY", offSetY, typeof(HTuple));
            info.AddValue("offsetY_Min", offsetY_Min, typeof(HTuple));
            info.AddValue("offsetY_Max", offsetY_Max, typeof(HTuple));

            info.AddValue("width", width, typeof(HTuple));
            info.AddValue("width_Min", width_Min, typeof(HTuple));
            info.AddValue("width_Max", width_Max, typeof(HTuple));

            info.AddValue("height", height, typeof(HTuple));
            info.AddValue("height_Min", height_Min, typeof(HTuple));
            info.AddValue("height_Max", height_Max, typeof(HTuple));
        }

        /// <summary>
        /// 克隆该对象
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        protected virtual Object Clone()
        {
            return new HalAcqImageProperty(this);
        }

        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
