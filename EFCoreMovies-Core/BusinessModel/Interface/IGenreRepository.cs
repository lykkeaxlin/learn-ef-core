using EFCoreMovies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Core.BusinessModel.Interface
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<IEnumerable<Genre>> GetGenreBySubstring(string substring);
        Task<Genre> CreateGenre(Genre genre);
        Task<Genre> DeleteGenreById(int id);
    }
}
