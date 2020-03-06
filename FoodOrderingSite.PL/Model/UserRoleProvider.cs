using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Configuration;
using FoodOrderingSite.BLL.Interfaces;

namespace FoodOrderingSite.PL.Model
{
    public class UserRoleProvider : RoleProvider
    {
        private readonly IClientBL ClientBL;

        public UserRoleProvider()
        {
            ClientBL = DependencyResolver.ClientBL;
        }
        public override string[] GetRolesForUser(string username)
        {
           return  ClientBL.GetRolesForUser(username).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        #region NOTIMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}