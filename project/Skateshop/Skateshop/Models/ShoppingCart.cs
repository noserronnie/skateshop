using Skateshop.Composite;
using System.Collections.Generic;

namespace Skateshop.Models
{
    public class ShoppingCart
    {

        public long Id { get; set; }

        public List<Product> Products { get; set; }

    }
}
