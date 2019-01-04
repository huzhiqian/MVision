//Halcon.MVision.Controls.NumUpDownControl
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Halcon.MVision.Implementation;


namespace Halcon.MVision.Controls
{
    [DesignTimeVisible(true)]
    [ToolboxBitmap(typeof(NumericUpDown))]  //用系统样式，也可自定义工具箱显示样式
    [ToolboxItem(true)]//在vs工具箱中显示
    public class HalNumberBox:NumericUpDown,IWidgetBaseClass
    {
        private delegate void updateValue();

        private bool exited;

        private bool gotLock = true;
        private HalSyncObject mSync;
        private HalWidgetBase widget;
        private TextBox upDownEdit;
        private Control upDownButtons;
        private Button degButton;
        private int mButtonWidth;
        private bool mShowDegree;
        private updateValue mUpdateValueDelegate;
        private string mToolTips;
        private bool mShowToolTips;
        private ToolTip toolTip1 = new ToolTip();

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HalNumberBox():base() {


            this.widget = new HalWidgetBase(this);
            this.widget.Changed += this.widget_Changed;
            base.ValueChanged += this.HalNumberBox_ValueChanged;
            base.Leave += this.HalNumberBox_Leave;
            TextBox textBox = base.Controls[0] as TextBox;
            if (textBox == null)
            {
                this.upDownButtons = base.Controls[0];
                this.upDownEdit = (TextBox)base.Controls[1];
            }
            else
            {
                this.upDownEdit = (TextBox)base.Controls[0];
                this.upDownButtons = base.Controls[1];
            }
            this.mUpdateValueDelegate = this.setNumericValue;
        }


        #endregion

        #region 属性
        [Browsable(false)]
        public object Subject
        {
            get
            {
                return this.widget.Subject;
            }
            set
            {
                this.widget.Subject = value;
                if (!base.DesignMode)
                {
                    base.Enabled = ((byte)((value != null) ? 1 : 0) != 0);
                }
                this.setNumericValue();
            }
        }

        /// <summary>
        /// 被编辑主题的属性或子属性的路径。当Subject属性为空时不使用
        /// </summary>
        public string Path
        {
            get
            {
                return this.widget.Path;
            }
            set
            {
                this.widget.Path = value;
                this.setNumericValue();
            }
        }

        public string ToolTipText
        {
            get
            {
                return this.mToolTips;
            }
            set
            {
                this.mToolTips = value;
                this.showToolTips();
            }
        }

        public bool ShowToolTips
        {
            get
            {
                return this.mShowToolTips;
            }
            set
            {
                this.mShowToolTips = value;
                this.showToolTips();
            }
        }


        public bool Electric
        {
            get
            {
                return this.widget.Electric;
            }
            set
            {
                if (this.widget.Electric && !value)
                {
                    this.widget.EraseElectric(typeof(CheckBox), this);
                }
                this.widget.Electric = value;
                if (value)
                {
                    base.Invalidate();
                }
            }
        }

        /// <summary>
        /// 如果为真，HalNumberBox将显示一个角度/弧度命令按钮来切换单位。
        /// </summary>
        public bool UseAngleUnit
        {
            get
            {
                return this.mShowDegree;
            }
            set
            {
                if (this.mShowDegree && this.degButton != null)
                {
                    this.mButtonWidth = 0;
                    this.degButton.Click -= this.degButton_Click;
                    base.Controls.RemoveAt(2);
                    this.degButton.Dispose();
                    this.degButton = null;
                }
                this.mShowDegree = value;
                if (value)
                {
                    this.degButton = new Button();
                    this.degButton.Dock = DockStyle.Right;
                    this.degButton.Text = "deg";
                    this.degButton.Size = new Size(32, 16);
                    this.degButton.FlatStyle = FlatStyle.System;
                    this.degButton.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    this.degButton.BackColor = Color.FromKnownColor(KnownColor.Control);
                    this.degButton.TextAlign = ContentAlignment.MiddleCenter;
                    this.mButtonWidth = this.degButton.Width;
                    base.Controls.Add(this.degButton);
                    this.degButton.Click += this.degButton_Click;
                    this.showToolTips();
                }
            }
        }

        private bool showDegree
        {
            get
            {
                if (this.degButton != null)
                {
                    return this.degButton.Text == "deg";
                }
                return false;
            }
        }


        #endregion

        #region 公共方法
        public void ToolSyncObject(HalSyncObject objSync, bool autoUpdate)
        {
            if (objSync == null)
            {
                this.exited = true;
                if (autoUpdate && this.mSync != null && this.mSync.TryLock())
                {
                    this.mSync.Unlocked -= this.mSync_Unlocked;
                    this.mSync.Unlock();
                }
            }
            else
            {
                this.exited = false;
                this.mSync = objSync;
                if (autoUpdate)
                {
                    this.mSync.Unlocked += this.mSync_Unlocked;
                }
            }
        }

        #endregion

        #region 私有方法

        private void showToolTips()
        {
            foreach (Control control in base.Controls)
            {
                this.toolTip1.SetToolTip(control, this.ShowToolTips ? this.mToolTips : null);
            }
            if (this.degButton != null)
            {
                this.toolTip1.SetToolTip(this.degButton, this.ShowToolTips ? this.mToolTips : null);
            }
        }

        private decimal RadToDeg(decimal Value)
        {
            return (decimal)(Convert.ToDouble(Value) * 180.0 / 3.1415926535897931);
        }

        private decimal RadToDeg(double Value)
        {
            return (decimal)(Value * 180.0 / 3.1415926535897931);
        }

        private decimal DegToRad(decimal Value)
        {
            return (decimal)(Convert.ToDouble(Value) * 3.1415926535897931 / 180.0);
        }

        private decimal DegToRad(double Value)
        {
            return (decimal)(Value * 3.1415926535897931 / 180.0);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.widget.DrawElectric(typeof(CheckBox), this);
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            this.PositionControls();
        }

        protected override void OnTextBoxResize(object source, EventArgs e)
        {
        }

        private void setNumericValue()
        {
            if (this.Subject != null && this.Path != null && !(this.Path == string.Empty))
            {
                try
                {
                    PropertyInfo parentProperty = this.widget.ParentProperty;
                    if (!(parentProperty == (PropertyInfo)null))
                    {
                        object value = parentProperty.GetValue(this.widget.ParentSource, null);
                        base.ValueChanged -= this.HalNumberBox_ValueChanged;
                        if (this.showDegree)
                        {
                            if (this.DegToRad(base.Value) != Convert.ToDecimal(value))
                            {
                                base.Value = this.RadToDeg(Convert.ToDecimal(value));
                            }
                        }
                        else if (Convert.ToDecimal(value) != base.Value)
                        {
                            base.Value = Convert.ToDecimal(value);
                        }
                        base.ValueChanged += this.HalNumberBox_ValueChanged;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error (" + ex.Message + ") has occurred.");
                }
            }
        }

        private void widget_Changed(object sender, EventArgs e)
        {
            if (base.InvokeRequired)
            {
                IAsyncResult asyncResult = base.BeginInvoke(this.mUpdateValueDelegate);
                while (!asyncResult.IsCompleted && !asyncResult.AsyncWaitHandle.WaitOne(300, false))
                {
                }
                base.EndInvoke(asyncResult);
            }
            else
            {
                this.setNumericValue();
            }
        }

        private void PositionControls()
        {
            Size clientSize = base.ClientSize;
            LeftRightAlignment upDownAlign = base.UpDownAlign;
            if (this.upDownEdit != null)
            {
                this.upDownEdit.Size = new Size(clientSize.Width - (16 + this.mButtonWidth + 1), clientSize.Height);
                if (upDownAlign == LeftRightAlignment.Left)
                {
                    this.upDownEdit.Location = new Point(16, 0);
                }
                else
                {
                    this.upDownEdit.Location = new Point(0, 0);
                }
            }
            if (this.upDownButtons != null)
            {
                if (upDownAlign == LeftRightAlignment.Left)
                {
                    this.upDownButtons.Location = new Point(0, 0);
                }
                else
                {
                    this.upDownButtons.Location = new Point(clientSize.Width - (16 + this.mButtonWidth), 0);
                }
            }
            if (this.upDownButtons != null)
            {
                Size size = this.upDownButtons.Size;
                this.upDownButtons.Size = new Size(size.Width, clientSize.Height);
                this.upDownButtons.Invalidate();
                if (this.mButtonWidth > 0)
                {
                    this.degButton.Location = new Point(clientSize.Width - this.degButton.Width, 0);
                }
            }
        }

        private void degButton_Click(object sender, EventArgs e)
        {
            this.gotLock = false;
            try
            {
                if (this.mSync != null && this.mSync.ThreadID != Thread.CurrentThread.ManagedThreadId)
                {
                    this.gotLock = this.mSync.TryLock();
                    if (this.gotLock)
                    {
                        goto IL_0041;
                    }
                    goto end_IL_0007;
                }
                goto IL_0041;
                IL_0041:
                base.ValueChanged -= this.HalNumberBox_ValueChanged;
                this.UpdateSubjectValue();
                base.ValueChanged += this.HalNumberBox_ValueChanged;
                this.degButton.Text = ((this.degButton.Text == "deg") ? "rad" : "deg");
                this.setNumericValue();
                end_IL_0007:;
            }
            catch
            {
            }
            finally
            {
                if (this.gotLock)
                {
                    this.mSync.Unlock();
                }
            }
        }

        private void checkValue()
        {
            if (this.UpdateSubjectValue())
            {
                this.setNumericValue();
            }
        }

        private void HalNumberBox_Leave(object sender, EventArgs e)
        {
            PropertyInfo parentProperty = this.widget.ParentProperty;
            if (!(parentProperty == (PropertyInfo)null))
            {
                this.gotLock = false;
                try
                {
                    if (this.mSync != null && this.mSync.ThreadID != Thread.CurrentThread.ManagedThreadId)
                    {
                        this.gotLock = this.mSync.TryLock();
                        if (this.gotLock)
                        {
                            goto IL_0057;
                        }
                        goto end_IL_001d;
                    }
                    goto IL_0057;
                    IL_0057:
                    object value = parentProperty.GetValue(this.widget.ParentSource, null);
                    if (this.showDegree)
                    {
                        if (this.DegToRad(base.Value) != Convert.ToDecimal(value))
                        {
                            this.checkValue();
                        }
                    }
                    else if (Convert.ToDecimal(value) != base.Value)
                    {
                        this.checkValue();
                    }
                    end_IL_001d:;
                }
                catch
                {
                }
                finally
                {
                    if (this.gotLock)
                    {
                        this.mSync.Unlock();
                    }
                }
            }
        }

        private void HalNumberBox_ValueChanged(object sender, EventArgs e)
        {
            this.gotLock = false;
            try
            {
                if (this.mSync != null && this.mSync.ThreadID != Thread.CurrentThread.ManagedThreadId)
                {
                    this.gotLock = this.mSync.TryLock();
                    if (this.gotLock)
                    {
                        goto IL_0041;
                    }
                    goto end_IL_0007;
                }
                goto IL_0041;
                IL_0041:
                this.checkValue();
                end_IL_0007:;
            }
            catch
            {
            }
            finally
            {
                if (this.gotLock)
                {
                    this.mSync.Unlock();
                }
            }
        }

        private object ConvertTo(Type type, decimal Value)
        {
            if (type == typeof(double))
            {
                return (double)Value;
            }
            if (type == typeof(float))
            {
                return (float)Value;
            }
            if (type == typeof(short))
            {
                return (short)Value;
            }
            if (type == typeof(int))
            {
                return (int)Value;
            }
            if (type == typeof(long))
            {
                return (long)Value;
            }
            MessageBox.Show("An illegal type is used for the CogNumberBox. It only supports the following types: Int16, Int32, Int64, and double");
            return null;
        }

        private bool UpdateSubjectValue()
        {
            PropertyInfo parentProperty = this.widget.ParentProperty;
            if (parentProperty == (PropertyInfo)null)
            {
                return false;
            }
            try
            {
                this.widget.GUIChanged = true;
                object obj = 0;
                if (this.showDegree)
                {
                    obj = this.ConvertTo(parentProperty.PropertyType, this.DegToRad(base.Value));
                    if (obj == null)
                    {
                        return false;
                    }
                }
                else
                {
                    obj = this.ConvertTo(parentProperty.PropertyType, base.Value);
                    if (obj == null)
                    {
                        return false;
                    }
                }
                object value = parentProperty.GetValue(this.widget.ParentSource, null);
                if (!value.Equals(obj))
                {
                    parentProperty.SetValue(this.widget.ParentSource, obj, null);
                    if (this.Electric)
                    {
                        this.Subject.GetType().InvokeMember("Run", BindingFlags.InvokeMethod, null, this.Subject, null);
                    }
                    return true;
                }
                this.widget.GUIChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error (" + ex.Message + ") has occurred.");
            }
            return false;
        }

        private void reflectGUI()
        {
            this.gotLock = true;
            this.checkValue();
        }

        private void mSync_Unlocked(object sender, EventArgs e)
        {
            if (base.InvokeRequired)
            {
                try
                {
                    if (!this.gotLock)
                    {
                        IAsyncResult asyncResult = base.BeginInvoke(new MethodInvoker(this.reflectGUI));
                        while (!asyncResult.IsCompleted && !asyncResult.AsyncWaitHandle.WaitOne(300, false))
                        {
                        }
                        base.EndInvoke(asyncResult);
                    }
                }
                catch
                {
                    this.exited = true;
                }
                if (this.exited)
                {
                    if (this.mSync != null)
                    {
                        this.mSync.Unlocked -= this.mSync_Unlocked;
                    }
                    this.mSync = null;
                }
            }
        }
        #endregion

    }
}
