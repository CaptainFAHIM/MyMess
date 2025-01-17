using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class CostsForm : Form
    {
        private DbConnection _dbConnection;
        private string _messName;

        public CostsForm(string messName)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _messName = messName;
        }

        private void addCostBtn_Click(object sender, EventArgs e)
        {
            string costText = addCostTxt.Text;
            string note = noteTxt.Text;

            // Validate the cost input
            if (string.IsNullOrEmpty(costText) || !decimal.TryParse(costText, out decimal costAmount))
            {
                MessageBox.Show("Please enter a valid cost amount.");
                return;
            }

            string insertCostQuery = @"
                INSERT INTO Costs (CostAmount, CostDate, MessName, Note)
                VALUES (@CostAmount, GETDATE(), @MessName, @Note)";

            string getMemberCountQuery = $@"
                SELECT COUNT(*) 
                FROM [{_messName}]";

            string updateBalanceQuery = $@"
                UPDATE [{_messName}]
                SET Balance = Balance - @PerMemberCost";

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insert the cost record into the Costs table
                            using (SqlCommand insertCommand = new SqlCommand(insertCostQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@CostAmount", costAmount);
                                insertCommand.Parameters.AddWithValue("@MessName", _messName);
                                insertCommand.Parameters.AddWithValue("@Note", note);
                                insertCommand.ExecuteNonQuery();
                            }

                            // Get the total number of members in the mess
                            int memberCount = 0;
                            using (SqlCommand countCommand = new SqlCommand(getMemberCountQuery, connection, transaction))
                            {
                                memberCount = (int)countCommand.ExecuteScalar();
                            }

                            if (memberCount == 0)
                            {
                                throw new Exception("No members found in the mess.");
                            }

                            // Calculate per-member cost
                            decimal perMemberCost = costAmount / memberCount;

                            // Deduct the cost from each member's balance
                            using (SqlCommand updateCommand = new SqlCommand(updateBalanceQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@PerMemberCost", perMemberCost);
                                updateCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Cost added and deducted from members' balances successfully!");
                            addCostTxt.Clear();
                            noteTxt.Clear();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while processing cost: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
