//Halcon.MVision.HalWidgetBase
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halcon.MVision
{
    /// <summary>
    /// 控件装饰基类
    /// </summary>
    internal class HalWidgetBase : HalEventCatch, IWidgetBaseClass
    {
        private bool mElectric;
        private object mSubject;
        private string mPath;
        private bool mShowToolTips;
        private string mToolTips;
        private Control client;
        private ToolTip toolTip = new ToolTip();

        #region 构造函数

        public HalWidgetBase(Control ctl):base()
        {
            this.client = ctl;
        }


        #endregion


        #region 属性

        public object Subject
        {
            get { return this.mSubject; }
            set
            {
                if (value == null)
                    this.RemoveEvents();
                else if (this.mPath != null && this.mPath != string.Empty && this.mSubject != null)
                {
                    this.RemoveEvents();
                }
                this.mSubject = value;
                if (this.mPath != null && this.mPath != string.Empty && value != null)
                {
                    this.AddEvents();
                }
            }
        }
        public string Path
        {
            get { return this.mPath; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    this.RemoveEvents();
                }
                else if (this.mPath != null && this.mPath != string.Empty && this.mSubject != null)
                {
                    this.RemoveEvents();
                }
                this.mPath = value;
                if (this.mSubject != null && value != null && value != string.Empty)
                {
                    this.AddEvents();
                }
            }
        }
        public string ToolTipText
        {
            get { return this.mToolTips; }
            set
            {
                this.mToolTips = value;
                this.toolTip.SetToolTip(this.client,this.ShowToolTips?this.mToolTips:"");
            }
        }
        public bool ShowToolTips
        {
            get { return mShowToolTips; }
            set
            {
                this.mShowToolTips = value;
                this.toolTip.SetToolTip(this.client,this.ShowToolTips?this.mToolTips:"");
            }
        }
        /// <summary>
        /// 是否是使用电动效果
        /// </summary>
        public bool Electric
        {
            get { return mElectric; }
            set { this.mElectric = value; }
        }

        public object ParentSource
        {
            get
            {
                if(base.Source.Count==0)
                   {
                    return null;
                }
                if (this.ParentPath != null && this.ParentPath.StartsWith("Owned"))
                {
                    string[] array = this.ParentPath.Split(',');
                    PropertyInfo propertyInfo = base.Source[base.Source.Count - 1].GetType().GetProperty(array[0]);
                    if (propertyInfo == (PropertyInfo)null)
                    {
                        return null;
                    }
                    return propertyInfo.GetValue(base.Source[base.Source.Count-1],null);
                }
                return base.Source[base.Source.Count-1];
            }
        }

        public string ParentPath
        {
            get
            {
                if (base.Paths.Count == 0)
                    return null;
                return (string)base.Paths[base.Paths.Count-1];
            }
        }

        public PropertyInfo ParentProperty
        {
            get
            {
                if (this.ParentSource == null)
                {
                    return null;
                }
                if (this.ParentPath.StartsWith("Owned"))
                {
                    string[] array = this.ParentPath.Split(',');
                    return this.ParentSource.GetType().GetProperty(array[1]);
                }
                return this.ParentSource.GetType().GetProperty(this.ParentPath);
            }
        }

        public bool GUIChanged
        {
            get { return base.mGUIChanged; }
            set { base.mGUIChanged = value; }
        }
        #endregion


        #region 公共方法

        public void RemoveEvents()
        {
            foreach (object item in base.Source)
            {
                base.removeEvent(item, this);
            }
            base.Source.Clear();
            base.Paths.Clear();
            base.StateFlag.Clear();
        }

        public void AddEvents()
        {
            if (this.mSubject != null && this.mPath != null && !(this.mPath == string.Empty))
            {
                try
                {
                    object obj = this.mSubject;
                    base.addEvent(obj,this,base.Source);
                    string text = this.mPath.Trim();
                    string text2 = text;
                    string text3 = "";
                    if (text.IndexOf(".") >= 0)
                    {
                        while (text2.IndexOf(".") >= 0)
                        {
                            text3 = text2.Substring(0,text2.IndexOf("."));
                            text2 = text2.Substring(text2.IndexOf("0")+1,text2.Length-text2.IndexOf(".")-1);
                            if (text3.StartsWith("Owned"))
                            {
                                break;
                            }
                            PropertyInfo[] properties = obj.GetType().GetProperties();
                            PropertyInfo[] array = properties;
                            foreach (PropertyInfo propertyInfo in array)
                            {
                                if (propertyInfo.Name == text3)
                                {
                                    base.Paths.Add(text3);
                                    this.ConvertToStateFlag(obj,text3);
                                    obj = obj.GetType().InvokeMember(text3,BindingFlags.GetProperty,null,obj,null);
                                    base.addEvent(obj,this,base.Source);
                                    break;
                                }
                            }
                        }
                    }
                    if (obj != null)
                    {
                        base.Paths.Add(text3.StartsWith("Owned")?(text3+"."+text2):text2);
                        this.ConvertToStateFlag(obj,text2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("意外的错误："+ ex.Message);
                }
            }
        }//


        public object CllByPath(object target,string name,BindingFlags flags,object[] value)
        {
            if (target != null && name != null & !(name == string.Empty))
            {
                try
                {
                    object obj = target;
                    name = name.Trim();
                    string text = name;
                    if (name.IndexOf(".") >= 0)
                    {
                        while (text.IndexOf(".")>=0)
                        {
                            string text2 = text.Substring(0,text.IndexOf("."));
                            text = text.Substring(text.IndexOf(".")+1,text.Length-text.IndexOf(".")-1);
                            PropertyInfo[] properties = obj.GetType().GetProperties();
                            PropertyInfo[] array = properties;
                            foreach (PropertyInfo propertyInfo in array)
                            {
                                if (propertyInfo.Name == text2)
                                {
                                    obj = obj.GetType().InvokeMember(text2,BindingFlags.GetProperty,null,obj,null);
                                    break;
                                }
                            }
                        }
                    }
                    if (obj == null) return null;
                    return obj.GetType().InvokeMember(text,flags,null,obj,value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("意外的错误在CallByPath中发生：" + ex.Message);
                    return null;
                }
            }
            return null;
        }

        public string LastString(string target)
        {
            if (target != null && !(target == string.Empty))
            {
                target.Trim();
                int num = target.LastIndexOf(".");
                if (num > 0)
                {
                    return target.Substring(num + 1, target.Length - num - 1);
                }
                return target;
            }
            return null;
        }

        /// <summary>
        /// 消除控件电动效果
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="source"></param>
        public void EraseElectric(Type objectType,Control source)
        {
            using (Bitmap bitmap = new Bitmap(objectType, "Icons.ElectricNarrow.ico"))
            {
                Point location = new Point(source.Location.X-bitmap.Width-2,source.Location.Y);
                Size size = new Size(bitmap.Width,bitmap.Height+(source.Height-bitmap.Height)/2);
                Rectangle rc = new Rectangle(location,size);
                source.Parent.Invalidate(rc);
            }
        }

        public void DrawElectric(Type objectType,Control source)            
        {
            if (this.Electric)
            {
                Graphics graphics = source.Parent.CreateGraphics();
                using (Bitmap bitmap = new Bitmap(objectType, "Icons.ElectricNarrow.ico"))
                {
                    Point location = source.Location;
                    graphics.DrawImage(bitmap,location.X-bitmap.Width-2,location.Y+(source.Height-bitmap.Height)/2);
                }
                graphics.Dispose();
            }
        }
        #endregion

        #region 私有方法

        private bool ConvertToStateFlag(object o,string name)
        {
            if (o == null) return false;
            FieldInfo[] fields = o.GetType().GetFields();
            name = "Sf" + name;
            FieldInfo[] array = fields;
            foreach (FieldInfo fieldInfo in array)
            {
                if (fieldInfo.Name == name)
                {
                    base.StateFlag.Add(fieldInfo.GetValue(fieldInfo));
                    return true;
                }
            }
            MessageBox.Show("未能找到标签：" + name);
            return false;
        }
        #endregion


    }
}
