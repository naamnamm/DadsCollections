using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
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
using Microsoft.Extensions.DependencyInjection;

namespace DadsCollections.Desktop
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        private readonly IDatabaseData _db;

        private OrderFullModel _data = null;
        public Product(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void backToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = App.serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
            this.Close();
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            var addProductForm = App.serviceProvider.GetService<AddProductForm>();

            addProductForm.Show();

        }

        private void searchForProduct_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
