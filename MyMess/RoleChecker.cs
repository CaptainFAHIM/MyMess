using System;
using System.Data.SqlClient;

public static class RoleChecker
{
    public static string GetUserRole(string email, DbConnection dbConnection)
    {
        string role = string.Empty;

        string query = "SELECT Role FROM users WHERE email = @Email";

        try
        {
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = reader["Role"]?.ToString().Trim();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while retrieving user role: {ex.Message}");
        }

        return role;
    }
}
