using DadsCollections.RazorPages.Helpers;
using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class CartModel : PageModel
    {
        private IDatabaseData _db;

        //[BindProperty(SupportsGet = true)] //Id as part of the url
        //public int Id { get; set; }
        public List<CartItem> cart { get; set; }
        public decimal Total { get; set; }

        public List<ProductModel> products { get; set; }

        public CartModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Product.Price * i.Quantity);
        }


        public IActionResult OnGetAddToCart(string id)
        {
            products = _db.GetAllProducts();

            int intId;
            Int32.TryParse(id, out intId);
            var selectedProduct = products.Where(x => x.Id == intId).FirstOrDefault();

            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<CartItem>();

                cart.Add(new CartItem
                {
                    Product = selectedProduct,
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                //return RedirectToPage("Cart");
                return Page();
            }


            int index = Exists(cart, intId);
            if (index == -1)
            {
                cart.Add(new CartItem
                {
                    Product = selectedProduct,
                    Quantity = 1
                });
            }
            else
            {
                //display product has already been added to the cart
                cart[index].Quantity++;
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return Page();
            //return RedirectToPage("Cart");
        }

        private int Exists(List<CartItem> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        //when first load the first - get cartID from cookie if exist, otherwise set cookie
        //public void OnGet()
        //{
        //    const string CookieName = "DadsCollectionCookie";
        //    if (Request.Cookies[CookieName] == null)
        //    {
        //        var cookieOptions = new CookieOptions
        //        {
        //            Secure = true,
        //            HttpOnly = true,
        //            SameSite = SameSiteMode.Unspecified
        //        };

        //        // Add the cookie to the response cookie collection
        //        Response.Cookies.Append(CookieName, "cartID", cookieOptions);
        //    }
        //}


    }
}
