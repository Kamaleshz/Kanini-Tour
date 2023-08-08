using Microsoft.AspNetCore.Mvc;
using Travellers.Interface;
using Travellers.Models;

namespace Travellers.Service
{
    public class TravellerService : ITravellerService
    {
        private readonly ITraveller _repo;
        private readonly IWebHostEnvironment _environment;

        public TravellerService(ITraveller repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<Traveller> Post([FromForm] Traveller traveller)
        {
            return await _repo.CreateTraveller(traveller);
        }
    }
}
