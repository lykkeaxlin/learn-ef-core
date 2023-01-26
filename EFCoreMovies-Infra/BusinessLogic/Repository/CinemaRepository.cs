using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreMovies;
using EFCoreMovies.Entities;
using EFCoreMovies_Core.BusinessModel.Interface;
using EFCoreMovies_Infra.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;

namespace EFCoreMovies_Infra.BusinessLogic.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext context;

        public CinemaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            var cinemas = await context.Cinemas
                .Include(x => x.CinemaOffer)
                .Include(x => x.CinemaHalls)
                    .ThenInclude(xx => xx.Movies)
                .ToListAsync();
            return cinemas;
        }
    }
}
