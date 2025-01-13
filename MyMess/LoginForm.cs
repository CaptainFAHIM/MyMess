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
    public partial class LoginForm : Form
    {
        private DbConnection _dbConnection;
        public LoginForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            RegForm form1 = new RegForm();

            // Show Form2
            form1.Show();
            //hide form 1
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string pass = passBox.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Email and Password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            try
            {
                string query = "SELECT Role FROM users WHERE Email = @Email AND Password = @Password";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", pass);

                    // Execute the query and get the role
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString().Trim();

                        query = "SELECT Name FROM users WHERE Email = @Email AND Password = @Password";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", pass);

                        string name = command.ExecuteScalar()?.ToString();


                        if (role.Equals("Manager") || role.Equals("Member"))
                        {
                            // Role is either Manager or Member, show DashboardForm
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DashboardForm dashboardForm = new DashboardForm(name);
                            dashboardForm.Show();
                            this.Hide();
                        }
                        else if (role == "")
                        {
                            // Role is null (empty), show CreateMessForm
                            MessageBox.Show("Login successful, Create a mess or join a mess!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CreateMessForm createMessForm = new CreateMessForm();
                            createMessForm.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
