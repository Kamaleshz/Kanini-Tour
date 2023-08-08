using Microsoft.AspNetCore.Mvc;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Service
{
    public class SpotsService : ISpotsService
    {
        private readonly ISpots _repo;
        private readonly IWebHostEnvironment _environment;

        public SpotsService(ISpots repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<IEnumerable<Spots>> Get()
        {
            return await _repo.GetSpots();
        }

        public async Task<List<Spots>>GetById(int id)
        {
            return await _repo.GetSpotsById(id);
        }

        public async Task<Spots>Post([FromForm]Spots spot, IFormFile images)
        {
            return await _repo.CreateSpot(spot, images);
        }

        public async Task<Spots>Put(int Spot_Id,Spots spot,IFormFile images)
        {
            return await _repo.UpdateSpot(Spot_Id, spot, images);
        }

        public async Task<Spots>Delete(int Spot_Id)
        {
            return await _repo.DeleteSpot(Spot_Id);
        }
    }
}
