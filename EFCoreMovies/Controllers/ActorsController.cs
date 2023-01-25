using EFCoreMovies.Dto;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ActorsController(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        // returns null fields
        [HttpGet("certainColumns")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetCertainColumns()
        {
            try
            {
                var actors = await context.Actors
                        .Select(a => new Actor { Id = a.Id, Name = a.Name, DateOfBirth = a.DateOfBirth })
                        .ToListAsync();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // no null fields
        [HttpGet("dto")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActorDTOs()
        {
            try
            {
                var dtos = await context.Actors.Select(a => new ActorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                }).ToListAsync();
                return Ok(dtos);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ids")]
        public async Task<ActionResult<IEnumerable<int>>> GetIds()
        {
            try
            {
                var ids = await context.Actors.Select(x => x.Id).ToListAsync();
                return Ok(ids);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActor(int id, Actor actor)
        { 
            var actorToUpdate = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (actorToUpdate == null)
            {
                return BadRequest();
            }

            actorToUpdate.DateOfBirth = actor.DateOfBirth;
            actorToUpdate.Name = actor.Name;
            actorToUpdate.MoviesActors = actor.MoviesActors;
            actorToUpdate.Biography= actor.Biography;

            await context.SaveChangesAsync();
            return Ok(actorToUpdate);
        }
    }
}

