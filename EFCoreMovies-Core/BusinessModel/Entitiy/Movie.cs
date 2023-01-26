using EFCoreMovies_Core.BusinessModel.Entitiy;

namespace EFCoreMovies.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool InCinemas { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public IEnumerable<MovieGenre> MovieGenresMapping { get; set; }
    }
}
