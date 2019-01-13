using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using Halcon.MVision;
using Halcon.MVision.Implementation.Internal;
using HalconDotNet;
using System.Runtime.Serialization;
using System.Windows.Forms;


//**********************************************
//文件名：HalAcqOperator
//命名空间：Halcon.MVision
//CLR版本：4.0.30319.42000
//内容：
//功能：相机内参操作类，负责相机内参的统一管理
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/1/7 20:43:31
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    [Serializable]
    internal class HalAcqOperator : IHalAcqOperator, ISerializable
    {
        [NonSerialized]
        private HTuple __acqHandle;
        private IHalAcqExposure exposureParam;

        private IHalAcqBrightness brightnessParam;

        private IHalAcqContrast contrastParam;

        private IHalAcqTrigger triggerParam;

        private IHalAcqImageProperty imagePropertyParam;
        #region 构造函数

        public HalAcqOperator(ref HTuple acqHnadle)
        {
            if (acqHnadle.TupleNotEqual(null))
            {
                __acqHandle = acqHnadle;
                exposureParam = new HalAcqExposure(ref __acqHandle);
                brightnessParam = new HalAcqBrightness(ref __acqHandle);
                contrastParam = new HalAcqContrast(ref __acqHandle);
                triggerParam = new HalAcqTrigger(ref __acqHandle);
                imagePropertyParam = new HalAcqImageProperty(ref __acqHandle);
            }
        }

        private HalAcqOperator(SerializationInfo info, StreamingContext context)
        {
            exposureParam = (IHalAcqExposure)info.GetValue("exposureParam", typeof(IHalAcqExposure));
            brightnessParam = (IHalAcqBrightness)info.GetValue("brightnessParam", typeof(IHalAcqBrightness));
            contrastParam = (IHalAcqContrast)info.GetValue("contrastParam", typeof(IHalAcqContrast));
            triggerParam = (IHalAcqTrigger)info.GetValue("triggerParam", typeof(IHalAcqTrigger));
            imagePropertyParam = (IHalAcqImageProperty)info.GetValue("imagePropertyParam", typeof(IHalAcqImageProperty));

        }

        #endregion


        #region 属性

        public HTuple CameraHandle
        {
            set
            {
                if (value.TupleNotEqual(null) && value.TupleNotEqual(__acqHandle))
                {
                    __acqHandle = value;
                    if (exposureParam != null)
                        exposureParam.AcqHandle = value;
                    if (brightnessParam != null)
                        brightnessParam.AcqHandle = value;
                    if (contrastParam != null)
                        contrastParam.AcqHandle = value;
                    if (triggerParam != null)
                        triggerParam.AcqHandle = value;
                    if (imagePropertyParam != null)
                        imagePropertyParam.AcqHandle = value;
                }
            }
        }
        /// <summary>
        /// 获取曝光参数
        /// </summary>

        IHalAcqExposure IHalAcqOperator.OwnedExposureParam
        {
            get { return exposureParam; }
        }

        /// <summary>
        /// 获取对比度参数
        /// </summary>
        IHalAcqContrast IHalAcqOperator.OwnedContrastParam
        {
            get { return contrastParam; }
        }
        /// <summary>
        /// 获取亮度参数
        /// </summary>
        IHalAcqBrightness IHalAcqOperator.OwnedBrightnessParam
        {
            get { return brightnessParam; }
        }

        /// <summary>
        /// 获取相机触发参数
        /// </summary>
        IHalAcqTrigger IHalAcqOperator.OwnedTriggerParam
        {
            get { return triggerParam; }
        }

        /// <summary>
        /// 获取图像属性
        /// </summary>
        IHalAcqImageProperty IHalAcqOperator.OwnedImagePropertyParam
        {
            get { return imagePropertyParam; }
        }


        #endregion

        #region 公共方法



        #endregion

        #region 私有方法

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("exposureParam", exposureParam, typeof(IHalAcqExposure));
            info.AddValue("brightnessParam", brightnessParam, typeof(IHalAcqBrightness));
            info.AddValue("contrastParam", contrastParam, typeof(IHalAcqContrast));
            info.AddValue("triggerParam", triggerParam, typeof(IHalAcqTrigger));
            info.AddValue("imagePropertyParam", imagePropertyParam, typeof(IHalAcqImageProperty));
        }
        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
