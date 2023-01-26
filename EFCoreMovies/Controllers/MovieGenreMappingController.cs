using EFCoreMovies_Core.BusinessModel.Entitiy;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/MovieGenre")]
    public class MovieGenreMappingController : ControllerBase
    {
        private readonly IMovieGenreRepository movieGenreMappingRepository;

        public MovieGenreMappingController(IMovieGenreRepository movieGenreMappingRepository)
        {
            this.movieGenreMappingRepository = movieGenreMappingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGenre>>> GetMovieGenreMappings()
        {
            try 
            { 
                var movieGenreMappings = await movieGenreMappingRepository.GetMovieGenreMappings();
                return Ok(movieGenreMappings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
