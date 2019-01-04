//Halcon.MVision.HalEventCatch
using System;
using System.Collections;
using System.Reflection;
using Halcon.MVision;

namespace Halcon.MVision
{
   internal class HalEventCatch:HalAddRemoveEvent
    {
        public delegate void HalCatchEventHandler(object sender,EventArgs args);

        private ArrayList[] obj = new ArrayList[3] { new ArrayList(),new ArrayList(),new ArrayList()};

        protected bool mGUIChanged;

        protected ArrayList Source
        {
            get { return this.obj[0]; }
        }

        protected ArrayList StateFlag
        {
            get { return this.obj[1]; }
        }

        protected ArrayList Paths
        {
            get { return this.obj[2]; }
        }

        public event HalCatchEventHandler Changed;

        public void ChangedEvent(object sender, HalChangedEventArgs e)
        {
            if (this.mGUIChanged)
            {
                this.mGUIChanged = false;
            }
            else
            {
                int i = 0;
                while (true)
                {
                    if (i < this.Source.Count)
                    {
                        if (sender.Equals(this.Source[i]) && (e.StateFlags & (long)this.StateFlag[i]) == (long)this.StateFlag[i])
                        {
                            if (i + 1 == this.Source.Count)
                            {
                                break;
                            }
                            Object obj = sender;
                            for (; i < this.Source.Count-1; i++)
                            {
                                PropertyInfo[] properties = obj.GetType().GetProperties();
                                PropertyInfo[] array = properties;
                                foreach (PropertyInfo propertyInfo in array)
                                {
                                    if (propertyInfo.Name == (string)this.Paths[i])
                                    {
                                        obj = obj = GetType().InvokeMember(propertyInfo.Name,BindingFlags.GetProperty,null,obj,null);
                                        if (obj != this.Source[i + 1])
                                        {
                                            base.removeEvent(this.Source[i+1],this);
                                            base.addEvent(obj,this,null);
                                            this.Source[i + 1] = obj;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    i++;
                    continue;
                }
                return;
            }
            this.Changed(this,EventArgs.Empty);
        }
    }
}
