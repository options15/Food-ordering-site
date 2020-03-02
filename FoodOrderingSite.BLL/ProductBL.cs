﻿using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL
{
    public class ProductBL : IProductBL
    {
        private readonly IProductDAO productDAO;

        public ProductBL(IProductDAO productDAO)
        {
            this.productDAO = productDAO;
        }

        public bool Add(Product product)
        {
            return productDAO.Add(product);
        }

        public bool DeleteById(int id)
        {
            return productDAO.DeleteById(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return productDAO.GetAll();
        }

        public IEnumerable<Order> GetByCategory()
        {
            return productDAO.GetByCategory();
        }

        public bool UpdateById(int id)
        {
            return productDAO.UpdateById(id);
        }
    }
}
