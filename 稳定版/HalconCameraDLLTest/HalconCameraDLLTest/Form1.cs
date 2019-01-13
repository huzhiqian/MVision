using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halcon.MVision;


namespace HalconCameraDLLTest
{
    public partial class Form1 : Form
    {
        private HalAcqFifoTool halAcqFifo;

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
            try
            {
                string fileName = @"C:\Users\Administrator\Desktop\AcqTest.hal";
                halAcqFifo = Halcon.MVision.HalSerializer.LoadObjectFormFile(fileName) as HalAcqFifoTool;
            }
            finally { }

        }

       


        #endregion

        private void btn_OpenCamerasetting_Click(object sender, EventArgs e)
        {
            AcqForm fm = new AcqForm(halAcqFifo);
            fm.ShowDialog();
        }
    }
}
