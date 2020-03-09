using Entities;
using System.Collections.Generic;

namespace FoodOrderingSite.BLL.Interfaces
{
    public interface IProductBL
    {
        bool Add(Product product);
        bool UpdateById(int id, Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(Category category);
        Product GetProductById(int id);
    }
}
