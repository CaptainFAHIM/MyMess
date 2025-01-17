using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMess
{
    public partial class DashboardForm : Form
    {
        private string _uname;
        private string _umail;
        private string _messName;
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            messName.Text = _messName.Split('_')[0];
            profileName.Text = _uname;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {
            // Navigate to Form3
            // Create an instance of Form2
            AddMemberForm addMemberForm = new AddMemberForm(_umail, _messName);
            // Set the new form's parent to the current form
            addMemberForm.StartPosition = FormStartPosition.CenterParent;
            // Show the new form
            addMemberForm.ShowDialog(); // This makes it a modal dialog
        }
    }
}
