using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class DepositeForm : Form
    {
        private DbConnection _dbConnection;
        private string _uMail;
        private string _messName;

        public DepositeForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        public DepositeForm(string uMail, string messName)
        {
            InitializeComponent();
            _uMail = uMail;
            _dbConnection = new DbConnection();
            _messName = messName;
        }

        private void addAmmountBtn_Click(object sender, EventArgs e)
        {
            string depositAmountText = depositeAmmountTxt.Text;

            // Validate the deposit amount and selected user
            if (string.IsNullOrEmpty(depositAmountText))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            if (selectUserCombo.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.");
                return;
            }

            // Convert depositAmountText to decimal
            if (!decimal.TryParse(depositAmountText, out decimal depositAmount))
            {
                MessageBox.Show("Please enter a valid numeric amount.");
                return;
            }

            string selectedMember = selectUserCombo.Text; // Get the selected member from the ComboBox

            // Query to update the mess table
            string updateMessQuery = $@"
                UPDATE [{_messName}]
                SET TotalDeposites = TotalDeposites + @DepositAmount,
                    Balance = Balance + @DepositAmount
                WHERE Members = @MemberName";

            // Query to insert into Deposites table
            string insertDepositQuery = @"
                INSERT INTO Deposites (Name, Email, DepositeAmount, JoinedMess, DepositeDate)
                SELECT Name, Email, @DepositAmount, @JoinedMess, GETDATE()
                FROM Users
                WHERE Email = @MemberEmail";

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    // Start a transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update the mess table
                            using (SqlCommand updateCommand = new SqlCommand(updateMessQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@DepositAmount", depositAmount);
                                updateCommand.Parameters.AddWithValue("@MemberName", selectedMember);

                                updateCommand.ExecuteNonQuery();
                            }

                            // Insert into Deposites table
                            using (SqlCommand insertCommand = new SqlCommand(insertDepositQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@DepositAmount", depositAmount);
                                insertCommand.Parameters.AddWithValue("@JoinedMess", _messName);
                                insertCommand.Parameters.AddWithValue("@MemberEmail", selectedMember);

                                insertCommand.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("Deposit added successfully!");
                            depositeAmmountTxt.Clear(); // Clear the input field
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // Re-throw the exception after rollback
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while adding deposit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DepositeForm_Load(object sender, EventArgs e)
        {
            string query = $"SELECT Members FROM [{_messName}]"; // Query to fetch data

            try
            {
                // Create a connection
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    // Create a DataAdapter to execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the ComboBox to the DataTable
                    selectUserCombo.DataSource = dataTable;
                    selectUserCombo.DisplayMember = "Members";  // Column to display
                    selectUserCombo.ValueMember = "Members";    // Use "Members" as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // This event is unused in this context.
        }

        private void selectUserCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add logic here if something needs to happen when the user selection changes.
        }
    }
}
