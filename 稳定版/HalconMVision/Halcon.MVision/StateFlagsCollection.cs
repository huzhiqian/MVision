//Halcon.Mvision.StateFlagsCollection
using System;
using System.Collections;
using System.Reflection;

//**********************************************
//文件名：StateFlagsCollection
//命名空间：Halcon.MVision
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/8 15:27:58
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    public class StateFlagsCollection : ICollection, IEnumerable
    {
        private Hashtable _sf;

        #region 构造函数
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="objType"></param>
        public StateFlagsCollection(Type objType)
        {
            this._sf = new Hashtable(23);
            FieldInfo[] fields = objType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            FieldInfo[] array = fields;
            foreach (FieldInfo fieldInfo in array)
            {
                if (fieldInfo.Name.StartsWith("Sf") && fieldInfo.FieldType == typeof(long))
                {
                    this._sf.Add(fieldInfo.Name.Substring(2), (long)fieldInfo.GetValue(null));
                }
            }
        }

        #endregion


        #region 属性
        //声明索引器
        public long this[string statename]
        {
            get
            {
                object obj = this._sf[statename];
                if (obj != null)
                {
                    return (long)obj;
                }
                return 0;
            }
        }


        public string[] Names
        {
            get
            {
                int count = this._sf.Keys.Count;
                int num = 0;
                string[] array = new string[count];
                foreach (string key in this._sf.Keys)
                {
                    array[num++] = key;
                }
                return array;
            }
        }

        public long[] Flags
        {
            get
            {
                int count = this._sf.Values.Count;
                int num = 0;
                long[] array = new long[count];
                foreach (long value in this._sf.Values)
                {
                    array[num++] = value;
                }
                return array;
            }
        }


        public bool IsSynchronized
        {
            get
            {
                return this._sf.IsSynchronized;
            }
        }

        public int Count
        {
            get
            {
                return this._sf.Count;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this._sf.SyncRoot;
            }
        }


        #endregion

        #region 公共方法
        public void CopyTo(Array array, int index)
        {
            this._sf.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return this._sf.GetEnumerator();
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
