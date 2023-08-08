using Microsoft.AspNetCore.Mvc;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface ILocationService
    {
        public Task<List<Location>> Get();

        public Task<List<Location>> GetById(int Location_Id);

        public Task<Location> Post([FromForm] Location locations, IFormFile imageFile);

        public Task<Location> Put(int Location_Id, Location location, IFormFile imageFile);

        public Task<Location> Delete(int Location_Id);
    }
}
