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

        // need to show blank input 
        //insert into dbo.Products(Title, [Description], Price, Quantity, ProductTypeId, ImgName)
        //values(@title, @description, @price, @quantity, @productTypeId, @imgName)

        // pull ProductTypeId from DB
        // show as a list

        // submit Product model when click submit 



        //isSold
        private readonly IDatabaseData _db;

        private ProductModel _addedProduct;

        public AddProductForm(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;   
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            var addedProduct = new ProductModel();

            //grab input value
            //_addedProduct.Title = titleText.Text;
            //_addedProduct.Description = descriptionText.Text;
            //_addedProduct.Price = Convert.ToDecimal(priceText.Text);
            //_addedProduct.Quantity = Int32.Parse(quantityText.Text);
            //_addedProduct.ImgName = imgNameText.Text;
            //_addedProduct.ProductTypeId = Int32.Parse(productTypeText.Text);

            addedProduct.Title = titleText.Text;
            addedProduct.Description = descriptionText.Text;
            addedProduct.Price = Convert.ToDecimal(priceText.Text);
            addedProduct.Quantity = Int32.Parse(quantityText.Text);
            addedProduct.ImgName = imgNameText.Text;
            addedProduct.ProductTypeId = Int32.Parse(productTypeText.Text);

            _db.CreateProducts(addedProduct);

            //if successfully added - set input text to blank and show success msg
        }
    }
}
