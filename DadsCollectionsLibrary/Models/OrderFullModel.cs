using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadsCollectionsLibrary.Models
{
    public class OrderFullModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public decimal TotalCost { get; set; }
        public string OrderProductIdList { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsSold { get; set; }

    }
}
