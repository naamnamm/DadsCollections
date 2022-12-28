using DadsCollections.RazorPages.Helpers;
using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class CheckoutModel : PageModel
    {

        private IDatabaseData _db;
        public List<CartItem> cart { get; set; }

        [BindProperty]
        public CustomerModel customer { get; set; }

        public decimal Total { get; set; }

        public List<int> OrderProductList { get; set; }

        public CheckoutModel(IDatabaseData db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart is null || cart.Count == 0)
            {
                return RedirectToPage("./Cart");
            }

            Total = cart.Sum(i => i.Product.Price * i.Quantity);
            return Page();
        }

        public IActionResult OnPostPlaceOrder()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(item => item.Product.Price * item.Quantity);

            OrderProductList = new List<int>();

            foreach (var item in cart) 
            {
                OrderProductList.Add(item.Product.Id);
            }

            int id = _db.CreateOrder(customer.FirstName, customer.LastName, customer.Email, Total, OrderProductList);

            return RedirectToPage("./OrderSuccess", new { id });
        }
    }
}
