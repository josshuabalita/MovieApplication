using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject_MovieApp
{
    public partial class StartingScreen : Form
    {
        private string username = "";
        public StartingScreen()
        {
            InitializeComponent();

        }


        private void startingLabel_Click(object sender, EventArgs e)
        {

        }

        private void returningUser_btn_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox.Visible = true;

            label1.Text = "Enter Registered Username: ";
        }

        private void newUser_btn_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox.Visible = true;

            label1.Text = "Enter New Username: ";
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
        }
    }
}
