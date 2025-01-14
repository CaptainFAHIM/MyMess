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
        private string _messName;
        public DashboardForm()
        {
            InitializeComponent();
        }

        public DashboardForm(string uname, string messName)
        {
            InitializeComponent();
            _uname = uname;
            _messName = messName.Split('_')[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            messName.Text = _messName;
            profileName.Text = _uname;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}
