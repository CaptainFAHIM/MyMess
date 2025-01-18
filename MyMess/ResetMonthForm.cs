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
    public partial class ResetMonthForm : Form
    {
        public ResetMonthForm()
        {
            InitializeComponent();
        }

        private void newMonthNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newMonthYes_Click(object sender, EventArgs e)
        {

        }
    }
}
