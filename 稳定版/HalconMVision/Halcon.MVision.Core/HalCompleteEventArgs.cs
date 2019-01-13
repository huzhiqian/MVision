using System;
using System.Collections.Generic;
using HalconDotNet;


//**********************************************
//文件名：HalCompleteEventArgs
//命名空间：Halcon.MVision.Core
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/1/12 14:00:39
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
   public class HalCompleteEventArgs:EventArgs
    {
        private int _ticket;
        private int _triggerNumber;
        private IHalImage _image;
        #region 构造函数

        public HalCompleteEventArgs(int ticket,int triggerNumber, IHalImage image )
        {
            _image = image;
            _ticket = ticket;
            _triggerNumber = triggerNumber;
        }

        #endregion


        #region 属性
        /// <summary>
        /// 获取相机抓取到的图像
        /// </summary>
        public IHalImage GrabImage
        {
            get { return _image; }
        }

        /// <summary>
        /// 获取相机开始抓帧时TicketCount
        /// </summary>
        public int Ticket
        {
            get { return _ticket; }
        }

        /// <summary>
        /// 获取完成采集的触发器序列号
        /// </summary>
        public int TriggerNumber
        {
            get { return _triggerNumber; }
        }

        #endregion

        #region 公共方法



        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
