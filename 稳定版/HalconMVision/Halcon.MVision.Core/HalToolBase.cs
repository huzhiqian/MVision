//Halcon.MVision.HalToolBase

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Halcon.MVision
{
    /// <summary>
    /// 工具对象的抽象基类
    /// </summary>
    [Serializable]
    public abstract class HalToolBase : ISerializable
    {
        public HalToolBase()
        {

        }

        HalToolBase(SerializationInfo info, StreamingContext context)
        {

        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
          
        }
    }
}
