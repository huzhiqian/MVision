namespace Halcon.MVision.Controls
{
    partial class HalAcqFifoEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalAcqFifoEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Run = new System.Windows.Forms.ToolStripButton();
            this.btn_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_SaveAll = new System.Windows.Forms.ToolStripButton();
            this.btn_RealDisplay = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg_CameraSetting = new System.Windows.Forms.TabPage();
            this.lbl_SerialNumber = new System.Windows.Forms.Label();
            this.numUpDown_TimeLimt = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_Contrast = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_Brightness = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_Exposure = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_InitializeCamera = new System.Windows.Forms.Button();
            this.cmb_ColorSpace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_CameraList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpg_TriggerSetting = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_TriggerSource = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chk_TriggerEnable = new System.Windows.Forms.CheckBox();
            this.tpg_ImageProperty = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_Width = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_StartY = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_StartX = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tpg_GigEInfo = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_AdapterIP = new System.Windows.Forms.Label();
            this.lbl_CameraIP = new System.Windows.Forms.Label();
            this.lbl_Firmware = new System.Windows.Forms.Label();
            this.lbl_Serial = new System.Windows.Forms.Label();
            this.lbl_CameraMode = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tpg_CustomSetting = new System.Windows.Forms.TabPage();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpg_CameraSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_TimeLimt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Exposure)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpg_TriggerSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpg_ImageProperty.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_StartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_StartX)).BeginInit();
            this.tpg_GigEInfo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Run,
            this.btn_OpenFile,
            this.btn_Save,
            this.btn_SaveAll,
            this.btn_RealDisplay});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(764, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Run
            // 
            this.btn_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Run.Image = ((System.Drawing.Image)(resources.GetObject("btn_Run.Image")));
            this.btn_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(23, 22);
            this.btn_Run.Text = "运行";
            this.btn_Run.ToolTipText = "运行";
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_OpenFile.Image")));
            this.btn_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(23, 22);
            this.btn_OpenFile.Text = "打开";
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(23, 22);
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_SaveAll
            // 
            this.btn_SaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SaveAll.Image = ((System.Drawing.Image)(resources.GetObject("btn_SaveAll.Image")));
            this.btn_SaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SaveAll.Name = "btn_SaveAll";
            this.btn_SaveAll.Size = new System.Drawing.Size(23, 22);
            this.btn_SaveAll.Text = "保存所有";
            // 
            // btn_RealDisplay
            // 
            this.btn_RealDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_RealDisplay.Image = ((System.Drawing.Image)(resources.GetObject("btn_RealDisplay.Image")));
            this.btn_RealDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_RealDisplay.Name = "btn_RealDisplay";
            this.btn_RealDisplay.Size = new System.Drawing.Size(23, 22);
            this.btn_RealDisplay.Text = "实时显示";
            this.btn_RealDisplay.Click += new System.EventHandler(this.btn_RealDisplay_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.hWindowControl1);
            this.splitContainer1.Size = new System.Drawing.Size(764, 481);
            this.splitContainer1.SplitterDistance = 412;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg_CameraSetting);
            this.tabControl1.Controls.Add(this.tpg_TriggerSetting);
            this.tabControl1.Controls.Add(this.tpg_ImageProperty);
            this.tabControl1.Controls.Add(this.tpg_GigEInfo);
            this.tabControl1.Controls.Add(this.tpg_CustomSetting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // tpg_CameraSetting
            // 
            this.tpg_CameraSetting.Controls.Add(this.lbl_SerialNumber);
            this.tpg_CameraSetting.Controls.Add(this.numUpDown_TimeLimt);
            this.tpg_CameraSetting.Controls.Add(this.numUpDown_Contrast);
            this.tpg_CameraSetting.Controls.Add(this.numUpDown_Brightness);
            this.tpg_CameraSetting.Controls.Add(this.numUpDown_Exposure);
            this.tpg_CameraSetting.Controls.Add(this.checkBox1);
            this.tpg_CameraSetting.Controls.Add(this.label7);
            this.tpg_CameraSetting.Controls.Add(this.label5);
            this.tpg_CameraSetting.Controls.Add(this.label4);
            this.tpg_CameraSetting.Controls.Add(this.label3);
            this.tpg_CameraSetting.Controls.Add(this.groupBox1);
            this.tpg_CameraSetting.Location = new System.Drawing.Point(4, 22);
            this.tpg_CameraSetting.Name = "tpg_CameraSetting";
            this.tpg_CameraSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_CameraSetting.Size = new System.Drawing.Size(404, 455);
            this.tpg_CameraSetting.TabIndex = 0;
            this.tpg_CameraSetting.Text = "设置";
            this.tpg_CameraSetting.UseVisualStyleBackColor = true;
            // 
            // lbl_SerialNumber
            // 
            this.lbl_SerialNumber.AutoSize = true;
            this.lbl_SerialNumber.Location = new System.Drawing.Point(126, 363);
            this.lbl_SerialNumber.Name = "lbl_SerialNumber";
            this.lbl_SerialNumber.Size = new System.Drawing.Size(71, 12);
            this.lbl_SerialNumber.TabIndex = 22;
            this.lbl_SerialNumber.Text = "00000000000";
            // 
            // numUpDown_TimeLimt
            // 
            this.numUpDown_TimeLimt.Location = new System.Drawing.Point(128, 321);
            this.numUpDown_TimeLimt.Name = "numUpDown_TimeLimt";
            this.numUpDown_TimeLimt.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_TimeLimt.TabIndex = 21;
            this.numUpDown_TimeLimt.ValueChanged += new System.EventHandler(this.numUpDown_TimeLimt_ValueChanged);
            // 
            // numUpDown_Contrast
            // 
            this.numUpDown_Contrast.DecimalPlaces = 2;
            this.numUpDown_Contrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDown_Contrast.Location = new System.Drawing.Point(128, 283);
            this.numUpDown_Contrast.Name = "numUpDown_Contrast";
            this.numUpDown_Contrast.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_Contrast.TabIndex = 20;
            this.numUpDown_Contrast.ValueChanged += new System.EventHandler(this.numUpDown_Contrast_ValueChanged);
            // 
            // numUpDown_Brightness
            // 
            this.numUpDown_Brightness.DecimalPlaces = 2;
            this.numUpDown_Brightness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDown_Brightness.Location = new System.Drawing.Point(128, 248);
            this.numUpDown_Brightness.Name = "numUpDown_Brightness";
            this.numUpDown_Brightness.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_Brightness.TabIndex = 19;
            this.numUpDown_Brightness.ValueChanged += new System.EventHandler(this.numUpDown_Brightness_ValueChanged);
            // 
            // numUpDown_Exposure
            // 
            this.numUpDown_Exposure.DecimalPlaces = 2;
            this.numUpDown_Exposure.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDown_Exposure.Location = new System.Drawing.Point(128, 209);
            this.numUpDown_Exposure.Name = "numUpDown_Exposure";
            this.numUpDown_Exposure.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_Exposure.TabIndex = 18;
            this.numUpDown_Exposure.ValueChanged += new System.EventHandler(this.numUpDown_Exposure_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(29, 322);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "时限";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "序列号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "对比度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "亮度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "曝光：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_InitializeCamera);
            this.groupBox1.Controls.Add(this.cmb_ColorSpace);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_CameraList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 164);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btn_InitializeCamera
            // 
            this.btn_InitializeCamera.Location = new System.Drawing.Point(156, 124);
            this.btn_InitializeCamera.Name = "btn_InitializeCamera";
            this.btn_InitializeCamera.Size = new System.Drawing.Size(116, 34);
            this.btn_InitializeCamera.TabIndex = 4;
            this.btn_InitializeCamera.Text = "初始化相机";
            this.btn_InitializeCamera.UseVisualStyleBackColor = true;
            this.btn_InitializeCamera.Click += new System.EventHandler(this.btn_InitializeCamera_Click);
            // 
            // cmb_ColorSpace
            // 
            this.cmb_ColorSpace.FormattingEnabled = true;
            this.cmb_ColorSpace.Location = new System.Drawing.Point(8, 71);
            this.cmb_ColorSpace.Name = "cmb_ColorSpace";
            this.cmb_ColorSpace.Size = new System.Drawing.Size(209, 20);
            this.cmb_ColorSpace.TabIndex = 3;
            this.cmb_ColorSpace.SelectedIndexChanged += new System.EventHandler(this.cmb_ColorSpace_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "颜色空间：";
            // 
            // cmb_CameraList
            // 
            this.cmb_CameraList.FormattingEnabled = true;
            this.cmb_CameraList.Location = new System.Drawing.Point(6, 32);
            this.cmb_CameraList.Name = "cmb_CameraList";
            this.cmb_CameraList.Size = new System.Drawing.Size(376, 20);
            this.cmb_CameraList.TabIndex = 1;
            this.cmb_CameraList.SelectedIndexChanged += new System.EventHandler(this.cmb_CameraList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片采集设备/图像采集卡：";
            // 
            // tpg_TriggerSetting
            // 
            this.tpg_TriggerSetting.Controls.Add(this.groupBox2);
            this.tpg_TriggerSetting.Location = new System.Drawing.Point(4, 22);
            this.tpg_TriggerSetting.Name = "tpg_TriggerSetting";
            this.tpg_TriggerSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_TriggerSetting.Size = new System.Drawing.Size(428, 455);
            this.tpg_TriggerSetting.TabIndex = 1;
            this.tpg_TriggerSetting.Text = "闪光灯和触发器";
            this.tpg_TriggerSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_TriggerSource);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chk_TriggerEnable);
            this.groupBox2.Location = new System.Drawing.Point(6, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 132);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "触发模式";
            // 
            // cmb_TriggerSource
            // 
            this.cmb_TriggerSource.FormattingEnabled = true;
            this.cmb_TriggerSource.Location = new System.Drawing.Point(98, 72);
            this.cmb_TriggerSource.Name = "cmb_TriggerSource";
            this.cmb_TriggerSource.Size = new System.Drawing.Size(121, 20);
            this.cmb_TriggerSource.TabIndex = 2;
            this.cmb_TriggerSource.SelectedIndexChanged += new System.EventHandler(this.cmb_TriggerSource_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "触发模式：";
            // 
            // chk_TriggerEnable
            // 
            this.chk_TriggerEnable.AutoSize = true;
            this.chk_TriggerEnable.Location = new System.Drawing.Point(27, 37);
            this.chk_TriggerEnable.Name = "chk_TriggerEnable";
            this.chk_TriggerEnable.Size = new System.Drawing.Size(72, 16);
            this.chk_TriggerEnable.TabIndex = 0;
            this.chk_TriggerEnable.Text = "启用触发";
            this.chk_TriggerEnable.UseVisualStyleBackColor = true;
            this.chk_TriggerEnable.CheckedChanged += new System.EventHandler(this.chk_TriggerEnable_CheckedChanged);
            // 
            // tpg_ImageProperty
            // 
            this.tpg_ImageProperty.Controls.Add(this.groupBox3);
            this.tpg_ImageProperty.Location = new System.Drawing.Point(4, 22);
            this.tpg_ImageProperty.Name = "tpg_ImageProperty";
            this.tpg_ImageProperty.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_ImageProperty.Size = new System.Drawing.Size(428, 455);
            this.tpg_ImageProperty.TabIndex = 2;
            this.tpg_ImageProperty.Text = "图像属性";
            this.tpg_ImageProperty.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numUpDown_Height);
            this.groupBox3.Controls.Add(this.numUpDown_Width);
            this.groupBox3.Controls.Add(this.numUpDown_StartY);
            this.groupBox3.Controls.Add(this.numUpDown_StartX);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 202);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "区域";
            // 
            // numUpDown_Height
            // 
            this.numUpDown_Height.Location = new System.Drawing.Point(94, 151);
            this.numUpDown_Height.Name = "numUpDown_Height";
            this.numUpDown_Height.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_Height.TabIndex = 7;
            this.numUpDown_Height.ValueChanged += new System.EventHandler(this.numUpDown_Height_ValueChanged);
            // 
            // numUpDown_Width
            // 
            this.numUpDown_Width.Location = new System.Drawing.Point(94, 111);
            this.numUpDown_Width.Name = "numUpDown_Width";
            this.numUpDown_Width.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_Width.TabIndex = 6;
            this.numUpDown_Width.ValueChanged += new System.EventHandler(this.numUpDown_Width_ValueChanged);
            // 
            // numUpDown_StartY
            // 
            this.numUpDown_StartY.Location = new System.Drawing.Point(94, 71);
            this.numUpDown_StartY.Name = "numUpDown_StartY";
            this.numUpDown_StartY.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_StartY.TabIndex = 5;
            this.numUpDown_StartY.ValueChanged += new System.EventHandler(this.numUpDown_StartY_ValueChanged);
            // 
            // numUpDown_StartX
            // 
            this.numUpDown_StartX.Location = new System.Drawing.Point(94, 31);
            this.numUpDown_StartX.Name = "numUpDown_StartX";
            this.numUpDown_StartX.Size = new System.Drawing.Size(120, 21);
            this.numUpDown_StartX.TabIndex = 4;
            this.numUpDown_StartX.ValueChanged += new System.EventHandler(this.numUpDown_StartX_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "高度:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "宽度:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "原点Y:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "原点X:";
            // 
            // tpg_GigEInfo
            // 
            this.tpg_GigEInfo.Controls.Add(this.groupBox4);
            this.tpg_GigEInfo.Location = new System.Drawing.Point(4, 22);
            this.tpg_GigEInfo.Name = "tpg_GigEInfo";
            this.tpg_GigEInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_GigEInfo.Size = new System.Drawing.Size(428, 455);
            this.tpg_GigEInfo.TabIndex = 3;
            this.tpg_GigEInfo.Text = "GigE";
            this.tpg_GigEInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_AdapterIP);
            this.groupBox4.Controls.Add(this.lbl_CameraIP);
            this.groupBox4.Controls.Add(this.lbl_Firmware);
            this.groupBox4.Controls.Add(this.lbl_Serial);
            this.groupBox4.Controls.Add(this.lbl_CameraMode);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 156);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "照相机信息";
            // 
            // lbl_AdapterIP
            // 
            this.lbl_AdapterIP.AutoSize = true;
            this.lbl_AdapterIP.BackColor = System.Drawing.Color.LightGray;
            this.lbl_AdapterIP.Location = new System.Drawing.Point(118, 127);
            this.lbl_AdapterIP.Name = "lbl_AdapterIP";
            this.lbl_AdapterIP.Size = new System.Drawing.Size(143, 12);
            this.lbl_AdapterIP.TabIndex = 9;
            this.lbl_AdapterIP.Text = "00000000000000000000000";
            // 
            // lbl_CameraIP
            // 
            this.lbl_CameraIP.AutoSize = true;
            this.lbl_CameraIP.BackColor = System.Drawing.Color.LightGray;
            this.lbl_CameraIP.Location = new System.Drawing.Point(118, 103);
            this.lbl_CameraIP.Name = "lbl_CameraIP";
            this.lbl_CameraIP.Size = new System.Drawing.Size(143, 12);
            this.lbl_CameraIP.TabIndex = 8;
            this.lbl_CameraIP.Text = "00000000000000000000000";
            // 
            // lbl_Firmware
            // 
            this.lbl_Firmware.AutoSize = true;
            this.lbl_Firmware.BackColor = System.Drawing.Color.LightGray;
            this.lbl_Firmware.Location = new System.Drawing.Point(118, 79);
            this.lbl_Firmware.Name = "lbl_Firmware";
            this.lbl_Firmware.Size = new System.Drawing.Size(143, 12);
            this.lbl_Firmware.TabIndex = 7;
            this.lbl_Firmware.Text = "00000000000000000000000";
            // 
            // lbl_Serial
            // 
            this.lbl_Serial.AutoSize = true;
            this.lbl_Serial.BackColor = System.Drawing.Color.LightGray;
            this.lbl_Serial.Location = new System.Drawing.Point(118, 55);
            this.lbl_Serial.Name = "lbl_Serial";
            this.lbl_Serial.Size = new System.Drawing.Size(143, 12);
            this.lbl_Serial.TabIndex = 6;
            this.lbl_Serial.Text = "00000000000000000000000";
            // 
            // lbl_CameraMode
            // 
            this.lbl_CameraMode.AutoSize = true;
            this.lbl_CameraMode.BackColor = System.Drawing.Color.LightGray;
            this.lbl_CameraMode.Location = new System.Drawing.Point(118, 31);
            this.lbl_CameraMode.Name = "lbl_CameraMode";
            this.lbl_CameraMode.Size = new System.Drawing.Size(143, 12);
            this.lbl_CameraMode.TabIndex = 5;
            this.lbl_CameraMode.Text = "00000000000000000000000";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 127);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "适配器IP地址：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "照相机IP地址：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "固件：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "序列号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "相机型号：";
            // 
            // tpg_CustomSetting
            // 
            this.tpg_CustomSetting.Location = new System.Drawing.Point(4, 22);
            this.tpg_CustomSetting.Name = "tpg_CustomSetting";
            this.tpg_CustomSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_CustomSetting.Size = new System.Drawing.Size(428, 455);
            this.tpg_CustomSetting.TabIndex = 4;
            this.tpg_CustomSetting.Text = "自定义属性";
            this.tpg_CustomSetting.UseVisualStyleBackColor = true;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(348, 481);
            this.hWindowControl1.TabIndex = 0;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(348, 481);
            // 
            // HalAcqFifoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HalAcqFifoEdit";
            this.Size = new System.Drawing.Size(764, 506);
            this.Load += new System.EventHandler(this.HalAcqFifoEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpg_CameraSetting.ResumeLayout(false);
            this.tpg_CameraSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_TimeLimt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Exposure)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpg_TriggerSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpg_ImageProperty.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_StartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_StartX)).EndInit();
            this.tpg_GigEInfo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Run;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_SaveAll;
        private System.Windows.Forms.ToolStripButton btn_RealDisplay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg_CameraSetting;
        private System.Windows.Forms.Label lbl_SerialNumber;
        private System.Windows.Forms.NumericUpDown numUpDown_TimeLimt;
        private System.Windows.Forms.NumericUpDown numUpDown_Contrast;
        private System.Windows.Forms.NumericUpDown numUpDown_Brightness;
        private System.Windows.Forms.NumericUpDown numUpDown_Exposure;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_InitializeCamera;
        private System.Windows.Forms.ComboBox cmb_ColorSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_CameraList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpg_TriggerSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_TriggerSource;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chk_TriggerEnable;
        private System.Windows.Forms.TabPage tpg_ImageProperty;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numUpDown_Height;
        private System.Windows.Forms.NumericUpDown numUpDown_Width;
        private System.Windows.Forms.NumericUpDown numUpDown_StartY;
        private System.Windows.Forms.NumericUpDown numUpDown_StartX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tpg_GigEInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_AdapterIP;
        private System.Windows.Forms.Label lbl_CameraIP;
        private System.Windows.Forms.Label lbl_Firmware;
        private System.Windows.Forms.Label lbl_Serial;
        private System.Windows.Forms.Label lbl_CameraMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpg_CustomSetting;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.ToolStripButton btn_OpenFile;
    }
}
