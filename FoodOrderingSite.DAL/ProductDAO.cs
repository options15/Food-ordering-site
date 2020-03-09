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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddNewProduct";

                var nameParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductName",
                    Value = product.Name,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(nameParametr);

                var compositionParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductСomposition",
                    Value = product.Сomposition,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(compositionParametr);

                var priceParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ProductPrice",
                    Value = product.Price,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(priceParametr);

                var imageParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductImage",
                    Value = product.Image,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(imageParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
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

        public IEnumerable<Product> GetByCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetProductByCategory";

                var categoryParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Category",
                    Value = category,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(categoryParametr);

                connection.Open();
                var result = command.ExecuteReader();
                var products = new List<Product>();
                while (result.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)result["Id"],
                        Name = result["Name"] as string,
                        Сomposition = result["Сomposition"] as string,
                        Image = result["ImageURL"] as string,
                        Price = (int)result["Price"],
                        Category = category
                    });
                }
                return products.ToArray();
            }
        }

        public Product GetProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetProductById";

                var idParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ProductId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);

                connection.Open();
                var result = command.ExecuteReader();
                if (!result.Read())
                {
                    return null;
                }
                var product = new Product
                {
                    Id = id,
                    Name = result["Name"] as string,
                    Category = (Category)result["Category"],
                    Price = (int)result["Price"],
                    Image = result["ImageURL"] as string,
                    Сomposition = result["Сomposition"] as string
                };

                return product;
            }
        }

        public bool UpdateById(int id, Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateProductById";

                var IdParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ProductId",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(IdParametr);

                var nameParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductName",
                    Value = product.Name,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(nameParametr);

                var compositionParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductСomposition",
                    Value = product.Сomposition,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(compositionParametr);

                var priceParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ProductPrice",
                    Value = product.Price,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(priceParametr);

                var imageParametr = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductImage",
                    Value = product.Image,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(imageParametr);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
