using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject_MovieApp
{
    public partial class ReviewsPage : Form
    {
        private const string ReviewsBaseUrl = "https://api.themoviedb.org/3/movie/";
        private const string ApiKey = "74bdf5aa8da3da84930433e3afb7124e";

        public ReviewsPage()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            FetchAndDisplayReviews(670292);
        }

        private async Task FetchAndDisplayReviews(int movieId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{ReviewsBaseUrl}{movieId}/reviews?api_key={ApiKey}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        MovieReviewResponse reviewResponse = JsonConvert.DeserializeObject<MovieReviewResponse>(responseData);
                        DisplayReviews(reviewResponse.Results);

                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private class MovieReviewResponse
        {
            public List<MovieReview> Results { get; set; }
        }


        private void DisplayReviews(List<MovieReview> reviews)
        {
            for (int i = 0; i < Math.Min(5, reviews.Count); i++)
            {
                AddReviewToLabel(reviews[i], i + 11);
            }
        }

        private class MovieReview
        {
            public string Author { get; set; }
            public string Content { get; set; }
        }
        private Label GetLabelByNumber(int labelNumber)
        {
            return this.Controls.Find($"label{labelNumber}", true).FirstOrDefault() as Label;
        }

        private void AddReviewToLabel(MovieReview review, int labelNumber)
        {
            Label label = GetLabelByNumber(labelNumber);

            if (label != null)
            {
                // Display the author and truncated content of the review
                string truncatedContent = TruncateText(review.Content, 50); // You can adjust the character limit as needed
                label.Text = $"{review.Author}:\n {truncatedContent}\n";

                // Add a separator line
                label.Text += $"---\n";

                // Customize the label
                CustomizeLabel(label);

                // Show the label
                label.Show();
            }
        }


        private string TruncateText(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }
            return text;
        }


        private void CustomizeLabel(Label label)
        {
            label.Font = new System.Drawing.Font("Sans Serif Collection", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.White;
        }

    }
}
