using DadsCollections.RazorPages.Helpers;
using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class CheckoutModel : PageModel
    {
        //user hit checkout from the Cart page
        //then it direct user to the check out page
        //onGet: checkout page get cart item from session
        //onPost: Place order that post cart to DB
        private IDatabaseData _db;
        public List<CartItem> cart { get; set; }

        public CustomerModel customer { get; set; }

        public string Message { get; set; }

        public decimal Total { get; set; }

        public List<int> OrderProductList { get; set; }
        public CheckoutModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            if (cart is null)
            {
                Message = "no item in the cart";
                return;
            }

            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Product.Price * i.Quantity);
        }

        public IActionResult OnPostPlaceOrder()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Product.Price * i.Quantity);

            foreach (var item in cart) {

                //push item.product.id
            }

            _db.CreateOrder(customer.FirstName, customer.LastName, customer.Email, Total, OrderProductList);

            //need to convert products in Cart to List of int


            //where to direct user to?
            return Page();
        }
    }
}
