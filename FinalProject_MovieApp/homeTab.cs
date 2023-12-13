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
        public homeTab()
        {
            InitializeComponent();
            this.Click += home_Click;
        }

        private void home_Click(object sender, EventArgs e)
        {
            OpenHomePage();
        }

        protected virtual void OnHomeTabClicked()
        { 
            HomeTabClicked?.Invoke(this, EventArgs.Empty);
            OpenHomePage();
        }

        private void OpenHomePage()
        {
            Homescreen homescreenForm = new Homescreen();
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
                homescreenForm.Closed += (s, args) => this.ParentForm.Close();
                homescreenForm.Show();
            }
        }
    }
}
