//Halcon.MVision.HalSerializationOptionsConstants
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：HalSerializationOptionsConstants
//命名空间：Halcon.MVision.HalSerializationOptionsConstants
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/4/25 15:36:28
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    /// <summary>
    /// 该枚举包含被CCSerializationOptionsAttribute将序列化与特定字段关联起来的常量
    /// </summary>
    public enum HalSerializationOptionsConstants
    { 
        /// <summary>
        /// 最小序列化属性集，不包含Input/Output image以及Result
        /// </summary>
        Minimum=0,
        /// <summary>
        /// 序列化Result Object
        /// </summary>
        Result=1,
        /// <summary>
        /// 序列化InputImage
        /// </summary>
        InputImage=2,
        /// <summary>
        /// 序列化OutputImage
        /// </summary>
        OutputImage=4,
        /// <summary>
        /// 不序列化绑定数据
        /// </summary>
        ExcludeDataBingdings=8,
        /// <summary>
        /// 序列化所有类型的属性
        /// </summary>
        All=16
    }
}
