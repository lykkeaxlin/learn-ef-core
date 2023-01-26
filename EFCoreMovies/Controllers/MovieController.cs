using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Movie")]
    public class MovieController : ControllerBase
    {
        public readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            try
            { 
                var movies = await movieRepository.GetMovies();
                return Ok(movies);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieById(int id)
        {
            try
            {
                var movie = await movieRepository.GetMovieById(id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("MoviesForActor/{actorId}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesForActorByActorId(int actorId)
        {
            try
            {
                var movies = await movieRepository.GetMoviesForActorByActorId(actorId);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
