using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadsCollectionsLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; }

        public decimal TotalCost { get; set; }  
    }
}
