namespace HalconCameraDLLTest
{
    partial class AcqForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.halAcqFifoEdit1 = new Halcon.MVision.Controls.HalAcqFifoEdit();
            this.SuspendLayout();
            // 
            // halAcqFifoEdit1
            // 
            this.halAcqFifoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halAcqFifoEdit1.Location = new System.Drawing.Point(0, 0);
            this.halAcqFifoEdit1.Name = "halAcqFifoEdit1";
            this.halAcqFifoEdit1.Size = new System.Drawing.Size(793, 592);
            this.halAcqFifoEdit1.Subject = null;
            this.halAcqFifoEdit1.TabIndex = 0;
            // 
            // AcqForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 592);
            this.Controls.Add(this.halAcqFifoEdit1);
            this.Name = "AcqForm";
            this.Text = "AcqForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AcqForm_FormClosed);
            this.Load += new System.EventHandler(this.AcqForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Halcon.MVision.Controls.HalAcqFifoEdit halAcqFifoEdit1;
    }
}