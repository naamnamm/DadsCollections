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

        public List<CartItem> cart { get; set; }

        public decimal Total { get; set; }

        public List<ProductModel> products { get; set; }

        public CartModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // need to create a check to see if cart is empty

            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart is null) return;

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

                Total = cart.Sum(i => i.Product.Price * i.Quantity);
                return Page();
            }

            //if the cart is not null
            if (cart is not null)
            {
                // 1. if item doesn't exist in the cart - add new item
                int index = Exists(cart, intId);
                if (index == -1)
                {
                    cart.Add(new CartItem
                    {
                        Product = selectedProduct,
                        Quantity = 1
                    });
                } // else Quantity += 1
                else
                {
                    //display product has already been added to the cart
                    cart[index].Quantity++;
                }

                Total = cart.Sum(i => i.Product.Price * i.Quantity);
            
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }



            return Page();

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
    }
}
