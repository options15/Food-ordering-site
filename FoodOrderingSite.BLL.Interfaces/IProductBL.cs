using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL.Interfaces
{
    public interface IProductBL
    {
        bool Add(Product product);
        bool DeleteById(int id);
        bool UpdateById(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByCategory();
    }
}
