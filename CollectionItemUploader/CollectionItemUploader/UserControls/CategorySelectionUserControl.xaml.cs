using CollectionItemUploader.ViewModels;
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

namespace CollectionItemUploader.UserControls
{
    /// <summary>
    /// Interaction logic for CategorySelectionUserControl.xaml
    /// </summary>
    public partial class CategorySelectionUserControl : UserControl
    {
        public CategorySelectionViewModel ViewModel { get { return DataContext as CategorySelectionViewModel; } }

        public CategorySelectionUserControl()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadData(null);
        }
    }
}
