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
        int Add(Order order);
        bool DeleteById(int id);
        bool UpdateById(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByCategory();
        IEnumerable<Order> GetAllByUserId(int userId);
    }
}
