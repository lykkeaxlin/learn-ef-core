using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using EFCoreMovies_Infra.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository actorRepository;

        public ActorController(IActorRepository actorRepository) 
        { 
            this.actorRepository = actorRepository;
        }

        // returns null fields
        [HttpGet("nullFields")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActorsNullFields()
        {
            try
            {
                var actors = await actorRepository.GetActorsNullFields();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // no null fields
        [HttpGet("noNullFields")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActorsNoNullFields()
        {
            try
            {
                var actors = await actorRepository.GetActors();
                var actorDtos = actors.Select(a => new ActorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                }).ToList();
                return Ok(actorDtos);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActor(int id, Actor actor)
        {
            try 
            {
                var updatedActor = await actorRepository.UpdateActor(actor);
                return Ok(updatedActor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

