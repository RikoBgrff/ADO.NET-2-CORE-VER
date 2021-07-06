using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO.NET_2_CORE_VER
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ConnectionString;
            using SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            Console.WriteLine(connection.State);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Cars";
            var data = command.ExecuteReader();
            Console.WriteLine(data.HasRows);
            Console.WriteLine(data.FieldCount);
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Console.WriteLine($"{data.GetValue(0)} -- {data.GetValue(1)} -- {data.GetValue(2)} -- {data.GetValue(3)} -- {data.GetValue(4)} -- {data.GetValue(5)} -- {data.GetValue(6)} -- {data.GetValue(7)} -- {data.GetValue(8)} -- {data.GetValue(9)}");

                }
            }

            connection.Close();

        }
    }
}
