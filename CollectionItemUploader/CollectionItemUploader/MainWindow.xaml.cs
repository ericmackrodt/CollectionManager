using CollectionItemUploader.ViewModels;
using CollectionItemUploader.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionItemUploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await (DataContext as MainViewModel).LoadData(null);
        }

        private void BtnAddCollection_Click(object sender, RoutedEventArgs e)
        {
            var addCol = new AddCollectionWindow();
            addCol.Show();
        }

        private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            var addCat = new AddCategoryWindow();
            addCat.Show();
        }
    }
}
