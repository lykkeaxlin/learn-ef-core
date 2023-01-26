using EFCoreMovies;
using EFCoreMovies_Core.BusinessModel.Entitiy;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Infra.BusinessLogic.Repository
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        private readonly ApplicationDbContext context;

        public MovieGenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MovieGenre>> GetMovieGenreMappings()
        {
            var movieGenreMappings = await context.MovieGenreMappings
                        .Include(x => x.Movie)
                        .Include(x => x.Genre)
                        .ToListAsync();
            return movieGenreMappings;
        }
    }
}
