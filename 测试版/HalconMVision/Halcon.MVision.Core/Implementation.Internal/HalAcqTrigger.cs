//Halcon.MVision.Implementation.Internal.HalAcqTrigger
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

//**********************************************
//文件名：HalAcqTrigger
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：相机触发控制类
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/12 10:10:53
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    [Serializable]
    public class HalAcqTrigger : CAcqOperatorBase,IHalAcqTrigger, IDisposable,IHalChangedEvent,ISerializable,ICloneable
    {
        [NonSerialized]
        private HTuple __acqHandle;//相机句柄

        private bool triggerEnable;//触发使能
        private HTuple currentTrigger ;
        private HTuple triggerSource;

        public static StateFlagsCollection _stateFlags;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hAcq">相机句柄</param>
        public HalAcqTrigger(HTuple hAcq)
        {
            if (hAcq.TupleNotEqual(null))
            {
                __acqHandle = hAcq;
                InitializeParam();
            }

        }

        private  HalAcqTrigger(HalAcqTrigger other)
        {
            GetStateFlages();
            Changed = null;
            __acqHandle = other.__acqHandle;
            triggerEnable = other.triggerEnable;
            triggerSource = other.triggerSource;
            currentTrigger = other.currentTrigger;

        }
        private HalAcqTrigger(SerializationInfo info, StreamingContext context)
        {
            GetStateFlages();
            triggerEnable = info.GetBoolean("triggerEnable");
            currentTrigger = (HTuple)info.GetValue("currentTrigger",typeof(HTuple));
            triggerSource = (HTuple)info.GetValue("triggerSource",typeof(HTuple));
        }
        #endregion


        #region 属性

        HTuple IHalAcqTrigger.AcqHandle
        {
            set
            {
                if (!HTuple.Equals(__acqHandle, value))
                {
                    __acqHandle = value;
                    SetCameraTrigger();
                }
            }
        }
        /// <summary>
        /// 获取或设置相机触发使能
        /// </summary>
        bool IHalAcqTrigger.TriggeModel
        {
            get { return triggerEnable; }
            set
            {
                if (value != triggerEnable)
                {
                    if (__acqHandle == null)
                        throw new NullReferenceException("Trigger AcqHandle");
                    if (SetTriggerModel(value))
                        triggerEnable = value;

                }
            }
        }
        /// <summary>
        /// 获取或设置相机触发源
        /// </summary>
        HTuple IHalAcqTrigger.CurrentTriggerSource
        {
            get { return currentTrigger; }
            set
            {
                if (value != currentTrigger)
                {
                    if (!__acqHandle.Equals(null))
                    {
                        if (SetCameraTriggerSource(value))
                            currentTrigger = value;
                    }
                }
            }
        }

        /// <summary>
        /// 获取相机所有触发源
        /// </summary>
        HTuple IHalAcqTrigger.TriggerSource
        {
            get { return triggerSource; }
        }

        public int ChangedEventSuspended
        {
            get { return 0; }
        }

        public StateFlagsCollection StateFlags
        {
            get { return GetStateFlages(); }
        }


        #endregion

        #region 公共方法


        public void SuspendChangedEvent()
        {
           
        }

        public void ResumeAndRaiseChangedEvent()
        {
          
        }

        #endregion

        #region 私有方法

        private void InitializeParam()
        {
            GetCameraAllTriggerSource();
            GetTriggerModel();
            GetCurrentTrigger();
        }
        /// <summary>
        /// 设置相机触发模参数
        /// </summary>
        private void SetCameraTrigger()
        {
            //获取相机所有触发源
            GetCameraAllTriggerSource();
            SetTriggerModel(triggerEnable);
            SetCameraTriggerSource(currentTrigger);
        }

        /// <summary>
        /// 获取状态位数据集
        /// </summary>
        /// <returns></returns>
        private static StateFlagsCollection GetStateFlages()
        {
            if (_stateFlags == null)
            {
                HalAcqTrigger._stateFlags = new StateFlagsCollection(typeof(HalAcqImageProperty));
            }
            return HalAcqTrigger._stateFlags;
        }

        /**********************************************************************
        *                          设置相机参数
        *********************************************************************/
        /// <summary>
        /// 设置相机触摸模式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool SetTriggerModel(bool model)
        {
            if (model)
            {
                if (SetParam(__acqHandle, new HTuple("TriggerModel"), new HTuple("on")))
                    return true;
                else
                    return false;
            }
            else
            {
                if (SetParam(__acqHandle, new HTuple("TriggerModel"), new HTuple("off")))
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// 设置相机触发源
        /// </summary>
        /// <param name="triggerSource"></param>
        private bool SetCameraTriggerSource(string triggerSource)
        {
           return SetParam(__acqHandle, new HTuple("TriggerSource"), triggerSource);
        }

        /**********************************************************************
         *                          获取相机参数
         *********************************************************************/
        /// <summary>
        /// 获取相机所有触发源
        /// </summary>
        private void GetCameraAllTriggerSource()
        {
            triggerSource= GetParamValues(__acqHandle,new HTuple("TriggerSource"));
        }
        /// <summary>
        /// 获取相机除法使能
        /// </summary>
        private void GetTriggerModel()
        {
           HTuple model= GetParam(__acqHandle, new HTuple("TriggerModel"));
            if (model.S == "on")
                triggerEnable = true;
            else
                triggerEnable = false;
        }
        /// <summary>
        /// 获取相机当前触发源
        /// </summary>
        private void GetCurrentTrigger()
        {
            currentTrigger = GetParam(__acqHandle,new HTuple("TriggerSource"));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info,context); 
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("triggerEnable",triggerEnable,typeof(bool));
            info.AddValue("currentTrigger",currentTrigger,typeof(HTuple));
            info.AddValue("triggerSource",triggerSource,typeof(HTuple));
        }
         
        object ICloneable.Clone()
        {
            return Clone();
        }

        protected virtual object Clone()
        {
            return new HalAcqTrigger(this);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。


                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~HalAcqTrigger() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion

        #endregion

        #region 委托



        #endregion

        #region 事件

        public event HalChangedEventHandler Changed;

        #endregion
    }
}
