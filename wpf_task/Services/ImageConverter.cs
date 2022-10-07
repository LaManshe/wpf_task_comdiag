using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using wpf_task.Services.Interfaces;

namespace wpf_task.Services
{
    internal class ImageConverter : IFileConverter
    {
        public string ConvertImageToBase64(string filePath)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            byte[] imgbyte = (byte[])converter.ConvertTo((Bitmap)Image.FromFile(filePath), typeof(byte[]));

            return Convert.ToBase64String(imgbyte);
        }

        public BitmapImage ConvertBase64ToImage(string code)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(Convert.FromBase64String(code));
            image.EndInit();
            return image;
        }
    }
}
