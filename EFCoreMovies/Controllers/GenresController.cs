using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            try 
            { 
                var genres = await context.Genres.ToListAsync();
                return Ok(genres);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("first")]
        public async Task<ActionResult<Genre>> GetFirst()
        {
            try 
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Name.Contains("z"));
                return Ok(genre);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Genre>>> FilterByName(string name)
        {
            try
            {
                var genres = await context.Genres.Where(x => x.Name.Contains(name)).ToListAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genre genre)
        { 
            await context.Genres.AddAsync(genre); // marking genre as added in memory
            await context.SaveChangesAsync();   // insert in the table
            return Ok();
        }

        [HttpPost("multiple")]
        public async Task<ActionResult> PostMultiple(IEnumerable<Genre> genres)
        { 
            await context.Genres.AddRangeAsync(genres);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("updateTitle")]
        public async Task<ActionResult> Update(int id, string newTitle)
        {
            var genreToUpdate = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genreToUpdate == null)
            {
                return BadRequest();
            }

            genreToUpdate.Name = newTitle;
            return Ok(genreToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        { 
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genre == null)
            { 
                return BadRequest(); 
            }

            context.Remove(genre);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
