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
    public partial class InputDialog : Form
    {
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;

        public string InputText { get; private set; }

        public InputDialog(string prompt)
        {
            InitializeComponent(prompt);
        }

        private void InitializeComponent(string prompt)
        {
            // Set up the form
            this.Text = "Enter Information";
            this.Size = new System.Drawing.Size(300, 140);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            // Create controls
            Label promptLabel = new Label();
            promptLabel.Text = prompt;
            promptLabel.Location = new System.Drawing.Point(10, 10);
            promptLabel.AutoSize = true;

            textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(10, 40);
            textBox.Size = new System.Drawing.Size(270, 20);

            okButton = new Button();
            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new System.Drawing.Point(10, 70);
            okButton.Click += OkButton_Click;

            cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(80, 70);

            // Add controls to the form
            this.Controls.Add(promptLabel);
            this.Controls.Add(textBox);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            InputText = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
