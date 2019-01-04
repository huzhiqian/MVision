using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalconCameraDLLTest
{
    public partial class Form1 : Form
    {
        private HalAcquisitionTool.HalAcqFifoTool myHalAcqFifoTool; //相机控制对象

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 软件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitialSoftware();
        }

        /// <summary>
        /// 软件关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        #region 初始化

        private void InitialSoftware()
        {

        }
            
        
            

        #endregion
    }
}
