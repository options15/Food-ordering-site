using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL.Interfaces
{
    public interface IOrderBL
    {
        bool Add(Order order);
        bool DeleteById(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByCategory();
    }
}
