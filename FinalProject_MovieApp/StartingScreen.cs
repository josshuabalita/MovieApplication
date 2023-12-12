using System;
using System.IO;
using System.Windows.Forms;

namespace FinalProject_MovieApp
{
    public partial class StartingScreen : Form
    {
        private string username = "";
        private const string filePath = "userCredentials.txt";
        private bool isReturningUser = false;

        public StartingScreen()
        {
            InitializeComponent();
        }

        private void returningUser_btn_Click(object sender, EventArgs e)
        {
            isReturningUser = true;
            ShowInputControls("Enter Registered Username: ");
        }

        private void newUser_btn_Click(object sender, EventArgs e)
        {
            isReturningUser = false;
            ShowInputControls("Enter New Username: ");
        }

        private void ShowInputControls(string prompt)
        {
            label1.Visible = true;
            textBox.Visible = true;
            label1.Text = prompt;
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            string enteredUsername = textBox.Text.Trim();

            try
            {
                if (!string.IsNullOrEmpty(enteredUsername))
                {
                    if (isReturningUser)
                    {
                        if (UserExists(enteredUsername))
                        {
                            MessageBox.Show("Login successful!");

                            // Create an instance of Homescreen
                            Homescreen homeScreen = new Homescreen(); // Correct class name

                            // Close the current form (StartingScreen)
                            this.Hide();

                            // Show the new form as a dialog
                            homeScreen.ShowDialog();

                            // Close the application when the Homescreen form is closed
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("User not found. Please register.");
                        }
                    }
                    else
                    {
                        RegisterUser(enteredUsername);
                        MessageBox.Show("User registered successfully!");

                        
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a username.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private bool UserExists(string usernameToCheck)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && parts[0].Trim() == usernameToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        private void RegisterUser(string newUsername)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{newUsername}:password"); // You may want to implement a secure way to store passwords
            }
        }
    }
}
