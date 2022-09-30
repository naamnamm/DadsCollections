using DadsCollectionsLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.Web.Pages
{
    public class ShopModel : PageModel
    {
        private IDatabaseData _databaseData;

        public ShopModel(IDatabaseData databaseData)
        {
            _databaseData = databaseData;
        }
        //public async Task<IActionResult> OnGet()
        //{
        //    var Products = await _databaseData.GetAvailableProducts();

        //    return Page();
        //}
    }
}
