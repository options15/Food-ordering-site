using System.Collections.Generic;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
