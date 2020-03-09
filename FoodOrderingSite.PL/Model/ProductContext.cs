using Configuration;
using Entities;
using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Collections.Generic;

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
            try
            {
                return productBL.GetAll();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(Category category)
        {

            try
            {
                return productBL.GetByCategory(category);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }

        public Product GetProductById(int id)
        {

            try
            {
                return productBL.GetProductById(id);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return null;
            }
        }

        public bool UpdateProductById(int id, Product product)
        {
            try
            {
                return productBL.UpdateById(id, product);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return false;
            }

        }

        public bool Add(Product product)
        {

            try
            {
                return productBL.Add(product);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.StackTrace);
                return false;
            }
        }
    }
}