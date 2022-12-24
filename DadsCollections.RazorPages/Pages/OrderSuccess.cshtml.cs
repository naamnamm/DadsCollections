using DadsCollections.RazorPages.Helpers;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class OrderSuccessModel : PageModel
    {
        public List<CartItem> cart { get; set; } = null;

        public string Message;

        public void OnGet()
        {
            Message = "Thank you for your order";

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }
    }
}
