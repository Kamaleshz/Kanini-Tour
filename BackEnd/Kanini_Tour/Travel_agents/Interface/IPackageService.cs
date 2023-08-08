using Microsoft.AspNetCore.Mvc;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface IPackageService
    {
        public Task<IEnumerable<Package>> Get();

        public Task<List<Package>> GetById(int Package_Id);

        public Task<Package> Post([FromForm] Package Package, IFormFile imageFile);

        public Task<Package> Put(int Package_Id, Package Package, IFormFile imageFile);

        public Task<Package> Delete(int Package_Id);
    }
}
