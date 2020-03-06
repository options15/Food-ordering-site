using Entities;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSite.DAL
{
    public class UserDAO : IUserDAO
    {

        private readonly string connectionString = @"Data Source=DESKTOP-RFR2OT2\SQLEXPRESS;Initial Catalog=FoodOrderingDB;Integrated Security=True;";
        public bool Add(User client)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRolesForUser";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserLogin",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                var user = new User
                {
                    Name = result["Name"] as string,
                    Address = result["Address"] as string,
                    Phone = result["Phone"] as string,
                    Login = login,
                    Password = result["Password"] as string
                };

                return user;
            }
        }

        public IEnumerable<string> GetRolesForUser(string login)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRolesForUser";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserLogin",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                var roles = new List<string>();
                while (result.Read())
                {
                    roles.Add(result["Status"] as string);
                }
                return roles.ToArray();
            }
        }

        public bool UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
