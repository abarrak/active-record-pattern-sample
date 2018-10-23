using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace ActiveRecordPattern
{
    public class Customer
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal TotalPurchases { get; set; }

        public Customer(int id, string name, int age, decimal totalPurchases)
        {
            Id = id;
            Name = name;
            Age = age;
            TotalPurchases = totalPurchases;
        }

        public static Customer Find(int id)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT TOP 1 * FROM [Customer] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    SqliteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        var name = (string)reader["Name"];
                        var age = (int)reader["Age"];
                        var totalPurchases = (decimal)reader["TotalPurchases"];

                        return new Customer(id, name, age, totalPurchases);
                    }
                }
            }
            return null;
        }

        public void Save()
        {
            if (Id == null || Id == 0)
            {
                Add();
            }
            else
            {
                Update();
            }

        }

        public bool Add()
        {
            return true;
        }

        public bool Update() 
        {
            return true;
        }

        public bool Delete()
        {
            using (SqliteConnection connection = DbConnection.Connection)
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM [Customer] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        //
        // Other methods (e.g. All(), FindBy*(), etc.) are usually provided in ORMs and
        // Active Record Pattern Implementations ..
        //
    }
}
