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
    /// Stellt einen Ordner im Dateisystem dar.
    /// </summary>
    public class Directory
    {
        private System.IO.DirectoryInfo info;

        private ObservableCollection<Directory> directories;
        private ICollectionView directoriesView;

        private ObservableCollection<File> files;
        private ICollectionView filesView;

        public string Name { get { return info.Name; } }
        public string FullName { get { return info.FullName; } }

        /// <summary>
        /// Gibt ein View der Unterordner des Ordners zurück
        /// </summary>
        public ICollectionView DirectoriesView { get { return directoriesView; } }

        /// <summary>
        /// Gibt ein View der Dateien des Ordner zurück.
        /// </summary>
        public ICollectionView FilesView
        {
            get
            {
                if (filesView == null)
                {
                    files = new ObservableCollection<File>(info.GetFiles().Select(fi => new File(fi)));
                    filesView = CollectionViewSource.GetDefaultView(files);
                }

                return filesView;
            }
        }
        
        internal Directory(System.IO.DirectoryInfo info)
        {
            this.info = info;

            directories = new ObservableCollection<Directory>(info.GetDirectories().Select(di => new Directory(di)));
            directoriesView = CollectionViewSource.GetDefaultView(directories);
        }
    }
}
