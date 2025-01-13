using System.Data.SqlClient;

public class DbConnection
{
    private readonly string connectionString = "Data Source=DESKTOP-KTOGEOI\\SQLEXPRESS;Initial Catalog=MyMess;Integrated Security=True;TrustServerCertificate=True";

    // Method to create and return a SQL connection
    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
