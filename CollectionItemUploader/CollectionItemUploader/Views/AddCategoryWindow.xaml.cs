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
using System.Windows.Shapes;

namespace CollectionItemUploader.Views
{
    /// <summary>
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public CreateCategoryViewModel ViewModel { get { return DataContext as CreateCategoryViewModel; } }

        public AddCategoryWindow()
        {
            InitializeComponent();
            ViewModel.OnCreated += ViewModel_OnCreated;
        }

        private void ViewModel_OnCreated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
