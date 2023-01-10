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
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        private readonly IDatabaseData _db;

        public AddProductForm(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;   
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            var addedProduct = new ProductModel();

            addedProduct.Title = titleText.Text;
            addedProduct.Description = descriptionText.Text;
            addedProduct.Price = Convert.ToDecimal(priceText.Text);
            addedProduct.Quantity = Int32.Parse(quantityText.Text);
            addedProduct.ImgName = imgNameText.Text;
            addedProduct.ProductTypeId = Int32.Parse(productTypeText.Text);

            _db.CreateProducts(addedProduct);

            this.Close();
        }
    }
}
