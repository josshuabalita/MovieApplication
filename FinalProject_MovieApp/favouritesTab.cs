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
    public partial class favouritesTab : UserControl
    {
        public event EventHandler FavouritesTabClicked;

        public favouritesTab()
        {
            InitializeComponent();
            this.Click += faveTab_Click;
        }

        private void faveTab_Click(object sender, EventArgs e)
        {
            OpenFavouritesPage();
        }
        protected virtual void OnFavouritesTabClicked()
        {
            FavouritesTabClicked?.Invoke(this, EventArgs.Empty);
            OpenFavouritesPage();
        }

        private void OpenFavouritesPage()
        {
            favouritesPage faveForm = new favouritesPage();
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
                faveForm.Closed += (s, args) => this.ParentForm.Close();
                faveForm.Show();
            }
        }
    }
}
