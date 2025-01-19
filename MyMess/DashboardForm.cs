using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyMess
{
    public partial class DashboardForm : Form
    {
        private string _uname;
        private string _umail;
        private string _messName;
        private DbConnection _dbConnection;

        public DashboardForm()
        {
            InitializeComponent();
        }

        public DashboardForm(string uname, string messName, string umail)
        {
            InitializeComponent();
            _uname = uname;
            _messName = messName;
            _umail = umail;
            _dbConnection = new DbConnection();

            changePassTxt.Visible = false; // Initially hidden
            newMonthTxt.Visible = false; // Initially hidden
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            messName.Text = _messName.Split('_')[0];
            profileName.Text = _uname;

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    // Fetch Mess Balance
                    string messBalanceQuery = $@"SELECT SUM(Balance) FROM [{_messName}]";
                    using (SqlCommand command = new SqlCommand(messBalanceQuery, connection))
                    {
                        object balanceResult = command.ExecuteScalar();
                        messBalanceTxt.Text = balanceResult != null ? balanceResult.ToString() : "0";
                    }

                    // Fetch Total Deposit
                    string totalDepositQuery = @"
                SELECT ISNULL(SUM(DepositAmount), 0)
                FROM Deposites
                WHERE MessName = @MessName";
                    using (SqlCommand command = new SqlCommand(totalDepositQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MessName", _messName);
                        object depositResult = command.ExecuteScalar();
                        totalDepositeTxt.Text = depositResult != null ? depositResult.ToString() : "0";
                    }

                    // Fetch Total Meal
                    string totalMealQuery = $@"
                SELECT ISNULL(SUM(TotalMeals), 0)
                FROM [{_messName}]";
                    using (SqlCommand command = new SqlCommand(totalMealQuery, connection))
                    {
                        object mealResult = command.ExecuteScalar();
                        totalMealTxt.Text = mealResult != null ? mealResult.ToString() : "0";
                    }

                    // Fetch Total Meal Cost
                    string totalMealCostQuery = @"
                SELECT ISNULL(SUM(MealCost), 0)
                FROM Meals
                WHERE MessName = @MessName";
                    using (SqlCommand command = new SqlCommand(totalMealCostQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MessName", _messName);
                        object mealCostResult = command.ExecuteScalar();
                        totalMealCostTxt.Text = mealCostResult != null ? mealCostResult.ToString() : "0";
                    }

                    // Fetch Total Cost
                    string totalCostQuery = @"
                SELECT ISNULL(SUM(CostAmount), 0)
                FROM Costs
                WHERE MessName = @MessName";
                    using (SqlCommand command = new SqlCommand(totalCostQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MessName", _messName);
                        object costResult = command.ExecuteScalar();
                        totalCostTxt.Text = costResult != null ? costResult.ToString() : "0";
                    }

                    //My info
                    string myBalanceQuery = $@"
                SELECT Balance
                FROM [{_messName}]
                WHERE Members = @Members";
                    using (SqlCommand command = new SqlCommand(myBalanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Members", _umail);
                        object balanceResult = command.ExecuteScalar();
                        myBalanceTxt.Text = balanceResult != null ? balanceResult.ToString() : "0";
                    }

                    //My deposit info
                    string myDepositQuery = $@"
                SELECT TotalDeposites
                FROM [{_messName}]
                WHERE Members = @Members";
                    using (SqlCommand command = new SqlCommand(myDepositQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Members", _umail);
                        object depositResult = command.ExecuteScalar();
                        myDepositeTxt.Text = depositResult != null ? depositResult.ToString() : "0"; //myDepositeTxt
                    }


                    //My meal count info
                    string myMealQuery = $@"
                SELECT TotalMeals
                FROM [{_messName}]
                WHERE Members = @Members";
                    using (SqlCommand command = new SqlCommand(myMealQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Members", _umail);
                        object depositResult = command.ExecuteScalar();
                        myTotalMealTxt.Text = depositResult != null ? depositResult.ToString() : "0"; //myDepositeTxt
                    }

                    //My meal total cost info
                    string myMealCostQuery = @"
                SELECT ISNULL(SUM(MealCost), 0)
                FROM Meals
                WHERE MemberEmail = @MemberEmail";
                    using (SqlCommand command = new SqlCommand(myMealCostQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MemberEmail", _umail);
                        object myMealCostResult = command.ExecuteScalar();
                        myMealCostTxt.Text = myMealCostResult != null ? myMealCostResult.ToString() : "0";
                    }



                    // Fetch Active Month
                    string activeMonthQuery = $@"SELECT ActiveMonth FROM [{_messName}] WHERE ActiveMonth IS NOT NULL";
                    using (SqlCommand command = new SqlCommand(activeMonthQuery, connection))
                    {
                        object result = command.ExecuteScalar();
                        activeMonthLabel.Text = result != null ? result.ToString() : "No active month found.";
                    }

                    // Fetch Start Date and Calculate Days Passed
                    string startDateQuery = $@"SELECT StartDate FROM [{_messName}] WHERE StartDate IS NOT NULL";
                    using (SqlCommand command = new SqlCommand(startDateQuery, connection))
                    {
                        object startDateResult = command.ExecuteScalar();
                        if (startDateResult != null)
                        {
                            DateTime startDate = Convert.ToDateTime(startDateResult);
                            DateTime currentDate = DateTime.Now;
                            int daysPassed = (currentDate - startDate).Days;
                            dayCount.Text = daysPassed.ToString();
                        }
                        else
                        {
                            dayCount.Text = "Start date not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label25_Click(object sender, EventArgs e)
        {
        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to add a member.");
                return;
            }

                // Navigate to AddMemberForm
                AddMemberForm addMemberForm = new AddMemberForm(_umail, _messName);
                addMemberForm.StartPosition = FormStartPosition.CenterParent;
                addMemberForm.ShowDialog(); // This makes it a modal dialog
            
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to deposite.");
                return;
            }
            // Navigate
            DepositeForm depositeForm = new DepositeForm(_umail, _messName);
            depositeForm.StartPosition = FormStartPosition.CenterParent;
            depositeForm.ShowDialog(); // This makes it a modal dialog

        }

        private void label7_Click(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to add meal.");
                return;
            }
            // Navigate
            MealForm mealForm = new MealForm(_messName);
            mealForm.StartPosition = FormStartPosition.CenterParent;
            mealForm.ShowDialog(); // This makes it a modal dialog

        }

        private void label8_Click(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to add meal.");
                return;
            }
            // Navigate
            CostsForm costsForm = new CostsForm(_messName);
            costsForm.StartPosition = FormStartPosition.CenterParent;
            costsForm.ShowDialog(); // This makes it a modal dialog
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm(_uname, _messName, _umail);
            dashboardForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            changePassTxt.Visible = !changePassTxt.Visible;
            newMonthTxt.Visible = !newMonthTxt.Visible;
        }

        private void newMonthTxt_Click(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to Start a new month.");
                return;
            }
            // Navigate
            ResetMonthForm resetMonthForm = new ResetMonthForm(_messName);
            resetMonthForm.StartPosition = FormStartPosition.CenterParent;
            resetMonthForm.ShowDialog(); // This makes it a modal dialog

        }

        private void label10_Click(object sender, EventArgs e)
        {

            // Navigate
            AllMembersForm allMembersForm = new AllMembersForm(_messName, _umail);
            allMembersForm.StartPosition = FormStartPosition.CenterParent;
            allMembersForm.ShowDialog(); // This makes it a modal dialog

        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Navigate
            MonthDetailsForm monthDetailsForm = new MonthDetailsForm(_messName);
            monthDetailsForm.StartPosition = FormStartPosition.CenterParent;
            monthDetailsForm.ShowDialog(); // This makes it a modal dialog
        }

        private void lgOutBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            LoginForm loginForm = new LoginForm();

            // Show Form2
            loginForm.Show();
            //hide form 1
            this.Close();
        }

        private void changePassTxt_Click(object sender, EventArgs e)
        {
            // Navigate
            PasswordChangeForm passwordChangeForm = new PasswordChangeForm(_umail);
            passwordChangeForm.StartPosition = FormStartPosition.CenterParent;
            passwordChangeForm.ShowDialog(); // This makes it a modal dialog
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            string role = RoleChecker.GetUserRole(_umail, _dbConnection);
            if (!role.Equals("Manager"))
            {
                MessageBox.Show("You do not have permission to add a member.");
                return;
            }
            // Navigate
            ToLetForm toLetForm = new ToLetForm(_messName);
            toLetForm.StartPosition = FormStartPosition.CenterParent;
            toLetForm.ShowDialog(); // This makes it a modal dialog
        }
    }
}
