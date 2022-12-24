using DadsCollections.RazorPages.Helpers;
using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;

namespace DadsCollections.RazorPages.Pages.Shop
{
    public class DisplayModel : PageModel
    {
        private IDatabaseData _db;

        [BindProperty] //bind just for the post action
        public ProductModel SelectedProduct { get; set; }

        public List<ProductModel> products { get; set; }

        //public List<CartItem> cart { get; set; }

        //public decimal Total { get; set; }

        public DisplayModel(IDatabaseData db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            products = _db.GetAllProducts();

            return Page();
        }

        public IActionResult OnPostSelectProduct()
        {
            //on post when user click the `view detail` button
            //if (ModelState.IsValid == false)
            //{
            //    return Page();
            //}

            products = _db.GetAllProducts();
            var selectedProduct = products.Where(x => x.Id == SelectedProduct.Id).FirstOrDefault();

            // sends the ID to DisplayProduct page onGet method
            return RedirectToPage("./DisplaySelectedProduct", new { Id = selectedProduct.Id });
        }

        //public void OnGetAddToCart(string id)
        //{
        //    cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

        //    if (cart is null) return;

        //    Total = cart.Sum(i => i.Product.Price * i.Quantity);
        //}
    }
}


//Todo: need to add async to everything