using EFCoreMovies_Core.BusinessModel.Entitiy;
using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieGenre> MovieGenresMapping { get; set; }
    }
}
