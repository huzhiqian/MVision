using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Halcon.MVision;
using HalconDotNet;


namespace Halcon.MVision.Controls
{
    public partial class HalAcqFifoEdit : UserControl
    {
        private HalAcqFifoTool subject;
        private string interface_type = "GigEVision2";
        private bool cameraInitialized = false;
        public HalAcqFifoEdit()
        {
            InitializeComponent();
            if (subject == null)
            {
                HiddenControls();   //隐藏控件
                cmb_ColorSpace.Enabled = false;
                btn_InitializeCamera.Enabled = false;
                SetMenuEnable(false);
            }

        }
        private void HalAcqFifoEdit_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
                //获取相机列表
                AddCameraInfoToCtrl();
        }

        #region 属性

        public HalAcqFifoTool Subject
        {
            get { return subject; }
            set
            {
                if (value != subject && value != null)
                {
                    subject = value;
                    cmb_CameraList.Text = interface_type + subject.GigEAccess.DeviceName;
                    cmb_ColorSpace.Text = subject.OpenInfo.ColorSpace.S;
                    SetSubject();
               
                }
            }
        }

        #endregion


        #region 公共方法


        #endregion

        #region 私有方法

        private void SetMenuEnable(bool en)
        {
            foreach (var item in toolStrip1.Items)
            {
                if (!((ToolStripButton)item).Text.Equals("打开"))
                    ((ToolStripButton)item).Enabled = en;
            }
        }

        private void HiddenControls()
        {
            tpg_TriggerSetting.Parent = null;
            tpg_ImageProperty.Parent = null;
            tpg_GigEInfo.Parent = null;
            tpg_CustomSetting.Parent = null;
            foreach (var item in tpg_CameraSetting.Controls)
            {
                if (item.GetType() != typeof(GroupBox))
                    ((Control)item).Visible = false;
            }
        }

        private void ShowControls()
        {
            tpg_TriggerSetting.Parent = tabControl1;
            tpg_ImageProperty.Parent = tabControl1;
            tpg_GigEInfo.Parent = tabControl1;
            tpg_CustomSetting.Parent = tabControl1;
            foreach (var item in tpg_CameraSetting.Controls)
            {
                if (item.GetType() != typeof(GroupBox))
                    ((Control)item).Visible = true;
            }
        }

        /// <summary>
        /// 获取当前系统连接上的相机
        /// </summary>
        /// <returns>返回系统上连接的相机</returns>
        private List<string> GetSysCameras()
        {
            List<string> camList = new List<string>();
            HTuple hv_infomation;
            HTuple hv_InfoList;

            //获取GigE接口的相机信息
            HOperatorSet.InfoFramegrabber(new HTuple("GigEVision2"), new HTuple("info_boards"), out hv_infomation, out hv_InfoList);
            if (hv_InfoList.SArr.Count() == 0)
                return camList;
            else
            {
                foreach (var item in hv_InfoList.SArr)
                {
                    string result = GetCameraBoardInfo(item, "device");
                    if (result != string.Empty)
                        camList.Add(result);
                }
                return camList;
            }
        }

        /// <summary>
        /// 获取相机板卡信息
        /// </summary>
        /// <param name="infoString">信息字符串</param>
        /// <param name="infoName">需要获取的信息名</param>
        /// <returns></returns>
        private string GetCameraBoardInfo(string infoString, string infoName)
        {
            string[] infoArray = infoString.Split('|');

            foreach (var item in infoArray)
            {
                string indexInfo = item.Trim();
                string[] _val = new string[] { };
                _val = indexInfo.Split(':');
                if (_val[0] == infoName)
                {
                    return _val[1];
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 向ComboBox中添加相机信息
        /// </summary>
        private void AddCameraInfoToCtrl()
        {
            List<string> camList = GetSysCameras();
            foreach (var item in camList)
            {
                string name = "GigEVision2:" + item;
                cmb_CameraList.Items.Add(name);
            }
        }

        private void AddInfoToColorSpaceCtrl()
        {
            HTuple hv_infomation, hv_colorspace;
            HOperatorSet.InfoFramegrabber(new HTuple(interface_type), new HTuple("color_space"), out hv_infomation, out hv_colorspace);
            foreach (var item in hv_colorspace.SArr)
            {
                cmb_ColorSpace.Items.Add(item);
            }
            cmb_ColorSpace.Text = "default";
        }
        /// <summary>
        /// 相机选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_CameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cameraName = (cmb_CameraList.Items[cmb_CameraList.SelectedIndex] as string).Split(':')[1];
            cmb_ColorSpace.Items.Clear();
            HTuple hv_Infomation, hv_BoardInfo;
            HOperatorSet.InfoFramegrabber(new HTuple(interface_type), new HTuple("info_boards"), out hv_Infomation, out hv_BoardInfo);
            foreach (var item in hv_BoardInfo.SArr)
            {
                if (cameraName.Equals(GetCameraBoardInfo(item, "device")))
                {
                    //判断当前相机状态是否是avaliable
                    string status = GetCameraBoardInfo(item, "status");
                    if (status.Equals("available"))
                    {
                        cmb_ColorSpace.Enabled = true;
                        //向cmb_ColorSpace添加选项
                        AddInfoToColorSpaceCtrl();
                    }
                    else
                    {
                        if (!status.Equals("busy"))
                            MessageBox.Show($"The camera：{cameraName} is unavailable");
                    }
                    return;
                }
            }
            cmb_ColorSpace.Enabled = false;
            btn_InitializeCamera.Enabled = false;

        }

        private void cmb_ColorSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ColorSpace.SelectedIndex != -1)
                btn_InitializeCamera.Enabled = true;
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InitializeCamera_Click(object sender, EventArgs e)
        {
            string device = (cmb_CameraList.Items[cmb_CameraList.SelectedIndex] as string).Split(':')[1];
            string colorspace = cmb_ColorSpace.Items[cmb_ColorSpace.SelectedIndex] as string;
            try
            {
                subject = new HalAcqFifoTool(new HTuple(device), colorspace);
                subject.AcqStateInfo.CameraLinkStateChanged += CameraLinkStateChanged;

                subject.Operator.OwnedExposureParam.Changed += ExposureChanged;
                subject.Operator.OwnedBrightnessParam.Changed += BrightnessChanged;
                subject.Operator.OwnedContrastParam.Changed += ContrastChanged;
                subject.Operator.OwnedTriggerParam.Changed += TriggerChnaged;
                subject.Operator.OwnedImagePropertyParam.Changed += ImagePropertyChanged;
                subject.Complete += GrabImageComplete;

                CameraLinkStateChanged(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void CameraLinkStateChanged(bool state)
        {
            cmb_ColorSpace.Enabled = !state;
            btn_InitializeCamera.Enabled = !state;
            SetMenuEnable(state);
            if (state)
            {
                ShowControls();//显示控件
                SetCtrlValue();
            }
            else
            {
                HiddenControls();
            }

            cameraInitialized = state;
        }

        /// <summary>
        /// 给控件赋值
        /// </summary>
        private void SetCtrlValue()
        {
            SetExsposureParam();
            SetBrightnessParam();
            SetContrastParam();
            SetTimeLimetParam();
            SetTriggerParam();
            SetImagePropertyParam();
            SetGigEInfo();
            if (subject.OutputImage != null)
            {
                DisplayImage(subject.OutputImage);
            }
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        private void SetExsposureParam()
        {
            numUpDown_Exposure.Maximum = (decimal)subject.Operator.OwnedExposureParam.MaxExposure;
            numUpDown_Exposure.Minimum = (decimal)subject.Operator.OwnedExposureParam.MinExposure;
            numUpDown_Exposure.Value = (decimal)subject.Operator.OwnedExposureParam.Exposure;
        }
        /// <summary>
        /// 设置亮度参数
        /// </summary>
        private void SetBrightnessParam()
        {
            if (subject.Operator.OwnedBrightnessParam.IsExist)
            {
                numUpDown_Brightness.Maximum = (decimal)subject.Operator.OwnedBrightnessParam.BrightnessMax.D;
                numUpDown_Brightness.Minimum = (decimal)subject.Operator.OwnedBrightnessParam.BrightnessMin.D;
                numUpDown_Brightness.Value = (decimal)subject.Operator.OwnedBrightnessParam.Brightness.D;

            }
        }
        /// <summary>
        /// 设置对比度参数
        /// </summary>
        private void SetContrastParam()
        {
            if (subject.Operator.OwnedContrastParam.IsExist)
            {
                numUpDown_Contrast.Maximum = (decimal)subject.Operator.OwnedContrastParam.ContrastMax.D;
                numUpDown_Contrast.Minimum = (decimal)subject.Operator.OwnedContrastParam.ContrastMin.D;
                numUpDown_Contrast.Value = (decimal)subject.Operator.OwnedContrastParam.Contrast.D;

            }
        }
        /// <summary>
        /// 设置时限
        /// </summary>
        private void SetTimeLimetParam()
        {

        }
        /// <summary>
        /// 设置触发参数
        /// </summary>
        private void SetTriggerParam()
        {
            chk_TriggerEnable.Checked = subject.Operator.OwnedTriggerParam.TriggeModel;
            foreach (var item in subject.Operator.OwnedTriggerParam.TriggerSource.SArr)
            {
                cmb_TriggerSource.Items.Add(item);
            }
            cmb_TriggerSource.Text = subject.Operator.OwnedTriggerParam.CurrentTriggerSource.S;

        }
        /// <summary>
        /// 设置图像属性
        /// </summary>
        private void SetImagePropertyParam()
        {
            numUpDown_StartX.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetX_Max.I;
            numUpDown_StartX.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetX_Min.I;
            numUpDown_StartX.Value = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetX.I;

            numUpDown_StartY.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetY_Max.I;
            numUpDown_StartY.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetY_Min.I;
            numUpDown_StartY.Value = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetY.I;

            numUpDown_Width.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.Width_Max.I;
            numUpDown_Width.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.Width_Min.I;
            numUpDown_Width.Value = (decimal)subject.Operator.OwnedImagePropertyParam.Width.I;

            numUpDown_Height.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.Height_Max.I;
            numUpDown_Height.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.Height_Min.I;
            numUpDown_Height.Value = (decimal)subject.Operator.OwnedImagePropertyParam.Height.I;
        }
        /// <summary>
        /// 设置GigE信息
        /// </summary>
        private void SetGigEInfo()
        {
            lbl_Serial.Text = subject.GigEAccess.CameraSerialNumber;
            lbl_SerialNumber.Text = subject.GigEAccess.CameraSerialNumber;
            lbl_CameraMode.Text = subject.GigEAccess.DeviceModelName;
            lbl_Firmware.Text = subject.GigEAccess.DeviceFirmwareVersion;
            lbl_CameraIP.Text = subject.GigEAccess.CurrentIPAddress;
            lbl_AdapterIP.Text = subject.GigEAccess.HostIPAddress;
        }


        private void numUpDown_Exposure_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedExposureParam.Exposure = (double)numUpDown_Exposure.Value;
        }

        private void numUpDown_Brightness_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedBrightnessParam.Brightness = (double)numUpDown_Brightness.Value;
        }

        private void numUpDown_Contrast_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedContrastParam.Contrast = (double)numUpDown_Contrast.Value;
        }

        private void numUpDown_TimeLimt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chk_TriggerEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedTriggerParam.TriggeModel = chk_TriggerEnable.Checked;
        }

        private void cmb_TriggerSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedTriggerParam.CurrentTriggerSource = cmb_TriggerSource.Items[cmb_TriggerSource.SelectedIndex] as string;
        }

        private void numUpDown_StartX_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedImagePropertyParam.OffsetX = (int)numUpDown_StartX.Value;
        }


        private void numUpDown_StartY_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedImagePropertyParam.OffsetY = (int)numUpDown_StartY.Value;
        }

        private void numUpDown_Width_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedImagePropertyParam.Width = (int)numUpDown_Width.Value;
        }

        private void numUpDown_Height_ValueChanged(object sender, EventArgs e)
        {
            if (cameraInitialized)
                subject.Operator.OwnedImagePropertyParam.Height = (int)numUpDown_Height.Value;
        }

        #region ValueChanged

        private void ExposureChanged(object sender, HalChangedEventArgs e)
        {
            SetExsposureParam();
        }

        private void BrightnessChanged(object sender, HalChangedEventArgs e)
        {
            SetBrightnessParam();
        }

        private void ContrastChanged(object sender, HalChangedEventArgs e)
        {
            SetContrastParam();
        }

        private void TriggerChnaged(object sender, HalChangedEventArgs e)
        {
            chk_TriggerEnable.Checked = subject.Operator.OwnedTriggerParam.TriggeModel;
            cmb_TriggerSource.Text = subject.Operator.OwnedTriggerParam.CurrentTriggerSource;
        }

        private void ImagePropertyChanged(object sender, HalChangedEventArgs e)
        {
            numUpDown_StartX.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetX_Max;
            numUpDown_StartX.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetX_Min;
            numUpDown_StartX.Value = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetX;

            numUpDown_StartY.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetY_Max;
            numUpDown_StartY.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetY_Min;
            numUpDown_StartY.Value = (decimal)subject.Operator.OwnedImagePropertyParam.OffsetY;

            numUpDown_Width.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.Width_Max;
            numUpDown_Width.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.Width_Min;
            numUpDown_Width.Value = (decimal)subject.Operator.OwnedImagePropertyParam.Width;

            numUpDown_Height.Maximum = (decimal)subject.Operator.OwnedImagePropertyParam.Height_Max;
            numUpDown_Height.Minimum = (decimal)subject.Operator.OwnedImagePropertyParam.Height_Min;
            numUpDown_Height.Value = (decimal)subject.Operator.OwnedImagePropertyParam.Height;
        }



        #endregion

 
        /// <summary>
        /// 显示图像
        /// </summary>
        private void DisplayImage(IHalImage image)
        {
                if (hWindowControl1.InvokeRequired)
                {
                    Action<IHalImage> a = new Action<IHalImage>(DisplayImage);
                    hWindowControl1.Invoke(a);
                    return;
                }
                else
                {
                    HSystem.SetSystem(new HTuple("flush_graphic"),new HTuple("false"));
                    hWindowControl1.HalconWindow.ClearWindow();
                    SetImagePart(0,0, image.Height,image.Width);
                    hWindowControl1.HalconWindow.DispObj(image.SourceImage);
                    HSystem.SetSystem(new HTuple("flush_graphic"), new HTuple("true"));
                  
                }
        }

        /// <summary>
        /// 根据提供的图像的信息调整图像显示（左上角和右下角坐标）
        /// </summary>
        /// <param name="r1">左上角Y坐标</param>
        /// <param name="c1">左上角x坐标</param>
        /// <param name="r2">右下角Y坐标</param>
        /// <param name="c2">右下角x坐标</param>
        private void SetImagePart(int r1, int c1, int r2, int c2)
        {
            System.Drawing.Rectangle rect = hWindowControl1.ImagePart;
            rect.X = c1;
            rect.Y = r1;
            rect.Height = r2;
            rect.Width = c2;
            hWindowControl1.ImagePart = rect;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Repaint();
        }

        /// <summary>
        /// 将ACQ对象序列化到本地计算机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveSubjectToFile();
        }

        protected virtual void SaveSubjectToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MVision文件|*.hal";
            saveFileDialog.Title = "保存MVision文件";
            //saveFileDialog.OverwritePrompt = true;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Halcon.MVision.HalSerializer.SaveObjectToFile(subject, saveFileDialog.FileName);
                    MessageBox.Show("保存完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存出错！\n" + ex.ToString());
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    saveFileDialog.Dispose();
                    saveFileDialog = null;
                }
            }
        }

        private void SetSubject()
        {
            if (subject.AcqStateInfo.IsCameraLinked)
            {

                subject.AcqStateInfo.CameraLinkStateChanged += CameraLinkStateChanged;

                subject.Operator.OwnedExposureParam.Changed += ExposureChanged;
                subject.Operator.OwnedBrightnessParam.Changed += BrightnessChanged;
                subject.Operator.OwnedContrastParam.Changed += ContrastChanged;
                subject.Operator.OwnedTriggerParam.Changed += TriggerChnaged;
                subject.Operator.OwnedImagePropertyParam.Changed += ImagePropertyChanged;
                subject.Complete += GrabImageComplete;
                CameraLinkStateChanged(true);

            }
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            if (subject != null)
            {
                if (MessageBox.Show("是否保存当前相机设置？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    SaveSubjectToFile(); 
                }
                //关闭相机
                if (subject.AcqStateInfo.IsCameraLinked)
                    subject.CloseCamera();
            }

            //打开新的文件
            OpenSubjectFile();
        }

        protected virtual void OpenSubjectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "MVision文件|*.hal";
            openFileDialog.Title = "打开MVision文件";
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = null;
            openFileDialog.AutoUpgradeEnabled = true;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.Windows.Forms.Application.DoEvents();
                    if (openFileDialog.SafeFileNames.Count() > 0)
                    {
                        if (openFileDialog.SafeFileNames[0].EndsWith(".hal") ||
                            openFileDialog.SafeFileNames[0].EndsWith(".HAL"))
                        {
                            string fileName =openFileDialog.FileNames[0];
                          var  acqObj = HalSerializer.LoadObjectFormFile(fileName) as HalAcqFifoTool;
                            Subject = acqObj;
                        }
                        else
                        {
                            MessageBox.Show("选择的文件不是.hal格式的！","提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("未选择文件！", "提示");
                    }
                }
            }
            finally
            {
                openFileDialog.Dispose();
                openFileDialog = null;
            }
          
        }


        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (subject != null)
                subject.Run();
        }

        private void GrabImageComplete(object sender,HalCompleteEventArgs e)
        {
            DisplayImage(e.GrabImage);
        }

        protected virtual void Repaint()
        {
            if (subject != null && subject.OutputImage != null)
            {
                DisplayImage(subject.OutputImage);
            }
        }

        private void btn_RealDisplay_Click(object sender, EventArgs e)
        {
            if (subject != null)
            {
                if (subject.IsCameraLiveDisplay)
                {
                    subject.StopLiveDisplay();
                }
                else
                {
                    subject.StartLiveDisplay();
                }
            }
        }

        #endregion

        #region 委托


        #endregion

        #region 事件


        #endregion

    }
}
