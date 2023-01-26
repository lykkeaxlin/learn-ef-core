using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using EFCoreMovies_Infra.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/actor")]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository actorRepository;

        public ActorController(IActorRepository actorRepository) 
        { 
            this.actorRepository = actorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActors()
        {
            try
            {
                var actors = await actorRepository.GetActors();
                return Ok(actors);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActor(Actor actor)
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

