using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class AddMemberForm : Form
    {
        private DbConnection _dbConnection;
        private string _mail;
        private string _messName;

        public AddMemberForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        public AddMemberForm(string email, string messName)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _mail = email;
            _messName = messName;
        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {
            string mail = addMemberMail.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Email required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!mail.Contains("@") || !mail.Contains("."))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    // Step 1: Check if the user exists and is not already in a mess
                    string selectQuery = "SELECT Role, Name, Email, JoinedMess FROM users WHERE Email = @Email";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Email", mail);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString().Trim();
                                string joinedMess = reader["JoinedMess"]?.ToString();

                                // Check if the user is already in a mess
                                if ((role.Equals("Manager") || role.Equals("Member")) || !string.IsNullOrEmpty(joinedMess))
                                {
                                    MessageBox.Show("This member is already in a mess.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid email.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Step 2: Update the user's JoinedMess column and Role, and add to the mess table
                    string updateUserQuery = "UPDATE users SET JoinedMess = @MessName, Role = @Role WHERE Email = @Email";
                    string insertMemberQuery = $"INSERT INTO {_messName} (Members) VALUES (@Email)";

                    using (SqlCommand updateCommand = new SqlCommand(updateUserQuery, connection))
                    using (SqlCommand insertCommand = new SqlCommand(insertMemberQuery, connection))
                    {
                        // Update the user's JoinedMess column and Role
                        updateCommand.Parameters.AddWithValue("@MessName", _messName);
                        updateCommand.Parameters.AddWithValue("@Role", "Member");
                        updateCommand.Parameters.AddWithValue("@Email", mail);
                        updateCommand.ExecuteNonQuery();

                        // Insert the user into the mess table
                        insertCommand.Parameters.AddWithValue("@Email", mail);
                        insertCommand.ExecuteNonQuery();
                    }

                    // Success message
                    MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) when (ex.Number == 2627) // Handle unique constraint violations
            {
                MessageBox.Show("Email is already associated with another mess.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
