using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL
{
    public class RoleBL : IRoleBL
    {
        private readonly IRoleDAO roleDAO;

        public RoleBL(IRoleDAO roleDAO)
        {
            this.roleDAO = roleDAO;
        }

        public bool Add(Role role)
        {
            return roleDAO.Add(role);
        }

        public bool DeleteById(int id)
        {
            return roleDAO.DeleteById(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return roleDAO.GetAll();
        }

        public Role GetById(int id)
        {
            return roleDAO.GetById(id);
        }

        public bool UpdateById(int id)
        {
            return roleDAO.UpdateById(id);
        }
    }
}
