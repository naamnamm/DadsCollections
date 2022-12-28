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

        public string Message { get; set; } = String.Empty;

        public List<ProductModel> products { get; set; }

        public CartModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart is null || cart.Count == 0) return;

            Total = cart.Sum(i => i.Product.Price * i.Quantity);
        }

        public IActionResult OnGetAddToCart(string id)
        {
            products = _db.GetAllProducts();

            int intId;
            Int32.TryParse(id, out intId);
            var selectedProduct = products.Where(x => x.Id == intId).FirstOrDefault();

            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart is null)
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

            if (cart is not null)
            {
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
                    Message = "The selected product is already in the cart.";
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

        public void OnGetRemoveItemFromCart(string id)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart is null)
            {
                return;
            }

            int intId;
            Int32.TryParse(id, out intId);

            int index = Exists(cart, intId);

            cart.RemoveAt(index);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            if (cart.Count == 0)
            {
                return;
            }

            Total = cart.Sum(i => i.Product.Price * i.Quantity);
        }
    }
}
