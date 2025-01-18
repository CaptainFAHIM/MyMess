using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class UpdateRoleForm : Form
    {
        private DbConnection _dbConnection;
        private string _messName;
        private string _umail;

        public UpdateRoleForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        public UpdateRoleForm(string messName, string uMail)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _messName = messName;
            _umail = uMail;
        }

        private void giveRoleBtn_Click(object sender, EventArgs e)
        {
            string newRole = null;
            string roleEmail = roleEmailTxt.Text;

            // Validate email
            if (string.IsNullOrEmpty(roleEmail))
            {
                MessageBox.Show("Please enter a valid Email.");
                return;
            }

            // Prevent updating the current user's own role
            if (roleEmail == _umail)
            {
                MessageBox.Show("You cannot change your own role.");
                return;
            }

            // Determine the new role
            if (managerRadio.Checked)
            {
                newRole = "Manager";
            }
            else if (memberRadio.Checked)
            {
                newRole = "Member";
            }

            // Validate role selection
            if (string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Check if the user's JoinedMess matches the current mess
                    string checkMessQuery = @"
                        SELECT COUNT(*) 
                        FROM users 
                        WHERE Email = @Email AND JoinedMess = @MessName";

                    using (SqlCommand checkCmd = new SqlCommand(checkMessQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", roleEmail);
                        checkCmd.Parameters.AddWithValue("@MessName", _messName);

                        int messMatchCount = (int)checkCmd.ExecuteScalar();

                        if (messMatchCount == 0)
                        {
                            MessageBox.Show("The user is not a member of this mess.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update role if the mess matches
                    string updateRoleQuery = @"
                        UPDATE users 
                        SET Role = @Role 
                        WHERE Email = @Email";

                    using (SqlCommand updateCmd = new SqlCommand(updateRoleQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Role", newRole);
                        updateCmd.Parameters.AddWithValue("@Email", roleEmail);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Role updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateRoleForm_Load(object sender, EventArgs e)
        {
        }
    }
}
