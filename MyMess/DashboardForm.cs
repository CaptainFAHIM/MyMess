using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            messName.Text = _messName.Split('_')[0];
            profileName.Text = _uname;

            // Fetch the active month and days passed from the database
            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    // Query to fetch the ActiveMonth
                    string activeMonthQuery = $@"SELECT ActiveMonth FROM {_messName} WHERE ActiveMonth IS NOT NULL";

                    using (SqlCommand command = new SqlCommand(activeMonthQuery, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            activeMonthLabel.Text = result.ToString(); // Assuming you have a label named activeMonthLabel
                        }
                        else
                        {
                            activeMonthLabel.Text = "No active month found.";
                        }
                    }

                    // Query to fetch the StartDate
                    string startDateQuery = $@"SELECT StartDate FROM {_messName} WHERE StartDate IS NOT NULL";

                    using (SqlCommand command = new SqlCommand(startDateQuery, connection))
                    {
                        object startDateResult = command.ExecuteScalar();
                        if (startDateResult != null)
                        {
                            DateTime startDate = Convert.ToDateTime(startDateResult);
                            DateTime currentDate = DateTime.Now;

                            // Calculate days passed
                            TimeSpan difference = currentDate - startDate;
                            int daysPassed = difference.Days;

                            // Set the days passed in the dayCount label
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
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
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
    }
}
