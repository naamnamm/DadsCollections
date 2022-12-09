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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace DadsCollections.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IDatabaseData _db;
        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void openOrderWindow_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = App.serviceProvider.GetService<Order>();
            orderWindow.Show();
            this.Close();

            //var model = (OrderFullModel)((Button)e.Source).DataContext;
            //orderForm.PopulateCheckInInfo(model);
            //search order (id)
        }

        private void openProductWindow_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = App.serviceProvider.GetService<Product>();
            productWindow.Show();
            this.Close();

            //var model = (OrderFullModel)((Button)e.Source).DataContext;
            //orderForm.PopulateCheckInInfo(model);
            //search order (id)
        }

        //main window has 2 buttons
        // order
        //-- 1. has button to show the search Order Window

        //product

        //private void searchForOrder_Click(object sender, RoutedEventArgs e)
        //{
        //    List<OrderFullModel> orders = _db.SearchOrdersByEmail(emailText.Text);
        //    resultsList.ItemsSource = orders;
        //}

        //private void viewOrder_Click(object sender, RoutedEventArgs e)
        //{

        //    var orderForm = App.serviceProvider.GetService<OrderForm>();
        //    var model = (OrderFullModel)((Button)e.Source).DataContext;
        //    //send id to order form

        //    orderForm.PopulateCheckInInfo(model);
        //    //search order (id)
        //    orderForm.Show();

        //}
    }
}
