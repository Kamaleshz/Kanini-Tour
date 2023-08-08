using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;

        public PackageController(IPackageService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Package>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("Package_Id")]
        public async Task<List<Package>>GetById(int Package_Id)
        {
            return await _service.GetById(Package_Id);
        }

        [HttpPost]
        public async Task<Package> Post([FromForm]Package package, IFormFile image)
        {
            return await _service.Post(package, image);
        }

        [HttpPut]
        public async Task<Package>Put(int Package_Id, Package package, IFormFile image)
        {
            return await _service.Put(Package_Id, package, image);
        }

        [HttpDelete]
        public async Task<Package> Delete(int Package_Id)
        {
            return await _service.Delete(Package_Id);
        }
    }
}
