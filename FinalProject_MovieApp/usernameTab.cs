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
            OnUserTabClicked();
        }

        protected virtual void OnUserTabClicked()
        {
            UsernameTabClicked?.Invoke(this, EventArgs.Empty);
            OpenUsernameBox();
        }

        private void OpenUsernameBox()
        {
            watchListPage watchListForm = new watchListPage();
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
                watchListForm.Closed += (s, args) => this.ParentForm.Close();
                watchListForm.Show();
            }
        }
    }
}
