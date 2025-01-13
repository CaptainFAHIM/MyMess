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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            LoginForm form2 = new LoginForm();

            // Show Form2
            form2.Show();
            //hide form 1
            this.Hide();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            CreateMessForm form3 = new CreateMessForm();

            // Show Form2
            form3.Show();
            //hide form 1
            this.Hide();

        }
    }
}
