using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_MovieApp
{
    public partial class watchListTab : UserControl
    {
        public event EventHandler WatchListTabClicked;
        private string username;

        public watchListTab()
        {
            InitializeComponent();
            this.Click += watchListTab_Click;
          
        }

        private void watchListTab_Click(object sender, EventArgs e)
        {
            PromptForUsernameAndOpenWatchListPage();

        }
        private void PromptForUsernameAndOpenWatchListPage()
        {
            InputDialog inputDialog = new InputDialog("Enter your registered username:");
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                username = inputDialog.InputText;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    OpenWatchListPage(username);
                }
                else
                {
                    MessageBox.Show("Username cannot be empty. Please enter a valid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void OpenWatchListPage(string username)
        { 
            WatchListPage watchListForm = new WatchListPage(username);
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
                watchListForm.Closed += (s, args) => this.ParentForm.Close();
                watchListForm.Show();
            }
        }
    }
}
