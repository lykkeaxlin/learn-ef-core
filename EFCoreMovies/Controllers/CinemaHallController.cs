using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/CinemaHall")]
    public class CinemaHallController : ControllerBase
    {
        private readonly ICinemaHallRepository cinemaHallRepository;

        public CinemaHallController(ICinemaHallRepository cinemaHallRepository)
        {
            this.cinemaHallRepository = cinemaHallRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaHall>>> GetCinemaHalls()
        {
            try 
            { 
                var cinemaHalls = await cinemaHallRepository.GetCinemaHalls();
                return Ok(cinemaHalls);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
