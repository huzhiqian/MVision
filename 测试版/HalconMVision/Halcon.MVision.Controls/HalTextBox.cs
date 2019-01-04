//Halcon.MVision.Controls.HalTextBox

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Halcon.MVision;

namespace Halcon.MVision.Controls
{
    [DesignTimeVisible(true)]
    [ToolboxBitmap(typeof(HalTextBox),"Bitmaps.HalTextBox.bmp")]  //用系统样式，也可自定义工具箱显示样式
    [ToolboxItem(true)]//在vs工具箱中显示
    public class HalTextBox:TextBox
    {
        private string defaultValue = string.Empty;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HalTextBox():base() {
           
        }

        public HalTextBox(string defaultVal) : base()
        {
            defaultValue = defaultVal;
            this.Text = defaultValue;

        }

        #region 属性

        public string DefaultString
        {
            get { return defaultValue; }
            set
            {
                if (defaultValue != value)
                {
                    defaultValue = value;
                    this.Text = value;
                }
            }
        }

        #endregion

        #region 公共方法


        #endregion

        #region 私有方法

        protected override void OnEnter(EventArgs e)
        {
           
            base.OnEnter(e);
            base.BackColor = Color.PaleGreen;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            base.BackColor = Color.White;
        }
        #endregion

        #region 事件


        #endregion
    }
}
