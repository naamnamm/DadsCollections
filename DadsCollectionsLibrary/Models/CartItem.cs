using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadsCollectionsLibrary.Models
{
    public class CartItem
    {
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
