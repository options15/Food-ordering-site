﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public string Catehory { get; set; }
        public List<Product> Products { get; set; }
    }
}
