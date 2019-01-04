//Halcon.MVision.IHalChangedEvent
using Halcon.MVision;
using System.ComponentModel;

namespace Halcon.MVision
{
    public interface IHalChangedEvent
    {
        [Browsable(false)]//标识对象不可被浏览
        int ChangedEventSuspended
        {
            get;
        }

        StateFlagsCollection StateFlags
        {
            get;
        }

        event HalChangedEventHandler Changed;

        /// <summary>
        /// 挂起改变事件
        /// </summary>
        void SuspendChangedEvent();
        /// <summary>
        /// 恢复和引起改变事件
        /// </summary>
        void ResumeAndRaiseChangedEvent();
    }
}
