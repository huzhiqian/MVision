// Halcon.MVision.Implementation.Internal.HalAcqState
using System;
using HalconDotNet;

//**********************************************
//文件名：HalAcqState
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：相机状态类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/14 14:42:06
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    public class HalAcqState : IHalAcqState
    {
        private HTuple __acqHandle;
        private bool isCameraLinked = false;
        private string camersStatus = "unavailable";

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HalAcqState()
        {

        }

        public HalAcqState(HTuple hAcq)
        {
            __acqHandle = hAcq;
            if (__acqHandle.TupleNotEqual(null))
                GetCameraStatus();
        }


        #endregion

        #region 属性

        HTuple IHalAcqState.AcqHandle
        {
            set
            {
                if (value.TupleNotEqual(__acqHandle) && value.TupleNotEqual(null))
                {
                    __acqHandle = value;
                    GetCameraStatus();
                }
            }
        }

        /// <summary>
        /// 获取相机是否连接
        /// </summary>
        bool IHalAcqState.IsCameraLinked
        {
            get { return isCameraLinked; }
        }

        /// <summary>
        /// 获取相机状态
        /// </summary>
        string IHalAcqState.CameraStatus
        {
            get { return camersStatus; }
        }


        #endregion

        #region 公共方法



        #endregion

        #region 私有方法

        private void GetCameraStatus()
        {
            HTuple boardInfo, boardInfoValue;
            HOperatorSet.InfoFramegrabber(__acqHandle, new HTuple("info_boards"), out boardInfo, out boardInfoValue);

            string[] items = new string[] { };
            //截断字符串
            items = boardInfoValue.S.Split('|');
            camersStatus = GetBoardInfoItem(items, "status");

        }

        private string GetBoardInfoItem(string[] items, string targetStr)
        {
            string[] temp;
            foreach (string str in items)
            {
                string tempstr = str.Trim();    //去掉前导空格和后导空格
                temp = tempstr.Split(':');
                if (temp[0] == targetStr)
                {
                    return temp[1];
                }
            }
            return string.Empty;
        }

        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
