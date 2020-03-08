using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL.Interfaces
{
    public interface IUserBL
    {
        int Add(User client);
        bool DeleteById(int id);
        bool UpdateById(int id, User user);
        User GetById(int id);
        User GetByLogin(string login);
        IEnumerable<User> GetAll();
        IEnumerable<string> GetRolesForUser(string login);
        IEnumerable<Product> GetBasketById(int id);
        bool AddProductToBasketById(int id, int productId);
        bool DeleteProductFromBasketById(int userId, int productId);
    }
}
