﻿using Entities;
using FoodOrderingSite.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FoodOrderingSite.DAL
{
    public class OrderDAO : IOrderDAO
    {
        private readonly string connectionString = @"Data Source=DESKTOP-RFR2OT2\SQLEXPRESS;Initial Catalog=FoodOrderingDB;Integrated Security=True;";
        public int Add(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddNewOrder";

                var UserIdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserId",
                    Value = order.UserId,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(UserIdParametr);

                var OrderIdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@OrderId",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(OrderIdParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return (int)OrderIdParametr.Value;
            }
        }

        public bool AddProductToOrderById(int orderId, Product[] products)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddProductToOrder";
                connection.Open();
                foreach (var item in products)
                {

                    var orderIdParametr = new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@OrderId",
                        Value = orderId,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(orderIdParametr);

                    var productIdParametr = new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ProductId",
                        Value = item.Id,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(productIdParametr);

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public IEnumerable<Product> GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetProductFromOrderById";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                var products = new List<Product>();
                while (result.Read())
                {
                    products.Add(new Product
                    {
                        Name = result["Name"] as string,
                        Сomposition = result["Сomposition"] as string,
                        Price = (int)result["Price"]
                    });
                }
                return products;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllOrders";

                connection.Open();
                var result = command.ExecuteReader();
                var orders = new List<Order>();
                while (result.Read())
                {
                    orders.Add(new Order
                    {
                        Id = (int)result["Id"],
                        Products = GetById((int)result["Id"]).ToList(),
                        Status = StatusById((int)result["Status"]),
                        UserId = (int)result["User_Id"]
                    });
                }
                return orders.ToArray();
            }
        }

        private string StatusById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetStatusById";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                result.Read();
                return result["Status"] as string;
            }
        }

        public IEnumerable<Order> GetByStatus(Status status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetOrderByStatus";

                var statusParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Status",
                    Value = status,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(statusParametr);

                connection.Open();
                var result = command.ExecuteReader();
                var orders = new List<Order>();
                while (result.Read())
                {
                    orders.Add(new Order
                    {
                        Id = (int)result["Id"],
                        Products = GetById((int)result["Id"]).ToList(),
                        Status = result["Status"] as string,
                        UserId = (int)result["User_Id"]
                    });
                }
                return orders.ToArray();
            }
        }

        public IEnumerable<Order> GetAllByUserId(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRolesForUser";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@UserLogin",
                    Value = userId,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                var roles = new List<Order>();
                while (result.Read())
                {
                    roles.Add(new Order
                    {
                        Id = (int)result["Id"],
                        Status = result["Status"] as string
                    });
                }
                return roles;
            }
        }

        public bool ChangeStatusById(int id, Status status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.ChangeOrderStatusById";

                var UserIdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@OrderId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(UserIdParametr);

                var OrderIdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Status",
                    Value = status,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(OrderIdParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
