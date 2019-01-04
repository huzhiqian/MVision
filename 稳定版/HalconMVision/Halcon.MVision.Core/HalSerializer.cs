//Halcon.MVision.HalSerializer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Soap;


//**********************************************
//文件名：HalSerializer
//命名空间：Halcon.MVision.HalSerializer
//CLR版本：4.0.30319.42000
//内容：
//功能：该类为序列化对象提供了方便的功能。它允许您将对象保存到文件或流中或从文件流中加载对象。
//     您应该使用这些函数来序列化所有封装halcon的对象。
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/4/25 11:00:57
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    public class HalSerializer
    {

        #region 序列化保存

        /// <summary>
        /// 将对象序列化到指定的文件中
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <param name="formaterType"></param>
        public static void SaveObjectToPath(object obj, string path, Type formaterType)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("需要序列化的对象到指定的文件");
            }
            FileStream fileStream = File.Create(path);
            try
            {
                SaveObjectToStream(obj, fileStream, formaterType, StreamingContextStates.File | StreamingContextStates.Persistence);
            }
            finally
            {
                ((IDisposable)fileStream).Dispose();
            }
        }


        /// <summary>
        /// 将对象保存到文件中
        /// </summary>
        /// <param name="obj">需要保存的对象</param>
        /// <param name="path">保存路径</param>
        public static void SaveObjectToFile(object obj, string path)
        {
            Type typeformateHandle = typeof(BinaryFormatter);//获取二进制序列化器类型句柄
            SaveObjectToPath(obj, path, typeformateHandle);

        }

        /// <summary>
        /// 通过流保存对象
        /// </summary>
        /// <param name="obj">要保存的对象</param>
        /// <param name="stream">文件流</param>
        ///  /// <param name="formaterType">指定格式化器</param>
        /// <param name="contextState">流上下文状态</param>
        public static void SaveObjectToStream(object obj, Stream stream, Type formaterType, StreamingContextStates contextState)
        {
            IFormatter formatter = (IFormatter)Activator.CreateInstance(formaterType);
            formatter.Context = new StreamingContext(contextState);
            formatter.Serialize(stream, obj);
        }
        #endregion

        #region 反序列化加载


        public static Object LoadObjectFormFile(string path ,Type fileFormat)
        {
            FileStream fileStream = File.OpenRead(path);
            try
            {
                return LoadObjectFormStream(fileStream,fileFormat,StreamingContextStates.File|StreamingContextStates.Persistence);
            }
            finally
            {
                if (fileStream != null)
                {
                    ((IDisposable)fileStream).Dispose();
                }
            } 
        }

        public static Object LoadObjectFormStream(Stream fileStream,Type formatType,StreamingContextStates contextStates)
        {
            IFormatter formatter = (IFormatter)Activator.CreateInstance(formatType);
            formatter.Context = new StreamingContext(contextStates);
            return formatter.Deserialize(fileStream);
        }

        /// <summary>
        /// 从文件中加载对象
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static Object LoadObjectFormFile(string path)
        {
            Type fileFormat = GetFileFormat(path);
            if ((object)fileFormat != null)
            {
                return LoadObjectFormFile(path,fileFormat);
            }
            else
            {
                throw new Exception("无法获取文件格式类型！");
            }
        }

        #endregion

        public static Type GetFileFormat(string fileName)
        {
            CheckFileExists(fileName);
            CheckFileFormat(fileName);
                  FileStream fileStream = File.OpenRead(fileName);
            try
            {
                return GetStreamFormat(fileStream);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return typeof(BinaryFormatter);
        }

        [return:MarshalAs(UnmanagedType.U2)]
        private static char ReadNextNWChar(Stream s)
        {
            char c = (char)s.ReadByte();
            while (true)
            {
                if (c != 0 && char.IsWhiteSpace(c))
                {
                    break;
                }
                c = (char)s.ReadByte();
            }
            return c;
        }

        public static Type  GetStreamFormat(Stream s)
        {
            if (s.CanSeek)
            {
                long position = s.Position;
                try
                {
                    char c = ReadNextNWChar(s);
                    if (c == '<')
                    {
                        switch (ReadNextNWChar(s))
                        {
                            case '?':
                                return null;
                            case 'S':
                            case 's':
                                return typeof(SoapFormatter);
                            default:
                                break;
                        }
                    }
                }
                finally
                {
                    s.Position = position;
                }
            }

            return typeof(BinaryFormatter);//返回二进制格式
        }

        /// <summary>
        /// 检查文件格式
        /// </summary>
        private static void CheckFileFormat(string path )
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("文件名为空");
            }
            if (path.EndsWith(".ccdq") || path.EndsWith(".CCDQ"))
            {
                throw new FormatException("文件格式不正确，文件扩展名必须是.ccdq或.CCDQ的文件");
            }
            return ;
           
        }

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        private static void CheckFileExists(string path)
        {
            if (File.Exists(path))
                return;
            else
                throw new ArgumentNullException("文件不存在！");
        }
    }
}
