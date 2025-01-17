using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace MyMess
{
    public partial class CreateMessForm : Form
    {
        private DbConnection _dbConnection;
        private string _mailForMess;

        public CreateMessForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        public CreateMessForm(string mailForMess)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _mailForMess = mailForMess;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(messName.Text))
            {
                MessageBox.Show("Please enter a valid mess name.");
                return;
            }

            string sanitizedEmail = _mailForMess.Replace("@", "_").Replace(".", "_");
            string tableName = messName.Text + "_" + sanitizedEmail;

            // Fetch the active month value
            string actvMnth = activeMonth.Text;

            // SQL query to create the table
            string createTableQuery = $@"
CREATE TABLE {tableName} (
    ActiveMonth NVARCHAR(50),
    StartDate DATETIME,
    Members NVARCHAR(50),
    TotalDeposites DECIMAL(18, 2) DEFAULT 0,
    TotalMeals INT DEFAULT 0,
    TotalCosts DECIMAL(18, 2) DEFAULT 0,
    Balance DECIMAL(18, 2) DEFAULT 0
    
)";

            // SQL query to insert both the email and the active month in the same row
            string insertEmailAndMonthQuery = $@"
INSERT INTO {tableName} (Members, ActiveMonth, StartDate) 
VALUES (@Email, @ActiveMonth, @StartDate)";

            // SQL query to update the Role and JoinedMess columns in the users table
            string updateUserQuery = $@"
UPDATE users 
SET Role = 'Manager', 
    JoinedMess = @TableName 
WHERE email = @Email";

            // SQL query to fetch Name and JoinedMess for the email
            string fetchUserQuery = $@"
SELECT Name, JoinedMess 
FROM users 
WHERE email = @Email";

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    // Create and execute the SQL command to create the table
                    using (SqlCommand createCommand = new SqlCommand(createTableQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                    }

                    // Insert both the email and active month into the same row
                    using (SqlCommand insertCommand = new SqlCommand(insertEmailAndMonthQuery, connection))
                    {
                        DateTime currentDate = DateTime.Now;
                        insertCommand.Parameters.AddWithValue("@Email", _mailForMess);
                        insertCommand.Parameters.AddWithValue("@ActiveMonth", actvMnth);
                        insertCommand.Parameters.AddWithValue("@StartDate", currentDate);
                        insertCommand.ExecuteNonQuery();
                    }

                    // Update the Role and JoinedMess columns in the users table
                    using (SqlCommand updateCommand = new SqlCommand(updateUserQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Email", _mailForMess);
                        updateCommand.Parameters.AddWithValue("@TableName", tableName);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Fetch Name and JoinedMess for the email
                    string userName = string.Empty;
                    string joinedMess = string.Empty;

                    using (SqlCommand fetchCommand = new SqlCommand(fetchUserQuery, connection))
                    {
                        fetchCommand.Parameters.AddWithValue("@Email", _mailForMess);
                        using (SqlDataReader reader = fetchCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userName = reader["Name"].ToString();
                                joinedMess = reader["JoinedMess"].ToString();
                            }
                        }
                    }

                    // Pass the fetched data to the DashboardForm
                    DashboardForm dashboardForm = new DashboardForm(userName, joinedMess, _mailForMess);
                    dashboardForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
