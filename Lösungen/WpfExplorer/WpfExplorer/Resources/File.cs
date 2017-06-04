using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfExplorer
{
    /// <summary>
    /// Stellt eine Datei im Dateisystem dar.
    /// </summary>
    public class File
    {
        private string name;
        private string fullName;
        private long length;
        private DateTime lastChanged;

        public string Name { get { return name; } }
        public string FullName { get { return fullName; } }
        public long Length { get { return length; } }
        public DateTime LastChanged { get { return lastChanged; } }

        internal File(System.IO.FileInfo info) {
            name = info.Name;
            fullName = info.FullName;
            length = info.Length;
            lastChanged = info.LastWriteTime;

            icon = IconProvider.GetIconForFile(fullName);
        }

        private BitmapSource icon;

        public BitmapSource Icon { get { return icon; } }
    }
}
