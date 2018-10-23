using Microsoft.Data.Sqlite;

namespace ActiveRecordPattern
{
    public class DbConnection
    {
        public static SqliteConnection Connection { get; } =
            new SqliteConnection("" + new SqliteConnectionStringBuilder() { DataSource = "app-db.db" });
    }
}
