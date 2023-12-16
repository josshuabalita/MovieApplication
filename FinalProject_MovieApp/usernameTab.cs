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
    public partial class usernameTab : UserControl
    {
        public event EventHandler UsernameTabClicked;

        public usernameTab()
        {
            InitializeComponent();
            this.Click += userTab_Click;
        }

        private void userTab_Click(object sender, EventArgs e)
        {
            ShowExitDialog();
        }

        private void ShowExitDialog()
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OnUserTabClicked();
            }
        }

        protected virtual void OnUserTabClicked()
        {
            UsernameTabClicked?.Invoke(this, EventArgs.Empty);

            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }
    }
}
