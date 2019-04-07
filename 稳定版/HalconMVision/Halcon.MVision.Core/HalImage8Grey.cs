using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using HalconDotNet;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;

//**********************************************
//文件名：HalImage8Grey
//命名空间：Halcon.MVision
//CLR版本：4.0.30319.42000
//内容：包含HObject类型图像和HObject类型的Graphic表
//功能：MVision8位灰度图
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/1/11 15:12:59
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision
{
    [Serializable]
    public class HalImage8Grey : IHalImage, ISerializable, IDisposable, ICloneable
    {

        private int m_width = 0;
        private int m_height = 0;

        private HObject sourceImage = null;    //相机源图像
        private Hashtable myGraphicTable = new Hashtable(10, 0.2f);  //存储Graphics对象的哈希表

        [NonSerialized]
        private bool _disposed = false;

        #region 构造函数

        /// <summary>
        /// HalImage8Grey构造函数
        /// </summary>
        /// <param name="srcImage">相机输出源图像</param>
        public HalImage8Grey(ref HObject srcImage)
        {
            HOperatorSet.GenEmptyObj(out sourceImage);
            sourceImage = srcImage;

        }

        /// <summary>
        /// HalImage8Grey构造函数
        /// </summary>
        /// <param name="srcImage">windows位图</param>
        public HalImage8Grey(Bitmap srcImage)
        {
            HOperatorSet.GenEmptyObj(out sourceImage);
            BitmapToHObjectImage(srcImage);
        }

        /// <summary>
        /// HalImage8Grey的拷贝构造函数
        /// </summary>
        /// <param name="other">其它HalImage8Grey对象</param>
        public HalImage8Grey(HalImage8Grey other)
        {
            HOperatorSet.GenEmptyObj(out sourceImage);
            sourceImage = other.SourceImage;
            myGraphicTable = other.GraphicContext;
        }

        private HalImage8Grey(SerializationInfo info, StreamingContext context)
        {
            sourceImage = (HObject)info.GetValue("srcImage", typeof(HObject));
            myGraphicTable = (Hashtable)info.GetValue("graphicContext", typeof(Hashtable));
        }
        #endregion


        #region 属性
        /// <summary>
        /// 获取图像宽度
        /// </summary>
        public int Width
        {
            get
            {
                GetImageWidth();
                return m_width;
            }
        }

        /// <summary>
        /// 获取图像高度
        /// </summary>
        public int Height
        {
            get
            {
                GetImageHeight();
                return m_height;
            }
        }

        public HObject SourceImage
        {
            get { return sourceImage; }
        }

        public Hashtable GraphicContext
        {
            get { return myGraphicTable; }
        }

        /// <summary>
        /// 获取原图像是否为空
        /// </summary>
        public bool IsSourceImageEmpty
        {
            get
            {
                HObject hobj;
                HOperatorSet.GenEmptyObj(out hobj);
              int val=  sourceImage.TestEqualObj(hobj);
                if (val == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 创建此图像的缩放版本。返回图像的尺寸(以像素为单位)由宽度和高度参数指定。使用双线性插值进行缩放
        /// </summary>
        /// <param name="width">指定图像的宽度</param>
        /// <param name="height">指定图像的高度</param>
        /// <returns></returns>
        public IHalImage ScaleImage(int width, int height)
        {
            if (sourceImage == null) return null;
            HObject ho_Image;
            HOperatorSet.GenEmptyObj(out ho_Image);
            HTuple hv_HalconError;
            try
            {
                HOperatorSet.ZoomImageSize(sourceImage, out ho_Image, new HTuple(width), new HTuple(height), new HTuple("bilinear"));
                return (IHalImage)ho_Image;
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
                return null;
            }

        }

        /// <summary>
        /// 返回图像的24位图
        /// </summary>
        /// <returns></returns>
        public Bitmap TopBitmap()
        {
            if (sourceImage == null) return null;
            Bitmap res;
            HTuple hred, hgreen, hblue, type, width, height;

            HOperatorSet.GetImagePointer3(sourceImage, out hred, out hgreen, out hblue, out type, out width, out height);
            res = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = res.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            unsafe
            {
                byte* bptr = (byte*)bitmapData.Scan0;
                byte* r = ((byte*)hred.I);
                byte* g = ((byte*)hgreen.I);
                byte* b = ((byte*)hblue.I);
                for (int i = 0; i < width * height; i++)
                {
                    bptr[i * 4] = (b)[i];
                    bptr[i * 4 + 1] = (g)[i];
                    bptr[i * 4 + 2] = (r)[i];
                    bptr[i * 4 + 3] = 255;
                }
            }

            res.UnlockBits(bitmapData);
            return res;
        }

        /// <summary>
        /// 向图片中添加图标元素
        /// </summary>
        /// <param name="name">图标名称</param>
        /// <param name="iconic">图标对象</param>
        public void AddIconic(string name, HObject iconic)
        {
            AddValueToHashTable(name, iconic);
        }

        #endregion

        #region 私有方法

        private void BitmapToHObjectImage(Bitmap bitmap)
        {
            if (bitmap == null) return;
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(
                rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            HTuple hv_halconError;
            try
            {
                HOperatorSet.GenImageInterleaved(out sourceImage, bmpData.Scan0, "bgrx", bitmap.Width,
                    bitmap.Height, -1, "byte", bitmap.Width, bitmap.Height, 0, 0, -1, 0);

            }
            catch (HalconException e)
            {
                hv_halconError = e.GetErrorCode();
                if ((int)hv_halconError < 0)
                    throw e;
            }
        }

        /// <summary>
        /// 获取图像宽度
        /// </summary>
        private void GetImageWidth()
        {
            if (!IsSourceImageEmpty)
            {
                if (m_width == 0)
                {
                    HTuple hv_HalconError;
                    HTuple hv_imagewidth, hv_imageheight;
                    try
                    {
                        HOperatorSet.GetImageSize(sourceImage, out hv_imagewidth, out hv_imageheight);
                        m_width = hv_imagewidth.I;
                        m_height = hv_imageheight.I;
                    }
                    catch (HalconException e)
                    {
                        hv_HalconError = e.GetErrorCode();
                        if (hv_HalconError < 0)
                            throw e;
                    }
                }
            }
            //else
            //{
            //    throw new NullReferenceException("源图像为空，无法获取图像宽度信息！");
            //}
        }
        /// <summary>
        /// 获取图像的高度
        /// </summary>
        private void GetImageHeight()
        {
            if (!sourceImage.Equals(null))
            {
                if (m_height != 0)
                {
                    HTuple hv_HalconError;
                    HTuple hv_imagewidth, hv_imageheight;
                    try
                    {
                        HOperatorSet.GetImageSize(sourceImage, out hv_imagewidth, out hv_imageheight);
                        m_width = hv_imagewidth.I;
                        m_height = hv_imageheight.I;
                    }
                    catch (HalconException e)
                    {
                        hv_HalconError = e.GetErrorCode();
                        if (hv_HalconError < 0)
                            throw e;
                    }
                }
            }
            else
            {
                throw new NullReferenceException("源图像为空，无法获取图像高度信息！");
            }
        }

        /// <summary>
        /// 往图形HashTable中添加键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        private void AddValueToHashTable(string key, HObject val)
        {
            if (myGraphicTable.ContainsKey(key))
                myGraphicTable[key] = val;
            else
                myGraphicTable.Add(key, val);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("srcImage", sourceImage, typeof(HObject));
            info.AddValue("graphicContext", myGraphicTable, typeof(Hashtable));
        }

        protected virtual void Dispose(bool disposing)
        {
            //释放飞托管资源

            //释放托管资源
            if (disposing)
            {
                if (!_disposed)
                {
                    try
                    {
                        sourceImage.Dispose();
                        myGraphicTable.Clear();
                    }
                    finally
                    {
                        _disposed = true;
                        HOperatorSet.GenEmptyObj(out sourceImage);
                    }
                }

            }

        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        protected virtual object Clone()
        {
            return new HalImage8Grey(this);
        }
        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
