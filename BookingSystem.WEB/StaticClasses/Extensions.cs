using Microsoft.AspNetCore.Http;
using SkiaSharp;
using System.IO;

namespace BookingSystem.WEB.StaticClasses
{
    public static class Extensions
    {
        public static byte[] ToByteArrayWithResize(this IFormFile formFile, int newWidth, int newHeight)
        {

            var byteArray = formFile.ToImage().ResizeImage(newWidth, newHeight).ToByteArray();
            return byteArray;
        }

        public static SKBitmap ToImage(this IFormFile formFile)
        {
            if (formFile == null ||

                formFile.ContentType.ToLower() != "image/jpg" &&
                formFile.ContentType.ToLower() != "image/jpeg" &&
                formFile.ContentType.ToLower() != "image/pjpeg" &&
                formFile.ContentType.ToLower() != "image/gif" &&
                formFile.ContentType.ToLower() != "image/x-png" &&
                formFile.ContentType.ToLower() != "image/png")
            {
                return null;
            }

            using var memoryStream = new MemoryStream();

            formFile.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();           

            var bitmap = SKBitmap.Decode(bytes);

            return bitmap;
        }

        public static SKBitmap ResizeImage(this SKBitmap image, int newWidth, int newHeight)
        {
            if (image.Height <= newHeight && image.Width <= newWidth)
                return image;
            double ratio;

            if (image.Height <= image.Width)
                ratio = (double)newWidth / image.Width;
            else
                ratio = (double)newWidth / image.Height;

            int targetWidth = (int)(image.Width * ratio);
            int targetHeight = (int)(image.Height * ratio);

            var resultImage = new SKBitmap(targetWidth, targetHeight, true);

            image.ScalePixels(resultImage, SKFilterQuality.High);

            return resultImage;
        }

        public static byte[] ToByteArray(this SKBitmap image)
        {
            using var memoryStream = new MemoryStream();
            using var sKManagetWstream = new SKManagedWStream(memoryStream);
            image.Encode(sKManagetWstream, SKEncodedImageFormat.Jpeg, 100);
            byte[] result = memoryStream.ToArray();

            return result;
        }
    }
}
