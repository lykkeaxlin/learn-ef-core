using EFCoreMovies;
using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies_Infra.BusinessLogic.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext context;
        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movies = await context.Movies
                        .Include(x => x.MovieGenresMapping)
                        .ToListAsync();
            return movies;
        }
        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await context.Movies.FindAsync(id);
            return movie;
        }

        public Task<IEnumerable<Movie>> GetMoviesGroupedByCinemas()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMoviesForActorByActorId(int actorId)
        {
            var movieIds = await context.MovieActorMappings
                    .Where(x => x.ActorId == actorId)
                    .Select(x => x.MovieId)
                    .ToListAsync();

            var movies = await context.Movies
                    .Where(x => movieIds.Contains(x.Id))
                    .ToListAsync();

            return movies;
        }
    }
}
