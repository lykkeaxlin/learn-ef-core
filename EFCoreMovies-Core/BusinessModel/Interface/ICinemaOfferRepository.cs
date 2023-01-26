using EFCoreMovies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Core.BusinessModel.Interface
{
    public interface ICinemaOfferRepository
    {
        Task<IEnumerable<CinemaOffer>> GetCinemaOffers();
    }
}
