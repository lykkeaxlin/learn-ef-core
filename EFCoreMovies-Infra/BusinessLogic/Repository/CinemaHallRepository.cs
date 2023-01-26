using EFCoreMovies;
using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Infra.BusinessLogic.Repository
{
    public class CinemaHallRepository : ICinemaHallRepository
    {
        private readonly ApplicationDbContext context;

        public CinemaHallRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CinemaHall>> GetCinemaHalls()
        {
            var cinemaHalls = await context.CinemaHalls
                        .Include(x => x.Movies)
                        .ToListAsync();
            return cinemaHalls;
        }
    }
}
