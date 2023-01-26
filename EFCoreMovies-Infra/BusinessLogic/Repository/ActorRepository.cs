using EFCoreMovies;
using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Infra.BusinessLogic.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext context;

        public ActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
    
        public async Task<IEnumerable<Actor>> GetActors()
        {
            var actors = await context.Actors.ToListAsync();
            return actors;
        }

        public async Task<Actor> UpdateActor(Actor actor)
        {
            var actorToUpdate = await context.Actors.FirstOrDefaultAsync(x => x.Id == actor.Id);

            if (actorToUpdate == null)
            {
                throw new ArgumentException($"Could not find Actor with id {actor.Id}");
            }

            actorToUpdate.DateOfBirth = actor.DateOfBirth;
            actorToUpdate.Name = actor.Name;

            await context.SaveChangesAsync();
            return actorToUpdate;
        }
    }
}
