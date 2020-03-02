﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
    }
}
