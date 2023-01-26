﻿using EFCoreMovies_Core.BusinessModel.Interface;
using EFCoreMovies_Infra.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaRepository cinemaRepository;

        public CinemaController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        // Cinemas not serializable due to Location, create a DTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaDTO>>> GetCinemas()
        {
            try 
            {
                var cinemas = await cinemaRepository.GetCinemas();
                return Ok(cinemas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}