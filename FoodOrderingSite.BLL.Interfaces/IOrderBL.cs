using Entities;
using System.Collections.Generic;

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
