using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IProductDAO
    {
        bool Add(Product product);
        bool DeleteById(int id);
        bool UpdateById(int id, Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(Category category);
        Product GetProductById(int id);
    }
}
