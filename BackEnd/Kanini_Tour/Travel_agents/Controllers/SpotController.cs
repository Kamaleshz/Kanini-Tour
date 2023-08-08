using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase
    {
        private readonly ISpotsService _service;

        public SpotController(ISpotsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Spots>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("Spot_Id")]
        public async Task<List<Spots>> GetById(int Spot_Id)
        {
            return await _service.GetById(Spot_Id);
        }

        [HttpPost]
        public async Task<Spots>Post([FromForm]Spots spot, IFormFile imageFile)
        {
            return await _service.Post(spot, imageFile);
        }

        [HttpPut]
        public async Task<Spots>Put(int Spot_Id,Spots spot, IFormFile imageFile)
        {
            return await _service.Put(Spot_Id, spot, imageFile);
        }

        [HttpDelete]
        public async Task<Spots>Delete(int Spot_Id)
        {
            return await _service.Delete(Spot_Id);
        }
    }
}
