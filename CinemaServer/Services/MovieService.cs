using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Services.Interfaces;
using CinemaServer.CinemaSupabase;

namespace CinemaServer.Services
{
    public class MovieService : IMovieService
    {
        private readonly SupabaseAuthDataProvider _dataProvider;

        public MovieService(SupabaseAuthDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<bool> AddFilmAsync(Movie movie)
        {
            return await _dataProvider.AddFilmAsync(movie);
        }

        public async Task<List<Movie>> GetAllFilmsAsync()
        {
            return await _dataProvider.GetAllFilmsAsync();
        }
    }
}
