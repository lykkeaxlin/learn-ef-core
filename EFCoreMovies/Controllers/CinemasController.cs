using EFCoreMovies.Dto;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CinemasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Cinemas not serializable due to Location, create a DTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaDTO>>> GetCinemas()
        {
            try 
            {
                var cinemas = await context.Cinemas.Select(c => new CinemaDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Latitude = c.Location.Y,
                    Longitude = c.Location.X
                }).ToListAsync();
                return Ok(cinemas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // anonymous type
        [HttpGet("closetoMe")]
        public async Task<ActionResult> Get(double latitude, double longitude, int maxDistance)
        {
            try 
            {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
                var cinemas = await context.Cinemas
                    .OrderBy(c => c.Location.Distance(myLocation))
                    .Where(c => c.Location.IsWithinDistance(myLocation, maxDistance))
                    .Select(c => new
                    {
                        Name = c.Name,
                        Distance = Math.Round(c.Location.Distance(myLocation))
                    }).ToListAsync();
                return Ok(cinemas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
