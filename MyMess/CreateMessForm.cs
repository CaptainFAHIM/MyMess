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

namespace MyMess
{
    public partial class CreateMessForm : Form
    {
        private DbConnection _dbConnection;
        public CreateMessForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
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

            
            string tableName = messName.Text;

            // Validate that the table name
            if (!System.Text.RegularExpressions.Regex.IsMatch(tableName, "^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("The table name contains invalid characters. Only letters, numbers, and underscores are allowed.");
                return;
            }


            // SQL query to create the table
            string createTableQuery = $@"
        CREATE TABLE {tableName} (
            Members NVARCHAR(50),
            TotalDeposite DECIMAL(18, 2),
            TotalMeal INT,
            TotalCost DECIMAL(18, 2),
            Balance DECIMAL(18, 2)
        )";


            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    // Create and execute the SQL command
                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Table '{tableName}' created successfully.");
                }

                // Open the DashboardForm
                DashboardForm dashboardForm = new DashboardForm();
                dashboardForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }



            //// Create an instance of Form2
            //DashboardForm form4 = new DashboardForm();

            //// Show Form2
            //form4.Show();
            ////hide form 1
            //this.Hide();
        }
    }
}
