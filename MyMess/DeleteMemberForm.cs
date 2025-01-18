using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class DeleteMemberForm : Form
    {
        private DbConnection _dbConnection;
        private string _messName;
        private string _uName;

        public DeleteMemberForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        public DeleteMemberForm(string messName, string uName)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _messName = messName;
            _uName = uName;
        }

        private void deleteMemberBtn_Click(object sender, EventArgs e)
        {
            string deleteMember = deleteMemberTxt.Text;

            if (deleteMember == _uName)
            {
                MessageBox.Show("You can't delete yourself from the mess", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();

                        // Delete the member from the _messName table
                        string deleteFromMessQuery = $@"DELETE FROM [{_messName}] WHERE Members = @Member";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteFromMessQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@Member", deleteMember);
                            deleteCmd.ExecuteNonQuery();
                        }

                        // Update Role and JoinedMess to NULL in the users table
                        string updateUserQuery = @"
                            UPDATE users 
                            SET Role = NULL, 
                                JoinedMess = NULL 
                            WHERE Email = @Member";
                        using (SqlCommand updateCmd = new SqlCommand(updateUserQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@Member", deleteMember);
                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Member deleted successfully and user details updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
