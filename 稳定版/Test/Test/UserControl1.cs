
        // Cognex.VisionPro.CogEditControlBaseV2
using Cognex.VisionPro;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.Implementation.Internal;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

[ToolboxItem(false)]
    public class CogEditControlBaseV2 : UserControl, ICogEditControl, ICogMultithreadedComponent
    {
        private class CogSubcontrolWatcher : CogPropertyWatcher
        {
            public readonly CogEditControlBaseV2 mSubcontrol;

            public CogSubcontrolWatcher(object subject, string path, CogEditControlBaseV2 subcontrol)
                : base(subject, path)
            {
                this.mSubcontrol = subcontrol;
            }
        }

        public class CogSubjectChangeEventArgs : EventArgs
        {
            public enum CogSubjectChangeTriggerConstants
            {
                External,
                Reset,
                Persistence,
                UserDefined
            }

            public readonly CogSubjectChangeTriggerConstants Cause;

            public readonly object OldSubject;

            public readonly object NewSubject;

            public CogSubjectChangeEventArgs(CogSubjectChangeTriggerConstants cause, object oldSubject, object newSubject)
            {
                this.Cause = cause;
                this.OldSubject = oldSubject;
                this.NewSubject = newSubject;
            }
        }

        protected CogElectricProvider mElectricProvider;

        protected internal CogInUseFlag mSafeFlag = new CogInUseFlag();

        [NonSerialized]
        private object mSubject;

        [NonSerialized]
        private bool mSubjectInUse;

        [NonSerialized]
        private bool mEnableQueuing;

        [NonSerialized]
        private bool mShowElectricIndicators;

        [NonSerialized]
        internal readonly CogRegisterComponentImpl mRegisterComponentImpl;

        [NonSerialized]
        private ArrayList mSubcontrolSubjectWatchers;

        private bool mHandleSubjectValuesChanged;

        private object mHandleSubjectValuesChangedLock = new object();

        private IContainer components;

        protected internal ToolTip mToolTips;

        protected internal CogToolPropertyProvider mPropertyProvider;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool SubjectInUse
        {
            get
            {
                return this.mSubjectInUse;
            }
            set
            {
                if (this.mSubjectInUse != value)
                {
                    using (this.mSafeFlag.StartUsing())
                    {
                        this.mSubjectInUse = value;
                        this.ProcessLoopSafeQueuedDelegates();
                        if (!base.IsDisposed)
                        {
                            this.mPropertyProvider.SubjectInUse = value;
                            this.DecideIfElectricityIsOn();
                            this.mRegisterComponentImpl.PushSubjectInUseToComponents();
                            this.SubjectInUseChanged();
                        }
                    }
                }
            }
        }

        [DefaultValue(false)]
        public bool EnableDelegateQueuing
        {
            get
            {
                return this.mEnableQueuing;
            }
            set
            {
                if (this.mEnableQueuing != value)
                {
                    if (this.mSubjectInUse)
                    {
                        throw new NotSupportedException("Cannot modify EnableDelegateQueuing while SubjectInUse is set.");
                    }
                    this.mEnableQueuing = value;
                    this.mPropertyProvider.EnableDelegateQueuing = value;
                    this.mRegisterComponentImpl.PushEnableDelegateQueuingToComponents();
                    this.EnableDelegateQueuingChanged();
                }
            }
        }

        [DefaultValue(false)]
        public bool ShowToolTips
        {
            get
            {
                return this.mToolTips.Active;
            }
            set
            {
                if (this.mToolTips.Active != value)
                {
                    this.mToolTips.Active = value;
                    this.mRegisterComponentImpl.PushShowToolTipsToComponents();
                    this.ShowToolTipsChanged();
                }
            }
        }

        [DefaultValue(false)]
        public bool ShowElectricIndicators
        {
            get
            {
                return this.mShowElectricIndicators;
            }
            set
            {
                if (this.mShowElectricIndicators != value)
                {
                    this.mShowElectricIndicators = value;
                    this.DecideIfElectricityIsOn();
                    this.mRegisterComponentImpl.PushShowElectricIndicatorsToComponents();
                    this.ShowElectricIndicatorsChanged();
                }
            }
        }

        Queue ICogMultithreadedComponent.DelegateQueue
        {
            get
            {
                return this.mPropertyProvider.DelegateQueue;
            }
            set
            {
                this.mPropertyProvider.DelegateQueue = value;
                this.mRegisterComponentImpl.PushDelegateQueueToComponents();
            }
        }

        Queue ICogMultithreadedComponent.LoopSafeDelegateQueue
        {
            get
            {
                return this.mPropertyProvider.LoopSafeDelegateQueue;
            }
            set
            {
                this.mPropertyProvider.LoopSafeDelegateQueue = value;
                this.mRegisterComponentImpl.PushLoopSafeDelegateQueueToComponents();
            }
        }

        CogInUseFlag ICogMultithreadedComponent.SafeFlag
        {
            get
            {
                return this.mSafeFlag;
            }
            set
            {
                this.mSafeFlag = value;
                this.mRegisterComponentImpl.PushSafeFlagToComponents();
            }
        }

        bool ICogMultithreadedComponent.SubjectInUse
        {
            get
            {
                return this.SubjectInUse;
            }
            set
            {
                this.SubjectInUse = value;
            }
        }

        bool ICogMultithreadedComponent.EnableDelegateQueuing
        {
            get
            {
                return this.EnableDelegateQueuing;
            }
            set
            {
                this.EnableDelegateQueuing = value;
            }
        }

        MethodInvoker ICogEditControl.ElectricDelegate
        {
            get
            {
                return this.mPropertyProvider.ExecuteElectricDelegate;
            }
            set
            {
                this.mPropertyProvider.ExecuteElectricDelegate = value;
                this.mRegisterComponentImpl.PushElectricDelegateToComponents();
            }
        }

        bool ICogEditControl.ShowToolTips
        {
            get
            {
                return this.ShowToolTips;
            }
            set
            {
                this.ShowToolTips = value;
            }
        }

        bool ICogEditControl.ShowElectricIndicators
        {
            get
            {
                return this.ShowElectricIndicators;
            }
            set
            {
                this.ShowElectricIndicators = value;
            }
        }

        public event EventHandler SubjectChanging;

        public event EventHandler SubjectChanged;

        protected internal void AssertSafe()
        {
        }

        private CogSubcontrolWatcher FindSubcontrolWatcher(CogEditControlBaseV2 subcontrol)
        {
            CogSubcontrolWatcher result = null;
            foreach (CogSubcontrolWatcher mSubcontrolSubjectWatcher in this.mSubcontrolSubjectWatchers)
            {
                if (object.ReferenceEquals(mSubcontrolSubjectWatcher.mSubcontrol, subcontrol))
                {
                    return mSubcontrolSubjectWatcher;
                }
            }
            return result;
        }

        public CogEditControlBaseV2()
            : this(false, false)
        {
        }

        public CogEditControlBaseV2(bool subjectInUse, bool enableDelegateQueuing)
        {
            this.InitializeComponent();
            this.mElectricProvider = new CogElectricProvider();
            this.mPropertyProvider.ElectricProvider = this.mElectricProvider;
            this.mPropertyProvider.ErrorProvider = new ErrorProvider();
            this.mSubcontrolSubjectWatchers = new ArrayList();
            this.mEnableQueuing = enableDelegateQueuing;
            this.mPropertyProvider.EnableDelegateQueuing = enableDelegateQueuing;
            this.mSubjectInUse = subjectInUse;
            this.mPropertyProvider.SubjectInUse = subjectInUse;
            this.mRegisterComponentImpl = new CogRegisterComponentImpl(this);
        }

        protected internal object GetSubject()
        {
            return this.mSubject;
        }

        private void DetachSubjectEvents()
        {
            lock (this.mHandleSubjectValuesChangedLock)
            {
                this.mHandleSubjectValuesChanged = false;
                ICogChangedEvent cogChangedEvent = this.mSubject as ICogChangedEvent;
                if (cogChangedEvent != null)
                {
                    cogChangedEvent.Changed -= this.SubjectValuesChangedHandler;
                }
            }
        }

        private void AttachSubjectEvents()
        {
            lock (this.mHandleSubjectValuesChangedLock)
            {
                this.mHandleSubjectValuesChanged = true;
                ICogChangedEvent cogChangedEvent = this.mSubject as ICogChangedEvent;
                if (cogChangedEvent != null)
                {
                    cogChangedEvent.Changed += this.SubjectValuesChangedHandler;
                }
            }
        }

        private void PrivateSetSubject(object value, CogSubjectChangeEventArgs evArgs, bool guaranteedSafe)
        {
            if (!base.IsHandleCreated)
            {
                IntPtr handle = base.Handle;
            }
            if (!this.mSubjectInUse || guaranteedSafe)
            {
                using (this.mSafeFlag.StartUsing())
                {
                    this.ProcessLoopSafeQueuedDelegates();
                    if (!base.IsDisposed)
                    {
                        goto end_IL_0026;
                    }
                    return;
                    end_IL_0026:;
                }
            }
            this.DetachSubjectEvents();
            this.OnSubjectChanging(evArgs);
            this.mSubject = value;
            this.AttachSubjectEvents();
            this.OnSubjectChanged(evArgs);
            if (!this.mSubjectInUse || guaranteedSafe)
            {
                using (this.mSafeFlag.StartUsing())
                {
                    this.InitializeFromSubject();
                }
            }
            else
            {
                this.mPropertyProvider.LoopSafeDelegateQueue.Enqueue(new DelegateQueueItem(new MethodInvoker(this.InitializeFromSubject), null));
            }
        }

        protected internal void SetSubject(object value)
        {
            this.SetSubject(value, false);
        }

        public virtual void SetSubjectAndInitialize(object value)
        {
            this.SetSubject(value, true);
        }

        protected void SetSubject(object value, bool guaranteedSafe)
        {
            this.SetSubject(value, CogSubjectChangeEventArgs.CogSubjectChangeTriggerConstants.External, guaranteedSafe);
        }

        protected void SetSubject(object value, CogSubjectChangeEventArgs.CogSubjectChangeTriggerConstants cause)
        {
            this.SetSubject(value, cause, false);
        }

        protected void SetSubject(object value, CogSubjectChangeEventArgs.CogSubjectChangeTriggerConstants cause, bool guaranteedSafe)
        {
            this.SetSubject(value, cause, guaranteedSafe, true);
        }

        protected void SetSubject(object value, CogSubjectChangeEventArgs.CogSubjectChangeTriggerConstants cause, bool guaranteedSafe, bool optimizeIneffectiveChanges)
        {
            if (object.ReferenceEquals(this.mSubject, value) && optimizeIneffectiveChanges)
            {
                return;
            }
            this.PrivateSetSubject(value, new CogSubjectChangeEventArgs(cause, this.mSubject, value), guaranteedSafe);
        }

        protected virtual void OnSubjectChanging(EventArgs e)
        {
            if (this.SubjectChanging != null)
            {
                this.SubjectChanging(this, e);
            }
        }

        protected virtual void OnSubjectChanged(EventArgs e)
        {
            if (this.SubjectChanged != null)
            {
                this.SubjectChanged(this, e);
            }
        }

        protected void RegisterComponent(ICogMultithreadedComponent component)
        {
            this.mRegisterComponentImpl.RegisterComponent(component);
        }

        protected void RegisterComponent(ICogMultithreadedComponent component, bool passElectric, bool passEDQing)
        {
            this.mRegisterComponentImpl.RegisterComponent(component, passElectric, passEDQing);
        }

        protected void UnregisterComponent(ICogMultithreadedComponent component)
        {
            this.mRegisterComponentImpl.UnregisterComponent(component);
        }

        protected void RegisterSubcontrolPath(CogEditControlBaseV2 subcontrol, string path)
        {
            CogSubcontrolWatcher subW = new CogSubcontrolWatcher(null, path, subcontrol);
            subW.Changed += this.WatcherHandler;
            subcontrol.Enabled = false;
            this.mSubcontrolSubjectWatchers.Add(subW);
            if (this.SubjectInUse)
            {
                this.mPropertyProvider.LoopSafeDelegateQueue.Enqueue(new DelegateQueueItem((MethodInvoker)delegate
                {
                    subW.Subject = this.mSubject;
                }, null));
            }
            else
            {
                subW.Subject = this.mSubject;
            }
        }

        protected void UnregisterSubcontrolPath(CogEditControlBaseV2 subcontrol)
        {
            CogSubcontrolWatcher cogSubcontrolWatcher = this.FindSubcontrolWatcher(subcontrol);
            if (cogSubcontrolWatcher == null)
            {
                throw new ArgumentException("subcontrol does not have a registered path");
            }
            cogSubcontrolWatcher.Subject = null;
            this.mSubcontrolSubjectWatchers.Remove(cogSubcontrolWatcher);
        }

        protected virtual void SubjectInUseChanged()
        {
        }

        private void DecideIfElectricityIsOn()
        {
            if (!base.DesignMode && this.SubjectInUse)
            {
                this.mElectricProvider.Active = false;
            }
            else
            {
                this.mElectricProvider.Active = this.mShowElectricIndicators;
            }
        }

        protected virtual void EnableDelegateQueuingChanged()
        {
        }

        public void ProcessQueuedDelegates()
        {
            using (this.mSafeFlag.StartUsing())
            {
                this.ProcessLoopSafeQueuedDelegates();
                if (!base.IsDisposed)
                {
                    this.mPropertyProvider.ProcessQueuedDelegates();
                }
            }
        }

        protected internal void ProcessLoopSafeQueuedDelegates()
        {
            this.AssertSafe();
            //this.mPropertyProvider.ProcessLoopSafeQueuedDelegates();
        }

        protected virtual void SubjectValuesChanged(object sender, CogChangedEventArgs e)
        {
        }

        protected virtual void InitializeFromSubject()
        {
            this.AssertSafe();
            this.mPropertyProvider.Subject = this.mSubject;
            this.DecideIfElectricityIsOn();
            foreach (CogSubcontrolWatcher mSubcontrolSubjectWatcher in this.mSubcontrolSubjectWatchers)
            {
                mSubcontrolSubjectWatcher.Subject = this.mSubject;
            }
        }

        protected virtual void ShowToolTipsChanged()
        {
        }

        protected virtual void ShowElectricIndicatorsChanged()
        {
        }

        private void SubjectValuesChangedHandler(object sender, CogChangedEventArgs e)
        {
            lock (this.mHandleSubjectValuesChangedLock)
            {
                if (this.mHandleSubjectValuesChanged)
                {
                    goto end_IL_0002;
                }
                return;
                end_IL_0002:;
            }
            if (base.InvokeRequired)
            {
                base.Invoke(new CogChangedEventHandler(this.SubjectValuesChangedHandler), sender, e);
            }
            else if (object.ReferenceEquals(sender, this.GetSubject()))
            {
                using (this.mSafeFlag.StartUsing())
                {
                    this.ProcessLoopSafeQueuedDelegates();
                    if (!base.IsDisposed)
                    {
                        this.SubjectValuesChanged(sender, e);
                    }
                }
            }
        }

        private void WatcherHandler(object sender, CogChangedEventArgs e)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new CogChangedEventHandler(this.WatcherHandler), sender, e);
            }
            else
            {
                using (this.mSafeFlag.StartUsing())
                {
                    this.ProcessLoopSafeQueuedDelegates();
                    if (!base.IsDisposed)
                    {
                        CogSubcontrolWatcher cogSubcontrolWatcher = (CogSubcontrolWatcher)sender;
                        if ((e.StateFlags & 0x20) != 0)
                        {
                            cogSubcontrolWatcher.mSubcontrol.Enabled = cogSubcontrolWatcher.IsConnected;
                        }
                        if ((e.StateFlags & 8) != 0)
                        {
                            if (cogSubcontrolWatcher.Subject == null)
                            {
                                cogSubcontrolWatcher.mSubcontrol.SetSubjectAndInitialize(null);
                            }
                            else
                            {
                                object subjectAndInitialize = null;
                                try
                                {
                                    subjectAndInitialize = cogSubcontrolWatcher.Value;
                                }
                                catch (Exception)
                                {
                                }
                                cogSubcontrolWatcher.mSubcontrol.SetSubjectAndInitialize(subjectAndInitialize);
                            }
                        }
                    }
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.GetSubject() == null)
            {
                this.mPropertyProvider.Subject = null;
            }
        }

        protected PropertyInfo GetSubjectPropertyInfo()
        {
            return this.GetSubjectPropertyInfo(base.GetType());
        }

        protected PropertyInfo GetSubjectPropertyInfo(Type type)
        {
            PropertyInfo propertyInfo = null;
            propertyInfo = type.GetProperty("Subject", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            if (propertyInfo == (PropertyInfo)null)
            {
                propertyInfo = type.GetProperty("Subject", BindingFlags.Instance | BindingFlags.Public);
            }
            if (propertyInfo == (PropertyInfo)null)
            {
                propertyInfo = type.GetProperty("Subject", BindingFlags.Instance | BindingFlags.NonPublic);
            }
            return propertyInfo;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
                this.DetachSubjectEvents();
                foreach (CogSubcontrolWatcher mSubcontrolSubjectWatcher in this.mSubcontrolSubjectWatchers)
                {
                    mSubcontrolSubjectWatcher.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.mToolTips = new ToolTip(this.components);
            this.mPropertyProvider = new CogToolPropertyProvider();
            base.SuspendLayout();
            this.mToolTips.Active = false;
            this.mToolTips.AutoPopDelay = 30000;
            this.mToolTips.InitialDelay = 500;
            this.mToolTips.ReshowDelay = 100;
            this.mPropertyProvider.ElectricProvider = null;
            this.mPropertyProvider.EnableDelegateQueuing = false;
            this.mPropertyProvider.ErrorProvider = null;
            this.mPropertyProvider.Subject = null;
            this.mPropertyProvider.SubjectInUse = false;
            base.AutoScaleMode = AutoScaleMode.None;
            base.Name = "CogEditControlBaseV2";
            base.Size = new Size(472, 296);
            base.ResumeLayout(false);
        }
    }



