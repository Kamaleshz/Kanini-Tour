using Microsoft.AspNetCore.Mvc;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocation _repo;
        private readonly IWebHostEnvironment _environment;

        public LocationService(ILocation repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }
        
        public async Task<List<Location>> Get()
        {
            return await _repo.GetLocation();
        }

        public async Task<List<Location>> GetById(int Location_Id)
        {
            return await _repo.GetLocationById(Location_Id);
        }

        public async Task<Location> Post([FromForm]Location location, IFormFile image)
        {
            return await _repo.CreateLocation(location,image);
        }

        public async Task<Location>Put(int Location_Id,Location location, IFormFile image)
        {
            return await _repo.UpdateLocation(Location_Id,location,image);
        }

        public async Task<Location>Delete(int Location_Id)
        {
            return await _repo.DeleteLocation(Location_Id); 
        }
    }
}
