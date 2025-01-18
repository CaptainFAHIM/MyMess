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
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace MyMess
{
    public partial class MonthDetailsForm : Form
    {
        private string _messName;
        private DbConnection _dbConnection;
        public MonthDetailsForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }
        public MonthDetailsForm(string messName)
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _messName = messName;
        }

        private void dgvDeposits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MonthDetailsForm_Load(object sender, EventArgs e)
        {
            LoadDeposits();
            LoadCosts();
            LoadMeals();
        }

        private void LoadDeposits()
        {
            string query = @"
        SELECT 
            Name AS 'Name',
            Email AS 'Email',
            DepositAmount AS 'Amount',
            DepositeDate AS 'Date'
        FROM Deposites
        WHERE MessName = @MessName";

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MessName", _messName);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvDeposits.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading deposits: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCosts()
        {
            string query = @"
        SELECT 
            CostAmount AS 'Amount',
            CostDate AS 'Date',
            Note AS 'Description'
        FROM Costs
        WHERE MessName = @MessName";

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MessName", _messName);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvCosts.DataSource = dataTable;

                    // Optionally, hide the ID column if it exists, even if it's not selected in the query.
                    // dgvCosts.Columns["ID"].Visible = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading costs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoadMeals()
        {
            string query = @"
        SELECT 
            MemberEmail AS 'Email',
            MealCount AS 'Meals Count',
            MealDate AS 'Date',
            MealCost AS 'Cost'
        FROM Meals
        WHERE MessName = @MessName";

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MessName", _messName);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvMeals.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading meals: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Download
        private void mnthDetailsDwnBtn_Click(object sender, EventArgs e)
        {
            string pdfPath = $"{_messName}_Month_Details.pdf";

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"{_messName} Month Details";

            // Create an empty page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 8, XFontStyle.Regular);  // Smaller font size
            double yPosition = 20;

            // Write the title at the very top of the PDF
            gfx.DrawString($"Mess Details for: {_messName.Split('_')[0]}", new XFont("Verdana", 16, XFontStyle.Bold), XBrushes.Black, new XRect(0, yPosition, page.Width, page.Height), XStringFormats.Center);
            yPosition += 30; // Add some space below the title

            // Write Deposits Table
            yPosition = WriteTable(gfx, "Deposits", dgvDeposits, font, yPosition);

            // Write Costs Table
            yPosition = WriteTable(gfx, "Costs", dgvCosts, font, yPosition);

            // Write Meals Table
            yPosition = WriteTable(gfx, "Meals", dgvMeals, font, yPosition);

            // Save the document to a file
            document.Save(pdfPath);

            // Optionally, open the PDF after creating it
            System.Diagnostics.Process.Start(pdfPath);

            MessageBox.Show("PDF saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double WriteTable(XGraphics gfx, string tableName, DataGridView dgv, XFont font, double yPosition)
        {
            // Table Title
            gfx.DrawString(tableName, new XFont("Verdana", 12, XFontStyle.Bold), XBrushes.Black, 20, yPosition);
            yPosition += 20;

            // Set column widths for each table (increased space between columns)
            double[] columnWidths = new double[dgv.Columns.Count];
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                columnWidths[i] = 150; // Increased the width of columns for more space
            }

            // Draw headers
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                gfx.DrawString(dgv.Columns[i].HeaderText, font, XBrushes.Black, 20 + i * 150, yPosition);  // Adjusted spacing
            }
            yPosition += 20;

            // Draw rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        gfx.DrawString(row.Cells[i].Value?.ToString() ?? string.Empty, font, XBrushes.Black, 20 + i * 150, yPosition);  // Adjusted spacing
                    }
                    yPosition += 20;
                }
            }

            // Add space between tables
            yPosition += 20;

            return yPosition;
        }




    }
}
