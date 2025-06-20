using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Core.Models;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CinemaServer.CinemaSupabase;
using CinemaServer.Services;
using Services.Implementations;

namespace CinemaWPF.ViewModels.Films
{
    public class UserFilmsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set { _movies = value; OnPropertyChanged(); }
        }

        public UserFilmsViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            LoadMovies();
        }

        public async void LoadMovies()
        {
            /*var service = new MovieService();
            var movies = await service.GetMoviesAsync();
            Movies.Clear();
            foreach (var movie in movies) 
                Movies.Add(movie);*/
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}









