using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DadsCollections.RazorPages.Pages
{
    public class OrderPlacedModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)] //id as part of the url
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public List<OrderFullModel> Order { get; set; }

        public decimal OrderTotal { get; set; }

        public OrderPlacedModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            //display success message includes

            Order = _db.SearchOrdersById(Id);
            OrderTotal = Order.First().TotalCost;
            CustomerName = Order.First().FirstName;
        }
    }
}
