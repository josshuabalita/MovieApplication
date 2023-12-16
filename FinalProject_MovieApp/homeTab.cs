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
    public partial class homeTab : UserControl
    {
        public event EventHandler HomeTabClicked;
        private string username;

        public homeTab()
        {
            InitializeComponent();
            this.Click += home_Click;
        }

        private void home_Click(object sender, EventArgs e)
        {
            PromptForUsernameAndOpenHomePage();
        }

        protected virtual void OnHomeTabClicked()
        { 
            HomeTabClicked?.Invoke(this, EventArgs.Empty);
            PromptForUsernameAndOpenHomePage();    
        }

        public void PromptForUsernameAndOpenHomePage()
        {
            InputDialog inputDialog = new InputDialog("Enter your registered username:");
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                username = inputDialog.InputText;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    OpenHomePage();
                }
                else
                {
                    MessageBox.Show("Username cannot be empty. Please enter a valid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void OpenHomePage()
        {
            Homescreen homescreenForm = new Homescreen(username);
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
                homescreenForm.Closed += (s, args) => this.ParentForm.Close();
                homescreenForm.Show();
            }
        }
    }
}
