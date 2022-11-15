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

        public ProductModel SelectedProduct { get; set; }

        public DisplaySelectedProductModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            SelectedProduct = _db.SearchProduct(Id).FirstOrDefault();

        }

    }
}
