using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        Task<bool> AddFilmAsync(Movie movie);
        Task<List<Movie>> GetAllFilmsAsync();
    }
}

