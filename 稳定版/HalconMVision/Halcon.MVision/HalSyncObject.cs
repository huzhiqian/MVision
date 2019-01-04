// Halcon.MVision.Implementation.HalSyncObject
using Halcon.MVision.Implementation;
using System;
using System.Threading;

namespace Halcon.MVision.Implementation
{
    /// <summary>
    /// 该类用于同步MVision成员访问。多线程程序必须向
    /// 任何编辑控件提供该类的实例，应用程序从非GUI线程访问
    /// 共享工具，应用程序有责任锁定和解锁
    /// </summary>
    public class HalSyncObject
    {

        private int _count;

        private readonly object _objectLock = new object();

        private int _threadID;

        #region 构造函数

        public HalSyncObject() { }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置用户指定的线程ID
        /// </summary>
        /// <value>
        /// 用户指定的线程ID,默认值为0
        /// </value>
        /// <remake>
        /// 该属性存储用户提供的线程ID,方便锁定HalSyncObject
        /// 中的线程，该属性时可选的
        /// </remake>

        public int ThreadID
        {
            get
            {
                return this._threadID;
            }
            set
            {
                this._threadID = value;
            }
        }

        #endregion

        #region 公共方法

        public void Lock()
        {
            Monitor.Enter(this._objectLock);
            this._count++;
            if (this._count == 1)
            {
                this.OnLock();
            }
        }

        public bool TryLock()
        {
            bool flag = Monitor.TryEnter(this._objectLock);
            if (flag)
            {
                this._count++;
                if (this._count == 1)
                {
                    this.OnLock();
                }
            }
            return flag;
        }

        public void Unlock()
        {
            bool flag = true;
            if (this._count > 0)
            {
                this._count--;
                if (this._count == 0)
                {
                    try
                    {
                        this.OnLock();
                    }
                    finally
                    {
                        Monitor.Exit(this._objectLock);
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                Monitor.Exit(_objectLock);
            }
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 该方法用于将Lock事件通知已注册的对象
        /// </summary>
        internal void OnLock()
        {
            HalLockedEventHandler locked = this.Locked;
            if (locked != null)
            {
                locked(this, new EventArgs());
            }
        }

        internal void OnUnlock()
        {
            HalUnLockEventHandler unlocked = this.Unlocked;
            if (unlocked != null)
            {
                unlocked(this,new EventArgs());
            }
        }
        #endregion

        #region 委托

        /// <summary>
        /// A delegate for the HalVisionToolSyncRoot Lock event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void HalLockedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// A delegate for the HalVisionToolSyncRoot Unlock event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void HalUnLockEventHandler(object sender, EventArgs e);

        #endregion

        #region 事件

        /// <summary>
        ///  This event is raised when this object is locked
        /// </summary>
        public event HalLockedEventHandler Locked;

        /// <summary>
        /// this event is raised when this object is unlocked
        /// </summary>
        public event HalUnLockEventHandler Unlocked;

        #endregion

    }
}
