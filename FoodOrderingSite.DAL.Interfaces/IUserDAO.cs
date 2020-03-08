using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IUserDAO
    {
        int Add(User user);
        bool DeleteById(int id);
        bool UpdateById(int id, User user);
        IEnumerable<User> GetAll();
        IEnumerable<string> GetRolesForUser(string login);
        User GetByLogin(string login);
        User GetById(int id);
        IEnumerable<Product> GetBasketById(int id);
        bool AddProductToBasketById(int userId, int productId);
        bool DeleteProductFromBasketById(int userId, int productId);
    }
}
