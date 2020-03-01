using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Basket
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public List<Product> Products { get; set; }
    }
}
