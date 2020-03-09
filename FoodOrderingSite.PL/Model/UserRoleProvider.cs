using Configuration;
using FoodOrderingSite.BLL.Interfaces;
using System;
using System.Linq;
using System.Web.Security;

namespace FoodOrderingSite.PL.Model
{
    public class UserRoleProvider : RoleProvider
    {
        private readonly IUserBL UserBL;

        public UserRoleProvider()
        {
            UserBL = DependencyResolver.UserBL;
        }
        public override string[] GetRolesForUser(string username)
        {
            return UserBL.GetRolesForUser(username).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return GetRolesForUser(username).Contains(roleName);
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