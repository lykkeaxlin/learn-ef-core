using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/cinemaoffer")]
    public class CinemaOfferController : ControllerBase
    {
        private readonly ICinemaOfferRepository cinemaOfferRepository;

        public CinemaOfferController(ICinemaOfferRepository cinemaOfferRepository)
        {
            this.cinemaOfferRepository = cinemaOfferRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaOffer>>> GetCinemaOffers()
        {
            try 
            { 
                var cinemaOffers = await cinemaOfferRepository.GetCinemaOffers();
                return Ok(cinemaOffers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
