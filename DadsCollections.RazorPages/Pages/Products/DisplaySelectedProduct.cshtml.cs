using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages.Products
{
    public class DisplaySelectedProductModel : PageModel
    {

        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)] //put Id as part of the url
        public int Id { get; set; }

        public ProductModel SelectedProduct { get; set; }

        public DisplaySelectedProductModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            //need to get productId from the url
            SelectedProduct = _db.SearchProduct(Id).FirstOrDefault();

        }
    }
}
