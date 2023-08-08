using Microsoft.AspNetCore.Mvc;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface ILocation
    {
        public Task<List<Location>> GetLocation();

        public Task< List<Location>> GetLocationById(int Location_Id);

        public Task<Location> CreateLocation([FromForm]Location locations, IFormFile imageFile);

        public Task<Location> UpdateLocation(int Location_Id, Location location, IFormFile imageFile);

        public Task<Location> DeleteLocation(int Location_Id);
    }
}
