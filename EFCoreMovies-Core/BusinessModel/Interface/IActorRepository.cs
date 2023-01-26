using EFCoreMovies.Entities;

namespace EFCoreMovies_Core.BusinessModel.Interface
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActors(); 
        Task<Actor> UpdateActor(Actor actor);
    }
}
