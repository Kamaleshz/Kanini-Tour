using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Interface;
using Travellers.Models;

namespace Travellers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellerController : ControllerBase
    {
        private readonly ITravellerService service;

        public TravellerController(ITravellerService service)
        {
            this.service = service;
        }

        [HttpPost]

        public async Task<Traveller>Post([FromForm]Traveller traveller)
        {
            return await service.Post(traveller);
        }
    }
}
