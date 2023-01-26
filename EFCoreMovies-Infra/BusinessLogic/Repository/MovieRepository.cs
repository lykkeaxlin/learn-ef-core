using EFCoreMovies;
using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .Include(x => x.Genres)
                    .Include(x => x.CinemaHalls)
                        .ThenInclude(xx => xx.Cinema)
                    .Include(x => x.MoviesActors)
                        .ThenInclude(xx => xx.Actor)
                    .ToListAsync();
            return movies;
        }
        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesGroupedByCinemas()
        {
            throw new NotImplementedException();
        }
    }
}
