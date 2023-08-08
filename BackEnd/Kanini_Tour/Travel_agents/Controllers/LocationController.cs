using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService location;

        public LocationController(ILocationService location)
        {
            this.location = location;
        }

        [HttpGet]

        public async Task<List<Location>> Get()
        {
            return await location.Get();
        }

        [HttpGet("Location_Id")]
        public async Task<List<Location>> GetById(int Location_Id)
        {
            return await location.GetById(Location_Id);
        }

        [HttpPost]
        public async Task<Location>Post([FromForm]Location Location , IFormFile image)
        {
            return await location.Post(Location,image);
        }

        [HttpPut]
        public async Task<Location>Put(int Location_Id, Location Location, IFormFile image)
        {
            return await location.Put(Location_Id,Location,image);
        }

        [HttpDelete]
        public async Task<Location> Delete(int Location_Id)
        {
            return await location.Delete(Location_Id);
        }
    }
}
