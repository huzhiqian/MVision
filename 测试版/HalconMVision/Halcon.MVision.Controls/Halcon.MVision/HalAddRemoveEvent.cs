//Halcon.MVision.HalAddRemoveEvent
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halcon.MVision
{
    internal class HalAddRemoveEvent
    {
        protected bool addEvent(object o, object target, ArrayList Source)
        {
            try
            {
                EventInfo[] events = o.GetType().GetEvents();
                EventInfo[] array = events;
                foreach (EventInfo eventInfo in array)
                {
                    if (eventInfo.Name == "Changed")
                    {
                        if (Source != null)
                        {
                            Source.Add(o);
                        }
                        eventInfo.AddEventHandler(o,Delegate.CreateDelegate(eventInfo.EventHandlerType,target,"ChangedEvent"));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("因为以下错误："+ ex.Message+"未能添加事件:"+o.GetType().Name);
            }
            return false;
        }//

        protected void removeEvent(object o,object target)
        {
            try
            {
                EventInfo[] events = o.GetType().GetEvents();
                EventInfo[] array = events;
                int num = 0;
                EventInfo eventInfo;
                while (true)
                {
                    if (num < array.Length)
                    {
                        eventInfo = array[num];
                        if (!(eventInfo.Name == "Changed"))
                        {
                            num++;
                            continue;
                        }
                        break;
                    }
                    return;
                }
                eventInfo.RemoveEventHandler(o,Delegate.CreateDelegate(eventInfo.EventHandlerType,target,"ChangedEvent"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("由于以下原因："+ ex.Message+"未能移除事件："+ o.GetType().Name);
            }
        }
    }
}
