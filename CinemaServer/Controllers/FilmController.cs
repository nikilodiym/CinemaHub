using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Interfaces;
using CinemaServer.Services;

namespace CinemaServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public FilmController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetAllFilmsAsync();
            return Ok(movies);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            await _movieService.AddFilmAsync(movie);
            return Ok();
        }
    }
}

