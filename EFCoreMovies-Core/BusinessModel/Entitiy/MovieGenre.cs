using EFCoreMovies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Core.BusinessModel.Entitiy
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
