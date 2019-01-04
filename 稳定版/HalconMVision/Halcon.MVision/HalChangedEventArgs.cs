//Halcon.MVision.HalChangedEventArgs
using System;
using Halcon.MVision;
using System.Reflection;
using System.Text;

//**********************************************
//文件名：HalChangedEventArgs
//命名空间：Halcon.MVision
//CLR版本：4.0.30319.42000
//内容：
//功能：改变事件参数类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/8 16:17:07
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    public class HalChangedEventArgs:EventArgs
    {
        public readonly long StateFlags;
        #region 构造函数

        public HalChangedEventArgs(long stateFlags)
        {
            this.StateFlags = stateFlags;
        }

        #endregion


        #region 属性



        #endregion

        #region 公共方法
        /// <summary>
        /// 获取状态名
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public string GetStateFlagNames(object sender)
        {
            return HalChangedEventArgs.GetStateFlagNames(sender.GetType(),this.StateFlags);
        }

        public static string GetStateFlagNames(Type senderType, long stateFlags)
        {
            StringBuilder stringBuilder = new StringBuilder();
            FieldInfo[] fields = senderType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            bool flag = false;
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name.StartsWith("Sf") && fieldInfo.FieldType == typeof(long) && (stateFlags & (long)fieldInfo.GetValue(null)) != 0)
                {
                    if (flag)
                    {
                        stringBuilder.Append("|");
                    }
                    stringBuilder.Append(fieldInfo.Name);
                    flag = true;
                }
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
