using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IBasketDAO
    {
        bool Add(Basket basket);
        bool DeleteById(int id);
        bool UpdateById(int id);
        IEnumerable<Product> GetAll();
    }
}
