using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;


namespace DadsCollections.RazorPages.Pages.Products
{
    public class DisplaySelectedProductModel : PageModel
    {

        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)] //id as part of the url
        public int Id { get; set; }

        //[TempData]
        //public int Id { get; set; }

        //[BindProperty] //bind just for the post action
        public ProductModel SelectedProduct { get; set; }

        //public List<ProductModel> products { get; set; }

        public DisplaySelectedProductModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            SelectedProduct = _db.SearchProduct(Id).FirstOrDefault();

            //set cookie
            //return Page();
        }

        //post to cart
        //public IActionResult OnPostAddToCart()
        //{
        //    //on post when user click the `view detail` button
        //    //if (ModelState.IsValid == false)
        //    //{
        //    //    return Page();
        //    //}

        //    products = _db.GetAllProducts();
        //    var selectedProduct = products.Where(x => x.Id == SelectedProduct.Id).FirstOrDefault();

        //    //Id = selectedProduct.Id;

        //    // sends the ID to DisplayProduct page onGet method
        //    //return RedirectToPage("/Cart", new { Id = selectedProduct.Id });
        //    return RedirectToPage("/Cart");
        //}

        //public IActionResult OnPostAddToCart()
        //{
        //    //if (ModelState.IsValid == false)
        //    //{
        //    //    return Page();
        //    //}

        //    //on post - when the user click add to cart
        //    // 1. send product Id to the cart page
        //    return RedirectToPage("./Cart/Display", new { Id });

        //    //create 

        //    // 2 - check if cookie named cartId exist
        //    // if yes
        //    // -- 1. post to the cartItems DB table
        //    // -- 2. 

        //    // if no 
        //    // -- 1. post to the carts DB table - generate cartId, timestamp, checked out set to false.
        //    // -- 2. post to the cartItems DB table
        //    // -- 3. sends the generate cartId back to the client to save it as a cookie 
        //}
    }
}
