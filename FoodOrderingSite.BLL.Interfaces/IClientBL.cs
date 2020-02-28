﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL.Interfaces
{
    public interface IClientBL
    {
        bool Add(Client client);
        bool DeleteById(int id);
        IEnumerable<Client> GetAll();
    }
}
