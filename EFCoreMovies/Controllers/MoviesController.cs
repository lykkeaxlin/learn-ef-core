using EFCoreMovies.Dto;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        public readonly ApplicationDbContext context;

        public MoviesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(int id)
        {
            try
            {
                var movie = await context.Movies
                    .Include(x => x.Genres)
                    .Include(x => x.CinemaHalls)
                        .ThenInclude(xx => xx.Cinema)
                    .Include(x => x.MoviesActors)
                        .ThenInclude(xx => xx.Actor)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var genresDto = movie.Genres.Select(x => new GenreDTO() { 
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
                
                var cinemas = await context.Cinemas.ToListAsync();
                var cinemasDto = cinemas.Select(x => new CinemaDTO() { 
                    Id = x.Id,
                    Name = x.Name,
                    Latitude = x.Location.Y,
                    Longitude = x.Location.X
                }).Distinct().ToList();

                var actorsDto = movie.MoviesActors
                    .Where(ma => ma.MovieId == movie.Id)
                    .Select(x => x.Actor)
                    .Select(x => new ActorDTO() {
                    Id = x.Id,
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth,
                }).ToList();

                var movieDto = new MovieDTO()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Genres = genresDto,
                    Cinemas = cinemasDto,
                    Actors = actorsDto
                };
                return Ok(movieDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("groupedByCinema")]
        public async Task<ActionResult> GetGroupedByCinema()
        {
            try
            {
                var groupedMovies = await context.Movies.GroupBy(x => x.InCinemas).Select(x => new
                {
                    InCinemas = x.Key,
                    Count = x.Count(),
                    Movies = x.ToList()
                }).ToListAsync();
                return Ok(groupedMovies);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("groupedByGenresCount")]
        public async Task<ActionResult> GetGroupedByGenresCount()
        {
            try
            {
                var groupedMovies = await context.Movies.GroupBy(x => x.Genres.Count())
                        .Select(x => new
                        {
                            Count = x.Key,
                            Titles = x.Select(x => x.Title),
                            Genre = x.Select(x => x.Genres).SelectMany(x => x).Select(x => x.Name).Distinct(),
                        }).ToListAsync();
                return Ok(groupedMovies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
