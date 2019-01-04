namespace Test
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
            this.cogAcqFifoCtlV21 = new Cognex.VisionPro.CogAcqFifoCtlV2();
            this.halNumberBox1 = new Halcon.MVision.Controls.HalNumberBox();
            this.cogAcqFifoEditV21 = new Cognex.VisionPro.CogAcqFifoEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.halNumberBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogAcqFifoEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogAcqFifoCtlV21
            // 
            this.cogAcqFifoCtlV21.Location = new System.Drawing.Point(42, 154);
            this.cogAcqFifoCtlV21.Name = "cogAcqFifoCtlV21";
            this.cogAcqFifoCtlV21.Size = new System.Drawing.Size(556, 360);
            this.cogAcqFifoCtlV21.Subject = null;
            this.cogAcqFifoCtlV21.TabIndex = 3;
            // 
            // halNumberBox1
            // 
            this.halNumberBox1.Electric = false;
            this.halNumberBox1.Location = new System.Drawing.Point(271, 96);
            this.halNumberBox1.Name = "halNumberBox1";
            this.halNumberBox1.Path = null;
            this.halNumberBox1.ShowToolTips = false;
            this.halNumberBox1.Size = new System.Drawing.Size(120, 21);
            this.halNumberBox1.Subject = null;
            this.halNumberBox1.TabIndex = 2;
            this.halNumberBox1.ToolTipText = null;
            this.halNumberBox1.UseAngleUnit = false;
            // 
            // cogAcqFifoEditV21
            // 
            this.cogAcqFifoEditV21.Location = new System.Drawing.Point(691, 123);
            this.cogAcqFifoEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogAcqFifoEditV21.Name = "cogAcqFifoEditV21";
            this.cogAcqFifoEditV21.Size = new System.Drawing.Size(835, 445);
            this.cogAcqFifoEditV21.SuspendElectricRuns = false;
            this.cogAcqFifoEditV21.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 656);
            this.Controls.Add(this.cogAcqFifoEditV21);
            this.Controls.Add(this.cogAcqFifoCtlV21);
            this.Controls.Add(this.halNumberBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.halNumberBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogAcqFifoEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Halcon.MVision.Controls.HalNumberBox halNumberBox1;
        private Cognex.VisionPro.CogAcqFifoCtlV2 cogAcqFifoCtlV21;
        private Cognex.VisionPro.CogAcqFifoEditV2 cogAcqFifoEditV21;
    }
}

