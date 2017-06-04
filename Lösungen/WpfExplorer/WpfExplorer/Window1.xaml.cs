using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfExplorer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            FileSystem fs = new FileSystem("D:\\Documents");

            this.DataContext = fs;
        }

        private void HANDLER_METH(object sender, RoutedEventArgs e)
        {
            ListView lv = sender as ListView;
            GridViewColumnHeader header = (GridViewColumnHeader)e.OriginalSource;

            ICollectionView view = (ICollectionView)lv.ItemsSource;

            Binding b = header.Column.DisplayMemberBinding as Binding;

            if (b == null) return;

            string path = b.Path.Path;

            if (string.IsNullOrEmpty(path)) return;

            if (view == null) return;

            SortDescription sd = view.SortDescriptions.FirstOrDefault();
            ListSortDirection direction = ListSortDirection.Ascending;

            if (sd != null && (sd.PropertyName == path & sd.Direction == ListSortDirection.Ascending))
            {
                direction = ListSortDirection.Descending;
            }

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(path, direction));
        }
    }
}
