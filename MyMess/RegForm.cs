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
    public partial class RegForm : Form
    {
        private DbConnection _dbConnection;
        public RegForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            LoginForm form2 = new LoginForm();

            // Show Form2
            form2.Show();
            //hide form 1
            this.Hide();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {

            string name = nameBox.Text.Trim();
            string email = emailBox.Text.Trim();
            string pass = passBox.Text.Trim();
            string passCheck = passCheckBox.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(passCheck))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            if (pass != passCheck)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }




            try
            {
                string query = "INSERT INTO users (Name, Email, Password) VALUES (@Name, @Email, @Password)";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", pass);

                    // Execute
                    connection.Open();
                    int rowsEffected = command.ExecuteNonQuery();

                    if (rowsEffected>0) {

                        MessageBox.Show("Rigistered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        query = "SELECT Email FROM users WHERE Email = @Email AND Password = @Password";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", pass);

                        string mail = command.ExecuteScalar()?.ToString();

                        // Navigate to Form3
                        // Create an instance of Form2
                        CreateMessForm createMessForm = new CreateMessForm(mail);

                        // Show Form2
                        createMessForm.Show();
                        //hide form 1
                        this.Hide();


                    }
                    
                }
            }

            catch (SqlException ex) when (ex.Number == 2627) // Unique constraint violation (e.g., duplicate email)
            {
                MessageBox.Show("Email already exists. Please use a different email.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            

        }
    }
}
