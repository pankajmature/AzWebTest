using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{
    public class ProductService
    {
        static readonly string db_source = "xaappdbserver.database.windows.net";

        static readonly string db_username = "sqladmin";

        static readonly string db_password = "2j5$Q1p8E&7jAX";

        static readonly string db_database = "xappdb";

        private static SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = db_source,
                UserID = db_username,
                Password = db_password,
                InitialCatalog = db_database
            };

            return new SqlConnection(builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection sqlConnection = GetConnection();

            List<Product> products = new List<Product>();

            string query = "SELECT ProductId, ProductName, Quantity From Products";

            sqlConnection.Open();

            SqlCommand cmd = new(query, sqlConnection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantiy = reader.GetInt32(2)
                    };

                    products.Add(product);
                }
            }

            sqlConnection.Close();

            return products;

        }

    }

}
