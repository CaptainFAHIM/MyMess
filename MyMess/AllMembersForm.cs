using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class AllMembersForm : Form
    {
        private DbConnection _dbConnection;
        private string _messName;
        private string _umail;

        public AllMembersForm()
        {
            InitializeComponent();
        }

        public AllMembersForm(string messName, string userMail)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _messName = messName;
            _umail = userMail;
        }

        private void AllMembersForm_Load(object sender, EventArgs e)
        {
            // Load user details into DataGridView when the form loads
            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            // SQL query to get Name, Email, and Role from users table based on the emails stored in the Members column of _messName
            string query = $@"
        SELECT u.Name AS 'Member Name', 
               m.Members AS 'Email', 
               u.Role AS 'Role'
        FROM [{_messName}] m
        INNER JOIN users u ON m.Members = u.Email";

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MessName", _messName);  // Remove if not required for dynamic table naming

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the data to DataGridView
                    dgvMembers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void newMonthYes_Click(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to delete a member.");
                return;
            }

            // Navigate
            DeleteMemberForm deleteMemberForm = new DeleteMemberForm(_messName, _umail);
            deleteMemberForm.StartPosition = FormStartPosition.CenterParent;
            deleteMemberForm.ShowDialog(); // This makes it a modal dialog

        }

        private void updateRoleBtn_Click(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to update role.");
                return;
            }
            // Navigate
            UpdateRoleForm updateRoleForm = new UpdateRoleForm(_messName, _umail);
            updateRoleForm.StartPosition = FormStartPosition.CenterParent;
            updateRoleForm.ShowDialog(); // This makes it a modal dialog

        }
    }
}
