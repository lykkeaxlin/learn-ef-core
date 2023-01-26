using EFCoreMovies_Core.BusinessModel.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Core.BusinessModel.Interface
{
    public interface IMovieGenreRepository 
    {
        Task<IEnumerable<MovieGenre>> GetMovieGenreMappings();
    }
}
