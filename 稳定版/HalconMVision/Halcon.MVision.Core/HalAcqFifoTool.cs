//Halcon.MVision.HalAcqFifoTool
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Halcon.MVision;
using HalconDotNet;
using Halcon.MVision.Implementation.Internal;
using System.Windows.Forms;


//**********************************************
//文件名：HalAcqFifoTool
//命名空间：Halcon.MVision.HalAcqFifoTool
//CLR版本：.net Fremework 4.0
//内容：
//功能：相机控制类，负责相机初始化和相机参数控制和图像输出
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019-1-7
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{

    [Serializable]
    public class HalAcqFifoTool : HalToolBase, ISerializable
    {
        [NonSerialized]
        private HTuple __halAcqHandle;  //相机句柄

        private IHalAcqOperator _operator;

        private IHalAcqOpenInfo cameraOpenInfo; //打开相机信息

        [NonSerialized]
        private IHalAcqState acqState;  //相机状态信息

        [NonSerialized]
        private IHalGigEAccess halGigEAccess;

        private bool asyncGrab = false; //开启异步抓帧
        [NonSerialized]
        private bool isRealDisplay = false; //开启实时显示的标志
        private IHalImage m_outputImage;

        #region 构造函数

        /// <summary>
        /// 反序列化构造
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private HalAcqFifoTool(SerializationInfo info, StreamingContext context)
        {
            //反序列化对象
            _operator = (IHalAcqOperator)info.GetValue("operator", typeof(IHalAcqOperator));
            cameraOpenInfo = (IHalAcqOpenInfo)info.GetValue("cameraOpenInfo", typeof(IHalAcqOpenInfo));
            asyncGrab = info.GetBoolean("asyncGrabImage");
            m_outputImage = (IHalImage)info.GetValue("outputImage", typeof(IHalImage));
            acqState = new HalAcqState();
            //判断被序列化的相机是否在相机列表中，如果在尝试打开相机
            if (SystemExistCamera(cameraOpenInfo.Device.S))
            {
                //打开相机
                if (OpenCamera(ref cameraOpenInfo))
                {

                    //对Operator传入新的相机句柄
                    _operator.CameraHandle = __halAcqHandle;
                    halGigEAccess = new CHalGigEAccess(ref __halAcqHandle);
                }

            }

        }

        public HalAcqFifoTool(HTuple deviceName, string colorspace) : base()
        {
            acqState = new HalAcqState();
            cameraOpenInfo = new HalAcqOpenInfo(deviceName, colorspace);
            //打开相机
            if (OpenCamera(ref cameraOpenInfo))
            {
                //初始化Operator
                _operator = new HalAcqOperator(ref __halAcqHandle);
                halGigEAccess = new CHalGigEAccess(ref __halAcqHandle);

            }

        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置相机内参操作类
        /// </summary>
        public IHalAcqOperator Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                if (value != _operator)
                    _operator = (HalAcqOperator)value;
            }
        }
        /// <summary>
        /// 获取相机状态信息对象
        /// </summary>
        public IHalAcqState AcqStateInfo
        {
            get
            {
                return acqState;
            }
        }

        public IHalGigEAccess GigEAccess
        {
            get { return halGigEAccess; }
        }

        public IHalAcqOpenInfo OpenInfo
        {
            get { return cameraOpenInfo; }
        }

        /// <summary>
        /// 获取或设置是否启用异步抓帧
        /// </summary>
        public bool UseAsyncGrab
        {
            get { return asyncGrab; }
            set
            {
                if (AcqStateInfo.IsCameraLinked)
                {
                    if (__halAcqHandle.TupleNotEqual(null))
                    {
                        if (value != asyncGrab)
                            SetAsyncGrabStatus(value);
                    }
                }
            }
        }

        /// <summary>
        /// 获取输出图像
        /// </summary>
        public IHalImage OutputImage
        {
            get { return m_outputImage; }
        }

        /// <summary>
        /// 获取相机是否在实时显示
        /// </summary>
        public bool IsCameraLiveDisplay
        {
            get { return isRealDisplay; }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 关闭相机/断开相机连接
        /// </summary>
        /// <returns></returns>
        public bool CloseCamera()
        {
            if (__halAcqHandle == null) throw new NullReferenceException("相机句柄为空");
            if (acqState.IsCameraLinked)
            {
                HTuple hv_halconError;
                try
                {
                    HOperatorSet.CloseFramegrabber(__halAcqHandle);
                    acqState.AcqHandle = __halAcqHandle;
                    if (CameraClosed != null)
                        CameraClosed(halGigEAccess.DeviceName);
                    return true;
                }
                catch (HalconException e)
                {
                    hv_halconError = e.GetErrorCode();
                    if ((int)hv_halconError < 0)
                        throw e;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 运行取像
        /// </summary>
        public void Run()
        {
            if (isRealDisplay) return;
            int ticketCount = System.Environment.TickCount;
            HObject ho_OutputImage;
            HOperatorSet.GenEmptyObj(out ho_OutputImage);
            if (asyncGrab)
            {
                ho_OutputImage = SafeAsyncGrabImage();
            }
            else
            {
                ho_OutputImage = SafeSyncGrabImage();
            }
            int triggerNumber = System.Environment.TickCount;
            m_outputImage = new HalImage8Grey(ref ho_OutputImage);
            HalCompleteEventArgs eventArgs = new HalCompleteEventArgs(ticketCount, triggerNumber, m_outputImage);
            if (Complete != null)
            {
                Complete(this, eventArgs);
               
            }
               

        }

        public void StartLiveDisplay()
        {
            if (isRealDisplay == false)
            {
                isRealDisplay = true;

                System.Threading.Thread.Sleep(100);
                UseAsyncGrab = true;    //启用异步抓帧
                System.Threading.Tasks.Task disTask = new System.Threading.Tasks.Task(new Action(() =>
                 {
                     LiveDisplayGrab();
                 }));
                disTask.Start();
            }

        }

        public void StopLiveDisplay()
        {
            if (isRealDisplay)
            {
                isRealDisplay = false;
                System.Threading.Thread.Sleep(100);
                UseAsyncGrab = false;
            }
        }
        #endregion

        #region 私有方法

        private void LiveDisplayGrab()
        {
            while (isRealDisplay)
            {
                try
                {

                    int ticketCount = System.Environment.TickCount;
                    HObject ho_OutputImage = null;

                    ho_OutputImage = SafeAsyncGrabImage();
                   HalImage8Grey image = new HalImage8Grey(ref ho_OutputImage);
                   int triggerNumber = System.Environment.TickCount;
                    HalCompleteEventArgs eventArgs = new HalCompleteEventArgs(ticketCount, triggerNumber, image);
                    Complete?.Invoke(this, eventArgs);
                
                   // Console.WriteLine("Grab one Image");
                }
                catch (Exception ex)
                {
                    isRealDisplay = false;

                    Console.WriteLine(ex.ToString());
                    //throw ex;
                }
            }
        }

        private bool OpenCamera(ref IHalAcqOpenInfo openInfo)
        {
            HTuple hv_HalconError;
            try
            {
                HOperatorSet.OpenFramegrabber(openInfo.Name, openInfo.HorizontalResolution, openInfo.VerticalResolution,
                    openInfo.ImageWitdth, openInfo.ImageHeight, openInfo.StartRow, openInfo.StartColumn, openInfo.Field,
                    openInfo.BitsPerChannel, openInfo.ColorSpace, openInfo.Generic, openInfo.ExternalTrigger, openInfo.CameraType,
                    openInfo.Device, openInfo.Port, openInfo.LineIn, out __halAcqHandle);
                acqState.AcqHandle = __halAcqHandle;

                if (CameraInitialComplete != null)
                    CameraInitialComplete(openInfo.Device.S);
                return true;
            }
            catch (HalconException ex)
            {
                hv_HalconError = ex.GetErrorCode();
                Console.WriteLine("OpenCamera Error:" + ex.ToString());
                acqState.AcqHandle = __halAcqHandle;
                return false;
            }

        }

        /// <summary>
        /// 判断当前系统上是否存在指定的相机
        /// </summary>
        /// <param name="devicename">指定相机名称</param>
        /// <returns></returns>
        private bool SystemExistCamera(string devicename)
        {
            List<string> cameras = GetSYSCameraList();
            if (cameras.Contains(devicename))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取当前系统上连接的所有相机名称
        /// </summary>
        /// <returns></returns>
        private List<string> GetSYSCameraList()
        {
            List<string> camList = new List<string>();
            HTuple hv_infomation;
            HTuple hv_InfoList;

            HOperatorSet.InfoFramegrabber(new HTuple("GigEVision2"), new HTuple("info_boards"), out hv_infomation, out hv_InfoList);
            if (hv_InfoList.SArr.Count() == 0)
                return camList;
            else
            {
                foreach (var item in hv_InfoList.SArr)
                {
                    string[] infomation = new string[] { };
                    infomation = item.Split('|');
                    foreach (var str in infomation)
                    {
                        string indexInfo = str.Trim();
                        string[] _val = new string[] { };
                        _val = indexInfo.Split(':');
                        if (_val[0] == "device")
                        {
                            camList.Add(_val[1]);
                            break;
                        }
                    }

                }
                return camList;
            }
        }

        /// <summary>
        /// 设置异步抓帧状态
        /// </summary>
        /// <param name="state"></param>
        private void SetAsyncGrabStatus(bool state)
        {
            if (state)
            {
                try
                {
                    HOperatorSet.GrabImageStart(__halAcqHandle, -1);
                    asyncGrab = state;
                }
                catch (HalconException e)
                {
                    throw e;
                }
            }
            else
                asyncGrab = state;
        }

        private object syncGrabLocker = new object();//同步取像锁
        private HObject SafeSyncGrabImage()
        {
            HObject ho_image;
            lock (syncGrabLocker)
            {
                    HOperatorSet.GrabImage(out ho_image, __halAcqHandle);//同步方式抓取一帧图像
            }
            return ho_image;
        }

        //private object asyncGrabLocker = new object(); //异步抓帧锁
        private HObject SafeAsyncGrabImage()
        {
            HObject ho_Image = null; ;
            // lock (asyncGrabLocker)
            // {
                HOperatorSet.GrabImageAsync(out ho_Image, __halAcqHandle, -1);//异步方式抓取一帧图像
            //}
            return ho_Image;
        }

        /// <summary>
        /// 序列化当前类
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("operator", _operator, typeof(HalAcqOperator));
            info.AddValue("cameraOpenInfo", cameraOpenInfo, typeof(IHalAcqOpenInfo));
            info.AddValue("asyncGrabImage", asyncGrab);
            info.AddValue("outputImage", m_outputImage, typeof(IHalImage));
        }

        #endregion

        #region 委托




        #endregion

        #region 事件

        /// <summary>
        /// 相机初始化完成事件
        /// </summary>
        public event Action<string> CameraInitialComplete;

        /// <summary>
        /// 相机关闭事件
        /// </summary>
        public event Action<string> CameraClosed;


        public event HalCompleteEventHandler Complete;
        #endregion

    }

     public delegate void HalCompleteEventHandler(object sender, HalCompleteEventArgs e);
}
