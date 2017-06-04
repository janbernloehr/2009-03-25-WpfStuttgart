using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace WpfExplorer
{
    /// <summary>
    /// Stellt eine hirarchische Struktur für ein Dateisystem zur Verfügung.
    /// </summary>
    /// <example>
    /// FileSystem fs = new FileSystem("D:\\Documents");
    /// </example>
    public class FileSystem
    {
        private ObservableCollection<Directory> directories;
        private ICollectionView directoriesView;

        public FileSystem(string root) {
            var ioroot = new System.IO.DirectoryInfo(root);

            directories = new ObservableCollection<Directory>(ioroot.GetDirectories().Select(di => new Directory(di)));
            directoriesView = CollectionViewSource.GetDefaultView(directories);
        }

        public ICollectionView DirectoriesView { get { return directoriesView; } }
    }
}
