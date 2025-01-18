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
    public partial class ResetMonthForm : Form
    {
        private string _messName;
        private DbConnection _dbConnection;
        public ResetMonthForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }
        public ResetMonthForm(string messName)
        {
            InitializeComponent();
            _messName = messName;
            _dbConnection = new DbConnection();
        }

        private void newMonthNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newMonthYes_Click(object sender, EventArgs e)
        {
            // Get new month name from the textbox
            string newMonthName = newMonthNameTxt.Text;

            string messName = _messName; 


            if (string.IsNullOrEmpty(newMonthName)) {
                MessageBox.Show("Please enter a valid month name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Update mess table
                    string updateMessQuery = $@"
                UPDATE [{messName}]
                SET ActiveMonth = @NewMonthName,
                    StartDate = GETDATE(),
                    TotalDeposites = 0,
                    TotalMeals = 0,
                    Balance = 0";

                    using (SqlCommand updateMessCmd = new SqlCommand(updateMessQuery, conn))
                    {
                        updateMessCmd.Parameters.AddWithValue("@NewMonthName", newMonthName);
                        updateMessCmd.ExecuteNonQuery();
                    }

                    // Delete from Costs table
                    string deleteCostsQuery = "DELETE FROM Costs WHERE MessName = @MessName";
                    using (SqlCommand deleteCostsCmd = new SqlCommand(deleteCostsQuery, conn))
                    {
                        deleteCostsCmd.Parameters.AddWithValue("@MessName", messName);
                        deleteCostsCmd.ExecuteNonQuery();
                    }

                    // Delete from Deposites table
                    string deleteDepositesQuery = "DELETE FROM Deposites WHERE MessName = @MessName";
                    using (SqlCommand deleteDepositesCmd = new SqlCommand(deleteDepositesQuery, conn))
                    {
                        deleteDepositesCmd.Parameters.AddWithValue("@MessName", messName);
                        deleteDepositesCmd.ExecuteNonQuery();
                    }

                    // Delete from Meals table
                    string deleteMealsQuery = "DELETE FROM Meals WHERE MessName = @MessName";
                    using (SqlCommand deleteMealsCmd = new SqlCommand(deleteMealsQuery, conn))
                    {
                        deleteMealsCmd.Parameters.AddWithValue("@MessName", messName);
                        deleteMealsCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Month has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
