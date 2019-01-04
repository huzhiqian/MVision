namespace HalconCameraDLLTest
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_OpenCamera = new System.Windows.Forms.Button();
            this.btn_GrabImage = new System.Windows.Forms.Button();
            this.btn_RealDisplay = new System.Windows.Forms.Button();
            this.displayToolMenu1 = new HalDisplayImagePanel.DisplayToolMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.displayImagePanel1 = new HalDisplayImagePanel.DisplayImagePanel();
            this.btn_OpenCamerasetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.displayToolMenu1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_OpenCamerasetting);
            this.splitContainer1.Panel2.Controls.Add(this.btn_RealDisplay);
            this.splitContainer1.Panel2.Controls.Add(this.btn_GrabImage);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OpenCamera);
            this.splitContainer1.Size = new System.Drawing.Size(1190, 625);
            this.splitContainer1.SplitterDistance = 820;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_OpenCamera
            // 
            this.btn_OpenCamera.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenCamera.Location = new System.Drawing.Point(67, 92);
            this.btn_OpenCamera.Name = "btn_OpenCamera";
            this.btn_OpenCamera.Size = new System.Drawing.Size(236, 45);
            this.btn_OpenCamera.TabIndex = 0;
            this.btn_OpenCamera.Text = "打开相机";
            this.btn_OpenCamera.UseVisualStyleBackColor = true;
            // 
            // btn_GrabImage
            // 
            this.btn_GrabImage.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GrabImage.Location = new System.Drawing.Point(22, 181);
            this.btn_GrabImage.Name = "btn_GrabImage";
            this.btn_GrabImage.Size = new System.Drawing.Size(135, 45);
            this.btn_GrabImage.TabIndex = 1;
            this.btn_GrabImage.Text = "手动取像";
            this.btn_GrabImage.UseVisualStyleBackColor = true;
            // 
            // btn_RealDisplay
            // 
            this.btn_RealDisplay.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RealDisplay.Location = new System.Drawing.Point(194, 181);
            this.btn_RealDisplay.Name = "btn_RealDisplay";
            this.btn_RealDisplay.Size = new System.Drawing.Size(135, 45);
            this.btn_RealDisplay.TabIndex = 2;
            this.btn_RealDisplay.Text = "实时显示";
            this.btn_RealDisplay.UseVisualStyleBackColor = true;
            // 
            // displayToolMenu1
            // 
            this.displayToolMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.displayToolMenu1.Location = new System.Drawing.Point(0, 0);
            this.displayToolMenu1.Name = "displayToolMenu1";
            this.displayToolMenu1.Size = new System.Drawing.Size(820, 36);
            this.displayToolMenu1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.displayImagePanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 589);
            this.panel1.TabIndex = 1;
            // 
            // displayImagePanel1
            // 
            this.displayImagePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayImagePanel1.hImage = null;
            this.displayImagePanel1.HO_Image = null;
            this.displayImagePanel1.Image = null;
            this.displayImagePanel1.Location = new System.Drawing.Point(0, 0);
            this.displayImagePanel1.Name = "displayImagePanel1";
            this.displayImagePanel1.Size = new System.Drawing.Size(820, 589);
            this.displayImagePanel1.TabIndex = 0;
            // 
            // btn_OpenCamerasetting
            // 
            this.btn_OpenCamerasetting.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenCamerasetting.Location = new System.Drawing.Point(67, 25);
            this.btn_OpenCamerasetting.Name = "btn_OpenCamerasetting";
            this.btn_OpenCamerasetting.Size = new System.Drawing.Size(236, 45);
            this.btn_OpenCamerasetting.TabIndex = 3;
            this.btn_OpenCamerasetting.Text = "打开相机设置";
            this.btn_OpenCamerasetting.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 625);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_RealDisplay;
        private System.Windows.Forms.Button btn_GrabImage;
        private System.Windows.Forms.Button btn_OpenCamera;
        private System.Windows.Forms.Panel panel1;
        private HalDisplayImagePanel.DisplayImagePanel displayImagePanel1;
        private HalDisplayImagePanel.DisplayToolMenu displayToolMenu1;
        private System.Windows.Forms.Button btn_OpenCamerasetting;
    }
}

