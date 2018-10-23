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
        public double TotalPurchases { get; set; }

        public Customer(string name, int age, double totalPurchases, int? id = null)
        {
            Name = name;
            Age = age;
            TotalPurchases = totalPurchases;
            Id = id;
        }

        public static Customer Find(int id)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Customer WHERE Id = @Id LIMIT 1";
                    command.Parameters.AddWithValue("@Id", id);

                    SqliteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        var name = (string)reader["Name"];
                        var age = (int)(long)reader["Age"];
                        var totalPurchases = (double)reader["TotalPurchases"];

                        return new Customer(name, age, totalPurchases, id);
                    }
                }
            }
            return null;
        }

        public bool Save()
        {
            if (Id == null || Id == 0)
            {
                return Add();
            }
            else
            {
                return Update();
            }

        }

        public bool Add()
        {
            using (SqliteConnection connection = DbConnection.Connection)
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Customer VALUES(NULL, @N, @A, 1000.5)";
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@N", Name);
                    command.Parameters.AddWithValue("@A", Age);
                    command.Parameters.AddWithValue("@TP", TotalPurchases);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool Update() 
        {
            using (SqliteConnection connection = DbConnection.Connection)
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Customer SET Name = @N, Age = @A, TotalPurchases = @TP WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@N", Name);
                    command.Parameters.AddWithValue("@A", Age);
                    command.Parameters.AddWithValue("@TP", TotalPurchases);
                    command.ExecuteNonQuery();
                }
            }
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
                    command.CommandText = "DELETE FROM Customer WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public static Customer Last() 
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Customer Order By Id DESC LIMIT 1";

                    SqliteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        var id = (int)(long)reader["Id"];
                        var name = (string)reader["Name"];
                        var age = (int)(long)reader["Age"];
                        var totalPurchases = (double)reader["TotalPurchases"];

                        return new Customer(name, age, totalPurchases, id);
                    }
                }
            }
            return null;
        }

        //
        // Other methods (e.g. All(), FindBy*(), First(), Last(), etc.) are usually provided in ORMs and
        // Active Record Pattern Implementations ..
        //

        public override string ToString()
        {
            return $"{Id} - Name: {Name} - Age: {Age} - Total Purchase: {TotalPurchases}";
        }
    }
}
