﻿using Entities;
using FoodOrderingSite.BLL.Interfaces;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.BLL
{
    public class ClientBL : IClientBL
    {
        private readonly IClientDAO clientDAO;

        public ClientBL(IClientDAO clientDAO)
        {
            this.clientDAO = clientDAO;
        }

        public bool Add(Client client)
        {
            return clientDAO.Add(client);
        }

        public bool DeleteById(int id)
        {
            return clientDAO.DeleteById(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return clientDAO.GetAll();
        }

        public bool UpdateById(int id)
        {
            return clientDAO.UpdateById(id);
        }
    }
}
