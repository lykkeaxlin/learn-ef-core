using EFCoreMovies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Core.BusinessModel.Interface
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetMoviesGroupedByCinemas();
        Task<IEnumerable<Movie>> GetMoviesForActorByActorId(int actorId);
    }
}
