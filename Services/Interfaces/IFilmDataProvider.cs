using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Services.Interfaces
{
    public interface IFilmDataProvider
    {
        Task<bool> AddFilmAsync(Movie movie);
        Task<List<Movie>> GetAllFilmsAsync();
    }
}

