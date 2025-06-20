using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using CinemaServer.CinemaSupabase;
using CinemaWPF.Core.Models;
using CinemaServer.Models;
using Movie = Core.Models.Movie;

namespace CinemaWPF.Views.Films
{
    public partial class FilmDetailsView : UserControl
    {
        private readonly SupabaseAuthDataProvider _dataProvider;
        private string? _selectedImagePath;

        public FilmDetailsView()
        {
            InitializeComponent();
            _dataProvider = new SupabaseAuthDataProvider();
        }

        private async void SaveFilmButton_Click(object sender, RoutedEventArgs e)
        {
            var title = FilmTitleTextBox.Text;
            var description = FilmDescriptionTextBox.Text;
            var releaseDate = FilmReleaseDatePicker.SelectedDate;
            var genre = GenreTextBox.Text;
            var rating = GetSelectedRating();

            if (string.IsNullOrWhiteSpace(title) || 
                string.IsNullOrWhiteSpace(description) || 
                string.IsNullOrWhiteSpace(genre) ||
                releaseDate == null)
            {
                MessageBox.Show("Please fill in all required fields (Title, Genre, Description, Release Date).");
                return;
            }

            var movie = new Movie()
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate.Value,

            };

            try
            {
                // Use AddFilmAsync instead of AddMovieAsync
                var success = await _dataProvider.AddFilmAsync(movie);
                
                if (success)
                {
                    MessageBox.Show("Film added successfully!");
                    ClearFields();
                    NavigateToFilmsView();
                }
                else
                {
                    MessageBox.Show("Failed to add film. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding film: {ex.Message}");
                Console.WriteLine($"Exception details: {ex}");
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Film Cover Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;

                try
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(_selectedImagePath);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    PreviewImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                    _selectedImagePath = null;
                }
            }
        }

        private int GetSelectedRating()
        {
            if (RatingComboBox.SelectedItem is string selectedRating)
            {
                // Extract number from strings like "1 ⭐️", "2 ⭐️⭐️", etc.
                if (selectedRating.StartsWith("1")) return 1;
                if (selectedRating.StartsWith("2")) return 2;
                if (selectedRating.StartsWith("3")) return 3;
                if (selectedRating.StartsWith("4")) return 4;
                if (selectedRating.StartsWith("5")) return 5;
            }
            return 0; // Default rating
        }
        private void ClearFields()
        {
            FilmTitleTextBox.Text = string.Empty;
            GenreTextBox.Text = string.Empty;
            FilmDescriptionTextBox.Text = string.Empty;
            FilmReleaseDatePicker.SelectedDate = null;
            RatingComboBox.SelectedIndex = -1;
            PreviewImage.Source = null;
            _selectedImagePath = null;
        }

        private void NavigateToFilmsView()
        {
            try
            {
                var filmsView = new FilmsView();
                var currentWindow = Window.GetWindow(this);
                if (currentWindow != null)
                {
                    currentWindow.Content = filmsView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to films view: {ex.Message}");
            }
        }
    }
}