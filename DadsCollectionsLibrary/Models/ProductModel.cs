using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadsCollectionsLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price{ get; set; }
        public int Quantity { get; set; }
        public int ProductTypeId { get; set; } 
        public string ImgName { get; set; } 
        public bool IsSold { get; set; }
    }
}
