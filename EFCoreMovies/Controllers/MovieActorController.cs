using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/movieactor")]
    public class MovieActorController : ControllerBase
    {
        private readonly IMovieActorRepository movieActorRepository;

        public MovieActorController(IMovieActorRepository movieActorRepository)
        {
            this.movieActorRepository = movieActorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActor>>> GetMovieActors()
        { 
            try 
            {
                var movieActors = await movieActorRepository.GetMovieActors();
                return Ok(movieActors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
