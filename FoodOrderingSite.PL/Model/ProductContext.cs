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

        public IEnumerable<Product> GetProductsByCategory( Category category)
        {
            return productBL.GetByCategory(category);
        }

        public Product GetProductById(int id)
        {
            return productBL.GetProductById(id);
        }

        public bool UpdateProductById(int id, Product product)
        {
            return productBL.UpdateById(id, product);
        }

        public bool Add(Product product)
        {
            return productBL.Add(product);
        }
    }
}