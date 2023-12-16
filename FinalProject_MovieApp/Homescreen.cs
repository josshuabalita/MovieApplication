using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        private const int MaxMoviesPerLabels = 5;
        private const int MaxTVShowsPerLabels = 5;

        public string username;  // Add a field to store the username


        public Homescreen(string username = "")
        {
            InitializeComponent();
            InitializeEventHandlers();
            HideAllLabels();
            this.Text = "MovieStreams";
            InitializeAsync();
            this.username = username;  // Store the passed username


            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;

            label21.Text = $"Welcome, {username}!";
           
        }
       

        private async void InitializeAsync()
        {

            await DisplayMoviesAndTVShowsAsync();
        }

        private async Task DisplayMoviesAndTVShowsAsync()
        {
            await FetchAndDisplayData(MovieBaseUrl, MaxMoviesPerLabels);
            await FetchAndDisplayData(TVBaseUrl, MaxTVShowsPerLabels);
        }


        private void InitializeEventHandlers()
        {
            SearchByTitleButton.Click += SearchByTitleButton_Click;

        }

        private async void SearchByTitleButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Welcome, {username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

            pictureBox16.Visible = true;
            pictureBox17.Visible = true;
            pictureBox18.Visible = true;
            pictureBox19.Visible = true;
            pictureBox20.Visible = true;
            pictureBox21.Visible = true;
                pictureBox22.Visible = true;
            pictureBox23.Visible = true;
            pictureBox24.Visible = true;
            pictureBox25.Visible = true;

            try
            {
                string searchQuery = textBox1.Text.Trim();

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    const string searchMovieBaseUrl = "https://api.themoviedb.org/3/search/movie";
                    string searchUrl = $"{searchMovieBaseUrl}?api_key={ApiKey}&query={searchQuery}&page_size=5";

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(searchUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync();
                            MovieResponse searchResponse = JsonConvert.DeserializeObject<MovieResponse>(responseData);
                            DisplaySearchedMovies(searchResponse.Results);
                        }
                        else
                        {
                            MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a search query.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
       public string path1;
        public string path2;
        public string path3;
        public string path4;
        public string path5;

        private async Task DisplaySearchedMovies(List<Movie> movies)
        {
            int startingIndex = 11; // Set the index where the search results should start appearing
            int labelIndex = 16;
            if (movies[0].backdrop_path != null)
            {
                path1 = movies[0].backdrop_path;
                path2 = movies[1].backdrop_path;
                path3 = movies[2].backdrop_path;
                path4 = movies[3].backdrop_path;
                path5 = movies[4].backdrop_path;

            }
         
            for (int i = 0; i < Math.Min(5, movies.Count); i++)
            {
                AddMovieTitleToLabel(movies[i], labelIndex + i);

                PictureBox pictureBox = GetPictureBoxByNumber(startingIndex + i);
                await DisplayMoviePoster(movies[i].backdrop_path, pictureBox);

                // Set the Tag property of the PictureBox to store the movie details
              

            }
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

      

        private async Task DisplayMovies(List<Movie> movies, int maxItems, bool clearControls = true)
        {
          

            for (int i = 0; i < Math.Min(maxItems, movies.Count); i++)
            {
                AddMovieTitleToLabel(movies[i], i + 1);
                await DisplayMovieBackdrop(movies[i].backdrop_path, GetPictureBoxByNumber(i + 1));
            }
        }


        private async Task DisplayTVShows(List<TVShow> tvShows, int maxItems)
        {
           

            for (int i = 0; i < Math.Min(maxItems, tvShows.Count); i++)
            {
                AddTVShowTitleToLabel(tvShows[i], i + 6); 
                await DisplayMovieBackdrop(tvShows[i].backdrop_path, GetPictureBoxByNumber(i + 6));
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
            label.Font = new System.Drawing.Font("Sans Serif Collection", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

       
        private void Homescreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }


        /// Save for specific user -----------------------------------------------------------------------------------------------------------------
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox11 

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path1}";


      
              
                string labelText = GetLabelText(16);

                // Save the information to a file for the current username
                SaveUserPreference(username, imageUrl, labelText);
                MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FavouritesPage favouritesPage = new FavouritesPage(username);
            favouritesPage.Show();

                
            // the preference is saved

        }
        private void SaveUserPreference(string username, string backdropPath, string labelText)
        {
            // Define a filename based on the username
            string preferencesFileName = $"{username}_preferences.txt";

            // Save the backdrop_path and label text to the file
            using (StreamWriter writer = new StreamWriter(preferencesFileName, true))
            {
                writer.WriteLine($"Backdrop Path: {backdropPath}");
                writer.WriteLine($"Label Text: {labelText}");
                writer.WriteLine();
            }
        }

        private void SaveUserWatchListPreference(string username, string backdropPath, string labelText)
        {
            // Define a filename based on the username
            string preferencesFileName = $"{username}_watchlist_preferences.txt";

            // Save the backdrop_path and label text to the file
            using (StreamWriter writer = new StreamWriter(preferencesFileName, true))
            {
                writer.WriteLine($"Backdrop Path: {backdropPath}");
                writer.WriteLine($"Label Text: {labelText}");
                writer.WriteLine();
            }
        }

        private string GetLabelText(int labelNumber)
        {
            Label label = GetLabelByNumber(labelNumber);
            return label?.Text ?? string.Empty;
        }




        /// Save for specific user -----------------------------------------------------------------------------------------------------------------


        private void pictureBox17_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path2}";


           


            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FavouritesPage favouritesPage = new FavouritesPage(username);
            favouritesPage.Show();


        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path3}";




            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FavouritesPage favouritesPage = new FavouritesPage(username);
            favouritesPage.Show();


        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path4}";


            


            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FavouritesPage favouritesPage = new FavouritesPage(username);
            favouritesPage.Show();


        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path5}";


            


            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FavouritesPage favouritesPage = new FavouritesPage(username);
            favouritesPage.Show();


        }

        private void ViewAllMoviesButton_Click(object sender, EventArgs e)
        {
            // Assuming reviewsPage is an instance of the ReviewsPage form
            ReviewsPage reviewsPage = new ReviewsPage();
            reviewsPage.Show();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path1}";




            string labelText = GetLabelText(16);

            // Save the information to a file for the current username
            SaveUserWatchListPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            WatchListPage watchListPage = new WatchListPage(username);
            watchListPage.Show();
            // Optionally, you can show a message to indicate that the preference is saved

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox11 from its Tag property

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path2}";




            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserWatchListPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            WatchListPage watchListPage = new WatchListPage(username);
            watchListPage.Show();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path3}";




            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserWatchListPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            WatchListPage watchListPage = new WatchListPage(username);
            watchListPage.Show();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path4}";




            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserWatchListPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            WatchListPage watchListPage = new WatchListPage(username);
            watchListPage.Show();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            // Get the movie details associated with pictureBox

            string imageUrl = $"https://image.tmdb.org/t/p/w500/{path5}";




            // Get the original poster path and label text

            string labelText = GetLabelText(17);

            // Save the information to a file for the current username
            SaveUserWatchListPreference(username, imageUrl, labelText);
            MessageBox.Show("Preference saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            WatchListPage watchListPage = new WatchListPage(username);
            watchListPage.Show();
        }
    }
}
