using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Configuration;
using Entities;

namespace FoodOrderingSite.PL.Model
{
    public class ProductContext
    {
        private static readonly ProductContext productContext;
        private IProductBL productBL = DependencyResolver.ProductBL;

        static ProductContext()
        {
            productContext = new ProductContext();
        }

        public static ProductContext GetInstance => productContext;

        public IEnumerable<Product> Products()
        { 
        return productBL.GetAll();
        }
    }
}