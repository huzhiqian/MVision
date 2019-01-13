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
    public partial class AcqForm : Form
    {
        private HalAcqFifoTool subject;
        public AcqForm(HalAcqFifoTool obj)
        {
            InitializeComponent();
            subject = obj;
        }
        private void AcqForm_Load(object sender, EventArgs e)
        {
            if (subject != null)
            {
                halAcqFifoEdit1.Subject = subject;
            }
        }
        private void AcqForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (halAcqFifoEdit1.Subject != null)
                halAcqFifoEdit1.Subject.CloseCamera();
        }


    }
}
