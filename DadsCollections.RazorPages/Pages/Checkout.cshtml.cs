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

        [BindProperty]
        public CustomerModel customer { get; set; }

        public string Message { get; set; }

        public decimal Total { get; set; }

        public List<int> OrderProductList { get; set; }
        public CheckoutModel(IDatabaseData db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            //need to refactor this validation
            if (cart is null)
            {
                Message = "no item in the cart";
                return RedirectToPage("./Cart");
            }

            Total = cart.Sum(i => i.Product.Price * i.Quantity);
            return Page();
        }

        public IActionResult OnPostPlaceOrder()
        {
            // when user click submit - call this onPost function
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(item => item.Product.Price * item.Quantity);

            OrderProductList = new List<int>();

            //convert products in Cart to List of int
            foreach (var item in cart) {

                //push item.product.id
                OrderProductList.Add(item.Product.Id);
            }

            int id = _db.CreateOrder(customer.FirstName, customer.LastName, customer.Email, Total, OrderProductList);

            //where to direct user to?
            return Page();
        }
    }
}
