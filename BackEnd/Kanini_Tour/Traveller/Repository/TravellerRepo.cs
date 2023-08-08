using Microsoft.AspNetCore.Mvc;
using Travellers.Context;
using Travellers.Interface;
using Travellers.Models;

namespace Travellers.Repository
{
    public class TravellerRepo : ITraveller
    {
        private readonly TravellerContext _traveller;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TravellerRepo(TravellerContext context, IWebHostEnvironment webHostEnvironment)
        {
            _traveller = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Traveller> CreateTraveller([FromForm] Traveller traveller)
        {
            _traveller.Travellers.Add(traveller);
            await _traveller.SaveChangesAsync();

            return traveller;
        }
    }
}
