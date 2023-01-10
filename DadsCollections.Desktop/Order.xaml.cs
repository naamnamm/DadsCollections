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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        private readonly IDatabaseData _db;

        public Order(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }
        private void searchForOrder_Click(object sender, RoutedEventArgs e)
        {
            List<OrderFullModel> orders = _db.SearchOrdersByEmail(emailText.Text);
            resultsList.ItemsSource = orders;
        }

        private void viewOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderForm = App.serviceProvider.GetService<OrderForm>();
            var model = (OrderFullModel)((Button)e.Source).DataContext;

            orderForm.PopulateCheckInInfo(model);

            orderForm.Show();
        }

        private void backToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = App.serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
            this.Close();
        }
        
    }
}
