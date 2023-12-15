using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_MovieApp
{

    public partial class favouritesTab : UserControl
    {
        public event EventHandler FavouritesTabClicked;
        private string username;

        public favouritesTab()
        {
            InitializeComponent();
            this.Click += faveTab_Click;
        }

        private void faveTab_Click(object sender, EventArgs e)
        {
            PromptForUsernameAndOpenFavouritesPage();
        }

        private void PromptForUsernameAndOpenFavouritesPage()
        {
            InputDialog inputDialog = new InputDialog("Enter your registered username:");
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                username = inputDialog.InputText;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    OpenFavouritesPage(username);
                }
                else
                {
                    MessageBox.Show("Username cannot be empty. Please enter a valid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenFavouritesPage(string username)
        {
            FavouritesPage faveForm = new FavouritesPage(username);
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
                faveForm.Closed += (s, args) => this.ParentForm.Close();
                faveForm.LoadUserPreferences();
                faveForm.Show();
            }
        }

    }
}
