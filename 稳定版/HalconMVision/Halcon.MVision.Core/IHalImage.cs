using System;
using System.Collections.Generic;
using System.Drawing;
using HalconDotNet;

namespace Halcon.MVision
{
    /// <summary>
    /// MVision图像接口
    /// </summary>
   public interface IHalImage
    {
       /// <summary>
       /// Halcon图像
       /// </summary>
        HObject SourceImage
        {
            get;
        }

        /// <summary>
        /// 获取图像宽度
        /// </summary>
        int Width
        {
            get;
        }

        /// <summary>
        /// 获取图像高度
        /// </summary>
        int Height
        {
            get;
        }

        /// <summary>
        /// 返回该图像的24位bitmap图像
        /// </summary>
        /// <returns></returns>
        Bitmap TopBitmap();

        /// <summary>
        /// 创建此图像的缩放版本。返回图像的尺寸(以像素为单位)由宽度和高度参数指定。使用双线性插值进行缩放。
        /// </summary>
        /// <param name="width">输出图像的宽度</param>
        /// <param name="height">输出图像的高度</param>
        /// <returns></returns>
        IHalImage ScaleImage(int width,int height);
    }
}
