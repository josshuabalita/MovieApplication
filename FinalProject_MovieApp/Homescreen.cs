using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FinalProject_MovieApp
{
    public partial class Homescreen : Form
    {
        private const string ApiKey = "74bdf5aa8da3da84930433e3afb7124e";
        private const string MovieBaseUrl = "https://api.themoviedb.org/3/discover/movie";
        private const string TVBaseUrl = "https://api.themoviedb.org/3/discover/tv";
        private const string ReviewsBaseUrl = "https://api.themoviedb.org/3/movie/";

        private const int MaxMoviesPerLabels = 5;
        private const int MaxTVShowsPerLabels = 5;

        public Homescreen()
        {
            InitializeComponent();
            InitializeEventHandlers();
            HideAllLabels();
            this.Text = "MovieStreams";
            FetchAndDisplayData(MovieBaseUrl, MaxMoviesPerLabels);
            FetchAndDisplayData(TVBaseUrl, MaxTVShowsPerLabels);
            FetchAndDisplayReviews(670292);
        }

        private void InitializeEventHandlers()
        {
        }

        private async Task FetchAndDisplayData(string apiUrl, int maxItems)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc&api_key={ApiKey}&page_size={maxItems}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        if (apiUrl == MovieBaseUrl)
                        {
                            MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(responseData);
                            DisplayMovies(movieResponse.Results, maxItems);
                        }
                        else if (apiUrl == TVBaseUrl)
                        {
                            TVShowResponse tvShowResponse = JsonConvert.DeserializeObject<TVShowResponse>(responseData);
                            DisplayTVShows(tvShowResponse.Results, maxItems);
                        }
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

        private async Task DisplayMovies(List<Movie> movies, int maxItems)
        {
            ClearLabelAndPictureBoxControls();

            for (int i = 0; i < Math.Min(maxItems, movies.Count); i++)
            {
                AddMovieTitleToLabel(movies[i], i + 1);
                await DisplayMovieBackdrop(movies[i].backdrop_path, GetPictureBoxByNumber(i + 1));
            }
        }

        private async Task DisplayTVShows(List<TVShow> tvShows, int maxItems)
        {
            ClearLabelAndPictureBoxControls();

            for (int i = 0; i < Math.Min(maxItems, tvShows.Count); i++)
            {
                AddTVShowTitleToLabel(tvShows[i], i + 6);
                await DisplayMovieBackdrop(tvShows[i].backdrop_path, GetPictureBoxByNumber(i + 6));
            }
        }

        private void DisplayReviews(List<MovieReview> reviews)
        {
            for (int i = 0; i < Math.Min(5, reviews.Count); i++)
            {
                AddReviewToLabel(reviews[i], i + 11);
            }
        }

        private void ClearLabelAndPictureBoxControls()
        {
            for (int i = 1; i <= 10; i++)
            {
                ClearPictureBox(GetPictureBoxByNumber(i));
                ClearLabel(GetLabelByNumber(i));
            }
        }

        private void ClearPictureBox(PictureBox pictureBox)
        {
            if (pictureBox != null)
            {
                pictureBox.Image = null;
            }
        }

        private void ClearLabel(Label label)
        {
            if (label != null)
            {
                label.Text = string.Empty;
            }
        }

        private async Task DisplayMoviePoster(string posterPath, PictureBox pictureBox)
        {
            try
            {
                string imageUrl = $"https://image.tmdb.org/t/p/w500/{posterPath}";

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(imageUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            Image originalImage = Image.FromStream(stream);
                            Image resizedImage = ResizeImage(originalImage, pictureBox.Width, pictureBox.Height);

                            pictureBox.Image = resizedImage;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error downloading poster: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task DisplayMovieBackdrop(string backdropPath, PictureBox pictureBox)
        {
            try
            {
                string imageUrl = $"https://image.tmdb.org/t/p/w500/{backdropPath}";

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(imageUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            Image originalImage = Image.FromStream(stream);
                            Image resizedImage = ResizeImage(originalImage, pictureBox.Width, pictureBox.Height);

                            pictureBox.Image = resizedImage;
                        }
                    }
                    else
                    {
                        string errorMessage = $"Error downloading backdrop: {response.StatusCode} - {response.ReasonPhrase}";
                        Console.WriteLine(errorMessage);
                        Console.WriteLine(imageUrl);
                        MessageBox.Show(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}";
                Console.WriteLine(errorMessage);
                MessageBox.Show(errorMessage);
            }
        }

        private Image ResizeImage(Image originalImage, int targetWidth, int targetHeight)
        {
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
            }
            return resizedImage;
        }

        private void AddMovieTitleToLabel(Movie movie, int labelNumber)
        {
            Label label = GetLabelByNumber(labelNumber);

            if (label != null)
            {
                string truncatedTitle = TruncateText(movie.Title, 40);
                label.Text = truncatedTitle;
                CustomizeLabel(label);
                label.Show();
            }
        }

        private void AddTVShowTitleToLabel(TVShow tvShow, int labelNumber)
        {
            Label label = GetLabelByNumber(labelNumber);

            if (label != null)
            {
                string truncatedName = TruncateText(tvShow.Name, 40);
                label.Text = truncatedName;
                CustomizeLabel(label);
                label.Show();
            }
        }

        private void AddReviewToLabel(MovieReview review, int labelNumber)
        {
            Label label = GetLabelByNumber(labelNumber);

            if (label != null)
            {
                string truncatedContent = TruncateText($" {review.Content}\n", 40);
                label.Text += truncatedContent;
                label.Text += $"---\n";
                CustomizeLabel(label);
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

        private Label GetLabelByNumber(int labelNumber)
        {
            return this.Controls.Find($"label{labelNumber}", true).FirstOrDefault() as Label;
        }

        private PictureBox GetPictureBoxByNumber(int pictureBoxNumber)
        {
            return this.Controls.Find($"pictureBox{pictureBoxNumber}", true).FirstOrDefault() as PictureBox;
        }

        private void CustomizeLabel(Label label)
        {
            label.Font = new System.Drawing.Font("Sans Serif Collection", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.White;
        }

        private void HideAllLabels()
        {
            for (int i = 1; i <= 20; i++)
            {
                GetLabelByNumber(i)?.Hide();
            }
        }

        private class MovieResponse
        {
            public List<Movie> Results { get; set; }
        }

        private class TVShowResponse
        {
            public List<TVShow> Results { get; set; }
        }

        private class MovieReviewResponse
        {
            public List<MovieReview> Results { get; set; }
        }

        private class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string backdrop_path { get; set; }
        }

        private class TVShow
        {
            public string Name { get; set; }
            public string backdrop_path { get; set; }
        }

        private class MovieReview
        {
            public string Author { get; set; }
            public string Content { get; set; }
        }

        private void Homescreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
