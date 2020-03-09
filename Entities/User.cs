using System.Collections.Generic;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public List<Order> Orders { get; set; }
        public Basket Basket { get; set; }
        public List<string> Roles { get; set; }
    }
}
