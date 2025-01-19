using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyMess
{
    public partial class PasswordChangeForm : Form
    {
        private DbConnection _dbConnection;
        private string _umail;

        public PasswordChangeForm()
        {
            InitializeComponent();
        }

        public PasswordChangeForm(string userMail)
        {
            InitializeComponent();
            _umail = userMail;
            _dbConnection = new DbConnection();
        }

        private void passChangeBtn_Click(object sender, EventArgs e)
        {
            string newPassword = passChangeTxt.Text.Trim();
            string confirmPassword = passChangeRetypeTxt.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Both fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE users SET Password = @Password WHERE Email = @Email";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Email", _umail);

                    // Execute the query
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
