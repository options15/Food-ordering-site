﻿using Entities;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL
{
    public class ProductDAO : IProductDAO
    {
        public bool Add(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetByCategory()
        {
            throw new NotImplementedException();
        }

        public bool UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}