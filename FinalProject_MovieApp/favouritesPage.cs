using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinalProject_MovieApp
{
    public partial class FavouritesPage : Form
    {
        public string Username { get; private set; }

        public FavouritesPage(string username = "")
        {
            InitializeComponent();
            Username = username;
            LoadUserPreferences();
            ShowWelcomeMessage();
        }

        private void ShowWelcomeMessage()
        {
            MessageBox.Show($"Welcome, {Username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label6.Text = $"Welcome, {Username}!";
        }

        public void LoadUserPreferences()
        {
            try
            {
                // Define the filename based on the username
                string preferencesFileName = $"{Username}_preferences.txt";

                // Check if the preferences file exists
                if (File.Exists(preferencesFileName))
                {
                    // Read all lines from the file
                    string[] lines = File.ReadAllLines(preferencesFileName);

                    // Filter lines that start with "Backdrop Path:"
                    var backdropPathLines = lines.Where(line => line.StartsWith("Backdrop Path: ")).ToArray();

                    // Process each line and set the image for the corresponding PictureBox
                    for (int i = 0; i < Math.Min(backdropPathLines.Length, 10); i++)
                    {
                        // Extract backdrop path
                        string backdropPath = backdropPathLines[i].Replace("Backdrop Path: ", "");

                        // Get the PictureBox dynamically by index
                        PictureBox pictureBox = Controls.Find($"pictureBox{i + 1}", true).FirstOrDefault() as PictureBox;

                        // Set the image for the PictureBox
                        SetImageForPictureBox(pictureBox, backdropPath);
                    }
                }
                else
                {
                    MessageBox.Show("No preferences found for the user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetImageForPictureBox(PictureBox pictureBox, string backdropPath)
        {
            // Use the backdrop path to construct the full URL
            string imageUrl = $"https://image.tmdb.org/t/p/w500/{backdropPath}";

            // Load the image into the PictureBox
            try
            {
                pictureBox.Load(imageUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {imageUrl} {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Define the filename based on the username
                string preferencesFileName = $"{Username}_preferences.txt";

                // Check if the preferences file exists
                if (File.Exists(preferencesFileName))
                {
                    // Clear all data in the preferences file
                    File.WriteAllText(preferencesFileName, "");

                    // Inform the user that data has been cleared
                    MessageBox.Show("Favourites List cleared successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No preferences found for the user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
