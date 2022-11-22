using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class OrderPlacedModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)] //id as part of the url
        public int Id { get; set; }

        public CustomerModel customer { get; set; }

        public OrderProductModel OrderedProducts { get; set; }

        public OrderPlacedModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            //display success message includes



            //1. need to create spOrders_SearchByOrderId

            
            //order ID get from url 
            //--searchOrderById(Id)
            //output: Order = {Id, CustomerId, CreatedDate, Status, TotalCost, orderProductIdList = {1,2,3}}

            //customers name
            //--searchCustomerById(Order.CustomerID)
            //output: customer = {Id, FirstName, LastName, Email}

            //if order is not null
            //search order products by orderID
            //1. loop through orderProductIdList = {1,2,3} 
            //output: List<ProductModel>

        }
    }
}
