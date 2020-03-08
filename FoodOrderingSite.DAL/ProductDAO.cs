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
    public class ProductDAO : IProductDAO
    {
        private readonly string connectionString = @"Data Source=DESKTOP-RFR2OT2\SQLEXPRESS;Initial Catalog=FoodOrderingDB;Integrated Security=True;";
        public bool Add(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllProduct";

                connection.Open();
                var result = command.ExecuteReader();
                var products = new List<Product>();
                while (result.Read())
                {
                    products.Add(new Product { 
                    Id = (int)result["Id"],
                    Name = result["Name"] as string,
                    Сomposition = result["Сomposition"] as string,
                    Image = result["ImageURL"] as string,
                    Price = (int)result["Price"]
                    });
                }
                return products.ToArray();
            }
        }

        public IEnumerable<Product> GetByCategory()
        {
            throw new NotImplementedException();
        }

        public bool UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
