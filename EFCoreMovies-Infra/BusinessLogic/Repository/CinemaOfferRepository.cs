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
    public class CinemaOfferRepository : ICinemaOfferRepository
    {
        private readonly ApplicationDbContext context;

        public CinemaOfferRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CinemaOffer>> GetCinemaOffers()
        {
            var cinemaOffers = await context.CinemaOffers.ToListAsync();
            return cinemaOffers;
        }
    }
}
