using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.DAL.Interfaces;
using System.Collections.Generic;

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

        public IEnumerable<Product> GetAll()
        {
            return productDAO.GetAll();
        }

        public IEnumerable<Product> GetByCategory(Category category)
        {
            return productDAO.GetByCategory(category);
        }

        public Product GetProductById(int id)
        {
            return productDAO.GetProductById(id);
        }

        public bool UpdateById(int id, Product product)
        {
            return productDAO.UpdateById(id, product);
        }
    }
}
