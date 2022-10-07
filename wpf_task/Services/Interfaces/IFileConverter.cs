using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace wpf_task.Services.Interfaces
{
    internal interface IFileConverter
    {
        BitmapImage ConvertBase64ToImage(string code);
        string ConvertImageToBase64(string filePath);
    }
}
