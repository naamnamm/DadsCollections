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

namespace DadsCollections.Desktop
{
    /// <summary>
    /// Interaction logic for OrderForm.xaml
    /// </summary>
    public partial class OrderForm : Window
    {
        private readonly IDatabaseData _db;

        private OrderFullModel _data = null;

        private string StatusText { get; set; }

        public OrderForm(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public void PopulateCheckInInfo(OrderFullModel data)
        {
            _data = data;
            idText.Text = _data.Id.ToString();
            firstNameText.Text = _data.FirstName;
            lastNameText.Text = _data.LastName;
            createdDateText.Text = _data.CreatedDate.ToShortDateString();
            statusText.Text = _data.Status;
            orderProductsText.Text = _data.OrderProductIdList.ToString();
        }

        private void updateOrder_Click(object sender, RoutedEventArgs e)
        {
            StatusText = ((Button)e.Source).Name;
            _db.UpdateOrderStatus(_data.Id, StatusText);
            this.Close();
        }

    }
}
