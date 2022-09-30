using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class ShopModel : PageModel
    {
        private IDatabaseData _db;

        public List<ProductModel> products { get; set; }

        public ShopModel(IDatabaseData db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            products = _db.GetAllProducts();

            return Page();
        }
    }
}
