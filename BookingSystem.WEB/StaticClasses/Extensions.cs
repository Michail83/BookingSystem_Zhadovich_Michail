using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace BookingSystem.WEB.StaticClasses
{
    public static class Extensions
    {
        public static byte[] ToByteArrayWithResize(this IFormFile formFile, int newWidth, int newHeight)
        {
            var newSize = new Size { Height = newHeight, Width = newWidth };
            var imageData = formFile.ToImage().ResizeImage(newSize).ToByteArray();

            return imageData;
        }

        public static  Image ToImage(this IFormFile formFile)
        {
            if (formFile == null ||

                formFile.ContentType.ToLower() != "image/jpg" &&
                formFile.ContentType.ToLower() != "image/jpeg" &&
                formFile.ContentType.ToLower() != "image/pjpeg" &&
                formFile.ContentType.ToLower() != "image/gif" &&
                formFile.ContentType.ToLower() != "image/x-png" &&
                formFile.ContentType.ToLower() != "image/png" )
            {
                return null;
            }
            Image image = null;
            try
            {
                using var stream = new MemoryStream();
                formFile.CopyTo(stream);
                image = Image.FromStream(stream);
            }
            catch (Exception)
            {
                return image;
            }
            return image;
        }

        public static Image ResizeImage(this Image image, Size size)
        {
            if (image == null)
                return null;
            
            if (image.Height<=size.Height && image.Width<=size.Width)            
                return image;
            
            double ratio;            

            if (image.Height >= image.Width)            
                ratio = (double)size.Width / image.Width;            
            else            
                ratio = (double)size.Height / image.Height;                
           
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            var resultImage = new Bitmap(newWidth, newHeight);

            using var graphic = Graphics.FromImage(resultImage);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            
            return resultImage;
        }

        public static byte[] ToByteArray(this Image image)
        {           
            if (image==null)
            {
                return new byte[0];
            }
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            var arrayResult = stream.ToArray();

            return arrayResult;
        }

    }
}
