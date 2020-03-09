using Entities;
using FoodOrderingSite.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FoodOrderingSite.DAL
{
    public class UserDAO : IUserDAO
    {

        private readonly string connectionString = @"Data Source=DESKTOP-RFR2OT2\SQLEXPRESS;Initial Catalog=FoodOrderingDB;Integrated Security=True;";
        public int Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddNewUser";

                var IdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(IdParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return (int)IdParametr.Value;
            }
        }

        public bool AddProductToBasketById(int userId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddProductToBasketById";

                var userParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(userParametr);

                var productParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ProductId",
                    Value = productId,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(productParametr);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductFromBasketById(int userId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteProductFromBasketById";

                var UserIdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(UserIdParametr);

                var ProductIdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ProductId",
                    Value = productId,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(ProductIdParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetBasketById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetBasketUserById";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();

                var basket = new List<Product>();
                while (result.Read())
                {
                    basket.Add(new Product
                    {
                        Id = (int)result["Id"],
                        Name = result["Name"] as string,
                        Сomposition = result["Сomposition"] as string,
                        Image = result["ImageURL"] as string,
                        Price = (int)result["Price"]
                    });
                };
                return basket.ToArray();
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                result.Read();
                var user = new User
                {
                    Id = id,
                    Name = result["Name"] as string,
                    Address = result["Address"] as string,
                    Phone = result["Phone"] as string,
                    Login = result["Login"] as string,
                    Password = result["Password"] as string
                };
                return user;
            }
        }

        public User GetByLogin(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetByLogin";

                var loginParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserLogin",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParametr);

                connection.Open();
                var result = command.ExecuteReader();
                result.Read();
                var user = new User
                {
                    Id = (int)result["Id"],
                    Name = result["Name"] as string,
                    Address = result["Address"] as string,
                    Phone = result["Phone"] as string,
                    Login = login,
                    Password = result["Password"] as string
                };
                return user;
            }
        }

        public IEnumerable<string> GetRolesForUser(string UserId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRolesForUser";

                var loginParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserId",
                    Value = int.Parse(UserId),
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParametr);

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

        public bool Registration(int id, User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.Registration";

                var IdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(IdParametr);

                var loginParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserLogin",
                    Value = user.Login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParametr);

                var passwordParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserPassword",
                    Value = user.Password,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(passwordParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool UpdateById(int id, User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.UserUpdate";

                var IdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(IdParametr);

                var nameParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserName",
                    Value = user.Name,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(nameParametr);

                var loginParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserLogin",
                    Value = user.Login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParametr);

                var passwordParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserPassword",
                    Value = user.Password,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(passwordParametr);

                var addressParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserAddress",
                    Value = user.Address,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(addressParametr);

                var phoneParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserPhone",
                    Value = user.Phone,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(phoneParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
