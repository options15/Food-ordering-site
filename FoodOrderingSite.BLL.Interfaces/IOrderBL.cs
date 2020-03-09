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
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByStatus(Status status);
        IEnumerable<Order> GetAllByUserId(int userId);

        bool ChangeStatusById(int id, Status status);
    }
}
