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

        [BindProperty] 
        public ProductModel SelectedProduct { get; set; }

        public List<ProductModel> products { get; set; }

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
            products = _db.GetAllProducts();
            var selectedProduct = products.Where(x => x.Id == SelectedProduct.Id).FirstOrDefault();

            return RedirectToPage("./DisplaySelectedProduct", new { Id = selectedProduct.Id });
        }
    }
}

