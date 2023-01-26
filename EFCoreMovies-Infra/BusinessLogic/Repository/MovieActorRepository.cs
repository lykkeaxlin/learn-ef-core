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
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly ApplicationDbContext context;

        public MovieActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MovieActor>> GetMovieActorMappings()
        {
            var movieActors = await context.MovieActorMappings
                                .Include(x => x.Movie)
                                .Include(x => x.Actor)
                                .ToListAsync();
            return movieActors;
        }
    }
}
