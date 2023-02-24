using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Runtime.InteropServices;
using System.Speech;
using System.Speech.Recognition;
using Models;
using BLL;
using Utility;
using ZXing;
using ZXing.Common;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsFormsApp1
{
    /// <summary>
    /// 判断输入的图片是否存在二维码
    /// if yes 返回提醒
    /// if no 返回空
    /// </summary>
    public class Cheak_QRcode
    {
        //Bitmap img;//处理图片
        public bool Cheak_IF_QRcode(Bitmap image)
        {
            string str = null;
            try
            {
                if (image != null)
                {
                    //Bitmap img = new Bitmap(@"D:\069936cb-b9a7-4fed-a7de-b9cd99f487ad.png");
                    byte[] bt = getImgByte(image);
                    LuminanceSource source = new RGBLuminanceSource(bt, image.Width, image.Height);
                    BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                    Result result = new MultiFormatReader().decode(bitmap);
                    if (result != null)
                    {
                        str = result.Text;
                        
                    }
                }
            }
            catch (Exception re)
            {
                throw re;

            }
            if (str == null)
            {//没有二维码
                return false;
            }
            else
            {//有二维码
                return true;
            }
            






        }
        // 性能最高，其数组和像素一一对应
        //public static byte[] GetImgByte(this Bitmap bmp)
        //{
        //    BitmapData bitmapData = bmp.LockBits(new System.Drawing.Rectangle(new System.Drawing.Point(0, 0), bmp.Size),
        //        ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        //    byte[] res = new byte[bitmapData.Stride * bitmapData.Height];

        //    IntPtr Ptr = bitmapData.Scan0;
        //    System.Runtime.InteropServices.Marshal.Copy(Ptr, res, 0, res.Length);

        //    bmp.UnlockBits(bitmapData);
        //    return res;
        //}


        public byte[] getImgByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                image.Save(ms, ImageFormat.Bmp);
                byte[] bt = ms.GetBuffer();
                return bt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
    }
}
