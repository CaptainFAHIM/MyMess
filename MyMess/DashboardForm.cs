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
        public DashboardForm()
        {
            InitializeComponent();
        }

        public DashboardForm(string uname)
        {
            InitializeComponent();
            _uname = uname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
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
