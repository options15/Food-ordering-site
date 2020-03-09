using System.Collections.Generic;

namespace Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
