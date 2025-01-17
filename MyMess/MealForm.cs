using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMess
{
    public partial class MealForm : Form
    {
        private DbConnection _dbConnection;
        private string _messName;

        public MealForm(string messName)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _messName = messName;
        }

        private void addAmmountBtn_Click(object sender, EventArgs e)
        {
            string mealAmountText = mealAmountTxt.Text;
            string mealCostText = mealCostTxt.Text;

            // Validate mealAmount and mealCost
            if (string.IsNullOrEmpty(mealAmountText) || !int.TryParse(mealAmountText, out int mealAmount))
            {
                MessageBox.Show("Please enter a valid number of meals.");
                return;
            }

            if (string.IsNullOrEmpty(mealCostText) || !decimal.TryParse(mealCostText, out decimal mealCost))
            {
                MessageBox.Show("Please enter a valid meal cost.");
                return;
            }

            decimal totalCostPerMember = mealAmount * mealCost;

            string insertMealQuery = $@"
                INSERT INTO Meals (MemberEmail, MealCount, MealDate, MessName, MealCost)
                SELECT Members, @MealCount, GETDATE(), @MessName, @MealCost
                FROM [{_messName}]";

            string updateMessQuery = $@"
                UPDATE [{_messName}]
                SET TotalMeals = TotalMeals + @MealCount,
                    Balance = Balance - @MealCost";

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insert meals for all members
                            using (SqlCommand insertCommand = new SqlCommand(insertMealQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@MealCount", mealAmount);
                                insertCommand.Parameters.AddWithValue("@MessName", _messName);
                                insertCommand.Parameters.AddWithValue("@MealCost", totalCostPerMember);
                                insertCommand.ExecuteNonQuery();
                            }

                            // Update mess table for all members
                            using (SqlCommand updateCommand = new SqlCommand(updateMessQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@MealCount", mealAmount);
                                updateCommand.Parameters.AddWithValue("@MealCost", totalCostPerMember);
                                updateCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Meals added successfully for all members!");
                            mealAmountTxt.Clear();
                            mealCostTxt.Clear();
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
                MessageBox.Show($"Error while adding meals: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
