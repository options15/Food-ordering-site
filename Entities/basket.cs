using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Dictionary<Product, int> Products { get; set; }
    }
}
