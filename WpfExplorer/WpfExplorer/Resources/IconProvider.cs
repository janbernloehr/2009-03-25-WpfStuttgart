using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using IconImage = System.Drawing.Icon;
using System.Windows.Interop;
using System.Windows;

namespace WpfExplorer
{
    public class IconProvider
    {
        /// <summary>
        /// Gibt das zu der übergebenen Datei gehörige Icon zurück.
        /// </summary>
        public static BitmapSource GetIconForFile(string fileName)
        {
            var file = new System.IO.FileInfo(fileName);

            if (!file.Exists) return null;

            IntPtr handle = default(IntPtr);

            handle = IconImage.ExtractAssociatedIcon(fileName).Handle;

            return Imaging.CreateBitmapSourceFromHIcon(handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
