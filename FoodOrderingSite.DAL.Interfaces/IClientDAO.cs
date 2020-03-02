using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL.Interfaces
{
    public interface IClientDAO
    {
        bool Add(Client client);
        bool DeleteById(int id);
        bool UpdateById(int id);
        IEnumerable<Client> GetAll();
    }
}
