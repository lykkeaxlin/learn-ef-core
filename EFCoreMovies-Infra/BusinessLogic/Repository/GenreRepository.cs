using EFCoreMovies;
using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Infra.BusinessLogic.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext context;

        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            var genres = await context.Genres.ToListAsync();
            return genres;
        }

        public async Task<IEnumerable<Genre>> GetGenreBySubstring(string substring)
        {
            var genres = await context.Genres
                .Where(x => x.Name.Contains(substring))
                .ToListAsync();
            return genres;
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            await context.Genres.AddAsync(genre); // marking genre as added in memory
            await context.SaveChangesAsync();   // insert in the table
            return genre;
        }

        public async Task<Genre> DeleteGenreById(int id)
        {
            var genreToDelete = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genreToDelete == null)
            {
                throw new ArgumentException($"Could not find Genre with id {id}");
            }

            context.Genres.Remove(genreToDelete);
            await context.SaveChangesAsync();
            return genreToDelete;
        }
    }
}
